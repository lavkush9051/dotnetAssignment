---*****************customers
create table Customers(CustomerId smallint identity(1,1) primary key, 
						CustomerName varchar(30), CustomerAddress varchar(50))

insert into Customers values('Vishal Sharma', 'Gwahati'),
							('Suvojit Achh', 'Kolkata'),
							('Somnath Kundu', 'Kolkata'),
							('Ravi Teja','Mumbai')
--alter table Customers add Contact bigint
alter table Customers add EmailId varchar(30)
alter table customers add Password varchar(20)
--alter table customers drop column Contact
update customers set EmailId = 'vishal@sharma', Password = '123456' where CustomerId = 1
update customers set EmailId = 'suvojit@Achh', Password = '123456' where CustomerId = 2
update customers set EmailId = 'somnath@kundu', Password = '123456' where CustomerId = 3
update customers set EmailId = 'ravi@teja', Password = '123456' where CustomerId = 4
update customers set EmailId = 'diptanu@ghosh', Password = '123456' where CustomerId = 5
update customers set EmailId = 'rahul@das', Password = '123456' where CustomerId = 6
update customers set EmailId = 'rajan@sharma', Password = '123456' where CustomerId = 7

select * from Customers

							---*********************** service table

create table ServicesTable (ServiceId smallint identity(1,1) primary key,
							ServiceName varchar(30))

insert into ServicesTable values('Plumber'),('Carpenter'),('Electrician'),('Salon'),('Massage'),
								('Ac Repair')


							---*************************owners table

create table Owners(OwnerId smallint identity(1,1) primary key, 
						OwnerName varchar(30), ServiceId smallint foreign key references ServicesTable(ServiceId), 
						 YearOfExp smallint, CostToService smallint )

alter table Owners add OwnerEmailId varchar(20)
alter table Owners add OwnerPassword varchar(20)

insert into Owners values('Abhi',2,2,400),
						 ('Ramu',1,3,300),
						 ('Dipu',2,1,200),
						 ('Ajay',4,2,200)
update Owners set OwnerEmailId = 'abhi@nseit', OwnerPassword = '123456' where OwnerId = 1
update Owners set OwnerEmailId = 'ramu@nseit', OwnerPassword = '123456' where OwnerId = 2
update Owners set OwnerEmailId = 'dipu@nseit', OwnerPassword = '123456' where OwnerId = 3
update Owners set OwnerEmailId = 'ajay@nseit', OwnerPassword = '123456' where OwnerId = 4
update Owners set OwnerEmailId = 'balamani@nseit', OwnerPassword = '123456' where OwnerId = 5

						------************************requestTable*********
create table CustomersRequest (AppointmentId smallint identity(1,1) primary key,
							  CustomerId smallint foreign key references Customers(CustomerId),
							  DateOfAppointment datetime)
alter table CustomersRequest add OwnerId smallint foreign key references Owners(OwnerId)

--update CustomersRequest set OwnerId = 1 where AppointmentId = 2 

						------************************requestTable*********
create table ServicesList (AppointId smallint identity(1,1) primary key,
						  CustomerId smallint foreign key references Customers(CustomerId),
						  OwnerId smallint foreign key references Owners(OwnerId),
						  DateofAppointment datetime)

insert into ServicesList values(1, 3, '2023-03-12 10:23:23')
insert into ServicesList values(1, 4, '2023-03-14 10:23:23')
insert into ServicesList values(1, 2, '2023-03-15 11:20:23')
insert into ServicesList values(2, 4, '2023-03-14 10:23:23')

--------- Admin table
Create table Admin (AdminId smallint identity(1,1) primary key,
					UserName varchar(30),
					Email varchar(20),
					Password varchar(20))

insert into Admin values('Lavkush', 'lav@singh','123456'),
						('Shiva', 'shiva@india', '654321')
alter table Admin add Roles varchar(20)

select * from Admin
--alter table Admin drop column roles
-------------------------------
insert into CustomersRequest values(4,'2023-02-12 10:23:23',2)

select * from CustomersRequest
select * from Customers
select * from ServicesTable
select * from Owners
sp_help Owners
sp_help serviceslist

select * from serviceslist

select * from CustomersRequest
select * from sys.tables