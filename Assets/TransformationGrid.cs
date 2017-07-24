using System;
using System.Collections.Generic;
using UnityEngine;

public class TransformationGrid : MonoBehaviour {

    public Transform prefab;
    public int gridResolution = 10;
    private Transform[] grid;
    private List<Transformation> transformations = new List<Transformation>();

    private void Awake() {
        grid = new Transform[gridResolution * gridResolution * gridResolution];
        for (int i = 0, z = 0; z < gridResolution; z++) {
            for (int y = 0; y < gridResolution; y++) {
                for (int x = 0; x < gridResolution; x++, i++) {
                    grid[i] = CreateGridPoint(x, y, z);
                }
            }
        }
    }

    private void Update() {
        GetComponents(transformations);
        for (int i = 0, z = 0; z < gridResolution; z++) {
            for (int y = 0; y < gridResolution; y++) {
                for (int x = 0; x < gridResolution; x++, i++) {
                    grid[i].localPosition = TransformPoint(x, y, z);
                }
            }
        }
    }

    private Vector3 TransformPoint(int x, int y, int z) {
        var coordinates = GetCoordinates(x, y, z);
        foreach(var transformation in transformations) {
            coordinates = transformation.Apply(coordinates);
        }

        return coordinates;
    }

    private Transform CreateGridPoint(int x, int y, int z) {
        var point = Instantiate(prefab);
        point.localPosition = GetCoordinates(x, y, z);
        point.GetComponent<MeshRenderer>().material.color = new Color (
            (float) x / gridResolution,
            (float) y / gridResolution,
            (float) z / gridResolution
        );

        return point;
    }

    private Vector3 GetCoordinates(int x, int y, int z) {
        return new Vector3(
            x - .5f * (gridResolution - 1f),
            y - .5f * (gridResolution - 1f),
            z - .5f * (gridResolution - 1f)
            );
    }
}
