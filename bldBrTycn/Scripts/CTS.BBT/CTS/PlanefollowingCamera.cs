using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class PlanefollowingCamera : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _relativePositionPlane;

		[SerializeField]
		private Vector3 _relativeRotationPlane;

		[Button(null, EButtonEnableMode.Always)]
		private void SavePosition()
		{
			_relativePositionPlane = base.transform.localPosition;
			_relativeRotationPlane = base.transform.localRotation.eulerAngles;
		}

		private void LateUpdate()
		{
			base.transform.position = MonoSingleton<MainCamera>.Instance.transform.position + MonoSingleton<MainCamera>.Instance.transform.TransformVector(_relativePositionPlane);
			base.transform.LookAt(MonoSingleton<MainCamera>.Instance.transform.position);
			base.transform.localEulerAngles += _relativeRotationPlane;
		}
	}
}
