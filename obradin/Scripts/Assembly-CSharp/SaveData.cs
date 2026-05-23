using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

public class SaveData
{
	[XmlType("moment")]
	public class MomentData : MomentDataRo
	{
		public bool visited
		{
			get
			{
				return visitCount != 0;
			}
		}

		[XmlAttribute]
		public string id { get; set; }

		[XmlAttribute]
		public int visitCount { get; set; }

		[XmlAttribute]
		public bool unlocked { get; set; }

		[XmlAttribute]
		public bool revealedGhosts { get; set; }

		[XmlAttribute]
		public bool revealedPageInBook { get; set; }

		public string description
		{
			get
			{
				return string.Format("{0,-25} {1} {2} {3}", id, (!unlocked) ? " LOK " : " UNL ", (!revealedGhosts) ? "HID " : "REV ", visitCount);
			}
		}

		public MomentData()
		{
		}

		public MomentData(string id_)
			: this()
		{
			id = id_;
		}

		public void Reset()
		{
			visitCount = 0;
			unlocked = false;
			revealedGhosts = false;
			revealedPageInBook = false;
		}
	}

	public interface MomentDataRo
	{
		bool visited { get; }

		string id { get; }

		int visitCount { get; }

		bool unlocked { get; }

		bool revealedGhosts { get; }

		bool revealedPageInBook { get; }
	}

	[XmlType("disaster")]
	public class DisasterData : DisasterDataRo
	{
		[XmlAttribute]
		public string id { get; set; }

		[XmlAttribute]
		public bool revealedChartInBook { get; set; }

		[XmlAttribute]
		public bool revealedDisappearancesInBook { get; set; }

		public DisasterData()
		{
		}

		public DisasterData(string id_)
			: this()
		{
			id = id_;
		}
	}

	public interface DisasterDataRo
	{
		string id { get; }

		bool revealedChartInBook { get; }

		bool revealedDisappearancesInBook { get; }
	}

	[XmlType("face")]
	public class FaceData : FaceDataRo
	{
		[XmlAttribute]
		public string id { get; set; }

		[XmlAttribute]
		public string nameId { get; set; }

		[XmlAttribute]
		public string fateId { get; set; }

		[XmlAttribute]
		public bool markedCorrect { get; set; }

		[XmlAttribute]
		public int clueWarning { get; set; }

		public bool isTotallyUnknown
		{
			get
			{
				return (!nameId.HasValue() || nameId == "unknown") && (!fateId.HasValue() || fateId == "unknown");
			}
		}

		public FaceData()
		{
			nameId = "unknown";
			fateId = "unknown";
		}

		public FaceData(string id_)
			: this()
		{
			id = id_;
		}

		public void Reset()
		{
			nameId = "unknown";
			fateId = "unknown";
			markedCorrect = false;
			clueWarning = 0;
		}
	}

	public interface FaceDataRo
	{
		string id { get; }

		string nameId { get; }

		string fateId { get; }

		bool markedCorrect { get; }

		int clueWarning { get; }

		bool isTotallyUnknown { get; }
	}

	[XmlType("stat")]
	public class StatData
	{
		public string id;

		public int val;

		public string description
		{
			get
			{
				return string.Format("{0,-20} {1}", id, val);
			}
		}

		public StatData()
		{
		}

		public StatData(string id_)
		{
			id = id_;
		}
	}

	[XmlType("general")]
	public class GeneralData : GeneralDataRo
	{
		[XmlAttribute]
		public string gameVersion { get; set; }

		[XmlAttribute]
		public int era { get; set; }

		[XmlAttribute]
		public float playTime { get; set; }

		[XmlAttribute]
		public string lastVisitedMomentId { get; set; }

		[XmlAttribute]
		public float lastVisitedMomentExitPlayTime { get; set; }

		[XmlAttribute]
		public bool exploringPlayerSpotValid { get; set; }

		public Quaternion exploringPlayerSpotLook { get; set; }

		public Vector3 exploringPlayerSpotFootPos { get; set; }

		[XmlAttribute]
		public string momentPlayerSpotId { get; set; }

		public Quaternion momentPlayerSpotLook { get; set; }

