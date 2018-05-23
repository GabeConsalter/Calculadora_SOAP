using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Newtonsoft.Json;
using Calculadora_SOAP.Scripts;

namespace Calculadora_SOAP.Controllers
{
    public class HomeController : Controller
    {
        struct Expression {
            public float fo { get; set; }
            public string op { get; set; }
            public float so { get; set; }
        }

        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View();
        }

        [System.Web.Services.WebMethod]
        public float Calcular(string expression)
        {
            var obj = JsonConvert.DeserializeObject<Expression>(expression);

            if (obj.op == "soma")
                return Calculadora.soma(obj.fo, obj.so);
            if (obj.op == "subtracao")
                return Calculadora.subtracao(obj.fo, obj.so);
            if (obj.op == "multiplicacao")
                return Calculadora.multiplicacao(obj.fo, obj.so);
            if (obj.op == "divisao")
                return Calculadora.divisao(obj.fo, obj.so);
            if (obj.op == "quadrado")
                return Calculadora.quadrado(obj.fo);
            if (obj.op == "cubo")
                return Calculadora.cubo(obj.fo);

            return 0;
        }
    }
}
