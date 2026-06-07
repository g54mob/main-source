using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
	public class ReorderableItem : MonoBehaviour
	{
		public Button upButton;

		public Button downButton;

		private Transform self;

		private Transform parent;

		private bool hasInit;

		private void Awake()
		{
			if (!hasInit)
			{
				Init();
			}
		}

		public void Init()
		{
			self = base.transform;
			parent = self.parent;
			hasInit = true;
		}

		public void MoveUp()
		{
			int num = self.GetSiblingIndex() - 1;
			if (num >= 0)
			{
				self.SetSiblingIndex(num);
			}
			if (num == 0)
			{
				upButton.enabled = false;
			}
			downButton.enabled = true;
		}

		public void MoveDown()
		{
			int num = self.GetSiblingIndex() + 1;
			int childCount = parent.childCount;
			if (num < childCount)
			{
				self.SetSiblingIndex(num);
			}
			if (num == childCount - 1)
			{
				downButton.enabled = false;
			}
			upButton.enabled = true;
		}

		public void UpdateButtons()
		{
			if (!hasInit)
			{
				Init();
			}
			int siblingIndex = self.GetSiblingIndex();
			int childCount = parent.childCount;
			upButton.enabled = siblingIndex > 0;
			downButton.enabled = siblingIndex < childCount - 1;
		}
	}
}
