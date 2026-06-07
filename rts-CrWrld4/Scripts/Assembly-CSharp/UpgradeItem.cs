using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
	public ERNInterfacePane upgradePane;

	public int upgradeType;

	public Image enrouteLight;

	public Image dockedLight;

	public Text descriptionText;

	public Image background;

	public Button releaseButton;

	public GameObject efficiencyPanel;

	public Text efficiencyTitleText;

	public Text efficiencyText;

	public Image efficiencyBar;

	public Color backgroundColor;

	public Color overBackgroundColor;

	public GameObject lockCover;

	private int lastAmpGems;

	public bool unlockNotEfficiency;

	private bool _locked;

	private static Color costColorNoPurchase;

	private static Color costColorCanPurchase;

	private static Color costColorOwned;

	public bool locked
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public void Start()
	{
	}

	public void Update()
	{
	}

	public void Refresh()
	{
	}

	public void ReleaseButtonClicked()
	{
	}

	public bool CanPurchase()
	{
		return false;
	}

	public void OnHelpClicked()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}
}
