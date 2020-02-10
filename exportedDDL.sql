--------------------------------------------------------
--  File created - Monday-February-10-2020   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table EMPLOYEES
--------------------------------------------------------

  CREATE TABLE "EMPLOYEES" ("FIRST_NAME" VARCHAR2(50))
REM INSERTING into EMPLOYEES
SET DEFINE OFF;
--------------------------------------------------------
--  DDL for Procedure ADDFIRSTNAME
--------------------------------------------------------
set define off;

  CREATE OR REPLACE NONEDITIONABLE PROCEDURE "ADDFIRSTNAME" (
  firstname employees.first_name%type
)
is
BEGIN
INSERT INTO employees (first_name) VALUES (firstname);

END;
