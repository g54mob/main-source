using System.Collections.Generic;
using System.Linq;
using DV;
using DV.OriginShift;
using DV.PointSet;
using MeshXtensions;
using UnityEngine;
using UnityEngine.Rendering;

public class RailwayLodGenerator : MonoBehaviour
{
	public float simplificationTolerance = 1.5f;

	public Shape profile;

	public Material mat;

	private Vector2[] profilePoints;

	[InspectorButton("Generate", true, true)]
	public bool generateLod;

	private void Start()
	{
		Generate();
	}

	public GameObject Generate()
	{
		profilePoints = profile.GetPoints2D();
		List<Mesh> list = GetRailTracks().Select(SimplifiedPoints).Select(GenerateMesh).ToList();
		List<GameObject> list2 = list.Select(MakeGameObject).ToList();
		GameObject gameObject = new GameObject("Railway LOD");
		foreach (GameObject item in list2)
		{
			item.transform.SetParent(gameObject.transform);
		}
		gameObject.transform.SetParent(OriginShift.parentContainer);
		int num = list.Sum((Mesh m) => m.vertexCount);
		int num2 = list.Sum((Mesh m) => m.triangles.Length / 3);
		Debug.Log(string.Format("{0} generated {1} meshes, total number of vertices: {2}, triangles: {3}", "RailwayLodGenerator", list.Count, num, num2));
		return gameObject;
	}

	private EquiPointSet SimplifiedPoints(RailTrack track)
	{
		EquiPointSet kinkedPointSet = track.GetKinkedPointSet();
		EquiPointSet.Point[] points = kinkedPointSet.points;
		List<int> list = new List<int>();
		LineUtility.Simplify(points.Select((EquiPointSet.Point p) => (Vector3)p.position).ToList(), simplificationTolerance, list);
		List<EquiPointSet.Point> list2 = new List<EquiPointSet.Point>();
		foreach (int item in list)
		{
			list2.Add(points[item]);
		}
		return new EquiPointSet
		{
			points = list2.ToArray(),
			span = kinkedPointSet.span
		};
	}

	private Mesh GenerateMesh(EquiPointSet pointSet)
	{
		MeshSweeperJob meshSweeperJob = new MeshSweeperJob(pointSet, 0, pointSet.points.Length - 1, Vector3.zero, profilePoints);
		meshSweeperJob.ScheduleSelf().Complete();
		Mesh mesh = new Mesh();
		meshSweeperJob.AfterComplete(mesh);
		return mesh;
	}

	private GameObject MakeGameObject(Mesh mesh)
	{
		GameObject obj = new GameObject();
		MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
		MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
		meshFilter.sharedMesh = mesh;
		meshRenderer.sharedMaterial = mat;
		meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		Vector3 vector = mesh.CenterToBounds();
		mesh.RecalculateBounds();
		obj.transform.position += vector;
		return obj;
	}

	private List<RailTrack> GetRailTracks()
	{
		return (from rt in Object.FindObjectsOfType<RailTrack>()
			where rt.generateMeshes
			select rt).ToList();
	}
}
