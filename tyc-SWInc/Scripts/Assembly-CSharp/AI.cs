using System;
using System.Collections.Generic;
using System.Linq;
using Achievements;
using UnityEngine;

public class AI
{
	public enum AIType
	{
		Employee = 0,
		Janitor = 1,
		Cleaning = 2,
		IT = 3,
		Receptionist = 4,
		Guest = 5,
		Cook = 6,
		Courier = 7,
		Burglar = 8,
		Police = 9,
		Security = 10,
		FireInspector = 11,
		FireFighter = 12,
		Robot = 13,
		Parent = 14
	}

	[Flags]
	public enum NodeFlag
	{
		None = 0,
		Snore = 1,
		Run = 2,
		DisableToiletNeed = 4,
		DisableFoodNeed = 8,
		GoingHome = 0x10,
		InMeeting = 0x20,
		DisableAllNeeds = 0x40,
		Working = 0x80,
		SprayHose = 0x100,
		LookAtTarget = 0x200
	}

	private const float _trashTime = 0.25f;

	public const int CookWait = 3;

	private static HashSet<Room> _assignedCooksRooms = new HashSet<Room>();

	public static int MaxBoxes = 54;

	public static int MaxBoxCarry = 9;

	public const float BoxPrice = 125f;

	public const float CourierSalary = 2000f;

	public static BehaviorNode DummyNode = new BehaviorNode("Dummy", delegate(Actor x)
	{
		x.DummyCount++;
		return 1;
	}, true);

	private BehaviorNode root;

	public Dictionary<string, BehaviorNode> BehaviorNodes = new Dictionary<string, BehaviorNode>();

	public Actor Target;

	private BehaviorNode _lastStop;

	private BehaviorNode _currentNode;

	public int LastResult = -1;

	private static KeyValuePair<Func<RoomSegment, int>, bool>[] BestSegCompare = new KeyValuePair<Func<RoomSegment, int>, bool>[2]
	{
		new KeyValuePair<Func<RoomSegment, int>, bool>((RoomSegment x) => x.GuardedBy.Count, true),
		new KeyValuePair<Func<RoomSegment, int>, bool>((RoomSegment x) => x.LastGuarded.ToInt(), true)
	};

	public static int MaxBoxesDPM
	{
		get
		{
			return MaxBoxes / GameSettings.DaysPerMonth * GameSettings.DaysPerMonth;
		}
	}

	public BehaviorNode currentNode
	{
		get
		{
			return _currentNode;
		}
		set
		{
			if (_lastStop != null && value.Atomic)
			{
				if (value != _lastStop)
				{
					_lastStop.Stop(Target);
				}
				_lastStop = null;
			}
			if (_currentNode != null && value != _currentNode && _currentNode.HasStop)
			{
				if (_currentNode.Atomic && !value.Atomic)
				{
					_lastStop = _currentNode;
				}
				else
				{
					_currentNode.Stop(Target);
				}
			}
			_currentNode = value;
		}
	}

	public string CurrentNodeLabel
	{
		get
		{
			if (currentNode != null)
			{
				return currentNode.LocName;
			}
			return "Idle";
		}
	}

	public NodeFlag CurrentNodeFlags
	{
		get
		{
			if (currentNode != null)
			{
				return currentNode.Flags;
			}
			return NodeFlag.None;
		}
	}

	private static int BurglarSpawn(Actor self)
	{
		GameSettings.Instance.ResetUndo();
		return 2;
	}

	private static int FindBurgleRoom(Actor self)
	{
		if (self.CleaningRoom != null)
		{
			return 2;
		}
		foreach (KeyValuePair<Room, int> item in from x in GameSettings.Instance.sRoomManager.GetConnectedRooms(self.currentRoom)
			orderby x.Key.GetFurnituresInAtrium().SumSafe((Furniture z) => (!z.CheckCanSteal()) ? 0f : z.GetSellPriceIgnoreQuality()) / (float)(x.Value + 1) descending
			select x)
		{
			Room key = item.Key;
			if (!key.Outside && key.Accessible && !(key == self.currentRoom) && key.IsPlayerControlled() && !key.NavmeshRebuildStarted && key.GetFurnituresInAtrium().Any((Furniture x) => x.CheckCanSteal()))
			{
				self.Reserved = null;
				self.CleaningRoom = key;
				FindFirstExpensiveFurn(self);
				if (!(self.Reserved == null))
				{
					return 2;
				}
				self.CleaningRoom = null;
			}
		}
		return 0;
	}

	private static void FindFirstExpensiveFurn(Actor self)
	{
		Vector2 point = self.transform.position.FlattenVector3();
		foreach (Furniture item in (from z in self.CleaningRoom.GetFurnituresInAtrium()
			where z.CheckCanSteal()
			orderby z.GetSellPriceIgnoreQuality() descending
			select z).ThenBy((Furniture x) => x.transform.position.FlattenVector3().ManhattanDist(point)))
		{
			if ((item.Reserved == null || item.Reserved.AItype != AIType.Burglar) && PathToFurn(item, self))
			{
				self.Reserved = item;
				break;
			}
		}
	}

	private static bool PathToFurn(Furniture furn, Actor self)
	{
		Vector3 vector = furn.transform.position + furn.transform.rotation * new Vector3(0f, 0f, 0.5f);
		Vector3? validPointNear = furn.Parent.FindFloorAtrium(vector).GetValidPointNear(vector, 0f, true);
		if (validPointNear.HasValue && self.PathToPoint(validPointNear.Value, true, true, self.AItype))
		{
			if (furn.Parent != self.CleaningRoom)
			{
				PathVector pathVector = self.CurrentPath.Last();
				self.CurrentPath.Add(new PathVector(pathVector.x, furn.Parent.Floor * 2, pathVector.z));
			}
			return true;
		}
		return false;
	}

	private static void AlertSecurityStaff(Actor self, Furniture f)
	{
		if (f.CCGroup == null)
		{
			return;
		}
		foreach (SurveillanceDesk desk in f.CCGroup.Desks)
		{
			Furniture[] cCTVs = desk.GetCCTVs();
			for (int i = 0; i < cCTVs.Length; i++)
			{
				if (cCTVs[i] == f)
				{
					Actor usedBy = desk.Furn.GetInteractionPoint(InteractionPoint.ActionType.Use, true).UsedBy;
					if (usedBy != null && usedBy.AItype == AIType.Security)
					{
						usedBy.RunToBurglar(self);
					}
					return;
				}
			}
		}
	}

	private static void ScareAllBurgs()
	{
		foreach (Actor item in GameSettings.Instance.sActorManager.Others["Burglars"])
		{
			if (!item.AIScript.HasFlag(NodeFlag.GoingHome))
			{
				item.Timer = -1f;
				item.ClearPath();
				item.AIScript.currentNode = item.AIScript.BehaviorNodes["ShouldUseBus"];
			}
		}
	}

	private static int FindExpensiveFurn(Actor self)
	{
		if (self.CleaningRoom == null)
		{
			self.Reserved = null;
			return 2;
		}
		if (self.currentRoom.AtriumParent == self.currentRoom)
		{
			for (int i = 0; i <= self.currentRoom.AtriumChildren.Count; i++)
			{
				HashList<Furniture> furniture = ((i == 0) ? self.currentRoom : self.currentRoom.AtriumChildren[i - 1]).GetFurniture("CCTV");
				for (int j = 0; j < furniture.Count; j++)
				{
					Furniture furniture2 = furniture[j];
					if (furniture2.IsAliveNotNull() && furniture2.IsOn && furniture2.CheckInRange(self.ActualPosition.FlattenVector3()))
					{
						furniture2.InteractStart();
						ScareAllBurgs();
						AlertSecurityStaff(self, furniture2);
						return 1;
					}
				}
			}
		}
		else if (self.currentRoom.Outside)
		{
			List<CCTVGroup> cCGroups = GameSettings.Instance.sRoomManager.CCGroups;
			for (int k = 0; k < cCGroups.Count; k++)
			{
				foreach (Furniture key in cCGroups[k].CCTVs.Keys)
				{
					if (key.IsAliveNotNull() && key.IsReversed && key.IsOn && key.CheckInRange(self.ActualPosition.FlattenVector3()))
					{
						key.InteractStart();
						ScareAllBurgs();
						AlertSecurityStaff(self, key);
						return 1;
					}
				}
			}
		}
		else
		{
			HashList<Furniture> furniture3 = self.currentRoom.GetFurniture("CCTV");
			for (int l = 0; l < furniture3.Count; l++)
			{
				Furniture furniture4 = furniture3[l];
				if (furniture4.IsAliveNotNull() && furniture4.IsOn && furniture4.CheckInRange(self.ActualPosition.FlattenVector3()))
				{
					furniture4.InteractStart();
					ScareAllBurgs();
					AlertSecurityStaff(self, furniture4);
					return 1;
				}
			}
		}
		if (self.Timer >= 0f)
		{
			self.SetAnim(Actor.AnimationStates.Steal);
			if (self.Timer < 0.5f)
			{
				ActualSteal(self);
			}
			if (self.WaitForTimer(-1f) == 2)
			{
				ActualSteal(self);
				return 2;
			}
			return 1;
		}
		if (self.Reserved == null || self.CurrentPath == null)
		{
			if (self.CleaningRoom.GetNavMeshRunning())
			{
				self.SetAnim(Actor.AnimationStates.Idle);
				return 1;
			}
			self.Reserved = null;
			FindFirstExpensiveFurn(self);
			if (self.Reserved == null)
			{
				self.CleaningRoom = null;
				return 2;
			}
		}
		else if (self.CurrentPath != null && self.WalkPath() && self.Reserved != null)
		{
			self.InitiateTurn(Quaternion.LookRotation(self.Reserved.transform.position.ReplaceY(0f) - self.ActualPosition.ReplaceY(0f)).eulerAngles.y);
			self.Timer = 1f;
		}
		return 1;
	}

	private static void ActualSteal(Actor self)
	{
		if (self.Reserved != null)
		{
			self.Reserved.Undo = true;
			self.Reserved.NonPlayerDestruction = true;
			self.Reserved.Parent.AddDestructionUndo(self.Reserved);
			if (self.Stolen == null)
			{
				self.Stolen = new List<InventoryItem>();
			}
			if (!self.Reserved.Type.Equals("Award"))
			{
				self.Stolen.Add(new InventoryItem(self.Reserved));
			}
			foreach (Furniture item in self.Reserved.IterateSnap())
			{
				item.Undo = true;
				item.NonPlayerDestruction = true;
				item.Parent.AddDestructionUndo(item);
				item.InsurancePayout();
				self.Stolen.Add(new InventoryItem(item));
				GameSettings.Instance.Looted++;
			}
			GameSettings.Instance.Burgled.Add(self.Reserved.Parent);
			self.Reserved.InsurancePayout();
			GameSettings.Instance.Looted++;
			self.Reserved.DestroyGO();
		}
		self.Reserved = null;
	}

	private static int Arrest(Actor self)
	{
		self.SetAnim(Actor.AnimationStates.HandsUp);
		if (self.TargetActor != null)
		{
			if (InRange(self))
			{
				return 2;
			}
			return 1;
		}
		return 2;
	}

	private static int IsCleaningOff(Actor self)
	{
		int num = IsStaffOff(self);
		if (num == 2)
		{
			self.NegotiateSalary = false;
			if (self.CleaningRoom != null)
			{
				self.CleaningRoom.Reservers--;
				self.CleaningRoom = null;
			}
			if (self.UsingPoint != null)
			{
				self.UsingPoint.UsedBy = null;
				self.UsingPoint = null;
			}
		}
		return num;
	}

	private static int FindCleanRoom(Actor self)
	{
		if (self.GoHomeNow)
		{
			self.ClearPath();
			self.UsingPoint = null;
			return 0;
		}
		if (self.CleaningRoom != null)
		{
			self.CleaningRoom.Reservers--;
			self.CleaningRoom = null;
		}
		IEnumerable<Room> enumerable;
		if (!self.HasAssignedRooms)
		{
			if (!self.currentRoom.Outside)
			{
				enumerable = from x in GameSettings.Instance.sRoomManager.GetConnectedRooms(self.currentRoom)
					orderby x.Value / 3, x.Key.DirtScore * (float)(1 + x.Key.Reservers)
					select x.Key;
			}
			else
			{
				IEnumerable<Room> enumerable2 = GameSettings.Instance.sRoomManager.Rooms.OrderBy((Room x) => x.DirtScore * (float)(1 + x.Reservers));
				enumerable = enumerable2;
			}
		}
		else
		{
			IEnumerable<Room> enumerable2 = from x in self.GetAssignedRooms()
				orderby x.DirtScore * (float)(1 + x.Reservers)
				select x;
			enumerable = enumerable2;
		}
		self.NegotiateSalary = false;
		foreach (Room item in enumerable)
		{
			if (!item.Outside && item.Accessible && !(item == self.currentRoom) && item.CanClean && (!GameSettings.Instance.RentMode || (item.PlayerOwned && item.Rentable)) && !item.BuildingOnFire)
			{
				if (item.ToiletInUse() || item.NavmeshRebuildStarted)
				{
					self.NegotiateSalary = true;
				}
				else if (!Mathf.Approximately(item.DirtScore, 1f))
				{
					self.UsingPoint = null;
					self.CleaningRoom = item;
					item.Reservers++;
					return 2;
				}
			}
		}
		Room currentRoom = self.currentRoom;
		if (!currentRoom.Outside && !currentRoom.NavmeshRebuildStarted && currentRoom.CanClean && (currentRoom.PlayerOwned || !GameSettings.Instance.RentMode) && !currentRoom.BuildingOnFire && !Mathf.Approximately(currentRoom.DirtScore, 1f))
		{
			self.UsingPoint = null;
			self.CleaningRoom = currentRoom;
			currentRoom.ClearDirtTimer();
			currentRoom.Reservers++;
			return 2;
		}
		return 0;
	}

	private static int ShouldWaitForToilet(Actor self)
	{
		if (self.GoHomeNow)
		{
			self.NegotiateSalary = false;
			return 0;
		}
		if (!self.NegotiateSalary && (self.OnCall || self.LeaveWhenDone))
		{
			self.AIScript.currentNode = self.AIScript.BehaviorNodes["ShouldUseBus"];
			return 0;
		}
		return 2;
	}

	private static int FindNewSpot(Actor self)
	{
		if (self.CleaningRoom == null)
		{
			self.CleaningPoints.Clear();
			return 0;
		}
		self.CleaningRoom.ClearDirtTimer();
		if (self.GoHomeNow || self.CleaningRoom.NavmeshRebuildStarted)
		{
			self.CleaningRoom.Reservers--;
			self.CleaningRoom = null;
			self.CleaningPoints.Clear();
			return 0;
		}
		bool flag = false;
		if (self.CleaningPoints.Count == 0)
		{
			flag = self.CleaningRoom.Dirts.Count > 0;
			self.SetAnim(Actor.AnimationStates.Idle);
			self.CleaningPoints.PushRange((from x in self.CleaningRoom.Dirts
				orderby Mathf.FloorToInt(x.Pos.x), Mathf.FloorToInt(x.Pos.y) * ((Mathf.FloorToInt(x.Pos.x) % 2 != 1) ? 1 : (-1))
				select new Vector3(x.Pos.x, self.CleaningRoom.Floor * 2, x.Pos.y)).ToList().RandomOffset());
		}
		while (self.CleaningPoints.Count > 0)
		{
			Vector3 v = self.CleaningPoints.Pop();
			if (self.CleaningRoom.GetDirt(v.x, v.z) > 0f)
			{
				Vector2 vector = v.FlattenVector3();
				Vector2? pos;
				Vector2? vector2 = (self.CleaningRoom.GetNavOrClosest(vector, out pos, 1f) ? new Vector2?(vector) : pos);
				if (vector2.HasValue && self.PathToPoint(vector2.Value.ToVector3(v.y), true))
				{
					self.CurrentCleaningSpot = vector;
					return 2;
				}
			}
		}
		self.CleaningRoom.RefreshDirtNavmesh();
		self.CleaningPoints.Clear();
		if (self.CleaningRoom.Dirts.Count > 0 && flag)
		{
			self.CleaningRoom.CanClean = false;
		}
		self.CleaningRoom.Reservers--;
		self.CleaningRoom = null;
		return 0;
	}

	private static int GotoCleanSpot(Actor self)
	{
		if (self.CleaningRoom != null)
		{
			self.CleaningRoom.ClearDirtTimer();
		}
		if (!self.WalkPath())
		{
			return 1;
		}
		return 2;
	}

	private static int CheckTrashInRoom(Actor self)
	{
		Room room = ((self.CleaningRoom == null) ? self.currentRoom : self.CleaningRoom);
		return CheckTrash(self, room.GetFurniture("Trashcan"), (Furniture x) =>
		{
			TrashCan component;
			return (!x.TryGetComponent<TrashCan>(out component)) ? null : component;
		});
	}

	private static int CheckTrashInWorld(Actor self)
	{
		if (self.GoHomeNow)
		{
			self.ClearPath();
			self.UsingPoint = null;
			return 0;
		}
		return CheckTrash(self, GameSettings.Instance.FullTrashCans, (TrashCan x) => x);
	}

	private static int CheckTrash<T>(Actor self, IList<T> tr, Func<T, TrashCan> getCan)
	{
		if (self.CurrentPath != null)
		{
			if (self.UsingPoint == null)
			{
				self.Timer = 0f;
				self.ClearPath();
				return 2;
			}
			if (self.WalkPath())
			{
				self.SetAnim(self.UsingPoint.Animation, self.UsingPoint.subAnimation);
				self.TurnToFurniture();
				self.Timer = 0.25f;
				return 2;
			}
			return 1;
		}
		if (tr.Count == 0)
		{
			return 0;
		}
		float num = float.MaxValue;
		InteractionPoint interactionPoint = null;
		for (int i = 0; i < tr.Count; i++)
		{
			T arg = tr[i];
			TrashCan trashCan = getCan(arg);
			if (trashCan != null && trashCan.NeedsEmpty())
			{
				InteractionPoint interactionPoint2 = trashCan.Furn.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
				if (interactionPoint2 != null && (self.ActualPosition.FlattenVector3() - interactionPoint2.transform.position.FlattenVector3()).sqrMagnitude + (float)(Mathf.Abs(self.Floor - trashCan.Furn.Floor) * 8 * 8) < num)
				{
					interactionPoint = interactionPoint2;
				}
			}
		}
		if (!interactionPoint.IsReferenceNull())
		{
			if (!self.PathToFurniture(interactionPoint, true))
			{
				return 0;
			}
			return 1;
		}
		return 0;
	}

	private static int EmptyTrash(Actor self)
	{
		if (self.WaitForTimer(0.25f) == 2)
		{
			TrashCan component;
			if (self.UsingPoint != null && self.UsingPoint.Parent.TryGetComponent<TrashCan>(out component))
			{
				component.Empty();
				self.UsingPoint = null;
			}
			return 2;
		}
		return 1;
	}

	private static int Clean(Actor self)
	{
		self.SetAnim(Actor.AnimationStates.Dust);
		if (self.CleaningRoom != null)
		{
			self.CleaningRoom.ClearDirtTimer();
			Vector2 vec = ((self.CurrentCleaningSpot == Vector2.zero) ? self.ActualPosition.FlattenVector3() : self.CurrentCleaningSpot);
			float num = (Time.deltaTime + self.UnusedMeters / self.WalkSpeed) * GameSettings.GameSpeed * 5f;
			float num2 = 0f;
			for (int num3 = 10; num3 > 0; num3--)
			{
				num = self.CleaningRoom.AddDirt(vec, 0f - num);
				num2 = self.CleaningRoom.GetDirt(vec.x, vec.y);
				if (num2 <= 0f || num <= 0f)
				{
					break;
				}
			}
			self.UnusedMeters = num / (5f * GameSettings.GameSpeed) * self.WalkSpeed;
			if (num2 == 0f)
			{
				if (self.CleaningPoints.Count > 0)
				{
					return 2;
				}
				self.CleaningRoom.RefreshDirtNavmesh();
				return 0;
			}
			return 1;
		}
		return 0;
	}

	private static int IsCookOff(Actor self)
	{
		int num = IsStaffOff(self);
		if (num == 2)
		{
			if (self.Holding[0] != null)
			{
				self.LeaveItem(self.Holding[0], true);
			}
			if (self.Reserved != null)
			{
				ClearReserved(self);
			}
			if (self.UsingPoint != null)
			{
				self.UsingPoint.UsedBy = null;
				self.UsingPoint = null;
			}
		}
		return num;
	}

