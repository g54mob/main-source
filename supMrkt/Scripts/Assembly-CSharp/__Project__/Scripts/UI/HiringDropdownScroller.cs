using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.UI
{
	public class HiringDropdownScroller : UIDropdownScroller
	{
		[SerializeField]
		private ScrollRect m_ParentScroll;

		[SerializeField]
		private int m_ParentIndex;

		public void SetIndexExternal(int parentIndex)
		{
		}

		public override void Select()
		{
		}
	}
}
