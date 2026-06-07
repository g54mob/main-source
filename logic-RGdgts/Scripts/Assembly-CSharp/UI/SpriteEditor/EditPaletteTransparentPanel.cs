using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.SpriteEditor
{
	public class EditPaletteTransparentPanel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		private Action<bool> onMouseDown;

		public void Init(Action<bool> onMouseDown)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}
	}
}
