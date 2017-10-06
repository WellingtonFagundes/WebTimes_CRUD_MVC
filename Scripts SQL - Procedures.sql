use TimeAdo
go

CREATE PROCEDURE ExcluirTimePorId
(
	@TimeId		AS INT
)
AS
BEGIN
	
	DELETE FROM Times WHERE TimeId = @TimeId

END

exec ExcluirTimePorId 2

/*************************************************/
CREATE PROCEDURE AtualizarTime
(
	@TimeId		AS	INT,
	@Time		AS	NVARCHAR(100),
	@Estado		AS	CHAR(2),
	@Cores		AS  NVARCHAR(50)
)
AS
BEGIN
	
	UPDATE Times SET 
				 Time = @Time,
				 Estado = @Estado,
				 Cores = @Cores
		   WHERE TimeId = @TimeId

END

/********************************************************/
CREATE PROCEDURE InserirTime
(
	@Time		AS NVARCHAR(100),
	@Estado		AS CHAR(2),
	@Cores		AS NVARCHAR(50)
)
AS
BEGIN
	
	INSERT INTO Times (Time,Estado,Cores)
		   VALUES(@Time,@Estado,@Cores)

END

exec InserirTime 'São Paulo','SP','Tricolor'

/**************************************************************/
CREATE PROCEDURE ObterTimes
AS
BEGIN
	
	SELECT TimeId,Time,Estado,Cores FROM Times
END

exec ObterTimes