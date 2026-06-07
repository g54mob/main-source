using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SINetworking;
using UnityEngine;

public class UndoObject
{
	public class UndoAction
	{
		public enum ActionType
		{
			Nothing = 0,
			DestroyFurniture = 1,
			CreateFurniture = 2,
			FurnitureColor = 3,
			ReplaceFurniture = 4,
			MoveFurniture = 5,
			DestroySegment = 6,
			CreateSegment = 7,
			DestroyRoom = 8,
			CreateRoom = 9,
			MergeRooms = 10,
			SplitRoom = 11,
			RoomColor = 12,
			RoomMaterial = 13,
			ChangeRoad = 14,
			BuyPlot = 15,
			SellPlot = 16,
			RentRoom = 17,
			UnrentRoom = 18,
			CreateLandmark = 19,
			DestroyLandmark = 20,
			AddTrees = 21,
			RemoveTrees = 22,
			DestroyRoof = 23,
			CreateRoof = 24,
			RoofStyle = 25,
			CreatePathObject = 26,
			DestroyPathSegment = 27,
			CreatePathSegment = 28,
			StylePathObject = 29,
			CurveWall = 30,
			TogglePillar = 31,
			MoveWallSnap = 32,
			PartOfGen = 33,
			AtriumConnection = 34,
			CurvedCorner = 35
		}

		public static Dictionary<ActionType, ActionType> LocRedir = new Dictionary<ActionType, ActionType> { 
		{
			ActionType.CurvedCorner,
			ActionType.CurveWall
		} };

		public ActionType Type;

		public WriteDictionary Dictionary = new WriteDictionary();

		public float BalanceDiff;

		public Company.TransactionCategory BalanceCategory;

		public TaxReport.TaxType TaxType;

		public float TaxBalance;

		public bool Taxed = true;

		public string BalanceBill;

		public bool Inventory;

		public bool Hide;

		public ActionType LocType
		{
			get
			{
				return LocRedir.GetOrDefault(Type, Type);
			}
		}

		public int Count()
		{
			switch (Type)
			{
			case ActionType.FurnitureColor:
			case ActionType.DestroyRoom:
			case ActionType.RoomColor:
			case ActionType.RoomMaterial:
			case ActionType.DestroyRoof:
			{
				uint[] array = Dictionary.Get<uint[]>("IDS", null);
				if (array != null)
				{
					return array.Length;
				}
				return 1;
			}
			case ActionType.CreateRoof:
			case ActionType.RoofStyle:
				return Dictionary.Get("Roofs", Array.Empty<WriteDictionary>()).Length;
			case ActionType.CreatePathObject:
				return Dictionary.Get("Paths", Array.Empty<WriteDictionary>()).Length;
			default:
				return 1;
			}
		}

		public override string ToString()
		{
			string text = Type.ToString();
			if (Type == ActionType.CreateFurniture)
			{
				text = text + ": " + ((WriteDictionary)Dictionary["Furn"])["Type"].ToString();
			}
			return text;
		}

		public T Get<T>(string key)
		{
			return Dictionary.Get<T>(key);
		}

		public T Get<T>(string key, T def)
		{
			return Dictionary.Get(key, def);
		}

		public bool Contains(string key)
		{
			return Dictionary.Contains(key);
		}

		private void InitFurn(Furniture furn, bool destroy, bool inventory)
		{
			Inventory = inventory;
			BalanceCategory = Company.TransactionCategory.Construction;
			Taxed = false;
			if (destroy)
			{
				BalanceBill = "Furniture";
				Type = ActionType.DestroyFurniture;
				furn.InitWritable();
				Dictionary["ID"] = furn.DID;
				float num = (BalanceDiff = furn.GetCost());
				if (num > 0f)
				{
					TaxType = TaxReport.TaxType.Depreciation;
					TaxBalance = num - furn.GetSellPrice();
				}
				return;
			}
			BalanceBill = "Recycle";
			Type = ActionType.CreateFurniture;
			if (furn.WallFurn)
			{
				furn.PrepareTempSerialization();
			}
			WriteDictionary writeDictionary = furn.SerializeThis(GameReader.NewLoadMode.Full, false);
			furn.SerializeUndo(writeDictionary);
			Dictionary["Furn"] = writeDictionary;
			BalanceDiff = 0f - furn.GetSellPrice();
			if (furn.Type.Equals("Award"))
			{
				TaxType = TaxReport.TaxType.Income;
				TaxBalance = 0f - furn.GetSellPrice();
			}
		}

		public UndoAction(Furniture furn, bool partOfGen, string ignore)
		{
			Type = ActionType.PartOfGen;
			Dictionary["Furn"] = furn.DID;
			Dictionary["PartOfGen"] = partOfGen;
			Hide = true;
		}

		public UndoAction(Room a, Room b, Vector2 x, Vector2 y, Vector2 corner, float cost)
		{
			Type = ActionType.CurvedCorner;
			Dictionary["aID"] = a.DID;
			Dictionary["bID"] = b.DID;
			Dictionary["x"] = x;
			Dictionary["y"] = y;
			Dictionary["corner"] = corner;
			BalanceCategory = Company.TransactionCategory.Construction;
			BalanceDiff = cost;
		}

		public UndoAction(Furniture furn)
		{
			BalanceCategory = Company.TransactionCategory.Construction;
			BalanceBill = "Furniture";
			Type = ActionType.CreateFurniture;
			Inventory = true;
			if (furn.WallFurn)
			{
				furn.PrepareTempSerialization();
			}
			WriteDictionary writeDictionary = furn.SerializeThis(GameReader.NewLoadMode.Full, false);
			furn.SerializeUndo(writeDictionary);
			Dictionary["Furn"] = writeDictionary;
			if (furn.HasUpg)
			{
				Upgradable.SerializeReset(writeDictionary);
			}
			BalanceDiff = 0f - furn.GetCost();
		}

		public UndoAction(Room r, int atrium = 0)
		{
			Type = ((atrium == 0) ? ActionType.TogglePillar : ActionType.AtriumConnection);
			Dictionary["Room"] = r.DID;
			if (!r.Pillar || Type == ActionType.AtriumConnection)
			{
				Dictionary["DirtSpots2"] = r.Dirts.Select((Room.Dirt x) => new SVector3(x.Pos.x, x.Pos.y, x.Amount, x.Rot)).ToArray();
			}
		}

		private void InitSegment(RoomSegment seg, bool destroy)
		{
			BalanceCategory = Company.TransactionCategory.Construction;
			if (destroy)
			{
				Type = ActionType.DestroySegment;
				seg.InitWritable();
				Dictionary["ID"] = seg.DID;
				RoomSegment segmentComponent = ObjectDatabase.Instance.GetSegmentComponent(seg.name);
				BalanceDiff = seg.Cost * (seg.WallWidth / segmentComponent.WallWidth);
				BalanceBill = "Segment";
			}
			else
			{
				Type = ActionType.CreateSegment;
				seg.PrepareTempSerialization();
				Dictionary["Segment"] = seg.SerializeThis(GameReader.NewLoadMode.Full, false);
				BalanceDiff = 0f;
			}
		}

		public UndoAction(bool style, params PathObject[] paths)
		{
			if (style)
			{
				Type = ActionType.StylePathObject;
				Dictionary["Paths"] = paths;
				Dictionary["Colors"] = paths.SelectInPlace((PathObject x) => x.MatColor);
				Dictionary["Colors2"] = paths.SelectInPlace((PathObject x) => x.MatColor2);
				Dictionary["Materials"] = paths.SelectInPlace((PathObject x) => x.Material);
			}
			else
			{
				Type = ActionType.CreatePathObject;
				Dictionary["Paths"] = paths.SelectInPlace((PathObject x) => GameSettings.Instance.sRoomManager.PathController.Serialize(new WriteDictionary(), x.Path.ToList()));
			}
		}

		public UndoAction(Room r1, Room r2, WallEdge e1, WallEdge e2, bool reverse, float cost, Vector2? corner = null)
		{
			Type = ActionType.CurveWall;
			Dictionary["r1"] = r1.DID;
			if (r2 != null)
			{
				Dictionary["r2"] = r2.DID;
			}
			Dictionary["reverse"] = reverse;
			Dictionary["e1"] = e1.Pos;
			Dictionary["e2"] = e2.Pos;
			Dictionary["corner"] = corner;
			BalanceDiff = cost;
			BalanceCategory = Company.TransactionCategory.Construction;
			BalanceBill = "Room";
		}

