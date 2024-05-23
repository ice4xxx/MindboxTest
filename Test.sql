CREATE TABLE product(id INT NOT NULL PRIMARY KEY, name varchar(max));
CREATE TABLE category(id INT NOT NULL PRIMARY KEY, name varchar(max));
CREATE TABLE product_category (product_id INT NOT NULL REFERENCES product(id), category_id INT NOT NULL REFERENCES category(id), PRIMARY KEY (product_id, category_id));

INSERT INTO product VALUES (1, 'minbox_1');
INSERT INTO product VALUES (2, 'minbox_2');
INSERT INTO product VALUES (3, 'minbox_3');
INSERT INTO product VALUES (4, 'minbox_4');

INSERT INTO category VALUES (1, 'category_1');
INSERT INTO category VALUES (2, 'category_2');
INSERT INTO category VALUES (3, 'category_3');
INSERT INTO category VALUES (4, 'category_4');

INSERT INTO product_category VALUES (3, 2);
INSERT INTO product_category VALUES (1, 1);
INSERT INTO product_category VALUES (2, 1);
INSERT INTO product_category VALUES (3, 3);
INSERT INTO product_category VALUES (2, 2);
INSERT INTO product_category VALUES (3, 1);


SELECT p.name, c.name FROM product_category RIGHT JOIN product p on product_category.product_id = p.id
                                            LEFT JOIN category c on product_category.category_id = c.id
ORDER BY p.name, c.name;