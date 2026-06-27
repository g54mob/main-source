using Restory.Data.Devices;
using UnityEngine;

namespace Restory.Gameplay.Devices
{
	public class CompetitionDevicePackLabel : MonoBehaviour
	{
		[SerializeField]
		private Renderer deviceImageRenderer;

		[SerializeField]
		private string deviceLabelTextureParam = "_Device";

		[SerializeField]
		[Min(0f)]
		private int packMaterialIndex;

		public void Init(DeviceInfo deviceInfo)
		{
			SetLabelTexture(deviceInfo.Icon.texture);
		}

		public void Cleanup()
		{
			SetLabelTexture(null);
		}

		private void SetLabelTexture(Texture2D deviceLabelTexture)
		{
			if (packMaterialIndex < deviceImageRenderer.materials.Length)
			{
				deviceImageRenderer.materials[packMaterialIndex].SetTexture(deviceLabelTextureParam, deviceLabelTexture);
			}
		}
	}
}