	private static void ClearReserved(Actor self)
	{
		if (self.Reserved != null)
		{
			self.Reserved.ClearHoldables();
			self.Reserved.Reserved = null;
			self.Reserved = null;
		}
	}

	private static int CanCook(Actor self)
	{
		if (self.Holding[0] != null)
		{
			return 0;
		}
		if (self.Reserved == null)
		{
			if (self.Owns.Count > 0)
			{
				foreach (Furniture own in self.Owns)
				{
					bool roomFail;
					if (CheckStove(self, own, true, out roomFail))
					{
						break;
					}
				}
			}
			if (self.Reserved == null)
			{
				if (self.HasAssignedRooms)
				{
					foreach (Room assignedRoom in self.GetAssignedRooms())
					{
						CheckRoomStove(self, assignedRoom);
						if (self.Reserved != null)
						{
							break;
						}
					}
				}
				else
				{
					self.UpdateCurrentRoom();
					List<KeyValuePair<Room, int>> connectedRooms = GameSettings.Instance.sRoomManager.GetConnectedRooms(self.currentRoom);
					for (int i = 0; i < connectedRooms.Count; i++)
					{
						CheckRoomStove(self, connectedRooms[i].Key);
						if (self.Reserved != null)
						{
							break;
						}
					}
				}
			}
			if (self.Reserved == null)
			{
				if (self.SickDays > 3 && !NotificationManager.CheckAggregate<MissingStaffFurnitureNotification>(self, "Stove".GetUHash()))
				{
					NotificationManager.AddNotification(new MissingStaffFurnitureNotification("CookStoveWarning".Loc(), "CookStoveWarningHint".Loc(), "Fork", "Stove", self));
				}
				if (self.SickDays <= 3)
				{
					self.SickDays++;
				}
			}
		}
		if (!(self.Reserved != null) || !self.Reserved.CanPlaceHoldable())
		{
			return 0;
		}
		return 2;
	}

	private static void CheckRoomStove(Actor self, Room room)
	{
		HashList<Furniture> furniture = room.GetFurniture("Stove");
		bool roomFail;
		for (int i = 0; i < furniture.Count && !(CheckStove(self, furniture[i], false, out roomFail) || roomFail); i++)
		{
		}
	}

	private static bool CheckStove(Actor self, Furniture furn, bool checkRoom, out bool roomFail)
	{
		roomFail = false;
		if (CheckReservation(self, furn) && (!furn.HasUpg || !furn.upg.Broken) && (!checkRoom || !self.HasAssignedRooms || self.IsAssignedRoom(furn.Parent)))
		{
			InteractionPoint interactionPoint = furn.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
			if (interactionPoint != null)
			{
				Vector2 point = interactionPoint.Point;
				Vector3 endV = new Vector3(point.x, furn.Parent.Floor * 2, point.y);
				if (GameSettings.Instance.sRoomManager.FindPath(self.ActualPosition, endV, 0f, null, Employee.RoleBit.None, true, out roomFail) != null)
				{
					furn.Reserved = self;
					self.Reserved = furn;
					return true;
				}
			}
		}
		return false;
	}

	private static bool CheckReservation(Actor self, Furniture furn)
	{
		if (furn.Reserved != null)
		{
			if (furn.Reserved == self)
			{
				return true;
			}
			if (furn.Reserved.Reserved != furn)
			{
				furn.Reserved = null;
				return true;
			}
			return false;
		}
		return true;
	}

	private static int FindFridge(Actor self)
	{
		int num = self.GoToFurniture("Fridge", InteractionPoint.ActionType.Use, -1, false, (self.Reserved != null) ? self.Reserved.Parent : null, false, true, (Furniture x) => x.AnyUnitsLeft());
		switch (num)
		{
		case 2:
			self.SetAnim(Actor.AnimationStates.Fridge);
			self.TurnToFurniture();
			break;
		case 0:
			if (!self.QueuedFor("Fridge") && !NotificationManager.CheckAggregate<MissingStaffFurnitureNotification>(self, "Fridge".GetUHash()))
			{
				if (Actor.FilterCheck == 1)
				{
					NotificationManager.AddNotification(new MissingStaffFurnitureNotification("NoFridgeWarning".Loc(), null, "Fork", "Fridge", self));
				}
				else
				{
					NotificationManager.AddNotification(new MissingStaffFurnitureNotification("CookFridgeWarning".Loc(), "CookStoveWarningHint".Loc(), "Fork", "Fridge", self));
				}
			}
			self.SetAnim(Actor.AnimationStates.Idle);
			break;
		}
		return num;
	}

	private static int CookGetFood(Actor self)
	{
		if (self.UsingPoint == null || !self.UsingPoint.Parent.AnyUnitsLeft())
		{
			return 2;
		}
		int num = self.WaitForTimer(2f);
		if (num == 2)
		{
			Holdable item = self.GetItem("Pot", true);
			if (item != null)
			{
				item.Worth = self.UsingPoint.Parent.UnitCost / (float)GameSettings.DaysPerMonth;
			}
			self.SetAnim(Actor.AnimationStates.Idle);
			if (self.UsingPoint != null)
			{
				self.UsingPoint.Parent.InteractEnd();
				self.UsingPoint.Parent.SubtractUnit();
				self.UsingPoint = null;
			}
		}
		return num;
	}

	private static int CookFood(Actor self)
	{
		if (self.Reserved != null)
		{
			if (!(self.Holding[0] != null) || !self.Holding[0].Type.Equals("Pot"))
			{
				return 0;
			}
			return 2;
		}
		if (self.Holding[0] != null && self.Holding[0].Type.Equals("Pot"))
		{
			self.LeaveItem(self.Holding[0], true);
		}
		return 0;
	}

	private static int FindStove(Actor self)
	{
		if (self.Reserved == null)
		{
			self.UsingPoint = null;
			self.ClearPath();
			return 0;
		}
		if (self.Reserved.HasUpg && self.Reserved.upg.Broken)
		{
			self.Reserved = null;
			self.UsingPoint = null;
			self.ClearPath();
			return 0;
		}
		if (self.CurrentPath == null)
		{
			InteractionPoint interactionPoint = self.Reserved.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
			if (interactionPoint != null && self.PathToFurniture(interactionPoint, false))
			{
				self.UsingPoint = interactionPoint;
				return 1;
			}
			ClearReserved(self);
			self.SetAnim(Actor.AnimationStates.Idle);
			return 0;
		}
		if (self.WalkPath())
		{
			self.TurnToFurniture();
			Holdable holdable = self.Holding[0];
			int result = 2;
			if (self.Reserved.PlaceHoldable(holdable))
			{
				self.TrashUpdate(5f, 2, 30f);
				self.LeaveItem(holdable);
			}
			else
			{
				result = 0;
			}
			self.UsingPoint = null;
			return result;
		}
		return 1;
	}

	private static int FoodReady(Actor self)
	{
		if (self.Holding[0] != null)
		{
			if (!self.Holding[0].Type.StartsWith("FoodPlate"))
			{
				return 0;
			}
			return 2;
		}
		if (self.Reserved != null && self.Reserved.GetComponent<StoveScript>().HasReady())
		{
			return 2;
		}
		return 0;
	}

	private static int FetchFood(Actor self)
	{
		if (self.Holding[0] != null)
		{
			if (!self.Holding[0].Type.StartsWith("FoodPlate"))
			{
				return 0;
			}
			return 2;
		}
		if (self.Reserved == null)
		{
			self.UsingPoint = null;
			self.ClearPath();
			return 0;
		}
		if (self.CurrentPath == null)
		{
			InteractionPoint interactionPoint = self.Reserved.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
			if (interactionPoint != null && self.PathToFurniture(interactionPoint, false))
			{
				return 1;
			}
			return 0;
		}
		if (self.WalkPath())
		{
			self.TurnToFurniture();
			Holdable holdable = self.Reserved.GetComponent<StoveScript>().TakeReady();
			if (holdable == null)
			{
				return 0;
			}
			float worth = holdable.Worth;
			holdable.DestroyMe();
			Holdable item = self.GetItem("FoodPlate", true);
			if (item != null)
			{
				item.Worth = worth;
			}
			self.UsingPoint = null;
			self.TrashUpdate(5f, 2, 30f);
			return 2;
		}
		return 1;
	}

	private static int FindTray(Actor self)
	{
		bool any = false;
		if (self.QueuedFor("Tray"))
		{
			InteractionPoint interactionPoint = self.InQueue["Tray"];
			if (interactionPoint == null)
			{
				self.InQueue.Remove("Tray");
			}
			else
			{
				if (!self.IsUp("Tray"))
				{
					return 0;
				}
				if (!interactionPoint.Usable())
				{
					interactionPoint.RemoveFromQueue(self);
					self.InQueue.Remove("Tray");
				}
				else
				{
					if (self.PathToFurniture(interactionPoint, true))
					{
						return 2;
					}
					interactionPoint.RemoveFromQueue(self);
					self.InQueue.Remove("Tray");
				}
			}
		}
		InteractionPoint result = null;
		int plates = -1;
		bool queued = true;
		_assignedCooksRooms.Clear();
		_assignedCooksRooms.AddRange(self.GetAssignedRooms());
		self.UpdateCurrentRoom();
		List<KeyValuePair<Room, int>> connectedRooms = GameSettings.Instance.sRoomManager.GetConnectedRooms(self.currentRoom);
		for (int i = 0; i < connectedRooms.Count; i++)
		{
			KeyValuePair<Room, int> keyValuePair = connectedRooms[i];
			if (keyValuePair.Value > 4)
			{
				if (!any && !NotificationManager.CheckAggregate<MissingStaffFurnitureNotification>(self, "Tray".GetUHash()))
				{
					NotificationManager.AddNotification(new MissingStaffFurnitureNotification("ServingTrayMissing".Loc(), "ServingTrayMissingHint".Loc(), "Fork", "Tray", self));
				}
				if (!result.IsReferenceNull())
				{
					break;
				}
				return 0;
			}
			CheckRoomForTray(self, keyValuePair.Key, ref result, ref plates, ref queued, ref any, keyValuePair.Value == 0);
			if (result != null && !queued && (_assignedCooksRooms.Count == 0 || _assignedCooksRooms.Contains(keyValuePair.Key)))
			{
				break;
			}
		}
		if (!result.IsReferenceNull())
		{
			if (queued)
			{
				result.AddToQueue(self);
				self.InQueue["Tray"] = result;
				return 0;
			}
			if (!self.PathToFurniture(result, true))
			{
				return 0;
			}
			return 2;
		}
		if (!any && !NotificationManager.CheckAggregate<MissingStaffFurnitureNotification>(self, "Tray".GetUHash()))
		{
			NotificationManager.AddNotification(new MissingStaffFurnitureNotification("ServingTrayMissing".Loc(), "ServingTrayMissingHint".Loc(), "Fork", "Tray", self));
		}
		return 0;
	}

	private static int WaitForTray(Actor self)
	{
		if (self.QueuedFor("Tray"))
		{
			InteractionPoint interactionPoint = self.InQueue["Tray"];
			if (interactionPoint == null)
			{
				self.InQueue.Remove("Tray");
			}
			else
			{
				if (!self.IsUp("Tray"))
				{
					self.TrashUpdate(Time.deltaTime * GameSettings.GameSpeed, 2, 30f);
					self.SetAnim(Actor.AnimationStates.Idle);
					return 1;
				}
				if (!interactionPoint.Usable())
				{
					interactionPoint.RemoveFromQueue(self);
					self.InQueue.Remove("Tray");
				}
				else
				{
					if (self.PathToFurniture(interactionPoint, true))
					{
						return 2;
					}
					interactionPoint.RemoveFromQueue(self);
					self.InQueue.Remove("Tray");
				}
			}
		}
		return 0;
	}

	private static void CheckRoomForTray(Actor self, Room r, ref InteractionPoint result, ref int plates, ref bool queued, ref bool any, bool currentRoom)
	{
		if (!r.Accessible || r.NavmeshRebuildStarted)
		{
			return;
		}
		HashList<Furniture> furniture = r.GetFurniture("Tray");
		float num = float.MaxValue;
		for (int i = 0; i < furniture.Count; i++)
		{
			any = true;
			Furniture furniture2 = furniture[i];
			InteractionPoint interactionPoint = furniture2.GetInteractionPoint(self, InteractionPoint.ActionType.Serve);
			if (interactionPoint != null)
			{
				float num2 = (currentRoom ? (self.ActualPosition.FlattenVector3() - interactionPoint.Point).sqrMagnitude : float.MaxValue);
				if (((result == null) | queued) || (currentRoom && num2 < num) || (!currentRoom && furniture2.HasHoldables < plates))
				{
					queued = false;
					result = interactionPoint;
					plates = furniture2.HasHoldables;
					num = num2;
					if (!currentRoom && plates == 0)
					{
						break;
					}
				}
			}
			else if (result == null)
			{
				InteractionPoint queueableInteractionPoint = furniture2.GetQueueableInteractionPoint(self, InteractionPoint.ActionType.Serve);
				if (queueableInteractionPoint != null)
				{
					result = queueableInteractionPoint;
					plates = furniture2.HasHoldables;
				}
			}
		}
	}

	private static int GotoTray(Actor self)
	{
		int num = ((!self.WalkPath()) ? 1 : 2);
		if (num == 2)
		{
			if (!(self.Holding[0] != null) || !(self.UsingPoint != null))
			{
				self.UsingPoint = null;
				self.SetAnim(Actor.AnimationStates.Idle);
				if (!(self.Holding[0] != null))
				{
					return 2;
				}
				return 0;
			}
			bool flag = true;
			FoodAssemblyInput component = self.UsingPoint.Parent.GetComponent<FoodAssemblyInput>();
			if (component != null)
			{
				if (component.CanReceive())
				{
					self.TurnToFurniture();
					AchievementController.SetInteraction(AchievementController.Mechanics.Canteen);
					component.ReceiveInput(self.Holding[0]);
					flag = false;
				}
			}
			else if (self.UsingPoint.Parent.CanPlaceHoldable())
			{
				self.TurnToFurniture();
				if (!self.UsingPoint.Parent.PlaceHoldable(self.Holding[0]))
				{
					return 0;
				}
				AchievementController.SetInteraction(AchievementController.Mechanics.Canteen);
				self.LeaveItem(self.Holding[0]);
				flag = false;
			}
			if (flag)
			{
				self.UsingPoint = null;
				self.SetAnim(Actor.AnimationStates.Idle);
				if (!(self.Holding[0] != null))
				{
					return 2;
				}
				return 0;
			}
		}
		return num;
	}

	private static int CookLoiter(Actor self)
	{
		if (self.CurrentPath != null)
		{
			if (self.WalkPath())
			{
				self.TurnToFurniture();
			}
			return 1;
		}
		if (self.UsingPoint == null || !self.UsingPoint.Parent.Type.Equals("Stove"))
		{
			if (self.Reserved != null)
			{
				InteractionPoint interactionPoint = self.Reserved.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
				if (interactionPoint != null && self.PathToFurniture(interactionPoint, false))
				{
					return 1;
				}
			}
			if (self.SickDays > 3)
			{
				return 0;
			}
		}
		if (self.Reserved != null && self.Reserved.HasHoldables > 0)
		{
			self.TrashUpdate(Time.deltaTime * GameSettings.GameSpeed, 2, 30f);
		}
		self.SetAnim(Actor.AnimationStates.Idle);
		return self.WaitForTimer(5f);
	}

	private static int HasCopies(Actor self)
	{
		if (self.Boxes < Mathf.Min(MaxBoxCarry, MaxBoxes / GameSettings.DaysPerMonth - self.BoxesShipped))
		{
			return 0;
		}
		return 2;
	}

	private static int GotoPort(Actor self)
	{
		if (self.CurrentPath != null)
		{
			if (self.ReservedPort == null)
			{
				self.ClearPath();
				return 0;
			}
			if (self.WalkPath())
			{
				self.InitiateTurn(self.ReservedPort.GetInteractionPoint(InteractionPoint.ActionType.Visit, true).Rotation);
				return 2;
			}
			return 1;
		}
		InteractionPoint garagePort = GetGaragePort(self);
		if (garagePort != null)
		{
			self.ReservedPort = garagePort.Parent;
			if (!self.PathToPoint(garagePort.transform.position + UnityEngine.Random.Range(-0.5f, 0.5f) * garagePort.transform.right, true))
			{
				return 0;
			}
			return 1;
		}
		return 0;
	}

	private static InteractionPoint GetGaragePort(Actor self)
	{
		InteractionPoint result = null;
		float num = float.MaxValue;
		Vector2 vector = self.ActualPosition.FlattenVector3();
		int floor = self.GetFloor();
		for (int i = 0; i < GameSettings.Instance.GaragePorts.Count; i++)
		{
			Furniture furniture = GameSettings.Instance.GaragePorts[i];
			if (!(furniture != null) || furniture.Pallet.CurrentAmount <= 0)
			{
				continue;
			}
			InteractionPoint interactionPoint = furniture.GetInteractionPoint(InteractionPoint.ActionType.Visit);
			if (!(interactionPoint != null))
			{
				continue;
			}
			float num2 = (furniture.transform.position.FlattenVector3() - vector).sqrMagnitude / (float)(furniture.Pallet.CurrentAmount * furniture.Pallet.CurrentAmount);
			if (num2 < 1024f)
			{
				float num3 = num2 * (float)(Mathf.Abs(floor - furniture.GetFloor()) + 1) * 64f;
				if (num3 < num)
				{
					num = num3;
					result = interactionPoint;
				}
			}
		}
		return result;
	}

	private static int TakePort(Actor self)
	{
		if (self.ReservedPort == null)
		{
			return 2;
		}
		int num = self.WaitForTimer(0.5f);
		if (num == 2)
		{
			int maxCarry = GetMaxCarry(self);
			self.SetAnim(Actor.AnimationStates.Idle);
			if (maxCarry > 0)
			{
				int boxes;
				ProductPrintOrder productPrintOrder = self.ReservedPort.Pallet.Take(out boxes, maxCarry);
				if (boxes > 0)
				{
					if (self.Order == null)
					{
						self.Order = productPrintOrder;
					}
					else
					{
						self.Order.MergeWith(productPrintOrder);
					}
					if (self.OnCall)
					{
						GameSettings.Instance.MyCompany.MakeTransaction(-125f * (float)boxes, Company.TransactionCategory.Staff, true, "On call");
					}
					self.Boxes += boxes;
					UpdateBoxes(self);
				}
			}
			self.ReservedPort = null;
		}
		else
		{
			self.SetAnim(Actor.AnimationStates.PickBox);
		}
		return num;
	}

	private static int GotoPallet(Actor self)
	{
		int num = self.GoToFurniture("Pallet", InteractionPoint.ActionType.Use, -1, false, null, false, true, (Furniture x) => x != null && x.Pallet.CurrentAmount > 0);
		if (num == 2)
		{
			self.TurnToFurniture();
		}
		return num;
	}

	private static int GetMaxCarry(Actor self)
	{
		if (self.OnCall)
		{
			return MaxBoxCarry - self.Boxes;
		}
		return Mathf.Min(MaxBoxCarry, MaxBoxes / GameSettings.DaysPerMonth - self.BoxesShipped) - self.Boxes;
	}

	private static void UpdateBoxes(Actor self)
	{
		if (self.Boxes == 0)
		{
			if (self.Holding[0] != null)
			{
				self.LeaveItem(self.Holding[0], true);
			}
			return;
		}
		if (self.Holding[0] == null)
		{
			self.GetItem("Boxes", true);
		}
		self.Holding[0].SetUVX(Mathf.Max(1f / 3f, (float)self.Boxes / (float)MaxBoxCarry));
	}

	private static int ShouldLoiter(Actor self)
	{
		if ((self.LeaveWhenDone || self.OnCall) && GameSettings.Instance.ProductPallets.None((ProductPallet x) => x.StaticBox && x.CurrentAmount > 0))
		{
			self.GoHomeNow = true;
			return 0;
		}
		return 2;
	}

	private static int CourierLoiter(Actor self)
	{
		self.SocialFactor += Time.deltaTime * GameSettings.GameSpeed;
		if (self.SocialFactor > 10f && self.Order != null && self.Order.TotalCopies != 0)
		{
			self.UsingPoint = null;
			self.ClearLoiterTable();
			self.ClearPath();
			return 0;
		}
		return Loiter(self);
	}

	private static void ClearCourierLoiter(Actor self)
	{
		self.SocialFactor = 0f;
		ClearLoiterTable(self);
	}

