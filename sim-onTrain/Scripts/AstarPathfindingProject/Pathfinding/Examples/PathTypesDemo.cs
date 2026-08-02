using System.Collections;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pathfinding.Examples
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_path_types_demo.php")]
	public class PathTypesDemo : MonoBehaviour
	{
		public enum DemoMode
		{
			ABPath = 0,
			MultiTargetPath = 1,
			RandomPath = 2,
			FleePath = 3,
			ConstantPath = 4,
			FloodPath = 5,
			FloodPathTracer = 6
		}

		public DemoMode activeDemo;

		public Transform start;

		public Transform end;

		public Vector3 pathOffset;

		public Material lineMat;

		public Material squareMat;

		public float lineWidth;

		public int searchLength = 1000;

		public int spread = 100;

		public float aimStrength;

		public bool onlyShortestPath;

		private GameObject constantPathMeshGo;

		private Path lastPath;

		private FloodPath lastFloodPath;

		private List<GameObject> lastRender = new List<GameObject>();

		private List<Vector3> multipoints = new List<Vector3>();

		private void Update()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 vector = ray.origin + ray.direction * (ray.origin.y / (0f - ray.direction.y));
			end.position = vector;
			if (Input.GetMouseButtonUp(0))
			{
				if (Input.GetKey(KeyCode.LeftShift))
				{
					multipoints.Add(vector);
				}
				if (Input.GetKey(KeyCode.LeftControl))
				{
					multipoints.Clear();
				}
			}
			if (Input.GetMouseButton(0) && Input.mousePosition.x > 225f && (lastPath == null || lastPath.IsDone()))
			{
				DemoPath();
			}
		}

		public void OnGUI()
		{
			GUILayout.BeginArea(new Rect(5f, 5f, 220f, Screen.height - 10), "", "Box");
			switch (activeDemo)
			{
			case DemoMode.ABPath:
				GUILayout.Label("Basic path. Finds a path from point A to point B.");
				break;
			case DemoMode.MultiTargetPath:
				GUILayout.Label("Multi Target Path. Finds a path quickly from one point to many others in a single search.");
				break;
			case DemoMode.RandomPath:
				GUILayout.Label("Randomized Path. Finds a path with a specified length in a random direction or biased towards some point when using a larger aim strenggth.");
				break;
			case DemoMode.FleePath:
				GUILayout.Label("Flee Path. Tries to flee from a specified point. Remember to set Flee Strength!");
				break;
			case DemoMode.ConstantPath:
				GUILayout.Label("Finds all nodes which it costs less than some value to reach.");
				break;
			case DemoMode.FloodPath:
				GUILayout.Label("Searches the whole graph from a specific point. FloodPathTracer can then be used to quickly find a path to that point");
				break;
			case DemoMode.FloodPathTracer:
				GUILayout.Label("Traces a path to where the FloodPath started. Compare the calculation times for this path with ABPath!\nGreat for TD games");
				break;
			}
			GUILayout.Space(5f);
			GUILayout.Label("Note that the paths are rendered without ANY post-processing applied, so they might look a bit jagged");
			GUILayout.Space(5f);
			GUILayout.Label("Click anywhere to recalculate the path. Hold to continuously recalculate the path.");
			if (activeDemo == DemoMode.ConstantPath || activeDemo == DemoMode.RandomPath || activeDemo == DemoMode.FleePath)
			{
				GUILayout.Label("Search Distance (" + searchLength + ")");
				searchLength = Mathf.RoundToInt(GUILayout.HorizontalSlider(searchLength, 0f, 100000f));
			}
			if (activeDemo == DemoMode.RandomPath || activeDemo == DemoMode.FleePath)
			{
				GUILayout.Label("Spread (" + spread + ")");
				spread = Mathf.RoundToInt(GUILayout.HorizontalSlider(spread, 0f, 40000f));
				GUILayout.Label(((activeDemo == DemoMode.RandomPath) ? "Aim strength" : "Flee strength") + " (" + aimStrength + ")");
				aimStrength = GUILayout.HorizontalSlider(aimStrength, 0f, 1f);
			}
			if (activeDemo == DemoMode.MultiTargetPath)
			{
				GUILayout.Label("Hold shift and click to add new target points. Hold ctr and click to remove all target points");
				onlyShortestPath = GUILayout.Toggle(onlyShortestPath, "Only Shortest Path");
			}
			if (GUILayout.Button("A to B path"))
			{
				activeDemo = DemoMode.ABPath;
			}
			if (GUILayout.Button("Multi Target Path"))
			{
				activeDemo = DemoMode.MultiTargetPath;
			}
			if (GUILayout.Button("Random Path"))
			{
				activeDemo = DemoMode.RandomPath;
			}
			if (GUILayout.Button("Flee path"))
			{
				activeDemo = DemoMode.FleePath;
			}
			if (GUILayout.Button("Constant Path"))
			{
				activeDemo = DemoMode.ConstantPath;
			}
			if (GUILayout.Button("Flood Path"))
			{
				activeDemo = DemoMode.FloodPath;
			}
			if (GUILayout.Button("Flood Path Tracer"))
			{
				activeDemo = DemoMode.FloodPathTracer;
			}
			GUILayout.EndArea();
		}

		public void OnPathComplete(Path p)
		{
			if (lastRender == null)
			{
				return;
			}
			ClearPrevious();
			if (!p.error)
			{
				GameObject gameObject = new GameObject("LineRenderer", typeof(LineRenderer));
				LineRenderer component = gameObject.GetComponent<LineRenderer>();
				component.sharedMaterial = lineMat;
				component.startWidth = lineWidth;
				component.endWidth = lineWidth;
				component.positionCount = p.vectorPath.Count;
				for (int i = 0; i < p.vectorPath.Count; i++)
				{
					component.SetPosition(i, p.vectorPath[i] + pathOffset);
				}
				lastRender.Add(gameObject);
			}
		}

		private void ClearPrevious()
		{
			for (int i = 0; i < lastRender.Count; i++)
			{
				Object.Destroy(lastRender[i]);
			}
			if (constantPathMeshGo != null)
			{
				constantPathMeshGo.SetActive(value: false);
			}
			lastRender.Clear();
		}

		private void OnDestroy()
		{
			ClearPrevious();
			lastRender = null;
		}

		private void DemoPath()
		{
			Path path = null;
			switch (activeDemo)
			{
			case DemoMode.ABPath:
				path = ABPath.Construct(start.position, end.position, OnPathComplete);
				break;
			case DemoMode.MultiTargetPath:
				StartCoroutine(DemoMultiTargetPath());
				break;
			case DemoMode.ConstantPath:
				StartCoroutine(DemoConstantPath());
				break;
			case DemoMode.RandomPath:
			{
				RandomPath randomPath = RandomPath.Construct(start.position, searchLength, OnPathComplete);
				randomPath.spread = spread;
				randomPath.aimStrength = aimStrength;
				randomPath.aim = end.position;
				path = randomPath;
				break;
			}
			case DemoMode.FleePath:
			{
				FleePath fleePath = FleePath.Construct(start.position, end.position, searchLength, OnPathComplete);
				fleePath.aimStrength = aimStrength;
				fleePath.spread = spread;
				path = fleePath;
				break;
			}
			case DemoMode.FloodPath:
				path = (lastFloodPath = FloodPath.Construct(end.position));
				break;
			case DemoMode.FloodPathTracer:
				if (lastFloodPath != null)
				{
					path = FloodPathTracer.Construct(end.position, lastFloodPath, OnPathComplete);
				}
				break;
			}
			if (path != null)
			{
				AstarPath.StartPath(path);
				lastPath = path;
			}
		}

		private IEnumerator DemoMultiTargetPath()
		{
			MultiTargetPath mp = MultiTargetPath.Construct(multipoints.ToArray(), end.position, null);
			mp.pathsForAll = !onlyShortestPath;
			lastPath = mp;
			AstarPath.StartPath(mp);
			yield return StartCoroutine(mp.WaitForPath());
			List<GameObject> list = new List<GameObject>(lastRender);
			lastRender.Clear();
			for (int i = 0; i < mp.vectorPaths.Length; i++)
			{
				if (mp.vectorPaths[i] != null)
				{
					List<Vector3> list2 = mp.vectorPaths[i];
					GameObject gameObject;
					if (list.Count > i && list[i].GetComponent<LineRenderer>() != null)
					{
						gameObject = list[i];
						list.RemoveAt(i);
					}
					else
					{
						gameObject = new GameObject("LineRenderer_" + i, typeof(LineRenderer));
					}
					LineRenderer component = gameObject.GetComponent<LineRenderer>();
					component.sharedMaterial = lineMat;
					component.startWidth = lineWidth;
					component.endWidth = lineWidth;
					component.positionCount = list2.Count;
					for (int j = 0; j < list2.Count; j++)
					{
						component.SetPosition(j, list2[j] + pathOffset);
					}
					lastRender.Add(gameObject);
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				Object.Destroy(list[k]);
			}
		}

		public IEnumerator DemoConstantPath()
		{
			ConstantPath constPath = ConstantPath.Construct(end.position, searchLength);
			constPath.Claim(this);
			AstarPath.StartPath(constPath);
			lastPath = constPath;
			yield return StartCoroutine(constPath.WaitForPath());
			ClearPrevious();
			if (constantPathMeshGo == null)
			{
				constantPathMeshGo = new GameObject("Mesh", typeof(MeshRenderer), typeof(MeshFilter));
				constantPathMeshGo.GetComponent<MeshRenderer>().material = squareMat;
			}
			constantPathMeshGo.SetActive(value: true);
			MeshFilter component = constantPathMeshGo.GetComponent<MeshFilter>();
			Mesh mesh3;
			if (component.sharedMesh == null)
			{
				Mesh mesh = (component.sharedMesh = new Mesh());
				mesh3 = mesh;
				mesh3.indexFormat = IndexFormat.UInt32;
				mesh3.MarkDynamic();
			}
			else
			{
				mesh3 = component.sharedMesh;
			}
			mesh3.Clear();
			List<GraphNode> allNodes = constPath.allNodes;
			int num = allNodes.Count * 4;
			Vector3[] array = ArrayPool<Vector3>.Claim(num);
			for (int i = 0; i < allNodes.Count; i++)
			{
				Vector3 vector = (Vector3)allNodes[i].position + pathOffset;
				GridGraph gridGraph = AstarData.GetGraph(allNodes[i]) as GridGraph;
				float num2 = 1f;
				if (gridGraph != null)
				{
					num2 = gridGraph.nodeSize;
				}
				array[i * 4] = vector + new Vector3(-0.5f, 0f, -0.5f) * num2;
				array[i * 4 + 1] = vector + new Vector3(0.5f, 0f, -0.5f) * num2;
				array[i * 4 + 2] = vector + new Vector3(-0.5f, 0f, 0.5f) * num2;
				array[i * 4 + 3] = vector + new Vector3(0.5f, 0f, 0.5f) * num2;
			}
			int num3 = 3 * num / 2;
			int[] array2 = ArrayPool<int>.Claim(num3);
			int j = 0;
			int num4 = 0;
			for (; j < num; j += 4)
			{
				array2[num4] = j;
				array2[num4 + 1] = j + 1;
				array2[num4 + 2] = j + 2;
				array2[num4 + 3] = j + 1;
				array2[num4 + 4] = j + 3;
				array2[num4 + 5] = j + 2;
				num4 += 6;
			}
			Vector2[] array3 = ArrayPool<Vector2>.Claim(num);
			for (int k = 0; k < num; k += 4)
			{
				array3[k] = new Vector2(0f, 0f);
				array3[k + 1] = new Vector2(1f, 0f);
				array3[k + 2] = new Vector2(0f, 1f);
				array3[k + 3] = new Vector2(1f, 1f);
			}
			mesh3.SetVertices(array, 0, num);
			mesh3.SetTriangles(array2, 0, num3, 0);
			mesh3.SetUVs(0, array3, 0, num);
			mesh3.RecalculateNormals();
			constPath.Release(this);
			ArrayPool<int>.Release(ref array2);
			ArrayPool<Vector2>.Release(ref array3);
			ArrayPool<Vector3>.Release(ref array);
		}
	}
}
