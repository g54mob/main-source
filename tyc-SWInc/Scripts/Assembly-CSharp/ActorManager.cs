using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActorManager
{
	public EventList<Actor> Actors = new EventList<Actor>();

	public EventList<Actor> Staff = new EventList<Actor>();

	public HashSet<Actor> ReadyForBus = new HashSet<Actor>();

	public Dictionary<string, HashSet<Actor>> Others = new Dictionary<string, HashSet<Actor>>
	{
		{
			"Guests",
			new HashSet<Actor>()
		},
		{
			"Burglars",
			new HashSet<Actor>()
		},
		{
			"Police",
			new HashSet<Actor>()
		},
		{
			"FireInspector",
			new HashSet<Actor>()
		},
		{
			"FireFighter",
			new HashSet<Actor>()
		},
		{
			"Parent",
			new HashSet<Actor>()
		}
	};

	public HashSet<Actor> ReadyForHome = new HashSet<Actor>();

	private Dictionary<Actor, SDateTime> Awaiting = new Dictionary<Actor, SDateTime>();

	public Dictionary<string, Team> Teams = new Dictionary<string, Team> { 
	{
		"Core",
		new Team("Core", true)
	} };

	[NonSerialized]
	private List<Actor> Deletes = new List<Actor>();

	[NonSerialized]
	private List<Actor> AvailableCache = new List<Actor>();

	public float Delay;

	public void FixEmployment()
	{
		if (!Actors.All((Actor x) => x.employee.MyEmployer == null))
		{
			return;
		}
		foreach (Actor actor in Actors)
		{
			actor.employee.MyEmployer = GameSettings.Instance.MyCompany;
		}
		foreach (Actor item in Staff)
		{
			item.employee.MyEmployer = GameSettings.Instance.MyCompany;
		}
	}

	public void PushAwaiting(float months, bool clearGuests)
	{
		int day = Mathf.FloorToInt(months * (float)GameSettings.DaysPerMonth) % GameSettings.DaysPerMonth;
		int month = Mathf.FloorToInt(months);
		SDateTime sDateTime = new SDateTime(day, month, 0);
		List<KeyValuePair<Actor, SDateTime>> list = Awaiting.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			KeyValuePair<Actor, SDateTime> keyValuePair = list[i];
			if (clearGuests && keyValuePair.Key.AItype == AI.AIType.Guest)
			{
				Awaiting.Remove(keyValuePair.Key);
				keyValuePair.Key.DestroyGO();
			}
			else
			{
				Awaiting[keyValuePair.Key] = keyValuePair.Value + sDateTime;
			}
		}
	}

	public ActorManager()
	{
		Actors.OnChange = UpdateActorWindow;
		Staff.OnChange = UpdateStaffWindow;
	}

	public IEnumerable<Actor> AllActors()
	{
		foreach (Actor actor in Actors)
		{
			yield return actor;
		}
		foreach (Actor item in Staff)
		{
			yield return item;
		}
		foreach (HashSet<Actor> value in Others.Values)
		{
			foreach (Actor item2 in value)
			{
				yield return item2;
			}
		}
	}

	public void UpdateActorWindow()
	{
		if (HUD.Instance != null && HUD.Instance.employeeWindow != null && HUD.Instance.employeeWindow.EmployeeList != null)
		{
			HUD.Instance.employeeWindow.UpdateEmployeeList();
			HUD.Instance.employeeWindow.UpdateEdNumber();
		}
	}

	public void UpdateStaffWindow()
	{
		if (HUD.Instance != null && HUD.Instance.staffWindow != null && HUD.Instance.staffWindow.StaffList != null)
		{
			Staff.Update(HUD.Instance.staffWindow.StaffList.Items);
		}
	}

	public void RemoveTeam(string name)
	{
		if (Teams.ContainsKey(name))
		{
			Team team = Teams[name];
			team.ClearTaskCompatibilities();
			team.PauseTaskCompRefresh();
			team.GetEmployees().ToList().ForEach(delegate(Actor x)
			{
				x.Team = null;
			});
			GameSettings.Instance.MyCompany.WorkItems.ForEachEnum(delegate(WorkItem x)
			{
				x.RemoveDevTeam(team);
			});
			Teams.Remove(name);
			GameSettings.Instance.RemoveTeamAssociation(team);
			CalendarWindow.ScheduleRefresh = true;
			GlobalSearchPanel.Instance.RemoveSearchItem(team);
			GlobalSearchPanel.Instance.RemoveSearchItem(team.HR);
		}
	}

	public void ApplySearchToTeam(Team team)
	{
		GlobalSearchPanel.Instance.AddSearchItem(team, team.Name, delegate
		{
			HUD.Instance.TeamWindow.Window.Show();
			HUD.Instance.TeamWindow.Init();
			HUD.Instance.TeamWindow.TeamList.Select(team);
		}, "MoreEmployees", false);
		GlobalSearchPanel.Instance.AddSearchItem(team.HR, team.Name + " " + "HR".Loc(), delegate
		{
			HUD.Instance.TeamWindow.autoWindow.Show(team);
		}, "MoreEmployees", false);
	}

	public void RenameTeam(string name, string newName)
	{
		if (Teams.ContainsKey(newName))
		{
			WindowManager.Instance.ShowMessageBox("TeamNameError".Loc(), false, DialogWindow.DialogType.Error);
		}
		else
		{
			Team oldTeam;
			if (!Teams.TryGetValue(name, out oldTeam))
			{
				return;
			}
			GlobalSearchPanel.Instance.RemoveSearchItem(oldTeam);
			GlobalSearchPanel.Instance.RemoveSearchItem(oldTeam.HR);
			Team newTeam = new Team(oldTeam, newName, true);
			Teams[newName] = newTeam;
			oldTeam.MeetingTable = null;
			oldTeam.HR = new HRManagement();
			oldTeam.ClearTaskCompatibilities();
			oldTeam.PauseTaskCompRefresh();
			newTeam.Leader = oldTeam.Leader;
			Actor[] employees = oldTeam.GetEmployees();
			for (int i = 0; i < employees.Length; i++)
			{
				employees[i].TeamRename(newTeam);
			}
			newTeam.PauseTaskCompRefresh();
			GameSettings.Instance.MyCompany.WorkItems.ForEachEnum(delegate(WorkItem x)
			{
				x.SwitchDevTeam(oldTeam, newTeam);
			});
			(from x in GameSettings.Instance.MyCompany.WorkItems.OfType<DesignDocument>()
				where x.NextPhaseTeam != null
				select x).ForEachEnum(delegate(DesignDocument x)
			{
				if (x.NextPhaseTeam.Contains(name))
				{
					x.NextPhaseTeam.Remove(name);
					x.NextPhaseTeam.Add(newName);
				}
			});
			Teams.Remove(name);
			GameSettings.Instance.SwitchTeamAssociation(oldTeam, newTeam);
			HUD.Instance.TeamWindow.TeamList.Items = GameSettings.Instance.sActorManager.Teams.Values.Cast<object>().ToList();
			AutomationWindow autoWindow = HUD.Instance.TeamWindow.autoWindow;
			if (autoWindow.Window.Shown)
			{
				for (int num = 0; num < autoWindow.Teams.Length; num++)
				{
					if (autoWindow.Teams[num] == oldTeam)
					{
						autoWindow.Teams[num] = newTeam;
						autoWindow.Initialize();
						break;
					}
				}
			}
			newTeam.CalculateCompatibility();
			for (int num2 = 0; num2 < newTeam.WorkItems.Count; num2++)
			{
				SoftwareWorkItem softwareWorkItem;
				if ((softwareWorkItem = newTeam.WorkItems[num2] as SoftwareWorkItem) != null)
				{
					softwareWorkItem.UpdateWorking();
				}
			}
			GameSettings.Instance.CheckOSLicenses = true;
			newTeam.SetCohesionDirty();
			newTeam.RefreshTaskCompatibility();
			ApplySearchToTeam(newTeam);
		}
	}

	public void RefreshAllTeamTaskCompatibilities()
	{
		Team[] array = Teams.Values.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].PauseTaskCompRefresh(false);
			for (int j = i + 1; j < array.Length; j++)
			{
				if (array[i].CompareTasks(array[j]))
				{
					GameSettings.Instance.TeamTaskComp.Add((array[i].Name.CompareTo(array[j].Name) < 0) ? new ValueTuple<Team, Team>(array[i], array[j]) : new ValueTuple<Team, Team>(array[j], array[i]));
				}
			}
		}
	}

	public List<Actor> GetAwaiting()
	{
		return Awaiting.Keys.ToList();
	}

	public Dictionary<Actor, SDateTime> GetAwaitingDict()
	{
		return Awaiting;
	}

	public SDateTime? GetArriveTime(Actor actor)
	{
		SDateTime value;
		if (!Awaiting.TryGetValue(actor, out value))
		{
			return null;
		}
		return value;
	}

	public void AddToAwaiting(Actor actor, SDateTime time, bool replace = false, bool mainThread = true)
	{
		if (!replace && Awaiting.ContainsKey(actor))
		{
			return;
		}
		if (replace && (!mainThread || !actor.isActiveAndEnabled))
		{
			for (int i = 0; i < RoadManager.Instance.Cars.Count; i++)
			{
				CarScript carScript = RoadManager.Instance.Cars[i];
				for (int j = 0; j < carScript.SpawnPoints.Length; j++)
				{
					carScript.SpawnPoints[j].Occupants.Remove(actor);
				}
			}
		}
		Awaiting[actor] = time;
	}

	public void RemoveFromAwaiting(Actor actor)
	{
		Awaiting.Remove(actor);
		ReadyForBus.Remove(actor);
	}

	public static Func<Room, float> PriorityFunctions(AI.AIType aiType, Actor ac)
	{
		switch (aiType)
		{
		case AI.AIType.IT:
			return delegate(Room x)
			{
				bool flag = ac.IsAssignedRoom(x);
				if ((ac.AssignedRoomGroups.Count == 0 || flag) && x.GetFurniture("ITStation").Count > 0)
				{
					return flag ? (-2) : (-1);
				}
				float num = 2f;
				List<Furniture> furnitures = x.GetFurnitures();
				for (int i = 0; i < furnitures.Count; i++)
				{
					Furniture furniture = furnitures[i];
					if (furniture.HasUpg && furniture.ITFix)
					{
						float num2 = (flag ? furniture.upg.Quality : (furniture.upg.Quality + 1f));
						if (num2 < num)
						{
							num = num2;
						}
					}
				}
				return num;
			};
		case AI.AIType.Janitor:
			return delegate(Room x)
			{
				float num = 2f;
				List<Furniture> furnitures = x.GetFurnitures();
				bool flag = ac.IsAssignedRoom(x);
				for (int i = 0; i < furnitures.Count; i++)
				{
					Furniture furniture = furnitures[i];
					if (furniture.HasUpg && !furniture.ITFix)
					{
						float num2 = (flag ? furniture.upg.Quality : (furniture.upg.Quality + 1f));
						if (num2 < num)
						{
							num = num2;
						}
					}
				}
				return num;
			};
		case AI.AIType.Courier:
			return delegate(Room x)
			{
				int num = 2;
				if (x.IsPlayerControlled())
				{
					HashList<Furniture> furniture = x.GetFurniture("Pallet");
					for (int i = 0; i < furniture.Count; i++)
					{
						if (furniture[i].Conveyor.GaragePort)
						{
							num = 0;
							break;
						}
						num = 1;
					}
				}
				return num;
			};
		case AI.AIType.Cleaning:
			return (Room x) => (!ac.IsAssignedRoom(x)) ? (x.DirtScore + 1f) : x.DirtScore;
		case AI.AIType.Receptionist:
			return (Room x) => (!ac.IsAssignedRoom(x)) ? ((x.GetFurniture("Desk").Count > 0) ? 1 : 2) : 0;
		case AI.AIType.Guest:
			return (Room x) => (x.GetFurniture("Desk").Count <= 0) ? 1 : 0;
		case AI.AIType.Cook:
			return (Room x) => (!ac.IsAssignedRoom(x)) ? ((x.GetFurniture("Stove").Count > 0) ? 1 : 2) : 0;
		case AI.AIType.Burglar:
			return (Room x) => x.GetFurnitures().SumSafe((Furniture z) => (!z.CheckCanSteal()) ? 0f : (0f - z.GetSellPriceIgnoreQuality()));
		case AI.AIType.Police:
			return (Room x) => -x.Occupants.Count((Actor z) => z.AItype == AI.AIType.Burglar);
		case AI.AIType.Security:
			return (Room x) => (!ac.IsAssignedRoom(x)) ? ((x.GetFurniture("SecurityDesk").Count > 0 || x.GetFurniture("SurveillanceDesk").Count > 0) ? 1 : ((x.Floor == 0) ? 2 : 3)) : 0;
		default:
			return (Room x) => 1f;
		}
	}

	private bool Compatible(Actor self, Actor other)
	{
		switch (self.AItype)
		{
		case AI.AIType.Janitor:
		case AI.AIType.Cleaning:
		case AI.AIType.IT:
		case AI.AIType.Receptionist:
		case AI.AIType.Security:
			if (other.AItype != AI.AIType.Cleaning && other.AItype != AI.AIType.Janitor && other.AItype != AI.AIType.IT && other.AItype != AI.AIType.Receptionist)
			{
				return other.AItype == AI.AIType.Security;
			}
			return true;
		case AI.AIType.Cook:
			return other.AItype == AI.AIType.Cook;
		case AI.AIType.Courier:
			return other.AItype == AI.AIType.Courier;
		case AI.AIType.Burglar:
			return other.AItype == AI.AIType.Burglar;
		case AI.AIType.Police:
			return other.AItype == AI.AIType.Police;
		case AI.AIType.FireInspector:
			return other.AItype == AI.AIType.FireInspector;
		default:
			return false;
		}
	}

	private RoadNode.ParkingAssign ActorToType(Actor self)
	{
		switch (self.AItype)
		{
		case AI.AIType.Employee:
		case AI.AIType.Robot:
			return RoadNode.ParkingAssign.Employees;
		case AI.AIType.Janitor:
		case AI.AIType.Cleaning:
		case AI.AIType.IT:
		case AI.AIType.Receptionist:
		case AI.AIType.Security:
			return RoadNode.ParkingAssign.Staff;
		case AI.AIType.Guest:
		case AI.AIType.FireInspector:
			return RoadNode.ParkingAssign.Guests;
		case AI.AIType.Cook:
			return RoadNode.ParkingAssign.Cooks;
		case AI.AIType.Courier:
			return RoadNode.ParkingAssign.Deliveries;
		default:
			return RoadNode.ParkingAssign.Anyone;
		}
	}

	public void DoUpdate()
	{
		Deletes.Clear();
		foreach (KeyValuePair<Actor, SDateTime> item in Awaiting)
		{
			if (item.Key.IsAliveNotNull())
			{
				if (item.Key.employee.Dismissed || (item.Key.AItype == AI.AIType.Guest && item.Key.deal != null && !item.Key.deal.StillValid(false)))
				{
					item.Key.DestroyGO();
					Deletes.Add(item.Key);
				}
			}
			else
			{
				Deletes.Add(item.Key);
			}
		}
		for (int i = 0; i < Deletes.Count; i++)
		{
			Awaiting.Remove(Deletes[i]);
			ReadyForBus.Remove(Deletes[i]);
		}
		Deletes.Clear();
		HashSet<Actor> hashSet = new HashSet<Actor>();
		Delay = Mathf.Max(0f, Delay - 1f);
		foreach (KeyValuePair<Actor, SDateTime> item2 in Awaiting)
		{
			if ((item2.Value - SDateTime.Now()).ToInt() >= 0)
			{
				continue;
			}
			Actor key = item2.Key;
			if (hashSet.Contains(key) || Deletes.Contains(key))
			{
				continue;
			}
			if (key.AItype == AI.AIType.Robot)
			{
				Furniture dLCDataDefault = key.GetDLCDataDefault<Furniture>("ChargingStation", null);
				if (dLCDataDefault.IsAliveNotNull())
				{
					key.ActualPosition = dLCDataDefault.transform.position;
					key.transform.rotation = dLCDataDefault.transform.rotation;
					key.enabled = true;
					key.SetVisible(true);
					key.anim.enabled = true;
					key.MeetNow();
					key.DriveTime = SDateTime.Now();
					Deletes.Add(key);
					dLCDataDefault.IsOn = false;
					dLCDataDefault.InteractEnd();
					dLCDataDefault.RemoveDLCData("ChargingUse");
					continue;
				}
			}
			if (key.SpecialState == Actor.HomeState.Sleeping)
			{
				key.MeetNow();
				key.DriveTime = SDateTime.Now();
				key.SpecialState = Actor.HomeState.Default;
				InteractionPoint usingPoint = key.UsingPoint;
				if ((object)usingPoint != null)
				{
					usingPoint.Parent.InteractEnd();
				}
				key.UsingPoint = null;
				key.SetAnim(Actor.AnimationStates.Idle);
				key.SetVisible(key.LastVisible);
				Deletes.Add(key);
				continue;
			}
			Vector3? optimalSpot = null;
			if (GameSettings.Instance.HasSubway && key.AllowAlternativeTraffic())
			{
				optimalSpot = (key.IsEmployee() ? RoadManager.Instance.FindOptimalSpawn(key) : new Vector3?(RoadManager.Instance.FindOptimalStaffSpawn(key, PriorityFunctions(key.AItype, key))));
				if (optimalSpot.HasValue && optimalSpot.Value.x >= 0f && (optimalSpot.Value.FlattenVector3() - GameSettings.Instance.ActiveSubway.Center()).sqrMagnitude < Subway.MaxDistanceSq)
				{
					Deletes.Add(key);
					GameSettings.Instance.ActiveSubway.SpawnActor(key);
					continue;
				}
			}
			CarScript carScript = ((key.AItype == AI.AIType.Robot) ? null : RoadManager.Instance.SendCar(key, PriorityFunctions(key.AItype, key), ActorToType(key), Delay, optimalSpot, key.employee.HasTrait(Employee.Trait.WalkInstead)));
			if (carScript == null || !carScript.gameObject.activeSelf)
			{
				if (key.AItype == AI.AIType.Courier)
				{
					if (!NotificationManager.CheckAggregate<CourierParkNotification>(null))
					{
						NotificationManager.AddNotification(new CourierParkNotification(SDateTime.Now()));
					}
					continue;
				}
				if (key.AItype == AI.AIType.Burglar)
				{
					Deletes.Add(key);
					key.DestroyGO();
					continue;
				}
				if (optimalSpot.HasValue && optimalSpot.Value.x >= 0f && GameSettings.Instance.HasSubway && key.IsEmployee())
				{
					Vector2 vector = GameSettings.Instance.BusStopSign.transform.position.FlattenVector3();
					if ((optimalSpot.Value.FlattenVector3() - GameSettings.Instance.ActiveSubway.Center()).sqrMagnitude < (optimalSpot.Value.FlattenVector3() - vector).sqrMagnitude)
					{
						Deletes.Add(key);
						GameSettings.Instance.ActiveSubway.SpawnActor(key);
						continue;
					}
				}
				if (ReadyForBus.Count < 16)
				{
					Deletes.Add(key);
					ReadyForBus.Add(key);
				}
				else
				{
					NotificationManager.AddNotification("BusFullWarning".Loc(), "Bus", NotificationManager.NotificationType.Warning, UniqueNotification.MessageID.BusFull);
				}
				continue;
			}
			if (key.AItype == AI.AIType.Courier)
			{
				NotificationManager.RemoveAggregate<CourierParkNotification>(null);
			}
			Delay = Mathf.Min(50f, Delay + UnityEngine.Random.Range(0.25f, 0.75f));
			AvailableCache.Clear();
			Deletes.Add(key);
			if (key.IsEmployee())
			{
				if (key.Team != null)
				{
					Actor localActor = key;
					SDateTime time = SDateTime.Now();
					AvailableCache.AddRange(from x in Awaiting
						where x.Value.Day == time.Day && x.Value.Month == time.Month && x.Value.Year == time.Year && x.Key != localActor && !x.Key.employee.HasTrait(Employee.Trait.WalkInstead) && !x.Key.employee.HasDemanded(LeadDesignDemands.Demand.LuxuryCar) && x.Key.Team != null && x.Key.Team.Equals(localActor.Team) && !Deletes.Contains(x.Key)
						select x.Key);
				}
			}
			else if (key.AItype != AI.AIType.Guest && carScript.Capacity > 1)
			{
				Actor localActor2 = key;
				SDateTime time2 = SDateTime.Now();
				AvailableCache.AddRange(from x in Awaiting
					where x.Key != localActor2 && Compatible(localActor2, x.Key) && x.Value.Day == time2.Day && x.Value.Month == time2.Month && x.Value.Year == time2.Year && localActor2.StaffOn == x.Key.StaffOn && !Deletes.Contains(x.Key)
					select x.Key);
			}
			int num = 0;
			int count = Deletes.Count;
			for (int num2 = 0; num2 < AvailableCache.Count; num2++)
			{
				if (num >= carScript.Capacity - 1)
				{
					break;
				}
				if (!hashSet.Contains(AvailableCache[num2]))
				{
					if (carScript.AddOccupant(AvailableCache[num2], true) == null)
					{
						break;
					}
					num++;
					hashSet.Add(AvailableCache[num2]);
					Deletes.Add(AvailableCache[num2]);
				}
			}
			if (key.AItype == AI.AIType.Employee)
			{
				for (int num3 = count; num3 < Deletes.Count; num3++)
				{
					Deletes[num3].InteractWith(key);
					for (int num4 = num3 + 1; num4 < Deletes.Count; num4++)
					{
						Deletes[num3].InteractWith(Deletes[num4]);
					}
				}
			}
			hashSet.Add(key);
		}
		for (int num5 = 0; num5 < Deletes.Count; num5++)
		{
			Awaiting.Remove(Deletes[num5]);
		}
		int num6 = 0;
		for (int num7 = 0; num7 < Actors.Count; num7++)
		{
			Actor actor = Actors[num7];
			if (actor.IsAliveNotNull() && !actor.isActiveAndEnabled && !actor.employee.Dismissed && Mathf.Abs(TimeOfDay.Instance.Hour - actor.SpawnTime) > 2 && !ReadyForBus.Contains(actor) && !hashSet.Contains(actor) && !Awaiting.ContainsKey(actor) && !RoadManager.Instance.Cars.Any((CarScript x) => x.ContainsOccupant(actor)))
			{
				AddToAwaiting(time: new SDateTime(0, actor.SpawnTime, TimeOfDay.Instance.Day, TimeOfDay.Instance.Month, TimeOfDay.Instance.Year), actor: actor);
				num6++;
			}
		}
		for (int num8 = 0; num8 < Staff.Count; num8++)
		{
			Actor actor2 = Staff[num8];
			if (actor2.IsAliveNotNull() && !actor2.isActiveAndEnabled && !actor2.employee.Dismissed && Mathf.Abs(TimeOfDay.Instance.Hour - actor2.SpawnTime) > 2 && !ReadyForBus.Contains(actor2) && !hashSet.Contains(actor2) && !Awaiting.ContainsKey(actor2) && !RoadManager.Instance.Cars.Any((CarScript x) => x.ContainsOccupant(actor2)))
			{
				AddToAwaiting(time: new SDateTime(0, actor2.SpawnTime, TimeOfDay.Instance.Day, TimeOfDay.Instance.Month, TimeOfDay.Instance.Year), actor: actor2);
				num6++;
			}
		}
		if (num6 > 0)
		{
			Debug.Log("Added {0} missing people to awaiting".Format(num6));
		}
	}
}
