using Rhizomatic.Utility;
using UnityEngine;

namespace GRP
{
	public class ColorPainterToolView : ToolView<ColorPainterToolViewable>
	{
		public WorldPointablePort port;

		private Highlight highlight;

		private Highlightable highlightable;

		private Color lastColor;

		private JsonData.Member lastMember;

		private Part currentPart;

		private PartView currentPartView;

		protected override void OnViewOpen()
		{
		}

		protected override void OnViewCreated()
		{
		}

		private JsonData.Member GetColorMember(PartView partView, WorldPointerEvent evt)
		{
			return null;
		}

		private void SetDefaultColor(WorldPointerEvent evt)
		{
		}
	}
}
