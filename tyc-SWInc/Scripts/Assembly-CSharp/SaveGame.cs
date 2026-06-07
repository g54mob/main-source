using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGame : IWorkshopItem, IComparable<SaveGame>
{
	public enum BuildingMetaIndex
	{
		RentMode = 0,
		Area = 1,
		Cost = 2
	}

	public readonly string FileName;

	public bool Legacy;

	public bool Broken;

	public string CompanyName;

	public SDateTime InGameTime;

	public DateTime RealTime;

	public double Money;

	public int Products;

	public int Employees;

	public int DaysPerMonth;

	public MiniMapMaker.MapDescriptor Map;

	public string GameVersion;

	public float FileSize;

	public bool BuildingOnly;

	private float[] BuildingMeta;

	public bool Resource;

	public byte[] Logo;

	public NetworkMeta NetworkData;

	public bool Readonly;

	public string UniqueName
	{
		get
		{
			if (!BuildingOnly)
			{
				return ActualName;
			}
			return "Build" + ActualName;
		}
	}

	public string ActualName
	{
		get
		{
			if (base.MetaData != null && !Resource)
			{
				return base.ItemTitle;
			}
			return Path.GetFileNameWithoutExtension(FileName);
		}
	}

	public override bool CheckCanUpload()
	{
		return !Readonly;
	}

	public override string GetWorkshopType()
	{
		return "Building";
	}

	public override string[] GetValidExts()
	{
		return new string[4] { "png", "build", "txt", "tyd" };
	}

	public override string[] ExtraTags()
	{
		return new string[0];
	}

	public float GetComparisonData()
	{
		float[] buildMeta = GetBuildMeta();
		if (buildMeta != null)
		{
			if (buildMeta[0] == 0f)
			{
				return buildMeta[1];
			}
			if (buildMeta[0] == 2f)
			{
				return buildMeta[1];
			}
			return buildMeta[2];
		}
		return 0f;
	}

	public bool IsRentMap()
	{
		float[] buildMeta = GetBuildMeta();
		if (buildMeta != null)
		{
			if (buildMeta[0] != 0f)
			{
				return buildMeta[0] == 2f;
			}
			return true;
		}
		return false;
	}

	public float[] GetBuildMeta()
	{
		if (!BuildingOnly)
		{
			return null;
		}
		if (BuildingMeta == null)
		{
			try
			{
				byte[] bytes;
				lock (this)
				{
					bytes = (Resource ? Utilities.ReadData(Resources.Load<TextAsset>(FileName).bytes, "BuildingMeta") : Utilities.ReadData(FileName, "BuildingMeta"));
				}
				BuildingMeta = Utilities.GetFloatsFromBytes(bytes);
			}
			catch (Exception)
			{
			}
		}
		return BuildingMeta;
	}

	private SaveGame(string path, bool readOnly, string cName, byte[] cLogo, string version, SDateTime d1, DateTime d2, double money, int p, int e, int dpm, bool buildingOnly, float loadTime, NetworkMeta networkData)
	{
		FileName = path;
		CompanyName = cName;
		InGameTime = d1;
		RealTime = d2;
		Money = money;
		Products = p;
		Employees = e;
		GameVersion = version;
		DaysPerMonth = dpm;
		BuildingOnly = buildingOnly;
		NetworkData = networkData;
		Logo = cLogo;
		if (BuildingOnly)
		{
			InitMod(Path.GetDirectoryName(path), loadTime);
		}
		Readonly = readOnly;
		UpdateFileSize();
	}

	private SaveGame(string path, bool readOnly, string cName, byte[] cLogo, string version, SDateTime d1, DateTime d2, double money, int p, int e, int dpm, bool buildingOnly, MiniMapMaker.MapDescriptor map, bool broken, float loadTime, NetworkMeta networkData, bool resource)
	{
		FileName = path;
		CompanyName = cName;
		Logo = cLogo;
		InGameTime = d1;
		RealTime = d2;
		Money = money;
		Products = p;
		Employees = e;
		Map = map;
		Broken = broken;
		GameVersion = version;
		DaysPerMonth = dpm;
		BuildingOnly = buildingOnly;
		Resource = resource;
		NetworkData = networkData;
		if (BuildingOnly)
		{
			InitMod(Path.GetDirectoryName(path), loadTime);
		}
		Readonly = readOnly;
		UpdateFileSize();
	}

	public void UpdateFileSize()
	{
		try
		{
			if (File.Exists(FileName))
			{
				FileInfo fileInfo = new FileInfo(FileName);
				FileSize = (float)fileInfo.Length / 1024f / 1024f;
			}
		}
		catch (Exception)
		{
		}
	}

	public static SaveGame LoadGame(string filename, bool build, bool canWrite, bool resource = false)
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		canWrite = !resource;
		byte[] fileData = (resource ? Resources.Load<TextAsset>(filename).bytes : null);
		byte[] array = (resource ? Utilities.ReadData(fileData, "Meta") : Utilities.ReadData(filename, "Meta"));
		if (array == null)
		{
			Debug.Log("Meta data empty for save file: " + filename);
			return null;
		}
		ConfigFile configFile = ConfigFile.Load(Utilities.GetStringFromBytes(array).SplitByNewLines());
		string text = configFile.Get("NetworkData", null);
		NetworkMeta networkData = null;
		if (text != null)
		{
			using (MemoryStream st = new MemoryStream(SDFCreator.GetTreeFromString(text)))
			{
				networkData = NetworkMeta.ReadData(st);
			}
		}
		string cName = configFile.Get("CompanyName", "Error");
		string text2 = configFile.Get("CompanyLogo", null);
		byte[] cLogo = null;
		if (text2 != null)
		{
			try
			{
				cLogo = SDFCreator.GetTreeFromString(text2);
			}
			catch (Exception)
			{
			}
		}
		int dpm = configFile.Get("DaysPerMonth", "1").ConvertToIntDef(1);
		SDateTime d = SDateTime.FromInt(configFile.Get("InGameTime", new SDateTime(1, 0).ToInt().ToString()).ConvertToIntDef(0), dpm);
		DateTime result;
		if (!DateTime.TryParse(configFile.Get("RealTime", DateTime.Now.ToString()), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out result))
		{
			result = DateTime.Now;
		}
		double money = configFile.Get("Money", "0").ConvertToDoubleDef(0.0);
		int p = configFile.Get("Products", "0").ConvertToIntDef(0);
		int e = configFile.Get("Employees", "0").ConvertToIntDef(0);
		string version = configFile.Get("GameVersion", Versioning.VersionString);
		bool buildingOnly = configFile.Get("BuildingOnly", "false").ConvertToBoolDef(false);
		MiniMapMaker.MapDescriptor map = new MiniMapMaker.MapDescriptor(new SVector3(0f, 0f, 10f, 10f));
		bool broken = false;
		try
		{
			using (MemoryStream serializationStream = new MemoryStream(resource ? Utilities.ReadData(fileData, "Map") : Utilities.ReadData(filename, "Map")))
			{
				map = (MiniMapMaker.MapDescriptor)new BinaryFormatter().Deserialize(serializationStream);
			}
		}
		catch (Exception)
		{
			broken = true;
		}
		return new SaveGame(filename, !canWrite, cName, cLogo, version, d, result, money, p, e, dpm, buildingOnly, map, broken, Time.realtimeSinceStartup - realtimeSinceStartup, networkData, resource);
	}

	public bool SaveNow(bool successMsg, bool failMsg, bool firstAuto, GameReader.NewLoadMode mode)
	{
		SaveIcon.Show(ActualName);
		try
		{
			CompanyName = GameSettings.Instance.MyCompany.Name.Replace("[", "").Replace("]", "");
			InGameTime = SDateTime.Now();
			RealTime = DateTime.Now;
			Money = GameSettings.Instance.MyCompany.Money;
			Products = GameSettings.Instance.MyCompany.Products.Count;
			Employees = GameSettings.Instance.sActorManager.Actors.Count;
			GameVersion = Versioning.VersionString;
			BuildingOnly = mode.Is(GameReader.NewLoadMode.Building);
			DaysPerMonth = GameSettings.DaysPerMonth;
			BuildingMeta = null;
			NetworkData = ((GameSettings.Instance.NetworkData != null) ? new NetworkMeta(GameSettings.Instance.NetworkData) : null);
			Logo = null;
			if (BuildingOnly)
			{
				string text = FolderPath();
				if (text != null && !Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
			}
			else
			{
				Logo = GameSettings.Instance.MyCompany.Logo;
			}
			GameReader.SaveGame(this, mode, firstAuto, failMsg);
			if (BuildingOnly)
			{
				try
				{
					GameObject gameObject = MinimapThumbnailMaker.Instance.MinimapMaker.CreateMap(Map, false);
					Texture2D texture2D = MinimapThumbnailMaker.Instance.RenderObject(gameObject, MinimapThumbnailMaker.ThumbSize.Big);
					File.WriteAllBytes(Path.Combine(FolderPath(), "Thumbnail.png"), texture2D.EncodeToPNG());
					gameObject.GetComponentsInChildren<MeshFilter>().ForEachEnum(delegate(MeshFilter x)
					{
						UnityEngine.Object.Destroy(x.sharedMesh);
					});
					UnityEngine.Object.Destroy(gameObject);
					UnityEngine.Object.Destroy(texture2D);
				}
				catch (Exception)
				{
				}
			}
			GameSettings.Instance.LastSaveTime = DateTime.Now;
			if (successMsg)
			{
				WindowManager.Instance.ShowMessageBox("SaveGameSuccess".Loc(), false, DialogWindow.DialogType.Information);
			}
			Legacy = false;
			Broken = false;
			UpdateFileSize();
		}
		catch (Exception ex2)
		{
			Exception ex3 = ex2;
			Exception e = ex3;
			Debug.LogException(e);
			if (failMsg)
			{
				WindowManager.Instance.ShowMessageBox("SaveGameFail2".Loc(), false, DialogWindow.DialogType.Error, delegate
				{
					FeedbackWindow.Instance.Show(FeedbackWindow.ReportTypes.Exception, null, false, true, null);
					FeedbackWindow.Instance.Exception = e.ToString();
				});
			}
			SaveGameManager.ReorderList();
			return false;
		}
		SaveGameManager.ReorderList();
		return true;
	}

	public static SaveGame CreateSave(string name, GameReader.NewLoadMode mode, bool readOnly)
	{
		bool flag = mode.Is(GameReader.NewLoadMode.Building);
		name = Utilities.CleanFileName(name);
		return new SaveGame(flag ? Path.Combine(Path.Combine(SaveGameManager.BuildingFolder, name), name + ".build") : Path.Combine(SaveGameManager.SaveFolder, name + ".sav"), readOnly, GameSettings.Instance.MyCompany.Name, flag ? null : GameSettings.Instance.MyCompany.Logo, Versioning.VersionString, SDateTime.Now(), DateTime.Now, GameSettings.Instance.MyCompany.Money, GameSettings.Instance.MyCompany.Products.Count, GameSettings.Instance.sActorManager.Actors.Count, GameSettings.DaysPerMonth, flag, 0f, (GameSettings.Instance.NetworkData != null) ? new NetworkMeta(GameSettings.Instance.NetworkData) : null);
	}

	public static SaveGame SaveCurrentGame(string name, bool auto, GameReader.NewLoadMode mode)
	{
		SaveGame saveGame = CreateSave(name, mode, false);
		if (!saveGame.SaveNow(!auto, !auto, auto, mode))
		{
			return null;
		}
		return saveGame;
	}

	public bool IsOlder()
	{
		return Versioning.DisectVersionString(GameVersion).Before(Versioning.CurrentVersion, 1);
	}

	public int CompareTo(SaveGame y)
	{
		if (y == null)
		{
			return -1;
		}
		if (y == this)
		{
			return 0;
		}
		if (BuildingOnly != y.BuildingOnly)
		{
			if (BuildingOnly)
			{
				return -1;
			}
			return 1;
		}
		if (BuildingOnly)
		{
			bool flag = !IsRentMap();
			bool flag2 = !y.IsRentMap();
			if (flag == flag2)
			{
				return GetComparisonData().CompareTo(y.GetComparisonData());
			}
			return flag.CompareTo(flag2);
		}
		return y.RealTime.CompareTo(RealTime);
	}

	public override string ToString()
	{
		return ActualName;
	}

	public override string GetActualString()
	{
		return ActualName;
	}

	public override string GetExtraInfo()
	{
		float[] buildMeta = GetBuildMeta();
		if (buildMeta == null || buildMeta.Length < 4)
		{
			return "Error".Loc();
		}
		if (buildMeta[0] == 0f)
		{
			return string.Format("{0}\n{4}: {1}\n{5}: {3}\n{6}: {2}", "Forrent".Loc(), buildMeta[1].ToString("N0") + " m2", BuildController.GetRoomCost(0f, buildMeta[1], false, false, 0, false, true, false).Currency(), buildMeta[3].ToString("N0") + " m2", "Leasedarea".Loc(), "Buildingarea".Loc(), "Cost".Loc());
		}
		if (buildMeta[0] == 2f)
		{
			float rentArea;
			float rentPrice;
			float rentableArea;
			SaveFileItem.GetRentMeta(buildMeta, out rentArea, out rentPrice, out rentableArea);
			return string.Format("{0}\n{4}: {1}\n{5}: {3}\n{6}: {2}", "Forrent".Loc(), rentArea.ToString("N0") + " m2", rentPrice.Currency(), rentableArea.ToString("N0") + " m2", "Leasedarea".Loc(), "Buildingarea".Loc(), "Cost".Loc());
		}
		return string.Format("{0}\n{4}: {1}\n{5}: {3}\n{6}: {2}", "Forsale".Loc(), buildMeta[1].ToString("N0") + " m2", buildMeta[2].Currency(), buildMeta[3].ToString("N0") + " m2", "Buildingarea".Loc(), "Plotarea".Loc(), "Cost".Loc());
	}
}
