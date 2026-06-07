using UnityEngine;

namespace Assets.Nimbatus.GUI.TravelScene
{
	public class CivilCargoshipAnimation : MonoBehaviour
	{
		public GameObject CorpSignal;

		public GameObject Thruster;

		public SpriteRenderer CivilCargoship;

		public Transform CargoshipTransform;

		[HideInInspector]
		public float CargoshipBrightnessTarget;

		public float CargoshipAngleTarget;

		private float _currentCargoshipBrightness;

		private float _currentCargoshipAngle;

		private void Start()
		{
		}

		private void Update()
		{
			float num = 2f;
			_currentCargoshipBrightness = Mathf.Lerp(_currentCargoshipBrightness, CargoshipBrightnessTarget, Time.deltaTime * num);
			_currentCargoshipAngle = Mathf.Lerp(_currentCargoshipAngle, CargoshipAngleTarget, Time.deltaTime * num);
			CivilCargoship.color = Color.Lerp(new Color(0.7f, 0.7f, 0.7f, 1f), new Color(1f, 1f, 1f, 1f), _currentCargoshipBrightness);
			CargoshipTransform.localEulerAngles = new Vector3(0f, 0f, Mathf.Lerp(-12f, 0f, _currentCargoshipAngle));
		}
	}
}
