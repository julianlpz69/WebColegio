using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreGrado = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "materia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreMateria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materia", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePais = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    rolName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_documento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_documento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_nota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorPorcentaje = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_nota", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreGrupo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdGradoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_grupo_grado_IdGradoFK",
                        column: x => x.IdGradoFK,
                        principalTable: "grado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreDepartamento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPaisFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_pais_IdPaisFK",
                        column: x => x.IdPaisFK,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdRolFK = table.Column<int>(type: "int", nullable: false),
                    IdPersonaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_rol_IdRolFK",
                        column: x => x.IdRolFK,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo_materia",
                columns: table => new
                {
                    IdGrupoFK = table.Column<int>(type: "int", nullable: false),
                    IdMateriaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_materia", x => new { x.IdGrupoFK, x.IdMateriaFK });
                    table.ForeignKey(
                        name: "FK_grupo_materia_grupo_IdGrupoFK",
                        column: x => x.IdGrupoFK,
                        principalTable: "grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grupo_materia_materia_IdMateriaFK",
                        column: x => x.IdMateriaFK,
                        principalTable: "materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCiudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDepartamentoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ciudad_departamento_IdDepartamentoFK",
                        column: x => x.IdDepartamentoFK,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Documento = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    IdTipoDocumentoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_tipo_documento_IdTipoDocumentoFK",
                        column: x => x.IdTipoDocumentoFK,
                        principalTable: "tipo_documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_usuario_Id",
                        column: x => x.Id,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUsuarioFK = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refresh_token_usuario_IdUsuarioFK",
                        column: x => x.IdUsuarioFK,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "archivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ruta = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPersonaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_archivo_Personas_IdPersonaFK",
                        column: x => x.IdPersonaFK,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DireccionEscrita = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Barrio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estrato = table.Column<int>(type: "int", nullable: false),
                    IdCiudadFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_direccion_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_direccion_ciudad_IdCiudadFK",
                        column: x => x.IdCiudadFK,
                        principalTable: "ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estudiante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdGrupoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estudiante_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estudiante_grupo_IdGrupoFK",
                        column: x => x.IdGrupoFK,
                        principalTable: "grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "profesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Titulacion = table.Column<byte[]>(type: "longblob", nullable: true),
                    Especialidad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profesor_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "boletin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Periodo = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    IdEstudianteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boletin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_boletin_estudiante_IdEstudianteFK",
                        column: x => x.IdEstudianteFK,
                        principalTable: "estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Contenido = table.Column<byte[]>(type: "longblob", nullable: true),
                    IdEstudianteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_matricula_estudiante_IdEstudianteFK",
                        column: x => x.IdEstudianteFK,
                        principalTable: "estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "padre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdEstudianteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_padre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_padre_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_padre_estudiante_IdEstudianteFK",
                        column: x => x.IdEstudianteFK,
                        principalTable: "estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo_profesor",
                columns: table => new
                {
                    IdGrupoFK = table.Column<int>(type: "int", nullable: false),
                    IdProfesorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_profesor", x => new { x.IdGrupoFK, x.IdProfesorFK });
                    table.ForeignKey(
                        name: "FK_grupo_profesor_grupo_IdGrupoFK",
                        column: x => x.IdGrupoFK,
                        principalTable: "grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grupo_profesor_profesor_IdProfesorFK",
                        column: x => x.IdProfesorFK,
                        principalTable: "profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "materia_profesor",
                columns: table => new
                {
                    IdMateriaFK = table.Column<int>(type: "int", nullable: false),
                    IdProfesorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materia_profesor", x => new { x.IdMateriaFK, x.IdProfesorFK });
                    table.ForeignKey(
                        name: "FK_materia_profesor_materia_IdMateriaFK",
                        column: x => x.IdMateriaFK,
                        principalTable: "materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_materia_profesor_profesor_IdProfesorFK",
                        column: x => x.IdProfesorFK,
                        principalTable: "profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "corte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Actitudinal = table.Column<double>(type: "double", maxLength: 5, nullable: false),
                    Evaluaciones = table.Column<double>(type: "double", nullable: false),
                    Talleres = table.Column<double>(type: "double", nullable: false),
                    Tareas = table.Column<double>(type: "double", nullable: false),
                    AutoEvaluacion = table.Column<double>(type: "double", nullable: false),
                    IdMateriaFK = table.Column<int>(type: "int", nullable: false),
                    IdBoletinFK = table.Column<int>(type: "int", nullable: false),
                    IdProfesorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_corte_boletin_IdBoletinFK",
                        column: x => x.IdBoletinFK,
                        principalTable: "boletin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_corte_materia_IdMateriaFK",
                        column: x => x.IdMateriaFK,
                        principalTable: "materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_corte_profesor_IdProfesorFK",
                        column: x => x.IdProfesorFK,
                        principalTable: "profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "nota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoNotaFK = table.Column<int>(type: "int", nullable: false),
                    CorteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nota_corte_CorteId",
                        column: x => x.CorteId,
                        principalTable: "corte",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_nota_tipo_nota_IdTipoNotaFK",
                        column: x => x.IdTipoNotaFK,
                        principalTable: "tipo_nota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "grado",
                columns: new[] { "Id", "NombreGrado" },
                values: new object[,]
                {
                    { 1, "Sexto" },
                    { 2, "Septimo" },
                    { 3, "Octavo" },
                    { 4, "Noveno" },
                    { 5, "Decimo" },
                    { 6, "Undecimo" }
                });

            migrationBuilder.InsertData(
                table: "pais",
                columns: new[] { "Id", "NombrePais" },
                values: new object[,]
                {
                    { 1, "Colombia" },
                    { 2, "Venezuela" }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "Id", "rolName" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Profesor" },
                    { 3, "Estudiante" },
                    { 4, "Padre" }
                });

            migrationBuilder.InsertData(
                table: "tipo_documento",
                columns: new[] { "Id", "NombreTipo" },
                values: new object[,]
                {
                    { 1, "Cedula de Ciudadania" },
                    { 2, "Tarjeta de Identidad" },
                    { 3, "Cédula de Extranjería" },
                    { 4, "Pasaporte" },
                    { 5, "Permiso Especial de Permanencia (PEP)" },
                    { 6, "Permiso de Proteccion Temporak (PPT)" }
                });

            migrationBuilder.InsertData(
                table: "tipo_nota",
                columns: new[] { "Id", "NombreTipo", "ValorPorcentaje" },
                values: new object[,]
                {
                    { 1, "Actitudinal", 10.0 },
                    { 2, "AutoEvaluacion", 10.0 },
                    { 3, "Talleres", 25.0 },
                    { 4, "Evaluaciones", 35.0 },
                    { 5, "Tareas", 20.0 }
                });

            migrationBuilder.InsertData(
                table: "departamento",
                columns: new[] { "Id", "IdPaisFK", "NombreDepartamento" },
                values: new object[,]
                {
                    { 1, 1, "Santander" },
                    { 2, 1, "Cundinamarca" },
                    { 3, 2, "Carabobo" },
                    { 4, 2, "Bolivar" }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "Id", "password", "email", "IdPersonaFK", "IdRolFK", "NombreUsuario" },
                values: new object[,]
                {
                    { 1, "AQAAAAIAAYagAAAAEJLB6/aRrT6xkqJYUfQxwUt2wY/37H0PPJ4XDNylyx9yk2mGK4ixSJDOn0Mc+KeB6g==", "administrador@gmail.com", 1, 1, "JulianA" },
                    { 2, "AQAAAAIAAYagAAAAEFSN6Is9/ceIML/0ANwVUWfAvLvM3DvnVik1IjmCZ03xL+ZWXCBPmZ0gHM8ERFflhQ==", "profesor@gmail.com", 2, 2, "JulianP" },
                    { 3, "AQAAAAIAAYagAAAAEEL2KHqP09HxnEgi6X7HSyIiBk6TfkY2249D5R/9s/IbMItQdenOd5pS/c6FUVZzzQ==", "estudiante@gmail.com", 3, 3, "JulianE" },
                    { 4, "AQAAAAIAAYagAAAAEOB7D6zemNVt7Es0SiywOv6qCr+Xfl89OmBKONBTSdug1ZpV4nKm+TZPbbJvByxM2w==", "padre@gmail.com", 4, 4, "JulianPa" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellidos", "CorreoElectronico", "Documento", "FechaNacimiento", "IdTipoDocumentoFK", "Nombres", "Telefono" },
                values: new object[,]
                {
                    { 1, "Apellido Ejemplo", "persona@example.com", "123456789", new DateOnly(2022, 10, 10), 1, "Nombre Ejemplo", "1234567890" },
                    { 2, "Apellido Ejemplo", "persona@example.com", "123456789", new DateOnly(2022, 10, 10), 1, "Nombre Ejemplo", "1234567890" },
                    { 3, "Apellido Ejemplo", "persona@example.com", "123456789", new DateOnly(2022, 10, 10), 1, "Nombre Ejemplo", "1234567890" },
                    { 4, "Apellido Ejemplo", "persona@example.com", "123456789", new DateOnly(2022, 10, 10), 1, "Nombre Ejemplo", "1234567890" }
                });

            migrationBuilder.InsertData(
                table: "ciudad",
                columns: new[] { "Id", "IdDepartamentoFK", "NombreCiudad" },
                values: new object[,]
                {
                    { 1, 1, "Bucaramanga" },
                    { 2, 1, "Giron" },
                    { 3, 1, "Floridablanca" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_archivo_IdPersonaFK",
                table: "archivo",
                column: "IdPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_boletin_IdEstudianteFK",
                table: "boletin",
                column: "IdEstudianteFK");

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_IdDepartamentoFK",
                table: "ciudad",
                column: "IdDepartamentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_corte_IdBoletinFK",
                table: "corte",
                column: "IdBoletinFK");

            migrationBuilder.CreateIndex(
                name: "IX_corte_IdMateriaFK",
                table: "corte",
                column: "IdMateriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_corte_IdProfesorFK",
                table: "corte",
                column: "IdProfesorFK");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_IdPaisFK",
                table: "departamento",
                column: "IdPaisFK");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_IdCiudadFK",
                table: "direccion",
                column: "IdCiudadFK");

            migrationBuilder.CreateIndex(
                name: "IX_estudiante_IdGrupoFK",
                table: "estudiante",
                column: "IdGrupoFK");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_IdGradoFK",
                table: "grupo",
                column: "IdGradoFK");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_materia_IdMateriaFK",
                table: "grupo_materia",
                column: "IdMateriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_profesor_IdProfesorFK",
                table: "grupo_profesor",
                column: "IdProfesorFK");

            migrationBuilder.CreateIndex(
                name: "IX_materia_profesor_IdProfesorFK",
                table: "materia_profesor",
                column: "IdProfesorFK");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_IdEstudianteFK",
                table: "matricula",
                column: "IdEstudianteFK");

            migrationBuilder.CreateIndex(
                name: "IX_nota_CorteId",
                table: "nota",
                column: "CorteId");

            migrationBuilder.CreateIndex(
                name: "IX_nota_IdTipoNotaFK",
                table: "nota",
                column: "IdTipoNotaFK");

            migrationBuilder.CreateIndex(
                name: "IX_padre_IdEstudianteFK",
                table: "padre",
                column: "IdEstudianteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdTipoDocumentoFK",
                table: "Personas",
                column: "IdTipoDocumentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_IdUsuarioFK",
                table: "refresh_token",
                column: "IdUsuarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_IdRolFK",
                table: "usuario",
                column: "IdRolFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "archivo");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "grupo_materia");

            migrationBuilder.DropTable(
                name: "grupo_profesor");

            migrationBuilder.DropTable(
                name: "materia_profesor");

            migrationBuilder.DropTable(
                name: "matricula");

            migrationBuilder.DropTable(
                name: "nota");

            migrationBuilder.DropTable(
                name: "padre");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "corte");

            migrationBuilder.DropTable(
                name: "tipo_nota");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "boletin");

            migrationBuilder.DropTable(
                name: "materia");

            migrationBuilder.DropTable(
                name: "profesor");

            migrationBuilder.DropTable(
                name: "pais");

            migrationBuilder.DropTable(
                name: "estudiante");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "grupo");

            migrationBuilder.DropTable(
                name: "tipo_documento");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "grado");

            migrationBuilder.DropTable(
                name: "rol");
        }
    }
}
