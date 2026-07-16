using MLCN_Localization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonField : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	[Header("General")]
	[SerializeField]
	public string label = "New Button";

	[SerializeField]
	public UILabelFieldProperties labelFieldProperties;

	[SerializeField]
	private bool useIcon = true;

	[SerializeField]
	private Sprite defaultIcon;

	[SerializeField]
	private float iconRotation;

	[Header("Localization")]
	[SerializeField]
	public bool useLocalization;

	[SerializeField]
	public string localizationKey = string.Empty;

	[SerializeField]
	public LocalizationDataTable.Tables localizationTable = LocalizationDataTable.Tables.UI;

	[Header("Button Setup")]
	[SerializeField]
	private Image visualAreaBorder;

	[SerializeField]
	private Image visualArea;

	[SerializeField]
	private bool animateBorder;

	[SerializeField]
	private UIFieldProperties normal;

	[SerializeField]
	private UIFieldProperties hover;

	[SerializeField]
	private UIFieldProperties pressed;

	[SerializeField]
	private UIFieldProperties select;

	[SerializeField]
	private bool isSelectable;

	[SerializeField]
	private bool loopHover;

	[SerializeField]
	private float fadeTime = 1f;

	[SerializeField]
	private AnimationCurve fadeCurve = new AnimationCurve();

	[SerializeField]
	private UnityEvent OnClick;

	[SerializeField]
	private UnityEvent OnHoverEnter;

	[SerializeField]
	private UnityEvent OnHoverExit;

	[SerializeField]
	private bool useIconTransform;

	[SerializeField]
	private Image iconArea;

	[SerializeField]
	private TMP_Text labelName;

	private int uid = -1;

	public int buttonId = -1;

	private bool isHovering;

	private bool isSelected;

	private bool disabled;

	private RectTransform rectTransform;

	private void Awake()
	{
		rectTransform = (useIconTransform ? iconArea.rectTransform : GetComponent<RectTransform>());
		LocaleStringEvent componentInChildren = GetComponentInChildren<LocaleStringEvent>();
		if (componentInChildren != null)
		{
			componentInChildren.SetNewTable(localizationTable);
			componentInChildren.SetNewKey(localizationKey);
			componentInChildren.TryUpdate();
		}
	}

	public void SetupIconButton(int index, string _name, Sprite sprite, UnityAction action, bool updateDefaultIcon = false)
	{
		buttonId = index;
		label = _name;
		if (useLocalization && localizationKey != string.Empty)
		{
			labelName.text = LocalizationManager.GetLocalizedString(localizationKey, localizationTable, label);
			LocalizationManager.OnLanguageChange.AddListener(delegate(int language)
			{
				UpdateLocalizedLabel(language);
			});
		}
		else if (!useLocalization)
		{
			labelName.text = _name;
		}
		if (updateDefaultIcon)
		{
			defaultIcon = sprite;
		}
		iconArea.sprite = sprite;
		if (action != null)
		{
			OnClick.AddListener(action);
		}
	}

	public void UpdateLocalizedLabel(int language)
	{
		labelName.text = LocalizationManager.GetLocalizedString(localizationKey, localizationTable, language, label);
	}

	public void Disable()
	{
		disabled = true;
	}

	public void Enable()
	{
		base.enabled = true;
	}

	private bool IsDisabled()
	{
		if (!disabled)
		{
			return false;
		}
		SoundManager.PlaySoundOnce(normal.sound);
		return true;
	}

	public void SubscribeToOnClick(UnityAction action)
	{
		OnClick.AddListener(action);
	}

	public void UnsubscribeToOnClick(UnityAction action)
	{
		OnClick.RemoveListener(action);
	}

	public void UnsubscribeAllClickEvents()
	{
		OnClick.RemoveAllListeners();
	}

	public void ChangeIcon(Sprite sprite)
	{
		if (useIcon)
		{
			defaultIcon = sprite;
			iconArea.sprite = sprite;
		}
	}

	public void Select()
	{
		StopAllCoroutines();
		isSelected = true;
		if (visualArea != null)
		{
			visualArea.color = select.color;
		}
		if (visualAreaBorder != null)
		{
			visualAreaBorder.color = select.borderColor;
		}
		if (iconArea != null)
		{
			iconArea.color = select.iconColor;
		}
		if (labelName != null)
		{
			labelName.color = select.labelColor;
		}
	}

	public void Deselect()
	{
		StopAllCoroutines();
		isSelected = false;
		if (visualArea != null)
		{
			visualArea.color = normal.color;
		}
		if (visualAreaBorder != null)
		{
			visualAreaBorder.color = normal.borderColor;
		}
		if (iconArea != null)
		{
			iconArea.color = normal.iconColor;
		}
		if (labelName != null)
		{
			labelName.color = normal.labelColor;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!IsDisabled())
		{
			OnClick.Invoke();
			SoundManager.PlaySoundOnce(normal.sound);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		TweenerManager.TweenUI(uid.ToString(), pressed, rectTransform, visualArea, fadeCurve, fadeTime, animateBorder ? visualAreaBorder : null, labelFieldProperties, iconArea, isSelectable, isSelected, select);
		if (!IsDisabled())
		{
			SoundManager.PlaySoundOnce(pressed.sound);
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		TweenerManager.TweenUI(uid.ToString(), isHovering ? hover : normal, rectTransform, visualArea, fadeCurve, fadeTime, animateBorder ? visualAreaBorder : null, labelFieldProperties, iconArea, isSelectable, isSelected, select);
		IsDisabled();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (loopHover)
		{
			TweenerManager.TweenUIPingPong(uid.ToString(), hover, rectTransform, visualArea, fadeCurve, fadeTime, animateBorder ? visualAreaBorder : null, labelFieldProperties, iconArea);
		}
		else
		{
			TweenerManager.TweenUI(uid.ToString(), hover, rectTransform, visualArea, fadeCurve, fadeTime, animateBorder ? visualAreaBorder : null, labelFieldProperties, iconArea, isSelectable, isSelected, select);
		}
		OnHoverEnter.Invoke();
		isHovering = true;
		SoundManager.PlaySoundOnce(hover.sound);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		TweenerManager.TweenUI(uid.ToString(), normal, rectTransform, visualArea, fadeCurve, fadeTime, animateBorder ? visualAreaBorder : null, labelFieldProperties, iconArea, isSelectable, isSelected, select);
		OnHoverExit.Invoke();
		isHovering = false;
	}
}
