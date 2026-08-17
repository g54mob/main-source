using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Data.Stage;

[Serializable]
public class Tileset
{
	private string _003CsetKey_003Ek__BackingField;

	private string _003CsetPath_003Ek__BackingField;

	private string _003CmapKey_003Ek__BackingField;

	private string _003CmapPath_003Ek__BackingField;

	private bool _003CisTiling_003Ek__BackingField;

	private bool _003CisHorizontalRoad_003Ek__BackingField;

	private bool _003ChasWallsCheckDestructibleLogic_003Ek__BackingField;

	private float? _003CSizeX_003Ek__BackingField;

	private float? _003CSizeY_003Ek__BackingField;

	private float? _003CminTreasureX_003Ek__BackingField;

	private float? _003CmaxTreasureX_003Ek__BackingField;

	private float? _003CminTreasureY_003Ek__BackingField;

	private float? _003CmaxTreasureY_003Ek__BackingField;

	private uint? _003Ctint_003Ek__BackingField;

	private ItemType? _003CmapRelic_003Ek__BackingField;

	private string _003CdetailsTexture_003Ek__BackingField;

	private HardBounds _003ChardBounds_003Ek__BackingField;

	public string setKey
	{
		get
		{
			return _003CsetKey_003Ek__BackingField;
		}
		set
		{
			_003CsetKey_003Ek__BackingField = value;
		}
	}

	public string setPath
	{
		get
		{
			return _003CsetPath_003Ek__BackingField;
		}
		set
		{
			_003CsetPath_003Ek__BackingField = value;
		}
	}

	public string mapKey
	{
		get
		{
			return _003CmapKey_003Ek__BackingField;
		}
		set
		{
			_003CmapKey_003Ek__BackingField = value;
		}
	}

	public string mapPath
	{
		get
		{
			return _003CmapPath_003Ek__BackingField;
		}
		set
		{
			_003CmapPath_003Ek__BackingField = value;
		}
	}

	public bool isTiling
	{
		get
		{
			return _003CisTiling_003Ek__BackingField;
		}
		set
		{
			_003CisTiling_003Ek__BackingField = value;
		}
	}

	public bool isHorizontalRoad
	{
		get
		{
			return _003CisHorizontalRoad_003Ek__BackingField;
		}
		set
		{
			_003CisHorizontalRoad_003Ek__BackingField = value;
		}
	}

	public bool hasWallsCheckDestructibleLogic
	{
		get
		{
			return _003ChasWallsCheckDestructibleLogic_003Ek__BackingField;
		}
		set
		{
			_003ChasWallsCheckDestructibleLogic_003Ek__BackingField = value;
		}
	}

	public float? SizeX
	{
		get
		{
			return _003CSizeX_003Ek__BackingField;
		}
		set
		{
			_003CSizeX_003Ek__BackingField = value;
		}
	}

	public float? SizeY
	{
		get
		{
			return _003CSizeY_003Ek__BackingField;
		}
		set
		{
			_003CSizeY_003Ek__BackingField = value;
		}
	}

	public float? minTreasureX
	{
		get
		{
			return _003CminTreasureX_003Ek__BackingField;
		}
		set
		{
			_003CminTreasureX_003Ek__BackingField = value;
		}
	}

	public float? maxTreasureX
	{
		get
		{
			return _003CmaxTreasureX_003Ek__BackingField;
		}
		set
		{
			_003CmaxTreasureX_003Ek__BackingField = value;
		}
	}

	public float? minTreasureY
	{
		get
		{
			return _003CminTreasureY_003Ek__BackingField;
		}
		set
		{
			_003CminTreasureY_003Ek__BackingField = value;
		}
	}

	public float? maxTreasureY
	{
		get
		{
			return _003CmaxTreasureY_003Ek__BackingField;
		}
		set
		{
			_003CmaxTreasureY_003Ek__BackingField = value;
		}
	}

	public uint? tint
	{
		get
		{
			return _003Ctint_003Ek__BackingField;
		}
		set
		{
			_003Ctint_003Ek__BackingField = value;
		}
	}

	public ItemType? mapRelic
	{
		get
		{
			return _003CmapRelic_003Ek__BackingField;
		}
		set
		{
			_003CmapRelic_003Ek__BackingField = value;
		}
	}

	public string detailsTexture
	{
		get
		{
			return _003CdetailsTexture_003Ek__BackingField;
		}
		set
		{
			_003CdetailsTexture_003Ek__BackingField = value;
		}
	}

	public HardBounds hardBounds
	{
		get
		{
			return _003ChardBounds_003Ek__BackingField;
		}
		set
		{
			_003ChardBounds_003Ek__BackingField = value;
		}
	}

	public Tileset()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v1+B8]");
		object obj2 = 0;
		_003CdetailsTexture_003Ek__BackingField = (string)obj2;
	}
}
