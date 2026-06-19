using UnityEngine;

namespace WorldEnvironment.FunctionalObjects
{
	public class HoldingTwoSideSwitch : MonoBehaviour
	{
		[SerializeField]
		private SwitchHoldingPoint _upHoldingPoint;

		[SerializeField]
		private SwitchHoldingPoint _downHoldingPoint;

		[SerializeField]
		private GameObject UpModel;

		[SerializeField]
		private GameObject DownModel;

		[SerializeField]
		private GameObject MidModel;

		private void OnEnable()
		{
			_upHoldingPoint.HoldingStart.AddListener(ActivateUpLight);
			_upHoldingPoint.HoldingEnd.AddListener(ActivateNeutralLight);
			_downHoldingPoint.HoldingStart.AddListener(ActivateDownLight);
			_downHoldingPoint.HoldingEnd.AddListener(ActivateNeutralLight);
		}

		private void ActivateUpLight()
		{
			UpModel.SetActive(value: true);
			DownModel.SetActive(value: false);
			MidModel.SetActive(value: false);
		}

		private void ActivateDownLight()
		{
			UpModel.SetActive(value: false);
			DownModel.SetActive(value: true);
			MidModel.SetActive(value: false);
		}

		private void ActivateNeutralLight()
		{
			UpModel.SetActive(value: false);
			DownModel.SetActive(value: false);
			MidModel.SetActive(value: true);
		}
	}
}
