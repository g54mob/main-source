using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class KeyRow : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Serializable]
	public class OnButtonClicked : UnityEvent<int, KeyRow>
	{
	}

	public Text titleText;

	public Text primaryText;

	public Text secondaryText;

	public Text subtextText;

	public OnButtonClicked onButtonClicked;

	[NonSerialized]
	public string uid;

	public string title
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string primary
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string secondary
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string subtext
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void OnPrimaryClicked()
	{
	}

	public void OnSecondaryClicked()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
