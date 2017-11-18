using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaDesk_ASP_NET_Web
{
    public class Desk
    {
        public int width { get; set; }
        public int depth { get; set; }
        public int drawers { get; set; }
        public int surface { get; set; }
        public DesktopMaterial Material { get; set; }

        public enum DesktopMaterial
        {
            Pine = 50,
            Laminate = 100,
            Oak = 200,
            Rosewood = 300,
            Veneer = 150
        };

        List<DesktopMaterial> materials = Enum.GetValues(typeof(DesktopMaterial)).Cast<DesktopMaterial>().ToList();

        public string GetSurfaceArea(int width, int depth)
        {
            int surface = depth * width;
            return surface.ToString();
        }
        
    }
}