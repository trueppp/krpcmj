﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuMech;
using KRPC;
using KRPC.Service.Attributes;
using KRPC.Service;

namespace krpcmj
{

    public static partial class krpcmj
    {
        /// <summary>
        /// Commands an immediate 'Land Anywhere' landing   
        /// </summary>
        [KRPCProcedure]
        public static void LandNow()
        {
            MechJebCore activejeb = GetJeb();
            if (activejeb != null)
            {
                MechJebModuleLandingAutopilot activelnd = activejeb.GetComputerModule("MechJebModuleLandingAutopilot") as MechJebModuleLandingAutopilot;
                if (activelnd != null)
                {
                    activelnd.LandUntargeted(activejeb);
                }
            }
        }
        /// <summary>
        /// Commands a landing as close as possible to target   
        /// </summary>
        [KRPCProcedure]
        public static void LandTarget()
        {
            MechJebCore activejeb = GetJeb();
            if (activejeb != null)
            {
                MechJebModuleLandingAutopilot activelnd = activejeb.GetComputerModule("MechJebModuleLandingAutopilot") as MechJebModuleLandingAutopilot;
                if (activelnd != null)
                {
                    activelnd.LandAtPositionTarget(activejeb);
                }
            }
        }
        /// <summary>
        /// Toggles the Landing AP on and off  
        /// </summary>
        [KRPCProperty]
        public static bool LandAP
        {
            get
            {
                MechJebCore activejeb = GetJeb();
                if (activejeb != null)
                {
                    MechJebModuleLandingAutopilot activelnd = activejeb.GetComputerModule("MechJebModuleLandingAutopilot") as MechJebModuleLandingAutopilot;
                    if (activelnd != null)
                    {
                        return activelnd.enabled;
                    }
                }return false;
            }
            set
            {
                MechJebCore activejeb = GetJeb();
                if (activejeb != null)
                {
                    MechJebModuleLandingAutopilot activelnd = activejeb.GetComputerModule("MechJebModuleLandingAutopilot") as MechJebModuleLandingAutopilot;
                    if (activelnd != null)
                    {
                        activelnd.enabled = value;
                    }
                }
            }

           
        }
        /// <summary>
        /// Toggle's Landing AP's ability to deploy gear   
        /// </summary>
        [KRPCProperty]
        public static bool LandGear
        {
            get
            {
                MechJebCore activejeb = GetJeb();
                if (activejeb != null)
                {
                    MechJebModuleLandingAutopilot activelnd = activejeb.GetComputerModule("MechJebModuleLandingAutopilot") as MechJebModuleLandingAutopilot;
                    if (activelnd != null)
                    {
                        return activelnd.deployGears;
                    }
                }
                return false;
            }
            set
            {
                MechJebCore activejeb = GetJeb();
                if (activejeb != null)
                {
                    MechJebModuleLandingAutopilot activelnd = activejeb.GetComputerModule("MechJebModuleLandingAutopilot") as MechJebModuleLandingAutopilot;
                    if (activelnd != null)
                    {
                        activelnd.deployGears = value;
                    }
                }
            }


        }
        /// <summary>
        /// Toggles Landing AP's ability to deploy parachutes   
        /// </summary>
        [KRPCProperty]
        public static bool LandChutes
        {
            get
            {
                MechJebCore activejeb = GetJeb();
                if (activejeb != null)
                {
                    MechJebModuleLandingAutopilot activelnd = activejeb.GetComputerModule("MechJebModuleLandingAutopilot") as MechJebModuleLandingAutopilot;
                    if (activelnd != null)
                    {
                        return activelnd.deployChutes;
                    }
                }
                return false;
            }
            set
            {
                MechJebCore activejeb = GetJeb();
                if (activejeb != null)
                {
                    MechJebModuleLandingAutopilot activelnd = activejeb.GetComputerModule("MechJebModuleLandingAutopilot") as MechJebModuleLandingAutopilot;
                    if (activelnd != null)
                    {
                        activelnd.deployChutes = value;
                    }
                }
            }


        }
        /// <summary>
        /// Estimates time to Landing   
        /// </summary>
        [KRPCProperty]
        public static double LandUT
        {
            get
            {
                MechJebCore activejeb = GetJeb();
                if (activejeb != null)
                {
                    MechJebModuleLandingAutopilot activelnd = activejeb.GetComputerModule("MechJebModuleLandingAutopilot") as MechJebModuleLandingAutopilot;
                    if (activelnd != null)
                    {
                        return activelnd.prediction.endUT;
                    }
                }
                return 0.0;
            }
        }
        /// <summary>
        /// Displays map view with selection cursor for selecting landing target   
        /// </summary>
        [KRPCProcedure]
        public static void LandPickTarget()
        {
            MechJebCore activejeb = GetJeb();
            if (activejeb != null)
            {
                activejeb.target.PickPositionTargetOnMap();
            }
        }
        /// <summary>
        /// SetsLanding Target by lattitude and longitude   
        /// </summary>
        [KRPCProcedure]
        public static void LandSetTarget(double lat, double lon)
        {
            MechJebCore activejeb = GetJeb();
            if (activejeb != null)
            {
                activejeb.target.SetPositionTarget(activejeb.vessel.mainBody, lat, lon);
            }
        }
        /// <summary>
        /// Returns Landing Target Lattitude   
        /// </summary>
        [KRPCProperty]
        public static double LandTargetLat
        {
            get
            {
                MechJebCore activejeb = GetJeb();
                if (activejeb != null)
                {
                    if (activejeb.target.PositionTargetExists)
                    {
                        return activejeb.target.targetLatitude;
                    }
                }
                return 0.0;
            }
        }
        /// <summary>
        /// Returns Landing Target Longitude   
        /// </summary>
        [KRPCProperty]
        public static double LandTargetLong
        {
            get
            {
                MechJebCore activejeb = GetJeb();
                if (activejeb != null)
                {
                    if (activejeb.target.PositionTargetExists)
                    {
                        return activejeb.target.targetLongitude;
                    }
                }
                return 0.0;
            }
        }

    }

}