	private static int TakePallet(Actor self)
	{
		if (self.UsingPoint == null)
		{
			return 2;
		}
		int num = self.WaitForTimer(0.5f);
		if (num == 2)
		{
			int maxCarry = GetMaxCarry(self);
			self.SetAnim(Actor.AnimationStates.Idle);
			if (maxCarry > 0)
			{
				int boxes;
				ProductPrintOrder productPrintOrder = self.UsingPoint.Parent.Pallet.Take(out boxes, maxCarry);
				if (boxes > 0)
				{
					if (self.Order == null)
					{
						self.Order = productPrintOrder;
					}
					else
					{
						self.Order.MergeWith(productPrintOrder);
					}
					if (self.OnCall)
					{
						GameSettings.Instance.MyCompany.MakeTransaction(-125f * (float)boxes, Company.TransactionCategory.Staff, true, "On call");
					}
					self.Boxes += boxes;
					UpdateBoxes(self);
				}
			}
			self.UsingPoint = null;
		}
		else
		{
			self.SetAnim(Actor.AnimationStates.PickBox);
		}
		return num;
	}

	private static int AnyCopies(Actor self)
	{
		if (self.Order == null || self.Order.TotalCopies == 0)
		{
			return 0;
		}
		return 2;
	}

	private static int GotoVan(Actor self)
	{
		if (self.MyCar == null)
		{
			self.ClearPath();
			self.BoxesShipped += self.Boxes;
			self.Boxes = 0;
			if (self.Order != null)
			{
				UpdateBoxes(self);
				GameSettings.Instance.RegisterStat("PrintsShipped", self.Order.TotalCopies);
				self.Order.Apply();
			}
			self.Order = new ProductPrintOrder();
			return 2;
		}
		if (self.CurrentPath == null)
		{
			if (self.PathToPoint(self.MyCar.SpawnPoints[2].transform.position, true))
			{
				FixCarPath(self.CurrentPath, self.MyCar.SpawnPoints[2].transform.forward);
				return 1;
			}
			self.BoxesShipped += self.Boxes;
			self.Boxes = 0;
			if (self.Order != null)
			{
				UpdateBoxes(self);
				GameSettings.Instance.RegisterStat("PrintsShipped", self.Order.TotalCopies);
				self.Order.Apply();
			}
			self.Order = new ProductPrintOrder();
			return 2;
		}
		if (self.WalkPath())
		{
			self.transform.rotation = self.MyCar.SpawnPoints[2].transform.rotation;
			return 2;
		}
		return 1;
	}

	private static int DropProducts(Actor self)
	{
		if (self.MyCar == null)
		{
			self.ClearPath();
			self.BoxesShipped += self.Boxes;
			self.Boxes = 0;
			UpdateBoxes(self);
			if (self.Order != null)
			{
				GameSettings.Instance.RegisterStat("PrintsShipped", self.Order.TotalCopies);
				self.Order.Apply();
			}
			self.Order = new ProductPrintOrder();
			return 2;
		}
		if (self.MyCar.SpawnPoints[2].OpenAmount == 0f)
		{
			self.SetAnim(Actor.AnimationStates.OpenVan);
		}
		else if (self.MyCar.SpawnPoints[2].OpenAmount == 1f)
		{
			self.SetAnim(Actor.AnimationStates.Idle);
			self.ClearPath();
			self.BoxesShipped += self.Boxes;
			self.Boxes = 0;
			if (self.Order != null)
			{
				UpdateBoxes(self);
				GameSettings.Instance.RegisterStat("PrintsShipped", self.Order.TotalCopies);
				self.Order.Apply();
			}
			self.Order = new ProductPrintOrder();
			self.MyCar.SpawnPoints[2].CloseDoor();
			return 2;
		}
		return 1;
	}

	private static int CourierIsOff(Actor self)
	{
		if (!self.OnCall)
		{
			self.GoHomeNow |= self.BoxesShipped >= MaxBoxes / GameSettings.DaysPerMonth;
		}
		if (self.GoHomeNow)
		{
			if (self.UsingPoint != null)
			{
				self.UsingPoint.UsedBy = null;
				self.UsingPoint = null;
			}
			return 2;
		}
		return 0;
	}

	public bool HasFlag(NodeFlag f)
	{
		return CurrentNodeFlags.HasFlag(f);
	}

	public AI(Actor target, Dictionary<string, BehaviorNode> tree)
	{
		Target = target;
		BehaviorNodes = tree;
		Initialize();
	}

	public static bool IsStaff(AIType type)
	{
		switch (type)
		{
		case AIType.Janitor:
		case AIType.Cleaning:
		case AIType.IT:
		case AIType.Receptionist:
		case AIType.Cook:
		case AIType.Courier:
		case AIType.Security:
			return true;
		default:
			return false;
		}
	}

	public void Initialize()
	{
		if (root != null)
		{
			ResetSimulation();
			return;
		}
		root = BehaviorNodes["Spawn"];
		ResetSimulation();
	}

	public void RunSimulation()
	{
		if (currentNode == null)
		{
			return;
		}
		int num = 0;
		do
		{
			if (num > 25)
			{
				Debug.LogError("AI went for infinite loop in state " + currentNode.Name);
				break;
			}
			LastResult = currentNode.Run(Target);
			if (LastResult == 0)
			{
				currentNode = currentNode.Failure;
			}
			if (LastResult == 2)
			{
				currentNode = currentNode.Success;
			}
			num++;
		}
		while (currentNode != null && !currentNode.Atomic);
		if (Target.DummyCount > 10)
		{
			Debug.Log(string.Concat("AI ", Target.AItype, " has been running Dummy behaviour for 10 cycles, resetting"), Target);
			Target.DummyCount = 0;
			Target.ResetState();
		}
		else if (currentNode != DummyNode)
		{
			Target.DummyCount = 0;
		}
	}

	public void ResetSimulation()
	{
		currentNode = root;
	}

	public static AI LoadAI(Actor target, AIType type)
	{
		return new AI(target, GameData.AITrees[type.ToString()]);
	}

	private static int Spawn(Actor self)
	{
		self.HasFridged = false;
		self.ClearLoiterTable();
		for (int i = 0; i < self.Courses.Count; i++)
		{
			KeyValuePair<Employee.EmployeeRole, string> keyValuePair = self.Courses[i];
			self.employee.AddSpecialization(keyValuePair.Key, keyValuePair.Value);
		}
		if (self.employee.HasTrait(Employee.Trait.NightOwl) && SDateTime.Now().Hour.IsBetween(5, 9))
		{
			self.NightOwlDebuff = 1f;
		}
		if (self.WasSick)
		{
			self.GermAdd = UnityEngine.Random.value.MapRange(0f, 1f, 1f / 6f, 1f / 24f);
		}
		if (self.employee.HasTrait(Employee.Trait.WalkInstead))
		{
			self.SetTraitView(Employee.Trait.WalkInstead, 0, 30, true);
		}
		self.Courses.Clear();
		if (self.Despawned)
		{
			self.employee.Spawn();
			self.SpecialState = Actor.HomeState.Default;
			self.Despawned = false;
		}
		if (self.CurrentPath == null)
		{
			return 2;
		}
		if (!self.WalkPath())
		{
			return 1;
		}
		return 2;
	}

	private static int CanWork(Actor self)
	{
		if (self.GoHomeNow)
		{
			return 0;
		}
		if (self.GoToFurniture("Computer", InteractionPoint.ActionType.Use, -1, false) > 0)
		{
			return 2;
		}
		return 0;
	}

	private static int CanWorkNow(Actor self)
	{
		if (self.GoToFurniture("Computer", InteractionPoint.ActionType.Use, -1, false) == 2)
		{
			return 2;
		}
		return 0;
	}

	private static int GoToDesk(Actor self)
	{
		int num = self.GoToFurniture("Computer", InteractionPoint.ActionType.Use, -1, false);
		if (num == 2)
		{
			if (self.UsingPoint == null)
			{
				return 0;
			}
			if (!self.HasFridged && !self.employee.Founder && !self.employee.HasDemanded(LeadDesignDemands.Demand.LuxuryMeal))
			{
				List<InteractionPoint> list = self.FindFurniture("Minifridge", InteractionPoint.ActionType.Use, 3, null, false, (Furniture x) => x.GetStockLeft() < x.Capacity, false, -1f, false, false, true);
				if (list.Count > 0)
				{
					Furniture parent = list[0].Parent;
					parent.AddStock();
					self.ReservedFridge = parent;
				}
				self.HasFridged = true;
			}
			self.UsingPoint.Parent.Reserved = self;
			if (self.coffee != null)
			{
				Furniture parent2 = self.UsingPoint.Parent.SnappedTo.Parent;
				if (parent2.Table != null)
				{
					Holdable coffee = self.coffee;
					parent2.Table.PlaceHoldable(coffee, self.UsingPoint.Parent.SnappedTo);
					self.LeaveItem(coffee);
				}
			}
			self.TurnToFurniture();
		}
		return num;
	}

	private static int IsOff(Actor self)
	{
		if (self.GoHomeNow)
		{
			if (!self.WagePaid)
			{
				float realSalary = self.GetRealSalary();
				if (realSalary > 0f)
				{
					if (self.employee.HasDemanded(LeadDesignDemands.Demand.FixedRate))
					{
						GameSettings.Instance.SalaryDue += realSalary * 8f / (float)GameSettings.DaysPerMonth;
					}
					else
					{
						SDateTime now = SDateTime.Now();
						int num = Mathf.RoundToInt(SDateTime.GetHours(self.MeetingTime, now));
						int workHours = self.GetWorkHours();
						if (Mathf.Abs(num - workHours) == 1)
						{
							num = workHours;
						}
						realSalary = (float)num * realSalary / (float)GameSettings.DaysPerMonth;
						float benefitValue = self.GetBenefitValue("NightShiftCompensation");
						if (benefitValue > 0f)
						{
							float percentLateNight = Utilities.GetPercentLateNight(self.MeetingTime.HourFraction, now.HourFraction);
							if (percentLateNight > 0f)
							{
								GameSettings.Instance.NightSalaryDue += realSalary * benefitValue * percentLateNight;
							}
						}
						GameSettings.Instance.SalaryDue += realSalary;
					}
				}
				self.WagePaid = true;
			}
			if (self.UsingPoint != null)
			{
				self.ShutdownPC();
				self.UsingPoint.UsedBy = null;
				self.UsingPoint = null;
			}
			Furniture furniture = null;
			foreach (Furniture item in self.ReservedFurniture)
			{
				if ("Computer".Equals(item.Type))
				{
					furniture = item;
					break;
				}
			}
			if (furniture != null && furniture.Reserved == self)
			{
				furniture.Reserved = null;
			}
			Team team = self.GetTeam();
			if (team != null)
			{
				for (int i = 0; i < team.WorkItems.Count; i++)
				{
					SoftwareWorkItem obj = team.WorkItems[i] as SoftwareWorkItem;
					if (obj != null)
					{
						obj.RemoveWorking(self.employee);
					}
				}
			}
			self.ClearPath();
			return 2;
		}
		return 0;
	}

	private static int Despawn(Actor self)
	{
		self.MakeUnIdle();
		self.GermAdd = 0f;
		self.ClearLoiterTable();
		self.CleanUpEating();
		if (self.coffee != null)
		{
			self.LeaveItem(self.coffee.GetComponent<Holdable>(), true);
		}
		foreach (InteractionPoint value in self.InQueue.Values)
		{
			value.RemoveFromQueue(self);
		}
		if ((bool)self.ReservedFridge)
		{
			self.ReservedFridge.SubtractUnit();
			self.ReservedFridge = null;
		}
		self.InQueue.Clear();
		self.Despawned = true;
		GameSettings.Instance.sRoomManager.ClearReservations(self);
		if (self.employee.Dismissed || self.employee.MyEmployer != GameSettings.Instance.MyCompany)
		{
			self.enabled = false;
			self.DestroyGO();
			return 2;
		}
		SDateTime date = SDateTime.Now();
		if (self.SpawnTime <= date.Hour)
		{
			date += new SDateTime(1, 0, 0);
		}
		if (!self.TakingCourses)
		{
			if (date.Month == 5 && date.Day == 0 && GameSettings.Instance.ConferenceController.IsInBooth(self.employee))
			{
				date += new SDateTime(1, 0, 0);
			}
			else if (!self.employee.Dismissed && self.employee.GetAgeMonth() >= Employee.RetirementAge * 12 - 1)
			{
				self.SpecialState = Actor.HomeState.Retired;
				self.QuitAffectTeam(true, 0.1f);
				HUD.Instance.insuranceWindow.AddTermination(new EmployeeTermination(self, EmployeeTermination.TerminationType.Retired, self.RetirementFund), self);
				self.employee.Retired = true;
				self.Dismiss(false);
			}
			else if (!self.employee.Dismissed)
			{
				bool wasSick = self.WasSick;
				self.WasSick = false;
				int chance = (self.employee.Founder ? int.MaxValue : Mathf.CeilToInt(self.employee.ModTrait(Employee.Trait.Hypochondriac, 18f, 24f) / (Mathf.Min(self.employee.JobSatisfaction, self.employee.Stress).MapRange(0f, 0.5f, 1.5f, 1f, true) * self.employee.Posture.MapRange(0f, 0.75f, 2f, 1f, true) * self.AirQuality.MapRange(0f, 0.8f, 3f, 1f, true))));
				int num = ((!self.employee.Founder) ? Mathf.RoundToInt(self.GetBenefitValue("Vacation months")) : 0);
				bool flag = false;
				if (num > 0 && self.AlternateVacation < SDateTime.Now() + new SDateTime(0, 0, 1, 0, 0))
				{
					date += new SDateTime(0, num, 0);
					self.employee.AddInstantMood("GoodVacation", self, (float)num / 6f);
					self.SpecialState = Actor.HomeState.Vacation;
					self.IgnoreOffSalary = true;
					if (self.Team != null)
					{
						self.ScheduleVacation(true);
					}
					GameSettings.Instance.Vacations.Add(self);
					flag = true;
				}
				if (!flag)
				{
					SDateTime time = SDateTime.Now().Simplify();
					bool flag2 = self.GermCount > 0f && Utilities.GetRandomNumber(self.employee.Name, time.ToInt()) < self.GermCount;
					bool num2 = !wasSick && (flag2 || (!self.employee.Founder && Utilities.GetRandomChance(time, self.employee.Name, 5164, chance)));
					if (flag2 && GameSettings.Instance.MissedSink > 0 && !NotificationManager.CheckAggregate<SinkWarningNotification>(null))
					{
						NotificationManager.AddNotification(new SinkWarningNotification());
					}
					if (num2)
					{
						if (self.employee.HasTrait(Employee.Trait.JustTheFlu))
						{
							self.WasSick = true;
						}
						else
						{
							date += new SDateTime(1, 0, 0);
							self.SickDays++;
							self.SpecialState = Actor.HomeState.Sick;
							TimeOfDay.Instance.AddToSick(self);
							GameSettings.Instance.RegisterStat("Sickdays", 1f);
						}
					}
					else if (!self.employee.Founder && self.AItype == AIType.Employee && (SDateTime.Now() - self.employee.Hired).Year >= 2 && Utilities.GetRandomChance(SDateTime.Now().SimplifyMore(), self.employee.Name, 1337, 10000))
					{
						self.QuitAffectTeam(true, 0.25f);
						if (UnityEngine.Random.value < (self.employee.GetAge() - (float)Employee.Youngest) / (float)(Employee.RetirementAge - Employee.Youngest))
						{
							self.SpecialState = Actor.HomeState.Dead;
							float benefitValue = self.GetBenefitValue("Life insurance");
							GameSettings.Instance.MyCompany.MakeTransaction(0f - benefitValue, Company.TransactionCategory.Benefits, true, "Life insurance");
							HUD.Instance.insuranceWindow.AddTermination(new EmployeeTermination(self, EmployeeTermination.TerminationType.Dead, benefitValue), self);
							self.employee.Retired = true;
							self.Dismiss(false);
						}
						else
						{
							self.SpecialState = Actor.HomeState.Hospitalized;
							float benefitValue2 = self.GetBenefitValue("Health insurance");
							GameSettings.Instance.MyCompany.MakeTransaction(0f - benefitValue2, Company.TransactionCategory.Benefits, true, "Health insurance");
							HUD.Instance.insuranceWindow.AddTermination(new EmployeeTermination(self, EmployeeTermination.TerminationType.Hospitalized, benefitValue2), self);
							self.employee.Retired = true;
							self.Dismiss(false);
						}
					}
					self.GermCount = 0f;
				}
			}
			if (date.Month == 5 && date.Day == 0 && GameSettings.Instance.ConferenceController.IsInBooth(self.employee))
			{
				date += new SDateTime(1, 0, 0);
			}
			GameSettings.Instance.sActorManager.AddToAwaiting(self, MakeArrivalTime(date, self));
		}
		else if (date.Month == 5 && date.Day == 0 && GameSettings.Instance.ConferenceController.IsInBooth(GameSettings.Instance.MyCompany, self.employee))
		{
			SDateTime? arriveTime = GameSettings.Instance.sActorManager.GetArriveTime(self);
			if (arriveTime.HasValue)
			{
				SDateTime time2 = arriveTime.Value + new SDateTime(1, 0, 0);
				GameSettings.Instance.sActorManager.AddToAwaiting(self, time2, true);
			}
		}
		self.OnDespawn();
		if (self.employee.HasTrait(Employee.Trait.Forgetful) && SDateTime.Now() > self.ForgetfulETA)
		{
			if (self.ForgetfulETA != new SDateTime(0))
			{
				self.employee.LoseSpec();
				self.SetTraitView(Employee.Trait.Forgetful, 24, 0, true);
			}
			self.ForgetfulETA = SDateTime.Now() + UnityEngine.Random.Range(12, 24);
		}
		return 2;
	}

	public static SDateTime MakeArrivalTime(SDateTime date, Actor a)
	{
		int stayHome = a.StayHome;
		a.StayHome = 0;
		return new SDateTime((float)a.SpawnTime - a.MeetingDiff, date.Day + stayHome, date.Month, date.Year);
	}

	private static int Work(Actor self)
	{
		self.CheckMeeting();
		if (self.UsingPoint == null || !self.UsingPoint.Parent.Type.Equals("Computer") || self.UsingPoint.Parent.Broken() || (self.UsingPoint.Parent.OwnedBy != null && self.UsingPoint.Parent.OwnedBy != self))
		{
			return 0;
		}
		self.Noisiness = (self.IsWorking ? 0.5f : 3f);
		self.ShouldWork = true;
		if (self.IsWorking)
		{
			Actor.AnimationStates currentAnimState = self.CurrentAnimState;
			if ((currentAnimState == Actor.AnimationStates.HappyKeyboard || (currentAnimState == Actor.AnimationStates.Work && self.anim.GetFloat("Blend2") <= 0f)) && !self.AudioComp.isPlaying && self.MayPlaySound())
			{
				self.AudioComp.clip = self.KeyboardSFX.GetRandom();
				self.AudioComp.Play();
			}
			self.WorkBoost();
		}
		if (self.IsWorking || Time.realtimeSinceStartup - self.LastWorkTime < 2f)
		{
			self.SetAnim((self.Effectiveness > 2f) ? Actor.AnimationStates.HappyKeyboard : Actor.AnimationStates.Work);
			if (self.IsWorking)
			{
				self.LastWorkTime = Time.realtimeSinceStartup;
			}
		}
		else
		{
			self.SetAnim(self.UsingPoint.Parent.CanLean ? Actor.AnimationStates.SitStill : Actor.AnimationStates.SitHandsdown);
		}
		self.UsingPoint.Parent.IsOn = true;
		if ((!self.HungerFailCheck && IsHungry(self) == 2) || (!self.BladderFailCheck && HasToPee(self) == 2))
		{
			self.Timer = -1f;
			return 2;
		}
		return self.WaitForTimer(UnityEngine.Random.Range(1, 10));
	}

	private static int IsHungry(Actor self)
	{
		if ((double)self.employee.Hunger < 0.35)
		{
			if (self.QueuedFor("Minifridge"))
			{
				if (!self.IsUp("Minifridge") || !(self.InQueue["Minifridge"].UsedBy == null))
				{
					return 0;
				}
				return 2;
			}
			return 2;
		}
		return 0;
	}

