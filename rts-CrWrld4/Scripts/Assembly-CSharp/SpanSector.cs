using TMPro;
using UnityEngine;

public class SpanSector : MonoBehaviour
{
	public const int WIDTH = 15;

	public const int HEIGHT = 6;

	public GameObject tilePrefab;

	public GalaxyMissionPanel gmp;

	public GameSpace.CATEGORY category;

	public Sprite[] backgrounds;

	public GameObject[] containers;

	public TextMeshProUGUI pageTitle;

	public TextMeshProUGUI itemCountText;

	public TextMeshProUGUI pageItemCountText;

	private int itemCount;

	private int[] pageItemCounts;

	private SpanTile[] spanTiles0;

	private SpanTile[] spanTiles1;

	private SpanTile[] spanTiles2;

	private int _selectedTile;

	public static int MAXPAGE;

	private int _page;

	public int selectedTile
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int page
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	private void InitContainer(int container, int page)
	{
	}

	public void OnLeft(int amt)
	{
	}

	public void OnRight(int amt)
	{
	}

	public string GetLoc()
	{
		return null;
	}

	public static string GetLoc(int x, int y, int page)
	{
		return null;
	}

	public static void FromLoc(string loc, out int x, out int y, out int page)
	{
		x = default(int);
		y = default(int);
		page = default(int);
	}

	public static string GetGUID(int x, int y, int page)
	{
		return null;
	}

	public static string GetGUID(int selectedTile, int page)
	{
		return null;
	}

	public static int GetSingleCoord(int x, int y, int page)
	{
		return 0;
	}

	private void SetMission(int selectedTile, int page)
	{
	}

	public static uint Hash(uint a)
	{
		return 0u;
	}
}
