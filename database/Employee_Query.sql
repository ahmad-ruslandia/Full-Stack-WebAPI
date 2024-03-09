create table dbo.Employee (
EmployeeId int identity(1,1),
EmployeeName varchar(500),
Department varchar(500),
DateOfJoining date,
PhotoFileName varchar(500)
)

insert into dbo.Employee values ('user 1', 'IT', '2024-06-01', 'picture.png')

select * from dbo.Employee