using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
	public string unitName;

	public GameObject infoContainer;

	public GameObject selectedImage;

	public TextMeshProUGUI supplyTextTitle;

	public TextMeshProUGUI supplyText;

	public TextMeshProUGUI limitTextTitle;

	public TextMeshProUGUI limitText;

	public GameObject buildLimitGO;

	public TextMeshProUGUI buildLimitText;

	public TextMeshProUGUI ammoTitle;

	public RawImage wareImage;

	public TextMeshProUGUI costText;

	public RawImage ammoWareImage;

	public GameObject unitMesh;

	public Text buttonText;

	public Text amtText;

	public GameObject lockImage;

	private bool _selected;

	private int _ammoWareType;

	private int _wareType;

	private int _cost;

	private string _unit;

	private int lastAvail;

	public bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int ammoWareType
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int wareType
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int cost
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public string unit
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public static string GetUnitAlias(string unit)
	{
		return null;
	}

	public void Update()
	{
	}

	private void Awake()
	{
	}

	public bool CanBuild()
	{
		return false;
	}

	private void Start()
	{
	}

	public void OnClick()
	{
	}

	public bool IsBuildUnitEnabled()
	{
		return false;
	}

	public void OnPointerEnter(BaseEventData ped)
	{
	}

	public void OnPointerExit(BaseEventData ped)
	{
	}

	public void OnPointerClick(BaseEventData ped)
	{
	}

	private void ShowInfo(bool show)
	{
	}
}
