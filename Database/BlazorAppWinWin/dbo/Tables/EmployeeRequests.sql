﻿CREATE TABLE [dbo].[EmployeeRequests] (
    [EmployeeRequestId] BIGINT        IDENTITY (80000, 1) NOT NULL,
    [EmployeeId]        BIGINT        NULL,
    [EmpAppOprStatusId] SMALLINT      NULL,
    [EmpAppReqStatusId] SMALLINT      NULL,
    [Title]             SMALLINT      NULL,
    [FirstName]         VARCHAR (255) NULL,
    [LastName]          VARCHAR (255) NULL,
    [PersonalEmail]     VARCHAR (500) NULL,
    [DOB]               DATETIME      NULL,
    [DOJ]               DATETIME      NULL,
    [IsActive]          BIT           NULL,
    [CreatedOn]         DATETIME      NULL,
    [CreatedBy]         BIGINT        NULL,
    [ModifidOn]         DATETIME      NULL,
    [ModifiedBy]        BIGINT        NULL
);

