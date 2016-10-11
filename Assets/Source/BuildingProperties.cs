using UnityEngine;
using System.Collections;

public static class BuildingProperties {

	public class House
    {
        public const int sizeX = 4;
        public const int sizeY = 4;
    }

    public class House1
    {
        public const int sizeX = 6;
        public const int sizeY = 6;
    }

    public class Commercial
    {
        public const int sizeX = 10;
        public const int sizeY = 10;
    }
}

public class Main
{
    public void program()
    {
        int sizeX = BuildingProperties.House.sizeX;
    }
}