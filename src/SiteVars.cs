//  Authors:  Robert M. Scheller, James B. Domingo

using Landis.Library.UniversalCohorts;
using Landis.SpatialModeling;

namespace Landis.Extension.Output.Biomass
{
    /// <summary>
    /// The pools of dead biomass for the landscape's sites.
    /// </summary>
    public static class SiteVars
    {
        private static ISiteVar<Pool> woodyDebris;
        private static ISiteVar<Pool> litter;
        private static ISiteVar<SiteCohorts> cohorts;


        //---------------------------------------------------------------------

        /// <summary>
        /// Initializes the module.
        /// </summary>
        public static void Initialize()
        {

            woodyDebris = PlugIn.ModelCore.GetSiteVar<Pool>("Succession.WoodyDebris");
            litter = PlugIn.ModelCore.GetSiteVar<Pool>("Succession.Litter");

            cohorts = PlugIn.ModelCore.GetSiteVar<SiteCohorts>("Succession.UniversalCohorts");

            if (cohorts == null)
            {
                string mesg = string.Format("Cohorts are empty.  Please double-check that this extension is compatible with your chosen succession extension.");
                throw new System.ApplicationException(mesg);
            }
        }

        //---------------------------------------------------------------------
        public static ISiteVar<SiteCohorts> Cohorts
        {
            get
            {
                return cohorts;
            }
        }
        //---------------------------------------------------------------------

        /// <summary>
        /// The intact dead woody pools for the landscape's sites.
        /// </summary>
        public static ISiteVar<Pool> WoodyDebris
        {
            get {
                return woodyDebris;
            }
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// The dead non-woody pools for the landscape's sites.
        /// </summary>
        public static ISiteVar<Pool> Litter
        {
            get {
                return litter;
            }
        }

    }
}