		public UndoAction(float cost, IList<PathController.PathPoint> paths, PathController.PathPoint shortA, PathController.PathPoint shortB)
		{
			Type = ActionType.DestroyPathSegment;
			Dictionary["Paths"] = paths.SelectInPlace((PathController.PathPoint x) => x.ID);
			if (shortA != null)
			{
				Dictionary["ShortAID"] = shortA.ID;
				Dictionary["ShortAPos"] = shortA.Point;
				Dictionary["ShortABez"] = shortA.Bezier;
			}
			if (shortB != null)
			{
				Dictionary["ShortBID"] = shortB.ID;
				Dictionary["ShortBPos"] = shortB.Point;
				Dictionary["ShortBBez"] = shortB.Bezier;
			}
			BalanceCategory = Company.TransactionCategory.Construction;
			BalanceBill = "Path";
			BalanceDiff = cost;
		}

		public UndoAction(HashSet<PathController.PathPoint> p)
		{
			Type = ActionType.CreatePathSegment;
			PathController.PathPoint[] array = GameSettings.Instance.sRoomManager.PathController.OrderByEnds(p);
			Dictionary["Points"] = array.SelectInPlace((PathController.PathPoint x) => x.Point);
			Dictionary["IDs"] = array.SelectInPlace((PathController.PathPoint x) => x.ID);
			Dictionary["Bezier"] = array.Mode((PathController.PathPoint x) => x.Bezier);
			PathController.PathPoint pathPoint = array.First();
			Dictionary["Color"] = pathPoint.Color;
			Dictionary["Material"] = pathPoint.Material;
		}

		public UndoAction(bool destroy, params Roof[] roof)
		{
			if (destroy)
			{
				Type = ActionType.DestroyRoof;
				Dictionary["IDS"] = roof.SelectInPlace((Roof x) => x.DID);
			}
			else
			{
				Type = ActionType.CreateRoof;
				Dictionary["Roofs"] = roof.SelectInPlace((Roof x) => x.SerializeThis(GameReader.NewLoadMode.Full, false));
			}
		}

		public UndoAction(List<Roof> roofs)
		{
			Type = ActionType.RoofStyle;
			Dictionary["Roofs"] = roofs.SelectInPlace((Roof x) => x.SerializeThis(GameReader.NewLoadMode.Full, false));
		}

		public UndoAction(WriteDictionary oldFurn, Furniture newFurn, float diff, bool inventory)
		{
			Type = ActionType.ReplaceFurniture;
			Dictionary["Furn"] = oldFurn;
			newFurn.InitWritable();
			Dictionary["ID"] = newFurn.DID;
			Inventory = inventory;
			BalanceDiff = diff;
			BalanceCategory = Company.TransactionCategory.Construction;
			BalanceBill = "Furniture";
		}

		public UndoAction(WallSnap[] furns, bool atlas = false, bool both = false)
		{
			Type = ActionType.FurnitureColor;
			int[] array = null;
			string[] array2 = null;
			string[] array3 = null;
			Color[,] array4 = null;
			if (atlas || both)
			{
				array = new int[furns.Length];
				array2 = new string[furns.Length];
				array3 = new string[furns.Length];
			}
			if (!atlas || both)
			{
				array4 = new Color[furns.Length, 3];
			}
			uint[] array5 = new uint[furns.Length];
			for (int i = 0; i < furns.Length; i++)
			{
				WallSnap wallSnap = furns[i];
				array5[i] = wallSnap.DID;
				if (atlas || both)
				{
					array[i] = wallSnap.AtlasIndex;
					array2[i] = wallSnap.GetReplacement(0);
					array3[i] = wallSnap.GetReplacement(1);
				}
				if (!atlas || both)
				{
					array4[i, 0] = wallSnap.ActualColorPrimary;
					array4[i, 1] = wallSnap.ActualColorSecondary;
					array4[i, 2] = wallSnap.ActualColorTertiary;
				}
			}
			Dictionary["IDS"] = array5;
			if (atlas || both)
			{
				Dictionary["Atlas"] = array;
				Dictionary["Replacement1"] = array2;
				Dictionary["Replacement2"] = array3;
			}
			if (!atlas || both)
			{
				Dictionary["Colors"] = array4;
			}
		}

		public UndoAction(List<Room> rooms, bool mat, bool both = false, bool offsets = false)
		{
			Type = (mat ? ActionType.RoomMaterial : ActionType.RoomColor);
			string[,] array = null;
			Color[,] array2 = null;
			SVector3[] array3 = null;
			if (mat)
			{
				array = new string[rooms.Count, 4];
			}
			if (both || !mat)
			{
				array2 = new Color[rooms.Count, 7];
			}
			if (offsets)
			{
				array3 = new SVector3[rooms.Count];
			}
			uint[] array4 = new uint[rooms.Count];
			for (int i = 0; i < rooms.Count; i++)
			{
				Room room = rooms[i];
				array4[i] = room.DID;
				if (mat)
				{
					array[i, 0] = room.FloorMat;
					array[i, 1] = room.InsideMat;
					array[i, 2] = room.OutsideMat;
					array[i, 3] = room.FenceStyle;
				}
				if (both || !mat)
				{
					array2[i, 0] = room.FloorColor;
					array2[i, 1] = room.FloorColor2;
					array2[i, 2] = room.InsideColor;
					array2[i, 3] = room.InsideColor2;
					array2[i, 4] = room.OutsideColor;
					array2[i, 5] = room.OutsideColor2;
					array2[i, 6] = room.FenceColor;
				}
				if (offsets)
				{
					array3[i] = new SVector3(room.FloorOffset.x, room.FloorOffset.y, room.FloorRotation, room.FloorScale);
				}
			}
			Dictionary["Mats"] = array;
			Dictionary["Colors"] = array2;
			Dictionary["IDS"] = array4;
			Dictionary["Offsets"] = array3;
		}

		public UndoAction(WallSnap snap, bool destroy, bool inventory = false)
		{
			RoomSegment seg;
			Furniture furn;
			if (snap == null || snap.gameObject == null)
			{
				Type = ActionType.Nothing;
			}
			else if ((object)(seg = snap as RoomSegment) != null)
			{
				InitSegment(seg, destroy);
			}
			else if ((object)(furn = snap as Furniture) != null)
			{
				InitFurn(furn, destroy, inventory);
			}
		}

		public UndoAction(Furniture furn, Room room, Vector3 pos, Quaternion rot, float localRot, SnapPoint point)
		{
			Type = ActionType.MoveFurniture;
			Dictionary["IDS"] = new uint[2] { furn.DID, room.DID };
			BalanceDiff = 0f;
			Dictionary["Pos"] = pos;
			Dictionary["Rot"] = rot;
			Dictionary["LocalRot"] = localRot;
			if (furn.WallFurn)
			{
				WallEdge firstEdge = furn.FirstEdge;
				WallEdge secondEdge = furn.SecondEdge;
				Dictionary["Edge1"] = room.Edges.FindIndex(firstEdge);
				Dictionary["Edge2"] = room.Edges.FindIndex(secondEdge);
				Dictionary["WallPos"] = furn.WallPosition[firstEdge] / (firstEdge.Pos - secondEdge.Pos).magnitude;
				Dictionary["IsReversed"] = furn.IsReversed;
			}
			if (point != null)
			{
				Dictionary["Snap"] = point.Parent.DID;
				Dictionary["SnapID"] = point.Parent.SnapPoints.FindIndex(point);
			}
		}

		public UndoAction(WallSnap snap)
		{
			Type = ActionType.MoveWallSnap;
			Room parentRoom = snap.GetParentRoom(true);
			if (parentRoom == null)
			{
				parentRoom = snap.GetParentRoom(false);
			}
			Dictionary["IDS"] = new uint[2] { snap.DID, parentRoom.DID };
			BalanceDiff = 0f;
			Dictionary["Edge1"] = snap.FirstEdge.Pos;
			Dictionary["Edge2"] = snap.SecondEdge.Pos;
			Dictionary["WallPos"] = snap.WallPosition[snap.FirstEdge] / (snap.FirstEdge.Pos - snap.SecondEdge.Pos).magnitude;
			Dictionary["IsReversed"] = snap.IsReversed;
		}

