using UnityEngine;

namespace Gh.Tk
{
	public class ScaleWithCamera : MonoBehaviour
	{
		public Transform visualScaler;

		public float defaultDistance;

		public float defaultScale;

		public float defaultFOV;

		private void OnEnable()
		{
		}

		[ContextMenu("CalibrateDefaultDistance")]
		public void CalibrateDefaultDistance()
		{
		}

		private void UpdateScaler()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
