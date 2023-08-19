create database ProductInventoryDb
use ProductInventoryDb

create table Products
(PId int primary key,
PName nvarchar(150),
Price float,
Quantity int,
MfDate Date,
ExpDate Date 
);

insert into Products values(1,'Spray',99.9,90,'12/02/22','01/09/23')
insert into Products values(2,'Powder',99.9,90,'12/03/22','01/05/23')
insert into Products values(3,'lipstick',99.9,90,'12/04/22','01/08/23')

drop table Products
select *from Products