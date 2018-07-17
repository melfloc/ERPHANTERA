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
        public string tr_base;
        public string tr_impuesto;
        public string tr_tipofactor;
        public string tr_tasacuota;
        public string tr_importe;

        //VARIABLES GLOBALES PARA NODO cfdi:Retencion (DENTRO DE cfdi:Concepto)
        public string ret_base;
        public string ret_impuesto;
        public string ret_tipofactor;
        public string ret_tasacuota;
        public string ret_importe;

        //VARIABLES GLOBALES PARA NODO cfdi:Impuesto
        public string imp_totalimpret;
        public string imp_totalimptras;

        //VARIABLES GLOBALES PARA NODO cfdi:Traslado (DENTRO DE cfdi:Impuestos)
        public string imp_tr_impuesto;
        public string imp_tr_tipofactor;
        public string imp_tr_tasacuota;
        public string imp_tr_importe;

        //VARIABLES GLOBALES PARA NODO cfdi:Retencion (DENTRO DE cfdi:Impuesto)
        public string imp_ret_impuesto;
        public string imp_ret_importe;

        //VARIABLES GLOBALES PARA NODO tfd:TimbreFiscalDigital
        public string tim_uuid;
        public DateTime tim_fechatimbrado;

        public void get_datos(string ruta)
        {
            //try
            //{
                //CARGA DEL DOCUMENTO XML
                XDocument documento = XDocument.Load(ruta);

                //DETECCION DE NODOS (HACE FALTA CONDIONAR)
                XElement Comprobante = documento.Element(cfdi.GetName("Comprobante"));
                XElement Emisor = Comprobante.Element(cfdi.GetName("Emisor"));
                XElement Receptor = Comprobante.Element(cfdi.GetName("Receptor"));
                XElement Conceptos = Comprobante.Element(cfdi.GetName("Conceptos"));
                XElement Concepto = Conceptos.Element(cfdi.GetName("Concepto"));
                XElement Con_impuestos = Concepto.Element(cfdi.GetName("Impuestos"));
                XElement Con_traslados = Con_impuestos.Element(cfdi.GetName("Traslados"));
                XElement Con_traslado = Con_traslados.Element(cfdi.GetName("Traslado"));
                XElement Con_retenciones = Con_impuestos.Element(cfdi.GetName("Retenciones"));
                XElement Con_retencion = Con_retenciones.Element(cfdi.GetName("Retencion"));
                XElement Impuestos = Comprobante.Element(cfdi.GetName("Impuestos"));
                XElement Imp_retenciones = Impuestos.Element(cfdi.GetName("Retenciones"));
                XElement Imp_retencion = Imp_retenciones.Element(cfdi.GetName("Retencion"));
                XElement Imp_Traslados = Impuestos.Element(cfdi.GetName("Traslados"));
                XElement Imp_traslado = Imp_Traslados.Element(cfdi.GetName("Traslado"));
                XElement Complemento = Comprobante.Element(cfdi.GetName("Complemento"));
                XElement Timbrefiscal = Complemento.Element(tfd.GetName("TimbreFiscalDigital"));

                //############################ OBTENCION DE DATOS DE LOS NODOS #####################################
                //FALTA ACOMPLETAR (COTEJAR CON LA LISTA SOLICITADA) Y CONDICIONAR.
                //ELEMENTOS DEL NODO cfdi:Comprobante
                comp_version = Convert.ToString(Comprobante.Attribute("Version").Value);
                comp_serie = Convert.ToString(Comprobante.Attribute("Serie").Value);
                comp_folio = Convert.ToString(Comprobante.Attribute("Folio").Value);
                comp_fecha = Convert.ToDateTime(Comprobante.Attribute("Fecha").Value);
                comp_formapago = Convert.ToString(Comprobante.Attribute("FormaPago").Value);
                comp_condpago = Convert.ToString(Comprobante.Attribute("CondicionesDePago").Value);
                comp_subtotal = Convert.ToString(Comprobante.Attribute("SubTotal").Value);
                //comp_descuento = Convert.ToString(Comprobante.Attribute("Descuento").Value);
                comp_moneda = Convert.ToString(Comprobante.Attribute("Moneda").Value);
                comp_total = Convert.ToString(Comprobante.Attribute("Total").Value);
                comp_tipocomprobante = Convert.ToString(Comprobante.Attribute("TipoDeComprobante").Value);
                comp_metodopago = Convert.ToString(Comprobante.Attribute("MetodoPago").Value);
                comp_lugarexpedicion = Convert.ToString(Comprobante.Attribute("LugarExpedicion").Value);

                //ELEMENTOS DEL NODO cfdi:Emisor
                emi_regimenfiscal = Convert.ToString(Emisor.Attribute("RegimenFiscal").Value);
                emi_rfc = Convert.ToString(Emisor.Attribute("Rfc").Value);
                emi_nombre = Convert.ToString(Emisor.Attribute("Nombre").Value);

                //ELEMENTOS DEL NODO cfdi:Receptor
                rec_rfc = Convert.ToString(Receptor.Attribute("Rfc").Value);
                rec_nombre = Convert.ToString(Receptor.Attribute("Nombre").Value);
                rec_usocfdi = Convert.ToString(Receptor.Attribute("UsoCFDI").Value);

                //ELEMENTOS DEL NODO cfdi:Concepto
                con_claveprodserv = Convert.ToString(Concepto.Attribute("ClaveProdServ").Value);
                con_claveunidad = Convert.ToString(Concepto.Attribute("ClaveUnidad").Value);
                con_cantidad = Convert.ToString(Concepto.Attribute("Cantidad").Value);
                con_unidad = Convert.ToString(Concepto.Attribute("Unidad").Value);
                //con_noid = Convert.ToString(Concepto.Attribute("NoIdentificacion").Value);
                con_descripcion = Convert.ToString(Concepto.Attribute("Descripcion").Value);
                con_valorunitario = Convert.ToString(Concepto.Attribute("ValorUnitario").Value);
                con_importe = Convert.ToString(Concepto.Attribute("Importe").Value);
                //con_descuento = Convert.ToString(Concepto.Attribute("Descuento").Value);

                //ELEMENTOS DEL NODO cfdi:Traslado (DENTRO DE cfdi:Concepto)
                tr_base = Convert.ToString(Con_traslado.Attribute("Base").Value);
                tr_impuesto = Convert.ToString(Con_traslado.Attribute("Impuesto").Value);
                tr_tipofactor = Convert.ToString(Con_traslado.Attribute("TipoFactor").Value);
                tr_tasacuota = Convert.ToString(Con_traslado.Attribute("TasaOCuota").Value);
                tr_importe = Convert.ToString(Con_traslado.Attribute("Importe").Value);

                //ELEMENTOS DEL NODO cfdi:Retencion (DENTRO DE cfdi:Concepto)
                ret_base = Convert.ToString(Con_retencion.Attribute("Base").Value);
                ret_impuesto = Convert.ToString(Con_retencion.Attribute("Impuesto").Value);
                ret_tipofactor = Convert.ToString(Con_retencion.Attribute("TipoFactor").Value);
                ret_tasacuota = Convert.ToString(Con_retencion.Attribute("TasaOCuota").Value);
                ret_importe = Convert.ToString(Con_retencion.Attribute("Importe").Value);

                //ELEMENTOS DE NODO cfdi:Impuestos
                imp_totalimpret = Convert.ToString(Impuestos.Attribute("TotalImpuestosRetenidos").Value);
                imp_totalimptras = Convert.ToString(Impuestos.Attribute("TotalImpuestosTrasladados").Value);

                //ELEMENTOS DEL NODO cfdi:Traslado (DENTRO DE cfdi:Impuestos)
                imp_tr_impuesto = Convert.ToString(Imp_traslado.Attribute("Impuesto").Value);
                imp_tr_tipofactor = Convert.ToString(Imp_traslado.Attribute("TipoFactor").Value);
                imp_tr_tasacuota = Convert.ToString(Imp_traslado.Attribute("TasaOCuota").Value);
                imp_tr_importe = Convert.ToString(Imp_traslado.Attribute("Importe").Value);

                //ELEMENTOS DEL NODO cfdi:Retencion (DENTRO DE cfdi:Impuestos)
                imp_ret_impuesto = Convert.ToString(Imp_retencion.Attribute("Impuesto").Value);
                imp_ret_importe = Convert.ToString(Imp_retencion.Attribute("Importe").Value);

                //ELEMENTOS DEL NODO tfd:TimbreFiscalDigital
                tim_uuid = Convert.ToString(Timbrefiscal.Attribute("UUID").Value);
                tim_fechatimbrado = Convert.ToDateTime(Timbrefiscal.Attribute("FechaTimbrado").Value);
            //}
            //catch (Exception ex)
            //{
            //}
        }
    }
}
