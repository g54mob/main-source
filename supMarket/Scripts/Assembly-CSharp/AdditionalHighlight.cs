using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AdditionalHighlight : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	[SerializeField]
	private List<Graphic> m_Graphics;

	public void OnSelect(BaseEventData eventData)
	{
	}

	public void Select()
	{
	}

	public void Deselect()
	{
	}
}
