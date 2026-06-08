using System.Collections.Generic;
using Rhizomatic.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GRP
{
	public class GuideRow : MonoBehaviour
	{
		public Transform content;

		public CanvasGroup canvasGroup;

		public LayoutElement layoutElement;

		public TextAdapter text;

		public Image background;

		public GuideRowConfig config;

		private List<Image> images;

		private bool isShow;

		private float startTime;

		private bool isActive;

		private float activeValue;

		public void Create()
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		private void LateUpdate()
		{
		}

		public void UpdateData(GuideData data)
		{
		}

		public void Setup(GuideData data)
		{
		}
	}
}
