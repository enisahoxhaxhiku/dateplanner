create database LabKurs1
use LabKurs1

create table Perdoruesi(
PerdoruesiID  int Primary key identity(1,1),
PerdoruesiName varchar(50),
PerdoruesiSurname varchar(70),
PerdoruesiEmail varchar(80)

)

select * from Perdoruesi

insert into Perdoruesi values('Enisa' ,'Hoxhaxhiku','enisahoxhaxhiku@hotmail.com')
insert into Perdoruesi values('Adea' ,'Mulaku','adeamulaku@gmail.com')

create table Takimet(
 TakimetID int Primary key identity(1,1),
 LlojiTakimit varchar(70),
 DataTakimit date

)

select * from Takimet

insert into Takimet values('Familjar' ,'4-28-2022')
insert into Takimet values('Shoqeror' ,'5-28-2022')


create table Lokacioni(
 LokacioniID int Primary key identity(1,1),
 Aktivitetet varchar(10),--Hapur ose Mbyllur
 LlojiLokacionit varchar(30)
 

)
select * from Lokacioni

insert into Lokacioni values('Mbyllur' , 'Restaurant')
insert into Lokacioni values('Hapur' ,'Swimming')

