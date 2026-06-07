using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TipManager : MonoBehaviour
{
	public static TipManager instance;

	public UnityEvent OnTipHeaderEnable;

	public UnityEvent OnTipHeaderDisable;

	public UnityEvent OnTipBodyEnable;

	public UnityEvent OnTipBodyDisable;

	public GameObject background;

	public UIParentResizer sizer;

	public TMP_Text headerText;

	public TMP_Text bodyText;

	private SettingsManager settings;

	private void Awake()
	{
		instance = this;
		headerText.text = "";
		bodyText.text = "";
	}

	private void Start()
	{
		settings = SettingsManager.Instance;
	}

	public void UpdateTipRaw(string _headerText, string _bodyText, bool isTutorial = false)
	{
		if (!settings)
		{
			settings = SettingsManager.Instance;
		}
		if (settings.DisableExtraTips && !isTutorial)
		{
			_headerText = "";
			_bodyText = "";
		}
		if (headerText.text != _headerText)
		{
			headerText.text = _headerText;
		}
		if (bodyText.text != _bodyText)
		{
			bodyText.text = _bodyText;
		}
		if ((bool)background)
		{
			if (headerText.text.Length > 0 || bodyText.text.Length > 0)
			{
				background.SetActive(value: true);
			}
			else
			{
				background.SetActive(value: false);
			}
		}
		sizer.Trigger();
	}

	public void UpdateTipLocalized(string _headerKey, string _bodyKey, bool isTutorial = false)
	{
		string text = TextTranslator.Translate(_headerKey);
		string text2 = TextTranslator.Translate(_bodyKey);
		UpdateTipRaw(text, text2, isTutorial);
	}
}
