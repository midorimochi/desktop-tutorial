// Version 2.3.3
// �2013 Reindeer Games
// All rights reserved
// Redistribution of source code without permission not allowed

using PrimitivesPro.Editor;
using PrimitivesPro.Primitives;
using UnityEditor;
using UnityEngine;

public class CreatePrimitive : Editor
{
    private Vector3 top;
    private Vector3 bottom;
    private Vector3 width0, width1;
    private Vector3 length0, length1;

    private const float handleSize = 0.06f;

    protected virtual bool ShowHeightHandles()
    {
        return true;
    }

    protected virtual bool ShowWidthHandles()
    {
        return true;
    }

    protected virtual bool ShowLengthHandles()
    {
        return true;
    }

    public bool IsValid()
    {
        if (Selection.activeGameObject)
        {
            var obj = Selection.activeGameObject.GetComponent<PrimitivesPro.GameObjects.BaseObject>();

            if (obj)
            {
                GUI.enabled = !obj.IsMeshEditing();

                return true;
            }
        }

        return false;
    }

    protected virtual void OnSceneGUI()
    {
        var obj = Selection.activeGameObject;

        if (obj)
        {
            var primitive = obj.GetComponent<PrimitivesPro.GameObjects.BaseObject>();

            if ((primitive && !primitive.showSceneHandles) || (primitive && primitive.IsMeshEditing()))
            {
                return;
            }

            // get mesh
            var meshFilter = obj.GetComponent<MeshFilter>();

            if (meshFilter && meshFilter.sharedMesh)
            {
                var bound = meshFilter.sharedMesh.bounds;

                var showHeight = ShowHeightHandles();

                if (showHeight)
                {
                    top = bound.center + Vector3.up * bound.size.y / 2;
                    bottom = bound.center - Vector3.up * bound.size.y / 2;

                    top = obj.transform.TransformPoint(top);
                    bottom = obj.transform.TransformPoint(bottom);

                    Handles.color = Color.green;

                    var fmh_85_25_638344451121967538 = Quaternion.identity; var t0 = Handles.FreeMoveHandle(top,
                        HandleUtility.GetHandleSize(obj.transform.position) * handleSize,
                        Vector3.zero,
                        Handles.DotHandleCap);

                    var fmh_91_33_638344451121991541 = Quaternion.identity; var b0 = Handles.FreeMoveHandle(bottom,
                                HandleUtility.GetHandleSize(obj.transform.position) * handleSize,
                                Vector3.zero,
                                Handles.DotHandleCap);

                    showHeight = Mathf.Abs((t0 - top).sqrMagnitude) > Mathf.Epsilon ||
                                 Mathf.Abs((b0 - bottom).sqrMagnitude) > Mathf.Epsilon;

                    top = t0;
                    bottom = b0;
                }

                var showWidth = ShowWidthHandles();

                if (showWidth)
                {
                    width0 = bound.center + new Vector3(1, 0, 0) * bound.size.x / 2;
                    width1 = bound.center - new Vector3(1, 0, 0) * bound.size.x / 2;

                    width0 = obj.transform.TransformPoint(width0);
                    width1 = obj.transform.TransformPoint(width1);

                    Handles.color = Color.green;

                    Vector3 w0 = width0;
                    Vector3 w1 = width1;

                    if (ShowLengthHandles())
                    {
                        var fmh_121_29_638344451121995982 = Quaternion.identity; w0 = Handles.FreeMoveHandle(width0,
                            HandleUtility.GetHandleSize(obj.transform.position) * handleSize,
                            Vector3.zero,
                            Handles.DotHandleCap);

                        var fmh_127_37_638344451121999456 = Quaternion.identity; w1 = Handles.FreeMoveHandle(width1,
                                    HandleUtility.GetHandleSize(obj.transform.position) * handleSize,
                                    Vector3.zero,
                                    Handles.DotHandleCap);
                    }

                    length0 = bound.center + new Vector3(0, 0, 1) * bound.size.z / 2;
                    length1 = bound.center - new Vector3(0, 0, 1) * bound.size.z / 2;

                    length0 = obj.transform.TransformPoint(length0);
                    length1 = obj.transform.TransformPoint(length1);

                    Handles.color = Color.green;

                    Vector3 l0 = length0;
                    Vector3 l1 = length1;

                    {
                        var fmh_146_29_638344451122003165 = Quaternion.identity; l0 = Handles.FreeMoveHandle(length0,
                            HandleUtility.GetHandleSize(obj.transform.position) * handleSize,
                            Vector3.zero,
                            Handles.DotHandleCap);

                        var fmh_152_37_638344451122006498 = Quaternion.identity; l1 = Handles.FreeMoveHandle(length1,
                                    HandleUtility.GetHandleSize(obj.transform.position) * handleSize,
                                    Vector3.zero,
                                    Handles.DotHandleCap);
                    }

                    showWidth = Mathf.Abs((w0 - width0).sqrMagnitude) > Mathf.Epsilon ||
                                Mathf.Abs((w1 - width1).sqrMagnitude) > Mathf.Epsilon ||
                                Mathf.Abs((l0 - length0).sqrMagnitude) > Mathf.Epsilon ||
                                Mathf.Abs((l1 - length1).sqrMagnitude) > Mathf.Epsilon;

                    width0 = w0;
                    width1 = w1;
                    length0 = l0;
                    length1 = l1;
                }

                if (primitive)
                {
                    if (showHeight)
                    {
                        primitive.SetHeight((top - bottom).magnitude);
                    }

                    if (showWidth)
                    {
                        primitive.SetWidth((width0 - width1).magnitude, (length0 - length1).magnitude);
                    }

                    if (showHeight || showWidth)
                    {
                        primitive.GenerateGeometry();
                    }
                }
            }
        }
    }
}