		public Vector3 momentPlayerSpotFootPos { get; set; }

		[XmlAttribute]
		public string bookPageId { get; set; }

		[XmlAttribute]
		public bool bookVisitedLastPage { get; set; }

		[XmlAttribute]
		public string bookBookmarkedCrewId { get; set; }

		[XmlAttribute]
		public bool officePawReady { get; set; }

		[XmlAttribute]
		public bool officePackageReady { get; set; }

		[XmlAttribute]
		public bool officeHaveRevealedBook { get; set; }

		[XmlAttribute]
		public bool officeEndedOnce { get; set; }

		[XmlAttribute]
		public bool helpedZoom { get; set; }

		[XmlAttribute]
		public bool helpedZoomBook { get; set; }

		[XmlAttribute]
		public bool helpedWatchBook { get; set; }

		[XmlAttribute]
		public bool helpedStartHunt { get; set; }

		[XmlAttribute]
		public bool helpedBookUsage { get; set; }

		[XmlAttribute]
		public bool helpedBookFaceBlur { get; set; }

		[XmlAttribute]
		public bool helpedBookFaceClear { get; set; }

		[XmlAttribute]
		public bool helpedBookFatesCheck { get; set; }

		[XmlAttribute]
		public bool helpedBookDifficulty { get; set; }

		[XmlAttribute]
		public bool helpedBookBookmarks { get; set; }

		[XmlAttribute]
		public bool playerFemale { get; set; }

		public bool justFinishedMoment
		{
			get
			{
				return lastVisitedMomentId.HasValue() && playTime <= lastVisitedMomentExitPlayTime + 0.1f;
			}
		}

		public Manifest.Gender playerGender
		{
			get
			{
				return (!playerFemale) ? Manifest.Gender.Male : Manifest.Gender.Female;
			}
		}
	}

	public interface GeneralDataRo
	{
		string gameVersion { get; }

		int era { get; }

		float playTime { get; }

		string lastVisitedMomentId { get; }

		float lastVisitedMomentExitPlayTime { get; }

		bool exploringPlayerSpotValid { get; }

		Quaternion exploringPlayerSpotLook { get; }

		Vector3 exploringPlayerSpotFootPos { get; }

		string momentPlayerSpotId { get; }

		Quaternion momentPlayerSpotLook { get; }

		Vector3 momentPlayerSpotFootPos { get; }

		string bookPageId { get; }

		bool bookVisitedLastPage { get; }

		bool officePawReady { get; }

		bool officePackageReady { get; }

		bool officeHaveRevealedBook { get; }

		bool officeEndedOnce { get; }

		bool helpedZoom { get; }

		bool helpedZoomBook { get; }

		bool helpedWatchBook { get; }

		bool helpedStartHunt { get; }

		bool helpedBookUsage { get; }

		bool helpedBookFaceBlur { get; }

		bool helpedBookFaceClear { get; }

		bool helpedBookFatesCheck { get; }

		bool helpedBookDifficulty { get; }

		bool helpedBookBookmarks { get; }

		bool justFinishedMoment { get; }

		Manifest.Gender playerGender { get; }
	}

	[XmlRoot("data")]
	public class Data
	{
		public GeneralData general = new GeneralData();

		public List<string> inventory = new List<string>();

		public List<MomentData> moments = new List<MomentData>();

		public List<DisasterData> disasters = new List<DisasterData>();

		public List<FaceData> faces = new List<FaceData>();

		public List<StatData> stats = new List<StatData>();
	}

	[XmlType("date")]
	public class Date
	{
		[XmlAttribute]
		public int year;

		[XmlAttribute]
		public int month;

		[XmlAttribute]
		public int day;

		[XmlAttribute]
		public int hour;

		[XmlAttribute]
		public int minute;

		[XmlAttribute]
		public int second;

		public string timeStr
		{
			get
			{
				return string.Format("{0}:{1:00}", hour, minute);
			}
		}

		public DateTime systemDateTime
		{
			get
			{
				return new DateTime(year, month, day, hour, minute, second);
			}
		}

