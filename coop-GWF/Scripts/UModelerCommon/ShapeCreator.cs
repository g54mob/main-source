using System.Collections.Generic;
using UnityEngine;
using tripolygon.UModeler;

public class ShapeCreator
{
	private static string DefaultObjectName = "UModeler Object";

	public static UModeler NewUModeler(string objectName, Material defaultMaterial)
	{
		GameObject gameObject = new GameObject(objectName);
		UModeler uModeler = gameObject.AddComponent<UModeler>();
		gameObject.AddComponent<MeshCollider>();
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();
		uModeler.hideFlags = HideFlags.DontSaveInBuild;
		uModeler.materials.Add(defaultMaterial);
		uModeler.CreateEngineResource();
		uModeler.CreateMeshFilter();
		uModeler.CreateMeshRenderer();
		return uModeler;
	}

	public static UModeler NewBox(Vector3 corner1, Vector3 corner2, Material defaultMaterial)
	{
		return NewBox(DefaultObjectName, corner1, corner2, defaultMaterial);
	}

	public static UModeler NewBox(string objectName, Vector3 corner1, Vector3 corner2, Material defaultMaterial)
	{
		return AddBox(NewUModeler(objectName, defaultMaterial), corner1, corner2);
	}

	public static UModeler AddBox(UModeler modeler, Vector3 corner1, Vector3 corner2)
	{
		if (modeler == null)
		{
			modeler = NewUModeler(DefaultObjectName, null);
		}
		if (modeler != null)
		{
			List<Vertex> list = new List<Vertex>
			{
				new Vertex(new Vector3(corner1.x, corner1.y, corner1.z)),
				new Vertex(new Vector3(corner2.x, corner1.y, corner1.z)),
				new Vertex(new Vector3(corner2.x, corner1.y, corner2.z)),
				new Vertex(new Vector3(corner1.x, corner1.y, corner2.z))
			};
			List<Vertex> list2 = new List<Vertex>
			{
				new Vertex(new Vector3(corner1.x, corner2.y, corner1.z)),
				new Vertex(new Vector3(corner2.x, corner2.y, corner1.z)),
				new Vertex(new Vector3(corner2.x, corner2.y, corner2.z)),
				new Vertex(new Vector3(corner1.x, corner2.y, corner2.z))
			};
			modeler.editableMesh.AddPolygon(CreateRectaglePolygon(list2, null, null, flip: true));
			modeler.editableMesh.AddPolygon(CreateRectaglePolygon(list));
			foreach (SimplePolygon item in CreateSidePolygons(list2, list, null, modeler.editableMesh))
			{
				if (item.plane != null && !MirrorHelper.IsOnMirrorPlane(item, modeler.editableMesh))
				{
					modeler.editableMesh.AddPolygon(item);
				}
			}
		}
		return modeler;
	}

	public static SimplePolygon CreateRectaglePolygon(List<Vertex> vertexList, SimplePolygon rootPolygon = null, PlaneEx floorPlane = null, bool flip = false)
	{
		PlaneEx planeEx = null;
		List<Vertex> list = new List<Vertex>();
		if (floorPlane != null)
		{
			planeEx = floorPlane.Clone();
			if (flip)
			{
				planeEx.Flip();
			}
		}
		if (flip)
		{
			list.Add(vertexList[0]);
			list.Add(vertexList[3]);
			list.Add(vertexList[2]);
			list.Add(vertexList[1]);
		}
		else
		{
			list.Add(vertexList[0]);
			list.Add(vertexList[1]);
			list.Add(vertexList[2]);
			list.Add(vertexList[3]);
		}
		SimplePolygon simplePolygon = new SimplePolygon(list, planeEx);
		if (simplePolygon.plane != null)
		{
			simplePolygon.AssignMatUVInfo(rootPolygon);
		}
		return simplePolygon;
	}

	public static List<SimplePolygon> CreateSidePolygons(List<Vertex> bottomVertices, List<Vertex> topVertices, SimplePolygon rootPolygon = null, EditableMesh edMesh = null)
	{
		List<SimplePolygon> list = new List<SimplePolygon>();
		for (int i = 0; i < 4; i++)
		{
			SimplePolygon simplePolygon = new SimplePolygon(new List<Vertex>
			{
				bottomVertices[i],
				bottomVertices[(i + 1) % 4],
				topVertices[(i + 1) % 4],
				topVertices[i]
			});
			if (simplePolygon.plane != null && !MirrorHelper.IsOnMirrorPlane(simplePolygon, edMesh))
			{
				list.Add(simplePolygon);
				simplePolygon.AssignMatUVInfo(rootPolygon);
			}
		}
		return list;
	}
}
