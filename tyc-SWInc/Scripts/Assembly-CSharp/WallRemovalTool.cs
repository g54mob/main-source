using System.Collections.Generic;
using UnityEngine;

public class WallRemovalTool : MonoBehaviour
{
	public static WallRemovalTool Instance;

	public WallEdge Edge1;

	public WallEdge Edge2;

	public float DistanceLimit;

	private Mesh mesh;

	public Material Mat;

	public MeshRenderer rend;

	private void Awake()
	{
		if (Instance != null)
		{
			Object.Destroy(Instance.gameObject);
		}
		Instance = this;
		mesh = new Mesh();
		mesh.MarkDynamic();
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void Show()
	{
		BuildController.Instance.ClearBuild();
		base.gameObject.SetActive(true);
		HUD.Instance.UpdateBorderOverlay();
	}

	private void BuildMesh()
	{
		Room room = Edge1.GetRoom(Edge2);
		Room room2 = Edge2.GetRoom(Edge1);
		WallEdge wallEdge = Edge1;
		do
		{
			WallEdge wallEdge2 = wallEdge.FindConnectionIn(room);
			if (wallEdge.Links.GetOrNull(room2) != wallEdge2)
			{
				break;
			}
			wallEdge = wallEdge2;
		}
		while (wallEdge != Edge1);
		List<Vector2> list = new List<Vector2>();
		int num = room.Edges.Count;
		do
		{
			list.Add(wallEdge.Pos);
			wallEdge = wallEdge.Links[room];
			num--;
		}
		while (num >= 0 && wallEdge.Links[room].Links.GetOrNull(room2) == wallEdge);
		list.Add(wallEdge.Pos);
		Vector3[] array = new Vector3[list.Count * 2];
		Vector2[] uv = new Vector2[list.Count * 2];
		int[] array2 = new int[(list.Count - 1) * 12];
		for (int i = 0; i < list.Count; i++)
		{
			array[i * 2] = new Vector3(list[i].x, room.Floor * 2, list[i].y);
			array[i * 2 + 1] = new Vector3(list[i].x, room.Floor * 2 + (room.Outdoors ? 1 : 2), list[i].y);
		}
		for (int j = 0; j < list.Count - 1; j++)
		{
			array2[j * 12] = j * 2;
			array2[j * 12 + 1] = j * 2 + 1;
			array2[j * 12 + 2] = j * 2 + 3;
			array2[j * 12 + 3] = j * 2 + 3;
			array2[j * 12 + 4] = j * 2 + 2;
			array2[j * 12 + 5] = j * 2;
			array2[j * 12 + 6] = j * 2;
			array2[j * 12 + 7] = j * 2 + 2;
			array2[j * 12 + 8] = j * 2 + 3;
			array2[j * 12 + 9] = j * 2 + 3;
			array2[j * 12 + 10] = j * 2 + 1;
			array2[j * 12 + 11] = j * 2;
		}
		mesh.triangles = new int[0];
		mesh.vertices = array;
		mesh.uv = uv;
		mesh.triangles = array2;
		int num2 = list.Count / 2 - 1;
		Vector2 v = (list[num2] + list[num2 + 1]) * 0.5f;
		Vector3 vector = (list[num2] - list[num2 + 1]).ToVector3(0f);
		base.transform.SetPositionAndRotation(v.ToVector3((float)GameSettings.Instance.ActiveFloor * 2f + 2.1f), Quaternion.LookRotation(-vector, Vector3.up));
	}

	private void OnDisable()
	{
		if (HUD.Instance != null)
		{
			HUD.Instance.UpdateBorderOverlay();
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (!CameraScript.WasDragging && Input.GetMouseButtonUp(1))
		{
			base.gameObject.SetActive(false);
		}
		Vector2 mouseProj = HUD.Instance.GetMouseProj(1f);
		if (Edge1 == null)
		{
			if (GUICheck.OverGUI)
			{
				return;
			}
			{
				foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(GameSettings.Instance.ActiveFloor))
				{
					if (item.Links.Count <= 1)
					{
						continue;
					}
					foreach (KeyValuePair<IRoom, WallEdge> link in item.Links)
					{
						Room room = (Room)link.Key;
						foreach (KeyValuePair<IRoom, WallEdge> link2 in link.Value.Links)
						{
							Room room2 = (Room)link2.Key;
							Vector2 res;
							if (link2.Key.Outdoors == link.Key.Outdoors && room2.Pillar == room.Pillar && link2.Value == item && Utilities.ProjectToLine(mouseProj, item.Pos, link.Value.Pos, out res) && (res - mouseProj).magnitude <= DistanceLimit && room.CanMerge(room2))
							{
								if (!room.TryFixEdges() || !room2.TryFixEdges())
								{
									Edge1 = null;
									Edge2 = null;
									return;
								}
								Edge1 = item;
								Edge2 = link.Value;
								BuildMesh();
								rend.enabled = true;
								UISoundFX.PlaySFX("HighlightTick", true);
								break;
							}
						}
						if (Edge1 != null)
						{
							break;
						}
					}
					if (Edge1 != null)
					{
						break;
					}
				}
				return;
			}
		}
		Vector2 res2;
		if (!Utilities.ProjectToLine(mouseProj, Edge1.Pos, Edge2.Pos, out res2) || (res2 - mouseProj).magnitude > DistanceLimit)
		{
			Edge1 = null;
			rend.enabled = false;
		}
		if (Edge1 == null)
		{
			return;
		}
		Room room3 = Edge1.GetRoom(Edge2);
		if (room3 == null)
		{
			Edge1 = null;
			rend.enabled = false;
			return;
		}
		if (!room3.IsInside(mouseProj))
		{
			Room room4 = Edge2.GetRoom(Edge1);
			if (room4 != null && room4.CanMerge(room3))
			{
				WallEdge edge = Edge1;
				Edge1 = Edge2;
				Edge2 = edge;
				base.transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
				UISoundFX.PlaySFX("Tick", true);
			}
		}
		Graphics.DrawMesh(mesh, Vector3.zero, Quaternion.identity, Mat, 0, CameraScript.Instance.mainCam);
		if (Input.GetMouseButtonDown(0))
		{
			UISoundFX.PlaySFX("PlaceWallRev", true);
			Room room5 = Edge1.GetRoom(Edge2);
			Room room6 = Edge2.GetRoom(Edge1);
			List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
			List<Vector2> split = room5.MergeWith(room6, room6.PrepareSplit(true, room5.PrepareSplit(true)), list);
			list.Add(new UndoObject.UndoAction(room5, room6, split));
			list.Reverse();
			GameSettings.Instance.AddUndo(list.ToArray());
			Edge1 = null;
			Edge2 = null;
			rend.enabled = false;
		}
	}
}