		public static Date Now()
		{
			DateTime now = DateTime.Now;
			Date date = new Date();
			date.day = now.Day;
			date.month = now.Month;
			date.hour = now.Hour;
			date.minute = now.Minute;
			date.second = now.Second;
			date.year = now.Year;
			return date;
		}
	}

	[XmlRoot("ObraDinnSaveData")]
	public class Container
	{
		public int version;

		public Date date;

		public string data;

		[XmlIgnore]
		public Data unencryptedData
		{
			get
			{
				string cryptoKey = "d080-esca-m00-bosun".Substring(0, 8) + "d090-fate-m00-mate1".Substring(0, 8);
				return XmlSerializerHelper.DeserializeObject<Data>(new TeaEncryptor(cryptoKey).Decrypt(data));
			}
			set
			{
				string cryptoKey = "d080-esca-m00-bosun".Substring(0, 8) + "d090-fate-m00-mate1".Substring(0, 8);
				data = new TeaEncryptor(cryptoKey).Encrypt(XmlSerializerHelper.SerializeObject(value));
			}
		}

		public string dataHash
		{
			get
			{
				using (MD5 mD = MD5.Create())
				{
					byte[] bytes = Encoding.UTF8.GetBytes(data);
					byte[] array = mD.ComputeHash(bytes);
					return BitConverter.ToString(array).Replace("-", "\u200c\u200b").ToLower();
				}
			}
		}
	}

	public class QuickList<T> where T : class
	{
		public delegate T Find(string id, bool createIfNotFound);

		private Find find;

		private Dictionary<string, T> dict = new Dictionary<string, T>();

		public QuickList(Find find_)
		{
			find = find_;
		}

		public T Get(string id, bool createIfNotFound = true)
		{
			T value = (T)null;
			if (dict.TryGetValue(id, out value))
			{
				return value;
			}
			value = find(id, createIfNotFound);
			if (value == null)
			{
				return (T)null;
			}
			dict.Add(id, value);
			return value;
		}
	}

	private class Quick
	{
		private Data data;

		public QuickList<MomentData> moments;

		public QuickList<DisasterData> disasters;

		public QuickList<FaceData> faces;

		public QuickList<StatData> stats;

		public Quick(Data data_)
		{
			data = data_;
			moments = new QuickList<MomentData>(GetMomentData);
			disasters = new QuickList<DisasterData>(GetDisasterData);
			faces = new QuickList<FaceData>(GetFaceData);
			stats = new QuickList<StatData>(GetStatData);
		}

		private MomentData GetMomentData(string id, bool createIfNotFound)
		{
			foreach (MomentData moment in data.moments)
			{
				if (moment.id == id)
				{
					return moment;
				}
			}
			if (!createIfNotFound)
			{
				return null;
			}
			if (Story.it.GetMomentIndex(id) < 0)
			{
				Debug.LogError("Invalid momentId: " + id);
			}
			MomentData momentData = new MomentData(id);
			data.moments.Add(momentData);
			return momentData;
		}

		private DisasterData GetDisasterData(string id, bool createIfNotFound)
		{
			foreach (DisasterData disaster in data.disasters)
			{
				if (disaster.id == id)
				{
					return disaster;
				}
			}
			if (!createIfNotFound)
			{
				return null;
			}
			if (Story.it.GetDisaster(id) == null)
			{
				Debug.LogError("Invalid disaster: " + id);
			}
			DisasterData disasterData = new DisasterData(id);
			data.disasters.Add(disasterData);
			return disasterData;
		}

		private FaceData GetFaceData(string id, bool createIfNotFound)
		{
			foreach (FaceData face in data.faces)
			{
				if (face.id == id)
				{
					return face;
				}
			}
			if (!createIfNotFound)
			{
				return null;
			}
			if (Manifest.it.GetCrewIndex(id) < 0)
			{
				Debug.LogError("Invalid face: " + id);
			}
			FaceData faceData = new FaceData(id);
			data.faces.Add(faceData);
			return faceData;
		}

		private StatData GetStatData(string id, bool createIfNotFound)
		{
			foreach (StatData stat in data.stats)
			{
				if (stat.id == id)
				{
					return stat;
				}
			}
			if (!createIfNotFound)
			{
				return null;
			}
			StatData statData = new StatData(id);
			data.stats.Add(statData);
			return statData;
		}
	}

