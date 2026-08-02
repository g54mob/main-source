using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP.Pages.NSKit
{
	public class KitStepPartViewable : Viewable
	{
		[RawImageCrew]
		public Texture2D partImage;

		public KitStepPart part;

		public KitStepPartViewable(KitStepPart part)
		{
		}
	}
}
