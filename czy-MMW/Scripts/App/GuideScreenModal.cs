using Client;
using UnityEngine;
using UnityEngine.UI;

public class GuideScreenModal : MonoBehaviour, IThemeComponent
{
	private CanvasGroup _canvas;

	private RectTransform _rect;

	[SerializeField]
	private TouchOptionButton _screens;

	private int _selectedButtonDotIndex;

	public Image[] visualiserDots;

	private void OnEnable()
	{
		Reset();
	}

	private void Reset()
	{
		SetOption(0);
		_screens.SetOption(0, invokeMethod: false);
		_canvas.alpha = 1f;
		_canvas.blocksRaycasts = true;
		_canvas.interactable = true;
	}

	protected void Awake()
	{
		_canvas = GetComponent<CanvasGroup>();
		_rect = GetComponent<RectTransform>();
	}

	protected void Start()
	{
		Reset();
	}

	private void Hide()
	{
		_canvas.alpha = 0f;
		_canvas.blocksRaycasts = false;
		_canvas.interactable = false;
	}

	public void SetOption(int index)
	{
		_selectedButtonDotIndex = index;
		UpdateColors();
	}

	private void UpdateColors()
	{
		Diagnostics.Verify(_selectedButtonDotIndex < visualiserDots.Length, "You don't have enough visualiser dots set up! Required {0} but have {1}. Add more dot prefabs to {3}", _selectedButtonDotIndex, visualiserDots.Length, base.name);
	}

	public void InitializeTheme(IThemeDatabase themeDatabase)
	{
	}

	public void ApplyTheme(ITheme newTheme)
	{
	}

	public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
	{
		return ThemeBlendingResult.StopBlending;
	}

	public void ReleaseTheme(IThemeDatabase themeDatabase)
	{
	}
}
