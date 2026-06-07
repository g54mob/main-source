using System;
using System.Collections.Generic;
using System.Xml.Linq;
using BestHTTP;
using TMPro;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class ColonySector : MonoBehaviour
{
	public struct TagCountStruct
	{
		public string tag;

		public int count;

		public TagCountStruct(string tag, int count)
		{
			this.tag = null;
			this.count = 0;
		}
	}

	public class MapEntry
	{
		public int id;

		public int ts;

		public string guid;

		public string author;

		public string title;

		public int width;

		public int height;

		public byte objectives;

		public string tags;

		public string[] tagArray;

		public int thumbs;

		public string topic;

		public string discordChannel;

		public string discordThread;

		public int tnSize;

		public int version;

		public MapEntry(int id, int ts, string guid, string author, string title, int width, int height, byte objectives, string tags, int thumbs, string topic, string discordChannel, string discordThread, string tnSize, int version)
		{
		}

		public void UpdateTags(OrderedDictionary2<string, int> tagResults)
		{
		}

		private void UpdateTagArray()
		{
		}

		private bool ContainsString(string[] array, string[] tags)
		{
			return false;
		}

		private bool MatchesString(string author, string[] tags)
		{
			return false;
		}

		private bool ContainsAllStrings(string[] array, string[] tags)
		{
			return false;
		}

		private static string WildCardToRegular(string value)
		{
			return null;
		}

		public bool MeetsFilterCriteria(HashSet<string> hidden, bool hiddenFilter, HashSet<string> favorites, bool favoriteFilter, bool obj0Filter, bool obj1Filter, bool obj2Filter, bool obj3Filter, bool obj4Filter, bool obj5Filter, bool inprogressFilter, bool completedFilter, bool notPlayedFilter, bool downloadedFilter, string textTitleFilter, string[] authorsFilter, string[] tagsFilter, bool notTagsFilter, string startNum)
		{
			return false;
		}
	}

	private const int MAX_TAG_LIST_COUNT = 25;

	public GameObject colonyMissionBadgePrefab;

	public RectTransform badgeContainer;

	public GameObject downloadOverviewPane;

	public TextMeshProUGUI downloadOverviewPaneText;

	public GameObject downloadPane;

	public GameObject detailPane;

	public TextMeshProUGUI pageText;

	public GameObject newestMissionsButton;

	public GameObject newerJumpMissionsButton;

	public GameObject newerMissionsButton;

	public GameObject oldestMissionsButton;

	public GameObject olderJumpMissionsButton;

	public GameObject olderMissionsButton;

	public TextMeshProUGUI numberButtonText;

	[NonSerialized]
	public List<MapEntry> mapList;

	private bool mapListDirty;

	private Dictionary<string, Texture2D> thumbnailCache;

	private Queue<MapEntry> thumbnailRetrievalQueue;

	private Queue<KeyValuePair<string, string>> mapRetrievalQueue;

	private bool loadThumbnail;

	private bool loadMap;

	private KeyValuePair<string, string> currentMapDownloading;

	private bool retrievingMetaData;

	private int randomOrderSeed;

	private XDocument metaData;

	private ColonyMissionBadge _selectedBadge;

	private int jumpToBadge;

	private HashSet<string> hidden;

	private HashSet<string> favorites;

	private HashSet<string> reports;

	public List<TagCountStruct> masterTagList;

	public ColonyFilters colonyFilters;

	public ColonySort colonySort;

	private int _currentPage;

	private string reportReason;

	private float lastContainerWidth;

	private float lastContainerHeight;

	private string _loadMapId;

	private List<MapEntry> masterMapList;

	private ColonyMissionBadge selectedBadge
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int currentPage
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private bool favoriteFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool inprogressFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool completedFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool notPlayedFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool downloadedFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool hiddenFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private string startNum
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private string textTitleFilter
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private string textAuthorFilter
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private string textTagsFilter
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private bool notTextTagsFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool objNullifyFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool objTotemFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool objReclaimFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool objSurviveFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool objCollectFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool objCustomFilter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private int sortBy
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void ApplyFilters()
	{
	}

	public void OnOlderMissionsClick(int amt)
	{
	}

	public void OnNewerMissionsClick(int amt)
	{
	}

	public void RandomSort()
	{
	}

	public void SetFavorite(MapEntry me, bool val)
	{
	}

	public bool IsMapFavorite(MapEntry me)
	{
		return false;
	}

	public void HideMap(MapEntry me, bool val)
	{
	}

	public bool IsMapHidden(MapEntry me)
	{
		return false;
	}

	public void ReportMap(MapEntry me, bool val, string reportReason)
	{
	}

	public bool IsMapReported(MapEntry me)
	{
		return false;
	}

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void Update()
	{
	}

	public void OnNumberButtonClicked()
	{
	}

	public void Show(bool show)
	{
	}

	public void PlayMission(MapEntry me)
	{
	}

	public void OnDownload()
	{
	}

	public void DownloadMap(MapEntry me)
	{
	}

	private MapEntry GetMapEntryFromID(int mapID)
	{
		return null;
	}

	private void SelectBadge(int mapID)
	{
	}

	public void SelectBadge(ColonyMissionBadge badge)
	{
	}

	public void RefreshDetail()
	{
	}

	private void SelectBadgeIfOnPage()
	{
	}

	private void RefreshDetailOld()
	{
	}

	public void RefreshBadges()
	{
	}

	public Texture2D GetThumbnailCache(MapEntry me)
	{
		return null;
	}

	private void GetPageMetrics(out int numX, out int numY, out float boxWidth, out float boxHeight, out int pageCount)
	{
		numX = default(int);
		numY = default(int);
		boxWidth = default(float);
		boxHeight = default(float);
		pageCount = default(int);
	}

	private void ProcessThumbnailRetrievalList()
	{
	}

	private void ProcessMapRetrievalList()
	{
	}

	private string GetThumbnailFile(string guid)
	{
		return null;
	}

	private bool IsThumbnailCached(MapEntry me)
	{
		return false;
	}

	private byte[] GetThumbnailData(string guid)
	{
		return null;
	}

	private Texture2D GetThumbnailTexture(string guid)
	{
		return null;
	}

	private void RetrieveThumbnail(string guid)
	{
	}

	private void RetrieveThumbnailBestCallback(HTTPRequest request, HTTPResponse response)
	{
	}

	private void SaveThumbnail(string guid, byte[] data)
	{
	}

	public bool IsMapQueued(string guid)
	{
		return false;
	}

	public bool IsMapCurrentlyDownloading(string guid)
	{
		return false;
	}

	private void RetrieveMap(string guid, string id)
	{
	}

	private void RetrieveMapBestCallback(HTTPRequest request, HTTPResponse response)
	{
	}

	private static string GetBaseMapFile(string id, bool suppressCreate = false)
	{
		return null;
	}

	private static string GetMapFile(string id)
	{
		return null;
	}

	public static bool IsMapDownloaded(string id)
	{
		return false;
	}

	private void SaveMap(string id, byte[] data)
	{
	}

	private void ReportMap(string guid)
	{
	}

	private void ReportMapBest(string guid)
	{
	}

	private void ReportMapBestCallback(HTTPRequest request, HTTPResponse response)
	{
	}

	public void RetrieveMetadata()
	{
	}

	private void RetrieveMetadataBest()
	{
	}

	private void RetrieveMetadataBestCallback(HTTPRequest request, HTTPResponse response)
	{
	}

	private void RetrieveMetadataBestProgress(HTTPRequest request, long downloaded, long length)
	{
	}

	private void GetLastMetaData()
	{
	}

	public static string[] CleanTags(string rawTags)
	{
		return null;
	}

	private void GetMapListFromMetadata(XDocument xdoc)
	{
	}

	private void GetMapListFromMaster()
	{
	}

	public static List<MapEntry> GetMapListFM(XDocument xdoc, out List<TagCountStruct> masterTagList)
	{
		masterTagList = null;
		return null;
	}

	public static void Shuffle<T>(IList<T> list, int randomOrderSeed)
	{
	}

	private void SaveFilters()
	{
	}

	public static string Decompress(byte[] gzip)
	{
		return null;
	}
}
