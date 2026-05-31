using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T9SuperconductorRotator : MonoBehaviour
	{
		private float _z;

		private void Update()
		{
			_z += Time.deltaTime * 180f;
			if (_z > 360f)
			{
				_z -= 360f;
			}
			base.transform.localEulerAngles = new Vector3(0f, 0f, _z);
		}
	}
}
