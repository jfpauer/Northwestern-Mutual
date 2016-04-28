using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ServiceFacadeFactory
    {
        #region Public Static Methods

        public static IWebApplication1ServiceFacade CreateWebApplication1ServiceFacade(string apiVersion)
        {
            switch (apiVersion)
            {
                // Put case statements here for other versions in future.

                default:
                    return new WebApplication1ServiceFacade();
            }
        }

        public static IWebApplication1ServiceFacade CreateWebApplication1ServiceFacade()
        {
            return new WebApplication1ServiceFacade();
        }

        #endregion
    }
}
