using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Elements
{
	public class UIPaletteButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		private Button button;

		public Action OnPixelSelected;

		public Action OnPixelSelectedRight;

		public void Init(Action onPixelSelected, Action onPixelSelectedRight = null)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}
	}
}
