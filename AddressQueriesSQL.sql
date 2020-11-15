create database AddressBookADONET
select * from sys.databases where name='AddressBookADONET'
use AddressBookADONET
--database created

create table AddressBookTable
(
firstName varchar(30) not null,
lastName varchar(30) not null,
address varchar(100) not null,
city varchar(30) not null,
state varchar(30) not null,
zipCode varchar(6) not null,
phoneNumber varchar(10) not null,
emailId varchar(50) not null,
);
--table created

select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='AddressBookTable';

insert into AddressBookTable values
('James','Hetfield','DownTown','San Francisco','California','111111','1111111111','fdjil@yahoo.com'),
('Lars','Ulrich','San Jose','San Francisco','California','222222','2222222222','uhkdf@gmail.com'),
('Cliff','Burton','Manhattan','New York City','New York','333333','3333333333','ljsd@yahoo.com'),
('Kirk','Hammet','Queens','New York City','New York','444444','4444444444','fldkja@gmail.com'),
('Steven','Wilson','Rajarhat','Kolkata','West Bengal','555555','5555555555','hksld23@yahoo.com'),
('Freddie','Mercury','Esplanade','Kolkata','West Bengal','666666','6666666666','fljwk@yahoo.com');
select * from AddressBookTable
--values inserted in table

update AddressBookTable set phoneNumber='7777777777' where firstName='James';
select * from AddressBookTable
--updated


alter table AddressBookTable add bookName varchar(20), bookType varchar(20);

update AddressBookTable set bookName='Book1', bookType='Family' where firstName='James' or firstName='Kirk';
update AddressBookTable set bookName='Book2', bookType='Friends' where firstName='Lars' or firstName='Steven';
update AddressBookTable set bookName='Book3', bookType='Job' where firstName='Cliff' or firstName='Freddie';
select * from AddressBookTable

update AddressBookTable set address='Newark' where firstName='Kirk';
select * from AddressBookTable

/* ERDIAGRAM */
create table Contact
(
CId int identity(1,1) not null primary key,
FirstName varchar(30) not null,
LastName varchar(30) not null,
PhoneNumber varchar(10) not null,
EmailId varchar(50) not null,
);
insert into Contact values
('James','Hetfield','1111111111','jhetfield@gmail.com'),
('Lars','Ulrich','2222222222','lulrich@yahoo.com'),
('Cliff','Burton','3333333333','cburton@gmail.com'),
('Kirk','Hammet','4444444444','khammet@yahoo.com'),
('Steven','Wilson','5555555555','swilson@gmail.com'),
('Freddie','Mercury','6666666666','fmercury@yahoo.com');
select * from Contact

create table Type
(
CId int foreign key references Contact(CId) on delete cascade,
CName varchar(20) not null,
CType varchar(20) not null,
);
insert into Type values
(1,'Book1','Family'),
(2,'Book3','Job'),
(3,'Book3','Job'),
(4,'Book2','Friends'),
(5,'Book1','Family'),
(6,'Book2','Friends');
select * from Type



create table Address
(
CId int foreign key references Contact(CId) on delete cascade,
Address varchar(100) not null,
City varchar(30) not null,
State varchar(30) not null,
ZipCode varchar(6) not null,
);
insert into Address values
(1,'DownTown','San Francisco','California','111111'),
(2,'San Jose','San Francisco','California','222222'),
(3,'Manhattan','New York City','New York','333333'),
(4,'Newark','New York City','New York','444444'),
(5,'Rajarhat','Kolkata','West Bengal','555555'),
(6,'Esplanade','Kolkata','West Bengal','666666');
select * from Address

select * from (Contact contact inner join Type type on (contact.CId=type.CId)) inner join Address address on address.CId=contact.CId;

alter table Contact add DateAdded datetime
update Contact set DateAdded='2020-03-12' where CId=1;
update Contact set DateAdded='2018-11-12' where CId=2;
update Contact set DateAdded='2019-07-12' where CId=3;
update Contact set DateAdded='2019-08-15' where CId=4;
update Contact set DateAdded='2019-08-19' where CId=5;
update Contact set DateAdded='2020-09-18' where CId=6;
select * from Contact
select * from Contact where DateAdded between '2018-12-31' and GETDATE();


