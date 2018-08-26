CREATE DATABASE ERPHONIX
-- CREACION DE LA BASE DE DATOS
USE ERPHONIX
-- CREACION DE TABLAS
CREATE TABLE FACTURA (
FAC_UUID VARCHAR(36) PRIMARY KEY NOT NULL,
FAC_FACTURA BINARY, -- 0 = RECIBIDA, 1 = EMITIDA * (calculado)
FAC_VERSION VARCHAR(3),
FAC_SERIE VARCHAR(25),
FAC_FOLIO VARCHAR(40),
FAC_FECHAEMISION DATE,
FAC_FORMAPAGO VARCHAR(2),
FAC_CONDICIONESPAGO VARCHAR(1000),
FAC_SUBTOTAL NUMERIC(10,2),
FAC_DESCUENTO NUMERIC(10,2),
FAC_MONEDA VARCHAR(3),
FAC_TIPOCAMBIO NUMERIC(8,6),
FAC_TOTAL NUMERIC(10,2),
FAC_TIPOCOMPROBANTE VARCHAR(1),
FAC_METODOPAGO VARCHAR(3),
FAC_LUGAREXPEDICION VARCHAR(5),
FAC_RFCEMISOR VARCHAR(13),
FAC_NOMBREEMISOR VARCHAR(254),
FAC_REGIMENFISCAL VARCHAR(3),
FAC_RFCRECEPTOR VARCHAR(13),
FAC_NOMBRERECEPTOR VARCHAR(254),
FAC_RESIDENCIAFISCAL VARCHAR(3),
FAC_NUMREGIDTRIB VARCHAR(40),
FAC_USOCFDI VARCHAR(3),
FAC_CONCEPTOS VARCHAR(1000),
FAC_RETENIDOIVA NUMERIC(10,2),
FAC_RETENIDOISR NUMERIC(10,2),
FAC_IVA NUMERIC (10,2),
FAC_TOTALIEPS NUMERIC (10,2),
FAC_FECHATIMBRADO DATETIME,
NOM_REGISTROPATRONAL VARCHAR(20),
NOM_TIPONOMINA VARCHAR(1),
NOM_FECHAPAGO DATE,
NOM_FECHAINICIALPAGO DATE,
NOM_FECHAFINALPAGO DATE,
NOM_NUMDIASPAGADOS NUMERIC(5,3),
NOM_RECEPTORCURP VARCHAR(18),
NOM_NUMSEGSOCIAL VARCHAR(15),
NOM_FECHAINIRELLAB DATE,
NOM_ANTIGUEDAD VARCHAR(10),
NOM_TIPOCONTRATO VARCHAR(2),
NOM_SINDICALIZADO VARCHAR(2),
NOM_TIPOJORNADA VARCHAR(2),
NOM_TIPOREGIMEN VARCHAR(2),
NOM_NUMEMPLEADO VARCHAR(15),
NOM_DEPARTAMENTO VARCHAR(100),
NOM_PUESTO VARCHAR(100),
NOM_RIESGOPUESTO VARCHAR(2),
NOM_PERIOINIPAGO VARCHAR(2),
NOM_BANCO VARCHAR(3),
NOM_CTABANCARIA INT,
NOM_SALDOBACOAP NUMERIC(20,2),
NOM_SALARIODI NUMERIC(20,2),
NOM_CVEENTFED VARCHAR(3),
NOM_TOTALSUELDOSPER NUMERIC(10,2),
NOM_TOTALSEPINDPER NUMERIC(10,2),
NOM_TOTALJUBPENSRET NUMERIC(10,2),
NOM_TOTALEXENTOPER NUMERIC(10,2),
NOM_TOTALOTRASDED NUMERIC(10,2),
NOM_TOTALIMPRETEN NUMERIC(10,2),
NOM_P01_SUE_SA_EX NUMERIC(20,2),
NOM_P01_SUE_SA_GR NUMERIC(20,2),
NOM_P02_AGUIN_EX NUMERIC(20,2),
NOM_P02_AGUIN_GR NUMERIC(20,2),
NOM_P03_UTIL_EX NUMERIC(20,2),
NOM_P03_UTIL_GR NUMERIC(20,2),
NOM_P04_GASMED_EX NUMERIC(20,2),
NOM_P04_GASMED_GR NUMERIC(20,2),
NOM_P05_FONAHO_EX NUMERIC(20,2),
NOM_P05_FONAHO_GR NUMERIC(20,2),
NOM_P06_CAJDH_EX NUMERIC(20,2),
NOM_P06_CAJDH_GR NUMERIC(20,2),
NOM_P09_CONT_EX NUMERIC(20,2),
NOM_P10_PRPUN_EX NUMERIC(20,2),
NOM_P10_PRPUN_GR NUMERIC(20,2),
NOM_P11_PRISEG_EX NUMERIC(20,2),
NOM_P11_PRISEG_GR NUMERIC(20,2),
NOM_P12_GASMED_EX NUMERIC(20,2),
NOM_P12_GASMED_GR NUMERIC(20,2),
NOM_P13_CUOSIN_EX NUMERIC(20,2),
NOM_P13_CUOSIN_GR NUMERIC(20,2),
NOM_P14_INCAP_EX NUMERIC(20,2),
NOM_P14_INCAP_GR NUMERIC(20,2),
NOM_P15_BECAS_EX NUMERIC(20,2),
NOM_P15_BECAS_GR NUMERIC(20,2),
NOM_P19_HRSEXT_EX NUMERIC(20,2),
NOM_P19_HRSEXT_GR NUMERIC(20,2),
NOM_P20_PRMDOM_EX NUMERIC(20,2),
NOM_P20_PRMDOM_GR NUMERIC(20,2),
NOM_P21_PRMVAC_EX NUMERIC(20,2),
NOM_P21_PRMVAC_GR NUMERIC(20,2),
NOM_P22_PRMANT_EX NUMERIC(20,2),
NOM_P22_PRMANT_GR NUMERIC(20,2),
NOM_P23_PSEPAR_EX NUMERIC(20,2),
NOM_P23_PSEPAR_GR NUMERIC(20,2),
NOM_P24_SGRETI_EX NUMERIC(20,2),
NOM_P24_SGRETI_GR NUMERIC(20,2),
NOM_P25_INDEMN_EX NUMERIC(20,2),
NOM_P25_INDEMN_GR NUMERIC(20,2),
NOM_P26_RFUNER_EX NUMERIC(20,2),
NOM_P26_RFUNER_GR NUMERIC(20,2),
NOM_P27_CUOSEG_EX NUMERIC(20,2),
NOM_P27_CUOSEG_GR NUMERIC(20,2),
NOM_P28_COMIS_EX NUMERIC(20,2),
NOM_P28_COMIS_GR NUMERIC(20,2),
NOM_P29_VALDSP_EX NUMERIC(20,2),
NOM_P29_VALDSP_GR NUMERIC(20,2),
NOM_P30_VALRES_EX NUMERIC(20,2),
NOM_P30_VALRES_GR NUMERIC(20,2),
NOM_P31_VALGAS_EX NUMERIC(20,2),
NOM_P31_VALGAS_GR NUMERIC(20,2),
NOM_P32_VALROP_EX NUMERIC(20,2),
NOM_P32_VALROP_GR NUMERIC(20,2),
NOM_P33_AYRENT_EX NUMERIC(20,2),
NOM_P33_AYRENT_GR NUMERIC(20,2),
NOM_P34_ARTESC_EX NUMERIC(20,2),
NOM_P34_ARTESC_GR NUMERIC(20,2),
NOM_P35_AYLENT_EX NUMERIC(20,2),
NOM_P35_AYLENT_GR NUMERIC(20,2),
NOM_P36_TRANSP_EX NUMERIC(20,2),
NOM_P36_TRANSP_GR NUMERIC(20,2),
NOM_P37_GFUNER_EX NUMERIC(20,2),
NOM_P37_GFUNER_GR NUMERIC(20,2),
NOM_P38_OTRING_EX NUMERIC(20,2),
NOM_P38_OTRING_GR NUMERIC(20,2),
NOM_P39_JUBILA_EX NUMERIC(20,2),
NOM_P39_JUBILA_GR NUMERIC(20,2),
NOM_P44_JUBPAR_EX NUMERIC(20,2),
NOM_P44_JUBPAR_GR NUMERIC(20,2),
NOM_P45_BIENES_EX NUMERIC(20,2),
NOM_P45_BIENES_GR NUMERIC(20,2),
NOM_P46_ASIMIL_EX NUMERIC(20,2),
NOM_P46_ASIMIL_GR NUMERIC(20,2),
NOM_P47_ALIMEN_EX NUMERIC(20,2),
NOM_P47_ALIMEN_GR NUMERIC(20,2),
NOM_P48_HABIT_EX NUMERIC(20,2),
NOM_P48_HABIT_GR NUMERIC(20,2),
NOM_P49_ASIST_EX NUMERIC(20,2),
NOM_P49_ASIST_GR NUMERIC(20,2),
NOM_P50_VIATIC_EX NUMERIC(20,2),
NOM_P50_VIATIC_GR NUMERIC(20,2),
NOM_D001_SEGSOC NUMERIC(20,2),
NOM_D002_ISR NUMERIC(20,2),
NOM_D003_APRETI NUMERIC(20,2),
NOM_D004_OTROS NUMERIC(20,2),
NOM_D005_FONVIV NUMERIC(20,2),
NOM_D006_DESINC NUMERIC(20,2),
NOM_D007_PNALIM NUMERIC(20,2),
NOM_D008_RENTA NUMERIC(20,2),
NOM_D009_INFONAVIT NUMERIC(20,2),
NOM_D010_CRVIV NUMERIC(20,2),
NOM_D011_INFONACOT NUMERIC(20,2),
NOM_D012_ANTSAL NUMERIC(20,2),
NOM_D013_EXCESO NUMERIC(20,2),
NOM_D014_ERRORES NUMERIC(20,2),
NOM_D015_PERDIDA NUMERIC(20,2),
NOM_D016_AVERIAS NUMERIC(20,2),
NOM_D017_AAPPEE NUMERIC(20,2),
NOM_D018_CCFSCCA NUMERIC(20,2),
NOM_D019_CUOSIND NUMERIC(20,2),
NOM_D020_AUSENC NUMERIC(20,2),
NOM_D021_CUOBPA NUMERIC(20,2),
NOM_D022_IMPLOC NUMERIC(20,2),
NOM_D023_APOVOL NUMERIC(20,2),
NOM_D024_AGUINEX NUMERIC(20,2),
NOM_D025_AGUINGR NUMERIC(20,2),
NOM_D026_APTUEX NUMERIC(20,2),
NOM_D027_APTUGR NUMERIC(20,2),
NOM_D028_GASMEDEX NUMERIC(20,2),
NOM_D029_FONAHOEX NUMERIC(20,2),
NOM_D030_CAJAHOEX NUMERIC(20,2),
NOM_D031_ACCTPPEX NUMERIC(20,2),
NOM_D032_PUNTGR NUMERIC(20,2),
NOM_D033_SEGVIDEX NUMERIC(20,2),
NOM_D034_GASMEDEX NUMERIC(20,2),
NOM_D035_COUSINEX NUMERIC(20,2),
NOM_D036_SUBINCEX NUMERIC(20,2),
NOM_D037_BECTREX NUMERIC(20,2),
NOM_D038_AHREXTEX NUMERIC(20,2),
NOM_D039_AHREXTGR NUMERIC(20,2),
NOM_D040_APRDOMEX NUMERIC(20,2),
NOM_D041_APRDOMGR NUMERIC(20,2),
NOM_D042_APRVACEX NUMERIC(20,2),
NOM_D043_APRVACGR NUMERIC(20,2),
NOM_D044_APRANTEX NUMERIC(20,2),
NOM_D045_APRANTGR NUMERIC(20,2),
NOM_D046_APGSEPEX NUMERIC(20,2),
NOM_D047_APGSEPGR NUMERIC(20,2),
NOM_D048_ASGRETEX NUMERIC(20,2),
NOM_D049_AINDEMEX NUMERIC(20,2),
NOM_D050_AINDEMGR NUMERIC(20,2),
NOM_D051_AREFUNEX NUMERIC(20,2),
NOM_D052_ACSPPPEX NUMERIC(20,2),
NOM_D053_ACOMIGR NUMERIC(20,2),
NOM_D054_AVADESEX NUMERIC(20,2),
NOM_D055_AVARESEX NUMERIC(20,2),
NOM_D056_AVAGASEX NUMERIC(20,2),
NOM_D057_AVAROPEX NUMERIC(20,2),
NOM_D058_AAYRENEX NUMERIC(20,2),
NOM_D059_AAYASCEX NUMERIC(20,2),
NOM_D060_AAYANTEX NUMERIC(20,2),
NOM_D061_AAYTEXEX NUMERIC(20,2),
NOM_D062_AAYGFUEX NUMERIC(20,2),
NOM_D063_AOINSAEX NUMERIC(20,2),
NOM_D064_AOINSAGR NUMERIC(20,2),
NOM_D065_AJUBILEX NUMERIC(20,2),
NOM_D066_AJUBILGR NUMERIC(20,2),
NOM_D067_APGSA NUMERIC(20,2),
NOM_D068_APGSNA NUMERIC(20,2),
NOM_D069_AJUBA NUMERIC(20,2),
NOM_D070_AJUBNA NUMERIC(20,2),
NOM_D071_SUBSEE NUMERIC(20,2),
NOM_D072_ABIENEX NUMERIC(20,2),
NOM_D073_ABIENGR NUMERIC(20,2),
NOM_D074_AALIMEX NUMERIC(20,2),
NOM_D075_AALIMGR NUMERIC(20,2),
NOM_D076_AHABIEX NUMERIC(20,2),
NOM_D077_AHABIGR NUMERIC(20,2),
NOM_D078_APRASIS NUMERIC(20,2),
NOM_D079_AJOTPAG NUMERIC(20,2),
NOM_D080_AVIATGR NUMERIC(20,2),
NOM_D081_AVIATET NUMERIC(20,2),
NOM_D082_AFOAHGR NUMERIC(20,2),
NOM_D083_ACAAHGR NUMERIC(20,2),
NOM_D084_APRSVGR NUMERIC(20,2),
NOM_D085_ASGMMGR NUMERIC(20,2),
NOM_D086_AINCAGR NUMERIC(20,2),
NOM_D087_ABECAGR NUMERIC(20,2),
NOM_D088_ASRETGR NUMERIC(20,2),
NOM_D089_AVADEGR NUMERIC(20,2),
NOM_D090_AVAREGR NUMERIC(20,2),
NOM_D091_AVAGAGR NUMERIC(20,2),
NOM_D092_AVAROGR NUMERIC(20,2),
NOM_D093_AAYREGR NUMERIC(20,2),
NOM_D094_AAYAEGR NUMERIC(20,2),
NOM_D095_AAYANGR NUMERIC(20,2),
NOM_D096_AAYTRGR NUMERIC(20,2),
NOM_D097_AAYFUGR NUMERIC(20,2),
NOM_D098_AINASGR NUMERIC(20,2),
NOM_D099_AINSSGR NUMERIC(20,2),
NOM_D100_AVIEXGR NUMERIC(20,2),
NOM_D101_ISRREEA NUMERIC(20,2),
NOM_OP002_SUBSEM NUMERIC(20,2)
)

