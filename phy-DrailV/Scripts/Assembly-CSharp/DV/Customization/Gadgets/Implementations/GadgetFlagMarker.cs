using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetFlagMarker : GadgetBase
	{
		private static readonly int PROPERTY_ID_COLOR = Shader.PropertyToID("_Color");

		public MeshRenderer colorRenderer;

		protected override void OnItemAssigned()
		{
			if (GadgetItemAttributeColorChanger.ExtractColor(base.GadgetItem, out var color))
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				materialPropertyBlock.SetColor(PROPERTY_ID_COLOR, color);
				colorRenderer.SetPropertyBlock(materialPropertyBlock);
			}
		}
	}
}
