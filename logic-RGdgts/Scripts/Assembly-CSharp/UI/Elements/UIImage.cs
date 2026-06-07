using System;
using Document;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
	public class UIImage : MonoBehaviour
	{
		[NonSerialized]
		[HideInInspector]
		public Image image;

		private UIColorMapperController colorController;

		public void Init()
		{
		}

		public void SetColor(UIColorStates color)
		{
		}

		public DocumentElementsColor GetElementColor()
		{
			return null;
		}

		public void SetColorEntity(DocumentElementsColor elementColor)
		{
		}
	}
}
