using System;
using System.Collections.Generic;
using System.IO;
using MovieCompulsory.Core.Models;
using Newtonsoft.Json;

namespace MovieCompulsory.DataJson
{
    public class JsonData
    {
        public List<BEReview> GetAllReviews()
        {
            List<BEReview> items;
            //To Do change the path to none hardcoded
            /*<ItemGroup>
                <Content Include="..\..\ratings.json" />
                </ItemGroup>*/
            using (StreamReader r = new StreamReader(@"../../../../MovieCompulsory.DataJson/ratings.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<BEReview>>(json);
            }
            return items;
        }


    }
}