	private static int GoToMinifridge(Actor self)
	{
		if (self.ReservedFridge != null)
		{
			if (self.Timer > 0f)
			{
				if (self.UsingPoint == null)
				{
					self.HungerFailCheck = true;
					return 0;
				}
				int num = self.WaitForTimer(self.UsingPoint.Parent.Wait);
				if (num == 2)
				{
					self.UsingPoint.Parent.InteractEnd();
					self.UsingPoint.UsedBy = null;
					self.UsingPoint = null;
					self.ReservedFridge.SubtractUnit();
					self.ReservedFridge = null;
					self.Food = self.GetItem("FoodPlate", true);
					return 2;
				}
				return num;
			}
			if (self.QueuedFor("Minifridge") && !self.IsUp("Minifridge"))
			{
				return 2;
			}
			if (self.CurrentPath != null)
			{
				if (self.WalkPath())
				{
					if (self.UsingPoint != null)
					{
						self.WaitForTimer(self.UsingPoint.Parent.Wait);
						self.SetAnim(self.UsingPoint.Animation);
						self.TurnToFurniture();
						return 1;
					}
					self.ClearPath(false);
					self.HungerFailCheck = true;
					return 0;
				}
				return 1;
			}
			InteractionPoint interactionPoint = self.ReservedFridge.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
			if (interactionPoint != null)
			{
				if (!self.PathToFurniture(interactionPoint, false))
				{
					return 0;
				}
				return 1;
			}
			interactionPoint = self.ReservedFridge.GetQueueableInteractionPoint(self, InteractionPoint.ActionType.Use);
			if (interactionPoint != null)
			{
				interactionPoint.AddToQueue(self);
				self.InQueue["Minifridge"] = interactionPoint;
				return 2;
			}
			self.HungerFailCheck = true;
			return 0;
		}
		self.HungerFailCheck = true;
		return 0;
	}

	private static int HasFood(Actor self)
	{
		if (self.Food == null)
		{
			for (int i = 0; i < self.Holding.Length; i++)
			{
				if (self.Holding[i] != null && self.Holding[i].Type.StartsWith("Food"))
				{
					self.Food = self.Holding[i];
					return 2;
				}
			}
		}
		if (!(self.Food != null))
		{
			return 0;
		}
		return 2;
	}

	private static int GoToServingTray(Actor self)
	{
		int num = self.GoToFurniture("Tray", InteractionPoint.ActionType.Use, -1, false, null, false, false, null, 5625f);
		if (num == 1)
		{
			self.MakeUnIdle();
			if (self.UsingPoint == null)
			{
				InteractionPoint value;
				if (self.WaitingForQueue < 0f || !self.InQueue.TryGetValue("Tray", out value) || value == null || value.Parent.HasHoldables == 0)
				{
					self.RemoveFromQueue("Tray");
					num = self.GoToFurniture("Tray", InteractionPoint.ActionType.Use, -1, false, null, false, false, null, 5625f);
				}
			}
			else if (self.UsingPoint.Parent.HasHoldables == 0)
			{
				self.RemoveFromQueue("Tray");
				self.UsingPoint = null;
				num = self.GoToFurniture("Tray", InteractionPoint.ActionType.Use, -1, false, null, false, false, null, 5625f);
			}
		}
		if (num == 2)
		{
			self.TurnToFurniture();
		}
		self.HungerFailCheck = num == 0;
		return num;
	}

	private static int TakeFoodFromTray(Actor self)
	{
		self.SetAnim(Actor.AnimationStates.Idle);
		if (self.UsingPoint == null || self.UsingPoint.Parent.HasHoldables == 0)
		{
			return 0;
		}
		Holdable holdable = self.UsingPoint.Parent.TakeHoldable();
		if (holdable == null)
		{
			return 0;
		}
		bool flag = false;
		if (self.employee.HasDemanded(LeadDesignDemands.Demand.LuxuryMeal))
		{
			flag = true;
			GameSettings.Instance.MyCompany.MakeTransaction(-3000f / (float)GameSettings.DaysPerMonth, Company.TransactionCategory.Bills, true, "LeadDemandLuxuryMeal");
			if (!holdable.Type.Equals("FoodPlateFancy"))
			{
				holdable.DestroyMe();
				holdable = self.GetItemAnyHand("FoodPlateFancy");
			}
		}
		else
		{
			self.ReTakeItemAnyHand(holdable);
		}
		self.Food = holdable;
		if (!flag && self.GetBenefitValue("Free food") < 0.5f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(100f / (float)GameSettings.DaysPerMonth, Company.TransactionCategory.Bills, true, "Food");
		}
		self.employee.AddInstantMood("GoodFood", self);
		return 2;
	}

	private static int FindPlaceToEat(Actor self)
	{
		if (self.Food == null)
		{
			self.ClearPath();
			self.CleanUpEating();
			return 2;
		}
		self.CheckMeeting(true);
		TableScript tableScript = self.FindFreeTable(Room.RoomLimits.Canteen, true, true, false, 4);
		if (tableScript != null)
		{
			Furniture freeChair = tableScript.GetFreeChair(self, true);
			if (freeChair != null)
			{
				InteractionPoint interactionPoint = freeChair.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
				if (interactionPoint != null && self.PathToFurniture(interactionPoint, false))
				{
					tableScript.ReserveTables(true, true);
					self.LoiterTable = tableScript;
					self.employee.HadProperFood = true;
					return 2;
				}
			}
		}
		if (self.GoToFurniture("Couch", InteractionPoint.ActionType.Use, 4, false) != 0)
		{
			self.employee.HadProperFood = self.UsingPoint.Parent.Parent.ForceRole == -3;
			return 2;
		}
		Furniture furniture = self.ReservedFurniture.FirstOrDefault((Furniture x) => x.Type.Equals("Computer"));
		if (furniture != null && furniture.Parent == self.currentRoom && furniture.ComputerChair != null)
		{
			InteractionPoint interactionPoint2 = furniture.ComputerChair.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
			if (interactionPoint2 != null && self.PathToFurniture(interactionPoint2, false))
			{
				return 2;
			}
		}
		if (!self.currentRoom.Outside)
		{
			if (!self.currentRoom.IsNeutral())
			{
				if (!FindPathToNeutral(self))
				{
					Vector2? vector = self.currentRoom.FindRandomSpot();
					if (vector.HasValue)
					{
						self.PathToPoint(new Vector3(vector.Value.x, self.currentRoom.Floor * 2, vector.Value.y));
					}
				}
			}
			else
			{
				Vector2? vector2 = self.currentRoom.FindRandomSpot();
				if (vector2.HasValue)
				{
					self.PathToPoint(new Vector3(vector2.Value.x, self.currentRoom.Floor * 2, vector2.Value.y));
				}
			}
		}
		self.UsingPoint = null;
		return 2;
	}

	private static int GoToEat(Actor self)
	{
		if (self.WalkPath())
		{
			if (self.Food == null)
			{
				self.CleanUpEating();
				return 0;
			}
			TableScript tableScript = ((!(self.UsingPoint != null)) ? null : ((self.UsingPoint.Parent.SnappedTo != null) ? self.UsingPoint.Parent.SnappedTo.Parent.Table : self.UsingPoint.Parent.Table));
			if (tableScript != null && tableScript.FurnComp.UsableForTableGroup())
			{
				tableScript.PlaceHoldable(self.Food, self.UsingPoint.transform);
				self.LeaveItem(self.Food);
			}
			else
			{
				self.LeaveItem(self.Food);
				self.ReTakeItem(self.Food, false);
			}
			self.GetItem("Spork", true);
			if (self.UsingPoint != null)
			{
				self.TurnToFurniture();
			}
			return 2;
		}
		return 1;
	}

	private static void CleanUpEating(Actor self)
	{
		self.CleanUpEating();
	}

	private static void ResetTimer(Actor self)
	{
		self.Timer = -1f;
	}

	private static int EatRealFood(Actor self)
	{
		if (self.GoHomeNow)
		{
			if (self.Food != null)
			{
				self.Food.DestroyMe();
				self.Food = null;
			}
			return 2;
		}
		bool flag = false;
		if (self.UsingPoint == null)
		{
			self.SetAnim(Actor.AnimationStates.EatStandingUp);
		}
		else
		{
			TableScript tableScript = ((self.UsingPoint.Parent.SnappedTo != null) ? self.UsingPoint.Parent.SnappedTo.Parent.Table : self.UsingPoint.Parent.Table);
			self.SetAnim((self.Holding[1] == self.Food) ? Actor.AnimationStates.EatInHands : Actor.AnimationStates.EatAtTable);
			if (tableScript != null)
			{
				List<Furniture> freeChairs = tableScript.GetFreeChairs();
				int count = freeChairs.Count;
				int num = Utilities.RandomRange(0, count);
				for (int i = 0; i < count; i++)
				{
					int index = (i + num) % count;
					Furniture furniture = freeChairs[index];
					for (int j = 0; j < furniture.InteractionPoints.Length; j++)
					{
						InteractionPoint interactionPoint = furniture.InteractionPoints[j];
						if (interactionPoint.UsedBy != null && interactionPoint.UsedBy != self)
						{
							self.InteractWith(interactionPoint.UsedBy);
							flag = true;
							break;
						}
					}
				}
			}
			else
			{
				int num2 = self.UsingPoint.Parent.InteractionPoints.Length;
				int num3 = Utilities.RandomRange(0, num2);
				for (int k = 0; k < num2; k++)
				{
					int num4 = (k + num3) % num2;
					InteractionPoint interactionPoint2 = self.UsingPoint.Parent.InteractionPoints[num4];
					if (interactionPoint2 != self.UsingPoint && interactionPoint2.Action == InteractionPoint.ActionType.Use && interactionPoint2.UsedBy != null)
					{
						self.InteractWith(interactionPoint2.UsedBy);
						flag = true;
						break;
					}
				}
			}
			self.StressFactor = -4f;
			if (flag)
			{
				self.SocialFactor = -32f * self.currentRoom.Acoustics;
			}
		}
		self.Noisiness = (flag ? 6 : 3);
		self.employee.Hunger = Mathf.Clamp01(self.employee.Hunger + Time.deltaTime * GameSettings.GameSpeed / self.employee.ModTrait(Employee.Trait.SlowEater, 90f, 45f));
		self.RemoveFromQueue("FastFood");
		self.RemoveFromQueue("Tray");
		self.RemoveFromQueue("Minifridge");
		if (self.employee.HasTrait(Employee.Trait.SlowEater))
		{
			self.SetTraitView(Employee.Trait.SlowEater, 0, 5, true);
		}
		self.TrashUpdate(Time.deltaTime * GameSettings.GameSpeed, 2, 30f);
		int num5 = ((self.employee.Hunger != 1f) ? 1 : 2);
		if (num5 == 2 && self.Food != null)
		{
			self.Food.DestroyMe();
			self.Food = null;
		}
		return num5;
	}

	private static int GoToFridge(Actor self)
	{
		if (self.QueuedFor("Tray"))
		{
			return 0;
		}
		if (self.employee.HasDemanded(LeadDesignDemands.Demand.LuxuryMeal))
		{
			self.HungerFailCheck = true;
			return 0;
		}
		int num = self.GoToFurniture("FastFood", InteractionPoint.ActionType.Use, -1, false, null, false, false, (Furniture x) => x.AnyUnitsLeft(), 2500f);
		if (num == 1)
		{
			self.MakeUnIdle();
		}
		if (num == 2)
		{
			if (self.UsingPoint == null)
			{
				return 0;
			}
			self.SetAnim(Actor.AnimationStates.Coffee);
			self.TurnToFurniture();
		}
		self.HungerFailCheck = num == 0;
		return num;
	}

	private static int WantCoffee(Actor self)
	{
		if (self.GoHomeNow || (self.Holding[0] != null && self.Holding[1] != null))
		{
			return 0;
		}
		if (Mathf.Approximately(self.employee.CoffeeQual, 0f))
		{
			if (self.GoToFurniture("Coffee", InteractionPoint.ActionType.Use, 3, false, null, false, false, (Furniture x) => x.AnyUnitsLeft(), 900f) <= 0)
			{
				return 0;
			}
			return 2;
		}
		return 0;
	}

	private static int GoToCoffee(Actor self)
	{
		int num = self.GoToFurniture("Coffee", InteractionPoint.ActionType.Use, 3, false, null, false, false, (Furniture x) => x.AnyUnitsLeft(), 900f);
		if (num > 0)
		{
			self.MakeUnIdle();
		}
		if (num != 0 && self.coffee != null)
		{
			self.ReTakeItem(self.coffee.GetComponent<Holdable>(), true);
		}
		if (num == 2)
		{
			self.TurnToFurniture();
			if (self.coffee == null && self.UsingPoint != null && self.UsingPoint.Parent != null)
			{
				self.UsingPoint.Parent.IsOn = true;
			}
		}
		return num;
	}

	private static int MakeCoffee(Actor self)
	{
		self.CheckMeeting(true);
		if (self.coffee != null)
		{
			Holdable component = self.coffee.GetComponent<Holdable>();
			self.LeaveItem(component, true);
			return 2;
		}
		if (self.UsingPoint == null || !self.UsingPoint.Parent.AnyUnitsLeft())
		{
			self.ClearPath();
			self.Timer = -1f;
			self.AtFurniture = false;
			self.UsingPoint = null;
			return 2;
		}
		self.SetAnim(Actor.AnimationStates.Coffee);
		int num = self.WaitForTimer(self.UsingPoint.Parent.Wait);
		if (num == 2)
		{
			self.coffee = self.GetItemAnyHand("CoffeeCup");
			if (self.coffee != null)
			{
				if (self.UsingPoint.Parent.IsActuallyPlayerControlled() && self.GetBenefitValue("Free food") < 0.5f)
				{
					GameSettings.Instance.MyCompany.MakeTransaction(self.UsingPoint.Parent.UnitCost / (float)GameSettings.DaysPerMonth, Company.TransactionCategory.Bills, true, "Coffee");
				}
				self.UsingPoint.Parent.SubtractUnit();
				self.coffee.MiscValue = 30f;
				float quality = self.UsingPoint.Parent.upg.Quality;
				self.employee.CoffeeQual = self.UsingPoint.Parent.MiscPotential * quality;
				if (quality < 0.5f)
				{
					self.employee.AddInstantMood("BadCoffee", self, (1f - quality * 2f) * (1f / self.UsingPoint.Parent.MiscPotential));
				}
				else
				{
					self.employee.AddInstantMood("GoodCoffee", self, (quality - 0.5f) * 2f * self.UsingPoint.Parent.MiscPotential);
				}
			}
			self.UsingPoint.Parent.IsOn = false;
			self.UsingPoint.UsedBy = null;
			self.UsingPoint = null;
		}
		return num;
	}

	private static int GetFood(Actor self)
	{
		if (self.UsingPoint == null || !self.UsingPoint.Parent.AnyUnitsLeft())
		{
			self.ClearPath();
			self.Timer = -1f;
			self.AtFurniture = false;
			self.UsingPoint = null;
			return 2;
		}
		if (HasFood(self) == 2)
		{
			return 2;
		}
		int num = self.WaitForTimer(2f);
		if (num == 2)
		{
			string itemName = "FoodPlate";
			if (self.employee.HasDemanded(LeadDesignDemands.Demand.LuxuryMeal))
			{
				itemName = "FoodPlateFancy";
				GameSettings.Instance.MyCompany.MakeTransaction(-3000f / (float)GameSettings.DaysPerMonth, Company.TransactionCategory.Bills, true, "LeadDemandLuxuryMeal");
			}
			else if (self.UsingPoint.Parent.IsActuallyPlayerControlled() && self.GetBenefitValue("Free food") < 0.5f)
			{
				GameSettings.Instance.MyCompany.MakeTransaction(self.UsingPoint.Parent.UnitCost / (float)GameSettings.DaysPerMonth, Company.TransactionCategory.Bills, true, "Food");
			}
			self.Food = self.GetItem(itemName, true);
			self.UsingPoint.Parent.SubtractUnit();
			self.SetAnim(Actor.AnimationStates.Idle);
			if (self.UsingPoint != null)
			{
				self.UsingPoint.UsedBy = null;
				self.UsingPoint = null;
			}
		}
		return num;
	}

	private static int HasMakeMeeting(Actor self)
	{
		if (self.Team == null || self.GoHomeNow)
		{
			return 0;
		}
		if (self.employee.IsRole(Employee.RoleBit.Lead))
		{
			if (self.employee.GetSpecialization(Employee.EmployeeRole.Lead, "Socialization") > 2 && (SDateTime.Now() - self.LastMeeting).ToInt() >= 1440)
			{
				TableScript tableScript = self.FindFreeTable(Room.RoomLimits.Meeting, true, false, true);
				if (tableScript != null)
				{
					Furniture freeChair = tableScript.GetFreeChair(self);
					if (freeChair != null)
					{
						InteractionPoint interactionPoint = freeChair.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
						if (interactionPoint != null)
						{
							Team team = self.GetTeam();
							team.MeetingTable = tableScript;
							List<Actor> list = self.CallForMeeting();
							if (list.Count > 0)
							{
								self.ShutdownPC();
								if (self.PathToFurniture(interactionPoint, false))
								{
									self.UsingPoint = interactionPoint;
									self.AtFurniture = false;
									team.MeetingTable.ReserveTables(true);
									self.Timer = 60f;
									team.Talking = self;
									team.Meeting.AddRange(list);
									team.Meeting.Add(self);
									team.SetMeetingStatus(Team.MeetingStatus.OK);
									return 2;
								}
								team.SetMeetingStatus(Team.MeetingStatus.Blocked);
							}
							else
							{
								team.SetMeetingStatus(Team.MeetingStatus.OK);
							}
							team.MeetingTable = null;
						}
					}
					else
					{
						self.GetTeam().SetMeetingStatus(Team.MeetingStatus.NoPlace);
					}
					return 0;
				}
				self.GetTeam().SetMeetingStatus(Team.MeetingStatus.NoPlace);
			}
		}
		else if (self.GetTeam().Meeting.Contains(self) && self.GetTeam().MeetingTable != null)
		{
			Furniture freeChair2 = self.GetTeam().MeetingTable.GetFreeChair(self);
			if (freeChair2 != null)
			{
				InteractionPoint interactionPoint2 = freeChair2.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
				if (interactionPoint2 != null)
				{
					self.ShutdownPC();
					bool num = self.PathToFurniture(interactionPoint2, false);
					if (num)
					{
						self.UsingPoint = interactionPoint2;
						self.AtFurniture = false;
					}
					if (!num)
					{
						return 0;
					}
					return 2;
				}
			}
		}
		return 0;
	}

	private static int GoToMeeting(Actor self)
	{
		int num = self.GoToFurniture("Chair", InteractionPoint.ActionType.Use, -1, false);
		if (num > 0)
		{
			self.MakeUnIdle();
		}
		if (num == 2)
		{
			self.TurnToFurniture();
		}
		return num;
	}

	private static int HaveMeeting(Actor self)
	{
		self.CheckMeeting(true);
		if (self.Team == null)
		{
			return 2;
		}
		Team team = self.GetTeam();
		bool flag = false;
		if (team.Talking == self)
		{
			for (int i = 0; i < team.Meeting.Count; i++)
			{
				Actor actor = team.Meeting[i];
				if (actor != self && actor.AIScript.HasFlag(NodeFlag.InMeeting))
				{
					flag = true;
				}
			}
		}
		self.SocialFactor = -16f * Mathf.Max(0f, self.TeamCompatibility) * self.currentRoom.Acoustics;
		self.Noisiness = (flag ? 6 : 3);
		self.SetAnim(flag ? Actor.AnimationStates.Talk : Actor.AnimationStates.SitStill);
		if (flag && !self.AudioComp.isPlaying)
		{
			if (self.IsTalking)
			{
				if (team.MeetingTable != null)
				{
					team.Talking = team.Meeting.GetRandomWhere((Actor x) => x.AIScript.HasFlag(NodeFlag.InMeeting));
				}
				self.IsTalking = false;
			}
			else if (self.MayPlaySound())
			{
				self.AudioComp.clip = (self.Female ? self.FemaleTalkSFX.GetRandom() : self.TalkSFX.GetRandom());
				self.AudioComp.Play();
				self.IsTalking = true;
			}
		}
		if (self.employee.IsRole(Employee.RoleBit.Lead))
		{
			if (team.MeetingTable == null)
			{
				team.Meeting.Clear();
				self.LastMeeting = SDateTime.Now();
				return 2;
			}
			self.Timer -= Time.deltaTime * GameSettings.GameSpeed;
			if (self.Timer <= 0f)
			{
				team.MeetingTable.ReserveTables(false);
				team.MeetingTable = null;
				for (int num = 0; num < team.Meeting.Count; num++)
				{
					for (int num2 = num + 1; num2 < team.Meeting.Count; num2++)
					{
						team.Meeting[num].InteractWith(team.Meeting[num2]);
					}
				}
				team.Meeting.Clear();
				self.LastMeeting = SDateTime.Now();
				return 2;
			}
			self.MeetingBoost();
			return 1;
		}
		if (team.MeetingTable != null && (team.Leader == null || !team.Leader.isActiveAndEnabled))
		{
			team.MeetingTable.ReserveTables(false);
			team.MeetingTable = null;
			team.Meeting.Clear();
		}
		if (team.MeetingTable != null)
		{
			self.MeetingBoost();
			return 1;
		}
		self.LastMeeting = SDateTime.Now();
		return 2;
	}

