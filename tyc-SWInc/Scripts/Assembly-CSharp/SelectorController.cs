using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Achievements;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class SelectorController : MonoBehaviour
{
	public enum SelectionTypes
	{
		Employee = 0,
		Room = 1,
		Furniture = 2,
		Segment = 3,
		Parking = 4,
		Roof = 5,
		Path = 6
	}

	[Flags]
	public enum ACTCAT
	{
		NULL = 1,
		FURN = 2,
		ROOM = 4,
		EMP = 8,
		STAFF = 0x10,
		SEG = 0x20,
		PARK = 0x40,
		ROOF = 0x80,
		PATH = 0x100
	}

	public enum ContextButtonGroup
	{
		Group = -1,
		Style = 2,
		Manage = 1,
		Manipulate = 0,
		Assign = 3,
		Select = 4
	}

	public class CounterButton
	{
		public Func<int, string> Countable;

		public Func<int> Max;

		public int DefaultCount = 1;

		public int Min = 1;

		public CounterButton(Func<int, string> countable, Func<int> max)
		{
			Countable = countable;
			Max = max;
		}
	}

	public class RightClickAction
	{
		public string Icon;

		public CounterButton Counter;

		public ACTCAT Category;

		public ContextButtonGroup Order;

		public Action<Selectable[], SelectorController> GroupAction;

		public Action DirectAction;

		public Func<Selectable[], bool> Checked;

		public Func<bool> CheckIfShow;

		public RightClickAction(ACTCAT category, string icon, ContextButtonGroup order, Action<Selectable[], SelectorController> action)
		{
			Category = category;
			Icon = icon;
			Order = order;
			GroupAction = action;
		}

		public RightClickAction(ACTCAT category, string icon, ContextButtonGroup order, Action action)
		{
			Category = category;
			Icon = icon;
			Order = order;
			DirectAction = action;
		}
	}

	public enum HighlightType
	{
		Primary = 0,
		Secondary = 1,
		Tertiary = 2,
		PrimaryAndTertiary = 3,
		Error = 4
	}

	public static Dictionary<string, string> CategoryIcons = new Dictionary<string, string>
	{
		{ "Furniture", "Furniture" },
		{ "Room", "Room" },
		{ "Employee", "Employee" },
		{ "Staff", "Staff" },
		{ "Segment", "Door" },
		{ "Parking", "Parking" },
		{ "Roof", "Roof" },
		{ "Path", "Path" }
	};

	public static string[] Categories = new string[9] { null, "Furniture", "Room", "Employee", "Staff", "Segment", "Parking", "Roof", "Path" };

	public static Dictionary<string, RightClickAction> RightClickActions = new Dictionary<string, RightClickAction>
	{
		{
			"Default Style",
			new RightClickAction(ACTCAT.FURN, "Checkmark", ContextButtonGroup.Style, DefaultStyleAction)
		},
		{
			"Save Style",
			new RightClickAction(ACTCAT.ROOM, "Disk", ContextButtonGroup.Style, SaveRoomStyle)
		},
		{
			"Apply Style",
			new RightClickAction(ACTCAT.ROOM, "Pipette", ContextButtonGroup.Style, ApplyRoomStyle)
		},
		{
			"Room Color",
			new RightClickAction(ACTCAT.ROOM, "Brush", ContextButtonGroup.Style, RoomColorAction)
		},
		{
			"Path Color",
			new RightClickAction(ACTCAT.PATH, "Brush", ContextButtonGroup.Style, PathColorAction)
		},
		{
			"Material",
			new RightClickAction(ACTCAT.ROOM, "Brick", ContextButtonGroup.Style, MaterialAction)
		},
		{
			"Roof Color",
			new RightClickAction(ACTCAT.ROOF, "Brush", ContextButtonGroup.Style, RoofColorAction)
		},
		{
			"Roof material",
			new RightClickAction(ACTCAT.ROOF, "Brick", ContextButtonGroup.Style, RoofMaterialAction)
		},
		{
			"Path material",
			new RightClickAction(ACTCAT.PATH, "Brick", ContextButtonGroup.Style, PathMaterialAction)
		},
		{
			"Educate",
			new RightClickAction(ACTCAT.EMP, "Education", ContextButtonGroup.Manage, EducateAction)
		},
		{
			"Dismiss",
			new RightClickAction(ACTCAT.EMP, "Trash", ContextButtonGroup.Manipulate, DismissAction)
		},
		{
			"Sell",
			new RightClickAction(ACTCAT.FURN, "Trash", ContextButtonGroup.Manipulate, SellAction)
		},
		{
			"PutInventory",
			new RightClickAction(ACTCAT.FURN, "Download", ContextButtonGroup.Manipulate, InventoryAction)
		},
		{
			"Dismantle",
			new RightClickAction(ACTCAT.SEG, "Trash", ContextButtonGroup.Manipulate, DismantleAction)
		},
		{
			"Destroy",
			new RightClickAction(ACTCAT.ROOM | ACTCAT.ROOF, "Trash", ContextButtonGroup.Manipulate, DestroyAction)
		},
		{
			"Destroy Path",
			new RightClickAction(ACTCAT.PATH, "Trash", ContextButtonGroup.Manipulate, PathDestroyAction)
		},
		{
			"Change Team",
			new RightClickAction(ACTCAT.EMP, "MoreEmployees", ContextButtonGroup.Assign, ChangeTeamAction)
		},
		{
			"Change Room Team",
			new RightClickAction(ACTCAT.ROOM, "MoreEmployees", ContextButtonGroup.Assign, ChangeRoomTeamAction)
		},
		{
			"Limit Use",
			new RightClickAction(ACTCAT.ROOM, "Stop", ContextButtonGroup.Assign, LimitUseAction)
		},
		{
			"Select Building",
			new RightClickAction(ACTCAT.ROOM, "Building", ContextButtonGroup.Select, SelectBuildingAction)
		},
		{
			"Change Role",
			new RightClickAction(ACTCAT.EMP, "Tie", ContextButtonGroup.Assign, ChangeRoleAction)
		},
		{
			"Send home",
			new RightClickAction(ACTCAT.NULL | ACTCAT.EMP | ACTCAT.STAFF, "Home", ContextButtonGroup.Manage, SendHomeAction)
			{
				Counter = new CounterButton(CountDays, CountDaysMax)
			}
		},
		{
			"Furniture color",
			new RightClickAction(ACTCAT.FURN | ACTCAT.SEG, "Brush", ContextButtonGroup.Style, FurnitureColor)
		},
		{
			"FurnitureStyle",
			new RightClickAction(ACTCAT.FURN | ACTCAT.SEG, "Painting", ContextButtonGroup.Style, FurnitureStyle)
		},
		{
			"FurnitureRandomStyle",
			new RightClickAction(ACTCAT.FURN, "Lightbulb", ContextButtonGroup.Style, FurnitureRandomStyle)
		},
		{
			"Types in Room",
			new RightClickAction(ACTCAT.NULL | ACTCAT.FURN | ACTCAT.ROOM, "Furniture", ContextButtonGroup.Select, TypesInRoom)
		},
		{
			"Details",
			new RightClickAction(ACTCAT.EMP, "Employee", ContextButtonGroup.Manage, DetailsAction)
		},
		{
			"Change Salary",
			new RightClickAction(ACTCAT.EMP, "Money", ContextButtonGroup.Manage, ChangeSalaryAction)
		},
		{
			"Select Team",
			new RightClickAction(ACTCAT.EMP, "SelectTeam", ContextButtonGroup.Select, SelectTeamAction)
		},
		{
			"Select Owned",
			new RightClickAction(ACTCAT.EMP, "MoreFurniture", ContextButtonGroup.Select, SelectOwnedAction)
		},
		{
			"Select Staff",
			new RightClickAction(ACTCAT.ROOM, "EmployeeRoom", ContextButtonGroup.Select, SelectStaffAction)
		},
		{
			"Unpair",
			new RightClickAction(ACTCAT.FURN, "FurnitureMinus", ContextButtonGroup.Assign, UnpairAction)
		},
		{
			"Pair Use",
			new RightClickAction(ACTCAT.EMP, "EmployeeFurniture", ContextButtonGroup.Assign, PairUse)
		},
		{
			"RoomPair",
			new RightClickAction(ACTCAT.STAFF, "StructurePlus", ContextButtonGroup.Assign, PairRoom)
		},
		{
			"ReplaceFurn",
			new RightClickAction(ACTCAT.FURN, "Recycle", ContextButtonGroup.Manipulate, ReplaceFurnAction)
		},
		{
			"Move",
			new RightClickAction(ACTCAT.FURN, "ArrowRight", ContextButtonGroup.Manipulate, MoveAction)
		},
		{
			"ConnectServers",
			new RightClickAction(ACTCAT.FURN, "Wires", ContextButtonGroup.Assign, ConnectServersAction)
		},
		{
			"MergeRooms",
			new RightClickAction(ACTCAT.ROOM, "Room", ContextButtonGroup.Manipulate, MergeRooms)
		},
		{
			"SelectWall",
			new RightClickAction(ACTCAT.SEG, "Door", ContextButtonGroup.Select, SelectWallAction)
		},
		{
			"Duplicate",
			new RightClickAction(ACTCAT.FURN, "MoreFurniture", ContextButtonGroup.Manipulate, DuplicateAction)
		},
		{
			"ResetDefaultStyle",
			new RightClickAction(ACTCAT.FURN, "Pipette", ContextButtonGroup.Style, ResetDefaultStyleAction)
		},
		{
			"SelectBuildingFloor",
			new RightClickAction(ACTCAT.ROOM, "SelectFloor", ContextButtonGroup.Select, SelectBuildingFloorAction)
		},
		{
			"AssignParking",
			new RightClickAction(ACTCAT.PARK, "EmployeePlus", ContextButtonGroup.Assign, AssignParkingAction)
		},
		{
			"SelectParkedPeople",
			new RightClickAction(ACTCAT.PARK, "Employee", ContextButtonGroup.Select, SelectParkedPeopleAction)
		},
		{
			"SelectNearParking",
			new RightClickAction(ACTCAT.PARK, "Road", ContextButtonGroup.Select, SelectNearParkingAction)
		},
		{
			"GroupRooms",
			new RightClickAction(ACTCAT.ROOM, "StructurePlus", ContextButtonGroup.Assign, GroupRooms)
		},
		{
			"ToggleRentable",
			new RightClickAction(ACTCAT.ROOM, "Money", ContextButtonGroup.Assign, ToggleRentable)
			{
				Checked = IsRentable
			}
		},
		{
			"TogglePlayerOwned",
			new RightClickAction(ACTCAT.ROOM, "Employee", ContextButtonGroup.Assign, TogglePlayerOwned)
			{
				Checked = IsPlayerOwned
			}
		},
		{
			"GroupRentRooms",
			new RightClickAction(ACTCAT.ROOM, "StructurePlus", ContextButtonGroup.Assign, GroupRentRooms)
		},
		{
			"AutoGroupRentRooms",
			new RightClickAction(ACTCAT.ROOM, "Automation", ContextButtonGroup.Assign, AutoGroupRentRooms)
		},
		{
			"Edit roof",
			new RightClickAction(ACTCAT.ROOF, "BuildMode", ContextButtonGroup.Manipulate, EditRoof)
		},
		{
			"ToggleElevator",
			new RightClickAction(ACTCAT.FURN, "Stop", ContextButtonGroup.Assign, ToggleElevator)
			{
				Checked = CanExitElevator
			}
		},
		{
			"SetComponentOutput",
			new RightClickAction(ACTCAT.FURN, "Hardware", ContextButtonGroup.Manage, SetComponentOutput)
		},
		{
			"ClearBoxes",
			new RightClickAction(ACTCAT.FURN, "Box", ContextButtonGroup.Manage, ClearBoxes)
		},
		{
			"AssemblyDetail",
			new RightClickAction(ACTCAT.FURN, "Question", ContextButtonGroup.Manage, ShowAssemblerDetails)
		},
		{
			"TogglePower",
			new RightClickAction(ACTCAT.FURN, "Lightning", ContextButtonGroup.Manage, ToggleConveyorOnState)
			{
				Checked = IsConveyorOn
			}
		},
		{
			"EditTag",
			new RightClickAction(ACTCAT.SEG, "Font", ContextButtonGroup.Style, EditSegmentTag)
		},
		{
			"SegmentsInRoom",
			new RightClickAction(ACTCAT.NULL | ACTCAT.ROOM | ACTCAT.SEG, "Doors", ContextButtonGroup.Select, SegmentsInRoom)
		},
		{
			"Insured",
			new RightClickAction(ACTCAT.FURN, "Umbrella", ContextButtonGroup.Manage, SetInsure)
			{
				Checked = IsInsured,
				CheckIfShow = NeedInsurance
			}
		},
		{
			"LightAlwaysOn",
			new RightClickAction(ACTCAT.FURN, "Lightbulb", ContextButtonGroup.Manage, SetLightAlwaysOn)
			{
				Checked = IsLamp
			}
		}
	};

	public static SelectorController Instance;

	[NonSerialized]
	public HashSet<Selectable> Selected = new HashSet<Selectable>();

	public static bool CanClick = true;

	public InputField SalaryText;

	public AudioClip Place;

	public Text InfoText;

	public Text PanelButtonText;

	public GUIToolTipper PanelButtonTip;

	public Image[] StatImages;

	public Text[] StatText;

	public GameObject StatPanel;

	public GameObject BigPanel;

	public GameObject PanelButton;

	public GameObject RelocateButton;

	public GUIToolTipper HelpButtonTip;

	public Material PrimaryHighlightMat;

	public Material SecondaryHighlightMat;

	public Material TertiaryHiglightMat;

	public Material PrimAndTerHightlightMat;

	public Material ErrorHightlightMat;

	public Material PrimaryHighlightMatAlpha;

	public Material SecondaryHighlightMatAlpha;

	public Material TertiaryHiglightMatAlpha;

	public Material PrimAndTerHightlightMatAlpha;

	public Material ErrorHightlightMatAlpha;

	public Material PrimaryHighlightMatDiag;

	public Material SecondaryHighlightMatDiag;

	public Material TertiaryHiglightMatDiag;

	public Material PrimAndTerHightlightMatDiag;

	public Material ErrorHightlightMatDiag;

	public RightClickPanel rcPanel;

	public Image BigImage;

	public Text BigText;

	public bool SpecialInfo;

	public Server SelectedServer;

	public RectTransform RectSelectGizmo;

	public Camera LogoCam;

	public Text LogoText;

	[NonSerialized]
	public HashSet<Selectable> SecondaryHighlights = new HashSet<Selectable>();

	public GameObject NeedPanel;

	public GUIProgressBar[] NeedBars;

	public LayoutElement NeedBarLayout;

	public GameObject RobotPanel;

	public GUIProgressBar[] RobotBars;

	public FurnitureReplaceWindow FurnReplacer;

	private int _focusSelector;

	private string _currentPanelAction;

	public Image PanelActionImg;

	public Gradient PanelActionPulse;

	public float PanelActionPulseSpeed;

	public float MoveAddBack;

	public bool RemovedTempFurns;

	public bool RemovedPrintFurns;

	public bool DoneLoading;

	public RenderTexture LoadingTex;

	public GameObject SkipWarning;

	public RectMask2D FixMask;

	public GameObject BoostSliderPanel;

	public Slider BoostSlider;

	public Text BoostLabel;

	private float _minBoostValue;

	private float _maxBoostValue;

	private float _boostIncrement;

	private bool _skipLoading;

	[NonSerialized]
	private HashSet<string> _panelActionPulseSet = new HashSet<string> { "Repair", "RestoreFurniture" };

	public static HashSet<string> MissingDataHost = new HashSet<string>();

	public static List<MonoBehaviour> ReEnable = new List<MonoBehaviour>();

	[NonSerialized]
	public List<WriteDictionary> DelayedCars = new List<WriteDictionary>();

	private bool _disableBoostChange;

	private float _highlightUpdate;

	private Vector2 _lastMousePos;

	private Selectable _currentHighlight;

	public float LastSelectTime;

	public bool FirstSweep;

	public bool SweepDeselectMode;

	private Vector2 _startClick;

	private bool _validStartClick;

	private bool _rectDragging;

	[NonSerialized]
	public HashSet<string> SelectedTeams;

	public static bool EnableDupeHint = true;

	public static bool EnableMoveHint = true;

	[NonSerialized]
	private Texture2D _pixelTex;

	[NonSerialized]
	private Mesh _selectMesh;

	public Material WhiteMat;

	private static void SellAction(Selectable[] xs, SelectorController y)
	{
		if (!GameSettings.ConstructionAllowed())
		{
			return;
		}
		HintController.Show(HintController.Hints.DeleteKeyHintHint);
		List<Furniture> avail = (from x in xs.Where((Selectable x) => x != null).OfType<Furniture>()
			where !x.Parent.BuildingOnFire
			select x).ToList();
		if (avail.Count <= 0)
		{
			return;
		}
		WindowManager.Instance.ShowMessageBox("SellMsg".Loc(avail.Count), true, "Trash", DialogWindow.DialogType.Error, DialogWindow.DialogType.Warning, delegate
		{
			UISoundFX.PlaySFX("BuyRev", true);
			List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
			HashSet<Furniture> hashSet = new HashSet<Furniture>();
			avail.ForEach(delegate(Furniture x)
			{
				x.PreferInventory = false;
			});
			foreach (Furniture item in from x in avail
				where x != null
				orderby x.GetSnappingDepth()
				select x)
			{
				if (!hashSet.Contains(item))
				{
					list.Add(new UndoObject.UndoAction(item, false));
					hashSet.Add(item);
					foreach (Furniture item2 in item.IterateSnap())
					{
						if (!(item2 == null) && !hashSet.Contains(item2))
						{
							if (item2.PreferInventory)
							{
								item2.Undo = true;
								GameSettings.AddToInventory(item2);
							}
							list.Add(new UndoObject.UndoAction(item2, false, item2.PreferInventory));
							hashSet.Add(item2);
						}
					}
					y.Selected.Remove(item);
					item.DestroyGO();
				}
			}
			if (list.Count > 0)
			{
				GameSettings.Instance.AddUndo(list.ToArray());
			}
			y.DoPostSelectChecks();
			GameSettings.Instance.sRoomManager.RecalculateAllDirtyTableGroups();
		}, "Sell furniture");
	}

	private static void InventoryAction(Selectable[] xs, SelectorController y)
	{
		if (!GameSettings.ConstructionAllowed())
		{
			return;
		}
		List<Furniture> list = (from x in xs.Where((Selectable x) => x != null).OfType<Furniture>()
			where !x.Parent.BuildingOnFire
			select x).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		List<UndoObject.UndoAction> list2 = new List<UndoObject.UndoAction>();
		HashSet<Furniture> hashSet = new HashSet<Furniture>();
		foreach (Furniture item in list.OrderBy((Furniture x) => x.GetSnappingDepth()))
		{
			if (hashSet.Contains(item))
			{
				continue;
			}
			list2.Add(new UndoObject.UndoAction(item, false, true));
			hashSet.Add(item);
			foreach (Furniture item2 in item.IterateSnap())
			{
				item2.Undo = true;
				GameSettings.AddToInventory(item2);
				list2.Add(new UndoObject.UndoAction(item2, false, true));
				hashSet.Add(item2);
			}
			y.Selected.Remove(item);
			item.Undo = true;
			GameSettings.AddToInventory(item);
			item.DestroyGO();
		}
		if (list2.Count > 0)
		{
			GameSettings.Instance.AddUndo(list2.ToArray());
		}
		y.DoPostSelectChecks();
	}

	private static void DestroyAction(Selectable[] xs, SelectorController y)
	{
		if (!GameSettings.ConstructionAllowed())
		{
			return;
		}
		HintController.Show(HintController.Hints.DeleteKeyHintHint);
		HashSet<Roof> roofs = xs.Where((Selectable x) => x != null).OfType<Roof>().ToHashSet();
		HashSet<Room> rooms = (from x in xs.Where((Selectable x) => x != null).OfType<Room>()
			where !x.BuildingOnFire
			select x).SelectMany((Room x) => x.GetAtriumChildren().Append(x)).ToHashSet();
		roofs.AddRange(rooms.SelectNotNull((Room x) => x.Roofing));
		if (rooms.Count + roofs.Count <= 0)
		{
			return;
		}
		WindowManager.Instance.ShowMessageBox("BulldozeMsg".Loc(roofs.Count + rooms.Count), true, "Trash", DialogWindow.DialogType.Error, DialogWindow.DialogType.Warning, delegate
		{
			UISoundFX.PlaySFX("BuyRev", true);
			bool flag = false;
			HashSet<Furniture> hashSet = new HashSet<Furniture>();
			HashSet<RoomSegment> segments = new HashSet<RoomSegment>();
			List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
			List<UndoObject.UndoAction> list2 = new List<UndoObject.UndoAction>();
			if (rooms.Any((Room room2) => room2.IsBalcony))
			{
				List<Room> list3 = rooms.Where((Room room2) => room2.IsBalcony).ToList();
				bool flag2 = true;
				while (list3.Count > 0 && flag2)
				{
					flag2 = false;
					for (int num = 0; num < list3.Count; num++)
					{
						Room room = list3[num];
						if (!rooms.Contains(room.AtriumParent) || !GameSettings.Instance.sRoomManager.CanDestroy(room.AtriumParent, rooms))
						{
							rooms.Remove(room);
							if (room.AtriumParent.CanMerge(room, true))
							{
								Room atriumParent = room.AtriumParent;
								List<Vector2> split = atriumParent.MergeWith(room, atriumParent.PrepareSplit(true), list2);
								atriumParent.AtriumChildren.Remove(room);
								list2.Add(new UndoObject.UndoAction(atriumParent, room, split));
								flag2 = true;
								list3.RemoveAt(num);
								num--;
							}
						}
					}
				}
			}
			foreach (Room item in from room2 in rooms
				orderby room2.Floor descending, (!room2.IsBalcony) ? 1 : 0
				select room2)
			{
				if (GameSettings.Instance.sRoomManager.CanDestroy(item, rooms))
				{
					list2.Add(new UndoObject.UndoAction(item, false, 0f));
					List<RoomSegment> segments2 = item.GetSegments(rooms);
					list.AddRange(from z in segments2
						where !segments.Contains(z)
						select new UndoObject.UndoAction(z, false));
					segments.AddRange(segments2);
					Room x1 = item;
					hashSet.AddRange(from z in item.GetFurnitures()
						where !z.KeepWithoutParent(x1)
						select z);
					y.Selected.Remove(item);
					item.DestroyGO();
					GameSettings.Instance.sRoomManager.Rooms.RemoveAll((Room z) => z == x1);
				}
				else
				{
					flag = true;
				}
			}
			list2.Reverse();
			list2.AddRange(list);
			list2.AddRange(hashSet.OrderBy((Furniture z) => z.GetSnappingDepth()).Select(delegate(Furniture z)
			{
				if (z.PreferInventory)
				{
					GameSettings.AddToInventory(z);
				}
				return new UndoObject.UndoAction(z, false, z.PreferInventory);
			}));
			if (roofs.Count > 0)
			{
				list2.Add(new UndoObject.UndoAction(false, roofs.ToArray()));
				foreach (Roof item2 in roofs)
				{
					y.Selected.Remove(item2);
					item2.DestroyGO();
				}
			}
			if (list2.Count > 0)
			{
				GameSettings.Instance.AddUndo(list2.ToArray());
			}
			y.DoPostSelectChecks();
			if (flag)
			{
				WindowManager.Instance.ShowMessageBox("CannotBulldozeSupport".Loc(), false, DialogWindow.DialogType.Error);
			}
			GameSettings.Instance.sRoomManager.RecalculateAllDirtyTableGroups();
		}, "Bulldoze buildings");
	}

	private static void DismantleAction(Selectable[] xs, SelectorController y)
	{
		if (!GameSettings.ConstructionAllowed())
		{
			return;
		}
		HintController.Show(HintController.Hints.DeleteKeyHintHint);
		WindowManager.Instance.ShowMessageBox("DismantleMsg".Loc(xs.Length), true, "Trash", DialogWindow.DialogType.Error, DialogWindow.DialogType.Warning, delegate
		{
			UISoundFX.PlaySFX("BuyRev", true);
			List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
			foreach (RoomSegment item in from x in xs
				where x != null
				select x.GetComponent<RoomSegment>() into x
				where x != null
				select x)
			{
				list.Add(new UndoObject.UndoAction(item, false));
				y.Selected.Remove(item);
				item.DestroyGO();
			}
			if (list.Count > 0)
			{
				GameSettings.Instance.AddUndo(list.ToArray());
			}
			y.DoPostSelectChecks();
		}, "Dismantle segments");
	}

	private static void ChangeTeamAction(Selectable[] xs, SelectorController y)
	{
		List<Actor> acts = xs.OfType<Actor>().ToList();
		HashSet<string> hashSet = acts.WhereSelect((Actor x) => x.GetTeam() != null, (Actor x) => x.Team).ToHashSet();
		HUD.Instance.TeamSelectWindow.Show(true, (hashSet.Count == 1) ? hashSet.First() : null, delegate(string[] x)
		{
			foreach (Actor item in acts.Where((Actor z) => z != null))
			{
				item.Team = ((x.Length == 0) ? null : x[0]);
			}
		}, null, null, (acts.Count == 1) ? acts[0].employee : null);
	}

	private static void ChangeRoomTeamAction(Selectable[] xs, SelectorController y)
	{
		List<Room> rooms = xs.OfType<Room>().ToList();
		if (rooms.Count <= 0)
		{
			return;
		}
		HashSet<string> selected = (from x in rooms.SelectMany((Room x) => x.Teams)
			select x.Name).ToHashSet();
		HUD.Instance.TeamSelectWindow.ShowPassThrough(selected, delegate(string[] x, bool pass)
		{
			List<Team> newTeam = x.SelectNotNull((string z) => GameSettings.Instance.sActorManager.Teams.GetOrNull(z)).ToList();
			for (int num = 0; num < rooms.Count; num++)
			{
				Room room = rooms[num];
				if (room != null)
				{
					room.UpdateTeams(newTeam);
					if (room.AllowPass != pass)
					{
						room.AllowPass = pass;
						GameSettings.Instance.sRoomManager.TeamAssignmentDirty = true;
					}
				}
			}
		}, rooms.Mode((Room x) => x.AllowPass));
	}

	private static void GroupRooms(Selectable[] xs, SelectorController y)
	{
		List<Room> rooms = xs.OfType<Room>().ToList();
		if (rooms.Count <= 0)
		{
			return;
		}
		List<string> groups = GameSettings.Instance.GetRoomGroups(false, true).ToList();
		if (groups.Count == 0)
		{
			WindowManager.Instance.ShowMessageBox("NoRoomGroupPrompt".Loc(), true, DialogWindow.DialogType.Question, delegate
			{
				HUD.Instance.roomGroupWindow.Show(rooms);
			});
			return;
		}
		groups.Add("Newroomgroup".Loc());
		WindowManager.Instance.MultiWindow.Show("Room groups", groups, delegate(int i)
		{
			if (i == groups.Count - 1)
			{
				HUD.Instance.roomGroupWindow.Show(rooms);
				return;
			}
			RoomGroup roomGroup = ((i < 0) ? null : GameSettings.Instance.GetRoomGroup(groups[i]));
			foreach (Room item in rooms)
			{
				GameSettings.Instance.RemoveRoomFromGroups(item);
				if (roomGroup == null)
				{
					item.RoomGroup = null;
				}
				else
				{
					roomGroup.AddRoom(item);
				}
			}
		}, true);
	}

	private static void LimitUseAction(Selectable[] xs, SelectorController y)
	{
		List<Room.RoomLimits> limits = (from Room.RoomLimits x in Enum.GetValues(typeof(Room.RoomLimits))
			orderby (int)x
			select x).ToList();
		WindowManager.Instance.MultiWindow.Show("Usage", limits.Select((Room.RoomLimits x) => x.ToString()).ToArray(), delegate(int z)
		{
			foreach (Room item in xs.Where((Selectable x) => x != null).OfType<Room>())
			{
				item.ChangeRole((int)limits[z]);
			}
		}, false, true, true, true);
	}

	private static void SelectBuildingAction(Selectable[] xs, SelectorController y)
	{
		foreach (Selectable selectable in xs)
		{
			selectable.Highlight(false);
			y.Selected.Remove(selectable);
		}
		foreach (Room item in xs.OfType<Room>())
		{
			if (!y.Selected.Contains(item))
			{
				y.Selected.AddRange(GameSettings.Instance.sRoomManager.GetConnected(item).Cast<Selectable>());
			}
		}
		if (GameSettings.Instance.EditMode || !GameSettings.Instance.RentMode)
		{
			List<Room> list = y.Selected.OfType<Room>().ToList();
			for (int j = 0; j < list.Count; j++)
			{
				Room room = list[j];
				if (room.Roofing != null)
				{
					y.Selected.Add(room.Roofing);
				}
			}
		}
		y.DoPostSelectChecks();
	}

	private static void SelectBuildingFloorAction(Selectable[] xs, SelectorController y)
	{
		foreach (Selectable selectable in xs)
		{
			selectable.Highlight(false);
			y.Selected.Remove(selectable);
		}
		foreach (Room item in xs.OfType<Room>())
		{
			if (!y.Selected.Contains(item))
			{
				y.Selected.AddRange(GameSettings.Instance.sRoomManager.GetConnected(item, true).Cast<Selectable>());
			}
		}
		y.DoPostSelectChecks();
	}

	private static void ChangeRoleAction(Selectable[] xs, SelectorController y)
	{
		EmployeeWindow.ChangeRolesNow(xs.WhereSelect((Selectable x) => x != null, (Selectable x) => x.GetComponent<Actor>()).ToList());
	}

	private static void SendHomeAction(Selectable[] xs, SelectorController y)
	{
		foreach (Actor item in from x in xs
			select x.GetComponent<Actor>() into x
			where x != null
			select x)
		{
			if (item.isActiveAndEnabled)
			{
				item.GoHomeNow = true;
				item.StayHome = y.rcPanel.CounterAmount - 1;
			}
			else if (y.rcPanel.CounterAmount > 1)
			{
				SDateTime? arriveTime = GameSettings.Instance.sActorManager.GetArriveTime(item);
				if (arriveTime.HasValue)
				{
					SDateTime time = arriveTime.Value + SDateTime.GetDay(y.rcPanel.CounterAmount - 1);
					GameSettings.Instance.sActorManager.AddToAwaiting(item, time, true);
				}
			}
		}
	}

	public static void FurnitureColor(Selectable[] xs, SelectorController y)
	{
		WallSnap[] selected = (from x in xs
			select x.GetComponent<WallSnap>() into x
			where x != null
			select x).ToArray();
		if (selected.Length == 0)
		{
			return;
		}
		string[] array = FixFurnitureTranslation(selected);
		HashSet<Color> hashSet = new HashSet<Color>();
		foreach (WallSnap wallSnap in selected)
		{
			if (wallSnap.ColorPrimaryEnabled)
			{
				hashSet.Add(wallSnap.ColorPrimaryDefault);
				hashSet.Add(wallSnap.ActualColorPrimary);
			}
			if (wallSnap.ColorSecondaryEnabled)
			{
				hashSet.Add(wallSnap.ColorSecondaryDefault);
				hashSet.Add(wallSnap.ActualColorSecondary);
			}
			if (wallSnap.ColorTertiaryEnabled)
			{
				hashSet.Add(wallSnap.ColorTertiaryDefault);
				hashSet.Add(wallSnap.ActualColorTertiary);
			}
			wallSnap.ToggleDoors(true, true, true);
		}
		List<string> list = new List<string>();
		List<Action<Color>> list2 = new List<Action<Color>>
		{
			delegate(Color z)
			{
				foreach (WallSnap item in selected.Where((WallSnap x) => x != null && x.ColorPrimaryEnabled))
				{
					item.ColorPrimary = z;
				}
			},
			delegate(Color z)
			{
				foreach (WallSnap item2 in selected.Where((WallSnap x) => x != null && x.ColorSecondaryEnabled))
				{
					item2.ColorSecondary = z;
				}
			},
			delegate(Color z)
			{
				foreach (WallSnap item3 in selected.Where((WallSnap x) => x != null && x.ColorTertiaryEnabled))
				{
					item3.ColorTertiary = z;
				}
			}
		};
		List<Color> list3 = new List<Color>
		{
			selected[0].ActualColorPrimary,
			selected[0].ActualColorSecondary,
			selected[0].ActualColorTertiary
		};
		if (selected.Any((WallSnap x) => x.ColorTertiaryEnabled))
		{
			list.Insert(0, array[2]);
		}
		else
		{
			list2.RemoveAt(2);
			list3.RemoveAt(2);
		}
		if (selected.Any((WallSnap x) => x.ColorSecondaryEnabled))
		{
			list.Insert(0, array[1]);
		}
		else
		{
			list2.RemoveAt(1);
			list3.RemoveAt(1);
		}
		if (selected.Any((WallSnap x) => x.ColorPrimaryEnabled))
		{
			list.Insert(0, array[0]);
		}
		else
		{
			list2.RemoveAt(0);
			list3.RemoveAt(0);
		}
		string[] tabs = list.ToArray();
		GameSettings.Instance.AddUndo(new UndoObject.UndoAction(selected));
		selected.ForEachEnum(delegate(WallSnap x)
		{
			x.Stylize(true);
		});
		WindowManager.SpawnColorDialog(tabs, list2, list3, hashSet, delegate
		{
			foreach (WallSnap item4 in selected.Where((WallSnap x) => x != null))
			{
				item4.ToggleDoors(false, false, true);
				item4.RefreshHighlight();
				item4.Stylize(false);
			}
			MaterialPreviewer.RefreshSelectedStyle(MaterialPreviewer.Mode.Furniture);
		}, true, null, delegate
		{
			selected.ForEachEnum(delegate(WallSnap x)
			{
				x.UpdateStyleNetwork();
			});
		});
	}

	public static void FurnitureStyle(Selectable[] xs, SelectorController y)
	{
		List<WallSnap> list = xs.OfType<WallSnap>().Where((WallSnap x) =>
		{
			UserImageFrame component;
			return x != null && (x.AtlasObject != null || x.ReplacementGroups.Length != 0 || x.TryGetComponent<UserImageFrame>(out component));
		}).ToList();
		if (list.Count > 0)
		{
			string chosen = (from x in list
				group x by x.name).MaxInstance((IGrouping<string, WallSnap> x) => x.Count()).Key;
			HUD.Instance.textureWindow.Show(list.Where((WallSnap x) => x.name.Equals(chosen)).ToList());
			return;
		}
		List<CompanySignage> list2 = (from x in xs.OfType<Furniture>()
			where x != null
			select x).SelectNotNull((Furniture x) => x.Signage).ToList();
		if (list2.Count > 0)
		{
			HUD.Instance.logoWindow.Show(list2);
		}
	}

	private static void FurnitureRandomStyle(Selectable[] xs, SelectorController y)
	{
		List<Furniture> list = (from x in xs.OfType<Furniture>()
			where x != null && x.AtlasObject != null
			select x).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		GameSettings instance = GameSettings.Instance;
		UndoObject.UndoAction[] array = new UndoObject.UndoAction[1];
		WallSnap[] furns = list.ToArray();
		array[0] = new UndoObject.UndoAction(furns, true);
		instance.AddUndo(array);
		HashSet<int> hashSet = new HashSet<int>();
		foreach (IGrouping<string, Furniture> item in from x in list
			group x by x.name)
		{
			bool flag = true;
			List<Furniture> list2 = item.ToList();
			for (int num = 0; num < list2.Count; num++)
			{
				Furniture furniture = list2[num];
				if (num == 0)
				{
					furniture.AtlasIndex = UnityEngine.Random.Range(0, furniture.AtlasCount / furniture.AtlasSkip) * furniture.AtlasSkip + furniture.AtlasOff;
					continue;
				}
				if (flag)
				{
					hashSet.Clear();
					for (int num2 = 0; num2 < furniture.AtlasCount / furniture.AtlasSkip; num2++)
					{
						hashSet.Add(num2 * furniture.AtlasSkip + furniture.AtlasOff);
					}
					flag = false;
				}
				for (int num3 = 0; num3 < num; num3++)
				{
					if (furniture.Parent == list2[num3].Parent && furniture.transform.position.ManhattanDist(list2[num3].transform.position) < 2f)
					{
						hashSet.Remove(list2[num3].AtlasIndex);
						flag = true;
					}
				}
				furniture.AtlasIndex = ((hashSet.Count > 0 && flag) ? hashSet.GetRandom(hashSet.Count) : (UnityEngine.Random.Range(0, furniture.AtlasCount / furniture.AtlasSkip) * furniture.AtlasSkip + furniture.AtlasOff));
			}
		}
	}

	private static void TypesInRoom(Selectable[] xs, SelectorController y)
	{
		HintController.Show(HintController.Hints.HintSelectFurnitureType);
		y.Selected.ForEachEnum(delegate(Selectable x)
		{
			x.Highlight(false);
		});
		y.Selected.Clear();
		Furniture[] array = xs.SelectNotNull((Selectable x) => x.GetComponent<Furniture>()).ToArray();
		bool flag = array.Length == 0;
		HashSet<ValueTuple<string, int>> hashSet = array.Select([return: TupleElementNames(new string[] { "Type", "SelectionSubType" })] (Furniture x) => new ValueTuple<string, int>(x.Type, x.SelectionSubType)).ToHashSet();
		HashSet<Room> hashSet2 = array.Select((Furniture x) => x.Parent).ToHashSet();
		hashSet2.AddRange(xs.SelectNotNull((Selectable x) => x.GetComponent<Room>()));
		foreach (Room item in hashSet2)
		{
			foreach (Room item2 in item.GetConnectedAtriumRoomsForSelection())
			{
				List<Furniture> furnitures = item2.GetFurnitures();
				for (int num = 0; num < furnitures.Count; num++)
				{
					Furniture furniture = furnitures[num];
					if (!furniture.IsSelectionRestricted() && (flag || hashSet.Contains(new ValueTuple<string, int>(furniture.Type, furniture.SelectionSubType))))
					{
						y.Selected.Add(furniture.GetComponent<Selectable>());
					}
				}
			}
		}
		y.DoPostSelectChecks();
	}

	private static void SetInsure(Selectable[] xs, SelectorController y)
	{
		bool flag = true;
		bool insured = false;
		foreach (Furniture item in from x in xs.OfType<Furniture>()
			where x.Insurable
			select x)
		{
			if (flag)
			{
				insured = !item.Insured;
				flag = false;
			}
			item.Insured = insured;
		}
	}

	private static bool IsInsured(Selectable[] xs)
	{
		Furniture furniture = xs.FirstOrDefaultOf<Furniture>();
		if (furniture != null && furniture.Insurable)
		{
			return furniture.Insured;
		}
		return false;
	}

	private static void SetLightAlwaysOn(Selectable[] xs, SelectorController y)
	{
		bool flag = true;
		bool lightAlwaysOn = false;
		foreach (Furniture item in from x in xs.OfType<Furniture>()
			where x.HasLamp
			select x)
		{
			if (flag)
			{
				lightAlwaysOn = !item.LightAlwaysOn;
				flag = false;
			}
			item.LightAlwaysOn = lightAlwaysOn;
		}
	}

	private static bool IsLamp(Selectable[] xs)
	{
		Furniture furniture = xs.OfType<Furniture>().FirstOrDefault((Furniture z) => z.HasLamp);
		if (furniture != null)
		{
			return furniture.LightAlwaysOn;
		}
		return false;
	}

	private static bool NeedInsurance()
	{
		if (GameSettings.Instance.Insurance.ContentInsurance <= 0)
		{
			return GameSettings.Instance.Insurance.ActualContentInsurance > 0;
		}
		return true;
	}

	private static void SegmentsInRoom(Selectable[] xs, SelectorController y)
	{
		y.Selected.ForEachEnum(delegate(Selectable x)
		{
			x.Highlight(false);
		});
		y.Selected.Clear();
		RoomSegment[] array = xs.SelectNotNull((Selectable x) => x.GetComponent<RoomSegment>()).ToArray();
		bool flag = array.Length == 0;
		HashSet<string> hashSet = array.Select((RoomSegment x) => x.name).ToHashSet();
		HashSet<Room> hashSet2 = xs.SelectNotNull((Selectable x) => x.GetComponent<Room>()).ToHashSet();
		foreach (RoomSegment obj in array)
		{
			Room parentRoom = obj.GetParentRoom(true);
			if (parentRoom != null && !parentRoom.Outside)
			{
				hashSet2.Add(parentRoom);
			}
			parentRoom = obj.GetParentRoom(false);
			if (parentRoom != null && !parentRoom.Outside)
			{
				hashSet2.Add(parentRoom);
			}
		}
		foreach (Room item in hashSet2)
		{
			List<RoomSegment> segments = item.GetSegments();
			for (int num2 = 0; num2 < segments.Count; num2++)
			{
				RoomSegment roomSegment = segments[num2];
				if (!roomSegment.IsSelectionRestricted() && (flag || hashSet.Contains(roomSegment.name)))
				{
					y.Selected.Add(roomSegment.GetComponent<Selectable>());
				}
			}
		}
		y.DoPostSelectChecks();
	}

	private static void AutoAssignComputers(List<Room> xs, bool askTeam)
	{
		if (askTeam)
		{
			List<string> teams = GameSettings.Instance.sActorManager.Teams.Keys.ToList();
			if (teams.Count == 1)
			{
				HashSet<Furniture> comps = xs.Where((Room x) => x.Teams.Count == 0).ToList().SelectMany((Room x) => from y in x.GetFurniture("Computer")
					where y.OwnedBy == null
					select y)
					.ToHashSet();
				AutoAssignCompTeam(new HashSet<Team> { GameSettings.Instance.sActorManager.Teams[teams[0]] }, comps);
				return;
			}
			WindowManager.Instance.MultiWindow.Show("Team", teams, delegate(int i)
			{
				HashSet<Furniture> comps2 = xs.Where((Room x) => x.Teams.Count == 0).ToList().SelectMany((Room x) => from y in x.GetFurniture("Computer")
					where y.OwnedBy == null
					select y)
					.ToHashSet();
				AutoAssignCompTeam(new HashSet<Team> { GameSettings.Instance.sActorManager.Teams[teams[i]] }, comps2);
			}, false);
			return;
		}
		List<Room> list = xs.Where((Room x) => x.Teams.Count > 0).ToList();
		AutoAssignCompTeam(comps: list.SelectMany((Room x) => from y in x.GetFurniture("Computer")
			where y.OwnedBy == null
			select y).ToHashSet(), teams: list.SelectMany((Room x) => x.Teams).ToHashSet());
	}

	private static void AutoAssignCompTeam(HashSet<Team> teams, HashSet<Furniture> comps)
	{
		if (comps.Count == 0)
		{
			return;
		}
		List<Actor> list = teams.SelectMany((Team x) => from y in x.GetEmployeesDirect()
			where !y.Owns.Any((Furniture z) => z.Type.Equals("Computer"))
			select y).ToList();
		SortedList<float, KeyValuePair<Furniture, Actor>> sortedList = new SortedList<float, KeyValuePair<Furniture, Actor>>(new Utilities.DuplicateReverseKeyComparer<float>());
		foreach (Furniture comp in comps)
		{
			for (int num = 0; num < list.Count; num++)
			{
				Actor actor = list[num];
				if (comp.Parent.AllowedInRoom(actor))
				{
					float num2 = comp.GetMaxEffectivenessValue(actor.employee);
					if (comp.Parent.ForceRole >= 0 && (Employee.RoleToMask[comp.Parent.ForceRole] & actor.GetRole()) > Employee.RoleBit.None)
					{
						num2 += 2f;
					}
					sortedList.Add(num2, new KeyValuePair<Furniture, Actor>(comp, actor));
				}
			}
		}
		HashSet<Actor> hashSet = new HashSet<Actor>();
		HashSet<Furniture> hashSet2 = new HashSet<Furniture>();
		foreach (KeyValuePair<float, KeyValuePair<Furniture, Actor>> item in sortedList)
		{
			if (!hashSet.Contains(item.Value.Value) && !hashSet2.Contains(item.Value.Key))
			{
				hashSet.Add(item.Value.Value);
				hashSet2.Add(item.Value.Key);
				item.Value.Key.OwnedBy = item.Value.Value;
			}
			if (hashSet.Count == list.Count || hashSet2.Count == comps.Count)
			{
				break;
			}
		}
	}

	public static void MergeRooms(Selectable[] xs, SelectorController y)
	{
		if (!GameSettings.ConstructionAllowed())
		{
			return;
		}
		List<Room> list = (from x in xs.Where((Selectable x) => x != null).OfType<Room>()
			where x.Burn <= 0f
			select x).ToList();
		if (list.Count <= 1)
		{
			return;
		}
		List<Room> list2 = new List<Room>();
		List<Room> list3 = new List<Room>();
		bool outDoor = list[0].Outdoors;
		bool pillar = list[0].Pillar;
		list.RemoveAll((Room x) => x.Outdoors != outDoor || x.Pillar != pillar);
		for (int num = 0; num < list.Count; num++)
		{
			if (!list[num].TryFixEdges())
			{
				list.RemoveAt(num);
				num--;
			}
		}
		if (list.Count <= 1)
		{
			return;
		}
		list2.Add(list[0]);
		list.RemoveAt(0);
		while (list2.Count > 0)
		{
			Room room = list2.First();
			list2.Remove(room);
			list3.Add(room);
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				if (room.CanMerge(list[num2]))
				{
					list2.Add(list[num2]);
					list.RemoveAt(num2);
					num2--;
				}
			}
		}
		if (list.Count != 0 || list3.Count <= 1)
		{
			return;
		}
		List<UndoObject.UndoAction> list4 = new List<UndoObject.UndoAction>();
		int num3 = 1;
		List<Selectable> list5 = new List<Selectable>();
		while (num3 > 0 && list3.Count > 1)
		{
			num3 = 0;
			for (int num4 = 1; num4 < list3.Count; num4++)
			{
				if (list3[0].CanMerge(list3[num4]))
				{
					Dictionary<WallSnap, UndoObject.UndoAction> snaps = list3[0].PrepareSplit(true);
					List<Vector2> split = list3[0].MergeWith(list3[num4], snaps, list4);
					list4.Add(new UndoObject.UndoAction(list3[0], list3[num4], split));
					list5.Remove(list3[num4]);
					num3++;
					list3.RemoveAt(num4);
					num4--;
				}
				else
				{
					list5.Add(list3[num4]);
				}
			}
		}
		list4.Reverse();
		GameSettings.Instance.AddUndo(list4.ToArray());
		y.Selected.Clear();
		y.Selected.Add(list3[0]);
		y.Selected.AddRange(list5);
		y.DoPostSelectChecks();
	}

	private static void DuplicateAction(Selectable[] xs, SelectorController y)
	{
		if (!GameSettings.ConstructionAllowed())
		{
			return;
		}
		if (EnableDupeHint)
		{
			HintController.Show(HintController.Hints.HintDuplicateStuff);
		}
		BuildController.Instance.ClearBuild();
		List<Furniture> list = new List<Furniture>();
		for (int i = 0; i < xs.Length; i++)
		{
			Furniture component = xs[i].GetComponent<Furniture>();
			if (component != null)
			{
				if (!string.IsNullOrWhiteSpace(component.MetalMarket))
				{
					AchievementController.SetAchievement("COPYGOLD");
				}
				if (component.IsUnlocked() && component.CanCopy)
				{
					list.Add(component);
				}
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		RecursiveRemoveChildren(list);
		Furniture furn = list.FirstOrDefault();
		list.RemoveAll((Furniture x) => x.Parent != furn.Parent);
		if (list.Count > 1)
		{
			Vector2 pos = new Vector2(list.Average((Furniture x) => x.OriginalPosition.x), list.Average((Furniture x) => x.OriginalPosition.z));
			list = (from x in list
				orderby (x.WallFurn || x.IsSnapping) ? 1 : 0, (x.OriginalPosition.FlattenVector3() - pos).magnitude
				select x).ToList();
			furn = list[0];
		}
		else
		{
			HintController.Show(HintController.Hints.HintFurnitureCopyMultiple);
		}
		list.Remove(furn);
		FurnitureBuilder component2 = UnityEngine.Object.Instantiate(BuildController.Instance.FurnitureBuilderPrefab).GetComponent<FurnitureBuilder>();
		BuildController.Instance.CurrentFurnitureBuilder = component2;
		component2.FurnPrefab = furn.gameObject;
		component2.IsProto = true;
		component2.CopyProto = true;
		foreach (Furniture item in list)
		{
			FurnitureBuilder component3 = UnityEngine.Object.Instantiate(BuildController.Instance.FurnitureBuilderPrefab).GetComponent<FurnitureBuilder>();
			component3.FurnPrefab = item.gameObject;
			component3.IsProto = true;
			component3.CopyProto = true;
			component3.Parent = component2;
			component2.Children.Add(component3);
		}
	}

	public static void MaterialAction(Selectable[] xs, SelectorController y)
	{
		List<Room> list = (from x in xs.OfType<Room>()
			where x != null
			select x).ToList();
		if (list.Count > 0)
		{
			Selectable.DisableDiagonalHighlights = true;
			y.Highligt(true);
			HUD.Instance.textureWindow.Show(list);
		}
	}

	public static void RoofMaterialAction(Selectable[] xs, SelectorController y)
	{
		List<Roof> list = (from x in xs.OfType<Roof>()
			where x != null
			select x).ToList();
		if (list.Count > 0)
		{
			HUD.Instance.textureWindow.Show(list);
		}
	}

	private static void EditRoof(Selectable[] xs, SelectorController y)
	{
		Roof roof = xs.FirstOrDefaultOf((Roof x) => x != null);
		if (roof != null)
		{
			HUD.Instance.roofEditWindow.Show(roof);
		}
	}

	private static void ToggleElevator(Selectable[] xs, SelectorController y)
	{
		foreach (Furniture item in xs.OfType<Furniture>())
		{
			item.CanExitElevator = !item.CanExitElevator;
			item.Parent.DirtyPathNodes = true;
			item.UpdateElevatorDisplay();
		}
	}

	private static bool CanExitElevator(Selectable[] xs)
	{
		Furniture furniture = xs.FirstOrDefaultOf<Furniture>();
		if (furniture != null)
		{
			return furniture.CanExitElevator;
		}
		return false;
	}

	private static void ClearBoxes(Selectable[] xs, SelectorController y)
	{
		foreach (Furniture item in xs.OfType<Furniture>())
		{
			if (item.HasConveyor)
			{
				for (int i = 0; i < item.Conveyor.CurrentBoxes.Length; i++)
				{
					TransportBox transportBox = item.Conveyor.CurrentBoxes[i];
					if (transportBox != null)
					{
						GameSettings.Instance.BoxController.DestroyBox(transportBox);
					}
				}
				item.Conveyor.UpdateBlockStatus();
			}
			if (!(item.Printer != null) || item.Printer.Type != ProductPrinter.PrinterType.Assembly)
			{
				continue;
			}
			lock (item.Printer.ManufactureQueue)
			{
				for (int j = 0; j < item.Printer.ManufactureQueue.Count; j++)
				{
					item.Printer.ManufactureQueue[j].RemoveFromStorage();
				}
				item.Printer.ManufactureQueue.Clear();
			}
		}
	}

	private static void ToggleConveyorOnState(Selectable[] xs, SelectorController y)
	{
		List<Conveyor> list = (from x in xs.OfType<Furniture>()
			where x.Type.Equals("Conveyor") && x.Conveyor.OutputLength == 1
			select x.Conveyor).ToList();
		if (list.Count > 0)
		{
			bool val = !list[0].Parent.IsOn;
			HashSet<Conveyor> hashSet = new HashSet<Conveyor>();
			for (int num = 0; num < list.Count; num++)
			{
				FindAllConveyors(list[num], hashSet);
			}
			hashSet.ForEachEnum(delegate(Conveyor x)
			{
				x.Parent.IsOn = val;
			});
		}
	}

	private static bool IsConveyorOn(Selectable[] xs)
	{
		Furniture furniture = xs.OfType<Furniture>().FirstOrDefault((Furniture x) => x.Type.Equals("Conveyor") && x.Conveyor.OutputLength == 1);
		if (furniture != null)
		{
			return furniture.IsOn;
		}
		return false;
	}

	private static void EditSegmentTag(Selectable[] xs, SelectorController y)
	{
		List<RoomSegment> cons = (from x in xs.OfType<RoomSegment>()
			where x.Taggable
			select x).ToList();
		if (cons.Count <= 0)
		{
			return;
		}
		WindowManager.SpawnInputDialog("TagEditPrompt".Loc(), "ActionEditTag".Loc(), cons.Mode((RoomSegment x) => x.TagText, ""), delegate(string x)
		{
			cons.ForEach(delegate(RoomSegment z)
			{
				z.TagText = x;
			});
		}, null, 25);
	}

	private static void FindAllConveyors(Conveyor c, HashSet<Conveyor> visited)
	{
		if (!(c != null) || !c.Parent.Type.Equals("Conveyor") || c.OutputLength != 1 || !visited.Add(c))
		{
			return;
		}
		foreach (Conveyor input in c.Inputs)
		{
			FindAllConveyors(input, visited);
		}
		for (int i = 0; i < c.OutputLength; i++)
		{
			FindAllConveyors(c.GetOutput(i), visited);
		}
	}

	private static void ShowAssemblerDetails(Selectable[] xs, SelectorController y)
	{
		Furniture furniture = xs.OfType<Furniture>().FirstOrDefault((Furniture x) => x.Printer != null && x.Printer.Type == ProductPrinter.PrinterType.Assembly);
		if (furniture != null)
		{
			HUD.Instance.AssemblerWindow.Show(furniture.Printer);
		}
	}

	private static void SetComponentOutput(Selectable[] xs, SelectorController y)
	{
		List<ProductPrinter> printers = xs.OfType<Furniture>().SelectNotNull((Furniture x) => x.Printer).ToList();
		int num = printers.Count((ProductPrinter x) => x.Type == ProductPrinter.PrinterType.Assembly);
		if (num > printers.Count - num)
		{
			IManufacturable def = printers.Where((ProductPrinter x) => x.Type == ProductPrinter.PrinterType.Assembly).Mode(delegate(ProductPrinter x)
			{
				Manufacturing manufacturing = x.GetManufacturing();
				return (manufacturing == null) ? null : manufacturing.Category;
			});
			HUD.Instance.ManufacturingSelectWindow.Show(true, def, delegate(object x)
			{
				ComponentProcess targetProcess;
				if (x == null)
				{
					targetProcess = null;
				}
				else
				{
					IManufacturable manufacturable = x as IManufacturable;
					targetProcess = ((manufacturable != null) ? manufacturable.GetManufacturing().FinalProcess : ((HardwareComponent)x).OutputProcess);
				}
				for (int i = 0; i < printers.Count; i++)
				{
					ProductPrinter productPrinter = printers[i];
					if (productPrinter != null && productPrinter.Type == ProductPrinter.PrinterType.Assembly)
					{
						productPrinter.SetTargetProcess(targetProcess);
					}
				}
			});
			return;
		}
		IManufacturable def2 = printers.Where((ProductPrinter x) => x.Type == ProductPrinter.PrinterType.Component).Mode(delegate(ProductPrinter x)
		{
			Manufacturing manufacturing = x.GetManufacturing();
			return (manufacturing == null) ? null : manufacturing.Category;
		});
		HUD.Instance.ManufacturingSelectWindow.Show(false, def2, delegate(object x)
		{
			HardwareComponent targetComponent = (HardwareComponent)x;
			for (int i = 0; i < printers.Count; i++)
			{
				ProductPrinter productPrinter = printers[i];
				if (productPrinter != null && productPrinter.Type == ProductPrinter.PrinterType.Component)
				{
					productPrinter.SetTargetComponent(targetComponent);
				}
			}
		});
	}

	private static void EducateAction(Selectable[] xs, SelectorController y)
	{
		HUD.Instance.educationWindow.Show(xs.OfType<Actor>());
	}

	private static void DismissAction(Selectable[] xs, SelectorController y)
	{
		HintController.Show(HintController.Hints.DeleteKeyHintHint);
		WindowManager.Instance.ShowMessageBox("DismissMsg".Loc(xs.Length), true, "Trash", DialogWindow.DialogType.Error, DialogWindow.DialogType.Warning, delegate
		{
			foreach (Actor item in from x in xs
				where x != null
				select x.GetComponent<Actor>() into x
				where x != null
				select x)
			{
				item.Fire(false);
				if (item.AItype == AI.AIType.Employee)
				{
					GameSettings.Instance.RegisterStat("Fired", 1f);
				}
			}
		});
	}

	private static void MoveAction(Selectable[] xs, SelectorController y)
	{
		if (!GameSettings.ConstructionAllowed())
		{
			return;
		}
		if (EnableMoveHint)
		{
			HintController.Show(HintController.Hints.HintMoveFurniture);
		}
		BuildController.Instance.ClearBuild();
		List<Furniture> list = (from x in xs.Where((Selectable x) => x != null && x.gameObject != null).OfType<Furniture>()
			where !x.Parent.BuildingOnFire
			select x).ToList();
		RecursiveRemoveChildren(list);
		Furniture furn = list.FirstOrDefault();
		if (!(furn != null))
		{
			return;
		}
		list.RemoveAll((Furniture x) => x.Parent != furn.Parent);
		if (list.Count > 1)
		{
			Vector3 pos = new Vector3(list.Average((Furniture x) => x.OriginalPosition.x), list[0].OriginalPosition.y, list.Average((Furniture x) => x.OriginalPosition.z));
			list = (from x in list
				orderby x.WallFurn ? 1 : 0, (x.OriginalPosition - pos).magnitude
				select x).ToList();
			furn = list[0];
		}
		list.Remove(furn);
		FurnitureBuilder component = UnityEngine.Object.Instantiate(BuildController.Instance.FurnitureBuilderPrefab).GetComponent<FurnitureBuilder>();
		BuildController.Instance.CurrentFurnitureBuilder = component;
		component.FurnPrefab = furn.gameObject;
		component.IsProto = true;
		foreach (Furniture item in list)
		{
			FurnitureBuilder component2 = UnityEngine.Object.Instantiate(BuildController.Instance.FurnitureBuilderPrefab).GetComponent<FurnitureBuilder>();
			component2.FurnPrefab = item.gameObject;
			component2.IsProto = true;
			component2.Parent = component;
			component.Children.Add(component2);
		}
	}

	public static void RoomColorAction(Selectable[] xs, SelectorController y)
	{
		Room[] rooms = (from x in xs
			select x.GetComponent<Room>() into x
			where x != null
			select x).ToArray();
		if (rooms.Length == 0)
		{
			return;
		}
		bool flag = rooms.All((Room x) => x.Outdoors || x.IsBalcony);
		bool num = !GameSettings.Instance.EditMode && GameSettings.Instance.RentMode;
		HashSet<Color> hashSet = new HashSet<Color>();
		List<string> list = new List<string>();
		List<Action<Color>> list2 = new List<Action<Color>>();
		List<Color> list3 = new List<Color>();
		if (!num)
		{
			if (flag)
			{
				hashSet.AddRange(rooms.Select((Room x) => x.OutsideColor));
				list.Add("Fence".Loc());
				list3.Add(rooms[0].FenceColor);
				list2.Add(delegate(Color color)
				{
					Room[] array = rooms;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].FenceColor = color;
					}
				});
			}
			else
			{
				hashSet.AddRange(rooms.Select((Room x) => x.OutsideColor));
				list.Add("Exterior".Loc());
				list3.Add(rooms[0].OutsideColor);
				list2.Add(delegate(Color color)
				{
					Room[] array = rooms;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].OutsideColor = color;
					}
				});
				if (rooms.Any((Room x) => RoomMaterialController.AllowSecondaryRecolor(x.OutsideMat)))
				{
					hashSet.AddRange(rooms.Select((Room x) => x.OutsideColor2));
					list.Add("Exterior".Loc() + " 2");
					list3.Add(rooms[0].OutsideColor2);
					list2.Add(delegate(Color color)
					{
						Room[] array = rooms;
						foreach (Room room in array)
						{
							if (RoomMaterialController.AllowSecondaryRecolor(room.OutsideMat))
							{
								room.OutsideColor2 = color;
							}
						}
					});
				}
			}
		}
		if (!flag)
		{
			hashSet.AddRange(rooms.Select((Room x) => x.InsideColor));
			list.Add("Interior".Loc());
			list3.Add(rooms[0].InsideColor);
			list2.Add(delegate(Color color)
			{
				Room[] array = rooms;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].InsideColor = color;
				}
			});
			if (rooms.Any((Room x) => RoomMaterialController.AllowSecondaryRecolor(x.InsideMat)))
			{
				hashSet.AddRange(rooms.Select((Room x) => x.InsideColor2));
				list.Add("Interior".Loc() + " 2");
				list3.Add(rooms[0].InsideColor2);
				list2.Add(delegate(Color color)
				{
					Room[] array = rooms;
					foreach (Room room in array)
					{
						if (RoomMaterialController.AllowSecondaryRecolor(room.InsideMat))
						{
							room.InsideColor2 = color;
						}
					}
				});
			}
		}
		hashSet.AddRange(rooms.Select((Room x) => x.FloorColor));
		list.Add("Floor".Loc());
		list3.Add(rooms[0].FloorColor);
		list2.Add(delegate(Color color)
		{
			Room[] array = rooms;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].FloorColor = color;
			}
		});
		if (rooms.Any((Room x) => RoomMaterialController.AllowSecondaryRecolor(x.FloorMat)))
		{
			hashSet.AddRange(rooms.Select((Room x) => x.FloorColor2));
			list.Add("Floor".Loc() + " 2");
			list3.Add(rooms[0].FloorColor2);
			list2.Add(delegate(Color color)
			{
				Room[] array = rooms;
				foreach (Room room in array)
				{
					if (RoomMaterialController.AllowSecondaryRecolor(room.FloorMat))
					{
						room.FloorColor2 = color;
					}
				}
			});
		}
		Selectable.DisableDiagonalHighlights = true;
		y.Highligt(true);
		GameSettings.Instance.AddUndo(new UndoObject.UndoAction(rooms.ToList(), false));
		WindowManager.SpawnColorDialog(list, list2, list3, hashSet, delegate
		{
			MaterialPreviewer.RefreshSelectedStyle(MaterialPreviewer.Mode.Room | MaterialPreviewer.Mode.Fence | MaterialPreviewer.Mode.Balcony);
			Selectable.DisableDiagonalHighlights = false;
			y.Highligt(true);
		}, true, null, delegate
		{
			rooms.ForEachEnum(delegate(Room x)
			{
				x.UpdateStyleNetwork();
			});
		});
	}

	public static void RoofColorAction(Selectable[] xs, SelectorController y)
	{
		Roof[] roofs = (from x in xs
			select x.GetComponent<Roof>() into x
			where x != null
			select x).ToArray();
		if (roofs.Length == 0)
		{
			return;
		}
		HashSet<Color> hashSet = new HashSet<Color>();
		hashSet = roofs.SelectMany((Roof x) => new Color[2] { x.RoofColor, x.GableColor }).ToHashSet();
		List<string> list = new List<string>();
		List<Color> list2 = new List<Color>();
		list.Add("Roof".Loc());
		list2.Add(roofs[0].RoofColor);
		hashSet.AddRange(roofs.Select((Roof x) => x.RoofColor));
		List<Action<Color>> list3 = new List<Action<Color>>();
		list3.Add(delegate(Color color)
		{
			Roof[] array = roofs;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RoofColor = color;
			}
		});
		if (roofs.Any((Roof x) => RoomMaterialController.AllowSecondaryRecolor(x.RoofMaterial)))
		{
			list.Add("Roof".Loc() + " 2");
			list2.Add(roofs[0].RoofColor2);
			hashSet.AddRange(roofs.Select((Roof x) => x.RoofColor2));
			list3.Add(delegate(Color color)
			{
				Roof[] array = roofs;
				foreach (Roof roof in array)
				{
					if (RoomMaterialController.AllowSecondaryRecolor(roof.RoofMaterial))
					{
						roof.RoofColor2 = color;
					}
				}
			});
		}
		list.Add("Gable".Loc());
		list2.Add(roofs[0].GableColor);
		hashSet.AddRange(roofs.Select((Roof x) => x.GableColor));
		list3.Add(delegate(Color color)
		{
			Roof[] array = roofs;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].GableColor = color;
			}
		});
		if (roofs.Any((Roof x) => RoomMaterialController.AllowSecondaryRecolor(x.GableMaterial)))
		{
			list.Add("Gable".Loc() + " 2");
			list2.Add(roofs[0].GableColor2);
			hashSet.AddRange(roofs.Select((Roof x) => x.GableColor2));
			list3.Add(delegate(Color color)
			{
				Roof[] array = roofs;
				foreach (Roof roof in array)
				{
					if (RoomMaterialController.AllowSecondaryRecolor(roof.GableMaterial))
					{
						roof.GableColor2 = color;
					}
				}
			});
		}
		GameSettings.Instance.AddUndo(new UndoObject.UndoAction(roofs.ToList()));
		WindowManager.SpawnColorDialog(list, list3, list2, hashSet, delegate
		{
			MaterialPreviewer.RefreshSelectedStyle(MaterialPreviewer.Mode.Roof);
		}, true, null, delegate
		{
			roofs.ForEachEnum(delegate(Roof x)
			{
				x.UpdateStyleNetwork();
			});
		});
	}

	public static void PathColorAction(Selectable[] xs, SelectorController y)
	{
		PathObject[] paths = (from x in xs
			select x.GetComponent<PathObject>() into x
			where x != null
			select x).ToArray();
		if (paths.Length == 0)
		{
			return;
		}
		HashSet<Color> hashSet = new HashSet<Color>();
		List<string> list = new List<string>();
		List<Action<Color>> list2 = new List<Action<Color>>();
		List<Color> list3 = new List<Color>();
		list.Add("Primary".Loc());
		list3.Add(paths[0].MatColor);
		hashSet.AddRange(paths.Select((PathObject x) => x.MatColor));
		list2.Add(delegate(Color color)
		{
			PathObject[] array = paths;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].MatColor = color;
			}
		});
		if (paths.Any((PathObject x) => RoomMaterialController.AllowSecondaryRecolor(x.Material)))
		{
			list.Add("Secondary".Loc());
			list3.Add(paths[0].MatColor2);
			hashSet.AddRange(paths.Select((PathObject x) => x.MatColor2));
			list2.Add(delegate(Color color)
			{
				PathObject[] array = paths;
				foreach (PathObject pathObject in array)
				{
					if (RoomMaterialController.AllowSecondaryRecolor(pathObject.Material))
					{
						pathObject.MatColor2 = color;
					}
				}
			});
		}
		GameSettings.Instance.AddUndo(new UndoObject.UndoAction(true, paths));
		WindowManager.SpawnColorDialog(list, list2, list3, hashSet, delegate
		{
			MaterialPreviewer.RefreshSelectedStyle(MaterialPreviewer.Mode.Path);
		});
	}

	private static void PathDestroyAction(Selectable[] xs, SelectorController y)
	{
		UISoundFX.PlaySFX("BuyRev", true);
		PathObject[] array = (from x in xs
			select x.GetComponent<PathObject>() into x
			where x != null
			select x).ToArray();
		GameSettings.Instance.AddUndo(new UndoObject.UndoAction(false, array));
		foreach (PathObject pathObject in array)
		{
			GameSettings.Instance.sRoomManager.PathController.DeleteEntirePath(pathObject);
			y.Selected.Remove(pathObject);
		}
		y.DoPostSelectChecks();
	}

	public static void PathMaterialAction(Selectable[] xs, SelectorController y)
	{
		List<PathObject> list = (from x in xs.OfType<PathObject>()
			where x != null
			select x).ToList();
		if (list.Count > 0)
		{
			HUD.Instance.textureWindow.Show(list);
		}
	}

	private static void ConnectServersAction(Selectable[] xs, SelectorController y)
	{
		List<Server> list = (from x in xs
			select x.GetComponent<Server>() into x
			where x != null
			select x).ToList();
		if (list.Count <= 1)
		{
			return;
		}
		Server server = null;
		List<ServerGroup> list2 = new List<ServerGroup>();
		foreach (IGrouping<string, Server> item in from x in list
			group x by x.ServerName)
		{
			ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(item.Key);
			if (serverGroup.Servers.Count == item.Count())
			{
				if (server == null)
				{
					server = item.First();
				}
				else
				{
					list2.Add(serverGroup);
				}
			}
		}
		if (server == null)
		{
			server = list[0];
			GameSettings.Instance.AddServer(server);
		}
		for (int num = 0; num < list2.Count; num++)
		{
			List<IServerItem> list3 = list2[num].Items.ToList();
			for (int num2 = 0; num2 < list3.Count; num2++)
			{
				GameSettings.Instance.RegisterWithServer(server.ServerName, list3[num2]);
			}
			server.Group.LastUsed += list2[num].LastUsed;
			list2[num].LastUsed = 0f;
		}
		for (int num3 = 1; num3 < list.Count; num3++)
		{
			list[num3].WireTo(server);
		}
		HUD.Instance.serverWindow.UpdateServerList();
		EventHandler onServersChanged = GameSettings.Instance.OnServersChanged;
		if (onServersChanged != null)
		{
			onServersChanged(GameSettings.Instance, null);
		}
	}

	private static void PairRoom(Selectable[] xs, SelectorController y)
	{
		StaffWindow.AssignRoomGroups((from x in xs.OfType<Actor>()
			where AI.IsStaff(x.AItype)
			select x).ToList());
	}

	private static void SaveRoomStyle(Selectable[] xs, SelectorController y)
	{
		Room r = xs.OfType<Room>().FirstOrDefault();
		if (r != null)
		{
			WindowManager.SpawnInputDialog("SaveStylePrompt".Loc(), "", "Roomstyle".Loc(), delegate(string x)
			{
				GameSettings.Instance.RoomStyles.Add(new RoomStyle(x, r));
			});
		}
	}

	private static void ApplyRoomStyle(Selectable[] xs, SelectorController y)
	{
		List<Room> rs = xs.OfType<Room>().ToList();
		if (rs.Count <= 0)
		{
			return;
		}
		bool outdoor = rs[0].Outdoors;
		rs.RemoveAll((Room x) => x.Outdoors != outdoor);
		List<RoomStyle> styles = GameSettings.Instance.RoomStyles.Where((RoomStyle x) => !x.RoofStyle && x.OutdoorStyle == outdoor).ToList();
		WindowManager.Instance.MultiWindow.Show("Roomstyle", styles.Select((RoomStyle x) => x.StyleName), delegate(int i)
		{
			List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>
			{
				new UndoObject.UndoAction(rs, true, true)
			};
			RoomStyle roomStyle = ((i >= 0) ? styles[i] : (outdoor ? GameSettings.Instance.DefaultOutdoorRoomStyle : GameSettings.Instance.DefaultIndoorRoomStyle));
			foreach (Room item in rs)
			{
				roomStyle.Apply(item, list);
			}
			GameSettings.Instance.AddUndo(list.ToArray());
		}, true, true, true, false, delegate(int i)
		{
			GameSettings.Instance.RoomStyles.Remove(styles[i]);
		});
	}

	private static void DefaultStyleAction(Selectable[] xs, SelectorController y)
	{
		for (int i = 0; i < xs.Length; i++)
		{
			Furniture component = xs[i].GetComponent<Furniture>();
			if (component != null)
			{
				if (component.ColorPrimaryEnabled)
				{
					GameSettings.Instance.ColorDefaults[component.DefaultColorGroup + "Primary"] = component.ColorPrimary;
				}
				if (component.ColorSecondaryEnabled)
				{
					GameSettings.Instance.ColorDefaults[component.DefaultColorGroup + "Secondary"] = component.ColorSecondary;
				}
				if (component.ColorTertiaryEnabled)
				{
					GameSettings.Instance.ColorDefaults[component.DefaultColorGroup + "Tertiary"] = component.ColorTertiary;
				}
			}
		}
	}

	private static void ResetDefaultStyleAction(Selectable[] xs, SelectorController y)
	{
		List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
		Furniture[] array = (from x in xs
			select x.GetComponent<Furniture>() into x
			where x != null
			select x).ToArray();
		if (array.Length != 0)
		{
			WallSnap[] furns = array;
			list.Add(new UndoObject.UndoAction(furns));
		}
		Furniture[] array2 = array;
		foreach (Furniture furniture in array2)
		{
			if (furniture.ColorPrimaryEnabled)
			{
				furniture.ColorPrimary = GameSettings.Instance.GetDefaultColor(furniture.DefaultColorGroup + "Primary", furniture.ColorPrimaryDefault);
			}
			if (furniture.ColorSecondaryEnabled)
			{
				furniture.ColorSecondary = GameSettings.Instance.GetDefaultColor(furniture.DefaultColorGroup + "Secondary", furniture.ColorSecondaryDefault);
			}
			if (furniture.ColorTertiaryEnabled)
			{
				furniture.ColorTertiary = GameSettings.Instance.GetDefaultColor(furniture.DefaultColorGroup + "Tertiary", furniture.ColorTertiaryDefault);
			}
		}
		if (list.Count > 0)
		{
			GameSettings.Instance.AddUndo(list.ToArray());
		}
	}

	private static void SelectWallAction(Selectable[] xs, SelectorController y)
	{
		IEnumerable<RoomSegment> source = (from x in xs.WhereSelect((Selectable x) => x != null, (Selectable x) => x.GetComponent<RoomSegment>())
			where x != null
			select x).SelectMany((RoomSegment x) => x.FirstEdge.Children[x.SecondEdge].OfType<RoomSegment>()).Distinct();
		y.Highligt(false);
		y.Selected.Clear();
		y.Selected.AddRange(source.OfType<Selectable>());
		y.DoPostSelectChecks();
	}

	private static void ChangeSalaryAction(Selectable[] xs, SelectorController y)
	{
		HUD.Instance.wageWindow.List.Items.Clear();
		HUD.Instance.wageWindow.List.Items.AddRange((from x in xs
			select x.GetComponent<Actor>() into x
			where x != null && !x.WorksForFree()
			select x).Cast<object>());
		if (HUD.Instance.wageWindow.List.Items.Count > 0)
		{
			HUD.Instance.wageWindow.Show(false);
		}
	}

	private static void SelectStaffAction(Selectable[] xs, SelectorController y)
	{
		foreach (Room item in xs.OfType<Room>())
		{
			item.Highlight(false);
			y.Selected.Remove(item);
			foreach (Room item2 in item.GetConnectedAtriumRoomsForSelection())
			{
				y.Selected.AddRange(item2.Occupants.Where((Actor x) => x != null && !x.IsSelectionRestricted()));
			}
		}
		y.DoPostSelectChecks();
	}

	private static void ReplaceFurnAction(Selectable[] xs, SelectorController y)
	{
		if (GameSettings.ConstructionAllowed())
		{
			List<Furniture> list = (from x in xs
				where x != null
				select x.GetComponent<Furniture>() into x
				where x != null && !string.IsNullOrEmpty(x.UpgradeTo)
				orderby x.GetSnappingDepth() descending
				select x).ToList();
			if (list.Count > 0)
			{
				y.FurnReplacer.Show(list);
			}
		}
	}

	private static void AssignParkingAction(Selectable[] xs, SelectorController y)
	{
		WindowManager.Instance.MultiWindow.Show("ActionAssignParking", RoadNode.ParkingAssignStrings, delegate(int i)
		{
			foreach (RoadNode item in from x in xs
				where x != null
				select x.GetComponent<RoadNode>() into x
				where x != null
				select x)
			{
				item.Assign = (RoadNode.ParkingAssign)i;
			}
		}, false, true, true, true);
	}

	private static void SelectParkedPeopleAction(Selectable[] xs, SelectorController y)
	{
		HashSet<RoadNode> parking = (from x in xs.WhereSelect((Selectable x) => x != null, (Selectable x) => x.GetComponent<RoadNode>())
			where x != null && x.Taken
			select x).ToHashSet();
		if (parking.Count > 0)
		{
			y.Highligt(false);
			y.Selected.Clear();
			y.Selected.AddRange(from x in (from x in RoadManager.Instance.Cars.WhereSelect((CarScript x) => x != null && x.Parked, (CarScript x) => x.GetComponent<NormalCar>())
					where x != null && x.GetGoal() != null && parking.Contains(x.GetGoal())
					select x).SelectMany((NormalCar x) => x.Car.GetOccupants().OfType<Selectable>())
				where !x.IsSelectionRestricted()
				select x);
			y.DoPostSelectChecks();
		}
	}

	private static void SelectNearParkingAction(Selectable[] xs, SelectorController y)
	{
		List<RoadNode> list = (from x in xs.WhereSelect((Selectable x) => x != null, (Selectable x) => x.GetComponent<RoadNode>())
			where x != null
			select x).ToList();
		HashSet<Selectable> hashSet = new HashSet<Selectable>();
		HashSet<RoadSegment> touch = new HashSet<RoadSegment>();
		foreach (RoadNode item in list)
		{
			AddSurrounding(hashSet, touch, Mathf.FloorToInt(item.transform.position.x / RoadManager.Instance.RoadSize), Mathf.FloorToInt(item.transform.position.z / RoadManager.Instance.RoadSize), item.GetRoadFloor());
		}
		y.Highligt(false);
		y.Selected.Clear();
		y.Selected.AddRange(hashSet);
		y.DoPostSelectChecks();
	}

	private static void AddSurrounding(HashSet<Selectable> park, HashSet<RoadSegment> touch, int x, int y, int floor)
	{
		RoadSegment segment = RoadManager.Instance.GetSegment(x, y, floor);
		if (!(segment != null) || segment.Parking.Length == 0 || touch.Contains(segment))
		{
			return;
		}
		touch.Add(segment);
		bool flag = false;
		for (int i = 0; i < segment.Parking.Length; i++)
		{
			RoadNode roadNode = segment.Parking[i];
			if (!roadNode.IsSelectionRestricted())
			{
				flag = true;
				park.Add(roadNode);
			}
		}
		if (flag)
		{
			AddSurrounding(park, touch, x - 1, y, floor);
			AddSurrounding(park, touch, x + 1, y, floor);
			AddSurrounding(park, touch, x, y - 1, floor);
			AddSurrounding(park, touch, x, y + 1, floor);
		}
	}

	private static void DetailsAction(Selectable[] xs, SelectorController y)
	{
		Actor actor = xs.OfType<Actor>().FirstOrDefault();
		if (actor != null)
		{
			HUD.Instance.DetailWindow.Show(actor);
		}
	}

	private static void SelectTeamAction(Selectable[] xs, SelectorController y)
	{
		foreach (Actor item in xs.OfType<Actor>())
		{
			if (item.GetTeam() == null)
			{
				continue;
			}
			item.GetTeam().GetEmployees().ToList()
				.ForEach(delegate(Actor z)
				{
					if (!y.Selected.Contains(z.GetComponent<Selectable>()))
					{
						y.Selected.Add(z.GetComponent<Selectable>());
					}
				});
			y.DoPostSelectChecks();
		}
	}

	private static void SelectOwnedAction(Selectable[] xs, SelectorController y)
	{
		y.Selected.Clear();
		foreach (Actor item in xs.OfType<Actor>())
		{
			item.Highlight(false);
			item.Owns.ForEachEnum(delegate(Furniture z)
			{
				if (!y.Selected.Contains(z))
				{
					y.Selected.Add(z);
				}
			});
		}
		y.DoPostSelectChecks();
	}

	private static void UnpairAction(Selectable[] xs, SelectorController y)
	{
		foreach (Furniture item in xs.OfType<Furniture>())
		{
			if (item.OwnedBy != null)
			{
				item.OwnedBy = null;
			}
		}
	}

	private static void PairUse(Selectable[] xs, SelectorController y)
	{
		foreach (Actor item in xs.OfType<Actor>())
		{
			Furniture furniture = ((item.UsingPoint == null) ? null : item.UsingPoint.Parent);
			if (furniture != null && furniture.CanAssign)
			{
				furniture.OwnedBy = item;
			}
		}
	}

	private static void ToggleRentable(Selectable[] xs, SelectorController y)
	{
		foreach (Room item in (from x in xs.OfType<Room>()
			select x.ParentRoom ?? x).Distinct())
		{
			item.Rentable = !item.Rentable;
		}
	}

	private static bool IsRentable(Selectable[] xs)
	{
		Room room = xs.FirstOrDefaultOf<Room>();
		if (room != null)
		{
			return (room.ParentRoom ?? room).Rentable;
		}
		return false;
	}

	private static void TogglePlayerOwned(Selectable[] xs, SelectorController y)
	{
		foreach (Room item in (from x in xs.OfType<Room>()
			select x.ParentRoom ?? x).Distinct())
		{
			item.SetPlayerOwned(!item.PlayerOwned, null);
		}
	}

	private static bool IsPlayerOwned(Selectable[] xs)
	{
		Room room = xs.FirstOrDefaultOf<Room>();
		if (room != null)
		{
			return (room.ParentRoom ?? room).PlayerOwned;
		}
		return false;
	}

	private static void GroupRentRooms(Selectable[] xs, SelectorController y)
	{
		List<Room> list = xs.OfType<Room>().ToList();
		if (list.Count <= 0)
		{
			return;
		}
		Room room = null;
		bool flag = true;
		for (int i = 0; i < list.Count; i++)
		{
			Room room2 = list[i];
			Room room3 = room2.ParentRoom ?? room2;
			if (room == null)
			{
				room = room3;
			}
			else if (room3 != room)
			{
				flag = false;
				break;
			}
		}
		if (flag && room != null)
		{
			flag &= room.ChildrenRooms.Count + 1 == list.Count;
		}
		list[0].UnGroup();
		for (int j = 1; j < list.Count; j++)
		{
			if (flag)
			{
				list[j].UnGroup();
			}
			else
			{
				list[j].GroupTo(list[0]);
			}
		}
	}

	private static void AutoGroupRentRooms(Selectable[] xs, SelectorController y)
	{
		HashSet<Room> rs = xs.OfType<Room>().ToHashSet();
		Room outside = GameSettings.Instance.sRoomManager.Outside;
		rs.Remove(outside);
		PathNode<Vector3> firstPathNode = outside.GetFirstPathNode();
		Dictionary<Room, HashSet<Room>> dictionary = new Dictionary<Room, HashSet<Room>>();
		HashSet<Room> hashSet = new HashSet<Room>();
		foreach (Room item2 in rs)
		{
			if (!item2.Rentable || hashSet.Contains(item2))
			{
				continue;
			}
			List<PathNode<Vector3>> list = NodePathFinding<Vector3>.FindPathNodes(item2.GetFirstPathNode(), firstPathNode, (Vector3 x, Vector3 z) => (x - z).magnitude, (Vector3 x, Vector3 z) => (x - z).magnitude, (object x) => x == outside || !(x is Room) || rs.Contains((Room)x));
			if (list == null)
			{
				continue;
			}
			hashSet.Add(item2);
			List<Room> list2 = list.Select((PathNode<Vector3> x) => x.Tag).OfType<Room>().ToList();
			NodePathFinding<Vector3>.Release(list);
			if (list2.Count == 2)
			{
				dictionary[item2] = new HashSet<Room>();
				continue;
			}
			int num = list2.Count - 2;
			while (num > 0 && !list2[num].Rentable)
			{
				num--;
			}
			Room room = list2[num];
			hashSet.Add(room);
			HashSet<Room> value = null;
			if (!dictionary.TryGetValue(room, out value))
			{
				value = (dictionary[room] = new HashSet<Room>());
			}
			for (int num2 = 0; num2 < num; num2++)
			{
				Room item = list2[num2];
				value.Add(item);
				hashSet.Add(item);
			}
		}
		foreach (KeyValuePair<Room, HashSet<Room>> item3 in dictionary)
		{
			item3.Key.UnGroup();
			foreach (Room item4 in item3.Value)
			{
				item4.GroupTo(item3.Key);
			}
		}
	}

	public static string CountDays(int amount)
	{
		if (GameSettings.DaysPerMonth <= 1)
		{
			return "Month".LocPlural(amount);
		}
		return "Day".LocPlural(amount);
	}

	public static int CountDaysMax()
	{
		return 12 * GameSettings.DaysPerMonth;
	}

	public Material GetHighlightMaterial(HighlightType type, bool diag, bool alpha, Material main)
	{
		switch (type)
		{
		case HighlightType.Primary:
			if (alpha)
			{
				return new Material(PrimaryHighlightMatAlpha)
				{
					mainTexture = main.mainTexture
				};
			}
			if (!diag)
			{
				return PrimaryHighlightMat;
			}
			return PrimaryHighlightMatDiag;
		case HighlightType.Secondary:
			if (alpha)
			{
				return new Material(SecondaryHighlightMatAlpha)
				{
					mainTexture = main.mainTexture
				};
			}
			if (!diag)
			{
				return SecondaryHighlightMat;
			}
			return SecondaryHighlightMatDiag;
		case HighlightType.Tertiary:
			if (alpha)
			{
				return new Material(TertiaryHiglightMatAlpha)
				{
					mainTexture = main.mainTexture
				};
			}
			if (!diag)
			{
				return TertiaryHiglightMat;
			}
			return TertiaryHiglightMatDiag;
		case HighlightType.PrimaryAndTertiary:
			if (alpha)
			{
				return new Material(PrimAndTerHightlightMatAlpha)
				{
					mainTexture = main.mainTexture
				};
			}
			if (!diag)
			{
				return PrimAndTerHightlightMat;
			}
			return PrimAndTerHightlightMatDiag;
		case HighlightType.Error:
			if (alpha)
			{
				return new Material(ErrorHightlightMatAlpha)
				{
					mainTexture = main.mainTexture
				};
			}
			if (!diag)
			{
				return ErrorHightlightMat;
			}
			return ErrorHightlightMatDiag;
		default:
			return PrimaryHighlightMatDiag;
		}
	}

	public static void RecursiveRemoveChildren(List<Furniture> furns)
	{
		for (int i = 0; i < furns.Count; i++)
		{
			SnapPoint snappedTo = furns[i].SnappedTo;
			while (snappedTo != null)
			{
				if (furns.Contains(snappedTo.Parent))
				{
					furns.RemoveAt(i);
					i--;
					break;
				}
				snappedTo = snappedTo.Parent.SnappedTo;
			}
		}
	}

	private IEnumerator Start()
	{
		GameData.NetworkSettings = null;
		bool oldV = false;
		ReEnable.Clear();
		BusScript.Present = false;
		Instance = this;
		GameSettings.IsQuitting = false;
		RoomMaterialController.Clear();
		float _skipTime = 0f;
		bool loaded = false;
		bool loadedGameData = false;
		bool clientLocalLoad = false;
		string timeSkip = null;
		Versioning.Version? loadVersion = ((GameData.LoadAnyOnLoad && GameData.LoadFile != null && !GameData.LoadFile.BuildingOnly) ? new Versioning.Version?(Versioning.DisectVersionString(GameData.LoadFile.GameVersion)) : ((Versioning.Version?)null));
		if (GameData.LoadAnyOnLoad)
		{
			loaded = true;
			GameSettings.Instance.HasToFinalizeTimers = true;
			GameSettings.GameSpeed = 0f;
			TimeProbe.BeginTime("Load game time:");
			if (GameData.LoadFile != null && !GameData.LoadFile.BuildingOnly)
			{
				GameSettings.DaysPerMonth = GameData.LoadFile.DaysPerMonth;
			}
			else
			{
				NetworkMeta networkData = GameData.NetworkData;
				GameSettings.DaysPerMonth = ((networkData != null) ? networkData.DaysPerMonth : GameData.DaysPerMonth);
			}
			GameSettings.Instance.LoadingCamera.gameObject.SetActive(true);
			if (GameData.NetworkSaveData != null)
			{
				bool hasOwn = false;
				List<SoftwareProduct> mocks = null;
				List<ValueTuple<uint, bool, float>> publisherStanding = null;
				SDateTime? oldDate = null;
				if (GameData.LoadFile != null)
				{
					loadedGameData = true;
					hasOwn = true;
					oldDate = GameData.LoadFile.InGameTime;
					IEnumerator actualRes = HandleLoad(GameReader.LoadGame(GameData.LoadFile.FileName, GameData.LoadFile, GameReader.NewLoadMode.Full, false, Writeable.LoadType.NetworkClient));
					while (actualRes.MoveNext())
					{
						yield return actualRes.Current;
					}
					GameData.LoadFile = null;
					mocks = (from x in MarketSimulation.Active.GetMockProducts()
						where x.Type != MarketSimulation.Active.DigitalDistSoft
						select x).ToList();
					publisherStanding = MarketSimulation.Active.Companies.Values.Select([return: TupleElementNames(new string[] { "ID", "WillPublishPlayer", "PlayerRelationship" })] (SimulatedCompany x) => new ValueTuple<uint, bool, float>(x.ID, x.WillPublishPlayer, x.PlayerRelationship)).ToList();
					clientLocalLoad = true;
				}
				Dictionary<uint, object> dict = null;
				if (hasOwn)
				{
					dict = Writeable.DeserializedObjects;
					Writeable.DeserializedObjects = new Dictionary<uint, object>();
				}
				IEnumerator res = HandleLoad(GameReader.LoadGame(GameReader.DeserializeDictionaries(GameData.NetworkSaveData), null, GameReader.NewLoadMode.Building, Versioning.CurrentVersion, Writeable.LoadType.NetworkHost));
				bool f = !hasOwn;
				while (res.MoveNext())
				{
					if (f)
					{
						TimeOfDay.Instance.Hour = 7;
						TimeOfDay.Instance.Minute = 0f;
						TimeOfDay.Instance.GetDate(true);
						f = false;
					}
					yield return res.Current;
				}
				if (DelayedCars.Count > 0)
				{
					Dictionary<uint, object> deserializedObjects = Writeable.DeserializedObjects;
					Writeable.DeserializedObjects = dict;
					foreach (WriteDictionary delayedCar in DelayedCars)
					{
						int idx = delayedCar.Get("CarIdx", 1);
						CarScript obj = RoadManager.Instance.CreateCar(idx, false).DeserializeThis(delayedCar, true) as CarScript;
						if ((object)obj != null)
						{
							obj.PostDeserialize();
						}
					}
					Writeable.DeserializedObjects = deserializedObjects;
				}
				if (hasOwn)
				{
					Writeable.IDCount = dict.MaxSafeUint((KeyValuePair<uint, object> x) => x.Key) + 1;
					List<object> list = Writeable.DeserializedObjects.Values.ToList();
					Writeable.DeserializedObjects = dict;
					for (int num = 0; num < list.Count; num++)
					{
						object obj2 = list[num];
						Writeable writeable = (Writeable)obj2;
						writeable.DID = Writeable.GetNextID();
						Writeable.DeserializedObjects[writeable.DID] = obj2;
					}
					GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>().ForEachEnum(delegate(AutoDevWorkItem x)
					{
						x.LeaderID = (x.Leader.IsAliveNotNull() ? x.Leader.DID : 0u);
					});
				}
				DelayedCars.Clear();
				for (int num2 = 0; num2 < GameSettings.Instance.Plots.Count; num2++)
				{
					PlotArea plotArea = GameSettings.Instance.Plots[num2];
					if (plotArea.PlayerOwned)
					{
						GameSettings.Instance.PlayerPlots.Add(plotArea);
						GameSettings.Instance.Plots.RemoveAt(num2);
						num2--;
					}
				}
				for (int num3 = 0; num3 < GameSettings.Instance.PlayerPlots.Count; num3++)
				{
					PlotArea plotArea2 = GameSettings.Instance.PlayerPlots[num3];
					if (!plotArea2.PlayerOwned)
					{
						GameSettings.Instance.Plots.Add(plotArea2);
						GameSettings.Instance.PlayerPlots.RemoveAt(num3);
						num3--;
					}
				}
				GameData.NetworkSaveData = null;
				GameSettings.Instance.NetworkData = GameData.NetworkData;
				RoadManager.Instance.DeserializeParking();
				RoadManager.Instance.UpdateParkingAvailability(true);
				if (hasOwn)
				{
					TimeOfDay.Instance.Minute = oldDate.Value.Minute;
					TimeOfDay.Instance.Hour = oldDate.Value.Hour;
					SDateTime dateLocked = TimeOfDay.GetDateLocked();
					dateLocked = new SDateTime(oldDate.Value.Minute, oldDate.Value.Hour, dateLocked.Day, dateLocked.Month, dateLocked.Year);
					float months = SDateTime.GetMonths(oldDate.Value, dateLocked);
					mocks.ForEach(delegate(SoftwareProduct x)
					{
						if (x.FixSubReferences() != null)
						{
							MarketSimulation.Active.AddProduct(x, true);
						}
					});
					publisherStanding.ForEach(delegate(ValueTuple<uint, bool, float> x)
					{
						SimulatedCompany simulatedCompany;
						if ((simulatedCompany = MarketSimulation.Active.GetCompany(x.Item1) as SimulatedCompany) != null)
						{
							simulatedCompany.WillPublishPlayer = x.Item2;
							simulatedCompany.PlayerRelationship = x.Item3;
						}
					});
					try
					{
						FixUpClientPlayerCompany(months <= 1f);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					foreach (ServerGroup item in GameSettings.Instance.GetAllServerGroups().ToList())
					{
						byte cloudProvider = item.CloudProvider;
						if (cloudProvider > 0)
						{
							Company playerCompany = MarketSimulation.Active.GetPlayerCompany(cloudProvider);
							if (((playerCompany != null) ? playerCompany.CloudService : null) == null)
							{
								GameSettings.Instance.RemoveServer(item.Servers.First());
								continue;
							}
							item.Servers.Clear();
							item.Servers.Add(playerCompany.CloudService);
						}
					}
					GameSettings.Instance.MyCompany.Products.ForEach(delegate(SoftwareProduct x)
					{
						x.RegisterServer();
					});
					HUD.Instance.contractWindow.FixReferences();
					HUD.Instance.dealWindow.FixReferences();
					GameSettings.Instance.FixReferences();
					GameSettings.Instance.ProductPrinters.ForEach(delegate(ProductPrinter x)
					{
						x.FixReferences();
					});
					GameSettings.Instance.ProductPallets.ForEach(delegate(ProductPallet x)
					{
						x.FixReferences();
					});
					GameSettings.Instance.BoxController.FixBoxReferences();
					GameSettings.Instance.sActorManager.Staff.Where((Actor x) => x.AItype == AI.AIType.Courier).ForEachEnum(delegate(Actor x)
					{
						if (x.Order != null)
						{
							x.Order = x.Order.FixReferences() as ProductPrintOrder;
						}
					});
					if (months > 0f)
					{
						timeSkip = SDateTime.DateDiff(oldDate.Value, dateLocked);
						Debug.Log("Local player had a save time difference of: " + timeSkip);
						if (months >= 1f)
						{
							foreach (Deal activeDeal in HUD.Instance.dealWindow.GetActiveDeals())
							{
								HUD.Instance.dealWindow.CancelDeal(activeDeal, false, false);
							}
						}
						foreach (Actor actor3 in GameSettings.Instance.sActorManager.Actors)
						{
							actor3.employee.BirthDate += months;
							actor3.employee.Hired += months;
							actor3.employee.LastWage += months;
							actor3.employee.LastInpirationUse += months;
							actor3.LastMeeting += months;
							actor3.MeetingTime += months;
							actor3.DriveTime += months;
							actor3.DespawnTime += months;
							actor3.LeaveTime += months;
							actor3.LastSocial += months;
							actor3.ForgetfulETA += months;
							actor3.VacationMonth += Mathf.FloorToInt(months);
						}
						GameSettings.Instance.sActorManager.PushAwaiting(months, true);
						foreach (SoftwareWorkItem item2 in GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>())
						{
							if (item2.GetNetworkDealState() != WorkItem.NetworkDealState.Receiver)
							{
								item2.DevStart += months;
								if (item2.Publishing != null && item2.Publishing.Publisher == null)
								{
									item2.Publishing.Abandon(false);
								}
								if (item2.ReleaseDate.HasValue)
								{
									item2.ReleaseDate += months;
								}
							}
						}
						lock (GameSettings.Instance.PrintOrders)
						{
							for (int num4 = 0; num4 < GameSettings.Instance.PrintOrders.Count; num4++)
							{
								PrintJob printJob = GameSettings.Instance.PrintOrders[num4];
								ContractWork contractWork;
								if (printJob.Hardware && (contractWork = printJob.Target as ContractWork) != null)
								{
									contractWork.Deadline += months;
								}
							}
						}
					}
				}
			}
			else if (GameData.CompanyData != null)
			{
				loadedGameData = true;
				TimeOfDay.Instance.DateOverride = GameData.CompanyDate;
				if (GameData.LoadFile == null)
				{
					IEnumerator res = HandleLoad(GameReader.LoadGame(GameReader.DeserializeDictionaries(GameData.CompanyData), null, GameReader.NewLoadMode.Company, Versioning.CurrentVersion, Writeable.LoadType.Default));
					while (res.MoveNext())
					{
						yield return res.Current;
					}
				}
				else
				{
					InitLoadTex(GameData.LoadFile);
					IEnumerator res = HandleLoad(GameReader.LoadGame(GameData.LoadBackup ? (GameData.LoadFile.FileName + ".bak") : GameData.LoadFile.FileName, GameData.LoadFile, GameReader.NewLoadMode.Building, GameData.LoadFile.Resource, Writeable.LoadType.Default));
					while (res.MoveNext())
					{
						yield return res.Current;
					}
					Dictionary<uint, object> dict = Writeable.DeserializedObjects;
					Writeable.DeserializedObjects = new Dictionary<uint, object>();
					res = HandleLoad(GameReader.LoadGame(GameReader.DeserializeDictionaries(GameData.CompanyData), null, GameReader.NewLoadMode.Company, Versioning.CurrentVersion, Writeable.LoadType.Default));
					while (res.MoveNext())
					{
						yield return res.Current;
					}
					Writeable.IDCount = dict.MaxSafeUint((KeyValuePair<uint, object> x) => x.Key) + 1;
					List<object> list2 = Writeable.DeserializedObjects.Values.ToList();
					Writeable.DeserializedObjects = dict;
					for (int num5 = 0; num5 < list2.Count; num5++)
					{
						object obj3 = list2[num5];
						Writeable writeable2 = (Writeable)obj3;
						writeable2.DID = Writeable.GetNextID();
						Writeable.DeserializedObjects[writeable2.DID] = obj3;
					}
					foreach (KeyValuePair<string, List<InventoryItem>> item3 in GameSettings.Instance.FurnitureInventory)
					{
						for (int num6 = 0; num6 < item3.Value.Count; num6++)
						{
							item3.Value[num6] = item3.Value[num6].Clone(Writeable.GetNextID());
						}
					}
					GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>().ForEachEnum(delegate(AutoDevWorkItem x)
					{
						x.LeaderID = (x.Leader.IsAliveNotNull() ? x.Leader.DID : 0u);
					});
				}
				GameData.CompanyData = null;
				TimeOfDay.Instance.DateOverride = null;
			}
			else
			{
				try
				{
					Versioning.Version version = Versioning.DisectVersionString(GameData.LoadFile.GameVersion);
					if (version.TypeInt < 2 || (version.TypeInt == 2 && version.Major < 1))
					{
						oldV = true;
					}
				}
				catch (Exception)
				{
				}
				InitLoadTex(GameData.LoadFile);
				TimeOfDay.Instance.DateOverride = GameData.LoadFile.InGameTime;
				loadedGameData = !GameData.LoadFile.BuildingOnly;
				IEnumerator res = HandleLoad(GameReader.LoadGame(GameData.LoadBackup ? (GameData.LoadFile.FileName + ".bak") : GameData.LoadFile.FileName, GameData.LoadFile, (!GameData.LoadFile.BuildingOnly) ? GameReader.NewLoadMode.Full : GameReader.NewLoadMode.Building, GameData.LoadFile.Resource, Writeable.LoadType.Default));
				while (res.MoveNext())
				{
					yield return res.Current;
				}
				TimeOfDay.Instance.DateOverride = null;
				if (!GameData.LoadFile.Readonly && (!GameData.LoadFile.BuildingOnly || GameData.EditMode))
				{
					GameSettings.Instance.AssociatedSave = GameData.LoadFile;
				}
				if (GameData.LoadFile.BuildingOnly && !GameData.EditMode)
				{
					if (GameSettings.Instance.AssociatedSave == GameData.LoadFile)
					{
						GameSettings.Instance.AssociatedSave = null;
					}
					if (GameSettings.Instance.AssociatedAutoSave == GameData.LoadFile)
					{
						GameSettings.Instance.AssociatedAutoSave = null;
					}
				}
			}
			_skipTime = Time.realtimeSinceStartup;
			List<Room> rs = GameSettings.Instance.sRoomManager.Rooms;
			GameSettings.Instance.LoadingBar.gameObject.SetActive(true);
			GameSettings.Instance.LoadingText.text = "LoadingNavMesh".Loc() + " (1/2)";
			GameSettings.Instance.LoadingCamera.Render();
			while (!_skipLoading && rs.Any((Room x) => x.GetNavMeshRunning()))
			{
				GameSettings.Instance.LoadingBar.Value = (float)rs.Count((Room x) => x.GetNavMeshRunning()) / (float)rs.Count;
				DoSkipCheck(_skipTime);
				yield return new WaitForEndOfFrame();
			}
			GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
			yield return new WaitForEndOfFrame();
			GameSettings.Instance.LoadingText.text = "LoadingNavMesh".Loc() + " (2/2)";
			while (!_skipLoading && GameSettings.Instance.sRoomManager.IsBFSStarted())
			{
				GameSettings.Instance.LoadingBar.Value = (float)GameSettings.Instance.sRoomManager.BFSDone / (float)GameSettings.Instance.sRoomManager.BFSTotal;
				DoSkipCheck(_skipTime);
				yield return new WaitForEndOfFrame();
			}
			GameSettings.Instance.LoadingBar.gameObject.SetActive(false);
			while (!_skipLoading && (GameSettings.Instance.sRoomManager.Outside.GetNavMeshRunning() || GameSettings.Instance.AnyNavRooms()))
			{
				DoSkipCheck(_skipTime);
				yield return new WaitForEndOfFrame();
			}
			if (MoveAddBack > 0f)
			{
				GameSettings.Instance.MyCompany.MakeTransaction(MoveAddBack, Company.TransactionCategory.Construction, false);
				MoveAddBack = 0f;
			}
			MarketSimulation.Active.FixStocks();
			MarketSimulation.Active.FixMarketRecognition();
			MarketSimulation.Active.FixHardwareDependencies();
			if (MarketSimulation.Active.DigitalDistSoft == null)
			{
				MarketSimulation.Active.DigitalDistSoft = GameData.DigitalDistributionPlatform;
			}
			GameSettings.Instance.sActorManager.FixEmployment();
			HUD.Instance.serverWindow.UpdateServerList();
			HUD.Instance.roomGroupWindow.UpdateList();
			if (GameData.LoadBuildingOnLoad)
			{
				RoadManager.Instance.UpdateRoadVisibility();
				GrassSystem.Instance.Init();
			}
			TimeProbe.FinalizeTime("Load game time:");
			GameSettings.Instance.sRoomManager.Rooms.ForEach(delegate(Room x)
			{
				x.UpdateColors();
				x.RecalculateTableGroups();
			});
			foreach (WorkItem item4 in GameSettings.Instance.MyCompany.WorkItems.OrderBy((WorkItem x) => x.SiblingIndex))
			{
				item4.MakeWorkItem();
			}
			if (GameSettings.Instance.MyCompany.Distribution != null)
			{
				GameSettings.Instance.RegisterWithServer(GameSettings.Instance.MyCompany.Distribution.ServerName, GameSettings.Instance.MyCompany.Distribution);
			}
			GameData.LoadYear = 0;
			TimeOfDay.Instance.GroundTopDirty = true;
			for (int num7 = 0; num7 < Writeable.MissingIDs.Count; num7++)
			{
				Writeable.MissingIDs[num7].InitWritable();
			}
			Writeable.MissingIDs.Clear();
			if (GameSettings.Instance.Founders != null)
			{
				foreach (Actor founder in GameSettings.Instance.Founders)
				{
					founder.DID = Writeable.GetNextID();
				}
			}
			for (int num8 = 0; num8 < GameSettings.Instance.ElevatorGroups.Count; num8++)
			{
				if (!GameSettings.Instance.ElevatorGroups[num8].Deserialize())
				{
					GameSettings.Instance.ElevatorGroups.RemoveAt(num8);
					num8--;
				}
			}
		}
		else
		{
			GameSettings.GameSpeed = 1f;
		}
		if (!loadedGameData && !HintController.IsHintPossible(HintController.Hints.SkipTimeHint))
		{
			HUD.Instance.AvoidInitialSkip = false;
		}
		if (GameSettings.Instance.PLoanData != null)
		{
			GameSettings.Instance.PLoanData.ForEach(delegate(GameSettings.PlotLoanData x)
			{
				x.Apply(GameSettings.Instance.PlayerPlots);
			});
			GameSettings.Instance.PLoanData = null;
		}
		GameSettings.Instance.Generate();
		RoadManager.Instance.Generate();
		GameData.LoadAnyOnLoad = false;
		if (RemovedTempFurns)
		{
			WindowManager.Instance.ShowMessageBox("TemperatureDeprecationPrompt".Loc(), true, DialogWindow.DialogType.Question, delegate
			{
				TutorialSystem.Instance.StartTutorial("Temperature regulation", true);
			}, "TempDeprecation", null, false);
			RemovedTempFurns = false;
		}
		if (RemovedPrintFurns)
		{
			WindowManager.Instance.ShowMessageBox("PrinterDeprecationPrompt".Loc(), true, DialogWindow.DialogType.Question, delegate
			{
				TutorialSystem.Instance.StartTutorial("Physical distribution", true);
			}, "PrintDeprecation", null, false);
			RemovedPrintFurns = false;
		}
		if (!GameSettings.Instance.EditMode)
		{
			TutorialSystem.Instance.StartTutorial("Welcome");
		}
		BuildController.Instance.UpdateGridVisual();
		HUD.Instance.UpdateCashflow();
		if (GameSettings.Instance.SerializedEvents != null)
		{
			HUD.Instance.insuranceWindow.Terminations.Items.AddRange(GameSettings.Instance.SerializedEvents.Cast<object>());
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		Debug.Log("Tree combine time: " + (Time.realtimeSinceStartup - realtimeSinceStartup).SecondsToTime());
		UpdateInfoPanel();
		HUD.Instance.UpdateFurnitureButtons();
		HUD.Instance.FixUpperDayPanel();
		HUD.Instance.employeeWindow.UpdateEdNumber();
		HUD.Instance.insuranceWindow.UpdateInvestments();
		HUD.Instance.complaintWindow.UpdateCounter();
		if (GameSettings.Instance.RentMode && !GameSettings.Instance.EditMode)
		{
			GameSettings.Instance.DirtyRentGrid.AddRange(from x in GameSettings.Instance.sRoomManager.Rooms
				where x.PlayerOwned
				select x.Floor);
		}
		RelocateButton.SetActive(!GameSettings.Instance.EditMode);
		HelpButtonTip.TooltipDescription = "StartTutorialTip".Loc(HUD.Instance.GetActiveBuildTutorial().LocTry());
		if (ReEnable.Count > 0)
		{
			for (int num9 = 0; num9 < ReEnable.Count; num9++)
			{
				if (ReEnable[num9] != null)
				{
					ReEnable[num9].enabled = true;
				}
			}
			ReEnable.Clear();
			if (!_skipLoading)
			{
				if (_skipTime == 0f)
				{
					_skipTime = Time.realtimeSinceStartup;
				}
				yield return new WaitForEndOfFrame();
				yield return new WaitForEndOfFrame();
				float l = 0f;
				if (GameSettings.Instance.AnyNavRooms())
				{
					l = GameSettings.Instance.NavRoomCount();
					GameSettings.Instance.LoadingBar.gameObject.SetActive(true);
				}
				while (!_skipLoading && (GameSettings.Instance.sRoomManager.Outside.GetNavMeshRunning() || GameSettings.Instance.AnyNavRooms()))
				{
					if (l > 0f)
					{
						GameSettings.Instance.LoadingBar.Value = 1f - (float)GameSettings.Instance.NavRoomCount() / l;
					}
					DoSkipCheck(_skipTime);
					yield return new WaitForEndOfFrame();
				}
			}
			GameSettings.Instance.LoadingBar.gameObject.SetActive(false);
		}
		SkipWarning.SetActive(false);
		GameSettings.Instance.LoadingCamera.gameObject.SetActive(false);
		Furniture.UpdateEdgeDetection();
		TimeOfDay.Instance.UpdateSunEffectiveness();
		HUD.Instance.dealWindow.CleanUpDeadPrints();
		if (GameSettings.Instance.SerializedBoxes != null || GameSettings.Instance.SerializedHeli != null)
		{
			GameSettings.Instance.BoxController.Deserialize(GameSettings.Instance.SerializedBoxes, GameSettings.Instance.SerializedHeli);
			GameSettings.Instance.SerializedBoxes = null;
			GameSettings.Instance.SerializedHeli = null;
		}
		Example.FixComponentCounts(false);
		GameSettings.Instance.RefreshAllInventoryCounts();
		FixAssemblyLines();
		GameSettings.Instance.InitITStuff();
		GameSettings.Instance.BoxController.InitThread();
		NotificationManager.Instance.UpdateMuteSprite();
		GameSettings.Instance.CleanServerGroups();
		if (GameSettings.IsDoneLoadingGame != null)
		{
			GameSettings.IsDoneLoadingGame(this, null);
		}
		if (!GameSettings.Instance.PreSimActive)
		{
			GameSettings.Instance.OnGameReady();
		}
		DoneLoading = true;
		TimeOfDay.Instance.RealTimeDayStart = Time.realtimeSinceStartup;
		TimeOfDay.Instance.canSkip = TimeOfDay.Instance.CanSkip();
		if (GameData.RestartCompletedMissions != null)
		{
			GameSettings.Instance.CompletedMissions.AddRange(GameData.RestartCompletedMissions);
			GameSettings.Instance.CurrentMissions.AddRange(GameData.RestartActiveMissions);
			GameData.RestartCompletedMissions.Clear();
			GameData.RestartActiveMissions.Clear();
		}
		MissionGuide.Instance.Init();
		if (GameSettings.Instance.CampaignMode && !GameSettings.Instance.EditMode && GameSettings.Instance.CurrentMissions.Count > 0)
		{
			foreach (string currentMission in GameSettings.Instance.CurrentMissions)
			{
				MissionGuide.Instance.StartMission(currentMission, false);
			}
		}
		FixMask.enabled = true;
		RoadManager.Instance.PlaceRoadLamps();
		TimeOfDay.Instance.UpdateSunEffectiveness();
		GameSettings.Instance.CoolDep = Newspaper.MakeList((from x in ObjectDatabase.Instance.GetAllFurniture()
			select x.GetComponent<Furniture>() into x
			where x.TemperatureController && x.TempControlType == Furniture.TemperatureType.Cooling
			select Localization.GetFurniture(x.GetLocalizationName(), x.GetDefaultName(), x.ButtonDescription)[0]).ToList(), false);
		GameSettings.Instance.HotDep = Newspaper.MakeList((from x in ObjectDatabase.Instance.GetAllFurniture()
			select x.GetComponent<Furniture>() into x
			where x.TemperatureController && x.TempControlType == Furniture.TemperatureType.Heating
			select Localization.GetFurniture(x.GetLocalizationName(), x.GetDefaultName(), x.ButtonDescription)[0]).ToList(), false);
		HUD.Instance.UpdateAwardButtons();
		GameSettings.Instance.GetPlots().ToList().ForEach(delegate(PlotArea x)
		{
			x.FixOwner();
		});
		if (oldV)
		{
			WindowManager.Instance.ShowMessageBox("OldSaveVersionWarning".Loc(), true, DialogWindow.DialogType.Information);
		}
		if (GameData.DoCampaignInit)
		{
			HUD.Instance.ControlTutorial.gameObject.SetActive(true);
			Actor f2 = GameSettings.Instance.sActorManager.Actors.First();
			f2.enabled = true;
			f2.SetVisible(true);
			f2.MeetNow();
			f2.ActualPosition = new Vector3(149f, 0f, 106.3f);
			f2.transform.rotation = Quaternion.Euler(0f, 288f, 0f);
			f2.SetAnim(Actor.AnimationStates.SitHandsdown);
			f2.SkipAnimTime();
			f2.UpdateCurrentRoom(true);
			Employee emp = new Employee(MissionGuide.Instance.GetCharacter("Mom"));
			Actor actor = GameSettings.Instance.SpawnActor(emp);
			actor.AItype = AI.AIType.Parent;
			actor.enabled = true;
			actor.WaitSpawn = false;
			actor.SetVisible(true);
			actor.MeetNow();
			actor.ActualPosition = new Vector3(148f, 0f, 106.5f);
			actor.transform.rotation = Quaternion.Euler(0f, 115f, 0f);
			actor.UpdateCurrentRoom(true);
			actor.SetAnim(Actor.AnimationStates.Idle);
			actor.SetBlend(1);
			actor.SkipAnimTime();
			actor.SetCar(8);
			actor.CreateParentCar();
			MissionGuide.Instance.StartMission("Mission001", true);
			Actor actor2 = ((GameSettings.Instance.Founders != null && GameSettings.Instance.Founders.Count > 0) ? GameSettings.Instance.Founders[0] : null);
			if (actor2 != null)
			{
				object value;
				Furniture furniture;
				if (Writeable.DeserializedObjects.TryGetValue(113u, out value) && (object)(furniture = value as Furniture) != null && furniture.Type.Equals("Bed"))
				{
					furniture.OwnedBy = actor2;
				}
				object value2;
				Furniture furniture2;
				if (Writeable.DeserializedObjects.TryGetValue(205u, out value2) && (object)(furniture2 = value2 as Furniture) != null && furniture2.Type.Equals("Computer"))
				{
					furniture2.OwnedBy = actor;
				}
				object value3;
				Furniture furniture3;
				if (Writeable.DeserializedObjects.TryGetValue(114u, out value3) && (object)(furniture3 = value3 as Furniture) != null && furniture3.Type.Equals("Table"))
				{
					SnapPoint snapPoint = furniture3.SnapPoints[0];
					bool inventory;
					Furniture furniture4 = FurnitureBuilder.MakeFurn(snapPoint.transform.position, Quaternion.Euler(0f, 90f, 0f), furniture3.Parent, null, null, 0f, false, snapPoint, ObjectDatabase.Instance.GetFurniture("Old Computer"), 0f, false, out inventory);
					Upgradable upgradable = furniture4.GetComponent<Upgradable>();
					upgradable.Quality = 0f;
					furniture4.OwnedBy = actor2;
					HUD.Instance.SmokeSystem.Emit(new ParticleSystem.EmitParams
					{
						position = upgradable.SmokePosition.position,
						velocity = Vector3.zero
					}, 1);
					yield return new WaitForEndOfFrame();
					for (int num10 = 0; num10 < 50; num10++)
					{
						Vector3 vector = new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(-0.1f, 0.1f));
						float value4 = UnityEngine.Random.value;
						HUD.Instance.SmokeSystem.Emit(new ParticleSystem.EmitParams
						{
							position = upgradable.SmokePosition.position + vector * value4,
							velocity = vector,
							startLifetime = 1f - value4
						}, 1);
					}
				}
				Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent("90s Computer");
				GameSettings.AddToInventory(new InventoryItem(furnitureComponent.name, 0u, 0, furnitureComponent.ColorPrimaryDefault, furnitureComponent.ColorSecondaryDefault, furnitureComponent.ColorTertiaryDefault, 1f, false, false));
			}
			(from x in GameSettings.Instance.sRoomManager.GetRoomFromPoint(f2.transform.position).GetFurnitures()
				where x.Lamp != null
				select x).ForEachEnum(delegate(Furniture x)
			{
				x.Lamp.UpdateNow(0.1f);
			});
			GameData.DoCampaignInit = false;
		}
		if (GameData.MultiplayerMode)
		{
			if (loaded)
			{
				MarketSimulation.Active.ResetSoftwareIDs();
				if (NetworkManager.Instance.Host)
				{
					NetworkManager.Self.UniqueIDOverride = GameSettings.Instance.NetworkData.LocalUniqueID;
					NetworkManager.Self.ID = GameSettings.Instance.NetworkData.PlayerIDs[NetworkManager.Self.UniqueIDOverride];
					GameSettings.Instance.NetworkData.GenerateUUID();
				}
			}
			else
			{
				if (GameData.LobbyName != null)
				{
					if (NetworkManager.Self.ID == byte.MaxValue)
					{
						Debug.Log("Player was ID 255, changing to 1");
						NetworkManager.Self.ID = 1;
						foreach (PlotArea item5 in GameSettings.Instance.Plots.ToList())
						{
							if (item5.PlayerOwned)
							{
								GameSettings.Instance.Plots.Remove(item5);
								GameSettings.Instance.PlayerPlots.Add(item5);
							}
						}
					}
					GameSettings.Instance.YearlyNetworkIPO = GameData.ForcedIPO;
					GameSettings.Instance.PlotAdjacency = GameData.PlotAdjacency;
					GameSettings.Instance.RoundLimit = GameData.RoundLimit;
					GameSettings.Instance.RoundType = GameData.RoundType;
					GameData.ForcedIPO = null;
				}
				GameSettings.Instance.NetworkData = new NetworkMeta(NetworkManager.Self.ActualUniqueID, GameData.LobbyName, GameData.LobbyPassword, GameData.NetworkAllowCodeMods, GameData.NetworkAllowFurnitureMods, SteamLayer.LobbyType);
				foreach (NetworkPlayer player in NetworkManager.Instance.Players)
				{
					GameSettings.Instance.NetworkData.PlayerIDs[player.UniqueID] = player.ID;
				}
				GameSettings.Instance.NetworkData.RegisterCompany(NetworkManager.Self.ID, GameSettings.Instance.MyCompany.ID);
			}
			if (GameData.LobbyName != null)
			{
				GameSettings.Instance.NetworkData.ServerName = GameData.LobbyName;
				GameSettings.Instance.NetworkData.Password = GameData.LobbyPassword;
				GameSettings.Instance.NetworkData.LobbyType = SteamLayer.LobbyType;
				NetworkManager.Instance.Host = true;
				try
				{
					NetworkLayer.Active.CreateLobby(new NetworkLobby(GameData.LobbyName, null, null));
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
					WindowManager.Instance.ShowMessageBox("PlayerDisconnect".Loc(), true, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("OK", PauseWindow.QuitToMainMenu));
				}
				GameData.ResetLobbyData();
				GameData.MultiplayerMode = true;
			}
			GameSettings.Instance.NetworkData.RegisterPlayer(NetworkManager.Self.ID);
			MainBottomButton mainBottomButton = HUD.Instance.AddBottomButton("Market", "MultiplayerChat", "MultiplayerChatDesc", ObjectDatabase.GetIcon("SpeechBubble"));
			mainBottomButton.Button.onClick.AddListener(delegate
			{
				ChatWindow.Instance.Show(false);
			});
			ChatWindow.Instance.Counter = HUD.Instance.AddButtonCounter(mainBottomButton, "Messages");
			ChatWindow.Instance.Counter.Offset = new Vector2(0f, -15f);
			ChatWindow.Instance.Window.SpawnFrom = mainBottomButton.GetComponent<RectTransform>();
			ChatWindow.Instance.MainButton = mainBottomButton;
			ChatWindow.Instance.InitPings();
			if (loaded)
			{
				CheckNetworkIDs(MarketSimulation.Active.Companies.Values.Select((SimulatedCompany x) => x.LeadDesigner));
				CheckNetworkIDs(MarketSimulation.Active.Companies.Values.SelectMany((SimulatedCompany x) => x.NetworkEmployees));
				CheckNetworkIDs(MarketSimulation.Active.FreeLeads);
				CheckNetworkIDs(from x in MarketSimulation.Active.GetAllProducts(true)
					select x.LeadDesigner);
			}
			if (NetworkManager.Instance.Host)
			{
				NetworkManager.Instance.ResetNetworkIDs();
			}
			else
			{
				foreach (Company allCompany in MarketSimulation.Active.GetAllCompanies())
				{
					if (allCompany.Player)
					{
						allCompany.LocalPlayer = NetworkManager.Self.ID == allCompany.NetworkPlayerID;
						if (allCompany.LocalPlayer)
						{
							GameSettings.Instance.MyCompany = allCompany;
							allCompany.RepEffects = new Dictionary<string, Company.RepEffectItem>();
						}
						else if (!clientLocalLoad)
						{
							typeof(Company).GetField("Name").SetValue(allCompany, NetworkManager.Instance.Layer.FilterName(allCompany.Name, NetworkManager.GetPlayer(allCompany.NetworkPlayerID)));
						}
					}
				}
				foreach (Actor actor4 in GameSettings.Instance.sActorManager.Actors)
				{
					actor4.employee.MyEmployer = GameSettings.Instance.MyCompany;
				}
				NetworkMessaging.SendPlayerSync(NetworkManager.Self.ID, false, NetworkMessaging.MessageTarget.Everyone, 0);
				PlotArea plot = GameSettings.Instance.GetPlot(NetworkManager.Self.StartPlot);
				if (!clientLocalLoad)
				{
					GameSettings.Instance.UnlockCheck.UpdateMe(true);
					CameraScript.Instance.transform.position = plot.Center;
					Quaternion quaternion = Quaternion.LookRotation(new Vector3(128f, 0f, 128f) - plot.Center);
					CameraScript.Instance.transform.rotation = Quaternion.Euler(CameraScript.Instance.transform.rotation.eulerAngles.x, quaternion.eulerAngles.y - 45f, CameraScript.Instance.transform.rotation.eulerAngles.z);
					HUD.Instance.contractWindow.UpdateContracts(TimeOfDay.Instance.GetDate(true));
				}
				else
				{
					uint[] array = (from x in GameSettings.Instance.sRoomManager.Rooms
						where x.NetworkID != 0
						select x.NetworkID).ToArray();
					uint[] array2 = (from x in GameSettings.Instance.sRoomManager.Roofs
						where x.NetworkID != 0
						select x.NetworkID).ToArray();
					if (array.Length != 0 || array2.Length != 0)
					{
						NetworkMessaging.SendVerifyRoomData(array, array2, true, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					}
				}
				GameSettings.Instance.TransmitExtraWorth();
				foreach (NetworkPlayer player2 in NetworkManager.Instance.Players)
				{
					if (player2.DeferredCompany.CompanyName != null && player2.GetPlayerCompany() == null)
					{
						Company company = new Company(player2.DeferredCompany.CompanyName, player2.DeferredCompany.CompanyMoney, SDateTime.Now(), player2.DeferredCompany.CompanyID)
						{
							NetworkPlayerID = player2.ID,
							Logo = player2.DeferredCompany.CompanyLogo,
							Player = true,
							LocalPlayer = false
						};
						MarketSimulation.Active.AddCompany(company);
						GameSettings.Instance.NetworkData.RegisterCompany(player2.ID, player2.DeferredCompany.CompanyID);
						player2.DeferredCompany = default(NetworkPlayer.DeferredCompanyData);
						Debug.Log("Created missing company for: " + player2.Name);
					}
				}
				NetworkMessaging.SendLeadDesignerSync(true, null, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			GameSettings.Instance.GetPlots().ToList().ForEach(delegate(PlotArea x)
			{
				x.PlotObject.UpdatePlayerOwned();
			});
			PlotArea plotArea3 = GameSettings.Instance.PlayerPlots.FirstOrDefault((PlotArea x) => x.PlayerStarterPlot);
			Matrix4x4 matrix4x = Matrix4x4.identity;
			if (plotArea3.Center.z < 64f)
			{
				matrix4x = RotateAround(new Vector3(128f, 0f, 128f), Quaternion.Euler(0f, 270f, 0f));
			}
			else if (plotArea3.Center.x > 192f)
			{
				matrix4x = RotateAround(new Vector3(128f, 0f, 128f), Quaternion.Euler(0f, 180f, 0f));
			}
			else if (plotArea3.Center.z > 192f)
			{
				matrix4x = RotateAround(new Vector3(128f, 0f, 128f), Quaternion.Euler(0f, 90f, 0f));
			}
			GameSettings.Instance.BusStopSign.transform.position = matrix4x.MultiplyPoint(GameSettings.Instance.BusStopSign.transform.position);
			GameSettings.Instance.BusStopSign.transform.rotation = Quaternion.LookRotation(matrix4x.MultiplyVector(GameSettings.Instance.BusStopSign.transform.rotation * Vector3.forward));
			GameSettings.Instance.BusDir = matrix4x.MultiplyVector(GameSettings.Instance.BusDir);
			GameSettings.Instance.BusStart = matrix4x.MultiplyPoint(GameSettings.Instance.BusStart);
			GameSettings.Instance.MyCompany.WorkItems.ToList().ForEach(delegate(WorkItem x)
			{
				x.InitNetwork();
			});
			NetworkManager.Instance.UpdateSyncScreen();
			if (NetworkManager.Instance.Players.Count > 1)
			{
				NetworkMessaging.SendPlayerReady(NetworkManager.Self.Ready, NetworkMessaging.MessageTarget.Everyone, 0);
			}
			LogoController.Instance.Update();
			foreach (PlayerMap value5 in GameSettings.Instance.sRoomManager.PlayerMaps.Values)
			{
				foreach (Furniture value6 in value5.Furnitures.Values)
				{
					if ("CompanyLogo".Equals(value6.Type))
					{
						CompanySignage component = value6.GetComponent<CompanySignage>();
						if (component != null && component.JustLogo)
						{
							component.RefreshLogo();
						}
					}
				}
			}
			AFKChecker.Pulse();
			RoadManager.Instance.UpdateParkingAvailability(false);
			if (NetworkManager.IsHost && TimeOfDay.Instance.WaitingOnNetwork() && NetworkManager.Self.IsReady)
			{
				NetworkMessaging.CheckIfDaySkip();
			}
			foreach (Company playerCompany2 in MarketSimulation.Active.GetPlayerCompanies())
			{
				if (!playerCompany2.LocalPlayer && playerCompany2.CloudService != null && GameSettings.Instance.GetServerGroup(playerCompany2.CloudService.ServerName) == null)
				{
					GameSettings.Instance.AddServer(playerCompany2.CloudService);
				}
			}
			ServerGroup cloud = GameSettings.Instance.GetCloud();
			if (cloud != null)
			{
				foreach (NetworkServerItem item6 in cloud.Items.OfType<NetworkServerItem>().ToList())
				{
					if (NetworkManager.IsPlayerOffline(item6.PlayerID))
					{
						GameSettings.Instance.RegisterWithServer(null, item6, false);
					}
				}
			}
			NetworkMessaging.SendVerifyPrintDeals(null, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			for (int num11 = 0; num11 < GameSettings.Instance.sActorManager.Actors.Count; num11++)
			{
				Employee employee = GameSettings.Instance.sActorManager.Actors[num11].employee;
				foreach (SoftwareProduct item7 in employee.LeadProjectsFix.SelectNotNull((uint x) => MarketSimulation.Active.GetProduct(x, true, false, true)))
				{
					item7.LeadDesigner = employee;
				}
			}
		}
		else if (AFKChecker.Instance != null)
		{
			UnityEngine.Object.Destroy(AFKChecker.Instance.gameObject);
		}
		GameData.MultiplayerMode = false;
		GameData.NetworkData = null;
		GameData.LoadFile = null;
		HUD.Instance.MultiplayerToggle.gameObject.SetActive(NetworkManager.IsConnected);
		if (GameData.LoanAmount > 0)
		{
			LoanWindow.TakeLoan(ActorCustomization.StartLoanMonths, GameData.LoanAmount / 10000, 0);
			GameData.LoanAmount = 0;
		}
		if (MissingDataHost.Count > 0)
		{
			WindowManager.Instance.ShowMessageBox(string.Join("\n", "HostSaveOlder".Loc().Concate(MissingDataHost)), true, DialogWindow.DialogType.Error);
			MissingDataHost.Clear();
		}
		if (timeSkip != null)
		{
			WindowManager.Instance.ShowMessageBox("OldSaveMultiplayerWarning".Loc(timeSkip), true, DialogWindow.DialogType.Information);
		}
		GameSettings.Instance.MyCompany.WorkItems.ForEachEnum(delegate(WorkItem x)
		{
			if (x.guiItem != null)
			{
				x.guiItem.CheckInit();
			}
			AutoDevWorkItem autoDevWorkItem;
			if ((autoDevWorkItem = x as AutoDevWorkItem) != null)
			{
				autoDevWorkItem.CleanupWork();
			}
			SoftwareWorkItem softwareWorkItem;
			if ((softwareWorkItem = x as SoftwareWorkItem) != null)
			{
				softwareWorkItem.UpdateWorking();
			}
		});
		if (GameData.RestartCompany)
		{
			GameSettings.Instance.sRoomManager.PlayerMaps.Values.ForEachEnum(delegate(PlayerMap x)
			{
				x.Destroy();
			});
			GameSettings.Instance.sRoomManager.PlayerMaps.Clear();
			GameSettings.Instance.simulation.AddCompany(GameSettings.Instance.MyCompany);
			GameSettings.Instance.simulation.DistributionPlatforms.ForEach(delegate(DistributionPlatform x)
			{
				GameSettings.Instance.MyCompany.MarkInterested(x.Owner, true, 0);
			});
			GameData.RestartCompany = false;
			GameSettings.Instance.sActorManager.Actors.ForEach(delegate(Actor x)
			{
				x.employee.LeadProjectsFix.SelectNotNull((uint y) => MarketSimulation.Active.GetProduct(y, false, false, true)).ForEachEnum(delegate(SoftwareProduct z)
				{
					z.LeadDesigner = x.employee;
				});
				SDateTime sDateTime = SDateTime.Now();
				SDateTime time = ((x.GetTeam() != null) ? new SDateTime(0, x.GetTeam().WorkStart - 1, sDateTime.Day, sDateTime.Month, sDateTime.Year) : sDateTime);
				if (time.SimplifyLess() < sDateTime.SimplifyLess())
				{
					time += new SDateTime(1, 0, 0);
				}
				GameSettings.Instance.sActorManager.AddToAwaiting(x, time, true);
			});
			HUD.Instance.contractWindow.UpdateContracts(SDateTime.Now());
		}
		HUD.Instance.UpdateDifficultyButtons();
		GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
		GameSettings.Instance.FetchGrass();
		GameSettings.Instance.sActorManager.RefreshAllTeamTaskCompatibilities();
		GameSettings.Instance.Awards.ForEach(delegate(AwardTrophy.AwardData x)
		{
			x.AddToSearch();
		});
		if (!GameSettings.Instance.EditMode && loadVersion.HasValue && loadVersion.Value < GameReader.AddTrash)
		{
			WindowManager.Instance.ShowMessageBox("TrashPrompt".Loc(), true, DialogWindow.DialogType.Question, delegate
			{
				Furniture furnitureComponent2 = ObjectDatabase.Instance.GetFurnitureComponent("Trash Can");
				foreach (Room room in GameSettings.Instance.sRoomManager.Rooms)
				{
					if (room.IsPlayerControlled() && room.GetFurniture("Computer").Count > 0)
					{
						foreach (FurnitureAutoPlacement.PlacementData item8 in FurnitureAutoPlacement.AutoPlacementFunctions["Trashcan"].F(furnitureComponent2, room, Quaternion.identity))
						{
							bool inventory2;
							FurnitureBuilder.MakeFurn(item8.P, item8.R, room, null, null, 0f, false, null, furnitureComponent2.gameObject, 0f, false, out inventory2);
						}
					}
				}
			}, "TrashCanPrompt");
		}
		foreach (DistributionPlatform distributionPlatform in MarketSimulation.Active.DistributionPlatforms)
		{
			NetworkMessaging.DigitalPlatforms[distributionPlatform.Software.ID] = distributionPlatform.Software;
		}
	}

	public void RenderLogo(string name, RenderTexture t)
	{
		LogoText.text = name;
		LogoCam.targetTexture = t;
		LogoCam.gameObject.SetActive(true);
		LogoCam.Render();
		LogoCam.gameObject.SetActive(false);
		StartCoroutine(LogoCam.targetTexture.ApplySDF(32));
	}

	private static void FixUpClientPlayerCompany(bool sameMonth)
	{
		Company myCompany = GameSettings.Instance.MyCompany;
		Company company = MarketSimulation.Active.GetCompany(myCompany.ID);
		if (company == null)
		{
			Debug.Log("Local player company did not exist for host!");
			return;
		}
		GameSettings.Instance.MyCompany = company;
		GameSettings.Instance.MyCompany.LocalPlayer = true;
		GameSettings.Instance.MyCompany.FixNetworkPlayerReferences(myCompany, sameMonth);
		GameSettings.Instance.Loans = GameSettings.Instance.Loans.FixMyReferences(true);
	}

	private static void CheckNetworkIDs(IEnumerable<INetworkID> objs)
	{
		foreach (INetworkID obj in objs)
		{
			if (obj != null && obj.NetworkID != 0)
			{
				NetworkManager.Instance.RegisterNetworkObject(obj);
			}
		}
	}

	private Matrix4x4 RotateAround(Vector3 p, Quaternion rot)
	{
		return Matrix4x4.TRS(p, Quaternion.identity, Vector3.one) * Matrix4x4.TRS(Vector3.zero, rot, Vector3.one) * Matrix4x4.TRS(-p, Quaternion.identity, Vector3.one);
	}

	private void DoSkipCheck(float time)
	{
		if (Time.realtimeSinceStartup - time > 30f)
		{
			SkipWarning.SetActive(true);
			if (Input.GetKey(KeyCode.Space))
			{
				_skipLoading = true;
			}
		}
	}

	private void FixAssemblyLines()
	{
		HashSet<AssemblyLine> hashSet = GameSettings.Instance.GetAssemblyLines().ToHashSet();
		for (int i = 0; i < GameSettings.Instance.sRoomManager.AllFurniture.Count; i++)
		{
			ProductPrinter printer = GameSettings.Instance.sRoomManager.AllFurniture[i].Printer;
			if (printer != null && printer.Group != null && hashSet.Add(printer.Group))
			{
				GameSettings.Instance.AddAssemblyLine(printer.Group);
			}
		}
	}

	private void InitLoadTex(SaveGame save)
	{
		GameObject gameObject = MinimapThumbnailMaker.Instance.MinimapMaker.CreateMap(save.Map, false);
		MinimapThumbnailMaker.Instance.RenderObject(gameObject, MinimapThumbnailMaker.ThumbSize.Big, LoadingTex);
		MeshFilter[] componentsInChildren = gameObject.GetComponentsInChildren<MeshFilter>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			UnityEngine.Object.Destroy(componentsInChildren[i].sharedMesh);
		}
		UnityEngine.Object.Destroy(gameObject);
		GameSettings.Instance.LoadingImage.gameObject.SetActive(true);
	}

	public IEnumerator HandleLoad(IEnumerator<GameReader.LoadMessage> res)
	{
		while (true)
		{
			bool flag;
			try
			{
				flag = res.MoveNext();
			}
			catch (Exception e)
			{
				flag = false;
				HandleLoadException(e);
			}
			if (flag)
			{
				GameReader.LoadMessage current = res.Current;
				string text = (current.UseValue ? current.Message.Loc(current.Value) : current.Message.Loc());
				if (current.Done > 0f)
				{
					GameSettings.Instance.LoadingBar.gameObject.SetActive(true);
					GameSettings.Instance.LoadingBar.Value = current.Done;
				}
				else
				{
					GameSettings.Instance.LoadingBar.gameObject.SetActive(false);
				}
				GameSettings.Instance.LoadingText.text = text;
				GameSettings.Instance.LoadingCamera.Render();
				yield return new WaitForEndOfFrame();
				continue;
			}
			break;
		}
	}

	public void HandleLoadException(Exception e)
	{
		GameSettings.Instance.LoadingCamera.gameObject.SetActive(false);
		if (GameData.LoadFile != null && GameData.LoadFile.IsOlder())
		{
			WindowManager.Instance.ShowMessageBox("OldSaveGameError".Loc(GameData.LoadFile.GameVersion, Versioning.VersionString), false, DialogWindow.DialogType.Error);
		}
		else
		{
			ErrorLogging.LoggedErrors = 1;
			Debug.LogException(e);
			WindowManager.Instance.ShowMessageBox("LoadGameFail2".Loc(), false, DialogWindow.DialogType.Error, delegate
			{
				FeedbackWindow.Instance.Show(FeedbackWindow.ReportTypes.Exception, null, true, true, null, Path.GetFullPath(GameData.LoadFile.FileName));
				FeedbackWindow.Instance.IncludeSave.gameObject.SetActive(false);
				FeedbackWindow.Instance.Exception = e.ToString();
			});
		}
		ErrorLogging.FirstOfScene = false;
		ErrorLogging errorLogging = UnityEngine.Object.FindObjectOfType<ErrorLogging>();
		if (errorLogging != null)
		{
			UnityEngine.Object.DestroyImmediate(errorLogging.gameObject);
		}
	}

	public void InvokeAction()
	{
		List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
		Selectable selectable = null;
		foreach (Selectable item in Selected.SelectNotNull((Selectable x) => x.PanelActionDivert()).Distinct())
		{
			if (_currentPanelAction.Equals(item.GetPanelActionName()))
			{
				selectable = item;
				item.InvokePanelAction(list);
			}
		}
		if (selectable != null)
		{
			selectable.FinalizePanelAction(_currentPanelAction, list);
		}
		if (list.Count > 0)
		{
			GameSettings.Instance.AddUndo(list.ToArray());
		}
		UpdateInfoPanel();
	}

	public void BoostSliderChange()
	{
		float num = BoostSlider.value.MapRange(BoostSlider.minValue, BoostSlider.maxValue, _minBoostValue, _maxBoostValue);
		if (!_disableBoostChange)
		{
			foreach (Furniture item in Selected.OfType<Furniture>())
			{
				if (item.CanBoost && _minBoostValue == item.MinBoostValue && _maxBoostValue == item.MaxBoostValue && _boostIncrement == item.BoostIncrement)
				{
					item.BoostValue = num;
				}
			}
		}
		BoostLabel.text = num.ToPercent();
	}

	public static void UpdateInfoPanel(string text, string[] ExtraText, string[] Icons, string[] tooltips, Color[] Colors, float[] boost, string panelAction, string panelTip, bool special = true, bool forceRow = false)
	{
		if (Instance == null || GameSettings.IsQuitting)
		{
			return;
		}
		Instance._currentPanelAction = panelAction;
		Instance.InfoText.text = text;
		if (Instance._currentPanelAction == null)
		{
			Instance.PanelButton.SetActive(false);
		}
		else
		{
			Instance.PanelButton.SetActive(true);
			Instance.PanelButtonText.text = Instance._currentPanelAction.Loc();
			string text2 = panelTip ?? "";
			if (!text2.Equals(Instance.PanelButtonTip.TooltipDescription))
			{
				Instance.PanelButtonTip.TooltipDescription = text2;
				Instance.PanelButtonTip.UpdateTip();
			}
		}
		if (boost != null)
		{
			Instance._minBoostValue = boost[0];
			Instance._maxBoostValue = boost[1];
			Instance._boostIncrement = boost[2];
			float num = (boost[1] - boost[0]) / boost[2];
			Instance._disableBoostChange = true;
			Instance.BoostSliderPanel.SetActive(true);
			Instance.BoostSlider.maxValue = num;
			Instance.BoostSlider.value = boost[3].MapRange(boost[0], boost[1], 0f, num);
			Instance._disableBoostChange = false;
		}
		else
		{
			Instance.BoostSliderPanel.SetActive(false);
		}
		if (ExtraText == null)
		{
			Instance.StatPanel.SetActive(false);
			Instance.BigPanel.SetActive(false);
		}
		else if (ExtraText.Length == 1 && !forceRow)
		{
			Instance.StatPanel.SetActive(false);
			Instance.BigPanel.SetActive(true);
			Instance.BigText.text = ExtraText[0];
			Instance.BigImage.sprite = ObjectDatabase.GetIcon(Icons[0]);
		}
		else if (ExtraText.Length < 5)
		{
			Instance.StatPanel.SetActive(true);
			Instance.BigPanel.SetActive(false);
			for (int i = 0; i < ExtraText.Length; i++)
			{
				Instance.StatText[i].text = ExtraText[i];
				Instance.StatImages[i].sprite = ObjectDatabase.GetIcon(Icons[i]);
				Instance.StatImages[i].color = ((Colors == null) ? new Color(0.3f, 0.3f, 0.3f) : Colors[i]);
				GUIToolTipper component = Instance.StatText[i].transform.parent.GetComponent<GUIToolTipper>();
				component.ToolTipValue = "";
				component.TooltipDescription = "";
				if (tooltips != null)
				{
					if (tooltips[i].Length > 0 && tooltips[i][0] == '#')
					{
						int num2 = tooltips[i].IndexOf("\n", StringComparison.Ordinal);
						component.ToolTipValue = tooltips[i].Substring(1, num2 - 1);
						component.TooltipDescription = tooltips[i].Substring(num2 + 1);
					}
					else
					{
						component.ToolTipValue = tooltips[i];
					}
				}
			}
			for (int j = ExtraText.Length; j < 4; j++)
			{
				Instance.StatText[j].text = "";
				Instance.StatImages[j].color = new Color(0f, 0f, 0f, 0f);
				GUIToolTipper component2 = Instance.StatText[j].transform.parent.GetComponent<GUIToolTipper>();
				component2.ToolTipValue = "";
				component2.TooltipDescription = "";
			}
		}
		else if (ExtraText.Length == 5)
		{
			Instance.StatPanel.SetActive(true);
			Instance.BigPanel.SetActive(true);
			Instance.BigText.text = ExtraText[0];
			Instance.BigImage.sprite = ObjectDatabase.GetIcon(Icons[0]);
			for (int k = 0; k < 4; k++)
			{
				Instance.StatText[k].text = ExtraText[k + 1];
				Instance.StatImages[k].sprite = ObjectDatabase.GetIcon(Icons[k + 1]);
				Instance.StatImages[k].color = ((Colors == null) ? new Color(0.3f, 0.3f, 0.3f) : Colors[k]);
				GUIToolTipper component3 = Instance.StatText[k].transform.parent.GetComponent<GUIToolTipper>();
				component3.ToolTipValue = "";
				component3.TooltipDescription = "";
				if (tooltips != null)
				{
					if (tooltips[k].Length > 0 && tooltips[k][0] == '#')
					{
						int num3 = tooltips[k].IndexOf("\n", StringComparison.Ordinal);
						component3.ToolTipValue = tooltips[k].Substring(1, num3 - 1);
						component3.TooltipDescription = tooltips[k].Substring(num3 + 1);
					}
					else
					{
						component3.ToolTipValue = tooltips[k];
					}
				}
			}
		}
		Instance.SpecialInfo = special;
	}

	public static void UpdateInfoPanel()
	{
		if (Instance == null || GameSettings.IsQuitting)
		{
			return;
		}
		int num = Instance.Selected.Count((Selectable x) => x != null && x.gameObject != null);
		if (num == 0)
		{
			UpdateInfoPanel("", null, null, null, null, null, null, null, false);
		}
		else if (num == 1)
		{
			float sum = 0f;
			Selectable selectable = Instance.Selected.First((Selectable x) => x != null && x.gameObject != null);
			Furniture furniture;
			UpdateInfoPanel(selectable.GetInfo().Trim(), selectable.GetExtendedInfo(), selectable.GetExtendedIconInfo(), selectable.GetExtendedTooltipInfo(), selectable.GetExtendedColorInfo(), ((object)(furniture = selectable as Furniture) == null || !furniture.CanBoost) ? null : new float[4] { furniture.MinBoostValue, furniture.MaxBoostValue, furniture.BoostIncrement, furniture.BoostValue }, selectable.GetPanelActionName(), selectable.GetPanelActionTip(ref sum), false);
		}
		else
		{
			if (num <= 1)
			{
				return;
			}
			Dictionary<SelectionTypes, int> selection = GetSelection();
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			int num2 = 0;
			int count = selection.Count;
			foreach (KeyValuePair<SelectionTypes, int> item in selection.OrderBy((KeyValuePair<SelectionTypes, int> x) => (int)x.Key).ToList())
			{
				if (num2 == 3 && selection.Count > 1)
				{
					break;
				}
				switch (item.Key)
				{
				case SelectionTypes.Employee:
					list2.Add("MoreEmployees");
					list3.Add("Employees".Loc());
					break;
				case SelectionTypes.Parking:
					list2.Add("Parking");
					list3.Add("Parking".Loc());
					break;
				case SelectionTypes.Room:
					list2.Add("Structure");
					list3.Add("Rooms".Loc());
					break;
				case SelectionTypes.Furniture:
					list2.Add("Furniture");
					list3.Add("Furniture".Loc());
					break;
				case SelectionTypes.Segment:
					list2.Add("Door");
					list3.Add("WallSegments".Loc());
					break;
				case SelectionTypes.Roof:
					list2.Add("Roof");
					list3.Add("Roofs".Loc());
					break;
				case SelectionTypes.Path:
					list2.Add("Path");
					list3.Add("Path".Loc());
					break;
				}
				list.Add(item.Value.ToString());
				selection.Remove(item.Key);
				num2++;
			}
			if (count == 1)
			{
				Selectable selectable2 = Instance.Selected.First((Selectable x) => x != null && x.gameObject != null);
				string[] multiIcon = selectable2.GetMultiIcon();
				if (multiIcon != null)
				{
					list2.AddRange(multiIcon);
					list3.AddRange(selectable2.GetMultiDesc());
					list.AddRange(selectable2.GetMultiValue(Instance.Selected.Where((Selectable x) => x != null && x.gameObject != null)));
				}
			}
			if (selection.Count > 0)
			{
				list2.Add("Cogs");
				list3.Add("Various".Loc());
				list.Add(selection.Sum((KeyValuePair<SelectionTypes, int> x) => x.Value).ToString());
			}
			string tip;
			UpdateInfoPanel("", list.ToArray(), list2.ToArray(), list3.ToArray(), null, GetPanelBoost(), GetPanelAction(out tip), tip, false, true);
		}
	}

	private static float[] GetPanelBoost()
	{
		float[] array = null;
		foreach (Furniture item in Instance.Selected.OfType<Furniture>())
		{
			if (item.CanBoost)
			{
				if (array == null)
				{
					array = new float[4] { item.MinBoostValue, item.MaxBoostValue, item.BoostIncrement, item.BoostValue };
				}
				else if (item.MinBoostValue != array[0] || item.MaxBoostValue != array[1] || item.BoostIncrement != array[2])
				{
					array = null;
					break;
				}
			}
		}
		return array;
	}

	private static string GetPanelAction(out string tip)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		HashSet<Selectable> hashSet = new HashSet<Selectable>();
		string text = null;
		bool flag = true;
		tip = null;
		float sum = 0f;
		foreach (Selectable item in Instance.Selected)
		{
			string panelActionName = item.GetPanelActionName();
			if (panelActionName == null || (item.PanelActionOnlyOnce() && Instance.Selected.Count > 1))
			{
				continue;
			}
			dictionary.AddUp(panelActionName);
			if (hashSet.Add(item.PanelActionDivert()) && flag)
			{
				if (text == null || text.Equals(panelActionName))
				{
					tip = item.GetPanelActionTip(ref sum);
					text = panelActionName;
				}
				else if (!panelActionName.Equals(text))
				{
					tip = null;
					flag = false;
				}
			}
		}
		if (dictionary.Count <= 0)
		{
			return null;
		}
		return dictionary.MaxInstance((KeyValuePair<string, int> x) => x.Value).Key;
	}

	private static Dictionary<SelectionTypes, int> GetSelection()
	{
		Dictionary<SelectionTypes, int> dictionary = new Dictionary<SelectionTypes, int>();
		foreach (Selectable item in Instance.Selected.Where((Selectable x) => x != null && x.gameObject != null))
		{
			if (item is Actor)
			{
				dictionary.AddUp(SelectionTypes.Employee);
			}
			else if (item is Room)
			{
				dictionary.AddUp(SelectionTypes.Room);
			}
			else if (item is Furniture)
			{
				dictionary.AddUp(SelectionTypes.Furniture);
			}
			else if (item is RoomSegment)
			{
				dictionary.AddUp(SelectionTypes.Segment);
			}
			else if (item is RoadNode)
			{
				dictionary.AddUp(SelectionTypes.Parking);
			}
			else if (item is Roof)
			{
				dictionary.AddUp(SelectionTypes.Roof);
			}
			else if (item is PathObject)
			{
				dictionary.AddUp(SelectionTypes.Path);
			}
		}
		return dictionary;
	}

	public float ShiftMid(float val, float mid)
	{
		if (val > mid)
		{
			return (val - mid) / (1f - mid);
		}
		return val / mid - 1f;
	}

	public bool MouseOverObject()
	{
		if (_currentHighlight == null)
		{
			return false;
		}
		if (!(_currentHighlight is RoomSegment))
		{
			return _currentHighlight is Furniture;
		}
		return true;
	}

	public bool MouseOverSelectable()
	{
		return _currentHighlight != null;
	}

	private void UpdateHoverHighlight()
	{
		if (GameSettings.FreezeGame || BuildController.Instance.IsActive() || WindowManager.HasModal || GUICheck.OverGUI || CameraScript.Instance.FlyMode || GameSettings.Instance.WireMode)
		{
			if (_currentHighlight != null)
			{
				_currentHighlight.HoverHighlight(false);
				_currentHighlight = null;
			}
			return;
		}
		Vector2 vector = Input.mousePosition;
		if (!(vector != _lastMousePos))
		{
			return;
		}
		_highlightUpdate -= Time.deltaTime;
		if (!(_highlightUpdate <= 0f))
		{
			return;
		}
		_lastMousePos = vector;
		_highlightUpdate = 1f / 15f;
		Ray ray = CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition);
		float depth;
		Selectable roomRoofAt = GetRoomRoofAt(ray, true, true, true, out depth);
		RaycastHit[] source = Physics.RaycastAll(ray);
		Selectable selectable = null;
		foreach (RaycastHit item in source.OrderBy((RaycastHit x) => x.distance))
		{
			Selectable selectable2 = item.collider.GetComponent<Selectable>();
			if (selectable2 == null && item.rigidbody != null)
			{
				selectable2 = item.rigidbody.GetComponent<Selectable>();
			}
			int num = 0;
			if (selectable2 == null)
			{
				SelectRefer component = item.collider.GetComponent<SelectRefer>();
				if (component != null)
				{
					selectable2 = component.Target;
					num--;
				}
			}
			if (selectable2 != null && selectable2.IsSelectable() && item.distance < depth && selectable2.enabled && (selectable2.IsSelectableAboveFloor() || selectable2.GetTransformPosition().y < (float)(GameSettings.Instance.ActiveFloor * 2) + 1.85f) && (roomRoofAt == null || !(selectable2.GetTransformPosition().y < (float)((roomRoofAt.GetFloor() + num) * 2 - 1))) && MouseOverPixel(selectable2, _pixelTex, CameraScript.Instance.mainCam, WhiteMat, _selectMesh))
			{
				selectable = selectable2;
				break;
			}
		}
		selectable = selectable ?? roomRoofAt;
		if (selectable == null)
		{
			selectable = CheckPath();
		}
		if (selectable != _currentHighlight)
		{
			if (_currentHighlight != null)
			{
				_currentHighlight.HoverHighlight(false);
			}
			_currentHighlight = selectable;
			if (_currentHighlight != null)
			{
				_currentHighlight.HoverHighlight(true);
			}
		}
	}

	private void LateUpdate()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		for (int i = 0; i < GameSettings.Instance.sRoomManager.TempGroups.Count; i++)
		{
			GameSettings.Instance.sRoomManager.TempGroups[i].TogglePipes(false, false, TemperatureGroup.TempType.Both);
		}
		foreach (Selectable item in Selected)
		{
			if (item != null)
			{
				TemperatureGroup tempGroup = item.GetTempGroup();
				if (tempGroup != null)
				{
					tempGroup.TogglePipes(true, false, item.GetTempType());
				}
			}
		}
		UpdateHoverHighlight();
		if (_currentPanelAction != null)
		{
			PanelActionImg.color = (_panelActionPulseSet.Contains(_currentPanelAction) ? PanelActionPulse.Evaluate(Time.realtimeSinceStartup * PanelActionPulseSpeed % 1f) : Color.white);
		}
		if (!SpecialInfo)
		{
			UpdateInfoPanel();
		}
		if (Selected.Count == 1)
		{
			Actor actor = Selected.First() as Actor;
			if (actor != null)
			{
				if (actor.IsEmployee())
				{
					if (actor.AItype == AI.AIType.Robot)
					{
						NeedPanel.SetActive(false);
						RobotPanel.SetActive(true);
						float dLCDataDefault = actor.GetDLCDataDefault("RobotPower", 0f);
						float dLCDataDefault2 = actor.GetDLCDataDefault("RobotCapacity", 1f);
						Furniture value;
						if (actor.GetDLCData<Furniture>("ChargingStation", out value))
						{
							RobotBars[0].Value = Mathf.Clamp(dLCDataDefault + SDateTime.GetHours(actor.DespawnTime, SDateTime.Now()) * value.Wattage, 0f, dLCDataDefault2) / dLCDataDefault2;
						}
						else
						{
							float dLCDataDefault3 = actor.GetDLCDataDefault("RobotUsage", 1f);
							RobotBars[0].Value = Mathf.Clamp(dLCDataDefault - SDateTime.GetHours(actor.DriveTime, SDateTime.Now()) * dLCDataDefault3, 0f, dLCDataDefault2) / dLCDataDefault2;
						}
						RobotBars[1].Value = 1f;
					}
					else
					{
						NeedPanel.SetActive(true);
						RobotPanel.SetActive(false);
						NeedBars[0].Value = ShiftMid(actor.employee.Energy, actor.employee.ModTrait(Employee.Trait.Capacitor, 0.33056706f, 0.4686707f));
						NeedBars[3].Value = actor.employee.Stress * 2f - 1f;
						NeedBarLayout.minHeight = (actor.employee.Founder ? 16 : 50);
						NeedBars[1].gameObject.SetActive(!actor.employee.Founder);
						NeedBars[2].gameObject.SetActive(!actor.employee.Founder);
						NeedBars[4].gameObject.SetActive(!actor.employee.Founder);
						NeedBars[5].gameObject.SetActive(!actor.employee.Founder);
						if (!actor.employee.Founder)
						{
							NeedBars[1].Value = ShiftMid(actor.employee.Hunger, 0.0914397f);
							NeedBars[2].Value = ShiftMid(actor.employee.Bladder, 0.0559124f);
							NeedBars[4].Value = actor.employee.Social * 2f - 1f;
							NeedBars[5].Value = actor.employee.Posture;
						}
					}
				}
				else
				{
					NeedPanel.SetActive(false);
					RobotPanel.SetActive(false);
				}
			}
			else
			{
				NeedPanel.SetActive(false);
				RobotPanel.SetActive(false);
			}
		}
		else
		{
			NeedPanel.SetActive(false);
			RobotPanel.SetActive(false);
		}
		if (InputController.GetKeyUp(InputController.Keys.GotoEmp) && BuildController.Instance.CanChangeFloor() && Selected.Count > 0)
		{
			List<Selectable> list = Selected.ToList();
			int num = _focusSelector % list.Count;
			for (int j = 0; j < list.Count; j++)
			{
				num = (_focusSelector + j) % list.Count;
				Selectable selectable = list[num];
				if (selectable != null && selectable.isActiveAndEnabled)
				{
					CameraScript.Instance.MoveTo(selectable.GetFlatPos(), selectable.GetFloor());
					break;
				}
			}
			_focusSelector = (num + 1) % list.Count;
		}
		if (!GameSettings.FreezeGame && !BuildController.Instance.IsActive() && !WindowManager.HasModal && InputController.GetKeyDown(InputController.Keys.DuplicateFurniture))
		{
			CloneTool();
		}
		if (!GameSettings.FreezeGame && !BuildController.Instance.IsActive() && !WindowManager.HasModal && InputController.GetKeyDown(InputController.Keys.FurnitureMove))
		{
			EnableMoveHint = false;
			Selectable[] xs = (from x in Selected.OfType<Furniture>()
				where x != null && x.GetActions().Contains("Move")
				select x).ToArray();
			MoveAction(xs, this);
			EnableMoveHint = true;
		}
		if (Selected.Count > 0 && !WindowManager.HasModal && InputController.GetKeyUp(InputController.Keys.Destroy) && GameSettings.ConstructionAllowed())
		{
			List<Actor> actors = Selected.OfType<Actor>().ToList();
			actors.RemoveAll((Actor x) => x.employee.Founder);
			HashSet<Room> rooms = ((!GameSettings.Instance.EditMode && GameSettings.Instance.RentMode) ? new HashSet<Room>() : (from x in Selected.OfType<Room>()
				where !x.BuildingOnFire
				select x).SelectMany((Room x) => x.GetAtriumChildren().Append(x)).ToHashSet());
			HashSet<Roof> roofs = ((!GameSettings.Instance.EditMode && GameSettings.Instance.RentMode) ? new HashSet<Roof>() : Selected.OfType<Roof>().ToHashSet());
			roofs.AddRange(rooms.SelectNotNull((Room x) => x.Roofing));
			List<Furniture> furniture = (from x in Selected.OfType<Furniture>()
				where !x.Parent.BuildingOnFire && (x.IsCampaignOwned() || (x.IsPlayerControlled() && x.Parent.IsPlayerControlled()))
				select x).ToList();
			furniture.ForEach(delegate(Furniture x)
			{
				x.PreferInventory = false;
			});
			furniture.RemoveAll((Furniture x) => rooms.Contains(x.Parent));
			List<RoomSegment> segments = ((!GameSettings.Instance.EditMode && GameSettings.Instance.RentMode) ? new List<RoomSegment>() : Selected.OfType<RoomSegment>().ToList());
			List<PathObject> paths = ((!GameSettings.Instance.EditMode && GameSettings.Instance.RentMode) ? new List<PathObject>() : Selected.OfType<PathObject>().ToList());
			segments.RemoveAll((RoomSegment x) => (x.ParentRooms[0] != null && rooms.Contains(x.ParentRooms[0])) || (x.ParentRooms[1] != null && rooms.Contains(x.ParentRooms[1])));
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("AreYouSure".Loc() + ":");
			bool flag = false;
			if (rooms.Count > 0)
			{
				stringBuilder.AppendLine("BulldozeMsg2".Loc(rooms.Count));
				flag = true;
			}
			if (roofs.Count > 0)
			{
				stringBuilder.AppendLine("BulldozeMsg3".Loc(roofs.Count));
				flag = true;
			}
			if (paths.Count > 0)
			{
				stringBuilder.AppendLine("BulldozeMsg4".Loc(paths.Count));
				flag = true;
			}
			if (furniture.Count > 0)
			{
				stringBuilder.AppendLine("SellMsg2".Loc(furniture.Count));
				flag = true;
			}
			if (segments.Count > 0)
			{
				stringBuilder.AppendLine("DismantleMsg2".Loc(segments.Count));
				flag = true;
			}
			if (actors.Count > 0)
			{
				if (flag)
				{
					actors.Clear();
				}
				else
				{
					stringBuilder.AppendLine("DismissMsg2".Loc(actors.Count));
				}
			}
			if (actors.Count + rooms.Count + furniture.Count + segments.Count + roofs.Count + paths.Count > 0)
			{
				WindowManager.Instance.ShowMessageBox(stringBuilder.ToString(), true, "Trash", DialogWindow.DialogType.Error, DialogWindow.DialogType.Warning, delegate
				{
					if (rooms.Count + furniture.Count + segments.Count + roofs.Count + paths.Count > 0)
					{
						UISoundFX.PlaySFX("BuyRev", true);
					}
					BuildController.Instance.ClearBuild();
					UndoObject.UndoAction undoAction = null;
					if (paths.Count > 0)
					{
						undoAction = new UndoObject.UndoAction(false, paths.Where((PathObject pathObject) => pathObject != null).ToArray());
						paths.ForEach(delegate(PathObject pathObject)
						{
							if (pathObject != null)
							{
								GameSettings.Instance.sRoomManager.PathController.DeleteEntirePath(pathObject);
								Selected.Remove(pathObject);
							}
						});
					}
					List<UndoObject.UndoAction> list2 = new List<UndoObject.UndoAction>();
					bool flag2 = false;
					foreach (Actor item2 in actors.Where((Actor actor2) => actor2 != null))
					{
						item2.Fire(false);
						if (item2.AItype == AI.AIType.Employee)
						{
							GameSettings.Instance.RegisterStat("Fired", 1f);
						}
					}
					HashSet<Furniture> hashSet = new HashSet<Furniture>();
					HashSet<RoomSegment> segmentss = new HashSet<RoomSegment>();
					List<UndoObject.UndoAction> list3 = new List<UndoObject.UndoAction>();
					if (rooms.Any((Room room2) => room2.IsBalcony))
					{
						List<Room> list4 = rooms.Where((Room room2) => room2.IsBalcony).ToList();
						bool flag3 = true;
						while (list4.Count > 0 && flag3)
						{
							flag3 = false;
							for (int num2 = 0; num2 < list4.Count; num2++)
							{
								Room room = list4[num2];
								if (!rooms.Contains(room.AtriumParent) || !GameSettings.Instance.sRoomManager.CanDestroy(room.AtriumParent, rooms))
								{
									rooms.Remove(room);
									if (room.AtriumParent.CanMerge(room, true))
									{
										Room atriumParent = room.AtriumParent;
										int count = list2.Count;
										List<Vector2> split = atriumParent.MergeWith(room, room.PrepareSplit(true, atriumParent.PrepareSplit(true)), list2);
										atriumParent.AtriumChildren.Remove(room);
										list2.Add(new UndoObject.UndoAction(atriumParent, room, split));
										Selected.Remove(room);
										flag3 = true;
										list4.RemoveAt(num2);
										num2--;
									}
								}
							}
						}
					}
					foreach (Room item3 in from room2 in rooms
						where room2 != null
						orderby room2.Floor descending, (!room2.IsBalcony) ? 1 : 0
						select room2)
					{
						if (GameSettings.Instance.sRoomManager.CanDestroy(item3, rooms))
						{
							list2.Add(new UndoObject.UndoAction(item3, false, 0f));
							List<RoomSegment> segments2 = item3.GetSegments(rooms);
							list3.AddRange(segments2.WhereSelect((RoomSegment z) => !segmentss.Contains(z), (RoomSegment z) => new UndoObject.UndoAction(z, false)));
							segmentss.AddRange(segments2);
							Room x1 = item3;
							hashSet.AddRange(from z in item3.GetFurnitures()
								where !z.KeepWithoutParent(x1)
								select z);
							Selected.Remove(item3);
							item3.DestroyGO();
							GameSettings.Instance.sRoomManager.Rooms.RemoveAll((Room y) => y == x1);
						}
						else
						{
							flag2 = true;
						}
					}
					list2.Reverse();
					list2.AddRange(list3);
					list2.AddRange(hashSet.OrderBy((Furniture y) => y.GetSnappingDepth()).Select(delegate(Furniture y)
					{
						if (y.PreferInventory)
						{
							GameSettings.AddToInventory(y);
						}
						return new UndoObject.UndoAction(y, false, y.PreferInventory);
					}));
					foreach (Furniture item4 in from furniture2 in furniture
						where furniture2 != null
						orderby furniture2.GetSnappingDepth()
						select furniture2)
					{
						if (!hashSet.Contains(item4) && item4.IsAliveNotNull())
						{
							list2.Add(new UndoObject.UndoAction(item4, false, item4.PreferInventory));
							if (item4.PreferInventory)
							{
								GameSettings.AddToInventory(item4);
								item4.Undo = true;
							}
							hashSet.Add(item4);
							foreach (Furniture item5 in item4.IterateSnap())
							{
								if (item5.PreferInventory)
								{
									GameSettings.AddToInventory(item5);
									item5.Undo = true;
								}
								list2.Add(new UndoObject.UndoAction(item5, false, item5.PreferInventory));
								hashSet.Add(item5);
							}
							Selected.Remove(item4);
							item4.DestroyGO();
						}
					}
					foreach (RoomSegment item6 in segments.Where((RoomSegment roomSegment) => roomSegment != null))
					{
						if (item6.IsAliveNotNull())
						{
							list2.Add(new UndoObject.UndoAction(item6, false));
							Selected.Remove(item6);
							item6.DestroyGO();
						}
					}
					if (roofs.Count > 0)
					{
						list2.Add(new UndoObject.UndoAction(false, roofs.ToArray()));
						foreach (Roof item7 in roofs)
						{
							Selected.Remove(item7);
							item7.DestroyGO();
						}
					}
					if (undoAction != null)
					{
						list2.Add(undoAction);
					}
					if (list2.Count > 0)
					{
						GameSettings.Instance.AddUndo(list2.ToArray());
					}
					DoPostSelectChecks();
					ToggleRightClickMenu(false);
					if (flag2)
					{
						WindowManager.Instance.ShowMessageBox("CannotBulldozeSupport".Loc(), false, DialogWindow.DialogType.Error);
					}
					GameSettings.Instance.sRoomManager.RecalculateAllDirtyTableGroups();
				}, (actors.Count > 0) ? null : "Delete button");
			}
		}
		SelectionCode();
	}

	private HashSet<string> GetTypes(bool rect = false)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (Selectable item in Selected)
		{
			if (item != null && (!rect || item.CanRectSelect()))
			{
				string selectionType = GetSelectionType(item);
				if (selectionType != null)
				{
					hashSet.Add(selectionType);
				}
			}
		}
		return hashSet;
	}

	private string GetSelectionType(Selectable sel)
	{
		if (sel is Furniture)
		{
			Furniture furniture = (Furniture)sel;
			return furniture.Type + furniture.SelectionSubType;
		}
		if (sel is RoomSegment)
		{
			return ((RoomSegment)sel).Type;
		}
		if (sel is Room)
		{
			return "Room";
		}
		if (sel is Actor)
		{
			return "Actor";
		}
		if (sel is RoadNode)
		{
			return "Parking";
		}
		if (sel is Roof)
		{
			return "Roof";
		}
		if (sel is PathObject)
		{
			return "Path";
		}
		return null;
	}

	private bool RectSelect(Selectable s, Rect r, HashSet<string> types)
	{
		if (!s.enabled || !s.IsSelectable() || !s.CanRectSelect() || s.GetFloor() != GameSettings.Instance.ActiveFloor)
		{
			return false;
		}
		Vector3 point = CameraScript.Instance.SSAScript.WorldToScreenPoint(s.GetSelectPosition());
		if (point.z >= 0f)
		{
			if (r.Contains(point))
			{
				if (types != null)
				{
					return types.Contains(GetSelectionType(s));
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private void AddSelectedRect(Selectable sel, bool multi, ref bool handled)
	{
		if (!handled)
		{
			handled = true;
			if (!multi)
			{
				Selected.ForEachEnum(delegate(Selectable x)
				{
					x.Highlight(false);
				});
				Selected.Clear();
			}
		}
		Selected.Add(sel);
	}

	private PathObject CheckPath()
	{
		if (GameSettings.Instance.ActiveFloor >= 0 && (!GameSettings.Instance.RentMode || GameSettings.Instance.EditMode))
		{
			Vector2 mouseProj = HUD.Instance.GetMouseProj(0f, false);
			PathController.PathPoint pathFirst = GameSettings.Instance.sRoomManager.PathController.GetPathFirst(mouseProj, 1f);
			if (pathFirst != null)
			{
				return pathFirst.ParentObject;
			}
			return null;
		}
		return null;
	}

	private void CancelRectDragging()
	{
		_rectDragging = false;
		RectSelectGizmo.gameObject.SetActive(false);
	}

	private void SelectionCode()
	{
		if (GameSettings.FreezeGame || BuildController.Instance.IsActive())
		{
			CancelRectDragging();
			_validStartClick = false;
		}
		else if (!WindowManager.HasModal && !GameSettings.Instance.WireMode && !CameraScript.Instance.wasDragging && GUICheck.OverGUI && InputController.GetKeyUp(InputController.Keys.ContextMenu) && CanClick)
		{
			CancelRectDragging();
			_validStartClick = false;
			if (Selected.Count > 0)
			{
				ToggleRightClickMenu(true);
			}
		}
		else if (_rectDragging && InputController.GetKeyDown(InputController.Keys.ContextMenu))
		{
			CancelRectDragging();
			_validStartClick = false;
		}
		else
		{
			if (GUICheck.OverGUI && !_rectDragging)
			{
				return;
			}
			if (!CanClick || WindowManager.HasModal)
			{
				CancelRectDragging();
				_validStartClick = false;
				CanClick = true;
				return;
			}
			Ray ray = CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition);
			foreach (Selectable item in Selected)
			{
				Actor actor = item as Actor;
				if (!(actor != null) || !actor.isActiveAndEnabled)
				{
					continue;
				}
				string highestThought = actor.employee.GetHighestThought();
				if (highestThought == null)
				{
					continue;
				}
				for (int i = 0; i < actor.Colliders.Length; i++)
				{
					RaycastHit hitInfo;
					if (actor.Colliders[i].Raycast(ray, out hitInfo, 150f))
					{
						ThoughtBubble.Instance.SetThought(highestThought.Loc(), actor.NeckBone);
						break;
					}
				}
			}
			if (GameSettings.Instance.WireMode)
			{
				UpdateInfoPanel("WireModeLongHint".Loc(), null, null, null, null, null, null, null, false);
				if (InputController.GetKeyUp(InputController.Keys.NormalSelection))
				{
					bool flag = false;
					foreach (RaycastHit item2 in from x in Physics.RaycastAll(ray)
						orderby x.distance
						select x)
					{
						Server component = item2.collider.GetComponent<Server>();
						if (!(component != null) || component.GetComponent<Furniture>().Parent.Floor != GameSettings.Instance.ActiveFloor)
						{
							continue;
						}
						if (SelectedServer != null)
						{
							if (SelectedServer == component)
							{
								SelectedServer.CancelWire();
								SelectedServer.Selected = false;
								SelectedServer = null;
							}
							else
							{
								SelectedServer.WireTo(component);
								UISoundFX.PlaySFX("ServerConnect");
								SelectedServer.Selected = false;
								SelectedServer = null;
							}
						}
						else
						{
							SelectedServer = component;
							SelectedServer.Selected = true;
						}
						flag = true;
						break;
					}
					if (!flag && SelectedServer != null)
					{
						SelectedServer.CancelWire();
						SelectedServer.Selected = false;
						SelectedServer = null;
					}
				}
				if (Input.GetMouseButtonUp(1) && SelectedServer != null)
				{
					SelectedServer.Selected = false;
					SelectedServer.ReWire();
					SelectedServer = null;
				}
				return;
			}
			if (InputController.GetKeyDown(InputController.Keys.NormalSelection) || InputController.GetKeyDown(InputController.Keys.MultipleSelect))
			{
				_startClick = Input.mousePosition;
				_validStartClick = true;
			}
			bool keyUp = InputController.GetKeyUp(InputController.Keys.NormalSelection);
			bool key = InputController.GetKey(InputController.Keys.SweepSelect);
			if (InputController.GetKeyDown(InputController.Keys.SweepSelect))
			{
				FirstSweep = true;
				SweepDeselectMode = false;
			}
			bool keyUp2 = InputController.GetKeyUp(InputController.Keys.MultipleSelect);
			Vector2 v = Vector2.zero;
			if (!_rectDragging && !FloorGizmo.IsMoving && _validStartClick && (InputController.GetKey(InputController.Keys.NormalSelection) || InputController.GetKey(InputController.Keys.MultipleSelect) || keyUp || keyUp2))
			{
				v = Input.mousePosition;
				if (v.MinDist(_startClick) >= 4f)
				{
					_rectDragging = true;
					_validStartClick = false;
				}
			}
			if (_rectDragging)
			{
				v = Input.mousePosition;
				RectSelectGizmo.anchoredPosition = new Vector2(Mathf.Min(_startClick.x, v.x), Mathf.Max(_startClick.y, v.y) - (float)Screen.height) / Options.UISize;
				RectSelectGizmo.sizeDelta = new Vector2(Mathf.Abs(_startClick.x - v.x), Mathf.Abs(_startClick.y - v.y)) / Options.UISize;
			}
			RectSelectGizmo.gameObject.SetActive(_rectDragging);
			bool handled = false;
			if (_rectDragging && (keyUp || keyUp2))
			{
				_validStartClick = false;
				CancelRectDragging();
				if (!keyUp2)
				{
					Selected.ForEachEnum(delegate(Selectable x)
					{
						x.Highlight(false);
					});
					Selected.Clear();
				}
				HashSet<string> hashSet = (keyUp2 ? GetTypes(true) : null);
				if (hashSet != null && hashSet.Count == 0)
				{
					hashSet = null;
				}
				Rect r = new Rect(Mathf.Min(_startClick.x, v.x), Mathf.Min(_startClick.y, v.y), Mathf.Abs(_startClick.x - v.x), Mathf.Abs(_startClick.y - v.y));
				for (int num = 0; num < GameSettings.Instance.sRoomManager.AllFurniture.Count; num++)
				{
					Furniture furniture = GameSettings.Instance.sRoomManager.AllFurniture[num];
					if (RectSelect(furniture, r, hashSet))
					{
						AddSelectedRect(furniture, keyUp2, ref handled);
					}
				}
				if (hashSet == null || hashSet.Contains("Actor"))
				{
					for (int num2 = 0; num2 < GameSettings.Instance.sActorManager.Actors.Count; num2++)
					{
						Actor actor2 = GameSettings.Instance.sActorManager.Actors[num2];
						if (RectSelect(actor2, r, hashSet))
						{
							AddSelectedRect(actor2, keyUp2, ref handled);
						}
					}
					for (int num3 = 0; num3 < GameSettings.Instance.sActorManager.Staff.Count; num3++)
					{
						Actor actor3 = GameSettings.Instance.sActorManager.Staff[num3];
						if (RectSelect(actor3, r, hashSet))
						{
							AddSelectedRect(actor3, keyUp2, ref handled);
						}
					}
				}
				if (hashSet == null || hashSet.Contains("Parking"))
				{
					foreach (RoadNode item3 in RoadManager.Instance.GetParkingMesh())
					{
						if (RectSelect(item3, r, hashSet))
						{
							AddSelectedRect(item3, keyUp2, ref handled);
						}
					}
				}
				if (handled)
				{
					DoPostSelectChecks();
				}
			}
			if (!handled && (key || keyUp || keyUp2))
			{
				_validStartClick = false;
				HashSet<string> hashSet2 = (key ? GetTypes() : null);
				bool flag2 = !key || hashSet2.Count == 0;
				float depth;
				Selectable selectable = GetRoomRoofAt(ray, true, flag2 || hashSet2.Contains("Room"), flag2 || hashSet2.Contains("Roof"), out depth);
				if (key && !FirstSweep && selectable != null && SweepDeselectMode != Selected.Contains(selectable))
				{
					selectable = null;
				}
				RaycastHit[] source = Physics.RaycastAll(ray);
				bool hasHit = false;
				foreach (RaycastHit item4 in source.OrderBy((RaycastHit x) => x.distance))
				{
					Selectable selectable2 = item4.collider.GetComponent<Selectable>();
					if (selectable2 == null && item4.rigidbody != null)
					{
						selectable2 = item4.rigidbody.GetComponent<Selectable>();
					}
					int num4 = 0;
					if (selectable2 == null)
					{
						SelectRefer component2 = item4.collider.GetComponent<SelectRefer>();
						if (component2 != null)
						{
							selectable2 = component2.Target;
							num4--;
						}
					}
					if (selectable2 != null && selectable2.IsSelectable() && item4.distance < depth && selectable2.enabled && (selectable2.IsSelectableAboveFloor() || !(selectable2.GetTransformPosition().y > (float)(GameSettings.Instance.ActiveFloor * 2) + 1.85f)) && (!(selectable != null) || !(selectable2.GetTransformPosition().y < (float)((selectable.GetFloor() + num4) * 2 - 1))))
					{
						DoObjectSelection(selectable2.DeferSelection(), key, keyUp2, hashSet2, true, false, ref hasHit, true);
						if (hasHit)
						{
							break;
						}
					}
				}
				if (!hasHit && selectable != null)
				{
					DoObjectSelection(selectable.DeferSelection(), key, keyUp2, hashSet2, false, true, ref hasHit);
				}
				if (!hasHit)
				{
					PathObject pathObject = CheckPath();
					if (pathObject != null)
					{
						DoObjectSelection(pathObject.DeferSelection(), key, keyUp2, hashSet2, false, false, ref hasHit);
					}
				}
				if (!hasHit && !keyUp2 && !key)
				{
					Highligt(false);
					Selected.Clear();
				}
				DoPostSelectChecks();
			}
			if (!InputController.GetKeyUp(InputController.Keys.ContextMenu) || CameraScript.Instance.wasDragging)
			{
				return;
			}
			if (Selected.Count < 2)
			{
				float depth2;
				Selectable selectable3 = GetRoomRoofAt(ray, true, true, true, out depth2);
				RaycastHit[] source2 = Physics.RaycastAll(ray);
				bool flag3 = false;
				foreach (RaycastHit item5 in source2.OrderBy((RaycastHit x) => x.distance))
				{
					Selectable selectable4 = item5.collider.GetComponent<Selectable>();
					if (selectable4 == null && item5.rigidbody != null)
					{
						selectable4 = item5.rigidbody.GetComponent<Selectable>();
					}
					int num5 = 0;
					if (selectable4 == null)
					{
						SelectRefer component3 = item5.collider.GetComponent<SelectRefer>();
						if (component3 != null)
						{
							selectable4 = component3.Target;
							num5--;
						}
					}
					if (selectable4 != null && selectable4.IsSelectable() && item5.distance < depth2 && selectable4.enabled && (selectable4.IsSelectableAboveFloor() || !(selectable4.GetTransformPosition().y > (float)(GameSettings.Instance.ActiveFloor * 2) + 1.85f)) && (!(selectable3 != null) || !(selectable4.GetTransformPosition().y < (float)((selectable3.GetFloor() + num5) * 2 - 1))) && MouseOverPixel(selectable4, _pixelTex, CameraScript.Instance.mainCam, WhiteMat, _selectMesh))
					{
						selectable4 = selectable4.DeferSelection();
						if (Selected.Contains(selectable4))
						{
							flag3 = true;
							break;
						}
						Highligt(false);
						Selected.Clear();
						UISoundFX.PlaySFX("ObjectHighlight", true);
						Selected.Add(selectable4);
						DoPostSelectChecks();
						flag3 = true;
						break;
					}
				}
				if (selectable3 != null)
				{
					selectable3 = selectable3.DeferSelection();
				}
				if (!flag3 && selectable3 != null)
				{
					Highligt(false);
					Selected.Clear();
					UISoundFX.PlaySFX("ObjectHighlight", true);
					Selected.Add(selectable3);
					DoPostSelectChecks();
					flag3 = true;
				}
				if (!flag3)
				{
					PathObject pathObject2 = CheckPath();
					if (pathObject2 != null)
					{
						Highligt(false);
						Selected.Clear();
						UISoundFX.PlaySFX("ObjectHighlight", true);
						Selected.Add(pathObject2);
						DoPostSelectChecks();
						flag3 = true;
					}
				}
			}
			if (Selected.Count > 0)
			{
				ToggleRightClickMenu(true);
			}
		}
	}

	public void DoObjectSelection(Selectable c, bool sweep, bool multi, HashSet<string> types, bool canMove, bool presumeSweep, ref bool hasHit, bool pixelPerfect = false)
	{
		if (sweep)
		{
			if (FirstSweep)
			{
				SweepDeselectMode = Selected.Contains(c);
			}
			if (SweepDeselectMode == Selected.Contains(c) && (presumeSweep || types.Count == 0 || types.Contains(GetSelectionType(c))) && (!pixelPerfect || MouseOverPixel(c, _pixelTex, CameraScript.Instance.mainCam, WhiteMat, _selectMesh)))
			{
				if (SweepDeselectMode)
				{
					c.Highlight(false);
					Selected.Remove(c);
				}
				else
				{
					UISoundFX.PlaySFX("ObjectHighlight", true);
					Selected.Add(c);
				}
				FirstSweep = false;
				hasHit = true;
			}
		}
		else
		{
			if (pixelPerfect && !MouseOverPixel(c, _pixelTex, CameraScript.Instance.mainCam, WhiteMat, _selectMesh))
			{
				return;
			}
			if (!multi)
			{
				if (canMove && HUD.Instance.BuildMode && Selected.Count == 1 && Time.timeSinceLevelLoad - LastSelectTime < 0.3f && Selected.Contains(c) && c.GetActions().Contains("Move"))
				{
					EnableMoveHint = false;
					RightClickActions["Move"].GroupAction(Selected.ToArray(), this);
					EnableMoveHint = true;
					hasHit = true;
					return;
				}
				Highligt(false);
				Selected.Clear();
			}
			if (!Selected.Contains(c))
			{
				if (canMove)
				{
					LastSelectTime = Time.timeSinceLevelLoad;
				}
				UISoundFX.PlaySFX("ObjectHighlight", true);
				Selected.Add(c);
				if (multi)
				{
					HintController.Show(HintController.Hints.HintQuickSelect);
				}
			}
			else if (multi)
			{
				c.Highlight(false);
				Selected.Remove(c);
			}
			hasHit = true;
		}
	}

	public Selectable GetRoomRoofAt(Ray mouseRay, bool includeSelected, bool rooms, bool roofs, out float depth)
	{
		depth = float.PositiveInfinity;
		if (!rooms && !roofs)
		{
			return null;
		}
		bool flag = GameSettings.Instance.ActiveFloor < 0;
		Room room = null;
		Vector3 point = mouseRay.GetPoint(0f);
		int count = GameSettings.Instance.sRoomManager.Rooms.Count;
		bool flag2 = GameSettings.WallsDown == GameSettings.WallState.Back || GameSettings.WallsDown == GameSettings.WallState.High;
		float num = 1f;
		if (flag2)
		{
			float x = CameraScript.Instance.transform.rotation.eulerAngles.x;
			flag2 = x < 80f;
			if (rooms && flag2)
			{
				x = 90f - x;
				num = Mathf.Tan(x * ((float)Math.PI / 180f)) * 1.5f;
			}
		}
		for (int num2 = GameSettings.Instance.ActiveFloor; num2 >= (flag ? (-1) : 0); num2--)
		{
			float d;
			Vector2 mouseOnFloor = GetMouseOnFloor(mouseRay, num2, out d);
			if (rooms)
			{
				for (int i = 0; i < count; i++)
				{
					Room room2 = GameSettings.Instance.sRoomManager.Rooms[i];
					if (room2.Floor != num2 || !room2.IsSelectable() || (!includeSelected && Selected.Contains(room2)))
					{
						continue;
					}
					float num3 = (room2.Outdoors ? room2.FenceHeight : 2f);
					if (!room2.IsInsideBounds(mouseOnFloor, num * num3))
					{
						continue;
					}
					if (flag2)
					{
						for (int j = 0; j < room2.Edges.Count; j++)
						{
							if (room2.Edges[j].IsBalconyWall(room2))
							{
								continue;
							}
							Vector2 pos = room2.Edges[j].Pos;
							Vector2 pos2 = room2.Edges[(j + 1) % room2.Edges.Count].Pos;
							Vector2 v = pos - pos2;
							Vector3 inNormal = v.Turn90().normalized.ToVector3(0f);
							Plane plane = new Plane(inNormal, pos.ToVector3(0f));
							float enter;
							if ((plane.GetSide(point) && !(room == null)) || !plane.Raycast(mouseRay, out enter))
							{
								continue;
							}
							Vector3 point2 = mouseRay.GetPoint(enter);
							if (!(point2.y >= (float)(room2.Floor * 2)) || !(point2.y <= (float)(room2.Floor * 2) + num3))
							{
								continue;
							}
							Vector2 vector = point2.FlattenVector3();
							float sqrMagnitude = v.sqrMagnitude;
							float sqrMagnitude2 = (vector - pos).sqrMagnitude;
							float sqrMagnitude3 = (vector - pos2).sqrMagnitude;
							if (sqrMagnitude2 <= sqrMagnitude && sqrMagnitude3 <= sqrMagnitude)
							{
								if (!plane.GetSide(point))
								{
									depth = Mathf.Min(depth, enter);
									return room2;
								}
								if (GameSettings.WallsDown == GameSettings.WallState.High)
								{
									depth = Mathf.Min(depth, enter);
									room = room2;
								}
							}
						}
					}
					if (room == null && room2.IsInside(mouseOnFloor) && !room2.IsUpperAtriumNotBalcony)
					{
						depth = Mathf.Min(depth, d);
						room = room2;
					}
				}
			}
			if (room != null)
			{
				return room;
			}
			if (roofs)
			{
				for (int k = 0; k < GameSettings.Instance.sRoomManager.Roofs.Count; k++)
				{
					Roof roof = GameSettings.Instance.sRoomManager.Roofs[k];
					if (roof.IsSelectable() && roof.Floor == num2 && (includeSelected || !Selected.Contains(roof)) && Utilities.IsInside(mouseOnFloor, roof.Area))
					{
						depth = d;
						return roof;
					}
				}
			}
		}
		return null;
	}

	private Vector2 GetMouseOnFloor(Ray mouseRay, int floor, out float d)
	{
		new Plane(Vector3.up, Vector3.up * floor * 2f).Raycast(mouseRay, out d);
		return mouseRay.GetPoint(d).FlattenVector3();
	}

	public void SetSelection(params Selectable[] sel)
	{
		Highligt(false);
		Selected.Clear();
		Selected.AddRange(sel);
		DoPostSelectChecks();
	}

	public void SetSelection(IEnumerable<Selectable> sel)
	{
		Highligt(false);
		Selected.Clear();
		Selected.AddRange(sel);
		DoPostSelectChecks();
	}

	public void DoPostSelectChecks()
	{
		Highligt(true);
		UpdateInfoPanel();
		if (HUD.Instance != null && HUD.Instance.SelectionFilterToggle.isOn)
		{
			HUD.Instance.OnWorkItemToggle(-1);
		}
		MaterialPreviewer.Instance.RefreshState();
		FurnitureInfluenceDrawer.Instance.Disable();
	}

	public void PopulateRightClickMenu()
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (Selectable item in Selected)
		{
			hashSet.AddRange(item.GetActions());
		}
		Dictionary<string, RightClickAction> dictionary = hashSet.ToDictionary((string x) => x, (string x) => RightClickActions[x]);
		if (!GameSettings.Instance.EditMode)
		{
			List<Actor> list = (from x in Selected.OfType<Actor>()
				where x.IsEmployee()
				select x).ToList();
			List<Furniture> fc = (from x in Selected.OfType<Furniture>()
				where x.CanAssign
				select x).ToList();
			if (fc.Count > 0)
			{
				if (list.Count == 1)
				{
					List<Actor> acs1 = list;
					dictionary.Add("Pair", new RightClickAction(ACTCAT.NULL | ACTCAT.FURN | ACTCAT.EMP, "FurniturePlus", ContextButtonGroup.Assign, (Action)delegate
					{
						Actor actor = acs1[0];
						if (actor != null)
						{
							fc.ForEach(delegate(Furniture z)
							{
								z.OwnedBy = actor;
							});
						}
					}));
				}
				else if (list.Count == 0)
				{
					dictionary.Add("PairDirect", new RightClickAction(ACTCAT.NULL | ACTCAT.FURN, "FurniturePlus", ContextButtonGroup.Assign, (Action)delegate
					{
						List<Room> rs = fc.Select((Furniture x) => x.Parent).Distinct().ToList();
						List<Actor> acts = (from x in GameSettings.Instance.sActorManager.Actors
							where rs.Any((Room y) => y.AllowedInRoom(x))
							orderby x.employee.FullName
							select x).ToList();
						WindowManager.Instance.MultiWindow.Show("Assign", acts.Select((Actor z) => z.employee.FullName + " (" + z.employee.RoleString + ")"), delegate(int i)
						{
							fc.ForEach(delegate(Furniture z)
							{
								z.OwnedBy = acts[i];
							});
						}, false);
					}));
				}
			}
			List<Room> fcs = (from x in Selected.OfType<Room>()
				where x.IsPlayerControlled() && !x.Pillar && !x.IsUpperAtrium
				select x).ToList();
			if (fcs.Count > 0)
			{
				if (fcs.Any((Room x) => x.Teams.Count > 0))
				{
					dictionary.Add("AutoAssign", new RightClickAction(ACTCAT.ROOM, "Computer", ContextButtonGroup.Assign, (Action)delegate
					{
						AutoAssignComputers(fcs, false);
					}));
				}
				if (fcs.All((Room x) => x.Teams.Count == 0))
				{
					dictionary.Add("AutoAssign", new RightClickAction(ACTCAT.ROOM, "Computer", ContextButtonGroup.Assign, (Action)delegate
					{
						AutoAssignComputers(fcs, true);
					}));
				}
			}
		}
		foreach (KeyValuePair<string, RightClickAction> action in dictionary)
		{
			if (action.Value.CheckIfShow == null || action.Value.CheckIfShow())
			{
				Action action2 = action.Value.DirectAction ?? ((Action)delegate
				{
					action.Value.GroupAction(GetSelected(action.Key), this);
				});
				RightClickPanel rightClickPanel = rcPanel;
				string description = "Action" + action.Key;
				string icon = action.Value.Icon;
				CounterButton counter = action.Value.Counter;
				ACTCAT category = action.Value.Category;
				ContextButtonGroup order = action.Value.Order;
				Func<Selectable[], bool> func = action.Value.Checked;
				rightClickPanel.AddButton(description, icon, action2, counter, category, order, (func != null) ? new bool?(func(GetSelected(action.Key))) : ((bool?)null));
			}
		}
	}

	public Selectable[] GetSelected(string action)
	{
		return Selected.Where((Selectable x) => x != null && x.gameObject != null && x.GetActions().Contains(action)).ToArray();
	}

	public static string[] FixFurnitureTranslation(WallSnap[] furn)
	{
		HashSet<string> hashSet = new HashSet<string>();
		HashSet<string> hashSet2 = new HashSet<string>();
		HashSet<string> hashSet3 = new HashSet<string>();
		foreach (string item in furn.Select((WallSnap x) => x.name).ToHashSet())
		{
			string[] furniture = Localization.GetFurniture(item, item, null);
			if (furniture.Length > 2 && !string.IsNullOrEmpty(furniture[2]))
			{
				hashSet.Add(furniture[2]);
			}
			if (furniture.Length > 3 && !string.IsNullOrEmpty(furniture[3]))
			{
				hashSet2.Add(furniture[3]);
			}
			if (furniture.Length > 4 && !string.IsNullOrEmpty(furniture[4]))
			{
				hashSet3.Add(furniture[4]);
			}
		}
		return new string[3]
		{
			(hashSet.Count == 1) ? hashSet.First() : "Primary".Loc(),
			(hashSet2.Count == 1) ? hashSet2.First() : "Secondary".Loc(),
			(hashSet3.Count == 1) ? hashSet3.First() : "Tertiary".Loc()
		};
	}

	public void ToggleRightClickMenu(bool enable)
	{
		if (enable)
		{
			PopulateRightClickMenu();
			rcPanel.Activate(Input.mousePosition / Options.UISize);
		}
		else
		{
			rcPanel.Deactivate();
		}
	}

	public void Highligt(bool highligt)
	{
		SecondaryHighlights.RemoveAll((Selectable x) => x == null || x.gameObject == null);
		Selected.RemoveAll((Selectable x) => x == null || x.gameObject == null);
		SecondaryHighlights.ForEachEnum(delegate(Selectable x)
		{
			x.Highlight(false, true);
		});
		SecondaryHighlights.Clear();
		Selected.ForEachEnum(delegate(Selectable x)
		{
			x.Highlight(highligt);
		});
	}

	public string[] GetDescription()
	{
		IEnumerable<Selectable> source = Selected.Where((Selectable x) => x != null && x.gameObject != null);
		return new string[4]
		{
			source.Count((Selectable x) => x.GetComponent<Actor>() != null).ToString(),
			source.Count((Selectable x) => x.GetComponent<Room>() != null).ToString(),
			source.Count((Selectable x) => x.GetComponent<Furniture>() != null).ToString(),
			source.Count((Selectable x) => x.GetComponent<RoomSegment>() != null).ToString()
		};
	}

	public void SaveRoomText()
	{
		Room room = Selected.OfType<Room>().FirstOrDefault();
		if (room != null)
		{
			MiscMsg.SendMsg("RoomTest", room.ConvertToString());
		}
	}

	public void UpdateTeamSelection(bool active)
	{
		if (active)
		{
			HashSet<string> hashSet = new HashSet<string>();
			foreach (Selectable item in Selected)
			{
				if (!(item != null))
				{
					continue;
				}
				Room room = item as Room;
				if (room != null)
				{
					hashSet.AddRange(room.Teams.Select((Team x) => x.Name));
					for (int num = 0; num < room.Occupants.Count; num++)
					{
						Actor actor = room.Occupants[num];
						if (actor.IsEmployee() && actor.Team != null)
						{
							hashSet.Add(actor.Team);
						}
					}
				}
				else
				{
					Actor actor2 = item as Actor;
					if (actor2 != null && actor2.Team != null)
					{
						hashSet.Add(actor2.Team);
					}
				}
			}
			SelectedTeams = hashSet;
		}
		else
		{
			SelectedTeams = null;
		}
	}

	private static void CloneSelectedRooms(Room[] sel, Roof[] sel2)
	{
		int num = sel.Sum((Room x) => x.GetFurnitures().Count);
		if (sel.Length > 10 || num > 100)
		{
			WindowManager.Instance.ShowMessageBox("CloneComplexityWarning".Loc(), false, DialogWindow.DialogType.Warning, delegate
			{
				RoomCloneTool.Instance.Show(sel, sel2);
			}, "Room cloning");
		}
		else
		{
			RoomCloneTool.Instance.Show(sel, sel2);
		}
	}

	public void CloneTool()
	{
		EnableDupeHint = false;
		int num;
		object obj;
		if (HUD.Instance.BuildMode)
		{
			if (!GameSettings.Instance.EditMode)
			{
				num = ((!GameSettings.Instance.RentMode) ? 1 : 0);
				if (num == 0)
				{
					goto IL_0034;
				}
			}
			else
			{
				num = 1;
			}
			obj = (from x in Selected.OfType<Room>()
				where x != null && x.gameObject != null
				select x).ToArray();
			goto IL_006b;
		}
		num = 0;
		goto IL_0034;
		IL_006b:
		Room[] array = (Room[])obj;
		if (num != 0 && array.Length != 0)
		{
			Roof[] sel = (from x in Selected.OfType<Roof>()
				where x != null && x.gameObject != null
				select x).ToArray();
			CloneSelectedRooms(array, sel);
		}
		else
		{
			Furniture[] array2 = Selected.OfType<Furniture>().ToArray();
			if (array2.Length != 0)
			{
				Selectable[] xs = array2;
				DuplicateAction(xs, this);
			}
		}
		EnableDupeHint = true;
		return;
		IL_0034:
		obj = null;
		goto IL_006b;
	}

	public bool MouseOverPixel(Selectable s, Texture2D pixelTex, Camera cam, Material white, Mesh meshCache)
	{
		return true;
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