		public UndoAction(Room room, bool destroy, float cost)
		{
			BalanceCategory = Company.TransactionCategory.Construction;
			if (destroy)
			{
				BalanceBill = "Room";
				Type = ActionType.DestroyRoom;
				Dictionary["IDS"] = new uint[1] { room.DID };
			}
			else
			{
				Type = ActionType.CreateRoom;
				Dictionary["Build"] = BuildingPrefab.SaveRooms(new Room[1] { room }, Array.Empty<Roof>(), false, true, false, true, false, true);
				Dictionary["ID"] = room.DID;
			}
			BalanceDiff = cost;
		}

		public UndoAction(Room[] rooms, float balance)
		{
			BalanceCategory = Company.TransactionCategory.Construction;
			Type = ActionType.DestroyRoom;
			Dictionary["IDS"] = rooms.Select((Room x) => x.DID).ToArray();
			BalanceDiff = balance;
		}

		public UndoAction(int x, int y, int floor, int w, int h, float balance)
		{
			Type = ActionType.ChangeRoad;
			BalanceCategory = Company.TransactionCategory.Construction;
			BalanceBill = "Road";
			BalanceDiff = balance;
			byte[,] array = new byte[w, h];
			Dictionary["Point"] = new Vector2Int(x, y);
			Dictionary["Floor"] = floor;
			for (int i = 0; i < w; i++)
			{
				for (int j = 0; j < h; j++)
				{
					int fromFloor;
					byte road = RoadManager.Instance.GetRoad(x + i, y + j, floor, out fromFloor);
					array[i, j] = (byte)((fromFloor == floor) ? road : 0);
				}
			}
			Dictionary["RoadSegments"] = array;
		}

		public UndoAction(Room r1, Room r2, float balance, bool reverse = false)
		{
			Type = ActionType.MergeRooms;
			BalanceCategory = Company.TransactionCategory.Construction;
			BalanceBill = "Room";
			BalanceDiff = balance;
			Dictionary["Reverse"] = reverse;
			Dictionary["IDS"] = new uint[2] { r1.DID, r2.DID };
		}

		public UndoAction(Room r1, Room r2, List<Vector2> split, bool upperAtriumMerge = false)
		{
			Type = ActionType.SplitRoom;
			Dictionary["ID"] = r1.DID;
			BalanceCategory = Company.TransactionCategory.Construction;
			BalanceBill = "Room";
			Dictionary["Points"] = split;
			BalanceDiff = 0f;
			Dictionary["Room"] = r2.SerializeThis(GameReader.NewLoadMode.Full, false);
			Dictionary["UpperAtriumMerge"] = upperAtriumMerge;
			Dictionary["AtriumChildren"] = (r2.IsUpperAtriumNotBalcony ? r2.AtriumChildren.SelectInPlace((Room x) => x.DID) : new uint[0]);
		}

		public UndoAction(PlotArea area, float upFront)
		{
			Type = ActionType.BuyPlot;
			Dictionary["MonthsLeft"] = area.MonthsLeft;
			Dictionary["Monthly"] = area.Monthly;
			Dictionary["UpFront"] = upFront;
			Dictionary["Plot"] = area;
		}

		public UndoAction(PlotArea area, float upFront, float addonCost)
		{
			Type = ActionType.SellPlot;
			Dictionary["Plot"] = area;
			Dictionary["AddonCost"] = addonCost;
			Dictionary["UpFront"] = upFront;
		}

		public UndoAction(Room r, bool rent, bool atrium = false)
		{
			Type = (rent ? ActionType.RentRoom : ActionType.UnrentRoom);
			Dictionary["ID"] = r.DID;
		}

		public UndoAction(Landmark mark, bool create)
		{
			Type = (create ? ActionType.CreateLandmark : ActionType.DestroyLandmark);
			if (create)
			{
				Dictionary["Landmark"] = mark.SerializeThis(GameReader.NewLoadMode.Full, false);
			}
			else
			{
				Dictionary["Landmark"] = mark.DID;
			}
		}

		public UndoAction(TreeInstance[] trees, bool add)
		{
			Type = (add ? ActionType.AddTrees : ActionType.RemoveTrees);
			Dictionary["Trees"] = trees;
			Hide = true;
		}
	}

	public static List<Writeable> NeedsPostDeserialization = new List<Writeable>();

	public static bool RefreshSelectionState = false;

	public UndoAction[] Actions;

	public string Description;

	private static HashSet<uint> _furnIds = new HashSet<uint>();

	public UndoObject(params UndoAction[] actions)
	{
		Actions = actions;
		MakeDescription();
	}

	public UndoObject(params UndoAction[][] actions)
	{
		Actions = actions.SelectMany((UndoAction[] x) => x).ToArray();
		MakeDescription();
	}

	private void MakeDescription()
	{
		Description = string.Join("\n", from x in Actions
			where !x.Hide
			group x by x.LocType into x
			select ("Undo" + x.Key).Loc(x.Sum((UndoAction z) => z.Count())));
	}

	private static bool PartOfGen(UndoAction action)
	{
		Furniture furniture = GameSettings.Instance.sRoomManager.AllFurniture.FirstOrDefault((Furniture x) => x.DID == action.Get<uint>("Furn"));
		if (furniture != null)
		{
			furniture.PartOfGen = action.Get("PartOfGen", false);
			return true;
		}
		return false;
	}

	private static bool DestroyFurniture(UndoAction action)
	{
		Furniture furniture = GameSettings.Instance.sRoomManager.AllFurniture.FirstOrDefault((Furniture x) => x.DID == action.Get<uint>("ID"));
		if (furniture != null)
		{
			if (SelectorController.Instance.Selected.Remove(furniture))
			{
				RefreshSelectionState = true;
			}
			furniture.Undo = true;
			if (action.Inventory)
			{
				action.BalanceDiff = 0f;
				GameSettings.AddToInventory(furniture);
			}
			furniture.DestroyGO();
			return true;
		}
		return false;
	}

