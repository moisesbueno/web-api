# web-api


create table Book
(
	Id char(36),
	name varchar(50),
	primary key (Id)
)


dotnet tool install --global dotnet-ef


dotnet ef dbcontext scaffold "Server=localhost;User=root;Password=my-secret-pw;Database=Sales" "Pomelo.EntityFrameworkCore.MySql"




