using System;
using LeanTween.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIScripts
{
	public class TabsButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
	{
		[NonSerialized]
		public int index;

		public float initialY;

		public float verticalTravelOnSelection;

		[NonSerialized]
		public TabsManager manager;

		public GameObject image;

		private bool selected;

		public void Select()
		{
			if (!(manager == null))
			{
				image.transform.localPosition = new Vector3(0f, initialY + verticalTravelOnSelection, 0f);
				manager.OpenPanel(index);
				selected = true;
			}
		}

		public void Reset()
		{
			selected = false;
			LeanTween.Framework.LeanTween.moveLocalY(image, initialY, 0.25f).setEaseInOutQuad().setIgnoreTimeScale(useUnScaledTime: true);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!selected)
			{
				LeanTween.Framework.LeanTween.moveLocalY(image, initialY + verticalTravelOnSelection, 0.25f).setEaseInOutQuad().setIgnoreTimeScale(useUnScaledTime: true);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (!selected)
			{
				LeanTween.Framework.LeanTween.moveLocalY(image, initialY, 0.25f).setEaseInOutQuad().setIgnoreTimeScale(useUnScaledTime: true);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!selected)
			{
				Select();
			}
		}
	}
}
