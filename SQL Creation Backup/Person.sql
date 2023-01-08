CREATE TABLE Persons(
    personID INT AUTO_INCREMENT PRIMARY KEY,
    firstName VARCHAR(100),
    lastName VARCHAR(100),
    beltLevelID INT,
    email VARCHAR(100),
	dateOfBirth DATE,
	canGradeStudents BOOLEAN,
	FOREIGN KEY (beltLevelID) REFERENCES BeltLevel(beltLevelID)
);

INSERT INTO Persons (firstName,lastName,beltLevelID,email,dateOfBirth) VALUES
('Sam','North',11,'snorth@gmail.com','1962-05-20');
INSERT INTO Persons (firstName,lastName,beltLevelID,email,dateOfBirth) VALUES
('Kimberly','North',4,'snorth@gmail.com','2012-11-10');
INSERT INTO Persons (firstName,lastName,beltLevelID,email,dateOfBirth) VALUES
('Kylie','North',1,'snorth@gmail.com','2016-04-15');
INSERT INTO Persons (firstName,lastName,beltLevelID,email,dateOfBirth) VALUES
('Jasmine','Newman',17,'catgirl457@gmail.com','1972-02-12');
INSERT INTO Persons (firstName,lastName,beltLevelID,email,dateOfBirth) VALUES
('Kevin','Scott',12,'kscott@gmail.com','1998-04-14');
INSERT INTO Persons (firstName,lastName,beltLevelID,email,dateOfBirth) VALUES
('Mary','Rutherford',3,'mrutherford@gmail.com','2001-05-20');
INSERT INTO Persons (firstName,lastName,beltLevelID,email,dateOfBirth) VALUES
('Tom','Simpson',2,'sblack@gmail.com','2000-01-11');
INSERT INTO Persons (firstName,lastName,beltLevelID,email,dateOfBirth) VALUES
('Rachel','Stewart',15,'karatelady1231@gmail.com','2013-12-21');
INSERT INTO Persons (firstName,lastName,beltLevelID,email,dateOfBirth) VALUES
('Stephanie','Wright',8,'oliverwright@gmail.com','2015-09-19');
INSERT INTO Persons (firstName,lastName,beltLevelID,email,dateOfBirth) VALUES
('Adam','Wright',2,'oliverwright@gmail.com','2009-11-26');

SELECT firstName, lastName, BeltLevel.name, email, dateOfBirth
FROM Persons
INNER JOIN BeltLevel ON Persons.beltLevelID=BeltLevel.beltLevelID;
