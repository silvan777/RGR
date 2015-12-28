﻿using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CameraFollow cf = (CameraFollow)target;
        if (GUILayout.Button("Set Min Cam Pos"))
        {
            cf.SetMinPosition();
        }
        if (GUILayout.Button("Set Max Cam Pos"))
        {
            cf.SetMaxPosition();
        }
    }
}
