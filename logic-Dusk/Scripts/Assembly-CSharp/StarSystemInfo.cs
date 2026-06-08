using System.Collections.Generic;
using UnityEngine;

public class StarSystemInfo
{
	private int _id;

	private string finalGroupKey = string.Empty;

	private int lastGroupKeyInternalID;

	private GalaxyNode _galaxyNode;

	private UniverseNode.ConnectionEdge _stargateConnection;

	private string _guiTotalObjects = string.Empty;

	private int guiNumberVisited = -1;

	private string _guiVisitedCount = string.Empty;

	public StarSystemInfoEventDelegate OnStarSystemEvent;

	public int InternalId { get; private set; }

	public int Id
	{
		get
		{
			return _id;
		}
		set
		{
			if (value > 0)
			{
				GalaxySaveFile.Save(GroupKey, "ID", value);
			}
			_id = value;
			Refresh();
		}
	}

	public bool IsNursery { get; set; }

	public string Name
	{
		get
		{
			string text = GalaxySaveFile.Get(GroupKey, "NAME", string.Empty);
			if (string.IsNullOrEmpty(text))
			{
				text = string.Format("Star System #{0}", Id);
			}
			return text;
		}
		set
		{
			GalaxySaveFile.Save(GroupKey, "NAME", value);
		}
	}

	public string GroupKey
	{
		get
		{
			if (lastGroupKeyInternalID != InternalId)
			{
				finalGroupKey = string.Format("SYS_{0}", InternalId);
				lastGroupKeyInternalID = InternalId;
			}
			return finalGroupKey;
		}
	}

	public GalaxyNode galaxyNode
	{
		get
		{
			return _galaxyNode;
		}
		set
		{
			_galaxyNode = value;
			if (galaxyNode != null)
			{
				galaxyNode.Refresh();
			}
		}
	}

	public Vector3 Coordinates { get; set; }

	public Vector2 TrueImageCoords { get; set; }

	public StarSystemBackgroundScanEnum ScannedBackground { get; set; }

	public bool HasStargate
	{
		get
		{
			return GalaxySaveFile.Get(GroupKey, "SG", false);
		}
		set
		{
			GalaxySaveFile.Save(GroupKey, "SG", value);
		}
	}

	public bool IsStargateVisited
	{
		get
		{
			return GalaxySaveFile.Get(GroupKey, "SG_VISITED", false);
		}
		set
		{
			GalaxySaveFile.Save(GroupKey, "SG_VISITED", value);
		}
	}

	public bool IsChildGate
	{
		get
		{
			return GalaxySaveFile.Get(GroupKey, "SG_CHILD", false);
		}
		set
		{
			GalaxySaveFile.Save(GroupKey, "SG_CHILD", value);
		}
	}

	public UniverseNode.ConnectionEdge StargateConnection
	{
		get
		{
			return _stargateConnection;
		}
		set
		{
			_stargateConnection = value;
			if (value != null)
			{
				if (IsChildGate)
				{
					UniverseSaveFile.Save(value.GroupKey, "SYS_C", GroupKey);
				}
				else
				{
					UniverseSaveFile.Save(value.GroupKey, "SYS_P", GroupKey);
				}
				GalaxySaveFile.Save(GroupKey, "SG_OTHER", value.GetOtherNode((!IsChildGate) ? value.childNode : value.parentNode).GroupKey);
				GalaxySaveFile.Save(GroupKey, "GXE_P", value.GroupKey);
			}
		}
	}

	public int NumberOfDungeons { get; set; }

	public int NumberOfStations { get; set; }

	public int NumberOfOutposts { get; set; }

	public int NumberOfTradingPosts { get; set; }

	public int TotalObjects
	{
		get
		{
			return (HasStargate ? 1 : 0) + NumberOfDungeons + NumberOfOutposts + NumberOfTradingPosts;
		}
	}

	public int VisitedCount { get; private set; }

	public string guiTotalObjects
	{
		get
		{
			if (string.IsNullOrEmpty(_guiTotalObjects))
			{
				_guiTotalObjects = "Total Objects: " + TotalObjects;
			}
			return _guiTotalObjects;
		}
	}

	public string guiVisitedCount
	{
		get
		{
			if (guiNumberVisited != VisitedCount)
			{
				_guiVisitedCount = string.Format("Visited: {0}", VisitedCount);
				guiNumberVisited = VisitedCount;
			}
			return _guiVisitedCount;
		}
	}

	public float DifficultyMin { get; set; }

	public float DifficultyMax { get; set; }

	public float OrbitLineRotation { get; set; }

	public List<DungeonInfo> Dungeons { get; set; }

	public StarSystemInfo LeftStar { get; set; }

	public StarSystemInfo RightStar { get; set; }

	public StarSystemInfo AboveStar { get; set; }

	public StarSystemInfo BelowStar { get; set; }

	private StarSystemInfo()
	{
	}

	public StarSystemInfo(List<StarSystemInfo> siblingStarSystemList)
	{
		bool flag = false;
		int num = -1;
		do
		{
			num = Random.Range(0, int.MaxValue);
			if (siblingStarSystemList != null)
			{
				foreach (StarSystemInfo siblingStarSystem in siblingStarSystemList)
				{
					if (siblingStarSystem.Id != num)
					{
					}
				}
				flag = true;
			}
			else
			{
				num = 0;
				flag = true;
			}
		}
		while (!flag);
		InternalId = num;
		num = GalaxySaveFile.Get(GroupKey, "ID", 0);
		if (num != 0)
		{
			Id = num;
		}
	}

	private StarSystemInfo(int id)
	{
		Id = id;
		Refresh();
	}

	public void Refresh()
	{
		VisitedCount = 0;
		if (GlobalSettings.IsTutorial)
		{
			return;
		}
		List<string> allGroups = GalaxySaveFile.GetAllGroups("OBJ", "P", GroupKey);
		int count = allGroups.Count;
		for (int i = 0; i < count; i++)
		{
			string groupKey = allGroups[i];
			if (GalaxySaveFile.Get(groupKey, "VISITED", false))
			{
				VisitedCount++;
			}
		}
	}

	public override string ToString()
	{
		return string.Format("{0} ({1})", Id, InternalId);
	}
}
