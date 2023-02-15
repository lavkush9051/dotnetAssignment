create database EfCoreDb
use EfCoreDb

--table name should be in plural form
create table Departments
(DepartmentId smallint identity(1,1) primary key,
DepartmentName varchar(50) not null)

insert into Departments values('Accounts'),('Computers'),('Human Resorces'), ('Sales & Marketing')

create table Employees(
EmployeeId smallint identity(1,1) primary key,
EmployeeName varchar(50),
DepartmentId smallint foreign key references Departments(DepartmentId),
Salary money,
JoinDate date)

select * from employees
select * from Departments

sp_help Departments

insert into Departments values('Account'),('Human Resources'), ('Sales & Marketing'),('IT');

select * from employees 

create procedure proc_emp_insert @employeename varchar(50), @departmentid varchar(50), @salary decimal, @employeeid int out
as
begin
	insert into Employees values (@employeeid, @departmentid, @salary)
	set @employeeid = SCOPE_IDENTITY()
end

create procedure pro_getEmployees as
begin
select e.employeeid, e.employeename, e.salary, d.departmentname

select * from sys.procedures
sp_helptext proc_emp_insert

---------================================================================

create database abcBankDb
create table Tbl_AccountOpen
(AccountNumber smallint identity(1,1) primary key,
AccountName varchar(50), Address varchar(100), OpeningDate datetime, Balance money)

create table Tbl_Transactions
(TransactionId smallint identity(1,1) primary key,
AccountNumber smallint foreign key references Tbl_AccountOpen(AccountNumber),
TransactionDate datetime,
TransactionType char,
TransactionAmount money)--=======Account open procedurealter procedure Proc_AccountOpen @AccountName varchar(50), @Address varchar(100), @DepositeAmount smallint,@AccountNumber smallint outasbegin	begin try	begin transaction		insert into  Tbl_AccountOpen values(@AccountName, @Address, getDate(),@DepositeAmount)		set @AccountNumber = SCOPE_IDENTITY()		insert into Tbl_Transactions values(@AccountNumber, getDate(), 'D', @DepositeAmount)--		set @TransactionId = SCOPE_IDENTITY()	commit transaction	end try	begin catch		rollback transaction		print error_message()	end catchend

declare
	@accNumber smallint
	begin 
		execute Proc_AccountOpen @AccountName = 'Rahul', @Address = 'kolkata', @DepositeAmount='10000',
		@AccountNumber = @accNumber out
		print 'Account no. is :' + cast(@accNumber as varchar)
	end

--=======transaction procedure
create procedure Proc_Transactions @AccountNumber smallint, @TransactionType char,
@TransactionAmount smallint, @TransactionId smallint out
as
declare @bal smallint
	begin
		begin try
			begin transaction
			insert into Tbl_Transactions values(@AccountNumber, getDate(), @TransactionType, @TransactionAmount)
			set @TransactionId = SCOPE_IDENTITY()
			--select * from Tbl_AccountOpen where AccountNumber = @AccountNumber
			--IF @TransactionAmount > (select Balance from Tbl_AccountOpen where AccountNumber = @AccountNumber)
			
			select @bal=balance from Tbl_AccountOpen where AccountNumber = @AccountNumber
			IF @TransactionType='D'
				begin
				update Tbl_AccountOpen
					set Balance = @bal + @TransactionAmount where AccountNumber = @AccountNumber
				end
			ELSE IF @TransactionType = 'W'
				IF (@bal - @TransactionAmount) > 0
					begin
					update Tbl_AccountOpen
						set Balance = @bal - @TransactionAmount where AccountNumber = @AccountNumber
					end
				ELSE 
					Raiserror(15600, -1, -1, 'Proc_Transsctions')
			ELSE
				begin
					Raiserror(15600, -1, -1, 'Proc_Transsctions')
				end
			commit transaction		end try		begin catch			rollback transaction			print error_message()		end catch
	end


declare 
	@transId smallint
	begin
		execute Proc_Transactions @AccountNumber = '2', @TransactionType = 'W', @TransactionAmount='11000',
		@TransactionId = @transId out
		print 'Transaction id :' + cast(@transId as varchar)
	end





--delete from Tbl_AccountOpen
select * from Tbl_AccountOpen
select * from tbl_transactions
sp_help tbl_Accountopen
sp_help tbl_transactions

select * from Departments
select * from Employees