﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerationLib
{
    public class ReportGenerator
    {
        public static string GetReportName(int userId)
        {
            // remove this return statement
            return string.Empty;

            //var userRepo = new UserRepository();
            //var user = userRepo.GetUser(userId);
            //var city = CityLookup.Lookup(user.CityCode);

            //return user.LastName + "_" + user.FirstName + "_" + city + "_" + DateTime.Now.ToString("g");
        }
    }
}
