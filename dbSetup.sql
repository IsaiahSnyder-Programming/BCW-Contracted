CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
--
--
CREATE TABLE IF NOT EXISTS companies(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name VARCHAR(255) NOT NULL,
  location VARCHAR(255) NOT NULL
) default charset utf8 COMMENT '';
--
--
DROP TABLE companies;
--
--
INSERT INTO
  companies(name, location)
VALUES("Tam & Hams Green Eggs and Jam", "Yeet Street");
INSERT INTO
  companies(name, location)
VALUES("Tyler Scotts Brewery and Bar", "Yeet Street");
INSERT INTO
  companies(name, location)
VALUES("Drakes Donkeys", "Yeet Street");
--
  --
SELECT
  *
FROM
  companies;
--
  --
DELETE FROM
  companies
WHERE
  id = 1;
--
  --
  --
  --
  --
  --
  CREATE TABLE IF NOT EXISTS contractors(
    id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL
  ) default charset utf8 COMMENT '';
--
  --
  DROP TABLE IF EXISTS contractors;
--
  --
INSERT INTO
  contractors(name)
VALUES("Drake");
INSERT INTO
  contractors(name)
VALUES("Tamra");
INSERT INTO
  contractors(name)
VALUES("Hannah");
INSERT INTO
  contractors(name)
VALUES("Ty");
INSERT INTO
  contractors(name)
VALUES("Scott");
--
  --
  --
  --
  --
  --