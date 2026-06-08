using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic
{
	public class RecyclerLayout : LayoutDynamic
	{
		public Transform container;

		public ScrollRect scrollRect;

		public float itemHeight;

		public float bottomMargin;

		public int count;

		protected override Transform GetContainer()
		{
			return null;
		}

		protected override void BuildLayout()
		{
		}

		private void Reset()
		{
		}
	}
}