CREATE TABLE EMPRESA (
EMP_RFC VARCHAR(13) NOT NULL PRIMARY KEY,
EMP_NOMBRE VARCHAR(254),
EMP_CORREO VARCHAR(120),
EMP_CVESAT VARCHAR(8)
-- EMP_DIRECCION VARCHAR(254)* 
)

CREATE TABLE BANCO (
BAN_CVE_BANCO VARCHAR(7) PRIMARY KEY NOT NULL,
BAN_BANCO VARCHAR(254),
BAN_CTABANCARIA INT,
BAN_RFC VARCHAR(13),
BAN_MONEDA VARCHAR(3)
-- BAN_CTACONTABLE ???
)

CREATE TABLE MOVIMIENTOBANCARIO (
MOV_UUID VARCHAR(36)PRIMARY KEY NOT NULL,
MOV_SERIE VARCHAR (25),
MOV_FOLIO VARCHAR(40),
MOV_FECHAPAGO DATETIME,
MOV_BANCO VARCHAR(3),
MOV_CTABANCO INT,
MOV_DEPOSITO NUMERIC(10,2),
MOV_ABONO NUMERIC(10,2),
MOV_RETIRO NUMERIC(10,2),
MOV_CARGO NUMERIC(10,2),
MOV_SALDO NUMERIC(10,2),
MOV_MANUAL BINARY,		-- 1=MANUAL, 0= AUTOMATICO

BAN_CVE_BANCO VARCHAR(7) NOT NULL,

FOREIGN KEY (BAN_CVE_BANCO) REFERENCES BANCO(BAN_CVE_BANCO)
)

-- AVANCE HASTA 2018-08-16--