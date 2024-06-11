-- Странный баг, почему то отображаются только те кто работает (((

CREATE PROCEDURE GetEmployeeList
AS
BEGIN
    SELECT 
        p.last_name + ' ' + LEFT(p.first_name, 1) + '. ' + LEFT(p.second_name, 1) + '.' AS FIO,
        s.name AS status_name,
        d.name AS department_name,
        ps.name AS post_name,
        p.date_employ,
        p.date_uneploy
    FROM 
        dbo.persons p
    JOIN 
        dbo.status s ON p.status = s.id
    JOIN 
        dbo.deps d ON p.id_dep = d.id
    JOIN 
        dbo.posts ps ON p.id_post = ps.id	
    WHERE 
        s.id IN (1, 2, 3);
END;
