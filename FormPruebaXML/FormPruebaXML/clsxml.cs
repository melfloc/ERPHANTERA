using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;

namespace FormPruebaXML
{
    class clsxml
    {
        //NAMESPACES PARA ACCESO A DATOS (AGREGAR FALTANTES)
        XNamespace cfdi = "http://www.sat.gob.mx/cfd/3";
        XNamespace tfd = "http://www.sat.gob.mx/TimbreFiscalDigital";
        XNamespace bfa2 = "http://www.buzonfiscal.com/ns/addenda/bf/2";
        XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
        XNamespace pago10 = "http://www.sat.gob.mx/Pagos";
        XNamespace nomina12 = "http://www.sat.gob.mx/nomina12";

        //REALIZAR SUMARIO DE NOTAS Y OBSERVACIONES EN LA PARTE INFERIOR Y SOLO INDICAR EN LA LINEA DESEADA EL NUMERO DE LA OBSERVACION

        //###################### DECLARACION DE VARIABLES GLOBALES #############################
        //REVISAR**
        //VARIABLES GLOBALES DEL NODO cfdi:Comprobante
        public string comp_version;
        public string comp_serie;
        public string comp_folio;
        public DateTime comp_fecha;
        public string comp_formapago;
        public string comp_condpago;
        public string comp_subtotal;
        public string comp_descuento;
        public string comp_moneda;
        public string comp_tipodecambio;
        public string comp_total;
        public string comp_tipocomprobante;
        public string comp_metodopago;
        public string comp_lugarexpedicion;

        //VARIABLES GLOBALES DEL NODO cfdi:Emisor
        public string emi_regimenfiscal;
        public string emi_rfc;
        public string emi_nombre;

        //VARIABLES GLOBALES PARA NODO cfdi:Receptor
        public string rec_rfc;
        public string rec_nombre;
        public string rec_usocfdi;
        public string rec_resifiscal;
        public string rec_numregidtrib;

        //VARIABLES GLOBALES PARA NODO cfdi:Concepto
        public string con_claveprodserv;
        public string con_claveunidad;
        public string con_cantidad;
        public string con_unidad;
        public string con_noid;
        public string con_descripcion;
        public string con_valorunitario;
        public string con_importe;
        public string con_descuento;

        //VARIABLES GLOBALES PARA NODO cfdi:Traslado (DENTRO DE cfdi:Concepto)
        /*public string tr_base;
        public string tr_impuesto;
        public string tr_tipofactor;
        public string tr_tasacuota;
        public string tr_importe;

        //VARIABLES GLOBALES PARA NODO cfdi:Retencion (DENTRO DE cfdi:Concepto)
        public string ret_base;
        public string ret_impuesto;
        public string ret_tipofactor;
        public string ret_tasacuota;
        public string ret_importe;*/

        //VARIABLES GLOBALES PARA NODO cfdi:Impuesto
        public string imp_totalimpret;
        public string imp_totalimptras;

        //VARIABLES GLOBALES PARA NODO cfdi:Traslado (DENTRO DE cfdi:Impuestos)
        public string imp_tr_iva_impuesto;
        public string imp_tr_iva_tipofactor;
        public string imp_tr_iva_tasacuota;
        public string imp_tr_iva_importe;
        public string imp_tr_isr_impuesto;
        public string imp_tr_isr_tipofactor;
        public string imp_tr_isr_tasacuota;
        public string imp_tr_isr_importe;
        public string imp_tr_ieps_impuesto;
        public string imp_tr_ieps_tipofactor;
        public string imp_tr_ieps_tasacuota;
        public string imp_tr_ieps_importe;

        //VARIABLES GLOBALES PARA NODO cfdi:Retencion (DENTRO DE cfdi:Impuesto)
        public string imp_ret_iva_impuesto;
        public string imp_ret_iva_importe;
        public string imp_ret_isr_impuesto;
        public string imp_ret_isr_importe;
        public string imp_ret_ieps_impuesto;
        public string imp_ret_ieps_importe;

        //VARIABLES GLOBALES PARA NODO Nomina12:Nomina
        public DateTime nom_fechIniPago;
        public DateTime nom_fechFinalPago;
        public DateTime nom_fechapago;
        public string nom_numdiaspagados;
        public string nom_tiponomina;
        public string nom_totaldeducciones;
        public string nom_totalpercepciones;

        //VARIABLES GLOBALES PARA NODO Nomina12:Emisor (DENTRO DE Nomina12:Nomina)
        public string emi_registropatronal;

        //VARIABLES GLOBALES PARA NODO Nomina12:Receptor (DENTRO DE Nomina12:Nomina)
        public string rec_antiguedad;
        public string rec_banco;
        public string rec_claveEntFed;
        public string rec_cuentabancaria;
        public string rec_curp;
        public string rec_departamento;
        public DateTime rec_fechaIniLaboral;
        public string rec_numempleado;
        public string rec_numSegSoc;
        public string rec_periodiPago;
        public string rec_puesto;
        public string rec_riesgopuesto;
        public string rec_salariobaseCA;
        public string rec_salariodiarioInt;
        public string rec_sindicalizado;
        public string rec_tipocontrato;
        public string rec_tipojornada;
        public string rec_tiporegimen;

        //VARIABLES GLOBALES PARA NODO Nomina12:Percepciones
        public string per_totalexento;
        public string per_totalgravado;
        public string per_totalsueldos;

        //VARIABLES GLOBALES PARA NODO Nomina12:Percepcion
        public string per_001_importeexento;
        public string per_001_importegravado;
        public string per_002_importeexento;
        public string per_002_importegravado;
        public string per_003_importeexento;
        public string per_003_importegravado;
        public string per_004_importeexento;
        public string per_004_importegravado;
        public string per_005_importeexento;
        public string per_005_importegravado;
        public string per_006_importeexento;
        public string per_006_importegravado;
        public string per_007_importeexento;
        public string per_007_importegravado;
        public string per_008_importeexento;
        public string per_008_importegravado;
        public string per_009_importeexento;
        public string per_009_importegravado;
        public string per_010_importeexento;
        public string per_010_importegravado;
        public string per_011_importeexento;
        public string per_011_importegravado;
        public string per_012_importeexento;
        public string per_012_importegravado;
        public string per_013_importeexento;
        public string per_013_importegravado;
        public string per_014_importeexento;
        public string per_014_importegravado;
        public string per_015_importeexento;
        public string per_015_importegravado;
        public string per_016_importeexento;
        public string per_016_importegravado;
        public string per_017_importeexento;
        public string per_017_importegravado;
        public string per_018_importeexento;
        public string per_018_importegravado;
        public string per_019_importeexento;
        public string per_019_importegravado;
        public string per_020_importeexento;
        public string per_020_importegravado;
        public string per_031_importeexento;
        public string per_031_importegravado;
        public string per_032_importeexento;
        public string per_032_importegravado;
        public string per_033_importeexento;
        public string per_033_importegravado;
        public string per_034_importeexento;
        public string per_034_importegravado;
        public string per_035_importeexento;
        public string per_035_importegravado;
        public string per_036_importeexento;
        public string per_036_importegravado;
        public string per_037_importeexento;
        public string per_037_importegravado;
        public string per_038_importeexento;
        public string per_038_importegravado;
        public string per_039_importeexento;
        public string per_039_importegravado;
        public string per_040_importeexento;
        public string per_040_importegravado;
        public string per_041_importeexento;
        public string per_041_importegravado;
        public string per_042_importeexento;
        public string per_042_importegravado;
        public string per_043_importeexento;
        public string per_043_importegravado;
        public string per_044_importeexento;
        public string per_044_importegravado;
        public string per_045_importeexento;
        public string per_045_importegravado;
        public string per_046_importeexento;
        public string per_046_importegravado;
        public string per_047_importeexento;
        public string per_047_importegravado;
        public string per_048_importeexento;
        public string per_048_importegravado;
        public string per_049_importeexento;
        public string per_049_importegravado;
        public string per_050_importeexento;
        public string per_050_importegravado;

