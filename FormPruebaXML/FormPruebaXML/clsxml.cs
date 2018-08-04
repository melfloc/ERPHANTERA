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
        public string per_001_clave;
        public string per_001_concepto;
        public string per_001_importeexento;
        public string per_001_importegravado;
        public string per_001_tipopercepcion;
        public string per_002_clave;
        public string per_002_concepto;
        public string per_002_importeexento;
        public string per_002_importegravado;
        public string per_002_tipopercepcion;

        //VARIABLES GLOBALES PARA NODO Nomina12:Deducciones
        public string ded_totalImpRet;
        public string ded_totalOtDed;

        //VARIABLES GLOBALES PARA NODO Nomina12:Deduccion
        public string ded_clave;
        public string ded_concepto;
        public string ded_importe;
        public string ded_tipodeduccion;

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
                                per_001_clave += Convert.ToString(Per.Attribute("Clave").Value) + " * ";
                                per_001_concepto += Convert.ToString(Per.Attribute("Concepto").Value) + " * ";
                                per_001_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_001_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                per_001_tipopercepcion += Convert.ToString(Per.Attribute("TipoPercepcion").Value) + " * ";
                                break;
                            case "002":
                                per_002_clave += Convert.ToString(Per.Attribute("Clave").Value) + " * ";
                                per_002_concepto += Convert.ToString(Per.Attribute("Concepto").Value) + " * ";
                                per_002_importeexento += Convert.ToString(Per.Attribute("ImporteExento").Value) + " * ";
                                per_002_importegravado += Convert.ToString(Per.Attribute("ImporteGravado").Value) + " * ";
                                per_002_tipopercepcion += Convert.ToString(Per.Attribute("TipoPercepcion").Value) + " * ";
                                break;
                                /*continuar de este modo (ejemplo ilustrativo)(añadir variables por cada tipo de percepcion)
                                 * 
                                 * 
                                 */
                            default:
                                per_clave = "-";
                                per_concepto = "-";
                                per_importeexento = "0.00";
                                per_importegravado = "0.00";
                                per_tipopercepcion = "-";
                                // COLOCAR EN ESTE APRTADO LOS VALORES NULOS DE TODAS LAS VARIABLES CREADAS
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
                    // AGREGAR ESTRUCTURA FOREACH
                    foreach (XElement Ded in Nom_deducciones.Elements("Deduccion"))
                    {
                        switch (Convert.ToString(Ded.Attribute("TipoDeduccion").Value))
                        {
                            case "001":
                                ded_clave += Convert.ToString(Ded.Attribute("Clave").Value) + " * ";
                                ded_concepto += Convert.ToString(Ded.Attribute("Concepto").Value) + " * ";
                                ded_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                ded_tipodeduccio += Convert.ToString(Ded.Attribute("TipoDeduccion").Value) + " * ";
                                break;
                            case "002":
                                ded_clave += Convert.ToString(Ded.Attribute("Clave").Value) + " * ";
                                ded_concepto += Convert.ToString(Ded.Attribute("Concepto").Value) + " * ";
                                ded_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                ded_tipodeduccion += Convert.ToString(Ded.Attribute("TipoDeduccion").Value) + " * ";
                                break;
                            case "003":
                                ded_clave += Convert.ToString(Ded.Attribute("Clave").Value) + " * ";
                                ded_concepto += Convert.ToString(Ded.Attribute("Concepto").Value) + " * ";
                                ded_importe += Convert.ToString(Ded.Attribute("Importe").Value) + " * ";
                                ded_tipodeduccion += Convert.ToString(Ded.Attribute("TipoDeduccion").Value) + " * ";
                                break;
                                /*continuar de este modo (ejemplo ilustrativo)(añadir variables por cada tipo de percepcion)
                                * 
                                * 
                                */
                            default:
                                ded_clave = "-";
                                ded_concepto = "-";
                                ded_importe = "0.00";
                                ded_tipodeduccion = "-";
                                // COLOCAR EN ESTE APRTADO LOS VALORES NULOS DE TODAS LAS VARIABLES CREADAS
                                break;
                        }
                        
                    }
                    //---------------------------------------------------------------------------------------------------
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
                    rec_riesgopuesto = "-";
                    rec_salariobaseCA = "-";
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

                    //--------------------------ELEMENTOS DEL NODO Nomina12:Percepcion------------------------------------
                    per_clave = "-";
                    per_concepto = "-";
                    per_importeexento = "0.00";
                    per_importegravado = "0.00";
                    per_tipopercepcion = "-";
                    //---------------------------------------------------------------------------------------------------

                    //---------------------------ELEMENTOS DEL NODO Nomina12:Deducciones---------------------------------
                    ded_totalImpRet = "0.00";
                    ded_totalOtDed = "0.00";
                    //---------------------------------------------------------------------------------------------------

                    //------------------------------ELEMENTOS DEL NODO Nomina12:Deduccion--------------------------------
                    ded_clave = "-";
                    ded_concepto = "-";
                    ded_importe = "0.00";
                    ded_tipodeduccion = "0.00";
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