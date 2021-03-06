﻿using System;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Evodia.Voyager.Controllers
{
    public class VoyagerController : SurfaceController
    {
        [HttpPost]
        public JsonResult Sync()
        {
            try
            {
                var api = new Domain.Voyager(Services.ContentService);
                api.SyncAll();

                return Json(new {
                    status = "OK",
                    data = api.GetStatistics(),
                    message = "Sync has been succesful."
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