	private static bool CreateFurniture(UndoAction action)
	{
		WriteDictionary writeDictionary = action.Get<WriteDictionary>("Furn");
		string text = writeDictionary["Type"].ToString();
		Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(text);
		if (action.Inventory)
		{
			if (furnitureComponent.Type.Equals("Award"))
			{
				AwardTrophy component = furnitureComponent.GetComponent<AwardTrophy>();
				if (component != null)
				{
					GameSettings.Instance.RemoveAward(component.Type, writeDictionary.Get("AwardTier", AwardTrophy.AwardTier.Platinum), writeDictionary.Get("AwardYear", 0));
					action.BalanceDiff = 0f;
				}
			}
			else
			{
				uint num = writeDictionary.Get("WriteID", 0u);
				if (num != 0 && GameSettings.FetchFromInventory(text, num) != null)
				{
					action.BalanceDiff = 0f;
				}
			}
		}
		if (furnitureComponent != null)
		{
			Furniture furniture = UnityEngine.Object.Instantiate(furnitureComponent);
			furniture.name = furnitureComponent.name;
			furniture.DeserializeClone = true;
			if (furniture.DeserializeThis(writeDictionary, false) != null)
			{
				if (furniture.Offshore || !string.IsNullOrEmpty(furniture.MetalMarket))
				{
					GameSettings.Instance.OffshoreAccount += action.BalanceDiff;
					action.BalanceDiff = 0f;
					action.TaxBalance = 0f;
				}
				if (furniture.Pallet != null)
				{
					furniture.Pallet.FixStorage();
				}
				furniture.UpdateFreeNavs();
				NeedsPostDeserialization.Add(furniture);
				if (!furniture.isTemporary)
				{
					furniture.gameObject.SetActive(true);
					if (furniture.TwoFloors)
					{
						GameSettings.Instance.sRoomManager.AllFurniture.Add(furniture);
						if (furniture.ExtraParent != null)
						{
							furniture.ExtraParent.DirtyNavMesh = true;
							furniture.ExtraParent.DirtyPathNodes = true;
							furniture.ExtraParent.DirtyFloorMesh |= furniture.TwoFloors && furniture.MakeHole;
						}
						else if (furniture.Floor < 0)
						{
							TimeOfDay.Instance.GroundTopDirty |= furniture.TwoFloors && furniture.MakeHole;
						}
						furniture.Parent.DirtyRoofMesh |= furniture.TwoFloors && furniture.MakeHole;
					}
					if (furniture.PokesThroughRoof && furniture.Parent.Floor == -1)
					{
						GrassSystem.Instance.InvalidateArea();
					}
					if (furniture.Table != null)
					{
						furniture.Table.Init();
					}
					if (furniture.NetworkID != 0)
					{
						furniture.SendNetwork();
					}
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private static bool MoveFurniture(UndoAction action)
	{
		uint[] ids = action.Get<uint[]>("IDS");
		Furniture furniture = GameSettings.Instance.sRoomManager.AllFurniture.FirstOrDefault((Furniture x) => x.DID == ids[0]);
		Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == ids[1]);
		if (furniture != null && (room != null || furniture.ValidOutside))
		{
			room = room ?? GameSettings.Instance.sRoomManager.Outside;
			int num = action.Get("Edge1", -1);
			int num2 = action.Get("Edge2", -1);
			if (!furniture.WallFurn || (num >= 0 && num2 >= 0))
			{
				WallEdge wallEdge = (furniture.WallFurn ? room.Edges[num] : null);
				WallEdge wallEdge2 = (furniture.WallFurn ? room.Edges[num2] : null);
				SnapPoint snap = null;
				if (furniture.IsSnapping)
				{
					uint pid = action.Get("Snap", 0u);
					if (pid == 0)
					{
						return false;
					}
					Furniture furniture2 = GameSettings.Instance.sRoomManager.AllFurniture.FirstOrDefault((Furniture x) => x.DID == pid);
					if (!(furniture2 != null))
					{
						return false;
					}
					snap = furniture2.SnapPoints[action.Get<int>("SnapID")];
				}
				float wallPos = action.Get("WallPos", 0f);
				FurnitureBuilder.MoveFurn(action.Get<Vector3>("Pos"), action.Get<Quaternion>("Rot"), room, wallEdge, wallEdge2, wallPos, action.Get("IsReversed", false), snap, furniture.gameObject, action.Get<float>("LocalRot"));
				FurnitureBuilder.TraverseMove(furniture, room, wallEdge, wallEdge2, wallPos, null);
			}
		}
		return false;
	}

	private static bool MoveWallSnap(UndoAction action)
	{
		uint[] ids = action.Get<uint[]>("IDS");
		WallSnap wallSnap = GameSettings.Instance.sRoomManager.AllFurniture.FirstOrDefault((Furniture x) => x.DID == ids[0]);
		if (wallSnap == null)
		{
			wallSnap = GameSettings.Instance.sRoomManager.RoomSegments.FirstOrDefault((RoomSegment x) => x.DID == ids[0]);
		}
		Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == ids[1]);
		if (wallSnap != null && room != null)
		{
			Room parentRoom = wallSnap.GetParentRoom(true);
			if (parentRoom != null)
			{
				parentRoom.DirtyInnerMesh = true;
			}
			parentRoom = wallSnap.GetParentRoom(false);
			if (parentRoom != null)
			{
				parentRoom.DirtyInnerMesh = true;
			}
			WallEdge wallEdge = room.Edges.FirstOrDefault((WallEdge x) => x.Pos == action.Get("Edge1", Vector2.zero));
			WallEdge wallEdge2 = room.Edges.FirstOrDefault((WallEdge x) => x.Pos == action.Get("Edge2", Vector2.zero));
			if (wallEdge != null && wallEdge2 != null)
			{
				float pos = action.Get("WallPos", 0f);
				wallSnap.IsReversed = action.Get("IsReversed", false);
				wallSnap.Init(wallEdge, wallEdge2, pos);
				Furniture furniture;
				if ((object)(furniture = wallSnap as Furniture) != null)
				{
					furniture.OriginalPosition = furniture.transform.position;
					furniture.UpdateBoundaryPoints();
					FurnitureBuilder.TraverseMove(furniture, furniture.Parent, null, null, 0f, null);
				}
			}
			return true;
		}
		return false;
	}

	private static bool TogglePillar(UndoAction action)
	{
		uint rID = action.Dictionary.Get("Room", 0u);
		Room room = ((rID == 0) ? null : GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == rID));
		if (room != null)
		{
			room.TogglePillar(false);
			List<Room.Dirt> list = action.Dictionary.Get<List<Room.Dirt>>("DirtSpots3", null);
			if (list != null)
			{
				for (int num = 0; num < list.Count; num++)
				{
					Room.Dirt dirt = list[num];
					if (room.RoomBounds.Contains(dirt.Pos))
					{
						room.AddNewDirt(dirt.Pos, dirt.Amount, dirt.Type, dirt.Rot);
					}
				}
			}
			return true;
		}
		return false;
	}

	private static bool AtriumConnection(UndoAction action)
	{
		uint rID = action.Dictionary.Get("Room", 0u);
		Room room = ((rID == 0) ? null : GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == rID));
		if (room != null)
		{
			room.AtriumParent.AtriumChildren.Remove(room);
			room.AtriumParent.UpdateAtriumNetwork();
			room.AtriumParent.RecalculateStateVariables(true);
			foreach (Room atriumChild in room.AtriumParent.GetAtriumChildren())
			{
				if (atriumChild.IsAliveNotNull())
				{
					atriumChild.DirtyRoofMesh = true;
				}
				atriumChild.UpdateParentOfFurniture();
			}
			if (room.AtriumParent.AtriumChildren.Count == 0)
			{
				room.AtriumParent.AtriumParent = null;
				room.AtriumParent.RefreshTextureTiling();
			}
			room.AtriumParent.UpdateParentOfFurniture();
			room.AtriumParent.DirtyRoofMesh = true;
			room.AtriumParent = null;
			room.DirtyFloorMesh = true;
			room.DirtyRoofMesh = true;
			room.DirtyInnerMesh = true;
			room.UpdateParentOfFurniture();
			List<Room.Dirt> list = action.Dictionary.Get<List<Room.Dirt>>("DirtSpots3", null);
			if (list != null)
			{
				for (int num = 0; num < list.Count; num++)
				{
					Room.Dirt dirt = list[num];
					if (room.RoomBounds.Contains(dirt.Pos))
					{
						room.AddNewDirt(dirt.Pos, dirt.Amount, dirt.Type, dirt.Rot);
					}
				}
			}
			return true;
		}
		return false;
	}

	private static bool RemoveEdgesBetween(Room r, WallEdge a, WallEdge b)
	{
		HashSet<WallEdge> hashSet = new HashSet<WallEdge>();
		for (WallEdge wallEdge = a.Links[r]; wallEdge != b; wallEdge = wallEdge.Links[r])
		{
			if (!hashSet.Add(wallEdge))
			{
				return false;
			}
		}
		foreach (WallEdge item in hashSet)
		{
			GameSettings.Instance.sRoomManager.AllSegments.Remove(item);
			r.Edges.Remove(item);
		}
		return true;
	}

	private static void PerformRoomRefresh(Room r)
	{
		r.OptimizeSegments();
		r.UpdateBounds(false);
		r.DirtyOuterMesh = true;
		r.DirtyInnerMesh = true;
		r.DirtyNavMesh = true;
		r.DirtyPathNodes = true;
		r.Area = Utilities.PolygonArea(r.Edges);
		r.QueueEdgeNetworkUpdate();
	}

