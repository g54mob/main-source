using UnityEngine;

namespace Restory.Gameplay.Equipment.TableLamps
{
	public class TableLampVisualizer : MonoBehaviour
	{
		[SerializeField]
		private GameObject spotLight;

		[SerializeField]
		private Renderer renderer;

		[SerializeField]
		private string emissionMaterialParam = "_Emission_Power";

		[SerializeField]
		[Min(0f)]
		private int emissionMaterialIndex = 1;

		public void SetIsOn(bool isOn)
		{
			spotLight.SetActive(isOn);
			if (emissionMaterialIndex > 0 && emissionMaterialIndex < renderer.materials.Length)
			{
				renderer.materials[emissionMaterialIndex].SetFloat(emissionMaterialParam, isOn ? 1f : 0f);
			}
		}
	}
}
