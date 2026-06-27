using UnityEngine;

namespace Restory.Gameplay.Equipment.PersonalComputers
{
	public class PcInteractiveWorkplaceItemVisualizer : MonoBehaviour
	{
		[SerializeField]
		private Renderer renderer;

		[SerializeField]
		private int materialIndex;

		[SerializeField]
		private Texture2D blackScreenTexture;

		[SerializeField]
		private Texture2D noInternetTexture;

		[SerializeField]
		private Texture2D desktopTexture;

		public void ShowBlackScreen()
		{
			SetTexture(blackScreenTexture);
		}

		public void ShowNoInternet()
		{
			SetTexture(noInternetTexture);
		}

		public void ShowDesktop()
		{
			SetTexture(desktopTexture);
		}

		private void SetTexture(Texture2D texture)
		{
			Material[] materials = renderer.materials;
			if (materialIndex < 0 || materialIndex >= materials.Length)
			{
				Debug.LogWarning("[PcInteractiveWorkplaceItemVisualizer] " + $"Invalid material index: {materialIndex}. Total materials: {materials.Length}.");
				return;
			}
			materials[materialIndex].SetTexture("_Main_Texture", texture);
			renderer.materials = materials;
		}
	}
}
