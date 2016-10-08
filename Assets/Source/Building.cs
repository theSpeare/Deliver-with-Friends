﻿using UnityEngine;
using System.Collections;

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
}