	public class DataAccess<T, U> where T : class where U : class
	{
		private QuickList<T> quickList;

		public U this[string id]
		{
			get
			{
				return (id == null) ? ((U)null) : (quickList.Get(id) as U);
			}
		}

		public DataAccess(QuickList<T> quickList_)
		{
			quickList = quickList_;
		}
	}

	public const int kVersion = 2;

	public const int kClueWarningIgnore = -1;

	public const int kEraShipSomeUnvisited = 0;

	public const int kEraShipAllVisited = 1;

	public const int kEraTally = 2;

	public const int kEraOffice = 3;

	public DataAccess<MomentData, MomentData> moment;

	public DataAccess<MomentData, MomentDataRo> momentRo;

	public DataAccess<DisasterData, DisasterData> disaster;

	public DataAccess<DisasterData, DisasterDataRo> disasterRo;

	public DataAccess<FaceData, FaceData> face;

	public DataAccess<FaceData, FaceDataRo> faceRo;

	public UnityEventOne onInventoryReceived = new UnityEventOne();

	private Data data;

	private Quick quick;

	private bool showDebug;

	private Date diskDate_;

	private static SaveData instance_;

	private const bool kUseMemSave = false;

	private static string memSave = string.Empty;

	public Date diskDate
	{
		get
		{
			return diskDate_;
		}
	}

	public GeneralData general
	{
		get
		{
			return data.general;
		}
	}

	public GeneralDataRo generalRo
	{
		get
		{
			return data.general;
		}
	}

	public static SaveData it
	{
		get
		{
			if (instance_ == null)
			{
				instance_ = new SaveData();
			}
			return instance_;
		}
	}

	public SaveData()
	{
		DebugMenu.Add("Show/SaveData", KeyCode.None, delegate
		{
			showDebug = !showDebug;
		});
		Reset();
	}

	public void Reset()
	{
		SetData(new Data());
		diskDate_ = Date.Now();
	}

	private void SetData(Data data_)
	{
		data = data_;
		data.general.gameVersion = new Version().ToString();
		quick = new Quick(data);
		moment = new DataAccess<MomentData, MomentData>(quick.moments);
		momentRo = new DataAccess<MomentData, MomentDataRo>(quick.moments);
		disaster = new DataAccess<DisasterData, DisasterData>(quick.disasters);
		disasterRo = new DataAccess<DisasterData, DisasterDataRo>(quick.disasters);
		face = new DataAccess<FaceData, FaceData>(quick.faces);
		faceRo = new DataAccess<FaceData, FaceDataRo>(quick.faces);
	}

	public bool CanRewind()
	{
		return generalRo.era == 2 || generalRo.era == 3;
	}

	public void Rewind()
	{
		general.era = 1;
		general.officePawReady = false;
		general.officePackageReady = false;
		general.officeEndedOnce = false;
		general.officeHaveRevealedBook = false;
		general.bookPageId = "title";
		general.bookBookmarkedCrewId = string.Empty;
		general.lastVisitedMomentId = string.Empty;
		general.lastVisitedMomentExitPlayTime = 0f;
		general.momentPlayerSpotId = string.Empty;
		foreach (Manifest.Crew item in Manifest.it.IterateCrews())
		{
			if (Story.it.GetDeathOrDisappearZone(item.id) == Story.Zone.Office)
			{
				face[item.id].fateId = "unknown";
				face[item.id].markedCorrect = false;
			}
		}
		for (int i = 0; i < Story.it.disasterCount; i++)
		{
			Story.Disaster disaster = Story.it.GetDisaster(i);
			if (disaster.zone != Story.Zone.Office)
			{
				continue;
			}
			this.disaster[disaster.id].revealedChartInBook = false;
			this.disaster[disaster.id].revealedDisappearancesInBook = false;
			foreach (Story.Moment moment in disaster.moments)
			{
				this.moment[moment.id].Reset();
			}
		}
		UpdateZoneCompletion(Story.Zone.Office);
	}

	public int GetNumFatesCorrect()
	{
		int num = 0;
		foreach (FaceData face in data.faces)
		{
			if (face.markedCorrect)
			{
				num++;
			}
		}
		return num;
	}

