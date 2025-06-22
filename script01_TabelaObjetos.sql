IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TB_OBJETOS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [LocalidadePrimaria] nvarchar(max) NOT NULL,
    [LocalidadeSecundaria] nvarchar(max) NOT NULL,
    [LocalidadeTercearia] nvarchar(max) NOT NULL,
    [Situacao] nvarchar(max) NOT NULL,
    [idTipoObjeto] int NOT NULL,
    [DataInclusao] nvarchar(max) NOT NULL,
    [IdUsuarioInclusao] int NOT NULL,
    [DataAtualizacao] nvarchar(max) NOT NULL,
    [IdUsuarioAtualizacao] int NOT NULL,
    CONSTRAINT [PK_TB_OBJETOS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAtualizacao', N'DataInclusao', N'Descricao', N'IdUsuarioAtualizacao', N'IdUsuarioInclusao', N'LocalidadePrimaria', N'LocalidadeSecundaria', N'LocalidadeTercearia', N'Nome', N'Situacao', N'idTipoObjeto') AND [object_id] = OBJECT_ID(N'[TB_OBJETOS]'))
    SET IDENTITY_INSERT [TB_OBJETOS] ON;
INSERT INTO [TB_OBJETOS] ([Id], [DataAtualizacao], [DataInclusao], [Descricao], [IdUsuarioAtualizacao], [IdUsuarioInclusao], [LocalidadePrimaria], [LocalidadeSecundaria], [LocalidadeTercearia], [Nome], [Situacao], [idTipoObjeto])
VALUES (1, N'2025-06-21', N'2025-06-20', N'Mesa de madeira', 100, 100, N'Predio A', N'Andar 1', N'Sala 101', N'Mesa', N'Ativa', 1),
(2, N'2025-06-20', N'2025-06-18', N'Cadeira ergonômica para escritório', 101, 101, N'Prédio B', N'Andar 2', N'Sala 205', N'Cadeira', N'Em uso', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAtualizacao', N'DataInclusao', N'Descricao', N'IdUsuarioAtualizacao', N'IdUsuarioInclusao', N'LocalidadePrimaria', N'LocalidadeSecundaria', N'LocalidadeTercearia', N'Nome', N'Situacao', N'idTipoObjeto') AND [object_id] = OBJECT_ID(N'[TB_OBJETOS]'))
    SET IDENTITY_INSERT [TB_OBJETOS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250621234713_InitialCreate', N'9.0.6');

COMMIT;
GO

