using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;
using UnityEngine;

namespace GRP.Pages.NSKit
{
	public class KitPartViewable : Viewable
	{
		[RawImageCrew]
		public State<Texture> image;

		[TextCrew]
		public State<string> count;

		public KitPartViewable(KitPart part)
		{
		}
	}
}