	public Player.Spot GetPlayerExploringSpot()
	{
		if (generalRo.exploringPlayerSpotValid)
		{
			return new Player.Spot(generalRo.exploringPlayerSpotFootPos, generalRo.exploringPlayerSpotLook);
		}
		return null;
	}

	public void SetPlayerExploringSpot(Player.Spot spot)
	{
		if (spot != null)
		{
			general.exploringPlayerSpotValid = true;
			general.exploringPlayerSpotLook = spot.look;
			general.exploringPlayerSpotFootPos = spot.footPos;
			general.momentPlayerSpotId = string.Empty;
		}
		else
		{
			general.exploringPlayerSpotValid = false;
		}
	}

	public Player.Spot GetPlayerMomentSpot()
	{
		if (generalRo.momentPlayerSpotId.HasValue() && Game.instance != null && Game.IsInMoment(generalRo.momentPlayerSpotId))
		{
			return new Player.Spot(generalRo.momentPlayerSpotFootPos, generalRo.momentPlayerSpotLook);
		}
		return null;
	}

	public void SetPlayerMomentSpot(string momentId, Player.Spot spot)
	{
		general.momentPlayerSpotId = momentId;
		if (momentId.HasValue() && spot != null)
		{
			general.momentPlayerSpotLook = spot.look;
			general.momentPlayerSpotFootPos = spot.footPos;
		}
	}

	public FaceData FindFaceDataForNameId(string nameId)
	{
		if (string.IsNullOrEmpty(nameId))
		{
			return null;
		}
		foreach (FaceData face in data.faces)
		{
			if (face.nameId == nameId)
			{
				return face;
			}
		}
		return null;
	}

	public FaceDataRo FindFaceDataRoForNameId(string nameId)
	{
		return FindFaceDataForNameId(nameId);
	}

	public bool HaveInventory(string inventoryId)
	{
		return data.inventory.Contains(inventoryId);
	}

	public bool HaveWatchAndBook()
	{
		return HaveInventory("watch");
	}

	public void GiveInventory(string inventoryId)
	{
		if (!HaveInventory(inventoryId))
		{
			data.inventory.Add(inventoryId);
			onInventoryReceived.Invoke(inventoryId);
		}
	}

	public bool HaveVisitedMoment(string momentId)
	{
		MomentDataRo momentDataRo = momentRo[momentId];
		return momentDataRo.visited;
	}

	public bool HaveVisitedDisaster(string disasterId)
	{
		Story.Disaster disaster = Story.it.GetDisaster(disasterId);
		if (disaster == null)
		{
			return false;
		}
		foreach (Story.Moment moment in disaster.moments)
		{
			if (HaveVisitedMoment(moment.id))
			{
				return true;
			}
		}
		return false;
	}

	public bool HaveVisitedClimax(string crewId)
	{
		Story.Climax climax = Story.it.GetClimax(crewId);
		if (climax.type == Story.ClimaxType.Die)
		{
			return momentRo[climax.deathMomentIdOrDisasterId].visited;
		}
		Story.Disaster disaster = Story.it.GetDisaster(climax.deathMomentIdOrDisasterId);
		foreach (Story.Moment moment in disaster.moments)
		{
			if (!momentRo[moment.id].visited)
			{
				return false;
			}
		}
		return true;
	}

	public bool HaveVisitedThisManyMoments(int count)
	{
		int num = 0;
		foreach (MomentData moment in data.moments)
		{
			if (moment.visited)
			{
				num++;
			}
			if (num >= count)
			{
				return true;
			}
		}
		return false;
	}

	public void UpdateZoneCompletion(Story.Zone zone)
	{
		int num = 0;
		int num2 = 0;
		foreach (Story.Moment item in Story.it.IterateAllMoments())
		{
			if (item.zone == zone)
			{
				num2++;
				MomentDataRo momentDataRo = momentRo[item.id];
				if (momentRo[item.id].visited)
				{
					num++;
				}
			}
		}
		SetStat("zone-complete-" + zone.ToString().ToLower(), (num == num2) ? 1 : 0);
	}

