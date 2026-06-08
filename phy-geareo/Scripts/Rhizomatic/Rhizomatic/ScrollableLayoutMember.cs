using Rhizomatic.MemberBinding;
using UnityEngine;

namespace Rhizomatic
{
	public class ScrollableLayoutMember : Member<ScrollableLayout>
	{
		public LayoutItemBuilder itemBuilder
		{
			set
			{
			}
		}

		public Vector2Int range
		{
			get
			{
				return default(Vector2Int);
			}
			set
			{
			}
		}

		public int rangeX
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int rangeY
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
	}
}
