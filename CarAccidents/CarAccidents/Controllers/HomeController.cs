using log4net;
using System;
using System.Web.Mvc;
using Google.Cloud.BigQuery.V2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1;
using Google.Apis.Services;
using CarAccidents.Google;
using CarAccidents.Models;

namespace CarAccidents.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(HomeController));
        private Service service = new Service();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Map(MapModel model)
        {
            model.ResultDataList = service.getMapData(null);
            return View(model);
        }

        [HttpGet]
        public ActionResult Top10States(MapModel model)
        {
            model.ResultDataList = service.getMapData("2018");
            return View(model);
        }

        [HttpGet]
        public ActionResult Factors(MapModel model)
        {
            model.ResultFactorsList = service.getAccidnetsFactors();
            return View(model);
        }
    }
}