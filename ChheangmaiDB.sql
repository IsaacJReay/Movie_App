CREATE DATABASE ChheangmaiDB; 
GO

USE ChheangmaiDB;
GO

CREATE TABLE Movie (
    Title nvarchar(255) NOT NULL PRIMARY KEY,
    Duration int NOT NULL,
    Subtitle nvarchar(255) NOT NULL,
    ReleaseDate DATE NOT NULL,
    Language nvarchar(255) NOT NULL,
    MovieType varchar(10) NOT NULL CHECK (MovieType IN('Action','Horror','Adventure','Science'))
);
GO

INSERT INTO Movie ("Title", "Duration", "Subtitle", "ReleaseDate", "Language", "MovieType")
VALUES ('Spider Man: No Way Home', 180, 'Khmer', '2000-02-12', 'English', 'Action');

INSERT INTO Movie ("Title", "Duration", "Subtitle", "ReleaseDate", "Language", "MovieType")
VALUES ('Jurassic Park', 120, 'English', '2010-10-20', 'English', 'Horror');

INSERT INTO Movie ("Title", "Duration", "Subtitle", "ReleaseDate", "Language", "MovieType")
VALUES ('The Northman', 210, 'Khmer', '2022-02-20', 'English', 'Adventure');

INSERT INTO Movie ("Title", "Duration", "Subtitle", "ReleaseDate", "Language", "MovieType")
VALUES ('Transformer 3', 210, 'Khmer', '2009-12-30', 'English', 'Science');

GO