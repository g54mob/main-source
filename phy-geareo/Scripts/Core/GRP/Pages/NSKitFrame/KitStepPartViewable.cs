using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP.Pages.NSKitFrame
{
	public class KitStepPartViewable : Viewable
	{
		[RawImageCrew]
		public State<Texture> image;

		public KitPartViewable kitPartView;

		public KitStep step;

		public KitStepPart stepPart;

		public KitFramePage kitFramePage;

		public State<bool> used;

		public KitStepPartViewable(KitFramePage kitFramePage, KitStep step, KitStepPart stepPart, KitPartViewable partViewable)
		{
		}
	}
}