	private static int HasToPee(Actor self)
	{
		if (self.GoHomeNow || !((double)self.employee.Bladder < 0.2))
		{
			return 0;
		}
		return 2;
	}

	private static int GoToToilet(Actor self)
	{
		if (self.CurrentPath != null && self.UsingPoint != null && self.UsingPoint.Parent.Type.Equals("Toilet"))
		{
			PathVector pathVector = self.CurrentPath[Mathf.Min(self.CurrentPath.Count - 1, self.CurrentPathNode + 1)];
			if (GameSettings.Instance.sRoomManager.GetRoomFromPoint(pathVector) == self.UsingPoint.Parent.Parent && self.UsingPoint.Parent.Parent.Occupants.Any((Actor x) => x != self))
			{
				self.SetAnim(Actor.AnimationStates.Idle);
				self.Timer += Time.deltaTime * GameSettings.GameSpeed;
				if (self.Timer > 30f || self.currentRoom == self.UsingPoint.Parent.Parent)
				{
					self.Timer = -1f;
					self.UsingPoint = null;
					self.ClearPath();
					return 0;
				}
				return 1;
			}
		}
		int num = self.GoToFurniture("Toilet", InteractionPoint.ActionType.Use, -1, false, null, false, false, null, 2500f);
		if (num == 2)
		{
			if (self.UsingPoint == null)
			{
				return 0;
			}
			self.CensorRend.SetActive(true);
			self.SetAnim(Actor.AnimationStates.SitHandsdown);
			self.TurnToFurniture();
			self.UsingPoint.Parent.IsOn = true;
			self.UsingPoint.Parent.InteractStart();
		}
		if (num == 1)
		{
			self.MakeUnIdle();
		}
		self.BladderFailCheck = num == 0;
		return num;
	}

	private static int DoBusiness(Actor self)
	{
		self.CheckMeeting(true);
		if (self.UsingPoint == null)
		{
			return 2;
		}
		int num = self.WaitForTimer(UnityEngine.Random.Range(2, 4));
		if (self.employee.HasTrait(Employee.Trait.NervousBladder))
		{
			self.SetTraitView(Employee.Trait.NervousBladder, 0, 5, true);
		}
		self.currentRoom.Smell += Utilities.PerHour(120f / self.currentRoom.GetAtriumArea());
		if (num == 2)
		{
			self.UsingPoint.Parent.IsOn = false;
			float quality = self.UsingPoint.Parent.upg.Quality;
			self.employee.Bladder = 1f * quality;
			if (quality < 0.5f)
			{
				self.employee.AddMood("DisgustingToilet", self, Time.deltaTime, 1f - quality);
			}
			if (!self.currentRoom.IsPrivate || self.currentRoom.Occupants.Count > 1)
			{
				self.employee.AddMood("NoToiletPrivacy", self);
			}
			self.UsingPoint.Parent.InteractEnd();
			self.UsingPoint.UsedBy = null;
			self.UsingPoint = null;
			self.GermAdd = UnityEngine.Random.value * (1f / 36f);
		}
		return num;
	}

	private static int GotoSink(Actor self)
	{
		int num = self.GoToFurniture("Sink", InteractionPoint.ActionType.Use, 1, false);
		switch (num)
		{
		case 2:
			if (self.UsingPoint == null)
			{
				return 0;
			}
			self.SetAnim(self.UsingPoint.Animation);
			self.TurnToFurniture();
			self.UsingPoint.Parent.IsOn = true;
			self.UsingPoint.Parent.InteractStart();
			break;
		case 0:
			GameSettings.Instance.MissedSink = 24;
			break;
		}
		return num;
	}

	private static int WashHands(Actor self)
	{
		if (self.UsingPoint == null)
		{
			return 2;
		}
		int num = self.WaitForTimer(UnityEngine.Random.Range(1, 2));
		if (num == 2)
		{
			self.UsingPoint.Parent.IsOn = false;
			if (!self.WasSick)
			{
				self.GermAdd = 0f;
			}
			self.UsingPoint.Parent.InteractEnd();
			self.UsingPoint.UsedBy = null;
			self.UsingPoint = null;
		}
		return num;
	}

	private static int NeedsBath(Actor self)
	{
		if (self.GoHomeNow || !self.BO)
		{
			return 0;
		}
		return 2;
	}

	private static int GotoBath(Actor self)
	{
		InteractionPoint usingPoint = self.UsingPoint;
		int num = self.GoToFurniture("Shower", InteractionPoint.ActionType.Use, -1, false, null, false, false, (Furniture x) => x.Parent.IsPrivate && !x.Parent.ToiletInUse(), 2500f);
		switch (num)
		{
		case 2:
			if (self.UsingPoint == null)
			{
				self.UsingPoint = usingPoint;
				return 0;
			}
			self.CensorRend.SetActive(true);
			self.SetAnim(Actor.AnimationStates.Shower);
			self.TurnToFurniture();
			self.UsingPoint.Parent.IsOn = true;
			self.UsingPoint.Parent.InteractStart();
			ActorGenerator.Instance.SetTorsoPantsColor(self, self.SkinColor);
			break;
		case 1:
			self.MakeUnIdle();
			break;
		default:
			self.UsingPoint = usingPoint;
			break;
		}
		return num;
	}

	private static int TakeBath(Actor self)
	{
		self.CheckMeeting(true);
		if (self.UsingPoint == null)
		{
			return 2;
		}
		int num = self.WaitForTimer(UnityEngine.Random.Range(10, 15));
		if (num == 2)
		{
			self.UsingPoint.Parent.IsOn = false;
			self.BO = false;
			if (!CheckShowerPrivacy(self.currentRoom))
			{
				self.employee.AddMood("NoToiletPrivacy", self);
			}
			self.UsingPoint.Parent.InteractEnd();
			self.UsingPoint.UsedBy = null;
			self.UsingPoint = null;
			if (!self.WasSick)
			{
				self.GermAdd = 0f;
			}
		}
		return num;
	}

	private static void StopCensoring(Actor self)
	{
		self.CensorRend.SetActive(false);
	}

	private static void EndBath(Actor self)
	{
		StopCensoring(self);
		ActorGenerator.Instance.SetTorsoPantsColor(self, self.employee.StyleGen);
	}

	private static bool CheckShowerPrivacy(Room r)
	{
		if (!r.IsPrivate)
		{
			return false;
		}
		for (int i = 0; i < r.Occupants.Count; i++)
		{
			if (r.Occupants[i].UsingPoint != null && !"Shower".Equals(r.Occupants[i].UsingPoint.Parent.Type))
			{
				return false;
			}
		}
		return true;
	}

	private static int NeedsSocial(Actor self)
	{
		if (self.GoHomeNow)
		{
			return 0;
		}
		if ((self.employee.Social < 0.5f || self.employee.Stress == 0f) && (self.Holding[0] == null || "WaterCup".Equals(self.Holding[0].Type)))
		{
			InteractionPoint usingPoint = self.UsingPoint;
			bool atFurniture = self.AtFurniture;
			if (self.GoToFurniture("Watercooler", InteractionPoint.ActionType.Use, 3, false, null, false, false, null, 900f) > 0)
			{
				if (self.ShouldTrySocial())
				{
					self.LastSocial = SDateTime.Now();
					return 2;
				}
				bool flag = false;
				InteractionPoint[] interactionPoints = self.UsingPoint.Parent.InteractionPoints;
				for (int i = 0; i < interactionPoints.Length; i++)
				{
					if (interactionPoints[i].UsedBy != null && interactionPoints[i].UsedBy != self)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					return 2;
				}
				self.AtFurniture = atFurniture;
				self.UsingPoint = usingPoint;
				self.ClearPath(false);
			}
			self.LastSocial = SDateTime.Now();
		}
		return 0;
	}

	private static int GoToSocial(Actor self)
	{
		int num = self.GoToFurniture("Watercooler", InteractionPoint.ActionType.Use, 3, false, null, false, false, null, 900f);
		if (num > 0)
		{
			self.MakeUnIdle();
		}
		if (num == 2)
		{
			self.SetAnim(Actor.AnimationStates.WaterState);
			self.TurnToFurniture();
		}
		return num;
	}

	private static int BeSocial(Actor self)
	{
		self.CheckMeeting(true);
		if (self.GoHomeNow)
		{
			if (self.Holding[0] != null)
			{
				self.LeaveItem(self.Holding[0], true);
			}
			self.IsTalking = false;
			return 2;
		}
		if (self.Holding[0] == null || self.anim.GetCurrentAnimatorStateInfo(0).IsName("Take water"))
		{
			return 1;
		}
		if (self.UsingPoint == null || (self.Team != null && self.GetTeam().MeetingTable != null && self.GetTeam().Meeting.Contains(self)))
		{
			if (self.Holding[0] != null)
			{
				self.LeaveItem(self.Holding[0], true);
			}
			self.IsTalking = false;
			return 2;
		}
		if (self.anim.GetInteger("AnimControl") == 15)
		{
			self.SetAnim(Actor.AnimationStates.WaterState);
		}
		if (self.anim.GetInteger("AnimControl") == 14 && UnityEngine.Random.value < 0.1f * Time.deltaTime * GameSettings.GameSpeed)
		{
			self.SetAnim(Actor.AnimationStates.DrinkWater);
		}
		bool flag = false;
		bool flag2 = self.IsTalking;
		if (self.IsTalking && !self.AudioComp.isPlaying)
		{
			self.SetAnim(Actor.AnimationStates.WaterState);
			self.IsTalking = false;
		}
		InteractionPoint[] interactionPoints = self.UsingPoint.Parent.InteractionPoints;
		for (int i = 0; i < interactionPoints.Length; i++)
		{
			if (interactionPoints[i].UsedBy != null && interactionPoints[i].UsedBy != self && interactionPoints[i].UsedBy.AIScript.currentNode.Name.Equals("BeSocial"))
			{
				flag2 |= interactionPoints[i].UsedBy.IsTalking;
				flag = true;
				self.InteractWith(interactionPoints[i].UsedBy);
			}
		}
		bool flag3 = HasToPee(self) == 2 || IsHungry(self) == 2;
		if (flag)
		{
			if (!flag2 && self.MayPlaySound())
			{
				self.IsTalking = true;
				self.SetAnim(Actor.AnimationStates.TalkWater);
				self.AudioComp.clip = (self.Female ? self.FemaleTalkSFX.GetRandom() : self.TalkSFX.GetRandom());
				self.AudioComp.Play();
			}
			self.Noisiness = (self.IsTalking ? 6 : 3);
			self.SocialFactor = -32f * self.currentRoom.Acoustics;
			if (!flag3 && self.employee.Social < 1f)
			{
				return 1;
			}
		}
		else if (self.IsTalking)
		{
			self.IsTalking = false;
			self.SetAnim(Actor.AnimationStates.WaterState);
			self.AudioComp.Stop();
		}
		if (!flag3 && self.employee.Stress < 0.2f)
		{
			return 1;
		}
		int num = self.WaitForTimer(self.UsingPoint.Parent.Wait);
		if (flag3)
		{
			self.Timer = -1f;
			num = 2;
		}
		if (num == 2)
		{
			if (self.Holding[0] != null)
			{
				self.LeaveItem(self.Holding[0], true);
			}
			self.IsTalking = false;
		}
		return num;
	}

	private static int NeedsSocialLeader(Actor self)
	{
		if (self.GoHomeNow)
		{
			return 0;
		}
		if (self.employee.IsRole(Employee.RoleBit.Lead) && self.GetTeam() != null && self.employee.GetSpecialization(Employee.EmployeeRole.Lead, "Socialization") > 1)
		{
			float num = self.employee.ModTrait(Employee.Trait.BornLeader, 0.5f, 0.25f);
			if (self.employee.Social < num)
			{
				return 2;
			}
			List<Actor> employeesDirect = self.GetTeam().GetEmployeesDirect();
			for (int i = 0; i < employeesDirect.Count; i++)
			{
				Actor actor = employeesDirect[i];
				if (!(actor == self) && actor.gameObject.activeSelf && !(actor.UsingPoint == null) && actor.UsingPoint.Parent.Type.Equals("Computer") && actor.employee.Social < num)
				{
					return 2;
				}
			}
		}
		return 0;
	}

	private static int GoToSocialLeader(Actor self)
	{
		if (self.UsingPoint != null && self.UsingPoint.Action == InteractionPoint.ActionType.Social && self.CurrentPath != null)
		{
			if (self.WalkPath())
			{
				self.TurnToFurniture();
				return 2;
			}
			self.MakeUnIdle();
			return 1;
		}
		if (self.employee.IsRole(Employee.RoleBit.Lead))
		{
			self.Noisiness = 5f;
			foreach (Actor item in from x in self.GetTeam().GetEmployeesDirect()
				orderby x.employee.Social
				select x)
			{
				if (!(item == self) && item.gameObject.activeSelf && item.UsingPoint != null && item.UsingPoint.Parent.Type.Equals("Computer"))
				{
					InteractionPoint interactionPoint = item.UsingPoint.Parent.GetInteractionPoint(self, InteractionPoint.ActionType.Social);
					if (interactionPoint != null && self.PathToFurniture(interactionPoint, false))
					{
						self.MakeUnIdle();
						return 1;
					}
				}
			}
		}
		return 0;
	}

	private static int BeSocialLeader(Actor self)
	{
		if (self.UsingPoint == null || self.GoHomeNow || !self.employee.IsRole(Employee.RoleBit.Lead))
		{
			self.UsingPoint = null;
			return 2;
		}
		Actor usedBy = self.UsingPoint.Parent.GetInteractionPoint(InteractionPoint.ActionType.Use, true).UsedBy;
		if (usedBy == null)
		{
			self.UsingPoint = null;
			return 2;
		}
		self.InteractWith(usedBy);
		self.SetAnim(Actor.AnimationStates.StandUpTalking);
		if (!self.AudioComp.isPlaying && self.MayPlaySound())
		{
			self.AudioComp.clip = (self.Female ? self.FemaleTalkSFX.GetRandom() : self.TalkSFX.GetRandom());
			self.AudioComp.Play();
		}
		float num = self.employee.ModTrait(Employee.Trait.BornLeader, 1f, 0.75f);
		self.SocialFactor = -32f * num;
		usedBy.SocialFactor = -32f * num;
		self.Noisiness = 3f;
		if (self.employee.Social < num || usedBy.employee.Social < num)
		{
			return 1;
		}
		self.UsingPoint = null;
		return 2;
	}

	private static int BurglarPanic(Actor self)
	{
		self.SetAnim(Actor.AnimationStates.Panic);
		if (!GameSettings.BurglarPresent())
		{
			return 2;
		}
		return 1;
	}

	private static int ShouldUseBed(Actor self)
	{
		if (self.employee.Founder && !self.TakingCourses && self.GoToFurniture("Bed", InteractionPoint.ActionType.Use, -1, false) != 0)
		{
			return 2;
		}
		return 0;
	}

	private static int GoToSleep(Actor self)
	{
		if (self.AtFurniture)
		{
			return 1;
		}
		if (self.CurrentPath == null || self.UsingPoint == null)
		{
			return 0;
		}
		if (self.WalkPath())
		{
			self.AtFurniture = true;
			self.SetAnim(self.UsingPoint.Animation);
			self.TurnToFurniture();
		}
		return 1;
	}

	private static int CheckMentor(Actor self)
	{
		if (!self.GoHomeNow && self.IsMentor && SDateTime.Now() > self.MentorCooldown && self.Team != null)
		{
			List<Actor> employeesDirect = self.GetTeam().GetEmployeesDirect();
			for (int i = 0; i < employeesDirect.Count; i++)
			{
				Actor actor = employeesDirect[i];
				if (!actor.IsAliveNotNull() || !actor.IsWorking || actor.BeingMentored || actor.IsMentor || !(actor != self) || (actor.employee.CurrentRoleBit & self.employee.CurrentRoleBit) <= Employee.RoleBit.None)
				{
					continue;
				}
				for (int j = 1; j < 5; j++)
				{
					if (!actor.employee.IsRoleIndex(j) || !self.employee.IsRoleIndex(j) || !(actor.employee.GetSkillI(j) < actor.employee.SkillCeiling) || !(actor.employee.GetSkillI(j) < self.employee.GetSkillI(j)))
					{
						continue;
					}
					foreach (WorkItem currentWorkItem in actor.GetCurrentWorkItems())
					{
						Employee.EmployeeRole? boostRole = currentWorkItem.GetBoostRole(actor, actor.SecondaryWork);
						if (!boostRole.HasValue || !self.employee.IsRole(boostRole.Value) || !(actor.employee.GetSkill(boostRole.Value) < self.employee.GetSkill(boostRole.Value)))
						{
							continue;
						}
						InteractionPoint usingPoint = actor.UsingPoint;
						if (!(usingPoint != null))
						{
							continue;
						}
						if (usingPoint.Parent.SnappedTo != null)
						{
							Furniture parent = usingPoint.Parent.SnappedTo.Parent;
							for (int k = 0; k < parent.SnapPoints.Length; k++)
							{
								Furniture mainUsedBy = parent.SnapPoints[k].MainUsedBy;
								if (mainUsedBy != null && "Chair".Equals(mainUsedBy.Type) && !mainUsedBy.IsUsed() && mainUsedBy.GetComputer() == null && Mathf.Abs(Mathf.DeltaAngle(mainUsedBy.transform.rotation.eulerAngles.y, usingPoint.Parent.transform.rotation.eulerAngles.y - 180f)) < 40f)
								{
									InteractionPoint interactionPoint = mainUsedBy.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
									if (interactionPoint != null && self.PathToFurniture(interactionPoint, false))
									{
										self.TargetActor = actor;
										return 2;
									}
								}
							}
						}
						InteractionPoint interactionPoint2 = usingPoint.Parent.GetInteractionPoint(self, InteractionPoint.ActionType.Social);
						if (interactionPoint2 != null && self.PathToFurniture(interactionPoint2, false))
						{
							self.TargetActor = actor;
							return 2;
						}
					}
					break;
				}
			}
			self.MentorCooldown = SDateTime.Now() + SDateTime.GetMinutes(10f);
		}
		return 0;
	}

	private static int GoToMentor(Actor self)
	{
		if (self.UsingPoint == null || self.CurrentPath == null || !self.TargetActor.IsAliveNotNull())
		{
			self.UsingPoint = null;
			self.ClearPath();
			return 0;
		}
		if (self.WalkPath())
		{
			self.TurnToFurniture();
			self.Timer = 0f;
			self.TargetActor.BeingMentored = true;
			return 2;
		}
		return 1;
	}

	private static void ExitMentoring(Actor self)
	{
		self.Timer = -1f;
		self.MentorCooldown = SDateTime.Now() + SDateTime.GetMinutes(60f);
		if (self.TargetActor.IsAliveNotNull())
		{
			self.TargetActor.BeingMentored = false;
		}
		self.TargetActor = null;
	}

	private static int MentorStudent(Actor self)
	{
		if (self.UsingPoint == null || !self.TargetActor.IsAliveNotNull() || self.TargetActor.GoHomeNow || self.GoHomeNow || IsHungry(self) == 2 || HasToPee(self) == 2 || (!self.employee.IsRole(Employee.RoleBit.Lead) && HasMakeMeeting(self) == 2))
		{
			return 2;
		}
		Actor targetActor = self.TargetActor;
		self.InteractWith(targetActor);
		self.SocialFactor = -32f;
		targetActor.SocialFactor = -32f;
		self.Noisiness = 3f;
		bool flag = false;
		bool flag2 = true;
		if (targetActor.IsWorking)
		{
			WorkItem workItem = targetActor.MyWorkItem();
			Employee.EmployeeRole? employeeRole = ((workItem != null) ? workItem.GetBoostRole(targetActor, targetActor.SecondaryWork) : ((Employee.EmployeeRole?)null));
			if (employeeRole.HasValue && self.employee.IsRole(employeeRole.Value))
			{
				float skill = self.employee.GetSkill(employeeRole.Value);
				if (skill > targetActor.employee.GetSkill(employeeRole.Value))
				{
					targetActor.employee.ChangeSkill(employeeRole.Value, Mathf.Max(0f, Mathf.Min(1f, self.employee.Compatibility(targetActor.employee)) * Mathf.Min(1f, targetActor.Effectiveness) * Mathf.Min(1f, targetActor.employee.JobSatisfaction) * Mathf.Min(1f, self.employee.JobSatisfaction) * skill * 0.025f * targetActor.currentRoom.GetAuraValue(Furniture.AuraTypes.Skill)), true);
					flag = true;
				}
			}
		}
		else if (!self.TargetActor.AtFurniture || self.TargetActor.UsingPoint == null || !"Computer".Equals(self.TargetActor.UsingPoint.Parent.Type))
		{
			flag2 = false;
		}
		if (flag2 && !self.AudioComp.isPlaying && self.MayPlaySound())
		{
			self.AudioComp.clip = (self.Female ? self.FemaleTalkSFX.GetRandom() : self.TalkSFX.GetRandom());
			self.AudioComp.Play();
		}
		if (self.UsingPoint.Action == InteractionPoint.ActionType.Use)
		{
			self.SetAnim(flag2 ? Actor.AnimationStates.Talk : Actor.AnimationStates.SitHandsdown);
		}
		else
		{
			self.SetAnim(flag2 ? Actor.AnimationStates.StandUpTalking : Actor.AnimationStates.Idle);
		}
		if (flag)
		{
			self.Timer = 0f;
		}
		else
		{
			self.Timer += Time.deltaTime * GameSettings.GameSpeed;
		}
		if (!(self.Timer > 15f))
		{
			return 1;
		}
		return 2;
	}

