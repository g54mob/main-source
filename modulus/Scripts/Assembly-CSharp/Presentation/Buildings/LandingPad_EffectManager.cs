using UnityEngine;

namespace Presentation.Buildings
{
	public class LandingPad_EffectManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject _productionReadyVFX;

		private BuildingLandingPadView _landingPadViewScript;

		private void Start()
		{
			_landingPadViewScript = base.gameObject.GetComponentInParent<BuildingLandingPadView>();
			_landingPadViewScript.OnProductionReadyStateChanged += HandleProductionReadyStateChanged;
		}

		private void OnDestroy()
		{
			if (_landingPadViewScript != null)
			{
				_landingPadViewScript.OnProductionReadyStateChanged -= HandleProductionReadyStateChanged;
			}
		}

		private void HandleProductionReadyStateChanged(bool isReady)
		{
			_productionReadyVFX.SetActive(isReady);
		}
	}
}