	public bool GetZoneIsSolved(Story.Zone zone)
	{
		return GetZoneUnsolvedCount(zone) == 0;
	}

	public int GetZoneUnsolvedCount(Story.Zone zone)
	{
		int num = 0;
		foreach (Manifest.Crew item in Manifest.it.IterateCrews())
		{
			if (Story.it.GetDeathOrDisappearZone(item.id) == zone && !faceRo[item.id].markedCorrect)
			{
				num++;
			}
		}
		return num;
	}

	public int GetZoneSolvedCount(Story.Zone zone)
	{
		int num = 0;
		foreach (Manifest.Crew item in Manifest.it.IterateCrews())
		{
			if (Story.it.GetDeathOrDisappearZone(item.id) == zone && faceRo[item.id].markedCorrect)
			{
				num++;
			}
		}
		return num;
	}

	public bool GetCrewCategoryIsSolved(string categoryId)
	{
		if (!categoryId.StartsWith("?"))
		{
			return false;
		}
		foreach (Manifest.Crew item in Manifest.it.IterateCrews())
		{
			if (item.categoryId == categoryId && !faceRo[item.id].markedCorrect)
			{
				return false;
			}
		}
		return true;
	}

	public string GetWantRevealCompleteDisasterId()
	{
		for (int i = 0; i < Story.it.disasterCount; i++)
		{
			Story.Disaster disaster = Story.it.GetDisaster(i);
			if (!disasterRo[disaster.id].revealedDisappearancesInBook && HaveVisitedEntireDisaster(disaster.id))
			{
				return disaster.id;
			}
		}
		return null;
	}

	public int GetDisasterSolvedBits()
	{
		int num = 0;
		for (int i = 0; i < Story.it.disasterCount; i++)
		{
			Story.Disaster disaster = Story.it.GetDisaster(i);
			int num2 = 0;
			int num3 = 0;
			foreach (string item in Story.it.IterateDeathOrDisappearCrewIds(disaster.id))
			{
				num2++;
				if (faceRo[item].markedCorrect)
				{
					num3++;
				}
			}
			if (num3 == num2)
			{
				num |= 1 << i;
			}
		}
		return num;
	}

	public bool HaveVisitedEntireDisaster(string disasterId)
	{
		Story.Disaster disaster = Story.it.GetDisaster(disasterId);
		if (disaster == null)
		{
			return false;
		}
		foreach (Story.Moment moment in disaster.moments)
		{
			if (!momentRo[moment.id].visited)
			{
				return false;
			}
		}
		return true;
	}

	public bool GetMomentHasLockedPullableCorpseInside(string momentId)
	{
		Story.Moment moment = Story.it.GetMoment(momentId);
		if (moment == null || !momentRo[momentId].visited)
		{
			return false;
		}
		string[] pullableMomentIds = moment.pullableMomentIds;
		foreach (string id in pullableMomentIds)
		{
			if (!momentRo[id].unlocked)
			{
				return true;
			}
		}
		return false;
	}

	public int GetStat(string id, int defaultValue = 0)
	{
		if (id.StartsWith("#mom-visitCount-"))
		{
			string id2 = id.Substring("#mom-visitCount-".Length);
			return momentRo[id2].visitCount;
		}
		if (id.StartsWith("#mom-unlocked-"))
		{
			string id3 = id.Substring("#mom-unlocked-".Length);
			return momentRo[id3].unlocked ? 1 : 0;
		}
		if (id.StartsWith("#inv-"))
		{
			string inventoryId = id.Substring("#inv-".Length);
			return HaveInventory(inventoryId) ? 1 : 0;
		}
		StatData statData = quick.stats.Get(id, false);
		return (statData == null) ? defaultValue : statData.val;
	}

	public void SetStat(string id, int val)
	{
		StatData statData = quick.stats.Get(id);
		statData.val = val;
		Debug.Log("Set stat: " + id + " = " + GetStat(id));
	}

	public void IncStat(string id)
	{
		SetStat(id, GetStat(id) + 1);
	}

	public void Save(string id)
	{
		Container container = new Container();
		container.version = 2;
		container.date = Date.Now();
		container.unencryptedData = data;
		string filepath = GetFilepath(id, string.Empty);
		File.WriteAllText(filepath, XmlSerializerHelper.SerializeObject(container));
		Debug.Log("Saved to " + filepath);
		diskDate_ = container.date;
	}