	private static int PickFirePoint(Actor self)
	{
		if (self.CurrentPath != null)
		{
			if (self.CleaningRoom.IsOnFire)
			{
				if (!self.WalkPath())
				{
					return 1;
				}
				return 2;
			}
			self.ClearPath();
		}
		ClearFireRooms(self);
		if (self.InspectRooms.Count > 0 && self.MyCar != null && self.MyCar.Parked)
		{
			self.CleaningRoom = self.InspectRooms.First();
			if (!GotoNearestSpot(self, self.CleaningRoom.Center))
			{
				return 1;
			}
			return 2;
		}
		return 0;
	}

	private static bool GotoNearestSpot(Actor self, Vector2 target)
	{
		if (self.MyCar != null)
		{
			FireTruck component = self.MyCar.GetComponent<FireTruck>();
			if (component != null)
			{
				Vector2 p = self.ActualPosition.FlattenVector3();
				int minIndex = component.SprayPoints.GetMinIndex((Transform x) => (x.transform.position.FlattenVector3() - p).sqrMagnitude);
				int minIndex2 = component.SprayPoints.GetMinIndex((Transform x) => (x.transform.position.FlattenVector3() - target).sqrMagnitude);
				Vector2 vector = component.SprayPoints[minIndex].transform.position.FlattenVector3();
				if (minIndex != minIndex2)
				{
					self.SetPath(Actor.PathPool.Get());
					int num = minIndex;
					int num2 = Utilities.FastestIncrement(num, minIndex2, component.SprayPoints.Length);
					while (num != minIndex2)
					{
						self.CurrentPath.Add(component.SprayPoints[num].position);
						num += num2;
						if (num < 0)
						{
							num = component.SprayPoints.Length - 1;
						}
						else if (num >= component.SprayPoints.Length)
						{
							num = 0;
						}
					}
					self.CurrentPath.Add(component.SprayPoints[minIndex2].position);
					if ((vector - p).magnitude > 0.01f)
					{
						self.CurrentPath.Insert(0, self.ActualPosition);
					}
					return false;
				}
				if ((vector - p).magnitude > 0.01f)
				{
					self.SetPath(Actor.PathPool.Get());
					self.CurrentPath.Add(self.ActualPosition);
					self.CurrentPath.Add(component.SprayPoints[minIndex].position);
					return false;
				}
			}
		}
		return true;
	}

	private static void ClearFireRooms(Actor self)
	{
		Room room = self.InspectRooms.FirstOrDefault();
		while (room != null && (!room.IsOnFire || !(room.BurnStop > 0f)))
		{
			self.InspectRooms.Remove(room);
			room = self.InspectRooms.FirstOrDefault();
		}
	}

	private static int FightFires(Actor self)
	{
		if (self.CurrentPath != null)
		{
			return 2;
		}
		if (self.CleaningRoom != null)
		{
			bool flag = false;
			if (self.CleaningRoom.IsOnFire && self.CleaningRoom.BurnStop > 0f)
			{
				self.CleaningRoom.BurnStop -= Utilities.PerHour(100f / self.CleaningRoom.Area);
				self.SetAnim(Actor.AnimationStates.FireFight);
				flag = self.CleaningRoom.BurnStop <= 0f;
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				self.SetAnim(Actor.AnimationStates.Idle);
				self.InspectRooms.Remove(self.CleaningRoom);
				self.CleaningRoom = null;
				return 2;
			}
			return 1;
		}
		return 0;
	}

	private static int TurnToFire(Actor self)
	{
		if (self.CleaningRoom != null)
		{
			self.InitiateTurn((self.CleaningRoom.Center - self.ActualPosition.FlattenVector3()).ToVector3(0f).LookDir().eulerAngles.y);
		}
		return 2;
	}

	private static int GotoNextRoom(Actor self)
	{
		self.SetAnim(Actor.AnimationStates.Idle);
		if (self.InspectRooms.Count == 0)
		{
			return 0;
		}
		if (self.CleaningRoom == null)
		{
			List<KeyValuePair<Room, int>> connectedRooms = GameSettings.Instance.sRoomManager.GetConnectedRooms(self.currentRoom);
			Room room = null;
			int floor = self.Floor;
			int num = int.MaxValue;
			int num2 = int.MaxValue;
			for (int i = 0; i < connectedRooms.Count; i++)
			{
				KeyValuePair<Room, int> keyValuePair = connectedRooms[i];
				if (self.InspectRooms.Contains(keyValuePair.Key))
				{
					room = keyValuePair.Key;
					break;
				}
			}
			if (room != null)
			{
				self.InspectRooms.Remove(room);
				if (PathToRoom(self, room))
				{
					self.CleaningRoom = room;
					return 2;
				}
				return 1;
			}
			return 0;
		}
		if (PathToRoom(self, self.CleaningRoom))
		{
			return 2;
		}
		self.CleaningRoom = null;
		return 1;
	}

	private static int MoveToRoom(Actor self)
	{
		if (self.CurrentPath == null)
		{
			return 0;
		}
		if (self.WagePaid)
		{
			if (!self.currentRoom.Outside && !self.currentRoom.Outdoors)
			{
				if (self.currentRoom.Area >= 10f)
				{
					if (!self.currentRoom.AnyFurnitureInAtrium("FireAlarm") && GameSettings.Instance.ActiveFireReport.AlarmRooms.Add(self.currentRoom.DID))
					{
						GameSettings.Instance.ActiveFireReport.AlarmViolations++;
					}
					self.WagePaid = false;
				}
			}
			else
			{
				self.WagePaid = false;
			}
		}
		if (!self.WalkPath())
		{
			return 1;
		}
		return 2;
	}

	private static int InspectRoom(Actor self)
	{
		if (self.CleaningRoom != null)
		{
			self.HasFridged = true;
			Room mainAtriumParentOrSelf = self.CleaningRoom.GetMainAtriumParentOrSelf();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			foreach (Room item in mainAtriumParentOrSelf.GetAtriumChildrenAndSelf())
			{
				List<Furniture> furnitures = item.GetFurnitures();
				for (int i = 0; i < furnitures.Count; i++)
				{
					Furniture furniture = furnitures[i];
					if ("Computer".Equals(furniture.Type))
					{
						num2++;
					}
					else if ("Sprinkler".Equals(furniture.Type))
					{
						num3++;
					}
					else if ("FireAlarm".Equals(furniture.Type))
					{
						num4++;
					}
					if (furniture.HasUpg)
					{
						if (furniture.upg.FireStarter > 0f)
						{
							num++;
						}
						if (furniture.ITFix)
						{
							GameSettings.Instance.ActiveFireReport.ITFixCount++;
						}
						else
						{
							GameSettings.Instance.ActiveFireReport.MaintenanceFixCount++;
						}
					}
				}
			}
			if (!mainAtriumParentOrSelf.Outside && !mainAtriumParentOrSelf.Outdoors)
			{
				if (num > 0 && num4 == 0)
				{
					if (mainAtriumParentOrSelf.Area < 10f)
					{
						self.WagePaid = true;
					}
					else
					{
						GameSettings.Instance.ActiveFireReport.AlarmViolations++;
						GameSettings.Instance.ActiveFireReport.AlarmRooms.Add(mainAtriumParentOrSelf.DID);
					}
				}
				if (num > 0 && num3 == 0)
				{
					GameSettings.Instance.ActiveFireReport.SprinklerWarning = true;
				}
				if (num2 > 0 && num3 == 0)
				{
					GameSettings.Instance.ActiveFireReport.SprinklerViolations++;
					GameSettings.Instance.ActiveFireReport.SprinklerRooms.Add(mainAtriumParentOrSelf.DID);
				}
			}
			self.CleaningRoom = null;
		}
		self.SetAnim(Actor.AnimationStates.WriteClipboard);
		return self.WaitForTimer(3f);
	}

	private static bool PathToRoom(Actor self, Room r)
	{
		Vector2? vector = r.FindRandomSpot();
		if (vector.HasValue)
		{
			Vector3 e = vector.Value.ToVector3((float)r.Floor * 2f);
			if (self.PathToPoint(e, true, true, self.AItype))
			{
				return true;
			}
		}
		return false;
	}

	private static int StaffSpawn(Actor self)
	{
		self.SickDays = 0;
		if (self.CurrentPath == null)
		{
			return 2;
		}
		if (!self.WalkPath())
		{
			return 1;
		}
		return 2;
	}

	private static int Loiter(Actor self)
	{
		if (self.GoHomeNow || self.employee.Dismissed)
		{
			self.UsingPoint = null;
			self.ClearLoiterTable();
			self.ClearPath();
			return 2;
		}
		if (self.IsEmployee())
		{
			self.MakeIdle(Actor.WorkStatus.NoComputer);
		}
		if (self.CurrentPath != null && self.UsingPoint == null)
		{
			self.WalkPath();
			return 1;
		}
		if (self.Timer != -1f)
		{
			return self.WaitForTimer(self.Timer);
		}
		if (self.LoiterTable != null)
		{
			int num = self.GoToFurniture("Chair", InteractionPoint.ActionType.Use, -1, false);
			if (num == 0 || self.UsingPoint == null)
			{
				self.ClearLoiterTable();
				return 2;
			}
			if (num == 2)
			{
				self.CheckMeeting();
				self.SetAnim(self.UsingPoint.Parent.CanLean ? Actor.AnimationStates.Relax : Actor.AnimationStates.SitHandsdown);
				self.TurnToFurniture();
				return self.WaitForTimer(UnityEngine.Random.Range(1, 10));
			}
			return 1;
		}
		if (self.UsingPoint != null && self.UsingPoint.Parent.Type.Equals("Couch"))
		{
			switch (self.GoToFurniture("Couch", InteractionPoint.ActionType.Use, -1, false, null, true, false, null, 2500f, true))
			{
			case 0:
				self.UsingPoint = null;
				return 2;
			case 2:
				self.CheckMeeting();
				self.SetAnim(Actor.AnimationStates.SitHandsdown);
				self.TurnToFurniture();
				return self.WaitForTimer(UnityEngine.Random.Range(1, 10));
			default:
				return 1;
			}
		}
		if (self.GoToFurniture("Couch", InteractionPoint.ActionType.Use, -1, false, null, true, false, null, 2500f, true) != 0)
		{
			return 1;
		}
		if (self.LoiterTable == null)
		{
			if (self.Timer == -1f)
			{
				TableScript tableScript = self.FindFreeTable(Room.RoomLimits.Lounge, false, false, false);
				if (tableScript != null)
				{
					Furniture freeChair = tableScript.GetFreeChair(self);
					if (freeChair != null)
					{
						InteractionPoint interactionPoint = freeChair.GetInteractionPoint(self, InteractionPoint.ActionType.Use);
						if (interactionPoint != null && self.PathToFurniture(interactionPoint, false))
						{
							self.LoiterTable = tableScript;
							self.LoiterTable.ReserveTables(true, true);
							return 1;
						}
					}
				}
				if (!self.currentRoom.IsNeutral() && FindPathToNeutral(self))
				{
					self.UsingPoint = null;
					return 1;
				}
				if (self.AItype == AIType.Employee)
				{
					self.employee.AddInstantMood("NoSitting", self);
					self.SetAnim(Actor.AnimationStates.Idle);
					self.CheckMeeting();
					return self.WaitForTimer(UnityEngine.Random.Range(1, 10));
				}
			}
			self.SetAnim(Actor.AnimationStates.Idle);
			int result = self.WaitForTimer(UnityEngine.Random.Range(1, 10));
			self.CheckMeeting();
			return result;
		}
		return 2;
	}

	public static bool FindPathToNeutral(Actor self)
	{
		Room room = GameSettings.Instance.sRoomManager.GetConnectedRooms(self.currentRoom).SelectFirstOrDefault((KeyValuePair<Room, int> x) => x.Key, (Room x) => !x.Dummy && x.IsNeutral());
		if (room != null && (room.Center - self.ActualPosition.FlattenVector3()).sqrMagnitude < 900f)
		{
			Vector2? vector = room.FindRandomSpot();
			if (vector.HasValue && self.PathToPoint(new Vector3(vector.Value.x, room.Floor * 2, vector.Value.y)))
			{
				return true;
			}
		}
		else if (!self.currentRoom.Outside)
		{
			self.SetPath(GameSettings.Instance.sRoomManager.FindPathToOutside(self.ActualPosition, self.transform.rotation.eulerAngles.y));
			if (self.CurrentPath != null)
			{
				return true;
			}
		}
		return false;
	}

	private static int LoiterInPlace(Actor self)
	{
		self.SetAnim(Actor.AnimationStates.Idle);
		return self.WaitForTimer(5f);
	}

	private static void ClearLoiterTable(Actor act)
	{
		act.ClearLoiterTable();
	}

	private static int IsStaffOff(Actor self)
	{
		if (self.GoHomeNow)
		{
			if (self.UsingPoint != null)
			{
				self.UsingPoint.UsedBy = null;
				self.UsingPoint = null;
			}
			return 2;
		}
		return 0;
	}

	private static int Repair(Actor self)
	{
		if (self.UsingPoint == null)
		{
			return 2;
		}
		self.SetAnim(self.UsingPoint.Animation, self.UsingPoint.subAnimation);
		if (self.UsingPoint.Parent.upg.RepairMe())
		{
			self.UsingPoint.UsedBy = null;
			self.UsingPoint = null;
			return 2;
		}
		return 1;
	}

	private static int StaffDespawn(Actor self)
	{
		GameSettings.Instance.StaffSalaryDue += self.GetRealSalary() / (float)GameSettings.DaysPerMonth;
		foreach (InteractionPoint value in self.InQueue.Values)
		{
			value.RemoveFromQueue(self);
		}
		self.InQueue.Clear();
		if (self.OnCall)
		{
			self.DestroyGO();
		}
		else
		{
			SDateTime sDateTime = SDateTime.Now();
			int stayHome = self.StayHome;
			self.StayHome = 0;
			SDateTime time = new SDateTime(Utilities.GaussRange(0.5f, 0, 40), self.StaffOn - 1, sDateTime.Day + ((self.StaffOn <= TimeOfDay.Instance.Hour) ? 1 : 0) + stayHome, sDateTime.Month, sDateTime.Year);
			if (time.SimplifyLess() <= sDateTime.SimplifyLess())
			{
				time += new SDateTime(1, 0, 0);
			}
			GameSettings.Instance.sActorManager.AddToAwaiting(self, time);
			self.OnDespawn();
		}
		return 2;
	}

	private static void FixCarPath(List<PathVector> path, Vector3 face)
	{
		if (path == null || path.Count <= 3 || !(path[path.Count - 1].y > 1f))
		{
			return;
		}
		if ((path[path.Count - 1] - path[path.Count - 3]).sqrMagnitude > 5f)
		{
			PathVector pathVector = path[path.Count - 1];
			if (Mathf.Abs(face.x) > Mathf.Abs(face.z))
			{
				path.Insert(path.Count - 1, new Vector3(pathVector.x, pathVector.y, path[path.Count - 2].z));
			}
			else
			{
				path.Insert(path.Count - 1, new Vector3(path[path.Count - 2].x, pathVector.y, pathVector.z));
			}
			PathVector pathVector2 = path[path.Count - 2];
			PathVector pathVector3 = path[path.Count - 3];
			PathVector pathVector4 = path[path.Count - 4];
			float sqrMagnitude = (pathVector4 - pathVector2).sqrMagnitude;
			if (sqrMagnitude < (pathVector3 - pathVector2).sqrMagnitude || sqrMagnitude < (pathVector4 - pathVector3).sqrMagnitude)
			{
				path.RemoveAt(path.Count - 3);
			}
		}
		else
		{
			path.RemoveAt(path.Count - 2);
		}
	}

	private static int GoHomeState(Actor self)
	{
		if (self.AItype == AIType.Security && ScareOffBurglars(self))
		{
			return 1;
		}
		if (self.CurrentPath == null)
		{
			if (self.MyCar != null)
			{
				Vector3 position = self.MyCar.SpawnPoints[self.CarSpawnID].transform.position;
				bool failedRoom;
				self.SetPath(GameSettings.Instance.sRoomManager.FindPath(self.ActualPosition, position, self.transform.rotation.eulerAngles.y, self.GetTeam(), self.GetRole(), self.TrappedInToilet || self.AItype != AIType.Employee, out failedRoom, true, Actor.GetWeightingFunc(self.AItype)));
				if (self.CurrentPath == null)
				{
					self.SetPath(GameSettings.Instance.sRoomManager.FindPath(self.ActualPosition, position, self.transform.rotation.eulerAngles.y, self.GetTeam(), self.GetRole(), true, out failedRoom, true, Actor.GetWeightingFunc(self.AItype)));
				}
				FixCarPath(self.CurrentPath, self.MyCar.SpawnPoints[self.CarSpawnID].transform.forward);
				if (self.CurrentPath == null)
				{
					return 0;
				}
				NotificationManager.RemoveAggregate<StuckNotification>(self);
				HUD.Instance.CantGetHome.Remove(self);
				return 1;
			}
			return 0;
		}
		if (self.WalkPath())
		{
			if (self.MyCar != null)
			{
				CarSpawn carSpawn = self.MyCar.SpawnPoints[self.CarSpawnID];
				self.ActualPosition = carSpawn.transform.position;
				self.transform.SetPositionAndRotation(carSpawn.transform.position, carSpawn.transform.rotation);
				if (self.MyCar.IsBike)
				{
					self.Biking = true;
					self.anim.Play("OnBike", 0, 0f);
				}
				else
				{
					self.anim.Play(CarSpawn.AnimationInStates[carSpawn.SubAnimation], 0, 0f);
				}
			}
			self.MeetingTime = SDateTime.Now();
			return 2;
		}
		return 1;
	}

	private static int ShouldUseSubway(Actor self)
	{
		if (self.MyCar == null && GameSettings.Instance.HasSubway)
		{
			float sqrMagnitude = (GameSettings.Instance.ActiveSubway.Center() - self.ActualPosition.FlattenVector3()).sqrMagnitude;
			Vector2 vector = GameSettings.Instance.BusStopSign.transform.position.FlattenVector3();
			if (sqrMagnitude < (self.UsedSubway ? Subway.MaxDistanceUsedSq : Subway.MaxDistanceSq) || sqrMagnitude < (vector - self.ActualPosition.FlattenVector3()).sqrMagnitude)
			{
				return 2;
			}
			return 0;
		}
		return 0;
	}

	private static int GoHomeSubway(Actor self)
	{
		if (self.AItype == AIType.Security && ScareOffBurglars(self))
		{
			return 1;
		}
		if (self.CurrentPath == null)
		{
			Subway activeSubway = GameSettings.Instance.ActiveSubway;
			float w = UnityEngine.Random.Range(0f - activeSubway.SpawnWidth, activeSubway.SpawnWidth);
			Vector3 lastWaypoint = activeSubway.GetLastWaypoint(w);
			bool flag = self.PathToPoint(lastWaypoint, false, true, self.AItype);
			if (!flag)
			{
				flag = self.PathToPoint(lastWaypoint, true, true, self.AItype);
			}
			if (!flag)
			{
				if (!NotificationManager.CheckAggregate<StuckNotification>(self))
				{
					NotificationManager.AddNotification(new StuckNotification(self));
				}
				HUD.Instance.CantGetHome.Add(self);
				return 0;
			}
			activeSubway.GetWaypoints(self.CurrentPath, w, true);
			if (self.MyCar != null)
			{
				self.MyCar.SpawnPoints[self.CarSpawnID].Occupants.Remove(self);
				self.MyCar = null;
			}
			NotificationManager.RemoveAggregate<StuckNotification>(self);
			HUD.Instance.CantGetHome.Remove(self);
		}
		if (self.WalkPath())
		{
			self.MeetingTime = SDateTime.Now();
			return 2;
		}
		return 1;
	}

