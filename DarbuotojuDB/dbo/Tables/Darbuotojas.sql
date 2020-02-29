CREATE TABLE [dbo].[Darbuotojas] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Vardas]           NVARCHAR (50) NOT NULL,
    [Pavarde]          NVARCHAR (50) NOT NULL,
    [Asmens_kodas]     NVARCHAR (11) NOT NULL,
    [Gimimo_data]      DATE          NOT NULL,
    [Adresas]          NVARCHAR (70) NOT NULL,
    [Aktyvumo_pozymis] BIT           DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

