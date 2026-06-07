using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class FurnitureBuilder : MonoBehaviour
{
	public enum AtriumType
	{
		None = 0,
		Ignore = 1,
		Up = 2,
		Down = 3
	}

	public enum PlaceErrorType
	{
		FurnitureOccupied = 0,
		FurnitureAtriumFloor = 1,
		FurnitureAtriumCeiling = 2
	}

	public GameObject FurnPrefab;

	public Material Green;

	public Material Red;

	public Material GreenInstant;

	public Renderer Rend;

	private Room _lastRoom;

	public SnapPoint LastSnap;

	public SnapPoint OriginalSnap;

	public float RotationSnap = 45f;

	private Furniture Furn;

	public bool IsProto;

	public bool CopyProto;

	private bool TurnMode;

	private bool _turnMouseMoved = true;

	private Vector3 _beforeTurnMousePos;

	private float rotationCountDown;

	private float rotationOffset;

	private bool _disableVisualizer;

	private WallEdge edge1;

	private WallEdge edge2;

	private float WallPosition;

	[NonSerialized]
	private List<Vector2[]> BuildBoundary = new List<Vector2[]>();

	[NonSerialized]
	private List<Vector2> Heights = new List<Vector2>();

	public Material SnapIndicatorMat;

	public Material ElevatorIndicatorMat;

	public Material UsedMaterial;

	public Mesh SnapIndicatorMesh;

	public Mesh CCIndicator;

	public Mesh ElevatorIndicatorMesh;

	public Mesh Quad;

	public GameObject Arrow;

	public Vector3 LerpingPos;

	[NonSerialized]
	public FurnitureBuilder Parent;

	[NonSerialized]
	public List<FurnitureBuilder> Children = new List<FurnitureBuilder>();

	[NonSerialized]
	public HashSet<Furniture> DoNotCopy = new HashSet<Furniture>();

	private bool feetInit;

	private Room _lastPlacedRoom;

	private float _lastPlaced;

	private Texture AlphaTex;

	private Vector4 AlphaUV;

	private Vector2? DragEnd;

	[NonSerialized]
	private Matrix4x4[] _elevatorPos = new Matrix4x4[8];

	[NonSerialized]
	private Matrix4x4[] _autoPlacePos;

	private int _elevatorCount;

	private float _lastSnapOffset;

	private float? _fullCost;

	private bool _shiftGrid;

	private bool _interactionDistance;

	[NonSerialized]
	public double? PriceOverride;

	[NonSerialized]
	public Action OnBuild;

	[NonSerialized]
	public AwardTrophy.AwardData AwardData;

	[NonSerialized]
	public Action OnDestroyed;

	[NonSerialized]
	private Room _lastAutoPlaceRoom;

	[NonSerialized]
	private List<FurnitureAutoPlacement.PlacementData> _lastAutoPlace = new List<FurnitureAutoPlacement.PlacementData>();

	[NonSerialized]
	private int _autoPlaceAlgo;

	[NonSerialized]
	private List<Furniture> _withinDist = new List<Furniture>();

	[NonSerialized]
	private Material _cleanMat;

	public static int GPUInstanceArrows = 128;

	[NonSerialized]
	private readonly List<Matrix4x4[]> _snaps = new List<Matrix4x4[]>();

	private static PlaceErrorType _lastErrorType;

	private Selectable _lastError;

	public float LastRot;

	private static List<Room> BestRoomCache = new List<Room>();

	private bool wasReversed;

	private Vector2 finalP;

	private Vector3 OriginalPosition;

	private Vector3 LastPos;

	public Room LastRoom
	{
		get
		{
			return _lastRoom;
		}
		set
		{
			if (Furn != null && (Furn.TemperatureController || Furn.TemperatureOutput) && Parent == null && value != _lastRoom)
			{
				if (_lastRoom != null && _lastRoom.TempGroup != null)
				{
					_lastRoom.TempGroup.TogglePipes(false, true, Furn.GetTempType());
				}
				if (value != null && value.TempGroup != null)
				{
					value.TempGroup.TogglePipes(true, true, Furn.GetTempType());
				}
			}
			if (_lastRoom != value)
			{
				RefreshElevators(value);
			}
			_lastRoom = value;
		}
	}

	private void UpdateFullCost()
	{
		_fullCost = GetCurrentCost(new Dictionary<string, int>());
	}

	public void UpdateDist(Room r)
	{
		for (int i = 0; i < _withinDist.Count; i++)
		{
			_withinDist[i].HoverHighlight(false);
		}
		_withinDist.Clear();
		FurnitureDistances.FurnitureDist value;
		if (r.IsReferenceNull() || !FurnitureDistances.Distances.TryGetValue(Furn.Type, out value) || value.Furniture == null)
		{
			return;
		}
		float num = value.Distance * value.Distance;
		HashList<Furniture> furniture = r.GetFurniture(value.Furniture);
		for (int j = 0; j < furniture.Count; j++)
		{
			Furniture furniture2 = furniture[j];
			if ((base.transform.position.FlattenVector3() - furniture2.transform.position.FlattenVector3()).sqrMagnitude < num)
			{
				_withinDist.Add(furniture2);
				furniture2.HoverHighlight(true);
			}
		}
	}

	public void SetMaterial(Material mat)
	{
		if (_cleanMat != null)
		{
			UnityEngine.Object.Destroy(_cleanMat);
		}
		UsedMaterial = mat;
		Rend.sharedMaterial = mat;
		if (AlphaTex != null)
		{
			_cleanMat = new Material(mat);
			_cleanMat.mainTexture = AlphaTex;
			_cleanMat.mainTextureOffset = new Vector2(AlphaUV.x, AlphaUV.y);
			_cleanMat.mainTextureScale = new Vector2(AlphaUV.z, AlphaUV.w);
			Rend.sharedMaterial = _cleanMat;
		}
	}

	private void Start()
	{
		RotationSnap = BuildController.Instance.FurnitureAngle;
		Furn = FurnPrefab.GetComponent<Furniture>();
		if (!Furn.CanRotate || (Furn.WallFurn && (!Furn.PokesThroughWall || Furn.OnlyExteriorWalls)))
		{
			Arrow.SetActive(false);
		}
		if (Furn.HasConveyor)
		{
			ConveyorFlow.Toggle(true);
		}
		if (IsProto && !CopyProto)
		{
			MakeAllIgnored(true);
		}
		if (Furn.BuildBoundary != null && Furn.BuildBoundary.Length != 0)
		{
			BuildBoundary.Add(Furn.BuildBoundary.ToArray());
			if (Furn.CustomHeight || Furn.IsSnapping)
			{
				Heights.Add(new Vector2(Furn.Height1, Furn.Height2));
			}
			else
			{
				Heights.Add(new Vector2(Furn.OffsetHeight(0), Furn.OffsetHeight(1)));
			}
		}
		if (IsProto)
		{
			float customHeight = 0f;
			if (Furn.CustomHeight || (Furn.IsSnapping && Furn.SnappedTo != null))
			{
				customHeight = Furn.transform.position.y - (float)(Furn.Floor * 2);
			}
			Vector3 position = Furn.transform.position;
			Quaternion rotation = Furn.transform.rotation;
			Vector3 localScale = Furn.transform.localScale;
			Furn.transform.position = Vector3.zero;
			Furn.transform.rotation = Quaternion.identity;
			Furn.transform.localScale = Vector3.one;
			AddSnapFurnBounds(Furn, CopyProto, customHeight);
			Furn.transform.position = position;
			Furn.transform.rotation = rotation;
			Furn.transform.localScale = localScale;
		}
		if (IsProto)
		{
			base.transform.rotation = FurnPrefab.transform.rotation;
		}
		else
		{
			Vector3 forward = BuildController.Instance.GridMatrix.inverse.MultiplyVector(Vector3.forward);
			base.transform.rotation = Quaternion.LookRotation(forward);
		}
		BuildMesh();
		LerpingPos = base.transform.position;
		if (Parent != null)
		{
			base.transform.position = Quaternion.Inverse(Parent.Furn.transform.rotation) * (Furn.OriginalPosition - Parent.Furn.OriginalPosition);
			base.transform.SetParent(Parent.transform, false);
			base.transform.rotation = Furn.transform.rotation;
			SetMaterial(Green);
			Arrow.SetActive(false);
		}
		LastRot = base.transform.rotation.eulerAngles.y;
		MaterialPreviewer.Instance.RefreshState();
		if (!(Parent == null))
		{
			return;
		}
		WindowManager.SetCursorOverride("Place");
		if (Furn.Type.Equals("Column") && (!AudioVisualizer.Instance.gameObject.activeSelf || !AudioVisualizer.Instance.ColumnMode))
		{
			AudioVisualizer.Instance.ShowColumn();
			_disableVisualizer = true;
		}
		FurnitureInfluenceDrawer.Instance.Disable();
		if (!IsProto || CopyProto)
		{
			if (Options.ShiftToPlace)
			{
				HUD.Instance.ShortcutPanel.AddShortcut("PlaceMultiple".Loc(), KeyCode.LeftShift, true);
			}
			else
			{
				HUD.Instance.ShortcutPanel.AddShortcut("PlaceSingle".Loc(), KeyCode.LeftShift, true);
				HUD.Instance.ShortcutPanel.AddShortcut("Cancel".Loc(), KeyCode.Mouse1);
			}
		}
		if (Furn.WallFurn && Furn.CustomHeight)
		{
			HUD.Instance.ShortcutPanel.AddShortcut("PlaceFreely".Loc(), KeyCode.LeftControl, true);
		}
		if (!Furn.IsSnapping || Furn.CanNotSnap || Furn.CanRotate)
		{
			HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.DisableGrid);
		}
		if (!Furn.WallFurn && Furn.CanRotate)
		{
			HUD.Instance.ShortcutPanel.AddShortcut("Rotate".Loc(), KeyCode.Mouse0, true);
			HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.FurnitureClock);
			HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.FurnitureAntiClock);
			if (Furn.ValidIndoors || Furn.ValidOutdoors)
			{
				HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.AlignNearest);
			}
			if (!Furn.IsSnapping || Furn.CanNotSnap)
			{
				HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.FurnitureRandomRot);
			}
		}
		if (Furn.IsDraggable)
		{
			HUD.Instance.ShortcutPanel.AddShortcut("Stretch".Loc(), KeyCode.Mouse0, true);
		}
		if (!Furn.IsSnapping || Furn.CanNotSnap)
		{
			HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.ShiftGrid);
		}
		if (FurnitureDistances.Distances.ContainsKey(Furn.Type))
		{
			HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.ShowFurnitureInfluence);
			_interactionDistance = Furn.DefaultInteractionDistance;
		}
		if (CanAutoPlace())
		{
			HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.AutoPlaceFurniture, true);
		}
	}

	private bool CanAutoPlace()
	{
		if (!IsProto && !CopyProto && Furn.AutoPlaceGroup != null && Furn.AutoPlaceGroup.Length != 0)
		{
			return Furn.AutoPlaceGroup.All((string x) => FurnitureAutoPlacement.AutoPlacementFunctions.ContainsKey(x));
		}
		return false;
	}

	private void AddSnapFurnBounds(Furniture furn, bool copy, float customHeight)
	{
		SnapPoint[] snapPoints = furn.SnapPoints;
		foreach (SnapPoint snapPoint in snapPoints)
		{
			if (snapPoint.UsedByCount <= 0)
			{
				continue;
			}
			foreach (Furniture item in snapPoint.GetAllUsedBy())
			{
				if (item.CanCopy || !copy)
				{
					if (item.BuildBoundary != null && item.BuildBoundary.Length != 0)
					{
						BuildBoundary.Add(GetRealPoints(Matrix4x4.TRS(snapPoint.transform.localPosition, snapPoint.transform.localRotation, Vector3.one), item.BuildBoundary));
						Heights.Add(new Vector2(item.OffsetHeight(0) - customHeight, item.OffsetHeight(1) - customHeight));
					}
					AddSnapFurnBounds(item, copy, customHeight);
				}
			}
		}
	}

	private Matrix4x4 MakeSnap(Vector3 pos, Quaternion or)
	{
		float num = (Mathf.PerlinNoise(pos.x / 2f, pos.z / 2f) * 2f + Time.realtimeSinceStartup * 2f) % 2f;
		if (num > 1f)
		{
			num = 2f - num;
		}
		num = 1f - num * num;
		return Matrix4x4.TRS(pos + Vector3.up * (num * 0.1f + 0.3f), or, Vector3.one);
	}

	private bool IsSnapPointFree(SnapPoint p)
	{
		if (IsProto && !CopyProto)
		{
			return p.IsFree(Furn);
		}
		return p.IsFree(!Furn.CanSnapSurface);
	}

	private bool IsSnapPointBelowRoof(SnapPoint p)
	{
		if (Furn.Height2 - Furn.Height1 > 2f)
		{
			return true;
		}
		int floor = p.Parent.Parent.FindCeilingAtrium(p.pos.FlattenVector3()).Floor;
		return p.transform.position.y + Furn.Height2 < (float)(floor * 2) + 2.1f;
	}

	private void DrawSnaps(Room room)
	{
		Quaternion or = Quaternion.Euler(0f, Mathf.Round(CameraScript.Instance.transform.rotation.eulerAngles.y / 90f) * 90f + 90f, -90f);
		if (SystemInfo.supportsInstancing)
		{
			int num = 0;
			int num2 = 1;
			if (_snaps.Count == 0)
			{
				_snaps.Add(new Matrix4x4[GPUInstanceArrows]);
			}
			Matrix4x4[] array = _snaps[0];
			foreach (Furniture allFurnitureAtriumAndBalcony in room.GetAllFurnitureAtriumAndBalconies(GameSettings.Instance.ActiveFloor))
			{
				for (int i = 0; i < allFurnitureAtriumAndBalcony.SnapPoints.Length; i++)
				{
					SnapPoint snapPoint = allFurnitureAtriumAndBalcony.SnapPoints[i];
					if (!(snapPoint != LastSnap) || !snapPoint.IsValid || !IsSnapPointFree(snapPoint) || !Furn.DoesSnapTo(snapPoint.Name) || (!snapPoint.Parent.Parent.Outside && !IsSnapPointBelowRoof(snapPoint)) || (IsProto && !CopyProto && !RecurseSnap(snapPoint)))
					{
						continue;
					}
					array[num] = MakeSnap(snapPoint.transform.position, or);
					num++;
					if (num == GPUInstanceArrows)
					{
						num = 0;
						if (num2 == _snaps.Count)
						{
							_snaps.Add(new Matrix4x4[GPUInstanceArrows]);
						}
						array = _snaps[num2];
						num2++;
					}
				}
			}
			if (num == 0)
			{
				num2--;
				num = GPUInstanceArrows;
			}
			for (int j = 0; j < num2; j++)
			{
				int count = ((j == num2 - 1) ? num : GPUInstanceArrows);
				Graphics.DrawMeshInstanced(SnapIndicatorMesh, 0, SnapIndicatorMat, _snaps[j], count, null, ShadowCastingMode.On, false);
			}
			return;
		}
		foreach (Furniture allFurnitureAtriumAndBalcony2 in room.GetAllFurnitureAtriumAndBalconies(GameSettings.Instance.ActiveFloor))
		{
			for (int k = 0; k < allFurnitureAtriumAndBalcony2.SnapPoints.Length; k++)
			{
				SnapPoint snapPoint2 = allFurnitureAtriumAndBalcony2.SnapPoints[k];
				if (snapPoint2 != LastSnap && snapPoint2.IsValid && IsSnapPointFree(snapPoint2) && Furn.DoesSnapTo(snapPoint2.Name))
				{
					Graphics.DrawMesh(SnapIndicatorMesh, MakeSnap(snapPoint2.transform.position, or), SnapIndicatorMat, 0);
				}
			}
		}
	}

	private void AddSnapFurns(Furniture furn, List<Furniture> furns, bool copy)
	{
		foreach (Furniture item in from x in furn.SnapPoints.SelectMany((SnapPoint x) => x.GetAllUsedBy())
			where x.CanCopy || !copy
			select x)
		{
			furns.Add(item);
			AddSnapFurns(item, furns, copy);
		}
	}

	private void TraverseTransform(Transform t, Furniture localFurn, SnapPoint s)
	{
		if (s.Parent != Furn && s.Parent.SnappedTo != null)
		{
			TraverseTransform(t, s.Parent, s.Parent.SnappedTo);
		}
		t.position += t.rotation * s.transform.localPosition;
		t.rotation *= Quaternion.Euler(0f, localFurn.RotationOffset, 0f) * s.transform.localRotation;
	}

	public void BuildMesh()
	{
		MeshFilter component = GetComponent<MeshFilter>();
		if (component.sharedMesh != null)
		{
			UnityEngine.Object.Destroy(component.sharedMesh);
		}
		List<CombineInstance> list = new List<CombineInstance>();
		List<Furniture> list2 = new List<Furniture> { Furn };
		if (IsProto)
		{
			AddSnapFurns(Furn, list2, CopyProto);
		}
		Texture texture = null;
		Vector4 alphaUV = new Vector4(0f, 0f, 1f, 1f);
		FurnitureStyle furnitureStyle = null;
		bool flag = !IsProto && !CopyProto && Furn.ReplacementGroups != null && Furn.ReplacementGroups.Length != 0;
		FurnitureStyle furnitureStyle2;
		if (flag && (furnitureStyle2 = MaterialPreviewer.Instance.GetActiveStyle() as FurnitureStyle) != null)
		{
			furnitureStyle = furnitureStyle2;
		}
		else
		{
			flag = false;
		}
		ObjectDatabase.ReplacementGroup? replacementGroup = null;
		ObjectDatabase.ReplacementGroup? replacementGroup2 = null;
		if (flag)
		{
			ObjectDatabase.ReplacementGroup group;
			replacementGroup = (ObjectDatabase.Instance.GetReplacementGroup(Furn.ReplacementGroups[0], out group) ? new ObjectDatabase.ReplacementGroup?(group) : ((ObjectDatabase.ReplacementGroup?)null));
			if (Furn.ReplacementGroups.Length > 1)
			{
				replacementGroup2 = (ObjectDatabase.Instance.GetReplacementGroup(Furn.ReplacementGroups[1], out group) ? new ObjectDatabase.ReplacementGroup?(group) : ((ObjectDatabase.ReplacementGroup?)null));
			}
		}
		for (int i = 0; i < list2.Count; i++)
		{
			Furniture furniture = list2[i];
			Vector3 position = furniture.transform.position;
			Quaternion rotation = furniture.transform.rotation;
			Vector3 localScale = furniture.transform.localScale;
			furniture.transform.position = Vector3.zero;
			furniture.transform.rotation = Quaternion.identity;
			if (furniture.SnappedTo != null && furniture != Furn)
			{
				TraverseTransform(furniture.transform, furniture, furniture.SnappedTo);
				furniture.transform.position = furniture.transform.position + furniture.SnapPointOffset;
			}
			furniture.transform.localScale = Vector3.one;
			MeshFilter[] componentsInChildren = furniture.GetComponentsInChildren<MeshFilter>(true);
			foreach (MeshFilter meshFilter in componentsInChildren)
			{
				if (meshFilter.tag.Equals("HideUnaffected") || meshFilter.tag.Equals("IgnoreMesh") || meshFilter.tag.Equals("HidePlacement") || meshFilter.sharedMesh == null)
				{
					continue;
				}
				if (meshFilter.tag.Equals("HighlightAlpha"))
				{
					alphaUV = furniture.HighlightAlphaUV;
					texture = meshFilter.GetComponent<Renderer>().sharedMaterial.mainTexture;
					CompanySignage component2 = furniture.GetComponent<CompanySignage>();
					if (component2 != null)
					{
						if (component2.JustLogo)
						{
							alphaUV = LogoController.Instance.GetLogoRect(GameSettings.Instance.MyCompany).ToVector();
						}
						else
						{
							texture = GameSettings.Instance.GetCompanyBuildingName(GameSettings.Instance.MyCompany).Item1;
						}
					}
				}
				CombineInstance item = new CombineInstance
				{
					mesh = meshFilter.sharedMesh
				};
				ReplacementMesh component3;
				if (flag && meshFilter.TryGetComponent<ReplacementMesh>(out component3))
				{
					ObjectDatabase.ReplacementObject o;
					ValueTuple<Mesh, Mesh, Mesh> meshes;
					if (furnitureStyle.Replacement1 != null && replacementGroup.HasValue && replacementGroup.Value.GetReplacement(furnitureStyle.Replacement1, out o) && o.GetMesh(component3.ReplacementName, out meshes))
					{
						item.mesh = meshes.Item1;
						if (item.mesh == null)
						{
							continue;
						}
					}
					else if (furnitureStyle.Replacement2 != null && replacementGroup2.HasValue && replacementGroup2.Value.GetReplacement(furnitureStyle.Replacement2, out o) && o.GetMesh(component3.ReplacementName, out meshes))
					{
						item.mesh = meshes.Item1;
						if (item.mesh == null)
						{
							continue;
						}
					}
				}
				item.transform = meshFilter.transform.localToWorldMatrix;
				list.Add(item);
			}
			if (Parent == null && Children.Count == 0 && "CCTV".Equals(furniture.Type))
			{
				list.Add(new CombineInstance
				{
					mesh = CCIndicator,
					transform = Matrix4x4.TRS(new Vector3(0f, 0.02f, 0f), Quaternion.identity, Vector3.one * furniture.MiscPotential)
				});
			}
			if ("Elevator".Equals(furniture.Type) && furniture.ElevatorDoors.Length != 0)
			{
				Rect elevatorEntrance = furniture.ElevatorEntrance;
				list.Add(new CombineInstance
				{
					mesh = Quad,
					transform = Matrix4x4.TRS(new Vector3(elevatorEntrance.center.x, 0.02f, elevatorEntrance.center.y), Quaternion.identity, new Vector3(elevatorEntrance.width, 1f, elevatorEntrance.height))
				});
			}
			furniture.transform.position = position;
			furniture.transform.rotation = rotation;
			furniture.transform.localScale = localScale;
		}
		Mesh mesh = new Mesh();
		mesh.CombineMeshes(list.ToArray());
		component.sharedMesh = mesh;
		if (texture != null && list.Count == 1)
		{
			AlphaTex = texture;
			AlphaUV = alphaUV;
			SetMaterial(Green);
		}
	}

	private void GetHits(Vector2[] poly, Room r, List<Vector2[]> hits)
	{
		for (int i = 0; i < r.Edges.Count; i++)
		{
			WallEdge wallEdge = r.Edges[i];
			WallEdge wallEdge2 = r.Edges[(i + 1) % r.Edges.Count];
			for (int j = 0; j < poly.Length; j++)
			{
				Vector2 p = poly[j];
				Vector2 p2 = poly[(j + 1) % poly.Length];
				if (Utilities.LinesIntersect(p, p2, wallEdge.Pos, wallEdge2.Pos, true, true))
				{
					hits.Add(new Vector2[2] { wallEdge.Pos, wallEdge2.Pos });
					break;
				}
			}
		}
	}

	private Vector2? OffsetFromHits(Vector2[] poly, Room r, List<Vector2[]> hits)
	{
		Vector2 zero = Vector2.zero;
		for (int i = 0; i < hits.Count; i++)
		{
			Vector2 a = hits[i][0];
			Vector2 b = hits[i][1];
			bool flag = false;
			float num = 0f;
			Vector2 vector = Vector2.zero;
			for (int j = 0; j < poly.Length; j++)
			{
				Vector2 res;
				if (!r.IsInside(poly[j]) && Utilities.ProjectToLine(poly[j], a, b, out res))
				{
					Vector2 vector2 = res - poly[j];
					float magnitude = vector2.magnitude;
					if (magnitude > num)
					{
						vector = vector2;
						num = magnitude;
						flag = true;
					}
				}
			}
			if (flag)
			{
				Vector2 vector3 = vector.normalized * (num + 0.01f);
				for (int k = 0; k < poly.Length; k++)
				{
					poly[k] += vector3;
				}
				zero += vector3;
			}
		}
		if (zero != Vector2.zero)
		{
			return zero;
		}
		return null;
	}

	private Vector2? KeepInside(Vector2[] poly, Room r)
	{
		List<Vector2[]> list = new List<Vector2[]>();
		GetHits(poly, r, list);
		if (list.Count > 0)
		{
			int num = 0;
			Vector2? vector = OffsetFromHits(poly, r, list);
			Vector2 vector2 = vector ?? Vector2.zero;
			while (num < 4 && vector.HasValue)
			{
				list.Clear();
				GetHits(poly, r, list);
				if (list.Count <= 0)
				{
					break;
				}
				num++;
				vector = OffsetFromHits(poly, r, list);
				if (vector.HasValue)
				{
					vector2 += vector.Value;
				}
			}
			if (vector2 != Vector2.zero)
			{
				return vector2;
			}
		}
		return null;
	}

	private bool DoubleCheck()
	{
		Room room = GameSettings.Instance.sRoomManager.GetRoomFromPoint(GameSettings.Instance.ActiveFloor, HUD.Instance.GetMouseProj()) ?? LastRoom;
		if (ValidIn(Furn, room) != null || room == GameSettings.Instance.sRoomManager.Outside)
		{
			room = LastRoom;
		}
		if (BuildBoundary.Count == 1 && room != null && !room.Outside && !Furn.IsSnapping && !Furn.WallFurn)
		{
			Vector2[] realPoints = GetRealPoints(Matrix4x4.TRS(base.transform.position, GetFurnitureRotation(), Vector3.one), BuildBoundary[0]);
			Vector2? vector = KeepInside(realPoints, room);
			if (vector.HasValue)
			{
				Vector3 vector2 = base.transform.position + vector.Value.ToVector3(0f);
				if (IsValid(Matrix4x4.TRS(vector2, GetFurnitureRotation(), Vector3.one), room))
				{
					LastRoom = room;
					ErrorOverlay.Instance.Clear();
					base.transform.position = vector2;
					return true;
				}
			}
		}
		return false;
	}

	public bool IsValid(Matrix4x4 mat, Room r, Furniture ignore = null, bool exterior = false, int? floor = null, bool isTwoFloorCheck = false, bool forceSnap = false)
	{
		Vector3 pos = mat.MultiplyPoint(Vector3.zero);
		if (((Furn.ValidOutside && !exterior) || (Furn.PokesThroughRoof && exterior && floor.HasValue)) && (r == null || r.Outside))
		{
			if (GameSettings.Instance.RentMode && !GameSettings.Instance.EditMode)
			{
				ErrorOverlay.Instance.ShowError("NotPlayerOwnedPlace");
				SetError(null);
				return false;
			}
			int num = floor ?? GameSettings.Instance.ActiveFloor;
			if (floor.HasValue || num == 0 || Furn.IsSnapping)
			{
				float floorOffset = pos.y.GetFloorOffset(0);
				int num2 = (floor.HasValue ? floor.Value : 0);
				for (int i = 0; i < BuildBoundary.Count; i++)
				{
					int num3 = Mathf.FloorToInt((Heights[i].y + floorOffset) / 2f);
					Vector2[] realPoints = GetRealPoints(mat, BuildBoundary[i]);
					if (!GameSettings.Instance.PlayerOwnedArea(realPoints))
					{
						SetError(null);
						ErrorOverlay.Instance.ShowError("RoomOutOfPlot");
						return false;
					}
					int num4 = Mathf.FloorToInt(num2 / 2);
					int num5 = Mathf.FloorToInt((Furn.Height2 + (float)(num * 2)) / 4f) + 1;
					for (int j = num4; j < num5; j++)
					{
						if (RoadManager.Instance.GetRoad(base.transform.position.FlattenVector3(), j) != 0)
						{
							SetError(null);
							return false;
						}
					}
					for (int k = 0; k < realPoints.Length; k++)
					{
						Vector2 vector = realPoints[k];
						for (int l = num4; l < num5; l++)
						{
							if (RoadManager.Instance.GetRoad(vector, l) != 0)
							{
								SetError(null);
								return false;
							}
						}
						if (num2 <= 0)
						{
							Vector2 first = realPoints[(k == 0) ? (realPoints.Length - 1) : (k - 1)];
							Vector2 vector2 = realPoints[(k + 1) % realPoints.Length];
							if (BuildController.IsOnPath(p2: Utilities.GetOffset(vector, vector2, realPoints[(k + 2) % realPoints.Length], -1f, true), p1: Utilities.GetOffset(first, vector, vector2, -1f, true), floor: num))
							{
								ErrorOverlay.Instance.ShowError("RoomOnPath");
								SetError(null);
								return false;
							}
						}
					}
					if (!IsValid(Furn.Type, pos, realPoints, Heights[i].x + floorOffset, Heights[i].y + floorOffset, GameSettings.Instance.sRoomManager.Outside, Furn.WallFurn, forceSnap || LastSnap != null, exterior, Furn.InFloor, Furn.BlocksFloor, Furn.AtriumValid, Furn.GetAtriumType(), Furn.IgnoreType, this, ignore))
					{
						ErrorOverlay.Instance.ShowError("FurnitureOccupied");
						SetError(null);
						return false;
					}
					for (int m = 0; m < GameSettings.Instance.sRoomManager.Rooms.Count; m++)
					{
						Room room = GameSettings.Instance.sRoomManager.Rooms[m];
						if (room.Floor >= num2 && room.Floor <= num3 && !IsValid(Furn.Type, pos, realPoints, Heights[i].x + floorOffset, Heights[i].y + floorOffset, room, Furn.WallFurn, forceSnap || LastSnap != null, true, Furn.InFloor, Furn.BlocksFloor, Furn.AtriumValid, Furn.GetAtriumType(), Furn.IgnoreType, this, ignore))
						{
							if (_lastError == null)
							{
								SetError(room);
							}
							ErrorOverlay.Instance.ShowError("FurnitureOccupied");
							return false;
						}
						if (room.Floor == -1 && !room.Pillar && !IsValid(Furn.Type, pos, realPoints, Heights[i].x + floorOffset, Heights[i].y + floorOffset, room, Furn.WallFurn, forceSnap || LastSnap != null, true, Furn.InFloor, Furn.BlocksFloor, Furn.AtriumValid, Furn.GetAtriumType(), Furn.IgnoreType, this, ignore))
						{
							ErrorOverlay.Instance.ShowError("FurnitureOccupied");
							return false;
						}
					}
				}
				SetError(null);
				return true;
			}
			ErrorOverlay.Instance.ShowError("GroundFloorOutsideError");
			return false;
		}
		if (r == null)
		{
			SetError(null);
			return exterior;
		}
		if (r.Pillar)
		{
			SetError(null);
			return false;
		}
		if (r.Burn > 0f)
		{
			ErrorOverlay.Instance.ShowError("BurntRoomError");
			SetError(null);
			return false;
		}
		if (!r.IsPlayerControlled() && (!GameSettings.Instance.CampaignMode || GameSettings.Instance.CompletedMissions.Count >= 2 || r.DID != 85 || !Furn.Type.Equals("Computer")))
		{
			ErrorOverlay.Instance.ShowError("NotPlayerOwnedPlace");
			SetError(null);
			return false;
		}
		Vector2[] array = null;
		if (Furn.PokesThroughRoof && !exterior)
		{
			if (r.Roofing != null)
			{
				ErrorOverlay.Instance.ShowError("PokeThroughRoofError");
				SetError(r.Roofing);
				return false;
			}
			if (r.Floor == -1)
			{
				array = GetRealPoints(mat, BuildBoundary[0]);
				for (int n = 0; n < array.Length; n++)
				{
					if (RoadManager.Instance.GetRoad(array[n], 0) > 0)
					{
						ErrorOverlay.Instance.ShowError("PokeThroughRoofError");
						SetError(null);
						return false;
					}
				}
			}
		}
		float num6 = pos.y.GetFloorOffset(r.Floor);
		if (isTwoFloorCheck)
		{
			num6 += 2f;
		}
		for (int num7 = 0; num7 < BuildBoundary.Count; num7++)
		{
			Vector2[] ps = ((num7 == 0 && array != null) ? array : GetRealPoints(mat, BuildBoundary[num7]));
			if (!IsValid(Furn.Type, pos, ps, Heights[num7].x + num6, Heights[num7].y + num6, r, Furn.WallFurn, forceSnap || LastSnap != null || num7 > 0, exterior, Furn.InFloor, Furn.BlocksFloor, Furn.AtriumValid, Furn.GetAtriumType(), Furn.IgnoreType, this, ignore))
			{
				if (Furn.PokesThroughRoof && exterior)
				{
					ErrorOverlay.Instance.ShowError("PokeThroughRoofError");
				}
				else
				{
					ErrorOverlay.Instance.ShowError(_lastErrorType.ToString());
				}
				return false;
			}
		}
		return true;
	}

	public static bool IsValid(Furniture furn, Room r, bool exterior, params Furniture[] ignore)
	{
		return IsValid(furn.Type, furn.OriginalPosition, furn.FinalBoundary, furn.OffsetHeight(0), furn.OffsetHeight(1), r, furn.WallFurn, furn.IsActivelySnapping, exterior, furn.InFloor, furn.BlocksFloor, furn.AtriumValid, furn.GetAtriumType(), furn.IgnoreType, ignore);
	}

	public static bool IsValid(Furniture furn, float height1, float height2, Room r, bool exterior, params Furniture[] ignore)
	{
		return IsValid(furn.Type, furn.OriginalPosition, furn.FinalBoundary, height1, height2, r, furn.WallFurn, furn.IsActivelySnapping, exterior, furn.InFloor, furn.BlocksFloor, furn.AtriumValid, furn.GetAtriumType(), furn.IgnoreType, ignore);
	}

	public static bool IsValid(Furniture furn, Vector3 pos, Vector2[] ps, Room r, bool exterior, params Furniture[] ignore)
	{
		return IsValid(furn.Type, pos, ps, furn.OffsetHeight(0), furn.OffsetHeight(1), r, furn.WallFurn, furn.IsActivelySnapping, exterior, furn.InFloor, furn.BlocksFloor, furn.AtriumValid, furn.GetAtriumType(), furn.IgnoreType, ignore);
	}

	public static bool IsValid(Furniture furn, Vector3 pos, Vector2[] ps, float height1, float height2, Room r, bool exterior, params Furniture[] ignore)
	{
		return IsValid(furn.Type, pos, ps, height1, height2, r, furn.WallFurn, furn.IsActivelySnapping, exterior, furn.InFloor, furn.BlocksFloor, furn.AtriumValid, furn.GetAtriumType(), furn.IgnoreType, ignore);
	}

	public static bool IsValid(Furniture furn, Vector3 pos, Vector2[] ps, float height1, float height2, Room r, bool exterior, bool forceSnapping, params Furniture[] ignore)
	{
		return IsValid(furn.Type, pos, ps, height1, height2, r, furn.WallFurn, furn.IsActivelySnapping || forceSnapping, exterior, furn.InFloor, furn.BlocksFloor, furn.AtriumValid, furn.GetAtriumType(), furn.IgnoreType, ignore);
	}

	public static bool IsValid(string type, Vector3 pos, Vector2[] ps, float height1, float height2, Room r, bool wallFurn, bool snapping, bool exterior, bool inFloor, bool blocksFloor, bool atriumValid, AtriumType atriumFixture, string ignoreType, params Furniture[] ignore)
	{
		return IsValid(type, pos, ps, height1, height2, r, wallFurn, snapping, exterior, inFloor, blocksFloor, atriumValid, atriumFixture, ignoreType, null, ignore);
	}

	public static bool IsValid(string type, Vector3 pos, Vector2[] ps, float height1, float height2, Room r, bool wallFurn, bool snapping, bool exterior, bool inFloor, bool blocksFloor, bool atriumValid, AtriumType atriumFixture, string ignoreType, FurnitureBuilder builder, params Furniture[] ignore)
	{
		_lastErrorType = PlaceErrorType.FurnitureOccupied;
		if (r == null)
		{
			if ((object)builder != null)
			{
				builder.SetError(null);
			}
			return exterior;
		}
		if (!exterior && height2 - height1 < 2f)
		{
			int num = r.FindCeilingAtrium(pos.FlattenVector3()).Floor - r.Floor;
			if (height2 > (float)(num * 2) + 2.1f)
			{
				if ((object)builder != null)
				{
					builder.SetError(null);
				}
				return false;
			}
		}
		if (!exterior && !snapping && r.AtriumParent.IsAliveNotNull())
		{
			Room mainAtriumParent = r.GetMainAtriumParent();
			Room room = (r.IsBalcony ? r.AtriumParent : r);
			if ((r == mainAtriumParent || mainAtriumParent.AtriumChildren.Last() != room) && atriumFixture == AtriumType.None && height1 > 0.0001f && !wallFurn)
			{
				_lastErrorType = PlaceErrorType.FurnitureAtriumCeiling;
				if ((object)builder != null)
				{
					builder.SetError(null);
				}
				return false;
			}
			if (r != mainAtriumParent && r.IsUpperAtriumNotBalcony && (!atriumValid || (height1 < 0.01f && !wallFurn)))
			{
				_lastErrorType = PlaceErrorType.FurnitureAtriumFloor;
				if ((object)builder != null)
				{
					builder.SetError(null);
				}
				return false;
			}
		}
		if (r.Pillar && !exterior)
		{
			if ((object)builder != null)
			{
				builder.SetError(null);
			}
			return false;
		}
		if (ps.Length == 0)
		{
			if ((object)builder != null)
			{
				builder.SetError(null);
			}
			return true;
		}
		Rect bounds = ((IList<Vector2>)ps).GetBounds();
		if (ps.Length == 1)
		{
			if (!wallFurn && (!exterior || !r.Outside) && !(r.Floor == -1 && exterior) && !(exterior ^ r.IsInside(ps[0])))
			{
				if ((object)builder != null)
				{
					builder.SetError(null);
				}
				return false;
			}
			List<Furniture> furnitures = r.GetFurnitures();
			for (int i = 0; i < furnitures.Count; i++)
			{
				Furniture furniture = furnitures[i];
				if (!CheckFurniturePoint(r, furniture, ps[0], type, ignoreType, inFloor, blocksFloor, height1, height2, exterior, ignore))
				{
					if ((object)builder != null)
					{
						builder.SetError(furniture);
					}
					return false;
				}
			}
			Furniture eFurn;
			if (r.AtriumParent != null && !CheckFurnitureAtrium(r, ps, bounds, type, ignoreType, inFloor, blocksFloor, exterior, atriumFixture, ignore, out eFurn))
			{
				if ((object)builder != null)
				{
					builder.SetError(eFurn);
				}
				return false;
			}
		}
		else
		{
			bool flag = ps.Length > 2;
			if (!wallFurn && !(r.Outside && exterior) && !(r.Floor == -1 && exterior))
			{
				for (int j = 0; j < ps.Length; j++)
				{
					Vector2 p = ps[j];
					if (ps.Length > 2)
					{
						if (!(exterior ^ r.IsInside(p, exterior)))
						{
							if ((object)builder != null)
							{
								builder.SetError(null);
							}
							return false;
						}
					}
					else if (!flag && (exterior ^ r.IsInside(p, 0.02f)))
					{
						flag = true;
					}
					Vector2 p2 = ps[(j + 1) % ps.Length];
					if (r.Outside)
					{
						continue;
					}
					for (int k = 0; k < r.Edges.Count; k++)
					{
						Vector2 pos2 = r.Edges[k].Pos;
						if (exterior && Utilities.IsInside(pos2, ps))
						{
							if ((object)builder != null)
							{
								builder.SetError(null);
							}
							return false;
						}
						Vector2 pos3 = r.Edges[(k + 1) % r.Edges.Count].Pos;
						if (Utilities.LinesIntersect(p, p2, pos2, pos3, true, false))
						{
							if ((object)builder != null)
							{
								builder.SetError(null);
							}
							return false;
						}
					}
				}
			}
			else if (!flag)
			{
				flag = true;
			}
			if (!flag)
			{
				if ((object)builder != null)
				{
					builder.SetError(null);
				}
				return false;
			}
			List<Furniture> furnitures2 = r.GetFurnitures();
			for (int l = 0; l < furnitures2.Count; l++)
			{
				Furniture furniture2 = furnitures2[l];
				if (!CheckFurniturePoly(r, furniture2, ps, bounds, type, ignoreType, inFloor, blocksFloor, height1, height2, exterior, ignore))
				{
					if ((object)builder != null)
					{
						builder.SetError(furniture2);
					}
					return false;
				}
			}
			Furniture eFurn2;
			if (r.AtriumParent != null && !CheckFurnitureAtrium(r, ps, bounds, type, ignoreType, inFloor, blocksFloor, exterior, atriumFixture, ignore, out eFurn2))
			{
				if ((object)builder != null)
				{
					builder.SetError(eFurn2);
				}
				return false;
			}
		}
		if ((object)builder != null)
		{
			builder.SetError(null);
		}
		return true;
	}

	private static bool CheckFurnitureAtrium(Room r, Vector2[] ps, Rect bounds, string type, string ignoreType, bool inFloor, bool blocksFloor, bool exterior, AtriumType aType, Furniture[] ignore, out Furniture eFurn)
	{
		eFurn = null;
		bool isBalcony = r.IsBalcony;
		if (isBalcony)
		{
			r = r.AtriumParent;
		}
		Room atriumParent = r.AtriumParent;
		int num = ((!(atriumParent == r)) ? (atriumParent.AtriumChildren.IndexOf(r) + 1) : 0);
		if (!isBalcony)
		{
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				Room room = ((num2 == 0) ? atriumParent : atriumParent.AtriumChildren[num2 - 1]);
				bool flag = false;
				if (num2 > 0)
				{
					Room room2 = room.AtriumChildren.FirstOrDefault((Room x) => x.IsInside(ps[0]));
					if (room2 != null)
					{
						room = room2;
						flag = true;
					}
				}
				List<Furniture> furnitures = room.GetFurnitures();
				for (int num3 = 0; num3 < furnitures.Count; num3++)
				{
					Furniture furniture = furnitures[num3];
					if (aType != AtriumType.Down && furniture.GetAtriumType() != AtriumType.Up)
					{
						continue;
					}
					if (ps.Length == 1)
					{
						if (!CheckFurniturePoint(r, furniture, ps[0], type, ignoreType, inFloor, blocksFloor, 0f, 2f, exterior, ignore))
						{
							eFurn = furniture;
							return false;
						}
					}
					else if (!CheckFurniturePoly(r, furniture, ps, bounds, type, ignoreType, inFloor, blocksFloor, 0f, 2f, exterior, ignore))
					{
						eFurn = furniture;
						return false;
					}
				}
				if (flag)
				{
					break;
				}
			}
		}
		for (int num4 = num + 1; num4 < atriumParent.AtriumChildren.Count + 1; num4++)
		{
			Room room3 = atriumParent.AtriumChildren[num4 - 1];
			if (room3.AtriumChildren.Any((Room x) => x.IsInside(ps[0])))
			{
				break;
			}
			List<Furniture> furnitures2 = room3.GetFurnitures();
			for (int num5 = 0; num5 < furnitures2.Count; num5++)
			{
				Furniture furniture2 = furnitures2[num5];
				if (aType != AtriumType.Up && furniture2.GetAtriumType() != AtriumType.Down)
				{
					continue;
				}
				if (ps.Length == 1)
				{
					if (!CheckFurniturePoint(r, furniture2, ps[0], type, ignoreType, inFloor, blocksFloor, 0f, 2f, exterior, ignore))
					{
						eFurn = furniture2;
						return false;
					}
				}
				else if (!CheckFurniturePoly(r, furniture2, ps, bounds, type, ignoreType, inFloor, blocksFloor, 0f, 2f, exterior, ignore))
				{
					eFurn = furniture2;
					return false;
				}
			}
		}
		return true;
	}

	private static bool CheckFurniturePoint(Room r, Furniture furn, Vector2 p, string type, string ignoreType, bool inFloor, bool blocksFloor, float height1, float height2, bool exterior, Furniture[] ignore)
	{
		if (furn.IgnoreBoundary || furn.FinalBoundary == null || furn.FinalBoundary.Length == 0 || type.Equals(furn.IgnoreType) || furn.Type.Equals(ignoreType) || Mathf.Abs(furn.OriginalPosition.x - p.x) > 2f || Mathf.Abs(furn.OriginalPosition.z - p.y) > 2f || (!inFloor && !furn.InFloor && !Utilities.Overlap(furn.OffsetHeight(0), furn.OffsetHeight(1), height1, height2)) || (inFloor && !furn.InFloor && !furn.BlocksFloor) || (furn.InFloor && !inFloor && !blocksFloor) || (exterior && !r.Outside && r.Floor >= 0 && !furn.PokesThroughWall) || (exterior && r.Floor == -1 && !furn.PokesThroughRoof) || ignore.Contains(furn))
		{
			return true;
		}
		if (Utilities.IsInside(p, furn.FinalBoundary))
		{
			return false;
		}
		return true;
	}

	private static bool CheckFurniturePoly(Room r, Furniture furn, Vector2[] ps, Rect bounds, string type, string ignoreType, bool inFloor, bool blocksFloor, float height1, float height2, bool exterior, Furniture[] ignore)
	{
		if (ignore.Contains(furn) || furn.IgnoreBoundary || furn.FinalBoundary == null || furn.FinalBoundary.Length == 0 || type.Equals(furn.IgnoreType) || furn.Type.Equals(ignoreType) || (!inFloor && !furn.InFloor && !Utilities.Overlap(furn.OffsetHeight(0), furn.OffsetHeight(1), height1, height2)) || (inFloor && !furn.InFloor && !furn.BlocksFloor) || (furn.InFloor && !inFloor && !blocksFloor) || (exterior && r.Floor == -1 && !furn.PokesThroughRoof) || (exterior && !r.Outside && r.Floor >= 0 && !furn.PokesThroughWall))
		{
			return true;
		}
		if (!bounds.FixedOverlaps(furn.GetBuildRect()))
		{
			return true;
		}
		int num = 0;
		for (int i = 0; i < ps.Length; i++)
		{
			Vector2 vector = ps[i];
			Vector2 p = ps[(i + 1) % ps.Length];
			for (int j = 0; j < furn.FinalBoundary.Length; j++)
			{
				Vector2 vector2 = furn.FinalBoundary[j];
				Vector2 q = furn.FinalBoundary[(j + 1) % furn.FinalBoundary.Length];
				if (vector == vector2)
				{
					num++;
				}
				if (Utilities.LinesIntersect(vector, p, vector2, q, ps.Length != 2 || furn.FinalBoundary.Length != 2, false))
				{
					return false;
				}
				if (Utilities.IsInside(vector2, ps))
				{
					return false;
				}
			}
			if (Utilities.IsInside(vector, furn.FinalBoundary))
			{
				return false;
			}
		}
		if (num == ps.Length)
		{
			return false;
		}
		return true;
	}

	private void OnDestroy()
	{
		if (_cleanMat != null)
		{
			UnityEngine.Object.Destroy(_cleanMat);
		}
		UnityEngine.Object.Destroy(GetComponent<MeshFilter>().sharedMesh);
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		UpdateDist(null);
		Action onDestroyed = OnDestroyed;
		if (onDestroyed != null)
		{
			onDestroyed();
		}
		BuildController.Instance.SetAutoPlace(null);
		if (_disableVisualizer && AudioVisualizer.Instance.ColumnMode)
		{
			AudioVisualizer.Instance.enabled = false;
		}
		ConveyorFlow.Toggle(false);
		CostDisplay.Instance.Hide();
		if (_lastError != null)
		{
			_lastError.ToggleError(false);
			RefreshErrorEdgeDet();
		}
		if (BuildController.Instance != null)
		{
			BuildController.Instance.ResetTempGrid();
			if (BuildController.Instance.CurrentFurnitureBuilder == this)
			{
				BuildController.Instance.CurrentFurnitureBuilder = null;
				HUD.Instance.TempPanel.StartDeactivate();
			}
		}
		LastRoom = null;
		if (IsProto && !CopyProto)
		{
			MakeAllIgnored(false);
		}
		foreach (FurnitureBuilder child in Children)
		{
			if (child != null)
			{
				UnityEngine.Object.Destroy(child.gameObject);
			}
		}
		if (Parent != null)
		{
			Parent.Children.Remove(this);
		}
		MaterialPreviewer.Instance.RefreshState();
		FurnitureInfluenceDrawer.Instance.Disable();
	}

	private void RefreshErrorEdgeDet()
	{
		Furniture furniture = _lastError as Furniture;
		if (furniture != null)
		{
			furniture.RefreshEdgeDetection();
		}
	}

	public void SetError(Selectable furn)
	{
		if (_lastError != furn)
		{
			if (_lastError != null)
			{
				_lastError.ToggleError(false);
				RefreshErrorEdgeDet();
			}
			_lastError = furn;
			if (_lastError != null)
			{
				_lastError.ToggleError(true);
				RefreshErrorEdgeDet();
			}
		}
	}

	private void MakeAllIgnored(bool ignore)
	{
		if (!(Furn != null))
		{
			return;
		}
		Furn.IgnoreBoundary = ignore;
		foreach (Furniture item in Furn.SnapPoints.SelectMany((SnapPoint x) => x.GetAllUsedBy()))
		{
			item.IgnoreBoundary = ignore;
		}
	}

	public Vector2[] GetRealPoints(Matrix4x4 matrix, Vector2[] points)
	{
		return points.SelectInPlace((Vector2 x) => matrix.MultiplyPoint(x.ToVector3(0f)).FlattenVector3());
	}

	private float GetRandomRotation(float rot)
	{
		if (Furn.IsSnapping && Furn.Only180Rotation)
		{
			if (!(UnityEngine.Random.value > 0.5f))
			{
				return 180f;
			}
			return 0f;
		}
		int max = Mathf.RoundToInt(360f / RotationSnap);
		return rot + (float)UnityEngine.Random.Range(1, max) * RotationSnap;
	}

	public static Room SnapCheckRoom(Room room, Vector3 pos)
	{
		return room;
	}

	private void NormalBuildCode(bool usePos)
	{
		if (TurnMode && !usePos)
		{
			WindowManager.SetCursorOverride("Rotate");
			if (rotationCountDown < 0f && _turnMouseMoved)
			{
				if (Furn.IsSnapping && (!Furn.CanNotSnap || LastSnap != null))
				{
					if (Furn.CanRotate)
					{
						if (LastSnap != null)
						{
							Vector2 mousePos = BuildController.Instance.GetMousePos(new Plane(Vector3.up, Vector3.up * LastSnap.transform.position.y));
							Vector3 vector = new Vector3(mousePos.x, LastSnap.transform.position.y, mousePos.y);
							Vector3 realPos = LastSnap.GetRealPos();
							float y = Quaternion.LookRotation(vector - realPos).eulerAngles.y;
							float y2 = LastSnap.transform.rotation.eulerAngles.y;
							float a = rotationOffset;
							if (Furn.Only180Rotation)
							{
								rotationOffset = ((!(Utilities.AngleDistance(y, y2) < Utilities.AngleDistance(y - 180f, y2))) ? 180 : 0);
							}
							else
							{
								float num = y - y2;
								float a2 = (BuildController.NoGrid() ? num : (Mathf.Round(num / RotationSnap) * RotationSnap));
								float num2 = Utilities.AngleDistance(num, a2);
								rotationOffset = a2;
								if (num2 > 5f && LastSnap.Links.Count > 0)
								{
									foreach (SnapPoint link in LastSnap.Links)
									{
										if (!link.UseForOrientation)
										{
											continue;
										}
										float a3 = Quaternion.LookRotation(link.GetRealPos() - realPos).eulerAngles.y - y2;
										float num3 = Utilities.AngleDistance(num, a3);
										if (num3 < num2)
										{
											rotationOffset = a3;
											num2 = num3;
											if (num3 < 5f)
											{
												break;
											}
										}
									}
								}
							}
							if (!Mathf.Approximately(a, rotationOffset))
							{
								Options.UpdateHint(HintController.Hints.FurnPlaceHintRotateMouseSnap, false);
							}
							base.transform.rotation = Quaternion.Euler(base.transform.rotation.eulerAngles.x, rotationOffset, base.transform.rotation.eulerAngles.z) * LastSnap.transform.rotation;
						}
					}
					else if (OriginalSnap != null)
					{
						SnapPoint[] array = LastSnap.Parent.Parent.GetFurnitures().SelectMany((Furniture z) => z.SnapPoints.Where((SnapPoint x) => IsSnapPointFree(x) && x.Name.Equals(OriginalSnap.Name) && (OriginalSnap.GetRealPos() - x.GetRealPos()).sqrMagnitude < 0.5f)).ToArray();
						if (array.Length > 1)
						{
							Vector2 mousePos2 = BuildController.Instance.GetMousePos(new Plane(Vector3.up, Vector3.up * OriginalSnap.transform.position.y));
							Vector3 vector2 = new Vector3(mousePos2.x, OriginalSnap.transform.position.y, mousePos2.y);
							float a4 = Quaternion.LookRotation(vector2 - OriginalSnap.GetRealPos()).eulerAngles.y;
							foreach (SnapPoint item in array.OrderBy((SnapPoint x) => Mathf.Abs(Mathf.DeltaAngle(x.transform.rotation.eulerAngles.y, a4))))
							{
								Vector3 position = item.transform.position;
								Quaternion q = Quaternion.Euler(0f, rotationOffset, 0f) * item.transform.rotation;
								if (IsValid(Matrix4x4.TRS(position, q, Vector3.one), item.Parent.Parent, item.Parent))
								{
									LastRoom = SnapCheckRoom(item.Parent.Parent, position);
									LastSnap = item;
									base.transform.position = position;
									base.transform.rotation = Quaternion.Euler(base.transform.rotation.eulerAngles.x, rotationOffset, base.transform.rotation.eulerAngles.z) * item.transform.rotation;
									break;
								}
							}
						}
					}
				}
				else if (Furn.CanRotate || Children.Count > 0)
				{
					Vector2 p = BuildController.Instance.GetMousePos(new Plane(Vector3.up, Vector3.up * (GameSettings.Instance.ActiveFloor * 2)));
					Vector2 vector3 = p;
					float y3 = Quaternion.LookRotation(new Vector3(p.x, 0f, p.y) - OriginalPosition).eulerAngles.y;
					float y4 = Quaternion.LookRotation(BuildController.Instance.GridMatrix.MultiplyVector(Vector3.forward)).eulerAngles.y;
					float num4 = (BuildController.NoGrid() ? y3 : (Mathf.Round((y3 + y4) / RotationSnap) * RotationSnap - y4));
					if (!Mathf.Approximately(base.transform.rotation.eulerAngles.y, num4))
					{
						Options.UpdateHint(HintController.Hints.FurnPlaceHintRotateMouse, false);
					}
					base.transform.rotation = Quaternion.Euler(base.transform.rotation.eulerAngles.x, num4, base.transform.rotation.eulerAngles.z);
					if (!BuildController.NoGrid() && !Furn.Type.Equals("Elevator"))
					{
						Quaternion quaternion = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, 0f);
						quaternion = Quaternion.LookRotation(BuildController.Instance.GridMatrix.MultiplyVector(quaternion * new Vector3(0f, 0f, 1f)));
						quaternion = ((!(Furn.OnXEdge ^ Furn.OnYEdge)) ? Quaternion.Euler(0f, Mathf.Round(quaternion.eulerAngles.y / 90f) * 90f, 0f) : Quaternion.Euler(0f, quaternion.eulerAngles.y, 0f));
						bool flag = BuildController.Instance.GridMatrix.MultiplyVector(Vector3.left).magnitude > 1f;
						Vector3 vector4 = quaternion * new Vector3((_shiftGrid ^ (Furn.OnXEdge || flag)) ? 0f : 0.5f, 0f, (_shiftGrid ^ (Furn.OnYEdge || flag)) ? 0f : 0.5f);
						p = BuildController.Instance.CorrectMousePos(finalP, new Vector2(vector4.x, vector4.z));
						bool flag2 = LastRoom != null && LastRoom.Outside;
						LastRoom = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.Floor == GameSettings.Instance.ActiveFloor && ValidIn(Furn, x) == null && x.IsInside(p));
						if (LastRoom == null && flag2)
						{
							LastRoom = GameSettings.Instance.sRoomManager.Outside;
						}
						base.transform.position = new Vector3(p.x, ((LastRoom == null) ? GameSettings.Instance.ActiveFloor : LastRoom.Floor) * 2, p.y);
					}
					DragEnd = null;
					if (Furn.IsDraggable && Children.Count == 0 && Parent == null && (!IsProto || CopyProto))
					{
						int num5 = Mathf.FloorToInt((base.transform.position.FlattenVector3() - vector3).magnitude / Furn.DragDistance);
						if (num5 >= 1)
						{
							DragEnd = vector3;
							Mesh sharedMesh = GetComponent<MeshFilter>().sharedMesh;
							for (int num6 = 1; num6 <= num5; num6++)
							{
								Vector3 pos = base.transform.position + base.transform.forward * num6 * Furn.DragDistance;
								Graphics.DrawMesh(sharedMesh, Matrix4x4.TRS(pos, base.transform.rotation, Vector3.one), UsedMaterial, 0, CameraScript.Instance.mainCam);
							}
						}
						UpdateFullCost();
					}
				}
			}
			if (!BuildController.NoGrid() && (Furn.CanRotate || Children.Count > 0))
			{
				UpdateRotSound();
			}
			return;
		}
		WindowManager.SetCursorOverride("Place");
		string hint = GetHint(Furn.CanRotate, Furn.IsSnapping, IsProto && !CopyProto);
		if (hint != null)
		{
			ErrorOverlay.Instance.ShowError(hint, false, false, 0f, false);
		}
		string text = null;
		if (Furn.IsSnapping)
		{
			Room room = (usePos ? GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.Floor == GameSettings.Instance.ActiveFloor && ValidIn(Furn, x) == null && x.IsInside(base.transform.position.FlattenVector3())) : null);
			Vector2 p2 = (usePos ? base.transform.position.FlattenVector3() : Vector2.zero);
			Room room2 = null;
			bool flag3 = false;
			if (!usePos)
			{
				p2 = BuildController.Instance.GetMousePos(new Plane(Vector3.up, Vector3.up * (GameSettings.Instance.ActiveFloor * 2)));
				Vector2 p3 = BuildController.Instance.GetMousePos(new Plane(Vector3.up, Vector3.up * (GameSettings.Instance.ActiveFloor * 2 + 2)));
				room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.Floor == GameSettings.Instance.ActiveFloor && x.IsInside(p2));
				room2 = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.Floor == GameSettings.Instance.ActiveFloor && x.IsInside(p3));
				if (room == null && room2 == null && Furn.ValidOutside)
				{
					room = GameSettings.Instance.sRoomManager.Outside;
				}
				string text2 = ((room == null) ? null : ValidIn(Furn, room));
				string text3 = ((room2 == null) ? text2 : ValidIn(Furn, room2));
				if (room == null)
				{
					text2 = text3;
				}
				if (text2 != null && text3 != null && text2.Equals(text3))
				{
					ErrorOverlay.Instance.ShowError(text2.Loc(), false, false, 0f, false);
					room = null;
					room2 = null;
					flag3 = true;
				}
				else if (text2 != null)
				{
					room = null;
				}
				else if (text3 != null)
				{
					room2 = null;
				}
			}
			float minD = float.MaxValue;
			LastSnap = null;
			if (room != null)
			{
				UpdateSnap(room.GetAllFurnitureAtriumAndBalconies(GameSettings.Instance.ActiveFloor), usePos, ref minD);
			}
			if (room2 != null && room != room2)
			{
				UpdateSnap(room2.GetAllFurnitureAtriumAndBalconies(GameSettings.Instance.ActiveFloor), usePos, ref minD);
			}
			if (room != null)
			{
				DrawSnaps(room);
			}
			if (room2 != null && room != room2)
			{
				DrawSnaps(room2);
			}
			if (LastSnap != null)
			{
				Vector3 realPos2 = LastSnap.GetRealPos();
				base.transform.position = realPos2;
				if (!usePos && Furn.CanSnapSurface && LastSnap.HasSurface)
				{
					bool flag4 = true;
					Vector2 vector5 = BuildController.Instance.GetMousePos(new Plane(Vector3.up, realPos2));
					if (!InputController.GetKey(InputController.Keys.DisableGrid))
					{
						Vector2 offset = new Vector2(realPos2.x % 1f, realPos2.z % 1f);
						vector5 = BuildController.Instance.CorrectMousePos(vector5, offset);
						if (!LastSnap.IsWithinSurface(vector5.ToVector3(realPos2.y), 0f))
						{
							base.transform.position = LastSnap.transform.position;
							flag4 = false;
						}
					}
					if (flag4)
					{
						base.transform.position = LastSnap.KeepWithinSurface(vector5.ToVector3(realPos2.y), Furn.SurfaceSnapRadius);
					}
				}
				_lastSnapOffset = realPos2.y.GetFloorOffset(LastSnap.Parent.Floor);
				if (!usePos)
				{
					if (Furn.NeedsChair && LastSnap.Links.Count > 0)
					{
						float y5 = LastSnap.transform.rotation.eulerAngles.y;
						float a5 = rotationOffset + y5;
						float num7 = float.MaxValue;
						foreach (SnapPoint link2 in LastSnap.Links)
						{
							if (!link2.UseForOrientation || !(link2.MainUsedBy != null) || !link2.MainUsedBy.Type.Equals("Chair"))
							{
								continue;
							}
							float y6 = Quaternion.LookRotation(link2.GetRealPos() - realPos2).eulerAngles.y;
							float num8 = Utilities.AngleDistance(a5, y6);
							if (num8 < num7)
							{
								rotationOffset = y6 - y5;
								num7 = num8;
								if (num8 < 5f)
								{
									break;
								}
							}
						}
					}
					base.transform.rotation = Quaternion.Euler(0f, rotationOffset, 0f) * LastSnap.transform.rotation;
				}
				else if (!Furn.CanRotate)
				{
					rotationOffset = 0f;
					base.transform.rotation = Quaternion.Euler(0f, rotationOffset, 0f) * LastSnap.transform.rotation;
				}
				UpdateTick();
			}
			if (LastSnap == null)
			{
				if (!Furn.CanNotSnap)
				{
					base.transform.position = new Vector3(p2.x, (float)(GameSettings.Instance.ActiveFloor * 2) + _lastSnapOffset, p2.y);
					if (!flag3)
					{
						string text4 = ("SnapPoint" + Furn.SnapsTo[0]).LocDef(null);
						if (text4 != null)
						{
							ErrorOverlay.Instance.ShowError("FurnitureSnapError2".Loc(text4), false, false, 0f, false);
						}
						else
						{
							ErrorOverlay.Instance.ShowError("FurnitureSnapError");
						}
					}
				}
			}
			else if (Furn.CanRotate)
			{
				if (InputController.GetKeyDown(InputController.Keys.FurnitureClock))
				{
					if (Furn.Only180Rotation)
					{
						rotationOffset = (rotationOffset + 180f) % 360f;
					}
					else
					{
						rotationOffset += RotationSnap;
					}
					base.transform.rotation = Quaternion.Euler(base.transform.rotation.eulerAngles.x, rotationOffset, base.transform.rotation.eulerAngles.z) * LastSnap.transform.rotation;
					Options.UpdateHint(HintController.Hints.FurnPlaceHintRotateKey, false);
				}
				if (InputController.GetKeyDown(InputController.Keys.FurnitureAntiClock))
				{
					if (Furn.Only180Rotation)
					{
						rotationOffset = (rotationOffset + 180f) % 360f;
					}
					else
					{
						rotationOffset -= RotationSnap;
					}
					base.transform.rotation = Quaternion.Euler(base.transform.rotation.eulerAngles.x, rotationOffset, base.transform.rotation.eulerAngles.z) * LastSnap.transform.rotation;
					Options.UpdateHint(HintController.Hints.FurnPlaceHintRotateKey, false);
				}
				if (InputController.GetKeyDown(InputController.Keys.FurnitureRandomRot, false, true))
				{
					rotationOffset = GetRandomRotation(rotationOffset);
					base.transform.rotation = Quaternion.Euler(base.transform.rotation.eulerAngles.x, rotationOffset, base.transform.rotation.eulerAngles.z) * LastSnap.transform.rotation;
				}
				UpdateRotSound();
			}
		}
		if (Furn.IsSnapping && (!Furn.CanNotSnap || !(LastSnap == null)))
		{
			return;
		}
		if (Furn.CanRotate || Children.Count > 0)
		{
			if (InputController.GetKeyDown(InputController.Keys.FurnitureClock))
			{
				base.transform.rotation = GetFurnitureRotation() * Quaternion.Euler(0f, RotationSnap, 0f);
				Options.UpdateHint(HintController.Hints.FurnPlaceHintRotateKey, false);
			}
			if (InputController.GetKeyDown(InputController.Keys.FurnitureAntiClock))
			{
				base.transform.rotation = GetFurnitureRotation() * Quaternion.Euler(0f, 0f - RotationSnap, 0f);
				Options.UpdateHint(HintController.Hints.FurnPlaceHintRotateKey, false);
			}
			if (InputController.GetKeyDown(InputController.Keys.FurnitureRandomRot, false, true))
			{
				base.transform.rotation = Quaternion.Euler(0f, GetRandomRotation(base.transform.rotation.eulerAngles.y), 0f);
			}
			UpdateRotSound();
		}
		Vector2 vector6 = (usePos ? base.transform.position.FlattenVector3() : Vector2.zero);
		if (!usePos)
		{
			bool flag5 = false;
			if (Furn.Type.Equals("Elevator"))
			{
				Vector2 mousePos3 = BuildController.Instance.GetMousePos(new Plane(Vector3.up, Vector3.up * (GameSettings.Instance.ActiveFloor * 2)));
				Vector3 pp = new Vector3(mousePos3.x, GameSettings.Instance.ActiveFloor * 2 + 2, mousePos3.y);
				Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(pp);
				if (roomFromPoint != null)
				{
					Furniture furniture = roomFromPoint.GetFurnitureInAtrium("Elevator").FirstOrDefault((Furniture x) => (x.transform.position - pp).sqrMagnitude < 0.8f);
					if (furniture != null)
					{
						vector6 = (finalP = new Vector2(furniture.OriginalPosition.x, furniture.OriginalPosition.z));
						flag5 = true;
					}
				}
				pp = new Vector3(mousePos3.x, GameSettings.Instance.ActiveFloor * 2 - 2, mousePos3.y);
				roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(pp);
				if (roomFromPoint != null)
				{
					Furniture furniture2 = roomFromPoint.GetFurnitureInAtrium("Elevator").FirstOrDefault((Furniture x) => (x.transform.position - pp).sqrMagnitude < 0.8f);
					if (furniture2 != null)
					{
						vector6 = (finalP = new Vector2(furniture2.OriginalPosition.x, furniture2.OriginalPosition.z));
						flag5 = true;
					}
				}
			}
			if (!flag5)
			{
				finalP = BuildController.Instance.GetMousePos(new Plane(Vector3.up, Vector3.up * (GameSettings.Instance.ActiveFloor * 2)));
				Quaternion quaternion2 = Quaternion.Euler(0f, Quaternion.LookRotation(BuildController.Instance.GridMatrix.MultiplyVector(GetFurnitureRotation() * new Vector3(0f, 0f, 1f))).eulerAngles.y, 0f);
				bool flag6 = BuildController.Instance.GridMatrix.MultiplyVector(Vector3.left).magnitude > 1f;
				Vector3 vector7 = quaternion2 * new Vector3((_shiftGrid ^ (Furn.OnXEdge || flag6)) ? 0f : 0.5f, 0f, (_shiftGrid ^ (Furn.OnYEdge || flag6)) ? 0f : 0.5f);
				vector6 = (BuildController.NoGrid() ? finalP : BuildController.Instance.CorrectMousePos(finalP, new Vector2(vector7.x, vector7.z)));
			}
			base.transform.position = new Vector3(vector6.x, GameSettings.Instance.ActiveFloor * 2, vector6.y);
		}
		if (LastRoom == null || !LastRoom.IsStrictlyInside(vector6) || (LastRoom.Outside && GameSettings.Instance.sRoomManager.GetRoomFromPoint(0, vector6) != LastRoom) || LastRoom.Floor != GameSettings.Instance.ActiveFloor)
		{
			LastRoom = GetBestRoom(GameSettings.Instance.ActiveFloor, vector6, Furn, base.transform);
			if (LastRoom != null)
			{
				text = ValidIn(Furn, LastRoom);
				if (text != null)
				{
					LastRoom = null;
					ErrorOverlay.Instance.ShowError(text);
				}
			}
		}
		if (!BuildController.NoGrid() && LastRoom != null && text == null)
		{
			UpdateTick();
		}
		if (LastRoom == null && text == null)
		{
			ErrorOverlay.Instance.ShowError(GetFirstValid(Furn));
		}
	}

	private string GetFirstValid(Furniture f)
	{
		if (f.ValidIndoors)
		{
			return "IndoorError";
		}
		if (f.ValidOutdoors)
		{
			return "OutdoorError";
		}
		if (f.ValidOutside)
		{
			if (GameSettings.Instance.ActiveFloor <= 0)
			{
				return "OutsideError";
			}
			return "GroundFloorOutsideError";
		}
		return "FurnitureInRoom";
	}

	private bool RecurseSnap(SnapPoint s)
	{
		while (s != null)
		{
			if (s.Parent == Furn)
			{
				return false;
			}
			s = s.Parent.SnappedTo;
		}
		return true;
	}

	private void UpdateSnap(IEnumerable<Furniture> furns, bool usePos, ref float minD)
	{
		foreach (Furniture furn in furns)
		{
			if (IsProto && !CopyProto && !(furn != Furn))
			{
				continue;
			}
			for (int i = 0; i < furn.SnapPoints.Length; i++)
			{
				SnapPoint snapPoint = furn.SnapPoints[i];
				if (!IsSnapPointFree(snapPoint) || !Furn.DoesSnapTo(snapPoint.Name) || (IsProto && !CopyProto && !RecurseSnap(snapPoint)))
				{
					continue;
				}
				Vector3 vector = base.transform.position;
				Vector3 vector2 = snapPoint.GetRealPos();
				Vector3 pos = vector2;
				float num = BuildController.GetSnapDistance();
				if (!usePos)
				{
					vector = Input.mousePosition;
					vector2 = CameraScript.Instance.SSAScript.WorldToScreenPoint(vector2);
					num = 48f / vector2.z * 48f;
					vector2 = new Vector3(vector2.x, vector2.y, 0f);
				}
				float magnitude = (vector - vector2).magnitude;
				if (magnitude <= num && magnitude < minD)
				{
					Quaternion q = Quaternion.Euler(0f, rotationOffset, 0f) * snapPoint.transform.rotation;
					if (snapPoint.SuspendValidCheck(Furn) || IsValid(Matrix4x4.TRS(pos, q, Vector3.one), snapPoint.Parent.Parent, snapPoint.Parent, false, null, false, true))
					{
						LastRoom = SnapCheckRoom(snapPoint.Parent.Parent, snapPoint.pos);
						LastSnap = snapPoint;
						minD = magnitude;
					}
				}
			}
		}
	}

	public static Room GetBestRoom(int floor, Vector2 p, Furniture furn, Transform trans, bool validOutside = false)
	{
		return GetBestRoom(floor, p, furn, (trans == null) ? furn.transform.localToWorldMatrix : trans.localToWorldMatrix, validOutside);
	}

	public static Room GetBestRoom(int floor, Vector2 p, Furniture furn, Matrix4x4 trans, bool validOutside = false)
	{
		BestRoomCache.Clear();
		for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[i];
			if (room.Floor == floor && room.IsInside(p, -0.01f))
			{
				BestRoomCache.Add(room);
			}
		}
		if (BestRoomCache.Count == 0)
		{
			return GetOutside(null, floor, furn, validOutside);
		}
		if (BestRoomCache.Count == 1)
		{
			return GetOutside(BestRoomCache[0], floor, furn, validOutside);
		}
		p = furn.GetMeanPos(trans);
		for (int j = 0; j < BestRoomCache.Count; j++)
		{
			Room room2 = BestRoomCache[j];
			if (room2.IsInside(p))
			{
				return room2;
			}
		}
		return GetOutside(BestRoomCache[0], floor, furn, validOutside);
	}

	private static Room GetOutside(Room r, int floor, Furniture furn, bool validOutside = false)
	{
		if (r == null && floor == 0 && (furn.ValidOutside || validOutside))
		{
			return GameSettings.Instance.sRoomManager.Outside;
		}
		return r;
	}

	private void UpdateRotSound()
	{
		if (Parent == null)
		{
			float y = base.transform.rotation.eulerAngles.y;
			if (Mathf.Abs(LastRot - y) > 1f)
			{
				UISoundFX.PlaySFX("FurnRotate", true);
			}
			LastRot = y;
		}
	}

	private bool OpenAngle(Vector2 a, Vector2 b, Vector2 c)
	{
		return b.FullAngleBetween(a, c) >= 179.999f;
	}

	private void WallBuildCode(Room rr, bool usePos)
	{
		bool flag = Furn.OnXEdge ^ _shiftGrid;
		Vector2 vector = (usePos ? base.transform.position.FlattenVector3() : BuildController.Instance.GetMousePos(new Plane(Vector3.up, Vector3.up * ((float)(GameSettings.Instance.ActiveFloor * 2) + Furn.YOffset))));
		Vector2 vector2 = ((usePos || BuildController.NoGrid()) ? vector : BuildController.Instance.CorrectMousePos(vector, !flag, Furn.GridSizeOverride));
		IList<Room> list2;
		if (!(rr == null))
		{
			IList<Room> list = new Room[1] { rr };
			list2 = list;
		}
		else
		{
			IList<Room> list = GameSettings.Instance.sRoomManager.Rooms;
			list2 = list;
		}
		IList<Room> list3 = list2;
		edge1 = null;
		edge2 = null;
		if (!usePos)
		{
			base.transform.position = new Vector3(vector.x, (float)(GameSettings.Instance.ActiveFloor * 2) + (Furn.CustomHeight ? Furn.WallHeight : 0f), vector.y);
		}
		float num = Furn.WallWidth / 2f;
		float num2 = num + (wasReversed ? 0f : (Room.WallOffset / 2f));
		float num3 = ((!usePos && Furn.CustomHeight) ? 4f : 1f);
		float num4 = 50000f;
		LastRoom = null;
		Ray ray = CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition);
		for (int i = 0; i < list3.Count; i++)
		{
			Room room = list3[i];
			if (room.Floor != GameSettings.Instance.ActiveFloor)
			{
				continue;
			}
			if (usePos || !Furn.CustomHeight)
			{
				if (!room.IsInside(vector, -0.01f))
				{
					continue;
				}
			}
			else if (!room.IsInsideBounds(vector, 16f))
			{
				continue;
			}
			if ((room.Outdoors && !Furn.ValidOutdoors) || (Furn.OnlyOnGrass && !"None".Equals(room.FloorMat) && !room.Outside))
			{
				continue;
			}
			for (int j = 0; j < room.Edges.Count; j++)
			{
				WallEdge a = room.Edges[j];
				WallEdge wallEdge = room.Edges[(j + 1) % room.Edges.Count];
				WallEdge wallEdge2 = ((j == 0) ? room.Edges.Last() : room.Edges[j - 1]);
				WallEdge wallEdge3 = room.Edges[(j + 2) % room.Edges.Count];
				Plane plane = new Plane((wallEdge.Pos - a.Pos).normalized.Turn90().ToVector3(0f), a.Pos.ToVector3(0f));
				bool flag2 = GameSettings.Instance.ActiveFloor >= 0 && Furn.ValidOutside && !plane.GetSide(ray.GetPoint(0f)) && !wallEdge.Links.ContainsValue(a);
				WallEdge wallEdge4 = a;
				WallEdge wallEdge5 = wallEdge;
				if (!Furn.PokesThroughWall)
				{
					wallEdge4 = a.FindNextColinear(room, true, flag2);
					wallEdge5 = a.FindNextColinear(room, false, flag2);
				}
				if (wallEdge4.Pos.Dist(wallEdge5.Pos) < num2 * 2f)
				{
					continue;
				}
				if (Furn.OnlyExteriorWalls)
				{
					if (wallEdge.Links.ContainsValue(a) && (!Furn.ValidAgainstOutdoorArea || (!room.Outdoors && !wallEdge.Links.First((KeyValuePair<IRoom, WallEdge> x) => x.Value == a).Key.Outdoors)))
					{
						continue;
					}
				}
				else if (Furn.OnlyInteriorWalls && (room.Outdoors || !wallEdge.Links.ContainsValue(a) || wallEdge.Links.First((KeyValuePair<IRoom, WallEdge> x) => x.Value == a).Key.Outdoors))
				{
					continue;
				}
				float num5 = 0f;
				Vector2 vector3 = vector;
				Vector2 p = vector2;
				float? num6 = null;
				if (!usePos && Furn.CustomHeight)
				{
					float enter;
					if ((!plane.GetSide(ray.GetPoint(0f)) && wallEdge.Links.ContainsValue(a)) || !plane.Raycast(ray, out enter))
					{
						continue;
					}
					num5 = ray.GetPoint(enter).y;
					if (num5 < (float)(GameSettings.Instance.ActiveFloor * 2) || num5 > (float)(GameSettings.Instance.ActiveFloor * 2 + 2))
					{
						continue;
					}
					num6 = enter;
					vector3 = BuildController.Instance.GetMousePos(new Plane(Vector3.up, Vector3.up * num5));
					p = (BuildController.NoGrid() ? vector3 : BuildController.Instance.CorrectMousePos(vector3, !flag, Furn.GridSizeOverride));
				}
				Vector2 res;
				if (!Utilities.ProjectToLine(vector3, a.Pos, wallEdge.Pos, out res))
				{
					continue;
				}
				float num7 = res.Dist(vector3);
				Vector2 res2;
				if (!(num7 < num3) || (!(num4 > 40000f) && (!num6.HasValue || !(num6.Value < num4))) || !Utilities.ProjectToLine(p, a.Pos, wallEdge.Pos, out res2))
				{
					continue;
				}
				float num8 = (OpenAngle(wallEdge2.Pos, a.Pos, wallEdge.Pos) ? num : num2);
				if (res2.Dist(wallEdge4.Pos) < num8)
				{
					res2 = wallEdge4.Pos + (wallEdge5.Pos - wallEdge4.Pos).normalized * num8;
				}
				num8 = (OpenAngle(a.Pos, wallEdge.Pos, wallEdge3.Pos) ? num : num2);
				if (res2.Dist(wallEdge5.Pos) < num8)
				{
					res2 = wallEdge5.Pos + (wallEdge4.Pos - wallEdge5.Pos).normalized * num8;
				}
				Vector2 pos = res2;
				float heightOff = 0f;
				if (Furn.CustomHeight)
				{
					if (!usePos)
					{
						heightOff = num5 - (float)(GameSettings.Instance.ActiveFloor * 2);
						if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
						{
							heightOff = Mathf.Clamp(heightOff, Furn.GetValidHeight(0), Furn.GetValidHeight(1));
						}
						else
						{
							heightOff = Furn.ValidHeights.MinInstance((float x) => Mathf.Abs(x - heightOff));
						}
					}
					else if (Parent != null && Parent.Furn.CustomHeight)
					{
						float num9 = Furn.transform.position.y.GetFloorOffset(Furn.Floor) - Parent.Furn.transform.position.y.GetFloorOffset(Parent.Furn.Floor);
						heightOff = Mathf.Clamp(num9 + Parent.transform.position.y.GetFloorOffset(Mathf.FloorToInt(Parent.transform.position.y / 2f)), Furn.GetValidHeight(0), Furn.GetValidHeight(1));
					}
					else
					{
						heightOff = Furn.WallHeight;
					}
				}
				if (a.ValidSegment(ref pos, ref heightOff, Furn.WallWidth, wallEdge, !Furn.PokesThroughWall, Furn.IsConnecter, flag2 ^ Furn.ReverseWallSide, true, Furn.ValidOnFence, Furn.Height1, Furn.Height2, false, res.x - pos.x, res.y - pos.y, false, null, Furn.CustomHeight, Furn.GetValidHeight(0), Furn.GetValidHeight(1)))
				{
					wasReversed = flag2;
					num3 = num7;
					if (num6.HasValue)
					{
						num4 = num6.Value;
					}
					base.transform.position = new Vector3(pos.x, (float)(GameSettings.Instance.ActiveFloor * 2) + heightOff, pos.y);
					Vector2 vector4 = wallEdge.Pos - a.Pos;
					base.transform.rotation = Quaternion.LookRotation(new Vector3(0f - vector4.y, 0f, vector4.x));
					if (wasReversed)
					{
						base.transform.rotation = Quaternion.Euler(0f, 180f, 0f) * base.transform.rotation;
					}
					edge1 = a;
					edge2 = wallEdge;
					WallPosition = a.Pos.Dist(pos) / a.Pos.Dist(wallEdge.Pos);
					LastRoom = room;
				}
			}
			if (!BuildController.NoGrid() && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl) && edge1 != null)
			{
				UpdateTick();
				break;
			}
		}
		if (LastRoom == null)
		{
			ErrorOverlay.Instance.ShowError(Furn.OnlyExteriorWalls ? "ExteriorWallFurn" : "FurnitureOnWall");
		}
	}

	private string GetHint(bool rotate, bool snap, bool move)
	{
		return null;
	}

	private static bool IsValidIn(Furniture furn, Room room)
	{
		if (room.Outside)
		{
			return furn.ValidOutside;
		}
		if (furn.OnlyOnGrass)
		{
			return "None".Equals(room.FloorMat);
		}
		if (!room.Outdoors)
		{
			return furn.ValidIndoors;
		}
		return furn.ValidOutdoors;
	}

	private string ValidIn(Furniture furn, Room room)
	{
		if (room.Outside)
		{
			if (furn.ValidOutside)
			{
				return null;
			}
			SetError(null);
			if (!furn.ValidIndoors)
			{
				return "OutdoorError";
			}
			return "IndoorError";
		}
		if (furn.OnlyOnGrass)
		{
			if ("None".Equals(room.FloorMat))
			{
				return null;
			}
			SetError(null);
			return "GrassBuildError";
		}
		if (room.Outdoors)
		{
			if (furn.ValidOutdoors)
			{
				return null;
			}
			SetError(null);
			if (!furn.ValidIndoors)
			{
				return "OutsideError";
			}
			return "IndoorError";
		}
		if (furn.ValidIndoors)
		{
			return null;
		}
		SetError(null);
		if (!furn.ValidOutdoors)
		{
			return "OutsideError";
		}
		return "OutdoorError";
	}

	private bool CheckAllValid(bool doubleCheck = true)
	{
		if (CheckBasement() && CheckRoadConnection() && (!Furn.WallFurn || edge1 != null) && (!Furn.IsSnapping || Furn.CanNotSnap || (LastSnap != null && LastSnap.CheckCollisions(base.transform.position.FlattenVector3(), Furn.SurfaceSnapRadius, Furn, this))) && LastRoom != null && (IsValid(Matrix4x4.TRS(base.transform.position, GetFurnitureRotation(), Vector3.one), LastRoom, (LastSnap != null) ? LastSnap.Parent : null, false, null, false, LastSnap != null) || (doubleCheck && DoubleCheck())) && (!Furn.TwoFloors || IsValid(Matrix4x4.TRS(base.transform.position, GetFurnitureRotation(), Vector3.one), GetBestRoom(LastRoom.Floor + 1, base.transform.position.FlattenVector3(), Furn, base.transform), null, false, null, true)) && (!Furn.PokesThroughRoof || IsValid(Matrix4x4.TRS(base.transform.position, GetFurnitureRotation(), Vector3.one), GetBestRoom(LastRoom.Floor + 1, base.transform.position.FlattenVector3(), Furn, base.transform, true), null, true, GameSettings.Instance.ActiveFloor + 1)))
		{
			return CheckThroughWallRoom();
		}
		return false;
	}

	private bool CheckRoadConnection()
	{
		if (Furn.NeedsRoadConnection && (GameSettings.Instance.ActiveFloor < 0 || GameSettings.Instance.ActiveFloor % 2 == 1 || GameSettings.Instance.ActiveFloor / 2 >= RoadManager.Floors))
		{
			ErrorOverlay.Instance.ShowError("FurnitureRoadConnectionError");
			return false;
		}
		return true;
	}

	private bool CheckThroughWallRoom()
	{
		if (Furn.WallFurn && Furn.PokesThroughWall && edge1 != null && edge2 != null)
		{
			Room room = edge2.GetRoom(edge1);
			if (room != null)
			{
				return IsValid(Matrix4x4.TRS(base.transform.position, GetFurnitureRotation(), Vector3.one), room);
			}
			if (GameSettings.Instance.ActiveFloor == 0)
			{
				return IsValid(Matrix4x4.TRS(base.transform.position, GetFurnitureRotation(), Vector3.one), GameSettings.Instance.sRoomManager.Outside);
			}
		}
		return true;
	}

	private bool CheckAllValid(Vector3 rPos)
	{
		if (!Furn.WallFurn && !Furn.IsSnapping && !Furn.TwoFloors && !Furn.PokesThroughRoof && CheckBasement())
		{
			if (LastRoom != null)
			{
				return IsValid(Matrix4x4.TRS(rPos, GetFurnitureRotation(), Vector3.one), LastRoom, (LastSnap != null) ? LastSnap.Parent : null);
			}
			return false;
		}
		return false;
	}

	private void UpdateTick()
	{
		if (base.transform.position != LastPos)
		{
			UISoundFX.PlaySFX("Tick", true);
		}
		LastPos = base.transform.position;
	}

	private void RefreshElevators(Room r)
	{
		if (!(Parent == null) || !(Furn != null) || !"Elevator".Equals(Furn.Type))
		{
			return;
		}
		_elevatorCount = 0;
		if (r == null || r.Outside)
		{
			return;
		}
		for (int i = 0; i < GameSettings.Instance.sRoomManager.AllFurniture.Count; i++)
		{
			Furniture furniture = GameSettings.Instance.sRoomManager.AllFurniture[i];
			if (Mathf.Abs(Mathf.FloorToInt((furniture.OriginalPosition.y + 0.5f) / 2f) - GameSettings.Instance.ActiveFloor) != 1 || !"Elevator".Equals(furniture.Type) || furniture.Capacity != Furn.Capacity || !furniture.MiscPotential.Appx(Furn.MiscPotential))
			{
				continue;
			}
			bool flag = true;
			List<PathNode<Vector3>> connections = furniture.pathNode.GetConnections();
			for (int j = 0; j < connections.Count; j++)
			{
				Furniture furniture2 = connections[j].Tag as Furniture;
				if (furniture2 != null && furniture2.Parent == r)
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				continue;
			}
			Vector2 vector = furniture.OriginalPosition.FlattenVector3();
			if (r.IsInside(vector))
			{
				_elevatorPos[_elevatorCount] = Matrix4x4.TRS(vector.ToVector3(GameSettings.Instance.ActiveFloor * 2), furniture.transform.rotation, Vector3.one);
				_elevatorCount++;
				if (_elevatorCount == _elevatorPos.Length)
				{
					break;
				}
			}
		}
	}

	private void CheckShortcutPanel()
	{
		if (Parent == null && HUD.Instance != null)
		{
			HUD.Instance.ShortcutPanel.Hide();
		}
	}

	private void RefreshAutoPlaceData()
	{
		UpdateFullCost();
		if (_lastAutoPlaceRoom != null)
		{
			FurnitureAutoPlacement.PlacementAlgorithm placementAlgorithm = FurnitureAutoPlacement.AutoPlacementFunctions[Furn.AutoPlaceGroup[_autoPlaceAlgo]];
			BuildController.Instance.SetAutoPlace(placementAlgorithm.LocName, _autoPlaceAlgo, Furn.AutoPlaceGroup.Length);
			GetComponent<MeshRenderer>().enabled = false;
			_autoPlacePos = _lastAutoPlace.SelectInPlace((FurnitureAutoPlacement.PlacementData x) => Matrix4x4.TRS(x.P, x.R, Vector3.one));
		}
		else
		{
			BuildController.Instance.SetAutoPlace(null);
			GetComponent<MeshRenderer>().enabled = true;
			_autoPlacePos = null;
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (!feetInit)
		{
			feetInit = true;
			if (Parent == null)
			{
				FootPrintController.Initialize(this);
			}
		}
		if (IsProto && (FurnPrefab == null || Furn == null))
		{
			CheckShortcutPanel();
			WindowManager.SetCursorOverride(null);
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		if (Parent != null)
		{
			SetMaterial(Parent.UsedMaterial);
			return;
		}
		if (InputController.GetKeyDown(InputController.Keys.ShowFurnitureInfluence))
		{
			_interactionDistance = !_interactionDistance;
			if (!_interactionDistance)
			{
				UpdateDist(null);
				FurnitureInfluenceDrawer.Instance.Disable();
			}
		}
		if (_interactionDistance)
		{
			if (!FurnitureInfluenceDrawer.Instance.Set(Furn.Type, Furn.WallFurn ? (base.transform.position + base.transform.forward * 0.3f) : base.transform.position))
			{
				UpdateDist(null);
				FurnitureInfluenceDrawer.Instance.Disable();
			}
			else
			{
				UpdateDist(LastRoom);
			}
		}
		if (!_fullCost.HasValue)
		{
			UpdateFullCost();
		}
		if (InputController.GetKeyDown(InputController.Keys.ShiftGrid))
		{
			_shiftGrid = !_shiftGrid;
		}
		if (rotationCountDown >= 0f)
		{
			rotationCountDown -= Time.deltaTime;
		}
		if (!_turnMouseMoved && Input.mousePosition != _beforeTurnMousePos)
		{
			_turnMouseMoved = true;
		}
		if (!CameraScript.WasDragging && !FloorGizmo.IsMoving && Input.GetMouseButtonUp(1))
		{
			HUD.Instance.TempPanel.SetRoom(null, null);
			CheckShortcutPanel();
			WindowManager.SetCursorOverride(null);
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		if (_elevatorCount > 0)
		{
			if (SystemInfo.supportsInstancing)
			{
				Graphics.DrawMeshInstanced(ElevatorIndicatorMesh, 0, ElevatorIndicatorMat, _elevatorPos, _elevatorCount);
			}
			else
			{
				for (int i = 0; i < _elevatorCount; i++)
				{
					Graphics.DrawMesh(ElevatorIndicatorMesh, _elevatorPos[i], ElevatorIndicatorMat, 0, CameraScript.Instance.mainCam);
				}
			}
		}
		if (!GameSettings.Instance.RentMode && !Furn.TemperatureController && Furn.EqualizeTemperature && Furn.TempControlType != Furniture.TemperatureType.None)
		{
			Room room = LastRoom;
			if (Time.realtimeSinceStartup - _lastPlaced < 2f)
			{
				if (room == null)
				{
					room = _lastPlacedRoom;
				}
				else if (room != _lastPlacedRoom)
				{
					_lastPlacedRoom = null;
				}
			}
			HUD.Instance.TempPanel.SetRoom(room, (!Furn.TemperatureController) ? Furn : null);
		}
		else
		{
			HUD.Instance.TempPanel.SetRoom(null, null);
		}
		if (InputController.GetKey(InputController.Keys.AutoPlaceFurniture) && CanAutoPlace())
		{
			int num = (int)Input.mouseScrollDelta.y;
			if (num != 0 && Furn.AutoPlaceGroup.Length > 1)
			{
				_autoPlaceAlgo += num;
				if (_autoPlaceAlgo < 0)
				{
					_autoPlaceAlgo = Furn.AutoPlaceGroup.Length - 1;
				}
				else if (_autoPlaceAlgo >= Furn.AutoPlaceGroup.Length)
				{
					_autoPlaceAlgo = 0;
				}
				_lastAutoPlaceRoom = null;
			}
			Vector2 mousePos = BuildController.Instance.GetMousePos(new Plane(Vector3.up, Vector3.up * GameSettings.Instance.ActiveFloor * 2f));
			base.transform.position = mousePos.ToVector3((float)GameSettings.Instance.ActiveFloor * 2f);
			Room room2 = GameSettings.Instance.sRoomManager.GetRoomFromPoint(GameSettings.Instance.ActiveFloor, mousePos);
			if (_lastAutoPlaceRoom == null || _lastAutoPlaceRoom != room2)
			{
				if (room2 == null || room2.Outside)
				{
					_lastAutoPlace = new List<FurnitureAutoPlacement.PlacementData>();
				}
				else
				{
					if (room2.IsUpperAtriumNotBalcony)
					{
						room2 = room2.GetMainAtriumParentOrSelf();
					}
					FurnitureAutoPlacement.PlacementAlgorithm placementAlgorithm = FurnitureAutoPlacement.AutoPlacementFunctions[Furn.AutoPlaceGroup[_autoPlaceAlgo]];
					_lastAutoPlace = placementAlgorithm.F(Furn, room2, Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, 0f));
				}
				_lastAutoPlaceRoom = room2;
				RefreshAutoPlaceData();
			}
			if (_lastAutoPlace.Count == 0)
			{
				ErrorOverlay.Instance.ShowError("AutoPlaceFurnitureError");
				SetError(null);
			}
		}
		else if (Furn.WallFurn)
		{
			if (_lastAutoPlaceRoom != null)
			{
				_lastAutoPlaceRoom = null;
				RefreshAutoPlaceData();
			}
			WallBuildCode(null, false);
		}
		else
		{
			if (_lastAutoPlaceRoom != null)
			{
				_lastAutoPlaceRoom = null;
				RefreshAutoPlaceData();
			}
			if (!Furn.IsSnapping && Furn.CanRotate && LastRoom != null && !LastRoom.Outside && InputController.GetKeyDown(InputController.Keys.AlignNearest))
			{
				bool flag = false;
				Vector2 vector = base.transform.position.FlattenVector3();
				float num2 = 25f;
				Vector2 vector2 = Vector2.zero;
				Vector2 vector3 = Vector2.zero;
				for (int j = 0; j < LastRoom.Edges.Count; j++)
				{
					WallEdge wallEdge = LastRoom.Edges[j];
					WallEdge wallEdge2 = LastRoom.Edges[(j + 1) % LastRoom.Edges.Count];
					Vector2 res;
					if (Utilities.ProjectToLine(vector, wallEdge.Pos, wallEdge2.Pos, out res))
					{
						float sqrMagnitude = (vector - res).sqrMagnitude;
						if (sqrMagnitude < num2)
						{
							flag = true;
							num2 = sqrMagnitude;
							vector2 = wallEdge.Pos;
							vector3 = wallEdge2.Pos;
						}
					}
				}
				if (flag)
				{
					Options.UpdateHint(HintController.Hints.FurnPlaceHintAlign, false);
					if ((vector3 - vector).sqrMagnitude < (vector2 - vector).sqrMagnitude)
					{
						BuildController.Instance.SetTempGrid(vector3, vector2, true);
					}
					else
					{
						BuildController.Instance.SetTempGrid(vector2, vector3, false);
					}
					ResetRotation();
				}
			}
			NormalBuildCode(false);
		}
		if (_autoPlacePos != null)
		{
			Mesh sharedMesh = GetComponent<MeshFilter>().sharedMesh;
			if (SystemInfo.supportsInstancing)
			{
				Graphics.DrawMeshInstanced(sharedMesh, 0, GreenInstant, _autoPlacePos, _autoPlacePos.Length);
			}
			else
			{
				for (int k = 0; k < _autoPlacePos.Length; k++)
				{
					Graphics.DrawMesh(sharedMesh, _autoPlacePos[k], GreenInstant, 0, CameraScript.Instance.mainCam);
				}
			}
		}
		double num3 = PriceOverride ?? ((double)_fullCost.Value);
		if (num3 > 0.0)
		{
			CostDisplay.Instance.Show(num3, base.transform.position + Vector3.up * 2.5f, (GameSettings.Instance.MyCompany.Money >= num3) ? Color.white : Color.red);
		}
		bool flag2 = GameSettings.Instance.MyCompany.CanMakeTransaction(0.0 - num3) && CheckAllValid();
		SetMaterial(flag2 ? Green : Red);
		if (!FloorGizmo.IsMoving && _lastAutoPlaceRoom == null && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			rotationCountDown = 0.2f;
			TurnMode = true;
			OriginalPosition = base.transform.position;
			OriginalSnap = LastSnap;
			_beforeTurnMousePos = Input.mousePosition;
			_turnMouseMoved = false;
		}
		if (Input.GetMouseButtonUp(0))
		{
			if (_lastAutoPlaceRoom != null)
			{
				if (_lastAutoPlace.Count > 0)
				{
					List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
					double num4 = 0.0;
					for (int l = 0; l < _lastAutoPlace.Count; l++)
					{
						FurnitureAutoPlacement.PlacementData placementData = _lastAutoPlace[l];
						bool inventory;
						Furniture furniture = MakeFurn(placementData.P, placementData.R, _lastAutoPlaceRoom, placementData.E1, placementData.E2, placementData.WallPos, false, placementData.Snap, FurnPrefab, 0f, false, out inventory);
						if (!(furniture == null))
						{
							list.Add(new UndoObject.UndoAction(furniture, true, inventory));
							num4 += (inventory ? 0.0 : ((double)furniture.GetCost()));
						}
					}
					CostDisplay.Instance.FloatAway(num4);
					UISoundFX.PlaySFX("Kaching");
					if (list.Count > 0)
					{
						GameSettings.Instance.AddUndo(list.ToArray());
					}
					Action onBuild = OnBuild;
					if (onBuild != null)
					{
						onBuild();
					}
					if (!BuildController.PlaceMulti())
					{
						CheckShortcutPanel();
						WindowManager.SetCursorOverride(null);
						UnityEngine.Object.Destroy(base.gameObject);
					}
					else
					{
						Options.UpdateHint(HintController.Hints.FurnPlaceHintMultiple, false);
						UpdateFullCost();
					}
					_lastAutoPlaceRoom = null;
					RefreshAutoPlaceData();
				}
				else
				{
					UISoundFX.PlaySFX("BuildError");
				}
			}
			else if (TurnMode)
			{
				TurnMode = false;
				if (flag2)
				{
					_lastPlacedRoom = LastRoom;
					_lastPlaced = Time.realtimeSinceStartup;
					List<UndoObject.UndoAction> list2 = new List<UndoObject.UndoAction>();
					if (IsProto && !CopyProto && Children.Count > 0)
					{
						base.transform.rotation = GetFurnitureRotation();
						foreach (FurnitureBuilder child in Children)
						{
							child.transform.parent.SetParent(null, true);
							if (child.Furn.WallFurn)
							{
								child.WallBuildCode(LastRoom, true);
							}
							else
							{
								child.NormalBuildCode(true);
							}
						}
						List<FurnitureBuilder> list3 = new List<FurnitureBuilder>(Children);
						list3.Add(this);
						bool flag3 = true;
						HashSet<SnapPoint> hashSet = new HashSet<SnapPoint>();
						while (flag3)
						{
							hashSet.Clear();
							flag3 = false;
							for (int m = 0; m < list3.Count; m++)
							{
								FurnitureBuilder furnitureBuilder = list3[m];
								if (!furnitureBuilder.CheckAllValid(false))
								{
									furnitureBuilder.MakeAllIgnored(false);
									flag3 = true;
									list3.RemoveAt(m);
									m--;
								}
								else if (IsProto && !CopyProto && furnitureBuilder.Furn.IsSnapping && furnitureBuilder.LastSnap != null && hashSet.Contains(furnitureBuilder.LastSnap))
								{
									furnitureBuilder.MakeAllIgnored(false);
									flag3 = true;
									list3.RemoveAt(m);
									m--;
								}
								else if (furnitureBuilder.Furn.IsSnapping && furnitureBuilder.LastSnap != null)
								{
									hashSet.Add(furnitureBuilder.LastSnap);
								}
							}
						}
						double num5 = 0.0;
						foreach (FurnitureBuilder item in list3)
						{
							num5 += item.FinalBuild(list2);
						}
						if (CopyProto && num5 > 0.0)
						{
							CostDisplay.Instance.FloatAway(num5);
							UISoundFX.PlaySFX("Kaching");
						}
						UISoundFX.PlaySFX("PlaceFurniture", true);
					}
					else
					{
						double num6 = FinalBuild(list2);
						Quaternion rotation = base.transform.rotation;
						base.transform.rotation = GetFurnitureRotation();
						if (DragEnd.HasValue)
						{
							int num7 = Mathf.FloorToInt((base.transform.position.FlattenVector3() - DragEnd.Value).magnitude / Furn.DragDistance);
							if (num7 >= 1)
							{
								for (int n = 1; n <= num7; n++)
								{
									Vector3 vector4 = base.transform.position + base.transform.forward * n * Furn.DragDistance;
									if (CheckAllValid(vector4))
									{
										num6 += FinalBuild(list2, vector4);
									}
								}
							}
							DragEnd = null;
						}
						foreach (FurnitureBuilder child2 in Children)
						{
							Vector3 position = child2.transform.position;
							child2.transform.parent.SetParent(null, true);
							if (child2.Furn.WallFurn)
							{
								child2.WallBuildCode(LastRoom, true);
							}
							else
							{
								child2.NormalBuildCode(true);
							}
							if (child2.CheckAllValid())
							{
								num6 += child2.FinalBuild(list2);
							}
							child2.transform.parent.SetParent(base.transform, false);
							child2.transform.position = position;
						}
						if (num6 > 0.0)
						{
							CostDisplay.Instance.FloatAway(num6);
							UISoundFX.PlaySFX("Kaching");
						}
						UISoundFX.PlaySFX("PlaceFurniture", true);
						base.transform.rotation = rotation;
					}
					if (list2.Count > 0)
					{
						GameSettings.Instance.AddUndo(list2.ToArray());
					}
					Action onBuild2 = OnBuild;
					if (onBuild2 != null)
					{
						onBuild2();
					}
					if (PriceOverride.HasValue || AwardData != null || !BuildController.PlaceMulti() || (IsProto && !CopyProto))
					{
						CheckShortcutPanel();
						WindowManager.SetCursorOverride(null);
						UnityEngine.Object.Destroy(base.gameObject);
					}
					else
					{
						if (InputController.GetKey(InputController.Keys.FurnitureRandomRot, true) && Furn.CanRotate)
						{
							if (Furn.IsSnapping)
							{
								rotationOffset = GetRandomRotation(rotationOffset);
							}
							else
							{
								base.transform.rotation = Quaternion.Euler(0f, GetRandomRotation(base.transform.rotation.eulerAngles.y), 0f);
							}
						}
						Options.UpdateHint(HintController.Hints.FurnPlaceHintMultiple, false);
						UpdateFullCost();
					}
				}
				else
				{
					DragEnd = null;
					UpdateFullCost();
					UISoundFX.PlaySFX("BuildError");
				}
			}
		}
		if (!Furn.WallFurn && !ForceRotation())
		{
			Vector3 vector5 = LerpingPos - base.transform.position;
			Vector2 vector6 = Vector2.ClampMagnitude(new Vector2(vector5.x, vector5.z), 0.5f);
			vector5 = new Vector3(vector6.x, 1f, vector6.y);
			LerpingPos = base.transform.position + new Vector3(vector6.x, 0f, vector6.y);
			LerpingPos = Vector3.Lerp(LerpingPos, base.transform.position, Time.deltaTime * 10f);
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, vector5) * GetFurnitureRotation();
			base.transform.rotation = Quaternion.Euler(quaternion.eulerAngles.x, base.transform.rotation.eulerAngles.y, quaternion.eulerAngles.z);
		}
	}

	public bool ForceRotation()
	{
		if (Furn.IsSnapping)
		{
			return !Furn.CanRotate;
		}
		return false;
	}

	public void ResetRotation()
	{
		Vector3 forward = BuildController.Instance.GridMatrix.inverse.MultiplyVector(Vector3.forward);
		base.transform.rotation = Quaternion.LookRotation(forward);
	}

	private double FinalBuild(List<UndoObject.UndoAction> undo, Vector3? rPos = null)
	{
		Vector3 pos = rPos ?? base.transform.position;
		if (IsProto)
		{
			if (CopyProto)
			{
				bool inventory;
				Furniture furniture = MakeFurn(pos, GetFurnitureRotation(), LastRoom, edge1, edge2, WallPosition, wasReversed, LastSnap, FurnPrefab, rotationOffset, true, out inventory);
				if (furniture == null)
				{
					return 0.0;
				}
				DoNotCopy.Add(furniture);
				LastSnap = null;
				CopyStyle(Furn, furniture);
				float num = TraverseCopy(Furn, furniture, undo, furniture);
				undo.Add(new UndoObject.UndoAction(furniture, true, inventory));
				return num + (inventory ? 0f : furniture.GetCost());
			}
			Furniture component = FurnPrefab.GetComponent<Furniture>();
			undo.Add(new UndoObject.UndoAction(component, component.Parent, component.OriginalPosition, component.transform.rotation, component.RotationOffset, component.SnappedTo));
			MoveFurn(pos, GetFurnitureRotation(), LastRoom, edge1, edge2, WallPosition, wasReversed, LastSnap, FurnPrefab, rotationOffset);
			LastSnap = null;
			TraverseMove(Furn, LastRoom, edge1, edge2, WallPosition, undo);
			return 0.0;
		}
		bool inventory2;
		Furniture furniture2 = MakeFurn(pos, GetFurnitureRotation(), LastRoom, edge1, edge2, WallPosition, wasReversed, LastSnap, FurnPrefab, rotationOffset, false, out inventory2, false, false, PriceOverride, AwardData);
		if (furniture2 == null)
		{
			return 0.0;
		}
		DoNotCopy.Add(furniture2);
		if (PriceOverride.HasValue)
		{
			undo.Clear();
			GameSettings.Instance.ResetUndo();
		}
		else
		{
			undo.Add(new UndoObject.UndoAction(furniture2, true, inventory2));
		}
		LastSnap = null;
		double? priceOverride = PriceOverride;
		if (!priceOverride.HasValue)
		{
			if (!inventory2)
			{
				return furniture2.GetCost();
			}
			return 0.0;
		}
		return priceOverride.GetValueOrDefault();
	}

	private Quaternion GetFurnitureRotation()
	{
		if (!ForceRotation())
		{
			return Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y, 0f);
		}
		return base.transform.rotation;
	}

	private bool CheckBasement()
	{
		if (!Furn.BasementValid && GameSettings.Instance.ActiveFloor < 0)
		{
			ErrorOverlay.Instance.ShowError("BasementFurnError");
			return false;
		}
		return true;
	}

	private float GetCurrentCost(Dictionary<string, int> inventory)
	{
		if (IsProto && !CopyProto)
		{
			return 0f;
		}
		if (DragEnd.HasValue)
		{
			int num = Mathf.FloorToInt((base.transform.position.FlattenVector3() - DragEnd.Value).magnitude / Furn.DragDistance);
			float num2 = 0f;
			for (int i = 0; i <= num; i++)
			{
				num2 += ((Furn.ValidInInventory && DeductInventory(Furn.name, inventory)) ? 0f : Furn.GetCost());
				num2 += GetSnapCost(Furn, inventory);
			}
			return num2;
		}
		if (_lastAutoPlaceRoom != null)
		{
			float num3 = 0f;
			for (int j = 0; j < _lastAutoPlace.Count; j++)
			{
				num3 += ((Furn.ValidInInventory && DeductInventory(Furn.name, inventory)) ? 0f : Furn.GetCost());
			}
			return num3;
		}
		float num4 = ((Furn.ValidInInventory && DeductInventory(Furn.name, inventory)) ? 0f : Furn.GetCost());
		for (int k = 0; k < Children.Count; k++)
		{
			num4 += Children[k].GetCurrentCost(inventory);
		}
		return num4 + GetSnapCost(Furn, inventory);
	}

	private float GetSnapCost(Furniture furn, Dictionary<string, int> inventory)
	{
		float num = 0f;
		for (int i = 0; i < furn.SnapPoints.Length; i++)
		{
			SnapPoint snapPoint = furn.SnapPoints[i];
			if (snapPoint.UsedByCount <= 0)
			{
				continue;
			}
			foreach (Furniture item in snapPoint.GetAllUsedBy())
			{
				if (!item.ValidInInventory || !DeductInventory(item.name, inventory))
				{
					num += item.GetCost();
				}
				num += GetSnapCost(item, inventory);
			}
		}
		return num;
	}

	private bool DeductInventory(string furn, Dictionary<string, int> inventory)
	{
		int value;
		if (!inventory.TryGetValue(furn, out value))
		{
			value = (inventory[furn] = GameSettings.GetInventoryCount(furn));
		}
		if (value > 0)
		{
			inventory[furn]--;
			return true;
		}
		return false;
	}

	private float TraverseCopy(Furniture f, Furniture replacement, List<UndoObject.UndoAction> undo, Furniture ignore)
	{
		float num = 0f;
		SnapPoint[] snapPoints = f.SnapPoints;
		foreach (SnapPoint snapPoint in snapPoints)
		{
			if (snapPoint.UsedByCount <= 0)
			{
				continue;
			}
			Furniture[] array = snapPoint.GetAllUsedBy().ToArray();
			foreach (Furniture furniture in array)
			{
				if (!furniture.CanCopy || !(ignore != furniture) || DoNotCopy.Contains(furniture))
				{
					continue;
				}
				int localId = snapPoint.Id;
				SnapPoint snapPoint2 = replacement.SnapPoints.First((SnapPoint x) => x.Id == localId);
				bool inventory;
				Furniture furniture2 = MakeFurn(snapPoint2.transform.position + snapPoint2.transform.rotation * furniture.SnapPointOffset, Quaternion.Euler(0f, furniture.RotationOffset, 0f) * snapPoint2.transform.rotation, LastRoom, edge1, edge2, WallPosition, false, snapPoint2, furniture.gameObject, furniture.RotationOffset, true, out inventory);
				if (!(furniture2 == null))
				{
					DoNotCopy.Add(furniture2);
					LastSnap = null;
					CopyStyle(furniture, furniture2);
					num += TraverseCopy(furniture, furniture2, undo, ignore);
					undo.Add(new UndoObject.UndoAction(furniture2, true, inventory));
					if (!inventory)
					{
						num += furniture2.GetCost();
					}
				}
			}
		}
		return num;
	}

	public static void TraverseMove(Furniture f, Room room, WallEdge e1, WallEdge e2, float wallPos, List<UndoObject.UndoAction> undos)
	{
		SnapPoint[] snapPoints = f.SnapPoints;
		foreach (SnapPoint snapPoint in snapPoints)
		{
			if (snapPoint.UsedByCount <= 0)
			{
				continue;
			}
			Furniture[] array = snapPoint.GetAllUsedBy().ToArray();
			foreach (Furniture furniture in array)
			{
				MoveFurn(snapPoint.GetRealPos() + snapPoint.transform.rotation * furniture.SnapPointOffset, Quaternion.Euler(0f, furniture.RotationOffset, 0f) * snapPoint.transform.rotation, room, e1, e2, wallPos, false, snapPoint, furniture.gameObject, furniture.RotationOffset);
				if (undos != null && !IsValidIn(furniture, furniture.Parent))
				{
					furniture.UndoDestroyWithChildren(undos);
				}
				else
				{
					TraverseMove(furniture, room, e1, e2, wallPos, undos);
				}
			}
		}
	}

	public static void CopyStyle(Furniture furn1, Furniture furn2)
	{
		furn2.name = furn2.name.Replace("(Clone)", "").Trim();
		furn2.ColorPrimary = furn1.ActualColorPrimary;
		furn2.ColorSecondary = furn1.ActualColorSecondary;
		furn2.ColorTertiary = furn1.ActualColorTertiary;
		furn2.AtlasIndex = furn1.AtlasIndex;
		furn2.DisableInitColor = true;
		furn2.CopyPrinter(furn1);
		if (furn2.Signage != null)
		{
			furn2.Signage.CopyFrom(furn1.Signage);
			furn2.Signage.Apply();
		}
		furn2.SetReplacement(0, furn1.GetReplacement(0));
		UserImageFrame component;
		UserImageFrame component2;
		HardwareDesignFurn component3;
		HardwareDesignFurn component4;
		if (furn1.TryGetComponent<UserImageFrame>(out component) && furn2.TryGetComponent<UserImageFrame>(out component2))
		{
			component2.SetImage(component.ImageName);
		}
		else if (furn1.TryGetComponent<HardwareDesignFurn>(out component3) && furn2.TryGetComponent<HardwareDesignFurn>(out component4))
		{
			component4.ProductID = component3.ProductID;
			component4.AddonID = component3.AddonID;
		}
		else
		{
			furn2.SetReplacement(1, furn1.GetReplacement(1));
		}
	}

	public static void CopyStyle(BuildingPrefab.FurnitureObject furn1, Furniture furn2)
	{
		furn2.name = furn2.name.Replace("(Clone)", "").Trim();
		furn2.ColorPrimary = (furn2.ColorPrimaryEnabled ? furn1.Colors[0].ToColor() : furn2.ColorPrimaryDefault);
		furn2.ColorSecondary = (furn2.ColorSecondaryEnabled ? furn1.Colors[1].ToColor() : furn2.ColorSecondaryDefault);
		furn2.ColorTertiary = (furn2.ColorTertiaryEnabled ? furn1.Colors[2].ToColor() : furn2.ColorTertiaryDefault);
		furn2.SetReplacement(0, furn1.Replacement1);
		UserImageFrame component;
		HardwareDesignFurn component2;
		if (furn2.TryGetComponent<UserImageFrame>(out component))
		{
			component.SetImage(furn1.Replacement2);
		}
		else if (furn2.TryGetComponent<HardwareDesignFurn>(out component2))
		{
			component2.ProductID = ((furn1.Replacement1 != null) ? furn1.Replacement1.ConvertToUIntDef(0u) : 0u);
			component2.AddonID = ((furn1.Replacement2 != null) ? furn1.Replacement2.ConvertToUIntDef(0u) : 0u);
		}
		else
		{
			furn2.SetReplacement(1, furn1.Replacement2);
		}
		furn2.AtlasIndex = furn1.AtlasIndex;
		furn2.DisableInitColor = true;
		if (furn2.Printer != null)
		{
			furn2.Printer.SetOutput(furn1.ComponentOutput);
		}
		if (furn2.Signage != null && furn1.Signage != null && furn1.Signage.Length > 5)
		{
			furn2.Signage.Thickness = furn1.Signage[0];
			furn2.Signage.Outline = furn1.Signage[1];
			furn2.Signage.ShadowSize = furn1.Signage[2];
			furn2.Signage.ShadowHor = furn1.Signage[3];
			furn2.Signage.ShadowVert = furn1.Signage[4];
			furn2.Signage.ShadowOpacity = furn1.Signage[5];
			furn2.Signage.Apply();
		}
	}

	public static Furniture MakeFurnNetwork(uint id, Vector3 pos, Quaternion rot, float rotOffset, int floor, WallEdge edge1, WallEdge edge2, float wallPos, bool reverseWall, SnapPoint snap, GameObject furnFab, PlayerMap map, NetworkRoom parent)
	{
		Furniture component = UnityEngine.Object.Instantiate(furnFab).GetComponent<Furniture>();
		component.NetworkID = id;
		component.Map = map;
		component.transform.position = pos;
		component.OriginalPosition = pos;
		component.transform.rotation = rot;
		component.Floor = floor;
		component.NetworkParent = parent;
		component.InitLOD();
		if (parent == null || (component.PokesThroughRoof && parent.Floor == -1))
		{
			RemoveTrees(component);
		}
		if (component.WallFurn)
		{
			component.IsReversed = reverseWall;
			component.Init(edge1, edge2, wallPos);
		}
		if (component.IsSnapping && snap != null)
		{
			component.SnappedTo = snap;
			component.RotationOffset = rotOffset;
			snap.SetUsedBy(component);
		}
		if (component.PokesThroughRoof && parent != null && parent.Floor == -1)
		{
			GrassSystem.Instance.InvalidateArea();
		}
		component.gameObject.SetActive(true);
		return component;
	}

	public static Furniture MakeFurn(Vector3 pos, Quaternion rot, Room room, WallEdge edge1, WallEdge edge2, float wallPos, bool reverseWall, SnapPoint snap, GameObject furnFab, float rotOffset, bool isInstance, out bool inventory, bool free = false, bool partOfGen = false, double? priceOverride = null, AwardTrophy.AwardData awardData = null)
	{
		if (BuildController.Instance.ActivePrefab != null)
		{
			Furniture component = furnFab.GetComponent<Furniture>();
			if (!BuildController.Instance.ActivePrefab.CheckOnlyFurniture(component, pos, room.Floor, rot.eulerAngles.y))
			{
				ErrorOverlay.Instance.ShowError("ForcedPrefabError", false, true, 4f);
				inventory = false;
				UISoundFX.PlaySFX("BuildError");
				return null;
			}
		}
		if (isInstance)
		{
			furnFab = ObjectDatabase.Instance.GetFurniture(furnFab.name);
		}
		Furniture component2 = UnityEngine.Object.Instantiate(furnFab).GetComponent<Furniture>();
		InventoryItem inventoryItem = ((!component2.ValidInInventory || priceOverride.HasValue) ? null : GameSettings.PopFromInventory(furnFab.name));
		component2.PartOfGen = partOfGen;
		if (priceOverride.HasValue)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0.0 - priceOverride.Value, Company.TransactionCategory.Bills, true, "TotallyLegit");
		}
		else if (!free && inventoryItem == null)
		{
			float cost = component2.GetCost();
			if (cost > 0f)
			{
				GameSettings.Instance.MyCompany.MakeTransaction(0f - cost, Company.TransactionCategory.Construction, false, "Furniture");
				GameSettings.Instance.MyCompany.AddTax(TaxReport.TaxType.Depreciation, component2.GetSellPrice() - cost);
			}
		}
		component2.InitializeInteractionPoints();
		if (component2.Type.Equals("Lamp"))
		{
			HelpTipPanel.Show(HintController.Hints.LampTestHint, HUD.Instance.SunSlider.GetComponent<RectTransform>());
		}
		if (component2.TempControlType != Furniture.TemperatureType.None && component2.EqualizeTemperature)
		{
			TutorialSystem.Instance.StartTutorial("Temperature regulation");
		}
		component2.transform.position = pos;
		component2.OriginalPosition = pos;
		component2.transform.rotation = rot;
		component2.UpdateConnectorPositions();
		component2.Parent = room;
		component2.Floor = room.Floor;
		component2.InitLOD();
		component2.SpecialPrice = priceOverride ?? 0.0;
		if (isInstance)
		{
			room.AddFurniture(component2);
			component2.UpdateBoundaryPoints();
		}
		if (room.Outside || (component2.PokesThroughRoof && room.Floor == -1))
		{
			RemoveTrees(component2);
		}
		if (component2.WallFurn)
		{
			component2.IsReversed = reverseWall;
			component2.Init(edge1, edge2, wallPos);
		}
		if (component2.IsSnapping && snap != null)
		{
			component2.SnappedTo = snap;
			component2.RotationOffset = rotOffset;
			snap.SetUsedBy(component2);
			component2.ImprintSnapPointOffset(snap);
		}
		if (component2.DoesSnapTo("OnTable"))
		{
			room.RecalculateTableGroups();
		}
		if (snap != null && snap.Parent.Table != null)
		{
			snap.Parent.Table.UpdateStatus(true);
		}
		if (!room.GetNavMeshRunning())
		{
			component2.UpdateFreeNavs();
		}
		room.RecalculateStateVariables();
		room.RefreshNoise();
		if (component2.TwoFloors)
		{
			component2.Parent.DirtyRoofMesh |= component2.TwoFloors && component2.MakeHole;
			component2.ExtraParent = GetBestRoom(room.Floor + 1, pos.FlattenVector3(), component2, null);
			if (component2.ExtraParent != null)
			{
				component2.ExtraParent.AddFurniture(component2);
				component2.ExtraParent.DirtyNavMesh = true;
				component2.ExtraParent.DirtyPathNodes = true;
				component2.ExtraParent.DirtyFloorMesh |= component2.TwoFloors && component2.MakeHole;
			}
		}
		component2.gameObject.SetActive(true);
		if (inventoryItem != null)
		{
			inventoryItem.Deserialize(component2);
			component2.ApplyMaterialPickerStyle();
			inventory = true;
		}
		else
		{
			inventory = false;
		}
		if (component2.PokesThroughRoof && room.Floor == -1)
		{
			GrassSystem.Instance.InvalidateArea();
		}
		if (awardData != null)
		{
			component2.GetComponent<AwardTrophy>().Init(awardData);
			GameSettings.Instance.RemoveAward(awardData);
			inventory = true;
		}
		if (BuildController.Instance.ActivePrefab != null)
		{
			BuildController.Instance.ActivePrefab.CheckFurniture(component2);
		}
		return component2;
	}

	public static void MoveFurn(Vector3 pos, Quaternion rot, Room room, WallEdge edge1, WallEdge edge2, float wallPos, bool isReversed, SnapPoint snap, GameObject f, float rotOffset)
	{
		Furniture component = f.GetComponent<Furniture>();
		if (component.OnHead && component.OnHeadOf != null)
		{
			component.OnHeadOf.OnHead = null;
		}
		if (component.Parent != null)
		{
			if (component.Parent != room)
			{
				component.Parent.DirtyLights();
				if (component.PokesThroughRoof && component.Parent.Floor == -1)
				{
					GrassSystem.Instance.InvalidateArea();
				}
			}
			if (component.HasConveyor)
			{
				component.Parent.DirtyConveyors = true;
			}
		}
		component.SymbolicDestroy();
		component.transform.position = pos;
		component.OriginalPosition = pos;
		component.transform.rotation = rot;
		component.UpdateConnectorPositions();
		if (component.Parent != null && component.Parent != room)
		{
			component.Parent.RemoveFurniture(component);
		}
		component.Parent = room;
		component.Floor = room.Floor;
		component.InitLOD();
		room.AddFurniture(component);
		if (component.WallFurn)
		{
			component.IsReversed = isReversed;
			component.Init(edge1, edge2, wallPos);
		}
		if (component.IsSnapping)
		{
			component.ImprintSnapPointOffset(snap);
			SnapPoint snappedTo = component.SnappedTo;
			if (snappedTo != null)
			{
				snappedTo.SetUsedBy(component, false);
			}
			if (snap != null)
			{
				component.SnappedTo = snap;
				component.RotationOffset = rotOffset;
				component.transform.position = (component.OriginalPosition = snap.FixPosition(component));
				snap.SetUsedBy(component);
			}
			else if (component.CanNotSnap)
			{
				component.SnappedTo = null;
			}
			if (snappedTo != null && snappedTo.Parent.Table != null)
			{
				snappedTo.Parent.Table.UpdateStatus(true);
			}
		}
		component.UpdateBoundsMesh();
		Server component2 = component.GetComponent<Server>();
		if (component2 != null)
		{
			ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(component2.ServerName);
			if (serverGroup != null)
			{
				serverGroup.ReWireAll();
			}
		}
		LampScript component3 = component.GetComponent<LampScript>();
		if (component3 != null)
		{
			component3.CalcEdge();
		}
		component.UpdateBoundaryPoints();
		component.CleanFloor();
		if (component.Height1 < Actor.HumanHeight && component.FinalBoundary != null && component.FinalBoundary.Length != 0)
		{
			room.DirtyNavMesh = true;
		}
		if (component.Table != null || component.DoesSnapTo("OnTable"))
		{
			room.RecalculateTableGroups();
		}
		if (snap != null && snap.Parent.Table != null)
		{
			snap.Parent.Table.UpdateStatus(true);
		}
		component.CalcEdge();
		if (!room.GetNavMeshRunning())
		{
			component.UpdateFreeNavs();
		}
		room.RecalculateStateVariables();
		room.RefreshNoise();
		if (room.Outside || (component.PokesThroughRoof && room.Floor == -1))
		{
			RemoveTrees(component);
		}
		Furniture.UpdateEdgeDetection();
		if (!GameSettings.Instance.RentMode && (component.TemperatureController || component.TemperatureOutput))
		{
			if (component.TemperatureOutput)
			{
				HUD.Instance.NoInputTemp.Add(component);
			}
			GameSettings.Instance.sRoomManager.TemperatureControlDirty = true;
			component.ForceTempUpdate = true;
		}
		if (component.IsCCTVFurn)
		{
			GameSettings.Instance.sRoomManager.CCTVDirty = true;
		}
		if (component.TwoFloors)
		{
			component.Parent.DirtyRoofMesh |= component.TwoFloors && component.MakeHole;
			component.ExtraParent = GetBestRoom(room.Floor + 1, pos.FlattenVector3(), component, null);
			if (component.ExtraParent != null)
			{
				component.ExtraParent.AddFurniture(component);
				component.ExtraParent.DirtyNavMesh = true;
				component.ExtraParent.DirtyPathNodes = true;
				component.ExtraParent.DirtyFloorMesh |= component.TwoFloors && component.MakeHole;
			}
		}
		if (component.IsConnecter)
		{
			component.pathNode.Point = component.transform.position + Vector3.up * 0.5f;
			room.DirtyPathNodes = true;
		}
		if (component.HasConveyor)
		{
			room.DirtyConveyors = true;
			component.Conveyor.UpdateCachedPoints();
			if (component.Printer != null)
			{
				NotificationManager.RemoveAggregate<PrinterBlockedNotification>(component);
			}
		}
		room.DirtyLights();
		if (component.PokesThroughRoof && room.Floor == -1)
		{
			GrassSystem.Instance.InvalidateArea();
		}
		if (component.Pallet != null && !component.Pallet.StaticBox)
		{
			component.Pallet.CheckBlocked();
		}
		component.RefreshAtriumObject();
		AudioVisualizer.NoiseDirty = true;
		if (NetworkManager.IsConnected && NetworkManager.Instance.Players.Count > 1)
		{
			if (component.IsNetworkValid())
			{
				if (component.NetworkID != 0)
				{
					NetworkMessaging.SendMoveFurniture(component.NetworkID, pos, component.Floor, component.transform.rotation.eulerAngles.y, component.RotationOffset, (!component.Parent.Outside) ? component.Parent.NetworkID : 0u, (snap != null) ? snap.Parent.NetworkID : 0u, (snap != null) ? snap.Id : 0, component.IsReversed, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				}
				else
				{
					component.SendNetwork();
				}
			}
			else if (component.NetworkID != 0)
			{
				NetworkMessaging.SendDestroyNetworkObject(component.NetworkID, component.IsNetworkIDLocal(), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				component.NetworkID = 0u;
			}
		}
		BuildController.Instance.ValidateForcedPrefab();
	}

	public static void NetworkMoveFurn(Vector3 pos, float rot, int floor, WallEdge edge1, WallEdge edge2, float wallPos, bool isReversed, SnapPoint snap, GameObject f, float rotOffset, NetworkRoom parentRoom)
	{
		Furniture component = f.GetComponent<Furniture>();
		component.transform.position = pos;
		component.OriginalPosition = pos;
		component.transform.rotation = Quaternion.Euler(0f, rot, 0f);
		component.UpdateConnectorPositions();
		component.NetworkParent = parentRoom;
		component.Floor = floor;
		component.InitLOD();
		if (component.WallFurn)
		{
			component.IsReversed = isReversed;
			component.Init(edge1, edge2, wallPos);
		}
		if (component.IsSnapping && snap != null)
		{
			component.SnappedTo = snap;
			component.RotationOffset = rotOffset;
			snap.SetUsedBy(component);
		}
		component.UpdateBoundsMesh();
		LampScript component2 = component.GetComponent<LampScript>();
		if (component2 != null)
		{
			component2.CalcEdge();
		}
		component.UpdateBoundaryPoints();
		component.CalcEdge();
		if (parentRoom == null || (component.PokesThroughRoof && parentRoom.Floor == -1))
		{
			RemoveTrees(component);
		}
		Furniture.UpdateEdgeDetection();
		if (component.PokesThroughRoof && parentRoom != null && parentRoom.Floor == -1)
		{
			GrassSystem.Instance.InvalidateArea();
		}
	}

	private static void RemoveTrees(Furniture f)
	{
		Vector3 position = f.transform.position;
		List<TreeInstance> list = GameSettings.Instance.TreeTree.Query(new Rect(position.x - 2f, position.z - 2f, 4f, 4f)).ToList();
		if (f.FinalBoundary == null || f.FinalBoundary.Length == 0)
		{
			f.UpdateBoundaryPoints();
		}
		Vector2[] offset = f.FinalBoundary.GetOffset(-0.5f);
		for (int i = 0; i < list.Count; i++)
		{
			TreeInstance treeInstance = list[i];
			if (Utilities.IsInside(treeInstance.GetPos(), offset))
			{
				GameSettings.Instance.RemoveTree(treeInstance);
			}
		}
	}

	private void OnDrawGizmos()
	{
		foreach (Vector2[] item in BuildBoundary)
		{
			Vector2[] realPoints = GetRealPoints(base.transform.localToWorldMatrix, item);
			Gizmos.color = Color.yellow;
			for (int i = 0; i < realPoints.Length; i++)
			{
				int num = (i + 1) % realPoints.Length;
				Gizmos.DrawLine(new Vector3(realPoints[i].x, GameSettings.Instance.ActiveFloor * 2 + 1, realPoints[i].y), new Vector3(realPoints[num].x, GameSettings.Instance.ActiveFloor * 2 + 1, realPoints[num].y));
			}
		}
		Gizmos.color = Color.white;
		Gizmos.DrawSphere(LerpingPos, 0.1f);
	}
}
