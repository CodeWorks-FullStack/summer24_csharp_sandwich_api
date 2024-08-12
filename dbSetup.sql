CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL pRiMaRy kEy COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) UNIQUE COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
  ) default charset utf8mb4 COMMENT '';

-- CREATING TABLE
CREATE TABLE
  sandwiches (
    -- id is the column, int is the data type, not null means it is required, auto increment creates the id for us
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    -- bread is the column, varchar is the string data type, and the string must be no larger than 255 bytes (close to a length of 255), and is required
    bread VARCHAR(255) NOT NULL,
    protein VARCHAR(255) NOT NULL,
    dressing VARCHAR(255) NOT NULL,
    -- unsigned means that it must be positive
    calories SMALLINT UNSIGNED NOT NULL,
    hasPickles BOOL NOT NULL DEFAULT false
  ) default charset utf8mb4 COMMENT '';

-- CREATE
INSERT INTO
  sandwiches (bread, protein, dressing, calories, hasPickles)
VALUES
  ('white', 'cheese', 'mayo', 5002, false);

-- DELETE
DELETE FROM sandwiches
WHERE
  id = 1;

-- GET
SELECT
  *
FROM
  sandwiches;

-- UPDATE
UPDATE sandwiches
SET
  `hasPickles` = false
WHERE
  protein = 'cheese';