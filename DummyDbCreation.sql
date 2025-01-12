IF OBJECT_ID('Cars', 'U') IS NOT NULL
    DROP TABLE Cars
GO

CREATE TABLE Cars(
    CarID INT NOT NULL PRIMARY KEY,
    Model VARCHAR(50) NOT NULL,
    CurrentHolder VARCHAR(50) NOT NULL,
    CarType VARCHAR(50) NOT NULL
)


INSERT INTO Cars
([CarID], [Model], [CurrentHolder], [CarType])
VALUES
    (1, N'Opel', N'DEALERSHIP', N'Van'),
    (2, N'Opel', N'DEALERSHIP', N'Family Car'),
    (3, N'Volvo', N'DEALERSHIP', N'Van'),
    (4, N'Volvo', N'DEALERSHIP', N'Lorry'),
    (5, N'Toyota', N'DEALERSHIP', N'Motorbike')

GO

SELECT * FROM Cars