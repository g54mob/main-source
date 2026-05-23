using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class CollectionResearchListElement : CollectionListElement
	{
		[SerializeField]
		private Image masterIcon;

		[SerializeField]
		private Sprite secretIcon;

		[SerializeField]
		private List<RectTransform> resizeObjectList;

		[SerializeField]
		private Canvas guideCanvas;

		private Sprite baseSprite;

		public void SetMasterIcon(eWriterId writer)
		{
		}

		public override void InitComponent(ChoiceMenuButtonInitBase init)
		{
		}

		public void SetActive(bool active)
		{
		}

		public new void SetSecret(bool isSecret)
		{
		}
	}
}
