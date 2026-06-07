using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using AltSerialize;
using UnityEngine;

public class GameReader : MonoBehaviour
{
	public struct LoadMessage
	{
		public string Message;

		public int Value;

		public float Done;

		public bool UseValue;

		public LoadMessage(string message)
		{
			Message = message;
			Value = 0;
			Done = 0f;
			UseValue = false;
		}

		public LoadMessage(string message, int value, float done)
		{
			Message = message;
			Value = value;
			Done = done;
			UseValue = true;
		}
	}

	public enum LoadMode
	{
		Full = 0,
		Building = 1,
		Company = 2
	}

	[Flags]
	public enum NewLoadMode
	{
		None = 0,
		Full = 1,
		Building = 2,
		Company = 4,
		Any = 7,
		FullOrBuilding = 3,
		FullOrCompany = 5,
		BuildingOrCompany = 6
	}

	private static Dictionary<string, uint> _notLoadedFurniture = new Dictionary<string, uint>();

	private static Dictionary<string, string> _furnitureReplacement = new Dictionary<string, string>();

	public static ReaderWriterLockSlim SaveLock = new ReaderWriterLockSlim();

	private static bool _friendshipsLoaded = false;

	private static Dictionary<string, string> _dictToDesc = new Dictionary<string, string>
	{
		{ "RoomSegment", "LoadRoomSegment" },
		{ "Furniture", "LoadFurniture" },
		{ "Actor", "LoadActor" }
	};

	private static Versioning.Version TempRemoveV = new Versioning.Version(Versioning.VersionType.Alpha, 11, 4, 1);

	private static Versioning.Version PrintRemoveV = new Versioning.Version(Versioning.VersionType.Alpha, 11, 7, 0);

	private static Versioning.Version NewRoomSer = new Versioning.Version(Versioning.VersionType.Alpha, 11, 5, 6);

	private static Versioning.Version AnimFix = new Versioning.Version(Versioning.VersionType.Beta, 1, 1, 19);

	private static Versioning.Version LeadDesignerProjectFix = new Versioning.Version(Versioning.VersionType.Beta, 1, 3, 17);

	private static Versioning.Version CompanyLogoFix = new Versioning.Version(Versioning.VersionType.Beta, 1, 5, 1);

	private static Versioning.Version ShelfFix = new Versioning.Version(Versioning.VersionType.Beta, 1, 6, 1);

	private static Versioning.Version Networking = new Versioning.Version(Versioning.VersionType.Beta, 1, 7, 1);

	private static Versioning.Version NetworkPathFix = new Versioning.Version(Versioning.VersionType.Beta, 1, 7, 34);

	private static Versioning.Version ToolOverhaul = new Versioning.Version(Versioning.VersionType.Beta, 1, 8, 11);

	private static Versioning.Version ReviewSystem = new Versioning.Version(Versioning.VersionType.Beta, 1, 8, 31);

	private static Versioning.Version RemovePalletPoint = new Versioning.Version(Versioning.VersionType.Beta, 1, 8, 36);

	public static Versioning.Version AddTrash = new Versioning.Version(Versioning.VersionType.Beta, 1, 8, 36);

	private static Dictionary<string, float> IgnoreTempFurn = new Dictionary<string, float>
	{
		{ "AC Unit", 1000f },
		{ "Radiator", 150f },
		{ "Central Heating", 1000f },
		{ "Ventilation", 150f }
	};

	private static Dictionary<string, float> IgnorePrintFurn = new Dictionary<string, float>
	{
		{ "Small Product Printer", 20000f },
		{ "Medium Product Printer", 50000f },
		{ "Large Product Printer", 60000f },
		{ "Pallet", 200f },
		{ "Box Chute", 1000f }
	};

	private static Dictionary<string, float> IgnorePalletFurn = new Dictionary<string, float>
	{
		{ "Pallet Drop Point", 100f },
		{ "Pallet Pickup Point", 100f }
	};

	public static HashSet<uint> SerializedDIDs = new HashSet<uint>();

	public static bool ForceWrite = false;

	public static string DIDClash = null;

	public static object WriteLock = new object();

	public static void DebugBuildLoadGame(string filename)
	{
		Writeable.IDCount = 1u;
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		GameSettings.Instance.sRoomManager.DisableMeshRebuild = true;
		TimeProbe.BeginTime("Rebuild room time:");
		using (MemoryStream serializationStream = new MemoryStream(Utilities.ReadData(filename, "Rooms")))
		{
			((RoomDescriptor)binaryFormatter.Deserialize(serializationStream)).BuildRooms(() => UnityEngine.Object.Instantiate(BuildController.Instance.RoomPrefab), true);
		}
		TimeProbe.FinalizeTime("Rebuild room time:");
		GameSettings.Instance.sRoomManager.DisableMeshRebuild = false;
		TimeProbe.BeginTime("Room mesh rebuild time:");
		for (int num = -1; num <= GameSettings.MaxFloor; num++)
		{
			GameSettings.Instance.sRoomManager.UpdateFloorMeshes(num);
		}
		TimeProbe.FinalizeTime("Room mesh rebuild time:");
		GameSettings.Instance.sRoomManager.RoomNearnessDirty = true;
		HUD.Instance.companyWindow.Bind();
		HUD.Instance.TeamWindow.TeamList.Items = GameSettings.Instance.sActorManager.Teams.Values.Cast<object>().ToList();
		HUD.Instance.loanWindow.UpdateLoans();
	}

	public static LoadMode BackConvert(NewLoadMode l)
	{
		if (l.Is(NewLoadMode.Building))
		{
			return LoadMode.Building;
		}
		if (l.Is(NewLoadMode.Company))
		{
			return LoadMode.Company;
		}
		return LoadMode.Full;
	}