	public bool Load(string id)
	{
		try
		{
			Container container = new Container();
			string filepath = GetFilepath(id, string.Empty);
			container = XmlSerializerHelper.DeserializeObject<Container>(File.ReadAllText(filepath));
			Debug.Log("Loaded from " + filepath);
			diskDate_ = container.date;
			SetData(container.unencryptedData);
			return true;
		}
		catch (Exception ex)
		{
			if (ex != null)
			{
				Debug.Log(ex.Message);
			}
			Reset();
			return false;
		}
	}

	public void DebugGive()
	{
		GiveInventory("watch");
		data.general.bookVisitedLastPage = true;
		string[] collection = new string[13]
		{
			"d060-krak-m05-mid1", "d060-krak-m06-top3", "d060-krak-m07-pass1", "d080-esca-m00-bosun", "d080-esca-m01-stewm1", "d080-esca-m02-top2", "d080-esca-m03-gunnermate", "d080-esca-m04-mate4", "d080-esca-m05-mid2", "d090-fate-m00-mate1",
			"d090-fate-m01-seab", "d090-fate-m02-topa", "d090-fate-m03-captain"
		};
		List<string> list = new List<string>(collection);
		foreach (string item in list)
		{
			MomentData momentData = moment[item];
			momentData.unlocked = true;
			momentData.revealedGhosts = true;
			momentData.visitCount = 1;
			momentData.revealedPageInBook = true;
			string id = Story.it.GetMoment(item).disaster.id;
			DisasterData disasterData = disaster[id];
			disasterData.revealedChartInBook = true;
			disasterData.revealedDisappearancesInBook = true;
		}
		DebugSetFateCorrect("mate1", true);
		DebugSetFateCorrect("seab", true);
		DebugSetFateCorrect("topa", true);
		DebugUpdateZoneCompletions();
		data.general.bookPageId = "crew";
		data.general.era = 1;
	}

	public void DebugUpdateZoneCompletions()
	{
		UpdateZoneCompletion(Story.Zone.Ship);
		UpdateZoneCompletion(Story.Zone.Office);
	}

	public void DebugSetFacesAndFatesRandomly(bool markedCorrect = false)
	{
		List<int> list = ShuffledSequence.MakeShuffledArray(Manifest.it.crewCount);
		List<int> list2 = ShuffledSequence.MakeShuffledArray(Manifest.it.crewCount);
		for (int i = 0; i < Manifest.it.crewCount; i++)
		{
			string crewId = Manifest.it.GetCrewId(i);
			string crewId2 = Manifest.it.GetCrewId(list[i]);
			string crewId3 = Manifest.it.GetCrewId(list2[i]);
			FaceData faceData = face[crewId];
			faceData.nameId = crewId2;
			faceData.fateId = Manifest.it.GetCrewFateIds(crewId3)[0];
			faceData.fateId = Manifest.it.FateId_ScrubSelfKiller(faceData.nameId, faceData.fateId);
			faceData.markedCorrect = markedCorrect;
		}
	}

	private void DebugSetFateCorrect(string crewId, bool markedCorrect = false)
	{
		FaceData faceData = face[crewId];
		faceData.nameId = crewId;
		faceData.fateId = Manifest.it.GetCrewFateIds(crewId)[0];
		faceData.markedCorrect = markedCorrect;
	}

	public void DebugVisitAllMoments()
	{
		for (int i = 0; i < Story.it.momentCount; i++)
		{
			string momentId = Story.it.GetMomentId(i);
			MomentData momentData = moment[momentId];
			momentData.unlocked = true;
			momentData.revealedGhosts = true;
			momentData.revealedPageInBook = true;
			momentData.visitCount++;
		}
		for (int j = 0; j < Story.it.disasterCount; j++)
		{
			string id = Story.it.GetDisaster(j).id;
			DisasterData disasterData = disaster[id];
			disasterData.revealedChartInBook = true;
			disasterData.revealedDisappearancesInBook = true;
		}
		DebugUpdateZoneCompletions();
	}

