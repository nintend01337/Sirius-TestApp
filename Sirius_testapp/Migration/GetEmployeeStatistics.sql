CREATE PROCEDURE GetEmployeeStatistics
    @status_id INT,
    @start_date DATETIME,
    @end_date DATETIME,
    @is_employed BIT  -- 1 = принятые, 0 = уволенные
AS
BEGIN
    IF @is_employed = 1
    BEGIN
        -- Статистика по сотрудникам с указанным статусом, принятым за указанный период
        SELECT 
            CAST(p.date_employ AS DATE) AS date,
            COUNT(p.id) AS count
        FROM 
            dbo.persons p
        WHERE 
            p.status = @status_id
            AND p.date_employ BETWEEN @start_date AND @end_date
        GROUP BY 
            CAST(p.date_employ AS DATE);
    END
    ELSE
    BEGIN
        -- Статистика по сотрудникам с указанным статусом, уволенным за указанный период
        SELECT 
            CAST(p.date_uneploy AS DATE) AS date,
            COUNT(p.id) AS count
        FROM 
            dbo.persons p
        WHERE 
            p.status = @status_id
            AND p.date_uneploy BETWEEN @start_date AND @end_date
        GROUP BY 
            CAST(p.date_uneploy AS DATE);
    END
END;