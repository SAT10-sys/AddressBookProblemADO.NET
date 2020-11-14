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


