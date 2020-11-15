use AddressBookADONET
go
create or alter procedure GetCountByCityState
as
begin
select State, City, Count(FirstName) from Contact inner join Address on Contact.CId=Address.CId group by City, State
end