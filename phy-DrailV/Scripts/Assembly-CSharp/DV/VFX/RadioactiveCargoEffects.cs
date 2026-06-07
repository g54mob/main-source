using UnityEngine;

namespace DV.VFX
{
	public class RadioactiveCargoEffects : MonoBehaviour, ICargoEffects
	{
		public GameObject leakRupture;

		public void ToggleRuptureVisibility(bool on)
		{
			if (leakRupture != null)
			{
				leakRupture.SetActive(on);
			}
		}

		public void AllowSpecialEffects(bool allow)
		{
		}

		public void SetupForContent(ICargoContent cargoContent)
		{
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
			base.transform.localScale = Vector3.one;
		}

		public void UpdateEffectsFlowOut(float flowOut)
		{
		}

		public void UpdateEffectsFlowIn(float flowIn)
		{
		}

		public void OnCargoExploded()
		{
		}

		public void ActivateEffectsExternally(bool playRuptureSound = false)
		{
		}
	}
}
