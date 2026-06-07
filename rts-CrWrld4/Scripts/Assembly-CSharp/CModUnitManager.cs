using System;
using System.Collections.Generic;
using NBT.Tags;
using QuickOutline;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class CModUnitManager : UnitManager
{
	private List<RplCore> rplCores;

	private TargetIndicator specifiedTargetIndicator;

	private int showingPathCount;

	private int[] uiState;

	private string[] uiText;

	private List<string>[] uiOptions;

	private bool _createsMVerseGhost;

	[NonSerialized]
	public Dictionary<string, CMod.CModObjInstance> objInstanceTable;

	[NonSerialized]
	public bool CAN_SPECIFY_TARGET;

	private bool _SPECIFIED_TARGET_SHOW_PATH;

	public float _SPECIFIED_TARGET_PATH_HEIGHT;

	public Vector3 _SPECIFIED_TARGET_PATH_SOURCE_OFFSET;

	public bool _SPECIFIED_TARGET_OCCUPIES_MAP;

	private Vector2 _specifiedTarget;

	private string miniMapImageData;

	private Texture2D _miniMapImage;

	private Color _miniMapImageColor;

	private string _miniMapInfoText;

	private int _miniMapTimeToEvent;

	private static Color transColor;

	private MouseOverPane mop;

	private string popupTextManual0;

	private string popupTextManual1;

	private int popupEnabledManual;

	private Outline outline;

	private bool localDead;

	public bool createsMVerseGhost
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private int MYRANGE => 0;

	public bool SPECIFIED_TARGET_SHOW_PATH
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float SPECIFIED_TARGET_PATH_HEIGHT
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public Vector3 SPECIFIED_TARGET_PATH_SOURCE_OFFSET
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public bool SPECIFIED_TARGET_OCCUPIES_MAP
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Vector2 specifiedTarget
	{
		get
		{
			return default(Vector2);
		}
		set
		{
		}
	}

	public Texture2D MiniMapImage
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Color MiniMapImageColor
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public string MiniMapInfoText
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int MiniMapTimeToEvent
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override string officialName => null;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void SetUnitSettings(OrderedDictionary2<string, RplCore.Data> initParams)
	{
	}

	public override OrderedDictionary2<string, RplCore.Data> GetUnitSettings()
	{
		return null;
	}

	public override void SetUnitConstants(string unit)
	{
	}

	public override bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
	}

	public void SetMiniMipImage(string data)
	{
	}

	private char GetStringBit(string data, int x, int y)
	{
		return '\0';
	}

	public void PreGameUpdateScripts()
	{
	}

	protected override void SetUnitMaterial()
	{
	}

	public int GetUIState(int slot)
	{
		return 0;
	}

	public void SetUIState(int slot, int val)
	{
	}

	public string GetUIText(int slot)
	{
		return null;
	}

	public void SetUIText(int slot, string val)
	{
	}

	public void SetUIOptions(int slot, List<string> val)
	{
	}

	public List<string> GetUIOptions(int slot)
	{
		return null;
	}

	public CMod.CModObjInstance GetObjInstance(string name)
	{
		return null;
	}

	private void RefreshObjTable()
	{
	}

	public RplCore AddCrplCore(string scriptName, bool dontCompile = false)
	{
		return null;
	}

	public List<RplCore> GetRplCores()
	{
		return null;
	}

	public int GetRplCoreIndex(RplCore core)
	{
		return 0;
	}

	public RplCore GetRplCore(int index)
	{
		return null;
	}

	public RplCore GetRplCore(string scriptName)
	{
		return null;
	}

	public void CompileCores()
	{
	}

	public override void BuildComplete()
	{
	}

	public void InvokeCoreEvent(string eventName, RplCore.Data data)
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	public void ShowSpecifiedTargetIndicatorPath()
	{
	}

	public override void IndicateTarget(TargetIndicator ti)
	{
	}

	public override TargetIndicator CreateTargetIndicator()
	{
		return null;
	}

	public static void AddToCModUnits(CModUnitManager cmum)
	{
	}

	public static void RemoveFromCModUnits(CModUnitManager cmum)
	{
	}

	public static HashSet<UnitManager> GetCModUnitsOfType(string cmodType)
	{
		return null;
	}

	public void SetPopupEnabled(bool enabled, bool persist = false)
	{
	}

	public void SetPopupText0(string text, bool persist = false)
	{
	}

	public void SetPopupText1(string text, bool persist = false)
	{
	}

	public static UnitManager FindNearestSpore(Vector3 worldPosition, float RNG, bool factorAssignedMissiles)
	{
		return null;
	}

	public static UnitManager FindNearestAirSac(Vector3 worldPosition, float RNG, bool factorAssignedMissiles)
	{
		return null;
	}

	public void FindEnemy(bool deepest, int firePriority, out int chosenX, out int chosenY)
	{
		chosenX = default(int);
		chosenY = default(int);
	}

	private void FindNearestEnemies(int cellX, int cellY, out int nearest_creeperX, out int nearest_creeperY, out int nearest_vineX, out int nearest_vineY, out float nearest_creeperDist, out float nearest_vineDist)
	{
		nearest_creeperX = default(int);
		nearest_creeperY = default(int);
		nearest_vineX = default(int);
		nearest_vineY = default(int);
		nearest_creeperDist = default(float);
		nearest_vineDist = default(float);
	}

	private void FindDeepestCreeper(int cellX, int cellY, int firePriority, out int chosenX, out int chosenY)
	{
		chosenX = default(int);
		chosenY = default(int);
	}

	public override void RefreshLOSCache()
	{
	}

	public void SetOutlineEnabled(bool val)
	{
	}

	public void SetOutlineWidth(float w)
	{
	}

	public void SetOutlineColor(Color c)
	{
	}

	public void SetOutlineMode(bool all)
	{
	}

	private void CreateOutline()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}

	private TagCompound WriteNullStringArray(string[] data)
	{
		return null;
	}

	private List<string>[] ReadOptions(TagCompound data)
	{
		return null;
	}

	private TagCompound WriteOptions(List<string>[] options)
	{
		return null;
	}
}