	public static byte[] Decompress(byte[] dat)
	{
		using (MemoryStream stream = new MemoryStream(dat))
		{
			using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress, false))
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					gZipStream.CopyTo(memoryStream, 16384);
					dat = memoryStream.ToArray();
					return dat;
				}
			}
		}
	}

	public static byte[] Compress(byte[] dat)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, false))
			{
				gZipStream.Write(dat, 0, dat.Length);
			}
			dat = memoryStream.ToArray();
			return dat;
		}
	}

	public static int GetFloatConVersion(Versioning.Version v)
	{
		if (v.Before(new Versioning.Version(Versioning.VersionType.Beta, 1, 7, 35)))
		{
			return 0;
		}
		if (v.Before(new Versioning.Version(Versioning.VersionType.Beta, 1, 7, 36)))
		{
			return 1;
		}
		return -1;
	}

	public static IEnumerator<LoadMessage> LoadGame(string filename, SaveGame game, NewLoadMode mode, bool resource, Writeable.LoadType networkMode)
	{
		UnityEngine.Debug.Log("Loading game: " + Path.GetFileName(filename));
		if (game.NetworkData != null)
		{
			GameSettings.Instance.NetworkData = new NetworkMeta(game.NetworkData);
			GameSettings.Instance.NetworkData.ClearActivePlayers();
		}
		Writeable.IDCount = 1u;
		yield return new LoadMessage("LoadReadFile");
		byte[] fileData = (resource ? Resources.Load<TextAsset>(filename).bytes : null);
		byte[] dat = (resource ? Utilities.ReadData(fileData, "Data") : Utilities.ReadData(filename, "Data"));
		yield return new LoadMessage("LoadDecompressFile");
		TimeProbe.BeginTime("Decompress time:");
		dat = Decompress(dat);
		TimeProbe.FinalizeTime("Decompress time:");
		Versioning.Version version = Versioning.DisectVersionString(game.GameVersion);
		yield return new LoadMessage("LoadConstructData");
		TimeProbe.BeginTime("Deserialization time:");
		WriteDictionary[] result = DeserializeDictionaries(dat, GetFloatConVersion(version));
		TimeProbe.FinalizeTime("Deserialization time:");
		yield return new LoadMessage("LoadReadRooms");
		RoomDescriptor roomData = null;
		if (version < NewRoomSer)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Binder = new OlderDotNetVersionMigrationBinder();
			using (MemoryStream serializationStream = new MemoryStream(resource ? Utilities.ReadData(fileData, "Rooms") : Utilities.ReadData(filename, "Rooms")))
			{
				roomData = (RoomDescriptor)binaryFormatter.Deserialize(serializationStream);
			}
		}
		else
		{
			roomData = DeserializeRooms(resource ? Utilities.ReadData(fileData, "Rooms") : Utilities.ReadData(filename, "Rooms"));
		}
		IEnumerator<LoadMessage> l = LoadGame(result, roomData, mode, version, networkMode);
		while (l.MoveNext())
		{
			yield return l.Current;
		}
	}

	public static WriteDictionary[] DeserializeDictionaries(byte[] dat, int convertFloats = -1)
	{
		SaveLock.EnterWriteLock();
		try
		{
			return (WriteDictionary[])Serializer.Deserialize(dat, convertFloats);
		}
		finally
		{
			SaveLock.ExitWriteLock();
		}
	}

	public static RoomDescriptor DeserializeRooms(byte[] dat)
	{
		SaveLock.EnterWriteLock();
		try
		{
			return (RoomDescriptor)Serializer.Deserialize(dat);
		}
		finally
		{
			SaveLock.ExitWriteLock();
		}
	}

	public static IEnumerator<LoadMessage> LoadGame(WriteDictionary[] data, RoomDescriptor roomData, NewLoadMode mode, Versioning.Version v, Writeable.LoadType networkMode)
	{
		if (mode.Is(NewLoadMode.FullOrCompany))
		{
			Employee.ResetFriendships();
			_friendshipsLoaded = false;
		}
		Writeable.IDCount = 1u;
		Dictionary<string, int> counts = new Dictionary<string, int>();
		for (int i = 0; i < data.Length; i++)
		{
			if (_dictToDesc.ContainsKey(data[i].Name))
			{
				counts.AddUp(data[i].Name);
			}
		}
		Writeable.DeserializedObjects.Clear();
		if (mode.Is(NewLoadMode.FullOrCompany) && !GameData.RestartCompany)
		{
			GameSettings.Instance.sActorManager.Teams.Clear();
			Actor[] array = UnityEngine.Object.FindObjectsOfType<Actor>();
			for (int j = 0; j < array.Length; j++)
			{
				array[j].DestroyGO();
			}
		}
		GameSettings.Instance.sRoomManager.DisableMeshRebuild = true;
		GameSettings.Instance.FurnitureErrorOccured = false;
		if (roomData != null)
		{
			yield return new LoadMessage("LoadInstantiateRoom");
			TimeProbe.BeginTime("Rebuild room time:");
			roomData.BuildRooms(delegate
			{
				GameObject obj = UnityEngine.Object.Instantiate(BuildController.Instance.RoomPrefab);
				Room component = obj.GetComponent<Room>();
				component.enabled = false;
				SelectorController.ReEnable.Add(component);
				return obj;
			}, true);
			TimeProbe.FinalizeTime("Rebuild room time:");
		}
		TimeProbe.BeginTime("WriteDictionary element load time:");
		string first = null;
		string currentUI = null;
		float lastUpdate = Time.realtimeSinceStartup;
		int count = 0;
		int max = 0;
		_notLoadedFurniture.Clear();
		List<Writeable> elements = new List<Writeable>(data.Length);
		for (int i2 = 0; i2 < data.Length; i2++)
		{
			if (first != data[i2].Name)
			{
				first = data[i2].Name;
				currentUI = _dictToDesc.GetOrDefault(first);
				if (currentUI != null)
				{
					lastUpdate = Time.realtimeSinceStartup;
					count = 0;
					max = counts[data[i2].Name];
					yield return new LoadMessage(currentUI, max, 0f);
				}
			}
			if (currentUI != null && Time.realtimeSinceStartup - lastUpdate > 1f)
			{
				lastUpdate = Time.realtimeSinceStartup;
				yield return new LoadMessage(currentUI, counts[data[i2].Name], (float)count / (float)max);
			}
			Writeable writeable = LoadElement(data[i2], mode, v, networkMode);
			if (writeable != null)
			{
				elements.Add(writeable);
			}
			count++;
		}
		if (_notLoadedFurniture.Count > 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, uint> item in _notLoadedFurniture)
			{
				stringBuilder.AppendLine(item.Value + " x " + item.Key.BlueHighlight());
			}
			WindowManager.Instance.ShowMessageBox("FurnitureLoadError".LocColor(stringBuilder.ToString().TrimEnd()), true, DialogWindow.DialogType.Error);
			_notLoadedFurniture.Clear();
		}
		yield return new LoadMessage("LoadCleanAndBind");
		for (int num = 0; num < elements.Count; num++)
		{
			if (elements[num] != null)
			{
				elements[num].PostDeserialize();
			}
		}
		if (roomData != null)
		{
			for (int num2 = 0; num2 < GameSettings.Instance.sRoomManager.Rooms.Count; num2++)
			{
				GameSettings.Instance.sRoomManager.Rooms[num2].PostDeserialize();
			}
		}
		if (mode.Is(NewLoadMode.FullOrCompany))
		{
			GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>().ToList().ForEach(delegate(AutoDevWorkItem x)
			{
				x.Leader = Writeable.STGetDeserializedObject(x.LeaderID) as Actor;
			});
			if (!_friendshipsLoaded)
			{
				for (int num3 = 0; num3 < GameSettings.Instance.sActorManager.Actors.Count; num3++)
				{
					Actor actor = GameSettings.Instance.sActorManager.Actors[num3];
					foreach (KeyValuePair<Employee, float> friendship in actor.employee.Friendships)
					{
						if (actor.employee != friendship.Key)
						{
							Employee.SetFriendship(actor.employee, friendship.Key, friendship.Value);
						}
					}
					actor.employee.Friendships.Clear();
				}
			}
			GameSettings.Instance.sActorManager.Teams.Values.ForEachEnum(delegate(Team x)
			{
				x.CalculateCompatibility();
			});
		}
		if (v.Before(LeadDesignerProjectFix))
		{
			foreach (SoftwareProduct allProduct in GameSettings.Instance.simulation.GetAllProducts(true))
			{
				if (allProduct.LeadDesigner != null && allProduct.LeadDesigner.LeadProjects.Count > 0)
				{
					allProduct.LeadDesigner.LeadProjectsFix.AddRange(allProduct.LeadDesigner.LeadProjects.Select((SoftwareProduct x) => x.ID));
					allProduct.LeadDesigner.LeadProjects.Clear();
				}
			}
		}
		if (v.Before(Networking))
		{
			FixAllLeadSpec(GameSettings.Instance.sActorManager.Actors.Select((Actor x) => x.employee));
			FixAllLeadSpec(MarketSimulation.Active.Companies.Values.Select((SimulatedCompany x) => x.LeadDesigner));
			FixAllLeadSpec(from x in MarketSimulation.Active.GetAllProducts(true)
				select x.LeadDesigner);
			FixAllLeadSpec(MarketSimulation.Active.FreeLeads);
		}
		if (mode.Is(NewLoadMode.Company))
		{
			for (int num4 = 0; num4 < GameSettings.Instance.sActorManager.Actors.Count; num4++)
			{
				Actor actor2 = GameSettings.Instance.sActorManager.Actors[num4];
				if (!GameSettings.Instance.sActorManager.GetArriveTime(actor2).HasValue)
				{
					SDateTime sDateTime = SDateTime.Now();
					Team team = actor2.GetTeam();
					SDateTime time = ((team != null) ? new SDateTime(0, team.WorkStart - 1, sDateTime.Day, sDateTime.Month, sDateTime.Year) : sDateTime);
					time += new SDateTime(1, 0, 0);
					GameSettings.Instance.sActorManager.AddToAwaiting(actor2, time);
				}
			}
			HUD.Instance.companyWindow.Bind();
			HUD.Instance.TeamWindow.TeamList.Items = GameSettings.Instance.sActorManager.Teams.Values.Cast<object>().ToList();
			HUD.Instance.loanWindow.UpdateLoans();
		}
		TimeProbe.FinalizeTime("WriteDictionary element load time:");
		TimeProbe.FinalizeTime("Room segment load time:");
		TimeProbe.FinalizeTime("Furniture load time:");
		TimeProbe.FinalizeTime("Road manager load time:");
		TimeProbe.FinalizeTime("Actor load time:");
		TimeProbe.FinalizeTime("GameSettings load time:");
		TimeProbe.FinalizeTime("Teams load time:");
		TimeProbe.FinalizeTime("Cars load time:");
		GameSettings.Instance.sRoomManager.DisableMeshRebuild = false;
		if (mode.Is(NewLoadMode.FullOrBuilding))
		{
			yield return new LoadMessage("LoadCreateRoomMesh");
			TimeProbe.BeginTime("Room mesh rebuild time:");
			for (int num5 = -1; num5 <= GameSettings.MaxFloor; num5++)
			{
				GameSettings.Instance.sRoomManager.UpdateFloorMeshes(num5);
			}
			TimeProbe.FinalizeTime("Room mesh rebuild time:");
			GameSettings.Instance.sRoomManager.RoomNearnessDirty = true;
			GameSettings.Instance.LoadPortalData();
		}
	}

	private static void FixAllLeadSpec(IEnumerable<Employee> es)
	{
		foreach (Employee e in es)
		{
			if (e == null || e.LeadSpecialization == null)
			{
				continue;
			}
			if (e.LeadSpecialization.Count > 0)
			{
				e.LeadSpecializationFix = e.LeadSpecialization.ToDictionaryMerge((KeyValuePair<SoftwareType, float> x) => x.Key.Name, (KeyValuePair<SoftwareType, float> x) => x.Value, (float x, float y) => x + y);
			}
			e.LeadSpecialization = null;
		}
	}

	private static Writeable LoadElement(WriteDictionary dictionary, NewLoadMode mode, Versioning.Version version, Writeable.LoadType networkMode)
	{
		if (dictionary.Name.StartsWith("DLCDATA"))
		{
			string key = dictionary.Name.Substring(7);
			DLCObject value;
			if (GameData.InstalledDLC.TryGetValue(key, out value))
			{
				value.Deserialize(dictionary);
			}
		}
		switch (dictionary.Name)
		{
		case "RoomSegment":
		{
			TimeProbe.BeginTime("Room segment load time:");
			string text4 = dictionary["Type"].ToString();
			bool flag2 = false;
			RoomSegment segmentComponent = ObjectDatabase.Instance.GetSegmentComponent(text4);
			if (segmentComponent == null)
			{
				flag2 = true;
				string text5 = dictionary.Get<string>("Fallback", null);
				if (text5 != null)
				{
					segmentComponent = ObjectDatabase.Instance.GetSegmentComponent(text5);
				}
			}
			RoomSegment roomSegment = null;
			if (segmentComponent != null)
			{
				roomSegment = UnityEngine.Object.Instantiate(segmentComponent);
				roomSegment.name = segmentComponent.name;
				if (roomSegment.DeserializeThis(dictionary, true, networkMode) == null)
				{
					return null;
				}
				roomSegment.gameObject.SetActive(true);
			}
			if (flag2)
			{
				GameSettings.Instance.FurnitureErrorOccured = true;
				UnityEngine.Debug.Log("Missing segment " + text4);
				_notLoadedFurniture.AddUp(text4, 1u);
			}
			TimeProbe.EndTime("Room segment load time:");
			if (!roomSegment.IsAliveNotNull())
			{
				return null;
			}
			return roomSegment;
		}
		case "Furniture":
		{
			string text2 = dictionary["Type"].ToString();
			if (_furnitureReplacement.Count > 0)
			{
				text2 = _furnitureReplacement.GetOrDefault(text2, text2);
			}
			if (version < AddTrash && text2.Equals("Clock"))
			{
				dictionary["ColT"] = SVector3.One;
			}
			float value2;
			if (version < TempRemoveV && IgnoreTempFurn.TryGetValue(text2, out value2) && !dictionary.Get("PlacedInEditMode", false))
			{
				SelectorController.Instance.MoveAddBack += value2;
				SelectorController.Instance.RemovedTempFurns = true;
				return null;
			}
			if (version < PrintRemoveV && IgnorePrintFurn.TryGetValue(text2, out value2))
			{
				SelectorController.Instance.MoveAddBack += value2;
				SelectorController.Instance.RemovedPrintFurns = true;
				return null;
			}
			if (version < RemovePalletPoint && IgnorePalletFurn.TryGetValue(text2, out value2))
			{
				SelectorController.Instance.MoveAddBack += value2;
				return null;
			}
			if (version < ShelfFix && text2.Equals("Shelf"))
			{
				text2 = "Shelf 1";
			}
			bool flag = false;
			if (text2.Equals("Company Logo High"))
			{
				flag = true;
				text2 = "Company Logo";
			}
			Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(text2);
			if (furnitureComponent == null)
			{
				string text3 = dictionary.Get<string>("Fallback", null);
				if (text3 != null)
				{
					text2 = text3;
					furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(text2);
				}
			}
			if (furnitureComponent != null)
			{
				if (GameData.LoadYear > 1900 && !GameData.EditMode && furnitureComponent.UnlockYear > GameData.LoadYear)
				{
					GameSettings.Instance.FurnitureErrorOccured = true;
					if (!dictionary.Get("PlacedInEditMode", false))
					{
						SelectorController.Instance.MoveAddBack += furnitureComponent.GetTimelessCost();
					}
					return null;
				}
				TimeProbe.BeginTime("Furniture load time:", furnitureComponent.Type);
				if (version.Before(AnimFix))
				{
					dictionary.Remove("AnimAnim");
				}
				if (version.Before(CompanyLogoFix) && (text2.Equals("Company Logo") || text2.Equals("Company Logo Big")))
				{
					dictionary["IsReversed"] = true;
					if (!text2.Equals("Company Logo Big"))
					{
						dictionary["WallHeight"] = (flag ? 1.5f : 1f);
					}
				}
				Furniture furniture = UnityEngine.Object.Instantiate(furnitureComponent);
				furniture.name = furnitureComponent.name;
				furniture.Init();
				if (furniture.DeserializeThis(dictionary, true, networkMode) == null)
				{
					return null;
				}
				if (!furniture.isTemporary)
				{
					furniture.gameObject.SetActive(true);
				}
				if (furniture.enabled)
				{
					furniture.enabled = false;
					SelectorController.ReEnable.Add(furniture);
				}
				if (furniture.HasUpg && furniture.upg.enabled)
				{
					furniture.upg.enabled = false;
					SelectorController.ReEnable.Add(furniture.upg);
				}
				if (!furniture.Signage.IsReferenceNull())
				{
					furniture.Signage.enabled = false;
					SelectorController.ReEnable.Add(furniture.Signage);
				}
				TimeProbe.EndTime("Furniture load time:");
				if (!furniture.LoadError)
				{
					return furniture;
				}
				return null;
			}
			GameSettings.Instance.FurnitureErrorOccured = true;
			UnityEngine.Debug.Log("Missing furniture " + text2);
			_notLoadedFurniture.AddUp(text2, 1u);
			TimeProbe.EndTime("Furniture load time:");
			return null;
		}
		case "GameSettings":
			TimeProbe.BeginTime("GameSettings load time:");
			Writeable.DeserializeSaveFields(GameSettings.Instance, dictionary, true, networkMode);
			GameSettings.Instance.Deserialize(dictionary, networkMode);
			if (version.Before(ToolOverhaul) && GameSettings.Instance.simulation != null)
			{
				foreach (SoftwareProduct allProduct in GameSettings.Instance.simulation.GetAllProducts(false))
				{
					allProduct.InitTools();
					allProduct.InitOS();
				}
			}
			if (version.Before(ReviewSystem) && GameSettings.Instance.simulation != null)
			{
				SDateTime sDateTime = default(SDateTime);
				foreach (SoftwareProduct allProduct2 in GameSettings.Instance.simulation.GetAllProducts(true))
				{
					ValueTuple<int, int> valueTuple = GameSettings.Instance.simulation.GenerateReviews(allProduct2.ID, sDateTime, allProduct2.GetReviewTargetScore(sDateTime, false), allProduct2.UnitSum);
					allProduct2.PositiveReviews = (uint)valueTuple.Item1;
					allProduct2.NegativeReviews = (uint)valueTuple.Item2;
					foreach (List<AddOnProduct> value3 in allProduct2.Addons.Values)
					{
						foreach (AddOnProduct item in value3)
						{
							ValueTuple<int, int> valueTuple2 = GameSettings.Instance.simulation.GenerateReviews(item.ID, sDateTime, item.GetReviewTargetScore(sDateTime, false), item.Sales);
							item.PositiveReviews = (uint)valueTuple2.Item1;
							item.NegativeReviews = (uint)valueTuple2.Item2;
						}
					}
				}
			}
			TimeProbe.EndTime("GameSettings load time:");
			break;
		case "Actor":
		{
			TimeProbe.BeginTime("Actor load time:");
			Actor actor2 = GameSettings.Instance.SpawnActor(dictionary.Get("Female", true), false, false);
			actor2.DeserializeThis(dictionary, true, networkMode);
			if (actor2.enabled)
			{
				actor2.enabled = false;
				SelectorController.ReEnable.Add(actor2);
			}
			TimeProbe.EndTime("Actor load time:");
			return actor2;
		}
		case "Awaiting":
			foreach (KeyValuePair<uint, SDateTime> item2 in dictionary.Get("Awaiting", new Dictionary<uint, SDateTime>()))
			{
				Actor actor = Writeable.STGetDeserializedObject(item2.Key) as Actor;
				if (actor != null)
				{
					GameSettings.Instance.sActorManager.AddToAwaiting(actor, item2.Value);
				}
			}
			break;
		case "WaitingForBus":
			GameSettings.Instance.sActorManager.ReadyForBus = (from x in dictionary.Get("Actors", new List<uint>())
				select (Actor)Writeable.STGetDeserializedObject(x)).ToHashSet();
			break;
		case "ReadyForHome":
			GameSettings.Instance.sActorManager.ReadyForHome = (from x in dictionary.Get("Actors", new List<uint>())
				select (Actor)Writeable.STGetDeserializedObject(x)).ToHashSet();
			break;
		case "Team":
		{
			string text = (string)dictionary["Name"];
			if (GameSettings.Instance.sActorManager.Teams.ContainsKey(text))
			{
				UnityEngine.Debug.LogError("Tried to add 2 teams with the same name during load: " + text);
				break;
			}
			TimeProbe.BeginTime("Teams load time:");
			Team team = new Team("temp");
			GameSettings.Instance.sActorManager.Teams.Add(text, team);
			team.Deserialize(dictionary);
			TimeProbe.EndTime("Teams load time:");
			break;
		}
		case "Camera":
			CameraScript.Instance.Deserialize(dictionary);
			break;
		case "Car":
		{
			if (networkMode == Writeable.LoadType.NetworkClient)
			{
				SelectorController instance = SelectorController.Instance;
				if ((object)instance != null)
				{
					instance.DelayedCars.Add(dictionary);
				}
				return null;
			}
			TimeProbe.BeginTime("Cars load time:");
			int idx = dictionary.Get("CarIdx", 1);
			CarScript result = RoadManager.Instance.CreateCar(idx, false).DeserializeThis(dictionary, true, networkMode) as CarScript;
			TimeProbe.EndTime("Cars load time:");
			return result;
		}
		case "Roof":
			return UnityEngine.Object.Instantiate(HUD.Instance.roofEditWindow.RoofPrefab).DeserializeThis(dictionary, true, networkMode) as Roof;
		case "RoadManager":
			TimeProbe.BeginTime("Road manager load time:");
			if (GameData.MultiplayerMode && version < NetworkPathFix)
			{
				dictionary.Remove("PathPoints");
			}
			RoadManager.Instance.DeserializeThis(dictionary, true, networkMode);
			TimeProbe.EndTime("Road manager load time:");
			break;
		case "ModData":
		{
			GameSettings.Instance.ModData = dictionary;
			LoadMode mode2 = BackConvert(mode);
			for (int i = 0; i < ModController.Instance.Mods.Count; i++)
			{
				ModController.Instance.Mods[i].Deserialize(dictionary, mode2);
			}
			break;
		}
		case "Friendships":
			Employee.SetAllFriendships(dictionary.Get<Dictionary<Employee.FriendKey, float>>("Friendships"));
			_friendshipsLoaded = true;
			break;
		case "Confiscator":
		{
			Confiscator confiscator = UnityEngine.Object.Instantiate(GameSettings.Instance.ConfiscatorPrefab);
			confiscator.DeserializeThis(dictionary, true, networkMode);
			return confiscator;
		}
		case "NetworkPlayerMap":
			if (networkMode != Writeable.LoadType.NetworkClient)
			{
				PlayerMap playerMap = new PlayerMap();
				playerMap.Deserialize(dictionary);
				GameSettings.Instance.sRoomManager.PlayerMaps[playerMap.Player] = playerMap;
			}
			break;
		}
		return null;
	}

	private static void AddAreas(Dictionary<int, Room[]> rooms, List<float> result)
	{
		int num = -1;
		int num2 = 0;
		while (num2 < rooms.Count)
		{
			Room[] orNull = rooms.GetOrNull(num);
			if (orNull != null)
			{
				result.Add(orNull.SumSafe((Room x) => x.Area));
				num2++;
			}
			else
			{
				result.Add(0f);
			}
			num++;
		}
		result.Add(-1f);
	}

	private static float[] GetRentMeta()
	{
		Dictionary<int, Room[]> rooms = (from x in GameSettings.Instance.sRoomManager.GetRooms()
			where x.PlayerOwned && !x.Pillar && !x.Outdoors
			group x by x.Floor).ToDictionary((IGrouping<int, Room> x) => x.Key, (IGrouping<int, Room> x) => x.ToArray());
		List<float> list = new List<float>
		{
			2f,
			(from x in GameSettings.Instance.sRoomManager.GetRooms()
				where x.PlayerOwned && !x.Pillar
				select x).SumSafe((Room x) => x.Area)
		};
		AddAreas(rooms, list);
		AddAreas((from x in GameSettings.Instance.sRoomManager.GetRooms()
			where x.PlayerOwned && !x.Pillar && x.Outdoors
			group x by x.Floor).ToDictionary((IGrouping<int, Room> x) => x.Key, (IGrouping<int, Room> x) => x.ToArray()), list);
		list.Add((from x in GameSettings.Instance.sRoomManager.GetRooms()
			where x.Rentable
			select x).SumSafe((Room x) => x.Area));
		return list.ToArray();
	}

	public static float[] GetBuildingMeta()
	{
		if (GameSettings.Instance.RentMode)
		{
			return GetRentMeta();
		}
		List<Room> rooms = GameSettings.Instance.sRoomManager.GetRooms();
		return new float[4]
		{
			1f,
			rooms.SumSafe((Room x) => x.Area),
			GameSettings.Instance.GetMapCost(false),
			GameSettings.Instance.PlayerPlots.SumSafe((PlotArea x) => x.Area)
		};
	}

	public static void SaveGame(SaveGame saveGame, NewLoadMode mode, bool autoSave, bool failMsg, string fileName = null)
	{
		if (fileName == null)
		{
			fileName = saveGame.FileName;
		}
		if (!saveGame.BuildingOnly && File.Exists(fileName) && Options.Backup)
		{
			try
			{
				File.Copy(fileName, fileName + ".bak", true);
			}
			catch (Exception)
			{
			}
		}
		Dictionary<string, byte[]> finalResult = new Dictionary<string, byte[]>();
		ConfigFile configFile = new ConfigFile();
		configFile.Add("CompanyName", saveGame.CompanyName);
		configFile.Add("InGameTime", saveGame.InGameTime.ToInt().ToString());
		configFile.Add("RealTime", saveGame.RealTime.ToString("O"));
		configFile.Add("Money", saveGame.Money.ToString());
		configFile.Add("Products", saveGame.Products.ToString());
		configFile.Add("Employees", saveGame.Employees.ToString());
		configFile.Add("GameVersion", Versioning.VersionString);
		configFile.Add("DaysPerMonth", GameSettings.DaysPerMonth.ToString());
		configFile.Add("BuildingOnly", mode.Is(NewLoadMode.Building).ToString());
		if (saveGame.NetworkData != null)
		{
			configFile.Add("NetworkData", saveGame.NetworkData.Serialize());
		}
		if (saveGame.Logo != null)
		{
			configFile.Add("CompanyLogo", SDFCreator.GetTreeString(saveGame.Logo));
		}
		finalResult.Add("Meta", Utilities.GetBytesFromString(configFile.Serialize()));
		finalResult.Add("BuildingMeta", Utilities.GetBytesFromFloats(GetBuildingMeta()));
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		using (MemoryStream memoryStream = new MemoryStream())
		{
			MiniMapMaker.MapDescriptor mapDescriptor = MinimapThumbnailMaker.Instance.MinimapMaker.MapDescFromGame(GameSettings.Instance.RentMode ? GameSettings.Instance.BuildingRect() : GameSettings.Instance.PlotRect());
			saveGame.Map = mapDescriptor;
			binaryFormatter.Serialize(memoryStream, mapDescriptor);
			finalResult.Add("Map", memoryStream.ToArray());
		}
		float t = 0f;
		float conTime = 0f;
		byte[] dat = null;
		byte[] value = null;
		ForceWrite = false;
		for (int i = 0; i < 3; i++)
		{
			SerializedDIDs.Clear();
			DIDClash = null;
			value = CreateRoomData(mode);
			dat = CreateDictionaryData(mode, out t, out conTime, autoSave ? fileName : null, Writeable.LoadType.Default, 0);
			if (DIDClash == null)
			{
				break;
			}
			ForceWrite = i >= 1;
			UnityEngine.Debug.Log("Found clashing DIDs while saving " + (i + 1) + ". time: " + DIDClash);
		}
		finalResult.Add("Rooms", value);
		float serTime = t;
		t = Time.realtimeSinceStartup;
		ThreadPool.QueueUserWorkItem(delegate
		{
			lock (WriteLock)
			{
				try
				{
					Stopwatch stopwatch = new Stopwatch();
					stopwatch.Start();
					float num = dat.Length;
					dat = Compress(dat);
					finalResult.Add("Data", dat);
					float t2 = (float)stopwatch.ElapsedMilliseconds / 1000f;
					stopwatch.Restart();
					lock (saveGame)
					{
						Utilities.WriteMultipleFiles(fileName, finalResult);
					}
					saveGame.UpdateFileSize();
					float t3 = (float)stopwatch.ElapsedMilliseconds / 1000f;
					UnityEngine.Debug.Log(string.Format("Save construction time: {4} - Serialization time: {3} - Compress time: {0} - Effect: {1:F1}% - File write time: {5} - App time: {2} - Depth: {7} ({6})", t2.SecondsToTime(), (float)dat.Length / num * 100f, t.SecondsToTime(), serTime.SecondsToTime(), conTime.SecondsToTime(), t3.SecondsToTime(), Path.GetFileName(fileName), AltSerializer.DepthCounter));
				}
				catch (Exception ex2)
				{
					if (failMsg)
					{
						ErrorLogging.AddSaveError(ex2);
					}
				}
			}
		});
	}

	public static byte[] CreateRoomData(NewLoadMode mode)
	{
		SaveLock.EnterWriteLock();
		try
		{
			return Serializer.Serialize(RoomDescriptor.SaveRooms(mode.Is(NewLoadMode.FullOrBuilding) ? GameSettings.Instance.sRoomManager.GetRooms() : new List<Room>(), mode));
		}
		finally
		{
			SaveLock.ExitWriteLock();
		}
	}

	public static byte[] CreateDictionaryData(NewLoadMode mode, Writeable.LoadType networkMode, byte networkTarget = 0)
	{
		byte[] result = null;
		for (int i = 0; i < 3; i++)
		{
			SerializedDIDs.Clear();
			DIDClash = null;
			ForceWrite = i == 2;
			float t;
			float t2;
			result = CreateDictionaryData(mode, out t, out t2, null, networkMode, networkTarget);
			if (DIDClash == null)
			{
				break;
			}
			UnityEngine.Debug.Log("Found clashing DIDs creating company data for " + (i + 1) + ". time: " + DIDClash);
		}
		return result;
	}

	public static byte[] CreateDictionaryData(NewLoadMode mode, out float t, out float t2, string autosaveName, Writeable.LoadType networkMode, byte networkTarget = 0)
	{
		SaveLock.EnterWriteLock();
		try
		{
			t2 = Time.realtimeSinceStartup;
			GameSettings.Instance.BoxController.FixedUpdate();
			List<WriteDictionary> result = new List<WriteDictionary>();
			if (mode.Is(NewLoadMode.FullOrBuilding))
			{
				if (networkMode == Writeable.LoadType.NetworkHost)
				{
					foreach (Furniture item in from x in GameSettings.Instance.sRoomManager.AllFurniture
						where x != null && x.PartOfGen
						orderby x.GetSnappingDepth()
						select x)
					{
						result.Add(item.SerializeThis(mode, networkMode, true));
					}
				}
				else
				{
					RoomSegment[] allSegments = GameSettings.Instance.sRoomManager.GetAllSegments();
					foreach (RoomSegment roomSegment in allSegments)
					{
						if (roomSegment.IsAliveNotNull() && roomSegment.GetComponent<Furniture>() == null && !roomSegment.name.Contains("Wall"))
						{
							result.Add(roomSegment.SerializeThis(mode, networkMode, true));
						}
					}
					foreach (Furniture item2 in from x in GameSettings.Instance.sRoomManager.AllFurniture
						where x != null
						orderby x.GetSnappingDepth()
						select x)
					{
						if (!mode.Is(NewLoadMode.Building) || item2.ValidInBlueprints)
						{
							result.Add(item2.SerializeThis(mode, networkMode, true));
						}
					}
					for (int num2 = 0; num2 < GameSettings.Instance.sRoomManager.Roofs.Count; num2++)
					{
						result.Add(GameSettings.Instance.sRoomManager.Roofs[num2].SerializeThis(mode, networkMode, true));
					}
				}
			}
			foreach (KeyValuePair<byte, PlayerMap> playerMap in GameSettings.Instance.sRoomManager.PlayerMaps)
			{
				if (playerMap.Key != networkTarget)
				{
					result.Add(playerMap.Value.Serialize());
				}
			}
			if (networkMode == Writeable.LoadType.NetworkHost)
			{
				result.Add(PlayerMap.CreateLocalData());
			}
			WriteDictionary writeDictionary = GameSettings.Instance.Serialize(mode, networkMode);
			if (autosaveName != null)
			{
				writeDictionary["Autosave"] = autosaveName;
			}
			Writeable.SerializeSaveFields(GameSettings.Instance, writeDictionary, mode, networkMode);
			result.Add(writeDictionary);
			if (networkMode == Writeable.LoadType.Default && mode.Is(NewLoadMode.FullOrCompany))
			{
				for (int num3 = 0; num3 < GameSettings.Instance.sActorManager.Actors.Count; num3++)
				{
					Actor actor = GameSettings.Instance.sActorManager.Actors[num3];
					if (actor.IsAliveNotNull())
					{
						result.Add(actor.SerializeThis(mode, networkMode, true));
					}
				}
				if (mode.Is(NewLoadMode.Full))
				{
					for (int num4 = 0; num4 < GameSettings.Instance.sActorManager.Staff.Count; num4++)
					{
						Actor actor2 = GameSettings.Instance.sActorManager.Staff[num4];
						if (actor2.IsAliveNotNull())
						{
							result.Add(actor2.SerializeThis(mode, networkMode, true));
						}
					}
					GameSettings.Instance.sActorManager.Others.Values.ForEachEnum(delegate(HashSet<Actor> z)
					{
						z.Where((Actor x) => x.IsAliveNotNull()).ForEachEnum(delegate(Actor x)
						{
							result.Add(x.SerializeThis(mode, networkMode, true));
						});
					});
					WriteDictionary writeDictionary2 = new WriteDictionary("Awaiting");
					writeDictionary2["Awaiting"] = (from x in GameSettings.Instance.sActorManager.GetAwaitingDict()
						where x.Key.IsAliveNotNull()
						select x).ToDictionaryOverwrite((KeyValuePair<Actor, SDateTime> x) => x.Key.DID, (KeyValuePair<Actor, SDateTime> x) => x.Value);
					result.Add(writeDictionary2);
					WriteDictionary writeDictionary3 = new WriteDictionary("WaitingForBus");
					writeDictionary3["Actors"] = (from x in GameSettings.Instance.sActorManager.ReadyForBus
						where x.IsAliveNotNull()
						select x.DID).ToList();
					result.Add(writeDictionary3);
					WriteDictionary writeDictionary4 = new WriteDictionary("ReadyForHome");
					writeDictionary4["Actors"] = (from x in GameSettings.Instance.sActorManager.ReadyForHome
						where x.IsAliveNotNull()
						select x.DID).ToList();
					result.Add(writeDictionary4);
				}
				else
				{
					HashSet<Actor> hashSet = GameSettings.Instance.sActorManager.Actors.ToHashSet();
					WriteDictionary writeDictionary5 = new WriteDictionary("Awaiting");
					Dictionary<uint, SDateTime> dictionary = new Dictionary<uint, SDateTime>();
					foreach (KeyValuePair<Actor, SDateTime> item3 in GameSettings.Instance.sActorManager.GetAwaitingDict())
					{
						if (item3.Key.IsAliveNotNull() && hashSet.Contains(item3.Key))
						{
							dictionary[item3.Key.DID] = item3.Value;
						}
					}
					writeDictionary5["Awaiting"] = dictionary;
					result.Add(writeDictionary5);
				}
				result.AddRange(GameSettings.Instance.sActorManager.Teams.Select((KeyValuePair<string, Team> x) => x.Value.Serialize()));
				WriteDictionary writeDictionary6 = new WriteDictionary("Friendships");
				writeDictionary6["Friendships"] = Employee.GetAllFriendships();
				result.Add(writeDictionary6);
			}
			if (mode.Is(NewLoadMode.FullOrBuilding))
			{
				if (networkMode == Writeable.LoadType.Default)
				{
					result.Add(CameraScript.Instance.Serialize());
				}
				result.Add(RoadManager.Instance.SerializeThis(mode, networkMode, true));
			}
			if (networkMode == Writeable.LoadType.Default && mode.Is(NewLoadMode.Full))
			{
				for (int num5 = 0; num5 < RoadManager.Instance.Cars.Count; num5++)
				{
					if (!RoadManager.Instance.Cars[num5].Ghost)
					{
						result.Add(RoadManager.Instance.Cars[num5].SerializeThis(mode, networkMode, true));
					}
				}
				result.AddRange(GameSettings.Instance.Confiscators.Select((Confiscator x) => x.SerializeThis(mode, networkMode, false)));
			}
			if (networkMode == Writeable.LoadType.Default)
			{
				if (ModController.Instance.Mods.Count > 0 || GameSettings.Instance.ModData != null)
				{
					WriteDictionary writeDictionary7 = GameSettings.Instance.ModData ?? new WriteDictionary("ModData");
					LoadMode mode2 = BackConvert(mode);
					for (int num6 = 0; num6 < ModController.Instance.Mods.Count; num6++)
					{
						ModController.Instance.Mods[num6].Serialize(writeDictionary7, mode2);
					}
					result.Add(writeDictionary7);
				}
				foreach (DLCObject value in GameData.InstalledDLC.Values)
				{
					WriteDictionary writeDictionary8 = value.Serialize(mode);
					if (writeDictionary8 != null)
					{
						result.Add(writeDictionary8);
					}
				}
			}
			t2 = Time.realtimeSinceStartup - t2;
			t = Time.realtimeSinceStartup;
			byte[] result2 = Serializer.Serialize(result.ToArray(), networkMode == Writeable.LoadType.NetworkHost);
			t = Time.realtimeSinceStartup - t;
			return result2;
		}
		finally
		{
			SaveLock.ExitWriteLock();
		}
	}
}
