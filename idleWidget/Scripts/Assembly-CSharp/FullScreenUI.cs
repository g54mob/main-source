using Assets.Source.Item;
using TMPro;
using UnityEngine;

public class FullScreenUI : MonoBehaviour
{
	[SerializeField]
	private UICraftedItem _insufficientItemPrefab;

	[SerializeField]
	private TMP_Text _warningPrefab;

	[field: SerializeField]
	public Canvas Canvas { get; private set; }

	[field: SerializeField]
	public Transform WorldComponent { get; private set; }

	[field: SerializeField]
	public Camera ActiveCamera { get; private set; }

	public Vector2 MouseWorld => ActiveCamera.ScreenToWorldPoint(PlayerControls.MousePosition);

	public bool FullScreenActive { get; private set; }

	public void SetFullScreenActive(bool active)
	{
		FullScreenActive = active;
	}

	public virtual void OnFullScreenActivate()
	{
	}

	public virtual void OnFullScreenDeactivate()
	{
	}

	public UICraftedItem ShowNeedItem(Transform parent, ItemType type, int count)
	{
		UICraftedItem uICraftedItem = Object.Instantiate(_insufficientItemPrefab, base.transform);
		uICraftedItem.SetItem(type, count);
		((RectTransform)uICraftedItem.transform).anchoredPosition = Camera.main.WorldToScreenPoint(parent.transform.position);
		return uICraftedItem;
	}

	public TMP_Text ShowWarning(Transform parent, string text)
	{
		TMP_Text tMP_Text = Object.Instantiate(_warningPrefab, base.transform);
		tMP_Text.text = text;
		tMP_Text.rectTransform.anchoredPosition = Camera.main.WorldToScreenPoint(parent.transform.position);
		return tMP_Text;
	}

	public virtual bool ProcessEscape()
	{
		return false;
	}
}
