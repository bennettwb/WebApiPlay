using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace WebApi.Hubs
{
    public class EventConduit
    {
        public static string Process(string input)
        {
           input = 
                "{\"AssetId\":\"12847812\",\"AssetThumbnails\":[{\"Size\":170,\"URL\":\"http://fadftp.amer.gettywan.com:8080/fs1/editorialfeeds/webdirectory/prod/170Thumb/20111227/12855444.jpg\"},{\"Size\":600,\"URL\":\"http://fadftp.amer.gettywan.com:8080/fs1/editorialfeeds/webdirectory/prod/600Thumb/20111227/12855444.jpg\"}],\"BylineFeedRestrictions\":[],\"BylineName\":\"Scott Levy\",\"BylineTitle\":\"Contributor\",\"CallForImage\":false,\"CameraFilename\":null,\"CameraMakeModel\":null,\"CameraSerialNumber\":null,\"Caption\":\"NEW YORK, NY - DECEMBER 26: Goaltender Anders Nilsson #45 of the New York Islanders protects the net during warm-ups prior to the game against the New York Rangers at Madison Square Garden on December 26, 2011 in New York City. (Photo by Scott Levy/NHLI via Getty Images)\",\"CaptionWriter\":\"SC/ma\",\"City\":\"New York\",\"ClassificationIds\":[204,203,53],\"Composition\":\"\",\"Copyright\":\"2011 Madison Square Garden, L.P.\",\"Country\":\"United States\",\"CountryCode\":\"USA\",\"CreateDate\":\"2011-12-26T18:43-05:00\",\"Credit\":\"NHLI via Getty Images\",\"EditStatus\":null,\"EventGroupIds\":[],\"EventId\":468471,\"EventName\":\"New York Islanders v New York Rangers\",\"ExclusionRouting\":[],\"ExclusiveCoverage\":false,\"ExternalId\":\"507549455\",\"ExternalSystem\":\"EWSINGESTION\",\"FileId\":12427629,\"FileName\":\"12427629.jpg\",\"FixtureIdentifier\":null,\"Headline\":\"New York Islanders v New York Rangers\",\"ImageRank\":3,\"InactiveDate\":null,\"InclusionRouting\":[\"NORTH AMERICA\",\"SWEDEN\"],\"IngestionType\":1,\"IptcCategory\":\"S\",\"Keywords\":[\"2011020521\\nSports\\nathlete\\nhockey\\nNHL\"],\"MasterId\":\"134570531\",\"Meid\":119007872,\"ObjectCycle\":null,\"ObjectName\":null,\"OriginalCreateDateTime\":\"\\/Date(-62135578800000-0500)\\/\",\"OriginalFilename\":\"20112712__ZM48367.jpg\",\"OriginalTransmissionReference\":null,\"PaidAssignmentFlag\":false,\"PaidAssignmentId\":\"\",\"PblcstApvlF\":null,\"Personalities\":[\"Anders Nilsson\"],\"PulledReason\":null,\"ReadyForSale\":true,\"RuleDatas\":[{\"RuleId\":543,\"RuleType\":2}],\"SiteDestinations\":[\"Editorial\"],\"Source\":\"NHLI\",\"SpecialInstructions\":null,\"State\":\"NY\",\"SupplementalCategories\":[\"HKN\"],\"TeamsUpdate\":false,\"Url\":\"webdirectory/dev/20111227/12427629.jpg\",\"Venue\":\"Madison Square Garden\",\"VersionNumber\":1}";


            var obj = JObject.Parse(input);

            var city = (string) obj["City"];
            var state = (string) obj["State"];
            var country = (string) obj["Country"];

            using(var db = new LocationEntities())
            {
                var results = db.Cities.Where(a => a.CtyN == city);
                City c = null;

                if (results.Count() > 1)
                {
                    c = results.First(a => a.SrtOrdr == 1);
                }
                else if (results.Count() == 1)
                {
                    c = results.First();
                }

                if (c != null)
                {
                    obj["lat"] = c.Latd;
                    obj["long"] = c.Lngtd;
                }
            }

            return obj.ToString();

        }
    }
}