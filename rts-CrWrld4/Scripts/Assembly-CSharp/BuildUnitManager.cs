using System.Collections.Generic;
using NBT.Tags;

public class BuildUnitManager
{
	public static Dictionary<string, string> UNITNAMES;

	private bool _riftLabAvailable;

	private bool _factoryAvailable;

	private bool _ernPortalAvailable;

	private bool _towerAvailable;

	private bool _pylonAvailable;

	private bool _minerAvailable;

	private bool _greenarRefineryAvailable;

	private bool _terpAvailable;

	private bool _porterAvailable;

	private bool _cannonAvailable;

	private bool _mortarAvailable;

	private bool _sprayerAvailable;

	private bool _sniperAvailable;

	private bool _missileLauncherAvailable;

	private bool _nullifierAvailable;

	private bool _runwayAvailable;

	private bool _bomberPadAvailable;

	private bool _acBomberPadAvailable;

	private bool _rocketPadAvailable;

	private bool _platformAvailable;

	private bool _shieldAvailable;

	private bool _microRiftAvailable;

	private bool _chronatAvailable;

	private bool _airshipAvailable;

	private bool _berthaAvailable;

	private bool _sweeperAvailable;

	private Dictionary<string, int> buildCountLimits;

	public const string AIRSHIP = "ca8dfbe4-a3ca-4223-b8c4-070de8877b26";

	public const string BERTHA = "b2d47782-ebe0-4508-ace3-6ae4503b62fc";

	public const string SWEEPER = "c5b44bd0-1518-4091-9f15-36c919bc37c7";

	public const string CPACK_AIRSHIP = "341bad0a-fdc2-4239-b134-8acc1000ed3d";

	public const string CPACK_BERTHA = "a6cab11e-95b7-4c15-a8a2-85aeb92cf85b";

	public const string CPACK_SWEEPER = "363363a4-3f1f-417e-95d9-2a8ecd0b9185";

	public bool riftLabAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool factoryAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool ernPortalAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool towerAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool pylonAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool minerAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool greenarRefineryAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool terpAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool porterAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool cannonAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool mortarAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool sprayerAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool sniperAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool missileLauncherAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool nullifierAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool runwayAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool bomberPadAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool acBomberPadAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool rocketPadAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool platformAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool shieldAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool microRiftAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool chronatAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool airshipAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool berthaAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool sweeperAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void RemoveCPackIfNone(string cpackName, string cpackGUID)
	{
	}

	public bool GetAvailable(string name)
	{
		return false;
	}

	public void SetAvailable(string name, bool val)
	{
	}

	public int GetCount(string name)
	{
		return 0;
	}

	public int GetBuildCountLimit(string val)
	{
		return 0;
	}

	public void SetBuildCountLimit(string val, int amt)
	{
	}

	public int GetAvailableBuildCount(string val, int extra = 0)
	{
		return 0;
	}

	public void ReadData(Tag tag)
	{
	}

	public void WriteData(TagCompound baseTag)
	{
	}
}
