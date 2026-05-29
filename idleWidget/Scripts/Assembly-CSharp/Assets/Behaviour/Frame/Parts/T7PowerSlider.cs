using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T7PowerSlider : T6SiliconSlider
	{
		[SerializeField]
		private Transform _notch;

		private void Start()
		{
		}

		public void SetNotch(float notch)
		{
			_notch.transform.localPosition = new Vector3(Mathf.Lerp(_minX, _maxX, notch), _notch.transform.localPosition.y, _notch.transform.localPosition.z);
		}

		public bool IsSolved()
		{
			return Mathf.Abs(_notch.localPosition.x - _currentX) < 0.15f;
		}
	}
}
