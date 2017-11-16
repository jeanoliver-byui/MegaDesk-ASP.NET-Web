using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaDesk_ASP_NET_Web
{
    public class DeskQuote
    {
        private int newWidth;
        private int newDepth;
        private int newSurfaceArea;
        private int newDrawers;
        private string newMaterial;
        private int newRushDays;

        public DateTime QuoteDate { get; set; }
        public double QuoteAmount { get; set; }

        public int BASEPRICE = 200; //The base price for any desk quote
        private int BASESIZE = 1000; // THE BASE PRICE FOR SIZE MAXIMUM
        private int DRAWERCOST = 50; //cost per drawer
        private int SURFACECOST = 1; //cost per square inch greater than BASESIZE per desk
        private int RUSH1 = 3; private int RUSH2 = 5; private int RUSH3 = 7; // Rush order days options

        public DeskQuote(int width, int depth, int drawers, string material, int rushDays)
        {
            newWidth = width;
            newDepth = depth;
            newSurfaceArea = width * depth;
            newDrawers = drawers;
            newMaterial = material;
            newRushDays = rushDays;
        }

        public double DeskQuoteCalculate()
        {
            // Update the QuoteAmount 
            QuoteAmount = BASEPRICE + drawerCost() + surfaceCost() + SurfaceMaterialCost() + RushOrderCost();
            return QuoteAmount;
        }

        public int surfaceCost()
        {
            //Determine if additional cost is warranted with desk areas greater than DESKTOP BASE SIZE
            if (newSurfaceArea > BASESIZE)
            {
                return (newSurfaceArea - BASESIZE) * SURFACECOST;
            }
            else
            {
                return 0;
            }
        }

        public int drawerCost()
        {
            return newDrawers * DRAWERCOST;
        }

        public int SurfaceMaterialCost()
        {
            //Select the material cost
            int materialCost = 0;
            switch (newMaterial)
            {
                case "laminate":
                    materialCost = 100;
                    break;
                case "oak":
                    materialCost = 200;
                    break;
                case "pine":
                    materialCost = 50;
                    break;
                default:
                    materialCost = -1;//error check
                    break;
            }
            return materialCost;
        }

        public int RushOrderCost()
        {
            //magic number used for surface area and costs
            int rushCost = 0;
            if (newRushDays <= RUSH1)
            {
                if (newSurfaceArea <= BASESIZE)
                {
                    rushCost = 60;
                }
                else if (newSurfaceArea <= 1999)
                {
                    rushCost = 70;
                }
                else
                {
                    rushCost = 80;
                }
            }
            if (newRushDays <= RUSH2)
            {
                if (newSurfaceArea <= BASESIZE)
                {
                    rushCost = 40;
                }
                else if (newSurfaceArea <= 1999)
                {
                    rushCost = 50;
                }
                else
                {
                    rushCost = 60;
                }
            }
            if (newRushDays <= RUSH3)
            {
                if (newSurfaceArea <= BASESIZE)
                {
                    rushCost = 30;
                }
                else if (newSurfaceArea <= 1999)
                {
                    rushCost = 35;
                }
                else
                {
                    rushCost = 40;
                }
            }
            return rushCost;
        }
    }
}