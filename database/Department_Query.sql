create table dbo.Department (
DepartmentId int identity(1,1), 
DepartmentName varchar(500)
)

insert into dbo.Department values ('IT')

insert into dbo.Department values ('Finance')

select * from dbo.Department