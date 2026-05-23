using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ToggleButtonGroup : Button
	{
		public Sprite selectedSprite;

		public Sprite unSelectedSprite;

		public bool isDefaultSelect;

		public RectTransform content;

		public bool isLock;

		private bool isSelected;

		public bool IsSelected => false;

		private new void Start()
		{
		}

		public void ResetIdenticalLayerButtons()
		{
		}

		public void ChangeDefaultSprite()
		{
		}

		public void ChangeSelectedSprite()
		{
		}

		public void OnClickAction()
		{
		}
	}
}
