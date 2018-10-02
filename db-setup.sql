-- CREATE TABLE frenchfries (
--   id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   price DECIMAL(10,2) NOT NULL,
--   PRIMARY KEY(id)
-- );

INSERT INTO frenchfries (name, description, price) 
VALUES ("Animal Style Fries", "Fries smothered by all things unhealthy!", 11.99);

-- SELECT * FROM frenchfries;

-- ALTER TABLE frenchfries MODIFY COLUMN price DECIMAL(10,2);

-- UPDATE frenchfries SET 
--   price = 7.99, 
--   name = "The Plain Jane with Cheese", 
--   description = "Burger on a bun with cheese"
--   WHERE id = 1;

-- DELETE FROM frenchfries WHERE id = 1;


