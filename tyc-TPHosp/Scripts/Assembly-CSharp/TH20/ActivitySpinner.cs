using UnityEngine;

namespace TH20
{
	public class ActivitySpinner : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _spinnerObject;

		[SerializeField]
		private float _spinSpeed;

		private void Update()
		{
			if (_spinnerObject != null)
			{
				_spinnerObject.Rotate(new Vector3(0f, 0f, Time.unscaledDeltaTime * _spinSpeed));
			}
		}
	}
}
