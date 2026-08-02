using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP.Pages.NSKit
{
	public class KitStepViewable : Viewable
	{
		[RawImageCrew]
		public Texture2D stepImage;

		[ListLoaderCrew]
		public List<KitStepPartViewable> parts;

		public KitManualViewable kit;

		public KitStep step;

		public KitStepViewable(KitManualViewable kit, KitStep step)
		{
		}
	}
}
