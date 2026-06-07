using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioVisualizer : MonoBehaviour
{
	[NonSerialized]
	public Room LastRoom;

	public Mesh SphereMesh;

	public Mesh ProbeMesh;

	public Material SphereMat;

	public Material ProbeMaterial;

	public float TempScale = 4f;

	public Text AudioLabel;

	public Gradient ColorGrad;

	public Texture2D AudioProbeTex;

	public Color32[] AudioProbeBacking;

	public Mesh AudioProbeMesh;

	public Material AudioProbeMat;

	public static AudioVisualizer Instance;

	public int Resolution = 1;

	public int IterateX;

	public int IterateY;

	public int MaxChunk = 4;

	private int XMIN;

	private int YMIN;

	private int XMAX;

	private int YMAX;

	private bool ForceDraw;

	public float MaxDrawTime = 0.1f;

	public bool ColumnMode;

	[NonSerialized]
	private bool _tempMesh;

	[NonSerialized]
	private GameObject _lastMesh;

	[NonSerialized]
	private List<Matrix4x4> _sphereList = new List<Matrix4x4>();

	[NonSerialized]
	private int _lastFloor = int.MinValue;

	private Vector3 _lastPos;

	public static bool NoiseDirty;

	public void ToggleAudio(bool toggle)
	{
		ColumnMode = false;
		if (base.enabled == toggle)
		{
			ForceRedraw();
		}
		else
		{
			base.enabled = toggle;
		}
	}

	public void ShowColumn()
	{
		ColumnMode = true;
		if (base.enabled)
		{
			ForceRedraw();
		}
		else
		{
			base.enabled = true;
		}
	}

	private void Awake()
	{
		Instance = this;
		AudioProbeTex = new Texture2D(256 * Resolution, 256 * Resolution, TextureFormat.ARGB32, false);
		AudioProbeTex.wrapMode = TextureWrapMode.Clamp;
		AudioProbeMat = new Material(ProbeMaterial);
		AudioProbeMat.mainTexture = AudioProbeTex;
		base.enabled = false;
	}

	private void OnDestroy()
	{
		Instance = null;
		UnityEngine.Object.Destroy(AudioProbeMat);
		UnityEngine.Object.Destroy(AudioProbeTex);
		if (_tempMesh && AudioProbeMesh != null)
		{
			UnityEngine.Object.Destroy(AudioProbeMesh);
			AudioProbeMesh = null;
		}
	}

	public void ForceRedraw()
	{
		if (LastRoom != null)
		{
			ForceDraw = true;
			IterateX = 0;
			IterateY = 0;
		}
	}

	private void ClearBacking()
	{
		for (int i = XMIN; i < XMAX; i++)
		{
			for (int j = YMIN; j < YMAX; j++)
			{
				SetPixel(i, j, new Color32(0, 0, 0, 0));
			}
		}
	}

	private void SetPixel(int x, int y, Color32 c)
	{
		x -= XMIN;
		y -= YMIN;
		int num = x + y * (XMAX - XMIN);
		if (num > -1 && num < AudioProbeBacking.Length)
		{
			AudioProbeBacking[num] = c;
		}
	}

	private void UpdateBacking()
	{
		AudioProbeTex.SetPixels32(XMIN, YMIN, XMAX - XMIN, YMAX - YMIN, AudioProbeBacking);
		AudioProbeTex.Apply();
	}

	private float TestCalc(Room r, Vector2 p)
	{
		float num = float.MaxValue;
		for (int i = 0; i < r.Edges.Count; i++)
		{
			WallEdge wallEdge = r.Edges[i];
			float magnitude = (p - wallEdge.Pos).magnitude;
			if (magnitude < num)
			{
				num = magnitude;
			}
			WallEdge wallEdge2 = r.Edges[(i + 1) % r.Edges.Count];
			Vector2 res;
			if (Utilities.ProjectToLine(p, wallEdge.Pos, wallEdge2.Pos, out res))
			{
				magnitude = (p - res).magnitude;
				if (magnitude < num)
				{
					num = magnitude;
				}
			}
		}
		return Mathf.Clamp01(num / 4f);
	}

	private void CalculateAudioProbes(Room room, bool refresh)
	{
		if (refresh)
		{
			IterateX = 0;
			IterateY = 0;
		}
		if (!(room != null))
		{
			return;
		}
		GameObject floorMesh = (room.AtriumParent ?? room).FloorMesh;
		if (floorMesh == null)
		{
			floorMesh = room.FloorMesh;
		}
		if (!(floorMesh != null) || (!refresh && (!(GameSettings.GameSpeed > 0f) || room.Occupants.Count <= 0) && !ForceDraw && !ColumnMode))
		{
			return;
		}
		int num = Mathf.FloorToInt(room.RoomBounds.xMin);
		int num2 = Mathf.CeilToInt(room.RoomBounds.xMax);
		int num3 = Mathf.FloorToInt(room.RoomBounds.yMin);
		int num4 = Mathf.CeilToInt(room.RoomBounds.yMax);
		if (refresh)
		{
			XMIN = num * Resolution - 1;
			YMIN = num3 * Resolution - 1;
			XMAX = num2 * Resolution + 1;
			YMAX = num4 * Resolution + 1;
			AudioProbeBacking = new Color32[(XMAX - XMIN) * (YMAX - YMIN)];
			ClearBacking();
			if (_lastMesh != floorMesh)
			{
				if (_tempMesh && AudioProbeMesh != null)
				{
					UnityEngine.Object.Destroy(AudioProbeMesh);
					AudioProbeMesh = null;
				}
				if (room.FloorRotation != 0f || room.FloorOffset.x != 0f || room.FloorOffset.y != 0f || room.FloorScale != 1f)
				{
					Mesh sharedMesh = floorMesh.GetComponent<MeshFilter>().sharedMesh;
					Mesh mesh = new Mesh();
					mesh.vertices = sharedMesh.vertices;
					mesh.normals = sharedMesh.normals;
					mesh.uv = sharedMesh.vertices.SelectInPlace((Vector3 x) => x.FlattenVector3());
					mesh.triangles = sharedMesh.triangles;
					AudioProbeMesh = mesh;
					_tempMesh = true;
				}
				else
				{
					AudioProbeMesh = floorMesh.GetComponent<MeshFilter>().sharedMesh;
					_tempMesh = false;
				}
				_lastMesh = floorMesh;
			}
		}
		float num5 = 0f;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		Vector2[] expanded = room.GetExpanded(-0.1f);
		int num6 = Mathf.CeilToInt((float)(num2 - num) / (float)MaxChunk);
		int num7 = Mathf.CeilToInt((float)(num4 - num3) / (float)MaxChunk);
		int iterateX = IterateX;
		int iterateY = IterateY;
		List<Furniture> list = new List<Furniture>();
		do
		{
			int num8 = IterateX * MaxChunk;
			int num9 = IterateY * MaxChunk;
			int num10 = Mathf.Min(num2, num + num8 + MaxChunk);
			int num11 = Mathf.Min(num4, num3 + num9 + MaxChunk);
			list.Clear();
			HashList<Furniture> furniture = room.GetFurniture("Cubicle");
			for (int num12 = 0; num12 < furniture.Count; num12++)
			{
				Furniture furniture2 = furniture[num12];
				if (furniture2.OriginalPosition.x > (float)(num + num8 - 2) && furniture2.OriginalPosition.x < (float)(num10 + 2) && furniture2.OriginalPosition.z > (float)(num3 + num9 - 2) && furniture2.OriginalPosition.z < (float)(num11 + 2))
				{
					list.Add(furniture2);
				}
			}
			int num13 = (num + num8) * Resolution;
			num10 *= Resolution;
			int num14 = (num3 + num9) * Resolution;
			num11 *= Resolution;
			for (int num15 = num13; num15 < num10; num15++)
			{
				for (int num16 = num14; num16 < num11; num16++)
				{
					Vector2 p = new Vector2(((float)num15 + 0.5f) / (float)Resolution, ((float)num16 + 0.5f) / (float)Resolution);
					if (Utilities.IsInside(p, expanded))
					{
						if (ColumnMode)
						{
							Furniture ignore = null;
							Vector2? extra = null;
							FurnitureBuilder currentFurnitureBuilder = BuildController.Instance.CurrentFurnitureBuilder;
							if (currentFurnitureBuilder != null)
							{
								Furniture component = currentFurnitureBuilder.FurnPrefab.GetComponent<Furniture>();
								if (component.Type.Equals("Column"))
								{
									extra = currentFurnitureBuilder.transform.position.FlattenVector3();
									if (currentFurnitureBuilder.IsProto && !currentFurnitureBuilder.CopyProto)
									{
										ignore = component;
									}
								}
							}
							SetPixel(num15, num16, ColorGrad.Evaluate(1f - room.IntegrityFromPoint(p, ignore, extra)).Alpha(0.5f));
						}
						else
						{
							SetPixel(num15, num16, ColorGrad.Evaluate(Mathf.Clamp01(Furniture.RecalculateNoise(p, false, room, null, list, true, HUD.Instance.BuildMode))).Alpha(0.5f));
						}
					}
					else
					{
						SetPixel(num15, num16, new Color32(0, 0, 0, 0));
					}
				}
			}
			IterateX++;
			if (IterateX >= num6)
			{
				IterateX = 0;
				if (IterateY >= num7)
				{
					IterateY = 0;
					ForceDraw = false;
				}
				else
				{
					IterateY++;
				}
			}
			num5 += Time.realtimeSinceStartup - realtimeSinceStartup;
			realtimeSinceStartup = Time.realtimeSinceStartup;
		}
		while (num5 < MaxDrawTime && (iterateX != IterateX || iterateY != IterateY));
		UpdateBacking();
	}

	private void DrawProbes()
	{
		if (LastRoom != null && !GameSettings.Instance.IsReferenceNull())
		{
			Graphics.DrawMesh(AudioProbeMesh, Vector3.up * ((float)GameSettings.Instance.ActiveFloor * 2f + 0.1f), Quaternion.identity, AudioProbeMat, 0);
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		Camera mainCam = CameraScript.Instance.mainCam;
		if (GameSettings.Instance.ActiveFloor != _lastFloor || NoiseDirty || (_lastPos - mainCam.transform.position).sqrMagnitude > 0.1f || GameSettings.GameSpeed > 0f)
		{
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCam);
			_sphereList.Clear();
			List<Room> rooms = GameSettings.Instance.sRoomManager.GetRooms();
			bool flag = false;
			for (int i = 0; i < rooms.Count; i++)
			{
				Room room = rooms[i];
				if (room.Dummy || room.Floor != GameSettings.Instance.ActiveFloor)
				{
					continue;
				}
				List<Furniture> furnitures = room.GetFurnitures();
				for (int j = 0; j < furnitures.Count; j++)
				{
					Furniture furniture = furnitures[j];
					if (furniture.Noisiness > 0f && (HUD.Instance.BuildMode || furniture.IsOn) && GeometryUtility.TestPlanesAABB(planes, furniture.GetBounds(false)) && !DrawSphere(furniture.transform, furniture.Noisiness * TempScale, Vector3.up * ((furniture.Height1 + furniture.Height2) / 2f)))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (!flag)
			{
				for (int k = 0; k < GameSettings.Instance.sActorManager.Actors.Count; k++)
				{
					Actor actor = GameSettings.Instance.sActorManager.Actors[k];
					if (actor.enabled && actor.Floor == GameSettings.Instance.ActiveFloor && actor.WasOnScreen && !DrawSphere(actor.NeckBone, actor.Noisiness * TempScale, Vector3.zero))
					{
						break;
					}
				}
			}
			_lastFloor = GameSettings.Instance.ActiveFloor;
			_lastPos = mainCam.transform.position;
			NoiseDirty = false;
		}
		Vector2 mouseProj = HUD.Instance.GetMouseProj(1f);
		Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(GameSettings.Instance.ActiveFloor, mouseProj);
		bool flag2 = true;
		if (roomFromPoint != null && !roomFromPoint.Outdoors && !roomFromPoint.Outside)
		{
			if (LastRoom != roomFromPoint)
			{
				ForceDraw = true;
				LastRoom = roomFromPoint;
				CalculateAudioProbes(roomFromPoint, true);
				flag2 = false;
			}
			if (GUICheck.OverGUI)
			{
				AudioLabel.gameObject.SetActive(false);
			}
			else
			{
				AudioLabel.gameObject.SetActive(true);
				float num = Mathf.Clamp01(Furniture.RecalculateNoise(mouseProj, false, roomFromPoint, null, null, true, HUD.Instance.BuildMode));
				AudioLabel.text = num.ToDB();
				AudioLabel.color = ColorGrad.Evaluate(num);
				AudioLabel.rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x / Options.UISize, Input.mousePosition.y / Options.UISize);
			}
		}
		else
		{
			if (LastRoom != null)
			{
				LastRoom = null;
				CalculateAudioProbes(null, true);
				flag2 = false;
			}
			AudioLabel.gameObject.SetActive(false);
		}
		if (flag2)
		{
			CalculateAudioProbes(LastRoom, false);
		}
	}

	private void OnPreCull()
	{
		DrawProbes();
		if (_sphereList.Count <= 0)
		{
			return;
		}
		if (SystemInfo.supportsInstancing)
		{
			Graphics.DrawMeshInstanced(SphereMesh, 0, SphereMat, _sphereList, null, ShadowCastingMode.Off, false, 0, CameraScript.Instance.mainCam);
			return;
		}
		for (int i = 0; i < _sphereList.Count; i++)
		{
			Graphics.DrawMesh(SphereMesh, _sphereList[i], SphereMat, 0, CameraScript.Instance.mainCam);
		}
	}

	private void OnDisable()
	{
		if (!GameSettings.IsQuitting && AudioLabel != null && AudioLabel.gameObject != null)
		{
			AudioLabel.gameObject.SetActive(false);
		}
	}

	private void OnEnable()
	{
		_lastFloor = int.MinValue;
	}

	private bool DrawSphere(Transform t, float size, Vector3 offset)
	{
		if (_sphereList.Count < 1023)
		{
			_sphereList.Add(Matrix4x4.TRS(t.position + offset, Quaternion.identity, Vector3.one * size));
		}
		return _sphereList.Count < 1023;
	}
}
