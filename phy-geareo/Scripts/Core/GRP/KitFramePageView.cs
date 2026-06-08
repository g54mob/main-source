using Rhizomatic.MemberBinding;
using UnityEngine;

namespace GRP
{
	public class KitFramePageView : ProjectFramePageView<KitFramePage>
	{
		public InlineLayout inlineLayout;

		public Transform compass;

		public float smooth;

		public float alpha;

		public ExhibitBlinker exhibitBlinker;

		protected override void OnRender()
		{
		}

		protected override void Update()
		{
		}

		[Member]
		public void Next()
		{
		}

		[Member]
		public void Previous()
		{
		}
	}
}
