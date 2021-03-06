USE [Pruebas]
GO
/****** Object:  Table [dbo].[Administradores]    Script Date: 28/01/2022 08:44:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administradores](
	[idUsuario] [varchar](30) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Contrasena] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 28/01/2022 08:44:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[Matricula] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[ApellidoP] [varchar](20) NOT NULL,
	[ApellidoM] [varchar](20) NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Telefono] [varchar](10) NULL,
	[Email] [varchar](50) NULL,
	[Grupo] [varchar](3) NULL,
	[Password] [varchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 28/01/2022 08:44:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[idProfesor] [varchar](20) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[ApellidoPaterno] [varchar](30) NOT NULL,
	[ApellidoMaterno] [varchar](30) NULL,
	[Telefono] [varchar](10) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[idProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_AgregarAdministrador]    Script Date: 28/01/2022 08:44:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AgregarAdministrador]

@idUsuario varchar(30), @Nombre varchar(50), @contrasena varchar(30)
AS
IF NOT EXISTS(SELECT * FROM Administradores WHERE IdUsuario = @idUsuario)
	INSERT INTO Administradores (IdUsuario, Nombre, Contrasena) VALUES (@idUsuario, @Nombre, @contrasena)
GO
/****** Object:  StoredProcedure [dbo].[SP_AgregarProfesor]    Script Date: 28/01/2022 08:44:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AgregarProfesor]

@idProfesor varchar(20), @Nombre varchar(30), @ApellidoPaterno varchar(30), @ApellidoMaterno varchar(30),
@Telefono varchar(30), @Email varchar(50), @Password varchar(30)

AS

IF NOT EXISTS(SELECT idProfesor FROM Profesor WHERE idProfesor = @idProfesor)
	INSERT INTO Profesor (idProfesor, Nombre, ApellidoPaterno, ApellidoMaterno, Telefono, Email, Password) 
	VALUES (@idProfesor, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Telefono, @Email, @Password)
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarAdministrador]    Script Date: 28/01/2022 08:44:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarAdministrador]
	
@idUsuario varchar(30), @Nombre varchar(50)

AS
	DELETE FROM Administradores WHERE idUsuario = @idUsuario OR Nombre = @Nombre
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarProfesor]    Script Date: 28/01/2022 08:44:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarProfesor]

@idProfesor varchar(20)

AS

DELETE FROM Profesor WHERE idProfesor = @idProfesor
GO
