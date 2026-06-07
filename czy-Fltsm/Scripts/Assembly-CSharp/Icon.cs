using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Icon : UIBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
	[SerializeField]
	private Image _targetImage;

	private IIconProvider _iconProvider;

	public void OnPointerEnter(PointerEventData data)
	{
		_iconProvider?.ShowTooltip(base.gameObject);
	}

	public void OnPointerExit(PointerEventData data)
	{
		_iconProvider?.HideTooltip();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		_iconProvider?.ShowTooltip(base.gameObject, delayed: false);
	}

	public void Initialize(IIconProvider iconProvider, bool forceActive = false)
	{
		if (iconProvider == null)
		{
			Debug.LogWarning("Icon could not be initialized, IIconProvider == null!");
			return;
		}
		_iconProvider = iconProvider;
		if ((bool)_targetImage)
		{
			_targetImage.sprite = iconProvider.GetIcon();
		}
		if (forceActive)
		{
			base.gameObject.SetActive(value: true);
		}
	}
}
