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

--Tabela dhe queries per mi kqyr usernames,email, edhe a jon admin a user

create table AspNetUsers(
Id varchar(450) Primary Key,
UserName varchar(256),
NormalizedUserName varchar(256),
Email varchar(256),
NormalizedEmail varchar(256),
EmailConfirmed bit not null,
PasswordHash varchar(max),
SecurityStamp varchar(max),
ConcurrencyStamp varchar(max),
PhoneNumber varchar(max),
PhoneNumberConfirmed bit not null,
TwoFactorEnabled bit not null,
LockoutEnd datetimeoffset(7),
LockoutEnabled bit not null,
AccessFailedCount int not null
)

create table AspNetRoles(
Id varchar(450) Primary Key,
Name varchar(256),
NormalizedName varchar(256),
ConcurrencyStamp varchar(max)
)


create table AspNetUserRoles(
UserId varchar(450) not null,
RoleId varchar(450) not null,
constraint UserRolesPk primary key (UserId, RoleId),
constraint UserFk foreign key (UserId) references AspNetUsers(Id),
constraint RoleFk foreign key (RoleId) references AspNetRoles(Id),
)
SELECT ANR.Name,ANU.Email,ANU.UserName
FROM AspNetRoles ANR
LEFT OUTER JOIN AspNetUserRoles ANUR
ON ANR.Id=ANUR.RoleId
LEFT OUTER JOIN AspNetUsers ANU
ON ANU.Id=ANUR.UserId
ORDER BY 3

delete ANU
FROM AspNetRoles ANR
full JOIN AspNetUserRoles ANUR
ON ANR.Id=ANUR.RoleId
full JOIN AspNetUsers ANU
ON ANU.Id=ANUR.UserId
where ANR.Name is not null and ANU.Email is null and ANU.UserName is null






