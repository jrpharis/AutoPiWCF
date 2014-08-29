using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AutoPiWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class AutoPiService : IAutoPiService
    {
        public Dictionary<int, bool> GetLights()
        {
            return new Dictionary<int, bool>();
        }

        public KeyValuePair<int, bool> GetLightById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