	private static bool CurvedCorner(UndoAction action)
	{
		Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == action.Get<uint>("aID"));
		Room room2 = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == action.Get<uint>("bID"));
		Vector2 xPos = action.Get<Vector2>("x");
		Vector2 yPos = action.Get<Vector2>("y");
		WallEdge wallEdge = room.Edges.FirstOrDefault((WallEdge x) => (x.Pos - xPos).magnitude < 0.0001f);
		WallEdge wallEdge2 = room.Edges.FirstOrDefault((WallEdge x) => (x.Pos - yPos).magnitude < 0.0001f);
		if (wallEdge == null || wallEdge2 == null)
		{
			return false;
		}
		WallEdge wallEdge3 = new WallEdge(action.Get<Vector2>("corner"), room.Floor);
		GameSettings.Instance.sRoomManager.AllSegments.Add(wallEdge3);
		if (!RemoveEdgesBetween(room, wallEdge, wallEdge2))
		{
			return false;
		}
		wallEdge.Links[room] = wallEdge3;
		wallEdge3.Links[room] = wallEdge2;
		room.Edges.Insert(room.Edges.IndexOf(wallEdge) + 1, wallEdge3);
		PerformRoomRefresh(room);
		if (!RemoveEdgesBetween(room2, wallEdge2, wallEdge))
		{
			return false;
		}
		wallEdge2.Links[room2] = wallEdge3;
		wallEdge3.Links[room2] = wallEdge;
		room2.Edges.Insert(room2.Edges.IndexOf(wallEdge), wallEdge3);
		PerformRoomRefresh(room2);
		return true;
	}

	private static bool ReplaceFurniture(UndoAction action)
	{
		uint id = action.Get<uint>("ID");
		Furniture furniture = GameSettings.Instance.sRoomManager.AllFurniture.FirstOrDefault((Furniture x) => x.DID == id);
		if (furniture != null)
		{
			WriteDictionary writeDictionary = action.Get<WriteDictionary>("Furn");
			furniture.Undo = true;
			if (action.Inventory)
			{
				GameSettings.AddToInventory(furniture);
			}
			Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(writeDictionary["Type"].ToString());
			Furniture furniture2 = FurnitureReplaceWindow.UpgradeFurniture(furniture, furnitureComponent);
			furniture2.name = furnitureComponent.name;
			furniture2.DeserializeThis(writeDictionary, false);
			NeedsPostDeserialization.Add(furniture2);
			if (!furniture2.isTemporary)
			{
				furniture2.gameObject.SetActive(true);
			}
			return true;
		}
		return false;
	}

	private static bool DestroySegment(UndoAction action)
	{
		uint id = action.Get<uint>("ID");
		RoomSegment roomSegment = GameSettings.Instance.sRoomManager.RoomSegments.FirstOrDefault((RoomSegment x) => x.DID == id);
		if (roomSegment != null)
		{
			if (SelectorController.Instance.Selected.Remove(roomSegment))
			{
				RefreshSelectionState = true;
			}
			roomSegment.DestroyGO();
			return true;
		}
		return false;
	}

	private static bool CreateSegment(UndoAction action)
	{
		WriteDictionary segD = action.Get<WriteDictionary>("Segment");
		GameObject gameObject = ObjectDatabase.Instance.RoomSegments.FirstOrDefault((GameObject x) => x.name.Equals(segD["Type"].ToString()));
		if (gameObject != null)
		{
			RoomSegment component = UnityEngine.Object.Instantiate(gameObject).GetComponent<RoomSegment>();
			component.name = gameObject.name;
			component.DeserializeClone = true;
			component.DeserializeThis(segD, false);
			if (component.IsAliveNotNull())
			{
				NeedsPostDeserialization.Add(component);
				component.gameObject.SetActive(true);
			}
			return true;
		}
		return false;
	}

	private static bool DestroyRoom(UndoAction action)
	{
		uint[] ids = action.Get<uint[]>("IDS");
		int i;
		for (i = 0; i < ids.Length; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == ids[i]);
			if (room != null)
			{
				room.Destroyed = true;
				room.GetFurnitures().ForEach(delegate(Furniture x)
				{
					x.Undo = true;
				});
				if (SelectorController.Instance.Selected.Remove(room))
				{
					RefreshSelectionState = true;
				}
				GameSettings.Instance.sRoomManager.RemoveRoom(room);
				room.DestroyGO();
			}
			else if (ids.Length == 1)
			{
				return false;
			}
		}
		return true;
	}

	private static bool CreateRoom(UndoAction action)
	{
		RoomCloneTool.Instance.SetOptions(null, true, RoomCloneTool.GroupOption.Copy, null, false);
		List<KeyValuePair<Room, BuildingPrefab.RoomObject>> list = RoomCloneTool.Instance.BuildPrefab(action.Get<BuildingPrefab>("Build"), 0, true, false, false, false, new uint[1] { action.Get<uint>("ID") }, false, true, true);
		for (int i = 0; i < list.Count; i++)
		{
			KeyValuePair<Room, BuildingPrefab.RoomObject> keyValuePair = list[i];
			ReparentAtrium(keyValuePair.Key, keyValuePair.Value.RoomData.Get("AtriumParent", 0u));
		}
		NeedsPostDeserialization.AddRange(list.Select((KeyValuePair<Room, BuildingPrefab.RoomObject> x) => x.Key));
		return true;
	}

	private static void ReparentAtrium(Room r, uint pid)
	{
		if (pid == 0)
		{
			return;
		}
		if (pid == r.DID)
		{
			r.AtriumParent = r;
			return;
		}
		Room room = (r.AtriumParent = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == pid));
		if (room.AtriumParent == null)
		{
			room.AtriumParent = room;
		}
		if (room.AtriumChildren.Count > 0)
		{
			Room room2 = room.AtriumChildren.Last();
			room2.DirtyRoofMesh = true;
			room2.AtriumChildren.ForEach(delegate(Room x)
			{
				x.DirtyRoofMesh = true;
			});
		}
		else
		{
			room.DirtyRoofMesh = true;
		}
		if (!room.AtriumChildren.Contains(r))
		{
			room.AtriumChildren.Add(r);
			room.UpdateAtriumNetwork();
		}
		Room mainAtriumParent = room.GetMainAtriumParent();
		if (mainAtriumParent.IsAliveNotNull())
		{
			mainAtriumParent.UpdateParentOfFurniture();
			mainAtriumParent.GetAtriumChildren().ForEachEnum(delegate(Room x)
			{
				x.UpdateParentOfFurniture();
			});
			mainAtriumParent.RecalculateStateVariables(true);
		}
	}

	private static bool MergeRooms(UndoAction action)
	{
		uint[] ids = action.Get<uint[]>("IDS");
		Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == ids[0]);
		Room room2 = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == ids[1]);
		bool flag = action.Get("Reverse", false) || room.AtriumParent == room2;
		if (flag && room2.AtriumParent == room)
		{
			flag = false;
		}
		if (flag)
		{
			Room room3 = room;
			room = room2;
			room2 = room3;
		}
		if (room != null && room2 != null)
		{
			if (!room.TryFixEdges() || !room2.TryFixEdges())
			{
				return false;
			}
			room.OptimizeSegments();
			room2.OptimizeSegments();
			if (room.CanMerge(room2))
			{
				room.MergeWith(room2, null, null);
				if (flag)
				{
					room.DID = ids[0];
					Writeable.DeserializedObjects.Remove(ids[1]);
					Writeable.DeserializedObjects[ids[0]] = room;
				}
			}
			return true;
		}
		return false;
	}

	private static bool SplitRoom(UndoAction action)
	{
		uint id = action.Get<uint>("ID");
		List<Vector2> list = action.Get<List<Vector2>>("Points");
		bool flag = action.Get("UpperAtriumMerge", false);
		Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == id);
		if (room != null)
		{
			List<WallEdge> list2 = new List<WallEdge>();
			for (int num = 0; num < list.Count; num++)
			{
				Vector2 vector = list[num];
				WallEdge wallEdge = null;
				if (num == 0 || num == list.Count - 1)
				{
					foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(room.Floor))
					{
						if ((item.Pos - vector).magnitude < BuildController.GetSnapDistance(true))
						{
							wallEdge = item;
							break;
						}
					}
					if (wallEdge == null)
					{
						foreach (WallEdge item2 in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(room.Floor))
						{
							foreach (KeyValuePair<IRoom, WallEdge> link in item2.Links)
							{
								Vector2 res;
								if (Utilities.ProjectToLine(vector, item2.Pos, link.Value.Pos, out res) && (res - vector).magnitude < BuildController.GetSnapDistance(true))
								{
									wallEdge = new WallEdge(res, room.Floor);
									wallEdge.SetSplit(item2, (Room)link.Key);
									break;
								}
							}
						}
					}
				}
				if (wallEdge == null)
				{
					wallEdge = new WallEdge(vector, room.Floor);
				}
				list2.Add(wallEdge);
			}
			Dictionary<WallSnap, UndoAction> snaps = room.PrepareSplit(false);
			BuildController.Instance.CurrentSegments = list2;
			BuildController.Instance.FinalizeCuts(true, room.Floor, null, true);
			BuildController.Instance.CurrentSegments = null;
			GameSettings.Instance.sRoomManager.AllSegments.AddRange(list2);
			WriteDictionary writeDictionary = action.Get<WriteDictionary>("Room");
			uint num2 = writeDictionary.Get("AtriumParent", 0u);
			Room room2 = room.Split(list2, null, snaps, null, false, writeDictionary, num2 != 0, !flag, true);
			if (room2 != null)
			{
				uint[] children = action.Get<uint[]>("AtriumChildren");
				int i;
				for (i = 0; i < children.Length; i++)
				{
					Room room3 = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == children[i]);
					if (room3 != null)
					{
						if (room3.AtriumParent != null)
						{
							room3.AtriumParent.AtriumChildren.Remove(room3);
						}
						room3.AtriumParent = room2;
						room3.RefreshBalconyLook();
						room2.AtriumChildren.Add(room3);
						room2.UpdateAtriumNetwork();
					}
				}
				ReparentAtrium(room2, num2);
				GameSettings.Instance.sRoomManager.AddRoom(room2);
				foreach (Furniture item3 in room.GetFurnitures().ToList())
				{
					item3.UpdateParent(true, false);
				}
				if (room2.Outdoors != room2.Outdoors)
				{
					room2.DirtyOuterMesh = true;
					room2.DirtyInnerMesh = true;
					room2.DirtyFloorMesh = true;
					room2.DirtyRoofMesh = true;
				}
				RoomGroup roomGroup = GameSettings.Instance.GetRoomGroup(room2.RoomGroup);
				if (roomGroup != null)
				{
					roomGroup.AddRoom(room2);
				}
				if (room2.AtriumParent != null)
				{
					room2.AtriumParent.AtriumChildren.Sort((Room x, Room y) => x.Floor.CompareTo(y.Floor));
				}
				room2.RecalculateTableGroupsNow();
				room.RecalculateTableGroupsNow();
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool DestroyRoof(UndoAction action)
	{
		uint[] array = action.Get("IDS", new uint[0]);
		foreach (uint id in array)
		{
			Roof roof = GameSettings.Instance.sRoomManager.Roofs.FirstOrDefault((Roof x) => x.DID == id);
			if (roof != null)
			{
				if (SelectorController.Instance.Selected.Remove(roof))
				{
					RefreshSelectionState = true;
				}
				roof.DestroyGO();
			}
		}
		return true;
	}

	private static bool CreateRoof(UndoAction action)
	{
		WriteDictionary[] array = action.Get("Roofs", new WriteDictionary[0]);
		for (int i = 0; i < array.Length; i++)
		{
			Roof roof = UnityEngine.Object.Instantiate(HUD.Instance.roofEditWindow.RoofPrefab);
			roof.DeserializeThis(array[i], false);
			roof.PostDeserialize();
			NetworkMessaging.SendNewRoom(BuildingPrefab.SaveRoomsForNetwork(Array.Empty<Room>(), new Roof[1] { roof }, false), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		return true;
	}

	private static bool CreatePathObject(UndoAction action)
	{
		WriteDictionary[] array = action.Get("Paths", new WriteDictionary[0]);
		for (int i = 0; i < array.Length; i++)
		{
			GameSettings.Instance.sRoomManager.PathController.Deserialize(array[i]);
		}
		GrassSystem.Instance.InvalidateArea();
		return true;
	}

	private static bool StylePathObject(UndoAction action)
	{
		PathObject[] array = action.Get("Paths", new PathObject[0]);
		Color[] array2 = action.Get("Colors", new Color[0]);
		Color[] array3 = action.Get("Colors2", new Color[0]);
		string[] array4 = action.Get("Materials", new string[0]);
		int num = Mathf.Min(array.Length, array2.Length, array4.Length);
		for (int i = 0; i < num; i++)
		{
			PathObject pathObject = array[i];
			if (pathObject != null)
			{
				pathObject.MatColor = array2[i];
				pathObject.MatColor2 = array3[i];
				pathObject.Material = array4[i];
			}
		}
		return true;
	}

	private static bool CreatePathSegment(UndoAction action)
	{
		Vector2[] source = action.Get("Points", new Vector2[0]);
		uint[] ids = action.Get("IDs", new uint[0]);
		bool bezier = action.Get("Bezier", false);
		Color? col = action.Get<Color?>("Color", null);
		string mat = action.Get<string>("Material", null);
		GameSettings.Instance.sRoomManager.PathController.AddPath(source.ToList(), bezier, ids, col, mat);
		return true;
	}

	private static bool DestroyPathSegment(UndoAction action)
	{
		uint[] array = action.Get("Paths", new uint[0]);
		List<PathController.PathPoint> list = new List<PathController.PathPoint>();
		foreach (uint id in array)
		{
			PathController.PathPoint pathPoint = GameSettings.Instance.sRoomManager.PathController.AllPoints.FirstOrDefault((PathController.PathPoint x) => x.ID == id);
			if (pathPoint == null)
			{
				return false;
			}
			list.Add(pathPoint);
		}
		List<PathController.PathPoint> list2 = new List<PathController.PathPoint>();
		if (action.Contains("ShortAID"))
		{
			uint id2 = action.Get<uint>("ShortAID");
			Vector2 point = action.Get<Vector2>("ShortAPos");
			bool bezier = action.Get<bool>("ShortABez");
			PathController.PathPoint pathPoint2 = new PathController.PathPoint(point, bezier, id2);
			GameSettings.Instance.sRoomManager.PathController.AllPoints.Add(pathPoint2);
			list[0].AddConnection(pathPoint2);
			list[0].RemoveConnection(list[1]);
			list[1].RemoveConnection(list[0]);
			list.RemoveAt(0);
			if (!GetSegment(pathPoint2))
			{
				GameSettings.Instance.sRoomManager.PathController.EndPointQueue.Add(pathPoint2);
				GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
			}
			list2.Add(pathPoint2);
		}
		if (action.Contains("ShortBID"))
		{
			uint id3 = action.Get<uint>("ShortBID");
			Vector2 point2 = action.Get<Vector2>("ShortBPos");
			bool bezier2 = action.Get<bool>("ShortBBez");
			PathController.PathPoint pathPoint3 = new PathController.PathPoint(point2, bezier2, id3);
			GameSettings.Instance.sRoomManager.PathController.AllPoints.Add(pathPoint3);
			list[list.Count - 1].AddConnection(pathPoint3);
			if (list.Count > 1)
			{
				list[list.Count - 1].RemoveConnection(list[list.Count - 2]);
				list[list.Count - 2].RemoveConnection(list[list.Count - 1]);
			}
			list.RemoveAt(list.Count - 1);
			if (!GetSegment(pathPoint3))
			{
				GameSettings.Instance.sRoomManager.PathController.EndPointQueue.Add(pathPoint3);
				GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
			}
			list2.Add(pathPoint3);
		}
		if (list.Count == 1)
		{
			GameSettings.Instance.sRoomManager.PathController.DeletePoint(list[0]);
		}
		else
		{
			HashSet<PathController.PathPoint> hashSet = new HashSet<PathController.PathPoint>(list);
			HashSet<PathController.PathPoint> hashSet2 = new HashSet<PathController.PathPoint>();
			for (int num = 0; num < list.Count; num++)
			{
				PathController.PathPoint pathPoint4 = list[num];
				if (!hashSet.Contains(pathPoint4))
				{
					continue;
				}
				for (int num2 = 0; num2 < pathPoint4.Connections.Count; num2++)
				{
					PathController.PathPoint key = pathPoint4.Connections[num2].Key;
					if (!hashSet.Contains(key))
					{
						continue;
					}
					hashSet2.Clear();
					PathBuilder.FindDeletionSegment(pathPoint4, key, hashSet2, hashSet);
					GameSettings.Instance.sRoomManager.PathController.DeletePath(hashSet2);
					foreach (PathController.PathPoint item in hashSet2)
					{
						hashSet.Remove(item);
					}
					num--;
					break;
				}
			}
		}
		for (int num3 = 0; num3 < list2.Count; num3++)
		{
			PathController.PathPoint p = list2[num3];
			GameSettings.Instance.sRoomManager.PathController.RefreshPathFrom(p);
		}
		return true;
	}

	private static bool GetSegment(PathController.PathPoint path)
	{
		bool result = false;
		foreach (RoomSegment roomSegment in GameSettings.Instance.sRoomManager.RoomSegments)
		{
			if (roomSegment.IsConnectedToOutside() && roomSegment.ConnectedPath == null)
			{
				Vector2 vector = roomSegment.transform.position.FlattenVector3();
				if ((path.Point - vector).sqrMagnitude < PathController.PathSegSnapDist && roomSegment.IsOnOutside(path.Point))
				{
					path.ConnectSegment(roomSegment);
					result = true;
				}
			}
		}
		return result;
	}

	private static bool RoofStyle(UndoAction action)
	{
		WriteDictionary[] array = action.Get("Roofs", new WriteDictionary[0]);
		for (int i = 0; i < array.Length; i++)
		{
			uint id = array[i].Get("WriteID", 0u);
			if (id != 0)
			{
				Roof roof = GameSettings.Instance.sRoomManager.Roofs.FirstOrDefault((Roof x) => x.DID == id);
				if (roof != null)
				{
					roof.ShallowDeserialize(array[i]);
					roof.UpdateStyleNetwork();
				}
			}
		}
		return true;
	}

	private static bool ChangeRoad(UndoAction action)
	{
		byte[,] array = action.Get<byte[,]>("RoadSegments");
		Vector2Int vector2Int = action.Get<Vector2Int>("Point");
		int num = action.Get<int>("Floor");
		for (int i = 0; i < array.GetLength(0); i++)
		{
			for (int j = 0; j < array.GetLength(1); j++)
			{
				NetworkMessaging.SendPlaceRoad(i + vector2Int.x, j + vector2Int.y, num, array[i, j], NetworkMessaging.MessageTarget.Everyone, 0);
			}
		}
		if (num == 0)
		{
			GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
			GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
			GrassSystem.Instance.InvalidateArea();
		}
		return true;
	}

	private static bool RoomColor(UndoAction action)
	{
		uint[] ids = action.Get<uint[]>("IDS");
		Color[,] array = action.Get<Color[,]>("Colors");
		int i;
		for (i = 0; i < ids.Length; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == ids[i]);
			if (room != null)
			{
				room.FloorColor = array[i, 0];
				room.FloorColor2 = array[i, 1];
				room.InsideColor = array[i, 2];
				room.InsideColor2 = array[i, 3];
				room.OutsideColor = array[i, 4];
				room.OutsideColor2 = array[i, 5];
				room.FenceColor = array[i, 6];
				room.UpdateStyleNetwork();
			}
		}
		return false;
	}

	private static bool RoomMaterial(UndoAction action)
	{
		uint[] ids = action.Get<uint[]>("IDS");
		string[,] array = action.Get<string[,]>("Mats");
		Color[,] array2 = action.Get<Color[,]>("Colors", null);
		SVector3[] array3 = action.Get<SVector3[]>("Offsets", null);
		int i;
		for (i = 0; i < ids.Length; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == ids[i]);
			if (room != null)
			{
				room.FloorMat = array[i, 0];
				if (room.Outdoors)
				{
					room.SetFenceStyle(array[i, 3], null);
				}
				else
				{
					room.InsideMat = array[i, 1];
					room.OutsideMat = array[i, 2];
				}
				if (array2 != null)
				{
					room.FloorColor = array2[i, 0];
					room.FloorColor2 = array2[i, 1];
					room.InsideColor = array2[i, 2];
					room.InsideColor2 = array2[i, 3];
					room.OutsideColor = array2[i, 4];
					room.OutsideColor2 = array2[i, 5];
					room.FenceColor = array2[i, 6];
				}
				if (array3 != null)
				{
					room.FloorOffset = new SVector3(array3[i].x, array3[i].y, 0f);
					room.FloorRotation = array3[i].z;
					room.FloorScale = array3[i].w;
					room.DirtyFloorMesh = true;
				}
				room.UpdateStyleNetwork();
			}
		}
		return false;
	}

	private static bool FurnitureColor(UndoAction action)
	{
		uint[] ids = action.Get<uint[]>("IDS");
		int[] array = action.Get<int[]>("Atlas", null);
		string[] array2 = action.Get<string[]>("Replacement1", null);
		string[] array3 = action.Get<string[]>("Replacement2", null);
		Color[,] array4 = action.Get<Color[,]>("Colors", null);
		int i;
		for (i = 0; i < ids.Length; i++)
		{
			WallSnap wallSnap = GameSettings.Instance.sRoomManager.AllFurniture.FirstOrDefault((Furniture x) => x.DID == ids[i]);
			if (wallSnap == null)
			{
				wallSnap = GameSettings.Instance.sRoomManager.RoomSegments.FirstOrDefault((RoomSegment x) => x.DID == ids[i]);
			}
			if (!(wallSnap != null))
			{
				continue;
			}
			if (array != null)
			{
				wallSnap.AtlasIndex = array[i];
				wallSnap.SetReplacement(0, array2[i]);
				wallSnap.SetReplacement(1, array3[i]);
			}
			if (array4 != null)
			{
				if (wallSnap.ColorPrimaryEnabled)
				{
					wallSnap.ColorPrimary = array4[i, 0];
				}
				if (wallSnap.ColorSecondaryEnabled)
				{
					wallSnap.ColorSecondary = array4[i, 1];
				}
				if (wallSnap.ColorTertiaryEnabled)
				{
					wallSnap.ColorTertiary = array4[i, 2];
				}
			}
			wallSnap.UpdateStyleNetwork();
		}
		return false;
	}

	private static bool BuyPlot(UndoAction action)
	{
		PlotArea plotArea = action.Get<PlotArea>("Plot");
		GameSettings.Instance.BuyPlot(plotArea, true);
		plotArea.Monthly = action.Get<float>("Monthly");
		plotArea.MonthsLeft = action.Get<int>("MonthsLeft");
		GameSettings.Instance.MyCompany.MakeTransaction(0f - action.Get<float>("UpFront"), Company.TransactionCategory.Construction, false, "Plot");
		return true;
	}

	private static bool SellPlot(UndoAction action)
	{
		PlotArea plotArea = action.Get<PlotArea>("Plot");
		GameSettings.Instance.SellPlot(plotArea, new List<Room>(), true);
		plotArea.AddonCost = action.Get<float>("AddonCost");
		GameSettings.Instance.MyCompany.AddTax(TaxReport.TaxType.Depreciation, plotArea.AddonCost);
		GameSettings.Instance.MyCompany.MakeTransaction(action.Get<float>("UpFront"), Company.TransactionCategory.Construction, false, "Plot");
		return true;
	}

	private static bool RentRoom(UndoAction action)
	{
		uint id = action.Get<uint>("ID");
		Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == id);
		if (room != null)
		{
			room.SetPlayerOwned(true, null);
			GameSettings.Instance.DirtyRentGrid.Add(room.Floor);
			return true;
		}
		return false;
	}

	private static bool UnrentRoom(UndoAction action)
	{
		uint id = action.Get<uint>("ID");
		Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == id);
		if (room != null)
		{
			float rentPrice = room.GetRentPrice();
			GameSettings.Instance.MyCompany.MakeTransaction(rentPrice, Company.TransactionCategory.Bills, false, "Rent");
			GameSettings.Instance.MyCompany.AddTax(TaxReport.TaxType.Operation, rentPrice);
			room.SetPlayerOwned(false, null);
			GameSettings.Instance.DirtyRentGrid.Add(room.Floor);
			return true;
		}
		return false;
	}

	private static bool CreateLandmark(UndoAction action)
	{
		if (RoadManager.Instance.DeserializeLandmark(action.Get<WriteDictionary>("Landmark"), false, Writeable.LoadType.Default) != null)
		{
			GrassSystem.Instance.InvalidateArea();
			return true;
		}
		return false;
	}

	private static bool DestroyLandmark(UndoAction action)
	{
		uint did = action.Get<uint>("Landmark");
		Landmark landmark = RoadManager.Instance.FindLandmark(did);
		if (landmark != null)
		{
			landmark.DestroyLandmark();
			return true;
		}
		return false;
	}

	private static bool AddTrees(UndoAction action)
	{
		TreeInstance[] array = action.Get<TreeInstance[]>("Trees");
		if (array.Length != 0)
		{
			for (int i = 0; i < array.Length; i++)
			{
				GameSettings.Instance.TempTrees.Add(array[i]);
			}
			GameSettings.Instance.BatchTempTrees();
		}
		return true;
	}

	private static bool RemoveTrees(UndoAction action)
	{
		TreeInstance[] array = action.Get<TreeInstance[]>("Trees");
		foreach (TreeInstance treeInstance in array)
		{
			if (treeInstance.BelongsTo != null)
			{
				treeInstance.BelongsTo.RemoveTree(treeInstance);
			}
			GameSettings.Instance.Trees.Remove(treeInstance);
			GameSettings.Instance.TreeTree.TryRemoveItem(treeInstance);
		}
		return true;
	}

	private static WallEdge CreateMissing(Room r, Vector2 p)
	{
		float num = float.MaxValue;
		Vector2 p2 = Vector2.zero;
		int index = 0;
		for (int i = 0; i < r.Edges.Count; i++)
		{
			WallEdge wallEdge = r.Edges[i];
			WallEdge wallEdge2 = r.Edges[(i + 1) % r.Edges.Count];
			Vector2 res;
			if (Utilities.ProjectToLine(p, wallEdge.Pos, wallEdge2.Pos, out res))
			{
				float sqrMagnitude = (res - p).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					p2 = res;
					index = i;
				}
			}
		}
		if (num < 0.02f)
		{
			WallEdge wallEdge3 = new WallEdge(p2, r.Floor);
			wallEdge3.SetSplit(r.Edges[index], r);
			return wallEdge3;
		}
		return null;
	}

	private static bool CurveWall(UndoAction action)
	{
		uint r1id = action.Get<uint>("r1");
		uint r2id = action.Get("r2", 0u);
		Vector2? vector = action.Get<Vector2?>("corner", null);
		Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == r1id);
		Room room2 = ((r2id == 0) ? null : GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == r2id));
		if (room == null || (r2id != 0 && room2 == null))
		{
			return false;
		}
		if (r2id == 0 && room.Floor == 0)
		{
			GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
		}
		bool flag = action.Get<bool>("reverse");
		Vector2 e1p = action.Get<Vector2>("e1");
		Vector2 e2p = action.Get<Vector2>("e2");
		WallEdge wallEdge = room.Edges.FirstOrDefault((WallEdge x) => x.Pos.Dist(e1p) < 0.1f);
		WallEdge wallEdge2 = room.Edges.FirstOrDefault((WallEdge x) => x.Pos.Dist(e2p) < 0.1f);
		if (wallEdge == null || wallEdge2 == null)
		{
			bool flag2 = wallEdge == null;
			bool flag3 = wallEdge2 == null;
			if (flag2)
			{
				wallEdge = CreateMissing(room, e1p);
			}
			if (wallEdge != null && flag3)
			{
				wallEdge2 = CreateMissing(room, e2p);
			}
			if (wallEdge == null || wallEdge2 == null)
			{
				return false;
			}
			if (flag2)
			{
				wallEdge.SplitSegment(null);
			}
			if (flag3)
			{
				wallEdge2.SplitSegment(null);
			}
		}
		List<WallEdge> list = new List<WallEdge>();
		int num = room.Edges.IndexOf(wallEdge);
		for (int num2 = 1; num2 < room.Edges.Count; num2++)
		{
			int index = (num2 + num) % room.Edges.Count;
			WallEdge wallEdge3 = room.Edges[index];
			if (wallEdge3 == wallEdge2)
			{
				break;
			}
			list.Add(wallEdge3);
		}
		foreach (WallEdge item in list)
		{
			room.Edges.Remove(item);
			item.Links.Remove(room);
			if (room2 != null)
			{
				room2.Edges.Remove(item);
				item.Links.Remove(room2);
			}
			if (item.Links.Count == 0)
			{
				GameSettings.Instance.sRoomManager.AllSegments.Remove(item);
			}
		}
		wallEdge.Links[room] = wallEdge2;
		if (vector.HasValue)
		{
			WallEdge wallEdge4 = new WallEdge(vector.Value, room.Floor);
			GameSettings.Instance.sRoomManager.AllSegments.Add(wallEdge4);
			room.Edges.Insert(num + 1, wallEdge4);
			wallEdge.Links[room] = wallEdge4;
			wallEdge4.Links[room] = wallEdge2;
		}
		room.UpdateBounds(false);
		if (room2 != null)
		{
			wallEdge2.Links[room2] = wallEdge;
			room2.UpdateBounds(false);
		}
		else
		{
			GrassSystem.Instance.InvalidateArea();
		}
		Room room3 = (flag ? room2 : room);
		if (room3 != null)
		{
			foreach (Furniture item2 in room3.GetFurnitures().ToList())
			{
				item2.UpdateParent(false);
			}
		}
		room.RecalculateTableGroupsNow();
		if (room2 != null)
		{
			room2.RecalculateTableGroupsNow();
		}
		list.Add(wallEdge);
		list.Add(wallEdge2);
		List<IRoom> list2 = list.SelectMany((WallEdge x) => x.Links.Keys).Distinct().ToList();
		for (int num3 = 0; num3 < list2.Count; num3++)
		{
			Room obj = (Room)list2[num3];
			obj.OptimizeSegments();
			obj.DirtyOuterMesh = (obj.DirtyInnerMesh = (obj.DirtyNavMesh = (obj.DirtyPathNodes = true)));
		}
		return true;
	}

	public void Execute(bool forceThrough = false)
	{
		_furnIds.Clear();
		for (int i = 0; i < Actions.Length; i++)
		{
			UndoAction undoAction = Actions[i];
			if (undoAction.Type == UndoAction.ActionType.CreateFurniture && !_furnIds.Add(undoAction.Get<WriteDictionary>("Furn").Get<uint>("WriteID")))
			{
				Actions[i] = null;
			}
		}
		_furnIds.Clear();
		for (int j = 0; j < Actions.Length; j++)
		{
			UndoAction undoAction2 = Actions[j];
			uint val;
			if (undoAction2 == null || undoAction2.Type != UndoAction.ActionType.CreateFurniture || !undoAction2.Get<WriteDictionary>("Furn").TryGet<uint>("SnapPoint", out val) || val == 0)
			{
				continue;
			}
			for (int k = 0; k < Actions.Length; k++)
			{
				UndoAction undoAction3 = Actions[k];
				if (undoAction3 != null && undoAction3.Type == UndoAction.ActionType.CreateFurniture && undoAction3.Get<WriteDictionary>("Furn").Get<uint>("WriteID") == val)
				{
					if (k > j)
					{
						Actions[k] = undoAction2;
						Actions[j] = undoAction3;
						j--;
					}
					break;
				}
			}
		}
		UndoAction[] actions = Actions;
		foreach (UndoAction undoAction4 in actions)
		{
			if (undoAction4 == null)
			{
				continue;
			}
			bool flag = true;
			MethodInfo method = typeof(UndoObject).GetMethod(undoAction4.Type.ToString(), BindingFlags.Static | BindingFlags.NonPublic);
			if (method != null)
			{
				flag = (bool)method.Invoke(null, new object[1] { undoAction4 });
				if (!forceThrough && !flag && (undoAction4.Type == UndoAction.ActionType.SplitRoom || undoAction4.Type == UndoAction.ActionType.CurvedCorner))
				{
					return;
				}
				if (flag)
				{
					if (undoAction4.TaxBalance != 0f)
					{
						GameSettings.Instance.MyCompany.AddTax(undoAction4.TaxType, undoAction4.TaxBalance);
					}
					if (undoAction4.BalanceDiff != 0f)
					{
						GameSettings.Instance.MyCompany.MakeTransaction(undoAction4.BalanceDiff, undoAction4.BalanceCategory, undoAction4.Taxed ? ((!(undoAction4.BalanceDiff > 0f)) ? TaxReport.TaxType.Income : TaxReport.TaxType.Operation) : TaxReport.TaxType.None, undoAction4.BalanceBill);
					}
				}
				continue;
			}
			throw new Exception("Undo type could not be handled: " + undoAction4.Type);
		}
		foreach (Writeable item in NeedsPostDeserialization)
		{
			item.PostDeserialize();
		}
		NeedsPostDeserialization.Clear();
		if (RefreshSelectionState)
		{
			SelectorController.Instance.DoPostSelectChecks();
			RefreshSelectionState = false;
		}
	}
}
