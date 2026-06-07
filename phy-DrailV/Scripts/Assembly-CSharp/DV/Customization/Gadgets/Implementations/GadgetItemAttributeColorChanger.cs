using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	[RequireComponent(typeof(GadgetItem))]
	public class GadgetItemAttributeColorChanger : MonoBehaviour
	{
		private static readonly int PROPERTY_ID_COLOR = Shader.PropertyToID("_Color");

		public MeshRenderer[] targets;

		public static bool ExtractColor(GadgetItem gadgetItem, out Color color)
		{
			if (gadgetItem.AttributeQuery("HUE", out var value))
			{
				color = Color.HSVToRGB(value / 360f, 1f, 1f);
				return true;
			}
			color = default(Color);
			bool num = gadgetItem.AttributeQuery("R", out color.r);
			bool flag = gadgetItem.AttributeQuery("G", out color.g);
			bool flag2 = gadgetItem.AttributeQuery("B", out color.b);
			return num || flag || flag2;
		}

		private void Start()
		{
			if (targets == null || !TryGetComponent<GadgetItem>(out var component) || !ExtractColor(component, out var color))
			{
				return;
			}
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetColor(PROPERTY_ID_COLOR, color);
			MeshRenderer[] array = targets;
			foreach (MeshRenderer meshRenderer in array)
			{
				if (meshRenderer != null)
				{
					meshRenderer.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}
	}
}