	private static int ShouldUseBus(Actor self)
	{
		if (!(self.MyCar == null))
		{
			return 0;
		}
		return 2;
	}

	private static int GoHomeBusStop(Actor self)
	{
		if (self.AItype == AIType.Security && ScareOffBurglars(self))
		{
			GameSettings.Instance.sActorManager.ReadyForHome.Remove(self);
			return 1;
		}
		if (GameSettings.Instance.sActorManager.ReadyForHome.Contains(self))
		{
			if (self.CurrentPath == null)
			{
				self.SetAnim(Actor.AnimationStates.Idle);
				if (self.MyCar != null)
				{
					self.MyCar.SpawnPoints[self.CarSpawnID].Occupants.Remove(self);
					self.MyCar = null;
					return 0;
				}
				return 1;
			}
			if (self.MyCar == null)
			{
				self.ClearPath();
				return 0;
			}
			if (self.WalkPath())
			{
				CarSpawn carSpawn = self.MyCar.SpawnPoints[self.CarSpawnID];
				self.transform.rotation = carSpawn.transform.rotation;
				GameSettings.Instance.sActorManager.ReadyForHome.Remove(self);
				self.anim.Play(CarSpawn.AnimationInStates[carSpawn.SubAnimation], 0, 0f);
				self.MeetingTime = SDateTime.Now();
				return 2;
			}
			return 1;
		}
		if (self.CurrentPath == null)
		{
			Transform transform = GameSettings.Instance.BusStopSign.transform;
			Vector3 e = new Vector3(transform.position.x, 0f, transform.position.z) + transform.rotation * new Vector3(UnityEngine.Random.Range(0.3f, -0.15f), 0f, UnityEngine.Random.Range(3f, 0.1f));
			bool flag = self.PathToPoint(e, false, true, self.AItype);
			if (!flag)
			{
				flag = self.PathToPoint(e, true, true, self.AItype);
			}
			if (!flag && self.AItype != AIType.Burglar)
			{
				if (!NotificationManager.CheckAggregate<StuckNotification>(self))
				{
					NotificationManager.AddNotification(new StuckNotification(self));
				}
				HUD.Instance.CantGetHome.Add(self);
				return 0;
			}
			if (self.MyCar != null)
			{
				self.MyCar.SpawnPoints[self.CarSpawnID].Occupants.Remove(self);
				self.MyCar = null;
			}
			NotificationManager.RemoveAggregate<StuckNotification>(self);
			HUD.Instance.CantGetHome.Remove(self);
		}
		if (self.WalkPath())
		{
			GameSettings.Instance.sActorManager.ReadyForHome.Add(self);
		}
		return 1;
	}

	private static int Flee(Actor self)
	{
		if (self.CurrentPath != null)
		{
			if (!self.WalkPath())
			{
				return 1;
			}
			return 2;
		}
		if (self.Timer >= 0f)
		{
			self.WaitForTimer(self.Timer);
			return 1;
		}
		if (self.currentRoom.Outside)
		{
			return 2;
		}
		self.SetPath(GameSettings.Instance.sRoomManager.FindPathToOutside(self.ActualPosition, self.transform.rotation.eulerAngles.y));
		if (self.CurrentPath == null)
		{
			self.SetAnim(Actor.AnimationStates.Panic);
			self.WaitForTimer(30f + UnityEngine.Random.value * 30f);
			return 1;
		}
		return 1;
	}

	private static int GuestGoToReceptionDesk(Actor self)
	{
		if (self.UsingPoint == null)
		{
			self.CleaningRoom = null;
			return 0;
		}
		if (self.CurrentPath == null)
		{
			if (!self.PathToFurniture(self.UsingPoint, true))
			{
				self.CleaningRoom = null;
				self.UsingPoint = null;
				return 0;
			}
			return 1;
		}
		if (self.WalkPath())
		{
			self.SetAnim(self.UsingPoint.Animation);
			self.TurnToFurniture();
			return 2;
		}
		return 1;
	}

	private static int GuestWaitAtDesk(Actor self)
	{
		if (GetWaitState(self, true) * self.GuestPatience < 0.4f)
		{
			PopUpLeaveWarning(self);
			return 2;
		}
		int num = self.WaitForTimer(5f);
		if (num == 2)
		{
			if (self.deal != null)
			{
				HUD.Instance.dealWindow.InsertDeal(self.deal);
			}
			self.UsingPoint = null;
		}
		return num;
	}

	private static void PopUpLeaveWarning(Actor self)
	{
		if (!self.currentRoom.Outside)
		{
			NotificationManager.AddNotification(new SingleRoomNotification(self.currentRoom, "DealRoomFail".Loc(), "VisitorFailTip".Loc(), "Deal", SDateTime.Now(), NotificationManager.NotificationType.Warning));
		}
		else if (self.CleaningRoom != null)
		{
			NotificationManager.AddNotification(new SingleRoomNotification(self.CleaningRoom, "DealRoomFail".Loc(), "VisitorFailTip".Loc(), "Deal", SDateTime.Now(), NotificationManager.NotificationType.Warning));
		}
		else
		{
			NotificationManager.AddNotification(new NotificationMessage("DealRoomFail".Loc(), "VisitorFailTip".Loc(), "Deal", SDateTime.Now(), NotificationManager.NotificationType.Warning));
		}
	}

	private static int LookForReceptionDesk(Actor self)
	{
		if (self.GuestPatience <= 0f || GameSettings.Instance.IsReferenceNull())
		{
			return 0;
		}
		if (self.CleaningRoom == null)
		{
			int num = int.MaxValue;
			ReceptionDesk receptionDesk = null;
			for (int i = 0; i < GameSettings.Instance.ReceptionDesks.Count; i++)
			{
				ReceptionDesk receptionDesk2 = GameSettings.Instance.ReceptionDesks[i];
				if (receptionDesk2 != null && receptionDesk2.Furn.IsAliveNotNull() && receptionDesk2.Active && receptionDesk2.Queue.Count < num)
				{
					num = receptionDesk2.Queue.Count;
					receptionDesk = receptionDesk2;
					if (num == 0)
					{
						break;
					}
				}
			}
			if (receptionDesk != null)
			{
				receptionDesk.Queue.Add(self);
				self.CleaningRoom = receptionDesk.Furn.Parent;
				return 2;
			}
			return 0;
		}
		return 2;
	}

	private static int GuestDespawn(Actor self)
	{
		foreach (InteractionPoint value in self.InQueue.Values)
		{
			value.RemoveFromQueue(self);
		}
		self.InQueue.Clear();
		if (self.UsingPoint != null)
		{
			self.UsingPoint.UsedBy = null;
			self.UsingPoint = null;
		}
		self.DestroyGO();
		if (self.AItype == AIType.Burglar && !GameSettings.BurglarPresent())
		{
			GameSettings.Instance.GenerateBurglarMessage();
		}
		else if (self.AItype == AIType.FireInspector && !GameSettings.InspectorPresent())
		{
			GameSettings.Instance.FinishFireReport();
		}
		return 2;
	}

	private static int IsGuestOff(Actor self)
	{
		if (self.GuestPatience <= 0f || (SDateTime.Now() - self.MeetingTime).ToInt() > 180)
		{
			if (self.GuestPatience <= 0f)
			{
				PopUpLeaveWarning(self);
			}
			self.GoHomeNow = true;
			if (self.UsingPoint != null)
			{
				self.UsingPoint.UsedBy = null;
				self.UsingPoint = null;
			}
			return 2;
		}
		return 0;
	}

	private static int IsUp(Actor self)
	{
		if (!(self.GuestPatience > 0f) || !(self.UsingPoint != null) || !self.UsingPoint.Parent.Type.Equals("Desk"))
		{
			return 0;
		}
		return 2;
	}

	private static float GetWaitState(Actor self, bool onlyRoom)
	{
		if (!onlyRoom && self.CurrentPath != null)
		{
			return 1f;
		}
		if (self.currentRoom.Outside)
		{
			if (!onlyRoom)
			{
				return 0f;
			}
			return 1f;
		}
		if (!onlyRoom && self.UsingPoint == null)
		{
			return 0f;
		}
		float num = ((self.UsingPoint != null && self.UsingPoint.Parent.Type.Equals("Couch")) ? self.UsingPoint.Parent.Comfort : 1f);
		float num2 = 1f - Mathf.Clamp01(Mathf.Abs(self.currentRoom.Temperature - 21f) / 5f);
		float num3 = Mathf.Min(1f, self.currentRoom.GetEnvironment());
		float num4 = 1f - self.currentRoom.DarknessLevel;
		float num5 = 1f - self.currentRoom.Smell;
		float num6 = (num2 * num2 + num3 * num3 + num4) / 3f;
		return num5 * ((num > 1f) ? Mathf.Lerp(num6, 1f, num.MapRange(1f, 2f, 0f, 1f, true)) : (num6 * num.WeightOne(0.5f)));
	}

	private static int GuestLoiter(Actor self)
	{
		if (self.CurrentPath != null)
		{
			bool flag = self.WalkPath();
			if (self.UsingPoint == null)
			{
				self.ClearPath();
				return 0;
			}
			if (flag)
			{
				self.SetAnim(self.UsingPoint.Animation);
				self.TurnToFurniture();
				if (!self.UsingPoint.Parent.Type.Equals("Desk"))
				{
					return 1;
				}
				return 2;
			}
			return 1;
		}
		if (self.UsingPoint != null)
		{
			if (self.UsingPoint.Parent == null)
			{
				return 0;
			}
			if (self.UsingPoint.Parent.Type.Equals("Desk"))
			{
				return 2;
			}
			self.GuestPatience -= Utilities.PerHour((1f - GetWaitState(self, false)) * 15f);
			if (self.GuestPatience <= 0f)
			{
				self.UsingPoint = null;
				return 2;
			}
			return self.WaitForTimer(5f);
		}
		self.SetAnim(Actor.AnimationStates.Idle);
		if (self.CleaningRoom != null)
		{
			return self.GoToFurniture("Couch", InteractionPoint.ActionType.Use, 1, false, self.CleaningRoom);
		}
		if (!GameSettings.Instance.IsReferenceNull())
		{
			Room randomWhereOffset = GameSettings.Instance.sRoomManager.Rooms.GetRandomWhereOffset((Room x) => x.IsAliveNotNull() && x.GetFurniture("Desk").Count > 0 && x.Accessible);
			return self.GoToFurniture("Couch", InteractionPoint.ActionType.Use, 1, false, (randomWhereOffset == null) ? null : randomWhereOffset);
		}
		self.GuestPatience -= Utilities.PerHour((1f - GetWaitState(self, false)) * 15f);
		if (self.GuestPatience <= 0f)
		{
			self.UsingPoint = null;
			return 2;
		}
		return 0;
	}

