using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class RadarTooltip : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI PriceText;

	private RectTransform rt;

	[SerializeField]
	private Vector2 gamepadPosition;

	private EnhancementRadar currentEnhancement;

	private bool isOnMouse = true;

	private Vector2 lastMousePosition;

	private Vector2 baseMousePosition = new Vector2(406f, 409f);

	public TextMeshProUGUI Description { get; private set; }

	public void Init()
	{
		Description = GetComponentInChildren<TextMeshProUGUI>();
		rt = GetComponent<RectTransform>();
		SetIsTooltipOnMouse(isToMouse: true);
	}

	private void Update()
	{
		if (isOnMouse)
		{
			rt.position = MouseCursor.Instance.GetMousePos();
			return;
		}
		rt.localPosition = gamepadPosition;
		if (Vector2.Distance(MouseCursor.Instance.GetMousePos(), baseMousePosition) > 10f)
		{
			Debug.Log("distance on mouse, setting to mouse");
			SetIsTooltipOnMouse(isToMouse: true);
		}
	}

	public void SetUpgrade(EnhancementRadar en)
	{
		currentEnhancement = en;
		en.NameKey.StringChanged -= OnNameOrDescriptionChanged;
		en.DescriptionKey.StringChanged -= OnNameOrDescriptionChanged;
		en.NameKey.StringChanged += OnNameOrDescriptionChanged;
		en.DescriptionKey.StringChanged += OnNameOrDescriptionChanged;
		UpdateDescriptionText();
		string text = $"{en.CoresCost}";
		string localizedString = new LocalizedString("LocalizationTable", "Price: ").GetLocalizedString();
		PriceText.text = localizedString + text;
		(base.transform as RectTransform).pivot = new Vector2(0f, 0f);
	}

	private void OnNameOrDescriptionChanged(string _)
	{
		UpdateDescriptionText();
	}

	private void UpdateDescriptionText()
	{
		if (!(currentEnhancement == null))
		{
			string localizedString = currentEnhancement.NameKey.GetLocalizedString();
			string localizedString2 = currentEnhancement.DescriptionKey.GetLocalizedString();
			string text = localizedString + "\n" + localizedString2;
			if (currentEnhancement.IsToggleable)
			{
				text += "\n[Toggleable]";
			}
			Description.text = text;
		}
	}

	public bool GetIsOnMouse()
	{
		return isOnMouse;
	}

	public void SetIsTooltipOnMouse(bool isToMouse)
	{
		if (isToMouse != isOnMouse)
		{
			if (!isToMouse)
			{
				lastMousePosition = MouseCursor.Instance.GetMousePos();
				MouseCursor.Instance.SetMousePos(baseMousePosition);
				Debug.Log(MouseCursor.Instance.GetMousePos());
				MouseCursor.Instance.HideCursor();
			}
			else
			{
				MouseCursor.Instance.SetMousePos(lastMousePosition);
				MouseCursor.Instance.ShowCursor();
			}
			isOnMouse = isToMouse;
		}
	}
}
