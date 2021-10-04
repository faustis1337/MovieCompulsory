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
                // each ../ represents going back in folders starting from net5.0 folder in the Debug
                // from net5.0 to Debug to bin to MovieCompulsory.Domain to MovieCompulsory from where we start looking path to json
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<BEReview>>(json);
            }
            return items;
        }


    }
}