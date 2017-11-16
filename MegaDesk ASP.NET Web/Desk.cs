using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaDesk_ASP_NET_Web
{
    public class Desk
    {
        public int Width { get; set; }
        public int Depth { get; set; }
        public int NumDrawers { get; set; }
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
        

        public int GetSurfaceArea()
        {
            int area;
            area = Width * Depth;
            return area;
        }
    }
}