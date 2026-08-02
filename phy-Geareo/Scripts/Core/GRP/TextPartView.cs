using UnityEngine;

namespace GRP
{
	public class TextPartView : PartView<TextPartViewable>
	{
		public TextPartVisual visual;

		public Transform forward;

		public Transform back;

		protected override void OnRender()
		{
		}
	}
}
