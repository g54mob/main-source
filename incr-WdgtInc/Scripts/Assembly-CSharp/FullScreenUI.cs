using System.Numerics;
using Assets.Behaviour.UI;
using Assets.Source.Item;
using TMPro;
using UnityEngine;

public class FullScreenUI : MonoBehaviour
{
	[SerializeField]
	private UICraftedItem _insufficientItemPrefab;

	[SerializeField]
	private TMP_Text _warningPrefab;

	[SerializeField]
	private UICraftedItem _itemTextPrefab;

	[field: SerializeField]
	public Canvas Canvas { get; private set; }

	[field: SerializeField]
	public Transform WorldComponent { get; private set; }

	[field: SerializeField]
	public Camera ActiveCamera { get; private set; }

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

	public UICraftedItem ShowNeedItem(Transform parent, ItemType type, BigInteger count)
	{
		UICraftedItem uICraftedItem = Object.Instantiate(_insufficientItemPrefab, base.transform);
		uICraftedItem.SetItem(type, count);
		UnityEngine.Vector2 anchoredPosition = ((!(parent is RectTransform rectTransform)) ? ((UnityEngine.Vector2)Camera.main.WorldToScreenPoint(parent.position)) : ((UnityEngine.Vector2)rectTransform.position));
		((RectTransform)uICraftedItem.transform).anchoredPosition = anchoredPosition;
		return uICraftedItem;
	}

	public TMP_Text ShowWarning(Transform parent, string text)
	{
		TMP_Text tMP_Text = Object.Instantiate(_warningPrefab, base.transform);
		tMP_Text.TL(text);
		UnityEngine.Vector2 anchoredPosition = ((!(parent is RectTransform rectTransform)) ? ((UnityEngine.Vector2)Camera.main.WorldToScreenPoint(parent.position)) : ((UnityEngine.Vector2)rectTransform.position));
		tMP_Text.rectTransform.anchoredPosition = anchoredPosition;
		return tMP_Text;
	}

	public UICraftedItem ShowItemCrafted(Transform parent, ItemType type, BigInteger count, float offset = 0f)
	{
		UICraftedItem uICraftedItem = Object.Instantiate(_itemTextPrefab, base.transform);
		uICraftedItem.SetItem(type, count);
		if (type == ItemType.GlitchedWidget)
		{
			uICraftedItem.gameObject.AddComponent<GlitchedIcon>().SetWidget(v: true);
		}
		UnityEngine.Vector2 anchoredPosition = ((!(parent is RectTransform rectTransform)) ? ((UnityEngine.Vector2)(Camera.main.WorldToScreenPoint(parent.position) + new UnityEngine.Vector3(0f, offset))) : ((UnityEngine.Vector2)rectTransform.position));
		((RectTransform)uICraftedItem.transform).anchoredPosition = anchoredPosition;
		return uICraftedItem;
	}

	public virtual bool ProcessEscape()
	{
		return false;
	}
}
