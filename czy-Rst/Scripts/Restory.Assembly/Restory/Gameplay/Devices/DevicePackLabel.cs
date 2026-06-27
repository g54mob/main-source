using Restory.Data.Devices;
using Restory.Gameplay.WorkOrders;
using Restory.UserInterface.ElementPresets;
using UnityEngine;

namespace Restory.Gameplay.Devices
{
	public class DevicePackLabel : MonoBehaviour
	{
		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private Renderer deviceImageRenderer;

		[SerializeField]
		private Renderer customerImageRenderer;

		[SerializeField]
		private string deviceLabelTextureParam = "_Device";

		[SerializeField]
		private string characterLabelTextureParam = "_Character";

		[SerializeField]
		[Min(0f)]
		private int packMaterialIndex;

		public void Init(DeviceInfo deviceInfo, OrderCategory orderCategory, Sprite customerIcon = null)
		{
			presetSwitcher.ActivatePreset(orderCategory.ToString());
			SetLabelTexture(deviceInfo.Icon.texture, customerIcon?.texture);
		}

		public void Cleanup()
		{
			SetLabelTexture(null, null);
		}

		private void SetLabelTexture(Texture2D deviceLabelTexture, Texture2D customerLabelTexture)
		{
			if (packMaterialIndex < deviceImageRenderer.materials.Length)
			{
				deviceImageRenderer.materials[packMaterialIndex].SetTexture(deviceLabelTextureParam, deviceLabelTexture);
			}
			if (packMaterialIndex < customerImageRenderer.materials.Length)
			{
				customerImageRenderer.materials[packMaterialIndex].SetTexture(characterLabelTextureParam, customerLabelTexture);
			}
		}
	}
}
