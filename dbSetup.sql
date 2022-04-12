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
UPDATE
  accounts
SET
  id = "6255f845dbac55a6d8a432c7"
WHERE
  id = "621fe5d6dbe50cea2b338f0c";
--
  --
SELECT
  *
FROM
  accounts;
--
  --
  CREATE TABLE IF NOT EXISTS companies(
    creatorId varchar(255) NOT NULL,
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    location VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts(id)
  ) default charset utf8 COMMENT '';
--
  --
  DROP TABLE companies;
--
  --
INSERT INTO
  companies(name, location, `creatorId`)
VALUES(
    "Tam & Hams Green Eggs and Jam",
    "Yeet Street",
    "6255f845dbac55a6d8a432c7"
  );
INSERT INTO
  companies(name, location, `creatorId`)
VALUES(
    "Tyler Scotts Brewery and Bar",
    "Yeet Street",
    "6255f845dbac55a6d8a432c7"
  );
INSERT INTO
  companies(name, location, `creatorId`)
VALUES(
    "Drakes Donkeys",
    "Yeet Street",
    "6255f845dbac55a6d8a432c7"
  );
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
SELECT
  c.*,
  a.*
FROM
  companies c
  JOIN accounts a
WHERE
  a.id = c.creatorId;
--
  --
INSERT INTO
  companies (name, location, creatorId)
VALUES
  (
    "Tam and Ham Green Eggs and Jam",
    "Yeet Street",
    "6255f845dbac55a6d8a432c7"
  );
SELECT
  LAST_INSERT_ID();
--
  --
  --
  --
  --
  --
  CREATE TABLE IF NOT EXISTS contractors(
    creatorId varchar(255) NOT NULL,
    id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts(id)
  ) default charset utf8 COMMENT '';
--
  --
  DROP TABLE IF EXISTS contractors;
--
  --
INSERT INTO
  contractors(name, creatorId)
VALUES("Drake", "6255f845dbac55a6d8a432c7");
INSERT INTO
  contractors(name, creatorId)
VALUES("Tamra", "6255f845dbac55a6d8a432c7");
INSERT INTO
  contractors(name, creatorId)
VALUES("Hannah", "6255f845dbac55a6d8a432c7");
INSERT INTO
  contractors(name, creatorId)
VALUES("Ty", "6255f845dbac55a6d8a432c7");
INSERT INTO
  contractors(name, creatorId)
VALUES("Harrison", "6255f845dbac55a6d8a432c7");
--
  --
SELECT
  *
FROM
  contractors;
--
  --
  --
  --
  --
  --