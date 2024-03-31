using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;
using PrimitivesPro;

public class PrimitivesProTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestTriangle()
    {
        var obj = PrimitivesPro.GameObjects.Triangle.Create(1f, 0);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(4, 4);
    }
    
    [Test]
    public void TestCircle()
    {
        var obj = PrimitivesPro.GameObjects.Circle.Create(1f, 3);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(4, 4);
    }

    [Test]
    public void TestEllipse()
    {
        var obj = PrimitivesPro.GameObjects.Ellipse.Create(1f, 0.5f, 3);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(2, 1, 8);
    }

    [Test]
    public void TestRing()
    {
        var obj = PrimitivesPro.GameObjects.Ring.Create(0.5f, 1.0f, 3);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(1, 2, 40);
    }

    [Test]
    public void TestBox()
    {
        var obj = PrimitivesPro.GameObjects.Box.Create(1f, 1f, 1f, 1, 1, 1, false, null, PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(2.5f, 2.5f, 2.5f, 1, 1, 1, false, null, PrimitivesPro.Primitives.PivotPosition.Center);
    }

    [Test]
    public void TestCylinder()
    {
        var obj = PrimitivesPro.GameObjects.Cylinder.Create(1f, 3, 3, 1, PrimitivesPro.Primitives.NormalsType.Face,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(1.25f, 4f, 40, 1, PrimitivesPro.Primitives.NormalsType.Face,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
    }

    [Test]
    public void TestCone()
    {
        var obj = PrimitivesPro.GameObjects.Cone.Create(1, 0, 0, 2, 3, 10, PrimitivesPro.Primitives.NormalsType.Face,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(1.25f, 0, 4f, 40, 10, 0, PrimitivesPro.Primitives.NormalsType.Vertex, PrimitivesPro.Primitives.PivotPosition.Center);
    }

    [Test]
    public void TestSphere()
    {
        var obj = PrimitivesPro.GameObjects.Sphere.Create(1f, 4, 0, 0, 0, PrimitivesPro.Primitives.NormalsType.Face,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(2.25f, 40, 0, 0, 0, PrimitivesPro.Primitives.NormalsType.Vertex, PrimitivesPro.Primitives.PivotPosition.Center);
    }

    [Test]
    public void TestEllipsoid()
    {
        var obj = PrimitivesPro.GameObjects.Ellipsoid.Create(1, 1, 1, 4, PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(1.25f, 2.45f, 2.5f, 40, PrimitivesPro.Primitives.NormalsType.Vertex, PrimitivesPro.Primitives.PivotPosition.Center);
    }

    [Test]
    public void TestPyramid()
    {
        var obj = PrimitivesPro.GameObjects.Pyramid.Create(1, 1, 1, 1, 1, 1, false, PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(2.7f, 2.7f, 1.7f, 1, 1, 1, false, PrimitivesPro.Primitives.PivotPosition.Center);
    }
    
    [Test]
    public void TestGeoSphere()
    {
        var obj = PrimitivesPro.GameObjects.GeoSphere.Create(1f, 0, PrimitivesPro.Primitives.GeoSpherePrimitive.BaseType.Icosahedron,
            PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(2.45f, 4, PrimitivesPro.Primitives.GeoSpherePrimitive.BaseType.Icositetrahedron,
            PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
    }
    
    [Test]
    public void TestTube()
    {
        var obj = PrimitivesPro.GameObjects.Tube.Create(0.8f, 1f, 1f, 3, 1, 0.0f, false, PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(0.8f, 1.5f, 4f, 40, 0, 0, false, PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
    }
    
    [Test]
    public void TestCapsule()
    {
        var obj = PrimitivesPro.GameObjects.Capsule.Create(1f, 1f, 4, 1, false, PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(1.2f, 4f, 40, 1, false, PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
    }
    
    [Test]
    public void TestRoundedCube()
    {
        var obj = PrimitivesPro.GameObjects.RoundedCube.Create(1f, 1f, 1f, 1, 0.2f,
            PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(1.6f, 1.6f, 1.6f, 20, 0.6f, PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
    }

    [Test]
    public void TestTorus()
    {
        var obj = PrimitivesPro.GameObjects.Torus.Create(1f, 0.5f, 4, 4, 0, PrimitivesPro.Primitives.NormalsType.Face,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(1.6f, 0.8f, 40, 40, 0, PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
    }

    [Test]
    public void TestTorusKnot()
    {
        var obj = PrimitivesPro.GameObjects.TorusKnot.Create(0.5f, 0.3f, 10, 4, 2, 3,
            PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(1f, 0.5f, 120, 40, 2, 3, PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
    }

    [Test]
    public void TestArc()
    {
        var obj = PrimitivesPro.GameObjects.Arc.Create(1.0f, 1.0f, 1.0f, 1.0f, 10, PrimitivesPro.Primitives.PivotPosition.Botttom);
        ((PrimitivesPro.GameObjects.Arc)obj).gizmo.gameObject.transform.localPosition = new Vector3(-1, -1, 0);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(4.0f, 3.0f, 2.0f, 1.0f, 20, PrimitivesPro.Primitives.PivotPosition.Botttom);
    }

    [Test]
    public void TestSuperEllipsoid()
    {
        var obj = PrimitivesPro.GameObjects.SuperEllipsoid.Create(1, 1, 1, 20, 0.5f, 1.0f,
            PrimitivesPro.Primitives.NormalsType.Face,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(2, 2, 2, 20, 0.5f, 1.0f, PrimitivesPro.Primitives.NormalsType.Vertex,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
    }

    [Test]
    public void TestSphericalCone()
    {
        var obj = PrimitivesPro.GameObjects.SphericalCone.Create(1, 20, 180, 
            PrimitivesPro.Primitives.NormalsType.Face,
            PrimitivesPro.Primitives.PivotPosition.Botttom);
        Assert.IsNotNull(obj);
        obj.GenerateGeometry(2, 40, 20, PrimitivesPro.Primitives.NormalsType.Vertex, PrimitivesPro.Primitives.PivotPosition.Botttom);
    }
}
