using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIPopupContentReferences
	{
		public List<UIButton> Buttons;

		public List<Image> Images;

		public List<GameObject> Labels;

		public int ButtonsCount => 0;

		public bool HasButtons => false;

		public bool HasImages => false;

		public bool HasLabels => false;

		public int ImagesCount => 0;

		public int LabelsCount => 0;

		public void SetButtonsCallbacks(params UnityAction[] callbacks)
		{
		}

		public void SetButtonsLabels(params string[] buttonLabels)
		{
		}

		public void SetButtonsNames(params string[] buttonNames)
		{
		}

		public void SetContentData(UIPopupContentData data)
		{
		}

		public void SetImagesSprites(params Sprite[] sprites)
		{
		}

		public void SetLabelsTexts(params string[] labels)
		{
		}
	}
}
