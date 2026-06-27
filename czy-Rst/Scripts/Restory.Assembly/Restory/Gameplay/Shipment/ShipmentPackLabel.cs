using UnityEngine;

namespace Restory.Gameplay.Shipment
{
	public class ShipmentPackLabel : MonoBehaviour
	{
		[SerializeField]
		private Renderer labelRenderer;

		[SerializeField]
		private string labelTextureParam = "_Device";

		[SerializeField]
		[Min(0f)]
		private int packMaterialIndex;

		public void Init(Sprite contentIcon)
		{
			SetLabelTexture(contentIcon?.texture);
		}

		private void SetLabelTexture(Texture2D labelTexture)
		{
			if (packMaterialIndex < labelRenderer.materials.Length)
			{
				labelRenderer.materials[packMaterialIndex].SetTexture(labelTextureParam, labelTexture);
			}
		}
	}
}
