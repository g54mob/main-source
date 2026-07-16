using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public static UIManager Instance;

	[NonSerialized]
	[Header("Hotkey Tooltips")]
	private bool empty;

	[Header("Fade Screen")]
	[Header("Level Transition Fade Timings")]
	public float LevelStartFadeTime = 0.4f;

	public float LevelEndFadeTime = 2.3f;

	public float WorldStartFadeTime = 0.4f;

	[SerializeField]
	private Menu[] menusToInit;

	[Header("Colors")]
	[SerializeField]
	private ColorManager colorManager;

	private Gradient gradientGYR;

	public int radarLevel;

	private GameObject firstLoadPanelGO;

	[field: SerializeField]
	public HUD HUD { get; private set; }

	[field: SerializeField]
	public RadarHUD RadarHUD { get; private set; }

	[field: SerializeField]
	public BarControllerHull TrainHealthBar { get; private set; }

	[field: SerializeField]
	public BarController TrainDistanceBar { get; private set; }

	[field: SerializeField]
	public BarController CannonAmmoBar { get; private set; }

	[field: SerializeField]
	public MouseCursor MouseCursor { get; private set; }

	[field: SerializeField]
	public CrosshairCannon CannonCrosshair { get; private set; }

	[field: SerializeField]
	public Crosshair MortarCrosshair { get; private set; }

	[field: SerializeField]
	public Crosshair GatlingCrosshair { get; private set; }

	[field: SerializeField]
	public GameObject GatlingCrosshairFireIndicator { get; private set; }

	[field: SerializeField]
	public GameObject GatlingCrosshairFireIndicatorGamepad { get; private set; }

	[field: SerializeField]
	public TimerPanel TimerPanel { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI EndingText { get; private set; }

	[field: SerializeField]
	public TrackEventIndicator IndicatorUp { get; private set; }

	[field: SerializeField]
	public TrackEventIndicator IndicatorDown { get; private set; }

	[field: SerializeField]
	public TrackEventIndicator IndicatorAmmo { get; private set; }

	[field: SerializeField]
	public TrackEventIndicator IndicatorScrap { get; private set; }

	[field: SerializeField]
	public TrackEventIndicator IndicatorBoom { get; private set; }

	[field: SerializeField]
	public TrackEventIndicator IndicatorBoom2 { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI ScrapText { get; private set; }

	[field: SerializeField]
	public Button ShopButton { get; private set; }

	[field: SerializeField]
	public StatusManager StatusManager { get; private set; }

	[field: SerializeField]
	public GameObject HotkeyTooltipUpperPrefab { get; private set; }

	[field: SerializeField]
	public GameObject HotkeyTooltipLowerPrefab { get; private set; }

	[field: SerializeField]
	public Transform HotkeyCanvasTf { get; private set; }

	[field: SerializeField]
	public InputAssetsManager InputAssetsManager { get; private set; }

	[field: SerializeField]
	public DeflectIndicator DeflectIndicator { get; private set; }

	[field: SerializeField]
	public Counter ScrapCounter { get; private set; }

	[field: SerializeField]
	public SpeedDial SpeedDial { get; private set; }

	[field: SerializeField]
	public GameObject PPCanvasGo { get; private set; }

	[field: SerializeField]
	public RadarWindow RadarWindow { get; private set; }

	[field: SerializeField]
	public FloatingHealthChangeDisplay FloatingHealthChangeDisplay { get; private set; }

	[field: SerializeField]
	public ModuleHealthbarsDisplay ModuleHealthbarsDisplay { get; private set; }

	[field: SerializeField]
	public EnemyHealthbarsDisplay EnemyHealthbarsDisplay { get; private set; }

	[field: SerializeField]
	public GameObject JourneyOverwritePanel { get; private set; }

	[field: SerializeField]
	public RectTransform IndicatorsRt { get; private set; }

	[field: SerializeField]
	public CanvasGroup CGOverlay { get; private set; }

	[field: SerializeField]
	public CanvasGroup CGWorld { get; private set; }

	[field: SerializeField]
	public GameObject HUDOverview { get; private set; }

	[field: SerializeField]
	public GameObject FirstLoadPanel { get; private set; }

	[field: SerializeField]
	public SimpleFade FadeScreen { get; private set; }

	[field: SerializeField]
	public PopupUI MilestoneUnlockPopup { get; private set; }

	public bool WaveTimerUnlocked { get; set; }

	public Gradient GradientGYR
	{
		get
		{
			return gradientGYR;
		}
		set
		{
			gradientGYR = value;
		}
	}

	public Color ColorGreen => colorManager.ColorGreen;

	public Color ColorYellow => colorManager.ColorYellow;

	public Color ColorRed => colorManager.ColorRed;

	public Color HackedColor => colorManager.HackedOutlineColor;

	private void Awake()
	{
		Instance = this;
		GenerateGradient();
	}

	private void GenerateGradient()
	{
		GradientGYR = new Gradient();
		GradientColorKey[] colorKeys = new GradientColorKey[3]
		{
			new GradientColorKey(ColorRed, 0f),
			new GradientColorKey(ColorYellow, 0.5f),
			new GradientColorKey(ColorGreen, 1f)
		};
		GradientAlphaKey[] alphaKeys = new GradientAlphaKey[1]
		{
			new GradientAlphaKey(1f, 0f)
		};
		GradientGYR.SetKeys(colorKeys, alphaKeys);
	}

	public void StartFadeCanvasGroupOut(CanvasGroup canvasGroup)
	{
		LeanTween.alphaCanvas(canvasGroup, 0f, 1f);
	}

	public void StartFadeCanvasGroupIn(CanvasGroup canvasGroup)
	{
		LeanTween.alphaCanvas(canvasGroup, 1f, 1f);
	}

	public Color RarityColor(Rarity rarity)
	{
		return rarity switch
		{
			Rarity.Common => colorManager.RarityColors[0], 
			Rarity.Rare => colorManager.RarityColors[1], 
			Rarity.Epic => colorManager.RarityColors[2], 
			Rarity.Legendary => colorManager.RarityColors[3], 
			_ => colorManager.RarityColors[0], 
		};
	}

	public Color DarkerRarityColor(Rarity rarity)
	{
		return rarity switch
		{
			Rarity.Common => colorManager.DarkerRarityColors[0], 
			Rarity.Rare => colorManager.DarkerRarityColors[1], 
			Rarity.Epic => colorManager.DarkerRarityColors[2], 
			Rarity.Legendary => colorManager.DarkerRarityColors[3], 
			_ => colorManager.DarkerRarityColors[0], 
		};
	}

	public void ShowFirstLoadPanel()
	{
		if (FirstLoadPanel != null)
		{
			StartCoroutine(ShowFirstLoadPanelDelayed(1f));
		}
	}

	private IEnumerator ShowFirstLoadPanelDelayed(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		MenuManager.Instance.OpenMenu(MenuType.FirstLoadPanel);
	}

	public void HideFirstLoadPanel()
	{
		if (firstLoadPanelGO != null)
		{
			MenuManager.Instance.CloseCurrentMenu();
		}
	}
}
