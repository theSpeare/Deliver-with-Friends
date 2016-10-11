using UnityEngine;
using System.Collections;
using System;

public class Building : MonoBehaviour {

    public enum Type
    {
        house, commercial
    };

    public Type type;
    public int sizeX, sizeY; // size of building in tiles

    private void Awake()
    {
        createBuilding(8, 8);
    }

    public void createBuilding (int _sizeX, int _sizeY)
    {
        sizeX = _sizeX;
        sizeY = _sizeY;
    }

    public void createBuilding (Type type)
    {
        switch (type)
        {
            case (Type.house):
                sizeX = 1;
                sizeY = 2;
                return;




        }




    }
}