using UnityEngine;

namespace Assets.Scripts.Environment.Roads
{
	public class StoplightScript : MonoBehaviour
	{
		[SerializeField]
		private float _greenDuration = 10f;

		private StoplightType? _lightType;

		private StoplightModelScript[] _models;

		[SerializeField]
		private GameObject[] _redLightBlockers;

		[SerializeField]
		private float _yellowDuration = 3f;

		public float GreenDuration => _greenDuration;

		public float YellowDuration => _yellowDuration;

		public void ChangeLight(StoplightType lightType)
		{
			if (_lightType != lightType)
			{
				_lightType = lightType;
				GameObject[] redLightBlockers = _redLightBlockers;
				for (int i = 0; i < redLightBlockers.Length; i++)
				{
					redLightBlockers[i].SetActive(lightType != StoplightType.Green);
				}
				StoplightModelScript[] models = _models;
				for (int i = 0; i < models.Length; i++)
				{
					models[i].ChangeLight(lightType);
				}
			}
		}

		protected virtual void Awake()
		{
			_models = GetComponentsInChildren<StoplightModelScript>();
		}
	}
}