	private static int FindITRepair(Actor self)
	{
		if (self.LastCheckWait > 0f)
		{
			return 0;
		}
		if (self.employee.Dismissed)
		{
			self.ClearPath();
			return 0;
		}
		IEnumerable<Room> enumerable;
		if (!self.HasAssignedRooms)
		{
			if (!self.currentRoom.Outside)
			{
				enumerable = from x in GameSettings.Instance.sRoomManager.GetConnectedRooms(self.currentRoom.GetBalconyMainAtriumParentOrSelf())
					select x.Key;
			}
			else
			{
				IEnumerable<Room> enumerable2 = from x in GameSettings.Instance.sRoomManager.Rooms.Concate(GameSettings.Instance.sRoomManager.Outside)
					orderby x.GetFurnitures().WhereSelect((Furniture y) => y.ITFix && y.OnFire == 0f, (Furniture y) => y.HasUpg ? ((!y.upg.Broken) ? y.upg.Quality : 0f) : 1f).MinOrDefault(1f)
					select x;
				enumerable = enumerable2;
			}
		}
		else
		{
			enumerable = self.GetAssignedRooms();
		}
		bool flag = true;
		List<Furniture> list = new List<Furniture>();
		foreach (Room item in enumerable)
		{
			if (item.NavmeshRebuildStarted)
			{
				continue;
			}
			if (item.AtriumParent != null)
			{
				foreach (Room item2 in item.GetElligableAtriumSearch())
				{
					List<Furniture> furnitures = item2.GetFurnitures();
					for (int num = 0; num < furnitures.Count; num++)
					{
						Furniture furniture = furnitures[num];
						if (furniture != null && furniture.HasUpg && furniture.OnFire == 0f && furniture.ITFix && furniture.InteractionParent == item && (furniture.upg.Broken || furniture.upg.Quality < 0.8f) && GameSettings.Instance.MyCompany.CanMakeTransaction((1f - furniture.upg.Quality) * -500f) && furniture.TestAvailable(false, InteractionPoint.ActionType.Repair))
						{
							list.Add(furniture);
						}
					}
				}
			}
			else
			{
				List<Furniture> furnitures2 = item.GetFurnitures();
				for (int num2 = 0; num2 < furnitures2.Count; num2++)
				{
					Furniture furniture2 = furnitures2[num2];
					if (furniture2 != null && furniture2.HasUpg && furniture2.OnFire == 0f && furniture2.ITFix && (furniture2.upg.Broken || furniture2.upg.Quality < 0.8f) && GameSettings.Instance.MyCompany.CanMakeTransaction((1f - furniture2.upg.Quality) * -500f) && furniture2.TestAvailable(false, InteractionPoint.ActionType.Repair))
					{
						list.Add(furniture2);
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (Furniture item3 in from x in list
					orderby x.PathFailCount, x.upg.Quality
					select x)
				{
					flag = false;
					InteractionPoint interactionPoint = item3.GetInteractionPoint(self, InteractionPoint.ActionType.Repair);
					if (interactionPoint != null && TryFixFurn(self, item3, interactionPoint))
					{
						return 2;
					}
				}
			}
			list.Clear();
		}
		if ((self.OnCall || self.LeaveWhenDone) && flag)
		{
			self.GoHomeNow = true;
		}
		self.LastCheckWait = 30f;
		return 0;
	}

	private static bool TryFixFurn(Actor self, Furniture furn, InteractionPoint p)
	{
		InteractionPoint interactionPoint = furn.GetInteractionPoint(InteractionPoint.ActionType.Use, true);
		if (interactionPoint != null && interactionPoint.UsedBy != null && (interactionPoint.transform.position - p.transform.position).magnitude < 0.01f)
		{
			if (!furn.upg.Broken && ((!self.OnCall && furn.upg.Quality > 0.15f) || (self.OnCall && furn.upg.Quality > 0.5f)))
			{
				return false;
			}
			Actor usedBy = interactionPoint.UsedBy;
			usedBy.UsingPoint = null;
			usedBy.AtFurniture = false;
			usedBy.AIScript.currentNode = usedBy.AIScript.BehaviorNodes["Loiter"];
		}
		if (self.PathToFurniture(p, true))
		{
			GameSettings.Instance.MyCompany.MakeTransaction((1f - furn.upg.Quality) * -500f, Company.TransactionCategory.Repairs, true, "IT");
			return true;
		}
		if (!NotificationManager.CheckAggregate<UnreachableFurn>(furn))
		{
			NotificationManager.AddNotification(new UnreachableFurn(furn));
		}
		return false;
	}

	private static int LookForITDesk(Actor self)
	{
		if (self.OnCall)
		{
			return 0;
		}
		if (GameSettings.Instance.ITStationCount == 0 || GameSettings.Instance.ITSupportProcess == null || GameSettings.Instance.ITSupportProcess.Effectiveness == 0f || (GameSettings.Instance.BrokenIT.Count > 0 && GameSettings.Instance.BrokenIT.All((Furniture x) => x.upg.Quality == 0f)))
		{
			return 0;
		}
		if (self.GoToFurniture("ITStation", InteractionPoint.ActionType.Use, -1, false, null, false, true) <= 0)
		{
			return 0;
		}
		return 2;
	}

	private static int GotoITDesk(Actor self)
	{
		int num = self.GoToFurniture("ITStation", InteractionPoint.ActionType.Use, -1, false, null, false, true);
		if (num == 2)
		{
			self.TurnToFurniture();
		}
		return num;
	}

	private static int RemoteRepair(Actor self)
	{
		if (IsStaffOff(self) == 2)
		{
			return 2;
		}
		if (self.UsingPoint == null)
		{
			return 2;
		}
		bool flag = GameSettings.Instance.ITSupportProcess != null && GameSettings.Instance.ITSupportProcess.Effectiveness > 0f;
		if (flag)
		{
			Furniture furniture = null;
			for (int i = 0; i < GameSettings.Instance.BrokenIT.Count; i++)
			{
				Furniture furniture2 = GameSettings.Instance.BrokenIT[i];
				if (furniture2.IsAliveNotNull() && furniture2 != null)
				{
					if (furniture2.upg.Quality != 0f)
					{
						furniture = furniture2;
						break;
					}
					InteractionPoint interactionPoint = furniture2.GetInteractionPoint(self, InteractionPoint.ActionType.Repair);
					if (interactionPoint != null && TryFixFurn(self, furniture2, interactionPoint))
					{
						self.UsingPoint.UsedBy = null;
						self.UsingPoint = null;
						self.UsingPoint = interactionPoint;
						self.AtFurniture = false;
						self.AIScript.currentNode = self.AIScript.BehaviorNodes["GoToRepair"];
						return 1;
					}
				}
			}
			if (furniture != null)
			{
				furniture.upg.RepairMe(GameSettings.Instance.ITSupportProcess.Effectiveness * 0.5f);
			}
			else
			{
				flag = false;
				if (self.OnCall || self.LeaveWhenDone)
				{
					self.GoHomeNow = true;
				}
			}
		}
		if (flag)
		{
			self.SetAnim(Actor.AnimationStates.Work);
			if (self.anim.GetFloat("Blend2") <= 0f && !self.AudioComp.isPlaying && self.MayPlaySound())
			{
				self.AudioComp.clip = self.KeyboardSFX.GetRandom();
				self.AudioComp.Play();
			}
		}
		else
		{
			self.SetAnim(Actor.AnimationStates.SitStill);
		}
		return 1;
	}

	private static int GoToITRepair(Actor self)
	{
		foreach (InteractionPoint value in self.InQueue.Values)
		{
			if (value != null)
			{
				value.RemoveFromQueue(self);
			}
		}
		self.InQueue.Clear();
		if (self.UsingPoint != null)
		{
			bool num = self.WalkPath();
			if (num)
			{
				self.TurnToFurniture();
			}
			if (!num)
			{
				return 1;
			}
			return 2;
		}
		self.SetAnim(Actor.AnimationStates.Idle);
		self.ClearPath();
		return 0;
	}

	private static int FindRepair(Actor self)
	{
		if (self.LastCheckWait > 0f)
		{
			return 0;
		}
		IEnumerable<Room> enumerable;
		if (!self.HasAssignedRooms)
		{
			if (!self.currentRoom.Outside)
			{
				enumerable = from x in GameSettings.Instance.sRoomManager.GetConnectedRooms(self.currentRoom.GetBalconyMainAtriumParentOrSelf())
					select x.Key;
			}
			else
			{
				IEnumerable<Room> enumerable2 = from x in GameSettings.Instance.sRoomManager.Rooms.Concate(GameSettings.Instance.sRoomManager.Outside)
					orderby x.GetFurnitures().WhereSelect((Furniture y) => !y.ITFix && y.OnFire == 0f, (Furniture y) => y.HasUpg ? ((!y.upg.Broken) ? y.upg.Quality : 0f) : 1f).MinOrDefault(1f)
					select x;
				enumerable = enumerable2;
			}
		}
		else
		{
			enumerable = self.GetAssignedRooms();
		}
		bool flag = false;
		List<Furniture> list = new List<Furniture>();
		foreach (Room item in enumerable)
		{
			if (item.NavmeshRebuildStarted)
			{
				continue;
			}
			if (item.ToiletInUse())
			{
				flag = true;
				continue;
			}
			if (item.AtriumParent != null)
			{
				foreach (Room item2 in item.GetElligableAtriumSearch())
				{
					List<Furniture> furnitures = item2.GetFurnitures();
					for (int num = 0; num < furnitures.Count; num++)
					{
						Furniture furniture = furnitures[num];
						if (furniture != null && furniture.HasUpg && furniture.OnFire == 0f && !furniture.ITFix && furniture.InteractionParent == item && (furniture.upg.Quality < 0.75f || furniture.upg.Broken) && furniture.TestAvailable(InteractionPoint.ActionType.Repair))
						{
							list.Add(furniture);
						}
					}
				}
			}
			else
			{
				List<Furniture> furnitures2 = item.GetFurnitures();
				for (int num2 = 0; num2 < furnitures2.Count; num2++)
				{
					Furniture furniture2 = furnitures2[num2];
					if (furniture2 != null && furniture2.HasUpg && furniture2.OnFire == 0f && !furniture2.ITFix && (furniture2.upg.Quality < 0.75f || furniture2.upg.Broken) && furniture2.TestAvailable(InteractionPoint.ActionType.Repair))
					{
						list.Add(furniture2);
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (Furniture item3 in from x in list
					orderby x.PathFailCount, x.upg.Quality
					select x)
				{
					InteractionPoint interactionPoint = item3.GetInteractionPoint(self, InteractionPoint.ActionType.Repair);
					if (interactionPoint != null)
					{
						if (self.PathToFurniture(interactionPoint, true))
						{
							return 2;
						}
						if (!NotificationManager.CheckAggregate<UnreachableFurn>(item3))
						{
							NotificationManager.AddNotification(new UnreachableFurn(item3));
						}
					}
				}
			}
			list.Clear();
		}
		if (!flag && (self.OnCall || self.LeaveWhenDone))
		{
			self.GoHomeNow = true;
		}
		self.LastCheckWait = 30f;
		return 0;
	}

	private static int GoToRepair(Actor self)
	{
		bool num = self.WalkPath();
		if (num && self.UsingPoint != null && self.UsingPoint.TurnTo)
		{
			self.TurnToFurniture();
		}
		if (!num)
		{
			return 1;
		}
		return 2;
	}

	private static int ParentLoiter(Actor self)
	{
		if (TimeOfDay.Instance.Hour >= 8 && TimeOfDay.Instance.Hour < 12)
		{
			return 2;
		}
		if (TimeOfDay.Instance.Hour >= 22 || TimeOfDay.Instance.Hour <= 6)
		{
			return 2;
		}
		if (self.UsingPoint == null)
		{
			if (self.GoToFurniture("Computer", InteractionPoint.ActionType.Use, -1, false) != 0)
			{
				return 1;
			}
			return 2;
		}
		if (self.CurrentPath != null)
		{
			if (self.WalkPath())
			{
				self.TurnToFurniture();
			}
			return 1;
		}
		if (!self.UsingPoint.Parent.IsOn)
		{
			self.UsingPoint.Parent.IsOn = true;
		}
		Actor.AnimationStates currentAnimState = self.CurrentAnimState;
		if ((currentAnimState == Actor.AnimationStates.HappyKeyboard || (currentAnimState == Actor.AnimationStates.Work && self.anim.GetFloat("Blend2") <= 0f)) && !self.AudioComp.isPlaying && self.MayPlaySound())
		{
			self.AudioComp.clip = self.KeyboardSFX.GetRandom();
			self.AudioComp.Play();
		}
		self.SetAnim(Actor.AnimationStates.Work);
		return 1;
	}

	private static int ShouldGoToWork(Actor self)
	{
		if (TimeOfDay.Instance.Hour >= 8 && TimeOfDay.Instance.Hour < 12)
		{
			if (self.UsingPoint != null)
			{
				self.UsingPoint.Parent.IsOn = false;
				self.UsingPoint = null;
			}
			return 2;
		}
		return 0;
	}

	private static int ShouldGoToSleep(Actor self)
	{
		if (TimeOfDay.Instance.Hour >= 22 || TimeOfDay.Instance.Hour <= 6)
		{
			if (self.UsingPoint != null)
			{
				self.UsingPoint.Parent.IsOn = false;
				self.UsingPoint = null;
			}
			if (self.GoToFurniture("Bed", InteractionPoint.ActionType.Use, -1, false) != 0)
			{
				return 2;
			}
		}
		return 0;
	}

	private static int ParentDespawn(Actor self)
	{
		foreach (InteractionPoint value in self.InQueue.Values)
		{
			value.RemoveFromQueue(self);
		}
		self.InQueue.Clear();
		SDateTime sDateTime = SDateTime.Now();
		sDateTime = ((TimeOfDay.Instance.Hour >= 21) ? new SDateTime(0, 7, sDateTime.Day + 1, sDateTime.Month, sDateTime.Year) : ((TimeOfDay.Instance.Hour > 6) ? new SDateTime(0, 16, sDateTime.Day, sDateTime.Month, sDateTime.Year) : new SDateTime(0, 7, sDateTime.Day, sDateTime.Month, sDateTime.Year)));
		GameSettings.Instance.sActorManager.AddToAwaiting(self, sDateTime);
		CarScript myCar = self.MyCar;
		self.OnDespawn();
		if (myCar != null)
		{
			self.MyCar = myCar;
			myCar.ForceAddOccupant(self);
		}
		return 2;
	}

	private static int FindBurglar(Actor self)
	{
		if (self.TargetActor == null)
		{
			return 0;
		}
		if (InRange(self, 16f))
		{
			self.ClearPath();
			return 2;
		}
		if (self.CurrentPath == null)
		{
			if (self.TargetActor.CurrentPath != null && (self.ActualPosition - self.TargetActor.CurrentPath.Last()).sqrMagnitude < 1f)
			{
				self.SetAnim(Actor.AnimationStates.Idle);
				return 1;
			}
			if (!PathToBurg(self))
			{
				return 0;
			}
			return 1;
		}
		if (self.TargetActor.CurrentPath != null && (self.TargetActor.CurrentPath.Last() - self.CurrentPath.Last()).sqrMagnitude > 64f)
		{
			if (!PathToBurg(self))
			{
				return 0;
			}
			return 1;
		}
		self.WalkPath();
		return 1;
	}

	private static bool PathToBurg(Actor self)
	{
		Vector3 e = self.TargetActor.ActualPosition;
		if (self.TargetActor.CurrentPath != null)
		{
			e = self.TargetActor.CurrentPath.Last();
		}
		if (!self.PathToPoint(e, true))
		{
			return false;
		}
		return true;
	}

	private static bool InRange(Actor self, float sqrDist = 1f)
	{
		if (self.currentRoom == self.TargetActor.currentRoom)
		{
			return (self.ActualPosition.FlattenVector3() - self.TargetActor.ActualPosition.FlattenVector3()).sqrMagnitude < sqrDist;
		}
		return false;
	}

	private static int AnyBurglar(Actor self)
	{
		if (!(self.TargetActor != null))
		{
			return 0;
		}
		return 2;
	}

	private static int StartArrest(Actor self)
	{
		if (self.TargetActor == null)
		{
			return 2;
		}
		if (self.CurrentPath != null && !self.WalkPath())
		{
			return 1;
		}
		if (InRange(self))
		{
			self.TargetActor.Arrest(true, self.MyCar);
			return 2;
		}
		Vector3? validPointNear = self.TargetActor.currentRoom.GetValidPointNear(self.TargetActor.ActualPosition, 0.5f, true);
		if (validPointNear.HasValue && (validPointNear.Value - self.TargetActor.ActualPosition).sqrMagnitude < 1f && self.PathToPoint(validPointNear.Value))
		{
			self.TargetActor.Arrest(false, self.MyCar);
			return 1;
		}
		self.TargetActor.Arrest(true, self.MyCar);
		return 2;
	}

	private static bool PathToConfiscation(Furniture furn, Actor self)
	{
		Vector3 vector = furn.transform.position + furn.transform.rotation * new Vector3(0f, 0f, 0.5f);
		Vector3? validPointNear = furn.Parent.FindFloorAtrium(vector).GetValidPointNear(vector, 0f, true);
		if (validPointNear.HasValue && self.PathToPoint(validPointNear.Value, true))
		{
			if (furn.Parent != self.CleaningRoom)
			{
				PathVector pathVector = self.CurrentPath.Last();
				self.CurrentPath.Add(new PathVector(pathVector.x, furn.Parent.Floor * 2, pathVector.z));
			}
			return true;
		}
		return false;
	}

	private static void FindFirstConfiscation(Actor self)
	{
		Vector2 point = self.transform.position.FlattenVector3();
		foreach (Furniture item in from x in GameSettings.Instance.sRoomManager.AllFurniture
			where x.IsAliveNotNull() && !x.FireProtection && "PreciousMetal".Equals(x.Type) && x.Reserved == null
			orderby x.transform.position.FlattenVector3().ManhattanDist(point)
			select x)
		{
			if (PathToConfiscation(item, self))
			{
				self.Reserved = item;
				break;
			}
			GameSettings.Instance.DispatchConfiscator(item);
		}
	}

	private static void Confiscate(Furniture f)
	{
		if (f != null)
		{
			f.Undo = true;
			f.DestroyGO();
		}
	}

	private static int FindConfiscation(Actor self)
	{
		if (!self.IgnoreOffSalary)
		{
			return 0;
		}
		if (self.Timer >= 0f)
		{
			self.SetAnim(Actor.AnimationStates.Steal);
			if (self.Timer < 0.5f)
			{
				Confiscate(self.Reserved);
			}
			if (self.WaitForTimer(-1f) == 2)
			{
				Confiscate(self.Reserved);
				return 2;
			}
			return 1;
		}
		if (self.Reserved == null || self.CurrentPath == null)
		{
			self.Reserved = null;
			FindFirstConfiscation(self);
			if (self.Reserved == null)
			{
				return 0;
			}
		}
		else if (self.CurrentPath != null && self.WalkPath() && self.Reserved != null)
		{
			self.InitiateTurn(Quaternion.LookRotation(self.Reserved.transform.position.ReplaceY(0f) - self.ActualPosition.ReplaceY(0f)).eulerAngles.y);
			self.Timer = 1f;
		}
		return 1;
	}

	private static int GoToReceptionDesk(Actor self)
	{
		int num = self.GoToFurniture("Desk", InteractionPoint.ActionType.Use, -1, true, null, false, true);
		if (self.UsingPoint == null)
		{
			return 0;
		}
		if (num == 2)
		{
			self.SetAnim(self.UsingPoint.Animation);
			self.TurnToFurniture();
		}
		return num;
	}

	private static int WaitAtDesk(Actor self)
	{
		if (self.UsingPoint == null)
		{
			return 2;
		}
		ReceptionDesk component = self.UsingPoint.Parent.GetComponent<ReceptionDesk>();
		component.Queue.RemoveAll((Actor x) => x == null);
		if (self.GoHomeNow)
		{
			foreach (Actor item in component.Queue)
			{
				item.CleaningRoom = null;
			}
			self.UsingPoint = null;
			return 2;
		}
		InteractionPoint interactionPoint = self.UsingPoint.Parent.GetInteractionPoint(InteractionPoint.ActionType.Visit, true);
		if (interactionPoint.UsedBy != null && interactionPoint.UsedBy.GoHomeNow)
		{
			interactionPoint.UsedBy.UsingPoint = null;
			interactionPoint.UsedBy = null;
		}
		if (interactionPoint.UsedBy == null && component.Queue.Count > 0)
		{
			Actor actor = component.Queue[0];
			component.Queue.RemoveAt(0);
			actor.ClearPath();
			actor.UsingPoint = interactionPoint;
			interactionPoint.UsedBy = actor;
		}
		return 1;
	}

	private static int IsReceptionOff(Actor self)
	{
		if ((self.UsingPoint == null || self.UsingPoint.Parent.GetInteractionPoint(InteractionPoint.ActionType.Visit, true) == null) && self.GoHomeNow)
		{
			if (self.UsingPoint != null)
			{
				self.UsingPoint.UsedBy = null;
				self.UsingPoint = null;
			}
			return 2;
		}
		return 0;
	}

	private static int SecurityLoiter(Actor self)
	{
		bool flag = self.UsingPoint != null;
		self.SetAnim(flag ? self.UsingPoint.Animation : Actor.AnimationStates.Idle);
		if (ScareOffBurglars(self))
		{
			return 1;
		}
		if (self.Guarding == null && !flag)
		{
			return 2;
		}
		if (flag && self.UsingPoint.Parent.Broken())
		{
			return 2;
		}
		return self.WaitForTimer(30f);
	}

	private static bool ScareOffBurglars(Actor self)
	{
		bool flag = false;
		Actor burg = null;
		foreach (Actor item in GameSettings.Instance.sActorManager.Others["Burglars"])
		{
			if (item.currentRoom == self.currentRoom && item.Floor == self.Floor && !item.AIScript.HasFlag(NodeFlag.GoingHome) && (item.ActualPosition - self.ActualPosition).sqrMagnitude < 25f)
			{
				item.Timer = -1f;
				item.ClearPath();
				item.AIScript.currentNode = item.AIScript.BehaviorNodes["ShouldUseBus"];
				SubScareOffBurglars(item.ActualPosition, item.Floor);
				if (!flag)
				{
					flag = true;
					burg = item;
				}
			}
		}
		if (flag)
		{
			self.RunToBurglar(burg);
			return true;
		}
		return false;
	}

	private static void SubScareOffBurglars(Vector3 p, int floor)
	{
		foreach (Actor item in GameSettings.Instance.sActorManager.Others["Burglars"])
		{
			if (item.Floor == floor && !item.AIScript.HasFlag(NodeFlag.GoingHome) && (item.ActualPosition - p).sqrMagnitude < 25f)
			{
				item.Timer = -1f;
				item.ClearPath();
				item.AIScript.currentNode = item.AIScript.BehaviorNodes["ShouldUseBus"];
			}
		}
	}

	private static int RunToBurglar(Actor self)
	{
		if (ScareOffBurglars(self))
		{
			return 1;
		}
		if (!self.WalkPath())
		{
			return 1;
		}
		return 2;
	}

	private static int FindSurveillance(Actor self)
	{
		InteractionPoint interactionPoint = null;
		if (self.AtFurniture && self.UsingPoint != null)
		{
			interactionPoint = self.UsingPoint;
		}
		int num = self.GoToFurniture("SurveillanceDesk", InteractionPoint.ActionType.Use, -1, false, null, false, true);
		if (num == 1 && ScareOffBurglars(self))
		{
			return 1;
		}
		switch (num)
		{
		case 2:
			self.TurnToFurniture();
			break;
		case 0:
			if (interactionPoint != null)
			{
				self.AtFurniture = true;
				self.UsingPoint = interactionPoint;
			}
			break;
		}
		return num;
	}

	private static int FindDesk(Actor self)
	{
		if (ScareOffBurglars(self))
		{
			return 1;
		}
		int num = self.GoToFurniture("SecurityDesk", InteractionPoint.ActionType.Use, -1, false, null, false, true);
		if (num == 2)
		{
			self.TurnToFurniture();
		}
		return num;
	}

	private static int HasEntrance(Actor self)
	{
		if (!(self.Guarding != null))
		{
			return 0;
		}
		return 2;
	}

	private static int ValidateEntrance(Actor self)
	{
		if (self.UsingPoint != null)
		{
			if ("SurveillanceDesk".Equals(self.UsingPoint.Parent.Type))
			{
				InteractionPoint usingPoint = self.UsingPoint;
				bool atFurniture = self.AtFurniture;
				if (self.GoToFurniture("SurveillanceDesk", InteractionPoint.ActionType.Use, -1, false, null, false, true) == 0)
				{
					self.UsingPoint = usingPoint;
					self.AtFurniture = atFurniture;
				}
			}
			return 0;
		}
		if (self.GoToFurniture("SurveillanceDesk", InteractionPoint.ActionType.Use, -1, false, null, false, true) != 0)
		{
			self.Guarding = null;
			return 0;
		}
		if (self.GoToFurniture("SecurityDesk", InteractionPoint.ActionType.Use, -1, false, null, false, true) != 0)
		{
			self.Guarding = null;
			return 0;
		}
		if (self.Guarding != null)
		{
			RoomSegment bestSegment = GetBestSegment(self);
			if (bestSegment != null && bestSegment.GuardedBy.Count == 0)
			{
				self.Guarding = bestSegment;
				return 2;
			}
			return 0;
		}
		return 0;
	}

	private static RoomSegment GetBestSegment(Actor self)
	{
		RoomSegment roomSegment = null;
		if (self.HasAssignedRooms)
		{
			HashSet<Room> rooms = self.GetAssignedRooms().ToHashSet();
			roomSegment = GameSettings.Instance.sRoomManager.RoomSegments.Where((RoomSegment x) => BelongsToGroup(x, rooms) && x.IsConnectedToOutside(rooms) && HasMoreEntrances(x, rooms)).MinMaxInstance(BestSegCompare);
		}
		else
		{
			roomSegment = GameSettings.Instance.sRoomManager.RoomSegments.Where((RoomSegment x) => x.IsConnectedToOutside(true)).MinMaxInstance(BestSegCompare);
		}
		if (roomSegment == null && !NotificationManager.CheckAggregate<GuardIssueNotification>(self))
		{
			NotificationManager.AddNotification(new GuardIssueNotification(self));
		}
		return roomSegment;
	}

	private static bool BelongsToGroup(RoomSegment s, HashSet<Room> rooms)
	{
		if (s.ParentRooms[0] == null || !rooms.Contains(s.ParentRooms[0]))
		{
			if (s.ParentRooms[1] != null)
			{
				return rooms.Contains(s.ParentRooms[1]);
			}
			return false;
		}
		return true;
	}

	private static bool HasMoreEntrances(RoomSegment s, HashSet<Room> rooms)
	{
		if (s.ParentRooms[0] == null)
		{
			return true;
		}
		if (s.ParentRooms[1] == null)
		{
			return true;
		}
		Room room = (Room)(rooms.Contains(s.ParentRooms[0]) ? s.ParentRooms[1] : s.ParentRooms[0]);
		if (!room.NavmeshRebuildStarted && room.PathNodes != null && room.PathNodes.Count > 0)
		{
			return room.PathNodes[0].GetConnections().Count != 1;
		}
		return true;
	}

	private static int FindEntrance(Actor self)
	{
		self.Guarding = GetBestSegment(self);
		if (self.Guarding != null)
		{
			self.UsingPoint = null;
			return 2;
		}
		return 0;
	}

	private static Room GetOutside(Actor self)
	{
		if (self.HasAssignedRooms)
		{
			if (self.Guarding.ParentRooms[0] == null)
			{
				return GameSettings.Instance.sRoomManager.Outside;
			}
			if (self.Guarding.ParentRooms[1] == null)
			{
				return GameSettings.Instance.sRoomManager.Outside;
			}
			if (self.GetAssignedRooms().Contains(self.Guarding.ParentRooms[0]))
			{
				return (Room)self.Guarding.ParentRooms[1];
			}
			return (Room)self.Guarding.ParentRooms[0];
		}
		return GameSettings.Instance.sRoomManager.Outside;
	}

	private static int GotoEntrance(Actor self)
	{
		if (self.Guarding == null)
		{
			return 0;
		}
		if (self.CurrentPath != null)
		{
			if (ScareOffBurglars(self))
			{
				return 1;
			}
			if (self.WalkPath())
			{
				self.InitiateTurn(self.Guarding.GetDoorAngle(GetOutside(self)));
				return 2;
			}
			return 1;
		}
		Vector3? vector = null;
		Room outside = GetOutside(self);
		if (self.Guarding.Floor > 0 && outside.Outside)
		{
			Vector3 offsetPos = self.Guarding.GetOffsetPos(GameSettings.Instance.sRoomManager.Outside);
			Vector3 position = self.Guarding.transform.position;
			Vector3 normalized = (offsetPos - position).normalized;
			Vector3 vector2 = new Vector3(0f - normalized.z, normalized.y, normalized.x);
			vector = position + normalized * 0.5f + ((UnityEngine.Random.value > 0.5f) ? vector2 : (-vector2)) * self.Guarding.WallWidth * 0.5f;
		}
		else
		{
			float num = self.Guarding.GetDoorAngle(outside) * ((float)Math.PI / 180f);
			float angleFrom;
			float angleTo;
			if (UnityEngine.Random.value > 0.5f)
			{
				angleFrom = num - 1.2217305f;
				angleTo = num - 0.61086524f;
			}
			else
			{
				angleFrom = num + 0.61086524f;
				angleTo = num + 1.2217305f;
			}
			Vector3? validPointNear = outside.GetValidPointNear(self.Guarding.transform.position, 1f, true, angleFrom, angleTo);
			if (validPointNear.HasValue)
			{
				vector = validPointNear.Value;
			}
		}
		if (vector.HasValue && self.PathToPoint(vector.Value, true))
		{
			return 1;
		}
		self.Guarding = null;
		return 0;
	}

	private static int SecurityIsOff(Actor self)
	{
		int num = IsStaffOff(self);
		if (num == 2)
		{
			self.Guarding = null;
			if (self.UsingPoint != null)
			{
				self.UsingPoint.UsedBy = null;
				self.UsingPoint = null;
			}
		}
		return num;
	}
}
