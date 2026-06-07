using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class MiniMap : MonoBehaviour
{
	public GameObject miniMapUnitPrefab;

	public GameObject miniMapMLDiskPrefab;

	public Transform diskContainer;

	public Transform unitContainer;

	public RectTransform container;

	public RawImage mapImage;

	private Texture2D tex;

	private NativeArray<Color32> data;

	public float R;

	public Texture2D sporeLauncherIcon;

	public Texture2D blobNestIcon;

	public Texture2D skimmerFactoryIcon;

	public Texture2D airSacCauldronIcon;

	public Texture2D airSacIcon;

	public Texture2D denierIcon;

	public Texture2D emitterIcon;

	public Texture2D totemIcon;

	public Texture2D energyIcon;

	public Texture2D ernIcon;

	public Texture2D infoCacheIcon;

	public Texture2D bluiteIcon;

	public Texture2D redonIcon;

	public Texture2D greenarIcon;

	public Texture2D anticreeperIcon;

	public Texture2D argIcon;

	public Texture2D lifticIcon;

	public Texture2D oreBluiteIcon;

	public Texture2D oreRedonIcon;

	public Texture2D oreGreenarIcon;

	public Texture2D surviveBaseIcon;

	public Texture2D unknownIcon;

	public TextMeshProUGUI scaleText;

	public TextMeshProUGUI timeText;

	public Image backgroundImage;

	public UILineRenderer trapezoid;

	public GameObject infoPane;

	public TextMeshProUGUI infoPaneTitle;

	public TextMeshProUGUI infoPaneInfo;

	public RectTransform camIcon;

	public RectTransform resetCamButton;

	public RectTransform topViewButton;

	public RectTransform sizeButtons;

	private Dictionary<int, MiniMapUnit> units;

	private Color32 backgroundColor;

	private static Color32 black;

	private static Color32 gray;

	private static Color32 blue;

	private static Color32 purple;

	private static Color32 brown;

	private static Color32 brightblue;

	private static Color32 red;

	private static Color32 orange;

	private static Color32 yellow;

	private static Color32 green;

	private static Color32 cyan;

	private static Color32 pink;

	private static Color32 white;

	private static Color32[] browns;

	private Dictionary<MissileLauncher, MiniMapMLDisk> disks;

	private Dictionary<MoveTarget, MiniMapMLDisk> disksMT;

	private MiniMapMLDisk activeDisk;

	private Vector3[] tpoints;

	private List<Vector2> trapezoidPoints;

	public void Start()
	{
	}

	public void LateUpdate()
	{
	}

	private void UpdateInfo(UnitManager unit)
	{
	}

	public void OnResizeSmall(bool persist = true)
	{
	}

	public void OnResizeMedium(bool persist = true)
	{
	}

	public void OnResizeLarge(bool persist = true)
	{
	}

	public void OnResize()
	{
	}

	public void RefreshMap()
	{
	}

	public static NativeArray<Color32> RefreshMap(Texture2D tex, int gsw, int gsh, byte[] terrain = null, int[] creeper = null)
	{
		return default(NativeArray<Color32>);
	}

	private static void DrawDisk(NativeArray<Color32> data, int r, int cellX, int cellY, int gsw, int gsh, Color32 color, float colorBlend)
	{
	}

	public MiniMapMLDisk CreateMiniMapMLDisk(MissileLauncher ml)
	{
		return null;
	}

	public MiniMapMLDisk CreateMiniMapMLDiskMT(MoveTarget mt)
	{
		return null;
	}

	public void DestroyMiniMapMLDisk(MissileLauncher ml)
	{
	}

	public void DestroyMiniMapMLDiskMT(MoveTarget mt)
	{
	}

	private void RefreshMLDisks()
	{
	}

	private Vector2 GetMapForScreenPointSimple(Vector3 pos, int height)
	{
		return default(Vector2);
	}

	private Vector2 GetMapForScreenPoint(Vector3 pos)
	{
		return default(Vector2);
	}

	private Vector2 ConvertMapToMiniMapPos(Vector2 mapPos)
	{
		return default(Vector2);
	}

	private void RefreshTrapezoid()
	{
	}

	private bool IsChanged(int x, int y)
	{
		return false;
	}

	public void UpdateUnit(UnitManager unit, int timeToEvent)
	{
	}

	private void SetColor(UnitManager unit, MiniMapUnit mmu)
	{
	}

	private void SetImage(UnitManager unit, MiniMapUnit mmu)
	{
	}

	public void DestroyUnit(UnitManager unit)
	{
	}
}