        //VARIABLES GLOBALES PARA NODO Nomina12:Deducciones
        public string ded_totalImpRet;
        public string ded_totalOtDed;

        //VARIABLES GLOBALES PARA NODO Nomina12:Deduccion
        public string ded_001_importe;
        public string ded_002_importe;
        public string ded_003_importe;
        public string ded_004_importe;
        public string ded_005_importe;
        public string ded_006_importe;
        public string ded_007_importe;
        public string ded_008_importe;
        public string ded_009_importe;
        public string ded_010_importe;
        public string ded_011_importe;
        public string ded_012_importe;
        public string ded_013_importe;
        public string ded_014_importe;
        public string ded_015_importe;
        public string ded_016_importe;
        public string ded_017_importe;
        public string ded_018_importe;
        public string ded_019_importe;
        public string ded_020_importe;
        public string ded_021_importe;
        public string ded_022_importe;
        public string ded_023_importe;
        public string ded_024_importe;
        public string ded_025_importe;
        public string ded_026_importe;
        public string ded_027_importe;
        public string ded_028_importe;
        public string ded_029_importe;
        public string ded_030_importe;
        public string ded_031_importe;
        public string ded_032_importe;
        public string ded_033_importe;
        public string ded_034_importe;
        public string ded_035_importe;
        public string ded_036_importe;
        public string ded_037_importe;
        public string ded_038_importe;
        public string ded_039_importe;
        public string ded_040_importe;
        public string ded_041_importe;
        public string ded_042_importe;
        public string ded_043_importe;
        public string ded_044_importe;
        public string ded_045_importe;
        public string ded_046_importe;
        public string ded_047_importe;
        public string ded_048_importe;
        public string ded_049_importe;
        public string ded_050_importe;
        public string ded_051_importe;
        public string ded_052_importe;
        public string ded_053_importe;
        public string ded_054_importe;
        public string ded_055_importe;
        public string ded_056_importe;
        public string ded_057_importe;
        public string ded_058_importe;
        public string ded_059_importe;
        public string ded_060_importe;
        public string ded_061_importe;
        public string ded_062_importe;
        public string ded_063_importe;
        public string ded_064_importe;
        public string ded_065_importe;
        public string ded_066_importe;
        public string ded_067_importe;
        public string ded_068_importe;
        public string ded_069_importe;
        public string ded_070_importe;
        public string ded_071_importe;
        public string ded_072_importe;
        public string ded_073_importe;
        public string ded_074_importe;
        public string ded_075_importe;
        public string ded_076_importe;
        public string ded_077_importe;
        public string ded_078_importe;
        public string ded_079_importe;
        public string ded_080_importe;
        public string ded_081_importe;
        public string ded_082_importe;
        public string ded_083_importe;
        public string ded_084_importe;
        public string ded_085_importe;
        public string ded_086_importe;
        public string ded_087_importe;
        public string ded_088_importe;
        public string ded_089_importe;
        public string ded_090_importe;
        public string ded_091_importe;
        public string ded_092_importe;
        public string ded_093_importe;
        public string ded_094_importe;
        public string ded_095_importe;
        public string ded_096_importe;
        public string ded_097_importe;
        public string ded_098_importe;
        public string ded_099_importe;
        public string ded_100_importe;
        public string ded_101_importe;

        //VARIABLES GLOBALES PARA NODO NOMINA12:OtrosPagos
        public string otrpag_001_importe;
        public string otrpag_002_importe;
        public string otrpag_003_importe;
        public string otrpag_004_importe;
        public string otrpag_005_importe;
        public string otrpag_999_importe;

        
        //VARIABLES GLOBALES PARA NODO Pago10:Pago
        public DateTime pag_fechaPago;
        public string pag_formaPagoP;
        public string pag_monedaP;
        public string pag_monto;
        public string pag_rfcEmisorCO;
        public string pag_nomBancOrdExt;
        public string pag_ctaOrdenante;
        public string pag_rfcEmiCtaBen;
        public string pag_ctaBeneficiario;

        //VARIABLES GLOBALES PARA NODO Pago10:DoctoRelacionado
        public string dr_idDoc;
        public string dr_serie;
        public string dr_folio;
        public string dr_monedaDR;
        public string dr_metodoPagoDR;
        public string dr_numParcialidad;
        public string dr_impSaldoAnt;
        public string dr_impPagado;
        public string dr_impSaldoIns;

        //VARIABLES GLOBALES PARA NODO tfd:TimbreFiscalDigital
        public string tim_uuid;
        public DateTime tim_fechatimbrado;

