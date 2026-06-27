using Restory.Gameplay.Equipment.TableLamps;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Workplace
{
	public class WorkPlaceRugVisualizer : MonoBehaviour
	{
		[SerializeField]
		private Renderer rugRenderer;

		[SerializeField]
		private string emissionMaterialParam = "_Emission_Power";

		[SerializeField]
		[Min(0f)]
		private int emissionMaterialIndex;

		[SerializeField]
		[Range(0f, 1f)]
		private float dimEmission = 0.1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float brightEmission = 0.3f;

		private TableLamp tableLamp;

		[Inject]
		private void Construct(TableLamp tableLamp)
		{
			this.tableLamp = tableLamp;
		}

		public void Init()
		{
			tableLamp.OnIsOnChanged += ResolveTableLampIsChanged;
		}

		public void Cleanup()
		{
			tableLamp.OnIsOnChanged -= ResolveTableLampIsChanged;
		}

		private void ResolveTableLampIsChanged()
		{
			if (emissionMaterialIndex < rugRenderer.materials.Length)
			{
				rugRenderer.materials[emissionMaterialIndex].SetFloat(emissionMaterialParam, tableLamp.IsOn ? brightEmission : dimEmission);
			}
		}
	}
}
