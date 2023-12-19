create database order1
use order1
create table Stock
(
itemNum Int,
Parts Varchar(30),
Stock int,
quantity int
)
create table Stock1
(
itemNum Int,
Parts Varchar(30),
Stock int,
Price Int

)
create table CustStock
(
itemNum Int,
Parts Varchar(30),
Stock int,
Price Int,
Quantity Int
)
create table CustStock1
(
itemNum Int,
Parts Varchar(30),
Stock int,
Price Int,
Quantity Int,
TypeP Varchar(20)
)
create table Admin1
(
ID Varchar,
Pass Varchar(30)

)
create table Admin2
(
ID Varchar(30),
Pass Varchar(30)

)
create table AdminAcc
(
ID Varchar(30),
Pass Varchar(30)

)


create table Staff
(
ID Varchar(30),
Pass Varchar(30)
)
create table Custiomer
(
ID Varchar(30),
Pass Varchar(30)
)
select * from AdminAcc
INSERT INTO AdminAcc(ID,Pass) VALUES ('Renz','Lubas')
INSERT INTO Staff(ID,Pass) VALUES ('Staff','Only')
