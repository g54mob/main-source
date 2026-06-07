using UnityEngine;
using UnityEngine.Rendering;

namespace DV.Simulation.Cars
{
	public class Headlight : MonoBehaviour
	{
		public const int SORTING_ORDER = 10;

		public VolumetricBeamControllerBase.VolumetricBeamData beamData;

		public GameObject glare;

		[SerializeField]
		private Renderer headlightRenderer;

		[SerializeField]
		private Material emissionMaterialLit;

		[SerializeField]
		private Material emissionMaterialUnlit;

		public bool BeamsOn { get; private set; }

		private void Awake()
		{
			ToggleBeam(logic: false, view: false);
			ToggleGlare(on: false);
			if (glare != null)
			{
				glare.AddComponent<SortingGroup>().sortingOrder = 10;
			}
		}

		public void ToggleEmission(bool on)
		{
			if (headlightRenderer == null)
			{
				return;
			}
			if (on)
			{
				if (emissionMaterialLit != null)
				{
					headlightRenderer.material = emissionMaterialLit;
				}
			}
			else if (emissionMaterialUnlit != null)
			{
				headlightRenderer.material = emissionMaterialUnlit;
			}
		}

		public void ToggleGlare(bool on)
		{
			if (!(glare == null))
			{
				glare.SetActive(on);
			}
		}

		public void ToggleBeam(bool logic, bool view)
		{
			if (!(beamData.beam == null))
			{
				beamData.beam.gameObject.SetActive(view);
				BeamsOn = logic;
			}
		}
	}
}
