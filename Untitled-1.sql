-- CREATE TABLE burger (
-- id int NOT NULL AUTO_INCREMENT,
-- name VARCHAR(255) NOT NULL,
-- description VARCHAR(255) NOT NULL,
-- price DECIMAL NOT NULL,
-- PRIMARY KEY(id)
-- );


-- * this will "create" a table
-- * you only need to "create" a table once

-- --  this is the name of the table
-- INSERT INTO burger (name, description, price) 
-- VALUES ("The Plain Jane", "Burger on a bun", 7.99);
-- "insert" will add to the table


-- SELECT * FROM burgers;

-- ALTER TABLE burger MODIFY COLUMN price DECIMAL(10,2);
-- "alter" will alter the table itself.



UPDATE burger SET 
price = 7.99,
name = "The Plain Jane with Cheese",
description = "burger on a bun"
WHERE id = 1;
-- "update" will update the data within the table




-- if you forget your WHERE, you will overwrite all your data
-- update the table where I set the price where the id is 1
-- its not worth your TEA to memorize SQL commands

-- DELETE FROM burgers WHERE id = 1;
--"delete" will delete.

