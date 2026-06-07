using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Elements
{
	public class UIPathButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		[NonSerialized]
		[HideInInspector]
		public string folderPath;

		public string buttonName;

		[NonSerialized]
		[HideInInspector]
		public Action singleClick;

		[NonSerialized]
		[HideInInspector]
		public Action doubleClick;

		private bool one_click;

		private float dclick_threshold;

		private float sclick_threshold;

		private double timerdclick;

		public void Init(string path, string name = null)
		{
		}

		private IEnumerator SingleClickCo()
		{
			return null;
		}

		private void WaitDoubleClick()
		{
		}

		public void SetActive(bool active)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}
	}
}
