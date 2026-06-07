using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.SpriteEditor
{
	public class ImagePixelSelection : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[HideInInspector]
		public Vector2 relativeCoords;

		[HideInInspector]
		public Vector2 currentCell;

		[HideInInspector]
		public Vector2 startingCoords;

		[HideInInspector]
		public Vector2 startingCoordsRight;

		[HideInInspector]
		public MouseButtons mouseButton;

		private Coroutine checkMouseUpCo;

		public Action OnMouseDown;

		public Action OnMouseDownRight;

		public Action OnMouseMove;

		public Action OnMouseMoveLeft;

		public Action OnMouseMoveRight;

		public Action OnMouseUp;

		public Action OnMouseUpRight;

		public Action OnMouseExit;

		public Action OnMouseEnter;

		public Action OnDeleteButtonDown;

		public Action OnCut;

		public Action OnCopy;

		public Action OnPaste;

		private bool mouseOnImage;

		public void Init()
		{
		}

		private void Update()
		{
		}

		public Vector2 GetTransformRelativeCoords(Vector2 clickPosition)
		{
			return default(Vector2);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void StopCoroutines()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void PointerMove()
		{
		}

		private void PointerUp()
		{
		}

		private IEnumerator CheckMouseUpCO()
		{
			return null;
		}

		private void ResetOnPointerUp()
		{
		}
	}
}