	private void DebugUpdateFatesCorrect()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < Manifest.it.crewCount; i++)
		{
			string crewId = Manifest.it.GetCrewId(i);
			FaceData faceData = face[crewId];
			if (!faceData.markedCorrect && faceData.id == faceData.nameId && Manifest.it.IsCorrectFate(crewId, faceData.fateId))
			{
				list.Add(crewId);
			}
		}
		while (list.Count >= 3)
		{
			for (int j = 0; j < 3; j++)
			{
				string id = list[j];
				FaceData faceData2 = face[id];
				faceData2.markedCorrect = true;
			}
			list.RemoveRange(0, 3);
		}
	}

	public void DrawDebug()
	{
		if (!showDebug)
		{
			return;
		}
		DebugDrawer.Screen(delegate(DebugDrawer dd)
		{
			int num = 6;
			int num2 = num + 2;
			int num3 = 10;
			int num4 = 360 - num2;
			Color color = new Color(0.1f, 0.1f, 0.1f, 0.5f);
			Rect rect = new Rect(0f, 0f, 640f, 360f);
			Color color2 = new Color(0.8f, 0.6f, 0.8f, 1f);
			Color color3 = new Color(0.2f, 0.9f, 0.9f, 1f);
			Color color4 = new Color(1f, 0.5f, 0.1f, 1f);
			dd.FillRect(color, rect);
			List<MomentData> list = new List<MomentData>(data.moments);
			list.Sort((MomentData a, MomentData b) => string.Compare(a.id, b.id));
			foreach (MomentData item in list)
			{
				dd.DrawText(color2, item.description, new Vector3(num3, num4, 0f), num, true);
				num4 -= num2;
				if (num4 < 0)
				{
					num4 = 360 - num2;
					num3 = 320;
				}
			}
			foreach (StatData stat in data.stats)
			{
				dd.DrawText(color4, stat.description, new Vector3(num3, num4, 0f), num, true);
				num4 -= num2;
				if (num4 < 0)
				{
					num4 = 360 - num2;
					num3 = 320;
				}
			}
			foreach (string item2 in data.inventory)
			{
				dd.DrawText(color3, item2, new Vector3(num3, num4, 0f), num, true);
				num4 -= num2;
				if (num4 < 0)
				{
					num4 = 360 - num2;
					num3 = 320;
				}
			}
		});
	}

	private static string GetFilepath(string id, string subDir = "")
	{
		string text = "ObraDinnSave-";
		string path = Application.persistentDataPath;
		if (subDir.HasValue())
		{
			path = Path.Combine(path, subDir);
		}
		return Path.Combine(path, text + id + ".txt");
	}

	public static bool CanLoad(string id)
	{
		string filepath = GetFilepath(id, string.Empty);
		return File.Exists(filepath);
	}

	public static void MakeBackup(string id, string reason, bool appendDate = false)
	{
		string filepath = GetFilepath(id, string.Empty);
		if (File.Exists(filepath))
		{
			string sourceFileName = filepath;
			string text = id + "-" + reason;
			if (appendDate)
			{
				text = text + "-" + DateTime.Now.ToString("yyyyMMddHHmmss");
			}
			string filepath2 = GetFilepath(text, "Backup");
			string directoryName = Path.GetDirectoryName(filepath2);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			File.Copy(sourceFileName, filepath2, true);
			Debug.LogFormat("Copied to backup: " + filepath2);
		}
		else
		{
			Debug.LogWarning("Nothing to backup: " + filepath);
		}
	}

	public static void Copy(string srcId, string dstId)
	{
		string filepath = GetFilepath(srcId, string.Empty);
		string filepath2 = GetFilepath(dstId, string.Empty);
		if (File.Exists(filepath))
		{
			File.Copy(filepath, filepath2, true);
		}
		else
		{
			Debug.LogWarning("Nothing to copy: " + filepath);
		}
	}

	public static void Delete(string id)
	{
		string filepath = GetFilepath(id, string.Empty);
		if (File.Exists(filepath))
		{
			File.Delete(filepath);
		}
		else
		{
			Debug.LogWarning("Nothing to delete: " + filepath);
		}
	}
}