        public void get_data(string ruta)
        {
            try
            {
                //CARGA DEL DOCUMENTO XML
                XDocument documento = XDocument.Load(ruta);

                XElement Comprobante = documento.Element(cfdi.GetName("Comprobante"));
                //-------------------------ELEMENTOS DEL NODO cfdi:Comprobante--------------------------------
                comp_version = Convert.ToString(Comprobante.Attribute("Version").Value);

                if (Comprobante.Attribute("Serie") == null)
                    comp_serie = "-";
                else
                    comp_serie = Convert.ToString(Comprobante.Attribute("Serie").Value);

                if (Comprobante.Attribute("Folio") == null)
                    comp_folio = "-";
                else
                    comp_folio = Convert.ToString(Comprobante.Attribute("Folio").Value);

                comp_fecha = Convert.ToDateTime(Comprobante.Attribute("Fecha").Value);

                if (Comprobante.Attribute("CondicionesDePago") == null)
                    comp_condpago = "-";
                else
                    comp_condpago = Convert.ToString(Comprobante.Attribute("CondicionesDePago").Value);

                if (Comprobante.Attribute("MetodoPago") != null)
                {
                    comp_metodopago = Convert.ToString(Comprobante.Attribute("MetodoPago").Value);
                    if (comp_metodopago == "PPD")
                        comp_formapago = "99";
                    else
                        comp_formapago = Convert.ToString(Comprobante.Attribute("FormaPago").Value);
                }
                // ANALIZAR CONDICION DEL PUNTO ANTERIOR ^
                comp_subtotal = Convert.ToString(Comprobante.Attribute("SubTotal").Value);

                if (Comprobante.Attribute("Descuento") == null)
                    comp_descuento = "0.00";
                else
                    comp_descuento = Convert.ToString(Comprobante.Attribute("Descuento").Value);

                comp_moneda = Convert.ToString(Comprobante.Attribute("Moneda").Value);

                if (Comprobante.Attribute("TipoDeCambio") == null)
                    comp_tipodecambio = "1.00";
                else
                    comp_tipodecambio = Convert.ToString(Comprobante.Attribute("TipoDeCambio").Value);

                comp_total = Convert.ToString(Comprobante.Attribute("Total").Value);
                comp_tipocomprobante = Convert.ToString(Comprobante.Attribute("TipoDeComprobante").Value);
                comp_lugarexpedicion = Convert.ToString(Comprobante.Attribute("LugarExpedicion").Value);
                //---------------------------------------------------------------------------------------------

                /**/XElement Emisor = Comprobante.Element(cfdi.GetName("Emisor"));
                //-------------------------------ELEMENTOS DEL NODO cfdi:Emisor--------------------------------
                emi_regimenfiscal = Convert.ToString(Emisor.Attribute("RegimenFiscal").Value);
                emi_rfc = Convert.ToString(Emisor.Attribute("Rfc").Value);
                if (Emisor.Attribute("Nombre") == null)
                    emi_nombre = "-";
                else
                    emi_nombre = Convert.ToString(Emisor.Attribute("Nombre").Value);
                //---------------------------------------------------------------------------------------------

                /**/XElement Receptor = Comprobante.Element(cfdi.GetName("Receptor"));
                //------------------------------ELEMENTOS DEL NODO cfdi:Receptor-------------------------------
                rec_rfc = Convert.ToString(Receptor.Attribute("Rfc").Value);

                rec_resifiscal = Convert.ToString(Receptor.Attribute("ResidenciaFiscal").Value);

                rec_numregidtrib = Convert.ToString(Receptor.Attribute("NumRegIdTrib").Value);

                if (Receptor.Attribute("Nombre") == null)
                    rec_nombre = "-";
                else
                    rec_nombre = Convert.ToString(Receptor.Attribute("Nombre").Value);

                rec_usocfdi = Convert.ToString(Receptor.Attribute("UsoCFDI").Value);
                //---------------------------------------------------------------------------------------------

                /**/XElement Conceptos = Comprobante.Element(cfdi.GetName("Conceptos"));
                
                /******/XElement Concepto = Conceptos.Element(cfdi.GetName("Concepto"));
                //ELEMENTOS DEL NODO cfdi:Concepto
                foreach (XElement con in Conceptos.Elements(cfdi.GetName("Concepto")))
                {
                    if (con.Attribute("Descripcion") == null)
                        con_descripcion += "- * ";
                    else
                        con_descripcion += Convert.ToString(con.Attribute("Descripcion").Value) + " * ";

                    if (Concepto.Attribute("ClaveProdServ") == null)
                        con_claveprodserv += "- * ";
                    else
                        con_claveprodserv += Convert.ToString(Concepto.Attribute("ClaveProdServ").Value) + " * ";

                    if (Concepto.Attribute("ClaveUnidad") == null)
                        con_claveunidad += "-";
                    else
                        con_claveunidad += Convert.ToString(Concepto.Attribute("ClaveUnidad").Value) + " * ";

                    if (Concepto.Attribute("Cantidad") == null)
                        con_cantidad += "0.00 * ";
                    else
                    con_cantidad += Convert.ToString(Concepto.Attribute("Cantidad").Value) + " * ";

                    if (Concepto.Attribute("Unidad") == null)
                        con_unidad += "- * ";
                    else
                        con_unidad += Convert.ToString(Concepto.Attribute("Unidad").Value) + " * ";

                    if (Concepto.Attribute("NoIdentificacion") == null)
                        con_noid += "- * ";
                    else
                        con_noid += Convert.ToString(Concepto.Attribute("NoIdentificacion").Value) + " * ";

                    if (Concepto.Attribute("ValorUnitario") == null)
                        con_valorunitario += "0.00 * ";
                    else
                        con_valorunitario += Convert.ToString(Concepto.Attribute("ValorUnitario").Value) + " * ";

                    if (Concepto.Attribute("Importe") == null)
                        con_importe += "0.00 * ";
                    else
                        con_importe += Convert.ToString(Concepto.Attribute("Importe").Value) + " * ";

                    if (Concepto.Attribute("Descuento") == null)
                        comp_descuento += "0.00 * ";
                    else
                        con_descuento += Convert.ToString(Concepto.Attribute("Descuento").Value) + " * ";
                }
                
                //-----------------------------------------------------------------------------------------------

                //if (Concepto.Element(cfdi.GetName("Impuestos")) != null)
                //{
                    /**********///XElement Con_impuestos = Concepto.Element(cfdi.GetName("Impuestos"));

                    //if (Con_impuestos.Element(cfdi.GetName("Traslados")) != null)
                    //{
                        /**********///XElement Con_traslados = Con_impuestos.Element(cfdi.GetName("Traslados"));

                        /**************///XElement Con_traslado = Con_traslados.Element(cfdi.GetName("Traslado"));
                        //------------------ELEMENTOS DEL NODO cfdi:Traslado (DENTRO DE cfdi:Concepto)-------------------
                        /*tr_base = Convert.ToString(Con_traslado.Attribute("Base").Value);
                        tr_impuesto = Convert.ToString(Con_traslado.Attribute("Impuesto").Value);
                        tr_tipofactor = Convert.ToString(Con_traslado.Attribute("TipoFactor").Value);
                        if (Con_traslado.Attribute("TasaOCuota") == null)
                            tr_tasacuota = "1.00";
                        else
                            tr_tasacuota = Convert.ToString(Con_traslado.Attribute("TasaOCuota").Value);
                        if (Con_traslado.Attribute("Importe") == null)
                            tr_importe = tr_base;
                        else
                            tr_importe = Convert.ToString(Con_traslado.Attribute("Importe").Value);
                        //-----------------------------------------------------------------------------------------------
                    }
                    else
                    {
                        tr_base = "0.00";
                        tr_impuesto = "-";
                        tr_tipofactor = "-";
                        tr_tasacuota = "0.00";
                        tr_importe = "0.00";
                    }
                
                    if (Con_impuestos.Element(cfdi.GetName("Retenciones")) != null)
                    { */  
                        /**********///XElement Con_retenciones = Con_impuestos.Element(cfdi.GetName("Retenciones"));
                        /**************///XElement Con_retencion = Con_retenciones.Element(cfdi.GetName("Retencion"));
                        /*ret_base = Convert.ToString(Con_retencion.Attribute("Base").Value);
                        ret_impuesto = Convert.ToString(Con_retencion.Attribute("Impuesto").Value);
                        ret_tipofactor = Convert.ToString(Con_retencion.Attribute("TipoFactor").Value);
                        ret_tasacuota = Convert.ToString(Con_retencion.Attribute("TasaOCuota").Value);
                        ret_importe = Convert.ToString(Con_retencion.Attribute("Importe").Value);
                    }
                    else
                    {
                        ret_base = "0.00";
                        ret_impuesto = "-";
                        ret_tipofactor = "-";
                        ret_tasacuota = "0.00";
                        ret_importe = "0.00";
                    }
                }*/
                
                if (Comprobante.Element(cfdi.GetName("Impuestos")) != null)
                {
                    /******/XElement Impuestos = Comprobante.Element(cfdi.GetName("Impuestos"));
                    //----------------------------------ELEMENTOS DE NODO cfdi:Impuestos-------------------------------
                    imp_totalimpret = Convert.ToString(Impuestos.Attribute("TotalImpuestosRetenidos").Value);
                    imp_totalimptras = Convert.ToString(Impuestos.Attribute("TotalImpuestosTrasladados").Value);

                    if (Impuestos.Element(cfdi.GetName("Retenciones")) == null)
                    {
                        /**/XElement Imp_retenciones = Impuestos.Element(cfdi.GetName("Retenciones"));
                        /******/XElement Imp_retencion = Imp_retenciones.Element(cfdi.GetName("Retencion"));
                        foreach (XElement ret in Imp_retenciones.Elements(cfdi.GetName("Retencion")))
                        {
                            switch (Convert.ToString(ret.Attribute("Impuesto").Value))
                            {
                                case "001":
                                    imp_ret_isr_impuesto = Convert.ToString(ret.Attribute("Impuesto").Value);
                                    imp_ret_isr_importe = Convert.ToString(ret.Attribute("Importe").Value);
                                    break;
                                case "002":
                                    imp_ret_iva_impuesto = Convert.ToString(ret.Attribute("Impuesto").Value);
                                    imp_ret_iva_importe = Convert.ToString(ret.Attribute("Importe").Value);
                                    break;
                                case "003":
                                    imp_ret_ieps_impuesto = Convert.ToString(ret.Attribute("Impuesto").Value);
                                    imp_ret_iva_importe = Convert.ToString(ret.Attribute("Importe").Value);
                                    break;
                                default:
                                    imp_ret_isr_impuesto = "-";
                                    imp_ret_isr_importe = "0.00";
                                    imp_ret_iva_impuesto = "-";
                                    imp_ret_iva_importe = "0.00";
                                    imp_ret_ieps_impuesto = "-";
                                    imp_ret_ieps_importe = "0.00";
                                    break;
                            }
                        }
                    }
                    
                    if (Impuestos.Element(cfdi.GetName("Traslados")) == null)
                    {
                        /**/XElement Imp_Traslados = Impuestos.Element(cfdi.GetName("Traslados"));
                        /******/XElement Imp_traslado = Imp_Traslados.Element(cfdi.GetName("Traslado"));

                        foreach (XElement tr in Imp_Traslados.Elements("Traslados"))
                        {
                            switch (Convert.ToString(Imp_traslado.Attribute("Impuesto").Value))
                            {
                                case "001":
                                    imp_tr_isr_impuesto = Convert.ToString(Imp_traslado.Attribute("Impuesto").Value);
                                    imp_tr_isr_tipofactor = Convert.ToString(Imp_traslado.Attribute("TipoFactor").Value);
                                    imp_tr_isr_tasacuota = Convert.ToString(Imp_traslado.Attribute("TasaOCuota").Value);
                                    imp_tr_isr_importe = Convert.ToString(Imp_traslado.Attribute("Importe").Value);
                                    break;
                                case "002":
                                    imp_tr_iva_impuesto = Convert.ToString(Imp_traslado.Attribute("Impuesto").Value);
                                    imp_tr_iva_tipofactor = Convert.ToString(Imp_traslado.Attribute("TipoFactor").Value);
                                    imp_tr_iva_tasacuota = Convert.ToString(Imp_traslado.Attribute("TasaOCuota").Value);
                                    imp_tr_iva_importe = Convert.ToString(Imp_traslado.Attribute("Importe").Value);
                                    break;
                                case "003":
                                    imp_tr_ieps_impuesto = Convert.ToString(Imp_traslado.Attribute("Impuesto").Value);
                                    imp_tr_ieps_tipofactor = Convert.ToString(Imp_traslado.Attribute("TipoFactor").Value);
                                    imp_tr_ieps_tasacuota = Convert.ToString(Imp_traslado.Attribute("TasaOCuota").Value);
                                    imp_tr_ieps_importe = Convert.ToString(Imp_traslado.Attribute("Importe").Value);
                                    break;
                                default:
                                    imp_tr_iva_impuesto = "-";
                                    imp_tr_iva_tipofactor = "-";
                                    imp_tr_iva_tasacuota = "0.00";
                                    imp_tr_iva_importe = "0.00";
                                    imp_tr_isr_impuesto = "-";
                                    imp_tr_isr_tipofactor = "-";
                                    imp_tr_isr_tasacuota = "0.00";
                                    imp_tr_isr_importe = "0.00";
                                    imp_tr_ieps_impuesto = "-";
                                    imp_tr_ieps_tipofactor = "-";
                                    imp_tr_ieps_tasacuota = "0.00";
                                    imp_tr_ieps_importe = "0.00";
                                    break;
                            }                        
                        }
                    }
                }
                else
                {
                    imp_totalimpret = "0.00";
                    imp_totalimptras = "0.00";   
                }
                
                /**/XElement Complemento = Comprobante.Element(cfdi.GetName("Complemento"));
                
                if (Complemento.Element(nomina12.GetName("Nomina")) != null)
                {
                    /******/XElement Nomina = Complemento.Element(nomina12.GetName("Nomina"));
                    //--------------------------ELEMENTOS DEL NODO Nomina12:Nomina--------------------------------
                    nom_fechIniPago = Convert.ToDateTime(Nomina.Attribute("FechaInicialPago").Value);
                    nom_fechapago = Convert.ToDateTime(Nomina.Attribute("FechaPago").Value);
                    nom_fechFinalPago = Convert.ToDateTime(Nomina.Attribute("FechaFinalPago").Value);
                    nom_numdiaspagados = Convert.ToString(Nomina.Attribute("NumDiasPagados").Value);
                    nom_tiponomina = Convert.ToString(Nomina.Attribute("TipoNomina").Value);
                    nom_totaldeducciones = Convert.ToString(Nomina.Attribute("TotalDeducciones").Value);
                    nom_totalpercepciones = Convert.ToString(Nomina.Attribute("TotalPercepciones").Value);
                    nom_totalOtrosPagos = Convert.ToString(Nomina.Attribute("TotalOtrosPagos").Value);
                    //--------------------------------------------------------------------------------------------

                    /**********/XElement Nom_emisor = Nomina.Element(nomina12.GetName("Emisor"));
                    //--------------ELEMENTOS DEL NODO Nomina12:Emisor (DENTRO DE Nomina12:Nomina)----------------
                    if (Nom_emisor.Attribute("RegistroPatronal") == null)
                        emi_registropatronal = "-";
                    else
                        emi_registropatronal = Convert.ToString(Nom_emisor.Attribute("RegistroPatronal").Value); //CONDICIONAR CON NULO
                    //--------------------------------------------------------------------------------------------

                    /**********/XElement Nom_receptor = Nomina.Element(nomina12.GetName("Receptor"));
                    //--------------ELEMENTOS DEL NODO Nomina12:Receptor (DENTRO DE Nomina12:Nomina)--------------------
                    if (Nom_receptor.Attribute("Antigüedad") == null)
                        rec_antiguedad = "-";
                    else
                        rec_antiguedad = Convert.ToString(Nom_receptor.Attribute("Antigüedad").Value);

                    if (Nom_receptor.Attribute("Banco") == null)
                        rec_banco = "-";
                    else
                        rec_banco = Convert.ToString(Nom_receptor.Attribute("Banco").Value);

                    if (Nom_receptor.Attribute("ClaveEntFed") == null)
                        rec_claveEntFed = "-";
                    else
                        rec_claveEntFed = Convert.ToString(Nom_receptor.Attribute("ClaveEntFed").Value);

                    if (Nom_receptor.Attribute("CuentaBancaria") == null)
                        rec_cuentabancaria = "-";
                    else
                        rec_cuentabancaria = Convert.ToString(Nom_receptor.Attribute("CuentaBancaria").Value);

                    if (Nom_receptor.Attribute("Curp") == null)
                        rec_curp = "-";
                    else
                        rec_curp = Convert.ToString(Nom_receptor.Attribute("Curp").Value);

                    if (Nom_receptor.Attribute("Departamento") == null)
                        rec_departamento = "-";
                    else
                        rec_departamento = Convert.ToString(Nom_receptor.Attribute("Departamento").Value);

                    if (Nom_receptor.Attribute("FechaInicioRelLaboral") == null)
                        rec_fechaIniLaboral = new DateTime(0, 0, 0);
                    else
                        rec_fechaIniLaboral = Convert.ToDateTime(Nom_receptor.Attribute("FechaInicioRelLaboral").Value);

                    if (Nom_receptor.Attribute("NumEmpleado") == null)
                        rec_numempleado = "-";
                    else
                        rec_numempleado = Convert.ToString(Nom_receptor.Attribute("NumEmpleado").Value);

                    if (Nom_receptor.Attribute("NumSeguridadSocial") == null)
                        rec_numSegSoc = "-";
                    else
                        rec_numSegSoc = Convert.ToString(Nom_receptor.Attribute("NumSeguridadSocial").Value);

                    if (Nom_receptor.Attribute("PeriodicidadPago") == null)
                        rec_periodiPago = "-";
                    else
                        rec_periodiPago = Convert.ToString(Nom_receptor.Attribute("PeriodicidadPago").Value);

                    if (Nom_receptor.Attribute("Puesto") == null)
                        rec_puesto = "-";
                    else
                        rec_puesto = Convert.ToString(Nom_receptor.Attribute("Puesto").Value);

                    if (Nom_receptor.Attribute("RiesgoPuesto") == null)
                        rec_riesgopuesto = "-";
                    else
                        rec_riesgopuesto = Convert.ToString(Nom_receptor.Attribute("RiesgoPuesto").Value);

                    if (Nom_receptor.Attribute("SalarioBaseCotApor") == null)
                        rec_salariobaseCA = "0.00";
                    else
                        rec_salariobaseCA = Convert.ToString(Nom_receptor.Attribute("SalarioBaseCotApor").Value);

                    if (Nom_receptor.Attribute("SalarioDiarioIntegrado") == null)
                        rec_salariodiarioInt = "0.00";
                    else
                        rec_salariodiarioInt = Convert.ToString(Nom_receptor.Attribute("SalarioDiarioIntegrado").Value);

                    if (Nom_receptor.Attribute("Sindicalizado") == null)
                        rec_sindicalizado = "-";
                    else
                        rec_sindicalizado = Convert.ToString(Nom_receptor.Attribute("Sindicalizado").Value);

                    if (Nom_receptor.Attribute("TipoContrato") == null)
                        rec_tipocontrato = "-";
                    else
                        rec_tipocontrato = Convert.ToString(Nom_receptor.Attribute("TipoContrato").Value);

                    if (Nom_receptor.Attribute("TipoJornada") == null)
                        rec_tipojornada = "-";
                    else
                        rec_tipojornada = Convert.ToString(Nom_receptor.Attribute("TipoJornada").Value);

                    if (Nom_receptor.Attribute("TipoRegimen") == null)
                        rec_tiporegimen = "-";
                    else
                        rec_tiporegimen = Convert.ToString(Nom_receptor.Attribute("TipoRegimen").Value);
                    //---------------------------------------------------------------------------------------------------

                    /**********/XElement Nom_percepciones = Nomina.Element(nomina12.GetName("Percepciones"));
                    //----------------------------ELEMENTOS DEL NODO Nomina12:Percepciones--------------------------------
                    per_totalexento = Convert.ToString(Nom_percepciones.Attribute("TotalExento").Value);
                    per_totalgravado = Convert.ToString(Nom_percepciones.Attribute("TotalGravado").Value);
                    per_totalsueldos = Convert.ToString(Nom_percepciones.Attribute("TotalSueldos").Value);
                    //---------------------------------------------------------------------------------------------------

                    /**************/XElement Per_percepcion = Nom_percepciones.Element(nomina12.GetName("Percepcion"));
                    //--------------------------ELEMENTOS DEL NODO Nomina12:Percepcion------------------------------------
                    foreach (XElement Per in Nom_percepciones.Elements("Percepcion"))
                    {
                        switch (Convert.ToString(Per.Attribute("TipoPercepcion").Value))
                        {
                            case "001":
                                per_001_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_001_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "002":
                                per_002_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_002_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "003":
                                per_003_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_003_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "004":
                                per_004_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_004_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                            case "005":
                                per_005_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_005_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "006":
                                per_006_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_006_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break
                            case "007":
                                per_007_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_007_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "008":
                                per_008_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_008_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "009":
                                per_009_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_009_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "010":
                                per_010_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_010_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break
                            case "011":
                                per_011_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_011_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "012":
                                per_012_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_012_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break
                            case "013":
                                per_013_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_013_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                            case "014":
                                per_014_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_014_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "015":
                                per_015_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_015_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break
                            case "016":
                                per_016_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_016_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "017":
                                per_017_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_017_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "018":
                                per_018_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_018_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "019":
                                per_019_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_019_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                            case "020":
                                per_020_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_020_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "021":
                                per_021_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_021_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break
                            case "022":
                                per_022_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_022_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "023":
                                per_023_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_023_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "024":
                                per_024_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_024_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "025":
                                per_025_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_025_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break
                            case "026":
                                per_026_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_026_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "027":
                                per_027_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_027_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "028":
                                per_028_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_028_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "029":
                                per_029_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_029_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                            case "030":
                                per_030_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_030_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "031":
                                per_031_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_031_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break
                            case "032":
                                per_032_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_032_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "033":
                                per_033_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_033_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "034":
                                per_034_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_034_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "035":
                                per_035_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_035_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break
                            case "036":
                                per_036_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_036_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "037":
                                per_037_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_037_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break
                            case "038":
                                per_038_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_038_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                            case "039":
                                per_039_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_039_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "040":
                                per_040_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_040_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break
                            case "041":
                                per_041_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_041_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "042":
                                per_042_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_042_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "043":
                                per_043_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_043_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "044":
                                per_044_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_044_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                            case "045":
                                per_045_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_045_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "046":
                                per_046_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_046_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break
                            case "047":
                                per_047_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_047_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "048":
                                per_048_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_048_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "049":
                                per_049_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_049_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break;
                            case "050":
                                per_050_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_050_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                break                              
                            default:
                                per_001_importeexento = "0.00";
                                per_001_importegravado = "0.00";
                                per_002_importeexento = "0.00";
                                per_002_importegravado = "0.00";
                                per_003_importeexento = "0.00";
                                per_003_importegravado = "0.00";
                                per_004_importeexento = "0.00";
                                per_004_importegravado = "0.00";
                                per_005_importeexento = "0.00";
                                per_005_importegravado = "0.00";
                                per_006_importeexento = "0.00";
                                per_006_importegravado = "0.00";
                                per_007_importeexento = "0.00";
                                per_007_importegravado = "0.00";
                                per_008_importeexento = "0.00";
                                per_008_importegravado = "0.00";
                                per_009_importeexento = "0.00";
                                per_009_importegravado = "0.00";
                                per_010_importeexento = "0.00";
                                per_010_importegravado = "0.00";
                                per_011_importeexento = "0.00";
                                per_011_importegravado = "0.00";
                                per_012_importeexento = "0.00";
                                per_012_importegravado = "0.00";
                                per_013_importeexento = "0.00";
                                per_013_importegravado = "0.00";
                                per_014_importeexento = "0.00";
                                per_014_importegravado = "0.00";
                                per_015_importeexento = "0.00";
                                per_015_importegravado = "0.00";
                                per_016_importeexento = "0.00";
                                per_016_importegravado = "0.00";
                                per_017_importeexento = "0.00";
                                per_017_importegravado = "0.00";
                                per_018_importeexento = "0.00";
                                per_018_importegravado = "0.00";
                                per_019_importeexento = "0.00";
                                per_019_importegravado = "0.00";
                                per_020_importeexento = "0.00";
                                per_020_importegravado = "0.00";
                                per_031_importeexento = "0.00";
                                per_031_importegravado = "0.00";
                                per_032_importeexento = "0.00";
                                per_032_importegravado = "0.00";
                                per_033_importeexento = "0.00";
                                per_033_importegravado = "0.00";
                                per_034_importeexento = "0.00";
                                per_034_importegravado = "0.00";
                                per_035_importeexento = "0.00";
                                per_035_importegravado = "0.00";
                                per_036_importeexento = "0.00";
                                per_036_importegravado = "0.00";
                                per_037_importeexento = "0.00";
                                per_037_importegravado = "0.00";
                                per_038_importeexento = "0.00";
                                per_038_importegravado = "0.00";
                                per_039_importeexento = "0.00";
                                per_039_importegravado = "0.00";
                                per_040_importeexento = "0.00";
                                per_040_importegravado = "0.00";
                                per_041_importeexento = "0.00";
                                per_041_importegravado = "0.00";
                                per_042_importeexento = "0.00";
                                per_042_importegravado = "0.00";
                                per_043_importeexento = "0.00";
                                per_043_importegravado = "0.00";
                                per_044_importeexento = "0.00";
                                per_044_importegravado = "0.00";
                                per_045_importeexento = "0.00";
                                per_045_importegravado = "0.00";
                                per_046_importeexento = "0.00";
                                per_046_importegravado = "0.00";
                                per_047_importeexento = "0.00";
                                per_047_importegravado = "0.00";
                                per_048_importeexento = "0.00";
                                per_048_importegravado = "0.00";
                                per_049_importeexento = "0.00";
                                per_049_importegravado = "0.00";
                                per_050_importeexento = "0.00";
                                per_050_importegravado = "0.00";
                                
                                break;
                        }
                        
                    }
                    //---------------------------------------------------------------------------------------------------

                    /**********/XElement Nom_deducciones = Nomina.Element(nomina12.GetName("Deducciones"));
                    //---------------------------ELEMENTOS DEL NODO Nomina12:Deducciones---------------------------------
                    ded_totalImpRet = Convert.ToString(Nom_deducciones.Attribute("TotalImpuestosRetenidos").Value);
                    ded_totalOtDed = Convert.ToString(Nom_deducciones.Attribute("TotalOtrasDeducciones").Value);
                    //---------------------------------------------------------------------------------------------------

                    /**************/XElement Ded_deduccion = Nom_deducciones.Element(nomina12.GetName("Deduccion"));
                    //------------------------------ELEMENTOS DEL NODO Nomina12:Deduccion--------------------------------
                    foreach (XElement Ded in Nom_deducciones.Elements("Deduccion"))
                    {
                        switch (Convert.ToString(Ded.Attribute("TipoDeduccion").Value))
                        {
                            case "001":
                                ded_001_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "002":                                
                                ded_002_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "003":                                
                                ded_003_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "004":
                                ded_004_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "005":                                
                                ded_005_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "006":                                
                                ded_006_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "007":
                                ded_007_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "008":                                
                                ded_008_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "009":                                
                                ded_009_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "010":                                
                                ded_010_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "011":
                                ded_011_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "012":                                
                                ded_012_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "013":                                
                                ded_013_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "014":
                                ded_014_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "015":                                
                                ded_015_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "016":                                
                                ded_016_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "017":
                                ded_017_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "018":                                
                                ded_018_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "019":                                
                                ded_019_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "020":                                
                                ded_020_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "021":
                                ded_021_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "022":                                
                                ded_022_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "0023":                                
                                ded_023_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "024":
                                ded_024_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "025":                                
                                ded_025_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "026":                                
                                ded_026_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "027":
                                ded_027_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "028":                                
                                ded_028_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "029":                                
                                ded_029_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "030":                                
                                ded_030_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "031":
                                ded_031_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "032":                                
                                ded_032_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "033":                                
                                ded_033_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "034":
                                ded_034_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "035":                                
                                ded_035_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "036":                                
                                ded_036_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "037":
                                ded_037_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "038":                                
                                ded_038_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "039":                                
                                ded_039_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "040":                                
                                ded_040_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "041":
                                ded_041_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "042":                                
                                ded_042_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "043":                                
                                ded_043_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "044":
                                ded_044_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "045":                                
                                ded_045_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "046":                                
                                ded_046_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "047":
                                ded_047_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "048":                                
                                ded_048_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "049":                                
                                ded_049_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "050":                                
                                ded_050_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "051":
                                ded_051_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "052":                                
                                ded_052_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "053":                                
                                ded_053_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "054":
                                ded_054_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "055":                                
                                ded_055_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "056":                                
                                ded_056_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "057":
                                ded_057_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "058":                                
                                ded_058_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "059":                                
                                ded_059_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "060":                                
                                ded_060_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "061":
                                ded_061_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "062":                                
                                ded_062_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "063":                                
                                ded_063_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "064":
                                ded_064_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "065":                                
                                ded_065_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "066":                                
                                ded_066_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "067":
                                ded_067_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "068":                                
                                ded_068_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "069":                                
                                ded_069_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "070":                                
                                ded_070_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "071":
                                ded_071_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "072":                                
                                ded_072_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "073":                                
                                ded_073_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "074":
                                ded_074_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "075":                                
                                ded_075_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "076":                                
                                ded_076_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "077":
                                ded_077_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "078":                                
                                ded_078_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "079":                                
                                ded_079_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "080":                                
                                ded_080_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "081":
                                ded_081_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "082":                                
                                ded_082_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "083":                                
                                ded_083_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "084":
                                ded_084_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "085":                                
                                ded_085_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "086":                                
                                ded_086_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "087":
                                ded_087_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "088":                                
                                ded_088_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "089":                                
                                ded_089_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "090":                                
                                ded_090_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "091":
                                ded_091_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "092":                                
                                ded_092_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "093":                                
                                ded_093_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "094":
                                ded_094_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "095":                                
                                ded_095_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "096":                                
                                ded_096_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "097":
                                ded_097_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "098":                                
                                ded_098_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "099":                                
                                ded_099_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "100":                                
                                ded_100_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            case "101":                                
                                ded_101_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                break;
                            default:                                
                                ded_001_importe = "0.00";                                
                                ded_002_importe = "0.00";
                                ded_003_importe = "0.00";
                                ded_004_importe = "0.00";                                
                                ded_005_importe = "0.00";
                                ded_006_importe = "0.00";
                                ded_007_importe = "0.00";
                                ded_008_importe = "0.00";
                                ded_009_importe = "0.00";
                                ded_010_importe = "0.00";
                                ded_011_importe = "0.00";                                
                                ded_012_importe = "0.00";
                                ded_013_importe = "0.00";
                                ded_014_importe = "0.00";                                
                                ded_015_importe = "0.00";
                                ded_016_importe = "0.00";
                                ded_017_importe = "0.00";
                                ded_018_importe = "0.00";
                                ded_019_importe = "0.00";
                                ded_020_importe = "0.00";
                                ded_021_importe = "0.00";                                
                                ded_022_importe = "0.00";
                                ded_023_importe = "0.00";
                                ded_024_importe = "0.00";                                
                                ded_025_importe = "0.00";
                                ded_026_importe = "0.00";
                                ded_027_importe = "0.00";
                                ded_028_importe = "0.00";
                                ded_029_importe = "0.00";
                                ded_030_importe = "0.00";
                                ded_031_importe = "0.00";                                
                                ded_032_importe = "0.00";
                                ded_033_importe = "0.00";
                                ded_034_importe = "0.00";                                
                                ded_035_importe = "0.00";
                                ded_036_importe = "0.00";
                                ded_037_importe = "0.00";
                                ded_038_importe = "0.00";
                                ded_039_importe = "0.00";
                                ded_040_importe = "0.00";
                                ded_041_importe = "0.00";                                
                                ded_042_importe = "0.00";
                                ded_043_importe = "0.00";
                                ded_044_importe = "0.00";                                
                                ded_045_importe = "0.00";
                                ded_046_importe = "0.00";
                                ded_047_importe = "0.00";
                                ded_048_importe = "0.00";
                                ded_049_importe = "0.00";
                                ded_050_importe = "0.00";
                                ded_051_importe = "0.00";                                
                                ded_052_importe = "0.00";
                                ded_053_importe = "0.00";
                                ded_054_importe = "0.00";                                
                                ded_055_importe = "0.00";
                                ded_056_importe = "0.00";
                                ded_057_importe = "0.00";
                                ded_058_importe = "0.00";
                                ded_059_importe = "0.00";
                                ded_060_importe = "0.00";
                                ded_061_importe = "0.00";                                
                                ded_062_importe = "0.00";
                                ded_063_importe = "0.00";
                                ded_064_importe = "0.00";                                
                                ded_065_importe = "0.00";
                                ded_066_importe = "0.00";
                                ded_067_importe = "0.00";
                                ded_068_importe = "0.00";
                                ded_069_importe = "0.00";
                                ded_070_importe = "0.00";
                                ded_071_importe = "0.00";                                
                                ded_072_importe = "0.00";
                                ded_073_importe = "0.00";
                                ded_074_importe = "0.00";                                
                                ded_075_importe = "0.00";
                                ded_076_importe = "0.00";
                                ded_077_importe = "0.00";
                                ded_078_importe = "0.00";
                                ded_079_importe = "0.00";
                                ded_080_importe = "0.00";
                                ded_081_importe = "0.00";                                
                                ded_082_importe = "0.00";
                                ded_083_importe = "0.00";
                                ded_084_importe = "0.00";                                
                                ded_085_importe = "0.00";
                                ded_086_importe = "0.00";
                                ded_087_importe = "0.00";
                                ded_088_importe = "0.00";
                                ded_089_importe = "0.00";
                                ded_090_importe = "0.00";
                                ded_091_importe = "0.00";                                
                                ded_092_importe = "0.00";
                                ded_093_importe = "0.00";
                                ded_094_importe = "0.00";                                
                                ded_095_importe = "0.00";
                                ded_096_importe = "0.00";
                                ded_097_importe = "0.00";
                                ded_098_importe = "0.00";
                                ded_099_importe = "0.00";
                                ded_100_importe = "0.00";
                                ded_101_importe = "0.00";
                                
                                break;
                        }
                        
                    }
                    //---------------------------------------------------------------------------------------------------
                    /**************/XElement Nom_OtroPagos = Nomina.Element(nomina12.GetName("OtroPagos"));

                    //--------------------------ELEMENTOS DEL NODO Nomina12:OtroPago------------------------------------
                    //--------REVISAR SI EL NODO OTRO PAGO ESTA CORRECTAMENTE ESTRUCTURADO------------------------------
                    foreach (XElement Per in Nom_OtroPagos.Elements("OtroPago"))
                    {
                        switch (Convert.ToString(Per.Attribute("TipoOtroPago").Value))
                        {
                            case "001":
                                otrpag_001_importe += Convert.ToString(Per.Attribute("Importe").Value) + " * ";
                                break;
                            case "002":
                                otrpag_002_importe += Convert.ToString(Per.Attribute("Importe").Value) + " * ";
                                break;
                            case "003":
                                otrpag_003_importe += Convert.ToString(Per.Attribute("Importe").Value) + " * ";
                                break;
                            case "004":
                                otrpag_004_importe += Convert.ToString(Per.Attribute("Importe").Value) + " * ";
                                break;
                            case "005":
                                otrpag_005_importe += Convert.ToString(Per.Attribute("Importe").Value) + " * ";
                                break;
                            case "999":
                                otrpag_999_importe += Convert.ToString(Per.Attribute("Importe").Value) + " * ";
                                break;
                            default:
                                otrpag_001_importe = "0.00";
                                otrpag_001_importe = "0.00";
                                otrpag_001_importe = "0.00";
                                otrpag_001_importe = "0.00";
                                otrpag_001_importe = "0.00";
                                otrpag_001_importe = "0.00";
                            break;
                        }
                    }

                            
                }
                else
                {
                    //--------------------------ELEMENTOS DEL NODO Nomina12:Nomina--------------------------------

                    //FECHAS NULAS = ??? (INVESTIGAR SI ES POSIBLE)

                    nom_fechIniPago = new DateTime(0,0,0);      //Pendiente
                    nom_fechapago = new DateTime(0,0,0);
                    nom_fechFinalPago = new DateTime(0,0,0);
                    nom_numdiaspagados = "0.00";
                    nom_tiponomina = "-";
                    nom_totaldeducciones = "0.00";
                    nom_totalpercepciones = "0.00";
                    //--------------------------------------------------------------------------------------------

                    //--------------ELEMENTOS DEL NODO Nomina12:Emisor (DENTRO DE Nomina12:Nomina)----------------
                    emi_registropatronal = "-";
                    //--------------------------------------------------------------------------------------------

                    //--------------ELEMENTOS DEL NODO Nomina12:Receptor (DENTRO DE Nomina12:Nomina)--------------
                    rec_antiguedad = "-";
                    rec_banco = "000";
                    rec_claveEntFed = "-";
                    rec_cuentabancaria = "-";
                    rec_curp = "-";
                    rec_departamento = "-";
                    rec_fechaIniLaboral = new DateTime(0,0,0);
                    rec_numempleado = "-";
                    rec_numSegSoc = "-";
                    rec_periodiPago = "-";
                    rec_puesto = "-";
                    rec_riesgopuesto = "-";                    rec_salariobaseCA = "-";
                    rec_salariodiarioInt = "-";
                    rec_sindicalizado = "-";
                    rec_tipocontrato = "-";
                    rec_tipojornada = "-";
                    rec_tiporegimen = "-";
                    //---------------------------------------------------------------------------------------------------

                    //----------------------------ELEMENTOS DEL NODO Nomina12:Percepciones--------------------------------
                    per_totalexento = "0.00";
                    per_totalgravado = "0.00";
                    per_totalsueldos = "0.00";
                    //---------------------------------------------------------------------------------------------------

                    //---------------------------ELEMENTOS DEL NODO Nomina12:Deducciones---------------------------------
                    ded_totalImpRet = "0.00";
                    ded_totalOtDed = "0.00";
                    //---------------------------------------------------------------------------------------------------
                }

                if (Complemento.Element(pago10.GetName("Pagos")) != null)
                {
                    /******/XElement Pagos = Complemento.Element(pago10.GetName("Pagos"));
                    
                    /**********/XElement Pago = Pagos.Element(pago10.GetName("Pago"));
                    //---------------------------------ELEMENTOS DEL NODO Pago10:Pago-------------------------------------
                    pag_fechaPago = Convert.ToDateTime(Pago.Attribute("FechaPago").Value);
                    pag_formaPagoP = Convert.ToString(Pago.Attribute("FormaDePagoP").Value);
                    pag_monedaP = Convert.ToString(Pago.Attribute("MonedaP").Value);
                    pag_monto = Convert.ToString(Pago.Attribute("Monto").Value);
                    pag_rfcEmisorCO = Convert.ToString(Pago.Attribute("RfcEmisorCtaOrd").Value);
                    pag_nomBancOrdExt = Convert.ToString(Pago.Attribute("NomBancoOrdExt").Value);
                    pag_ctaOrdenante = Convert.ToString(Pago.Attribute("CtaOrdenante").Value);
                    pag_rfcEmiCtaBen = Convert.ToString(Pago.Attribute("RfcEmisorCtaBen").Value);
                    pag_ctaBeneficiario = Convert.ToString(Pago.Attribute("CtaBeneficiario").Value);
                    //----------------------------------------------------------------------------------------------------

                    /**************/XElement DoctoRel = Pago.Element(pago10.GetName("DoctoRelacionado"));
                    //------------------------ELEMENTOS DEL NODO Pago10:DoctoRelacionado----------------------------------
                    dr_idDoc = Convert.ToString(DoctoRel.Attribute("IdDocumento").Value);
                    dr_serie = Convert.ToString(DoctoRel.Attribute("Serie").Value);
                    dr_folio = Convert.ToString(DoctoRel.Attribute("Folio").Value);
                    dr_monedaDR = Convert.ToString(DoctoRel.Attribute("MonedaDR").Value);
                    dr_metodoPagoDR = Convert.ToString(DoctoRel.Attribute("MetodoDePagoDR").Value);
                    dr_numParcialidad = Convert.ToString(DoctoRel.Attribute("NumParcialidad").Value);
                    dr_impSaldoAnt = Convert.ToString(DoctoRel.Attribute("ImpSaldoAnt").Value);
                    dr_impPagado = Convert.ToString(DoctoRel.Attribute("ImpPagado").Value);
                    dr_impSaldoIns = Convert.ToString(DoctoRel.Attribute("ImpSaldoInsoluto").Value);
                    //----------------------------------------------------------------------------------------------------
                }
                else
                {
                    //---------------------------------ELEMENTOS DEL NODO Pago10:Pago-------------------------------------
                    pag_fechaPago = new DateTime(0,0,0);
                    pag_formaPagoP = "-";
                    pag_monedaP = "-";
                    pag_monto = "0.00";
                    pag_rfcEmisorCO = "-";
                    pag_nomBancOrdExt = "-";
                    pag_ctaOrdenante = "-";
                    pag_rfcEmiCtaBen = "-";
                    pag_ctaBeneficiario = "-";
                    //----------------------------------------------------------------------------------------------------

                    //---------------------------ELEMENTOS DEL NODO Pago10:DoctoRelacionado-------------------------------
                    dr_idDoc = "-";
                    dr_serie = "-";
                    dr_folio = "-";
                    dr_monedaDR = "-";
                    dr_metodoPagoDR = "-";
                    dr_numParcialidad = "-";
                    dr_impSaldoAnt = "-";
                    dr_impPagado = "0.00";
                    dr_impSaldoIns = "0.00";
                    //----------------------------------------------------------------------------------------------------
                }

                /******/XElement Timbrefiscal = Complemento.Element(tfd.GetName("TimbreFiscalDigital")); 
                //ELEMENTOS DEL NODO tfd:TimbreFiscalDigital
                tim_uuid = Convert.ToString(Timbrefiscal.Attribute("UUID").Value);
                tim_fechatimbrado = Convert.ToDateTime(Timbrefiscal.Attribute("FechaTimbrado").Value);
                //--------------------------------------------------------------------------------------------------------
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema con la lectura del archivo. \nError tipo: " + ex.ToString());
            }
        }
    }
}

/* -----------------------------------------------------------------------------------------------------------------
 * ----------------------------------------- OBSERVACIONES----------------------------------------------------------
 * _________________________________________________________________________________________________________________
 * 1.- ANALIZAR CONDICIONAMIENTO DE VARIABLES "TIPO DE CAMBIO" Y "FORMA DE PAGO" EN NODO COMPROBANTE
 * _________________________________________________________________________________________________________________
 * 2.- REVISAR EL CODIGO Y VARIABLES PARA EL COMIENZO DE NUEVAS CONDICIONES Y ELIMINACION DE DATOS INNECESARIOS
 * _________________________________________________________________________________________________________________
 * 3.- REVISION GENERAL DEL PROGRAMA, PARA PROCEDER A ELABORACION DE INTERFACES
 * _________________________________________________________________________________________________________________
 * 4.- REALIZAR PRUEBAS CON DIFERENTES ARCHIVOS XML, EN BUSCA DE ERRORES
 * _________________________________________________________________________________________________________________
 */