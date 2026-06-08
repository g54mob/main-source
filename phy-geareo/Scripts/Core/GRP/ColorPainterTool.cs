using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class ColorPainterTool : Tool<ColorPainterToolConfig>
	{
		public State<Color> color;

		public override bool canInteractPart => false;

		protected override ToolViewable DoCreateViewable()
		{
			return null;
		}
	}
}
