CREATE PROCEDURE [dbo].[ContactSearchOrView]
	@Name nvarchar(50)
	
AS
	SELECT * from tbl_Contact where name LIKE @Name+'%'
RETURN 0
