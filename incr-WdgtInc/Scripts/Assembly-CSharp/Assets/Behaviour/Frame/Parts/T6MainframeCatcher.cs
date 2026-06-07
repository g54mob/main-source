using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T6MainframeCatcher : MonoBehaviour
	{
		[SerializeField]
		private float _xMin;

		[SerializeField]
		private float _xMax;

		private float _currentX;

		private void Update()
		{
			float value = PlayerControls.MouseWorld.x - base.transform.parent.position.x;
			_currentX = Mathf.Clamp(value, _xMin, _xMax);
			base.transform.localPosition = new Vector3(_currentX, base.transform.localPosition.y, base.transform.localPosition.z);
		}
	}
}
