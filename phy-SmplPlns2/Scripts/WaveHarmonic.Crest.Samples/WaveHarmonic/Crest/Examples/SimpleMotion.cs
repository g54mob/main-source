using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Examples
{
	[AddComponentMenu("")]
	internal sealed class SimpleMotion : CustomBehaviour
	{
		[SerializeField]
		private bool _ResetOnDisable;

		[SerializeField]
		private bool _IsLocal;

		[Header("Translation")]
		[SerializeField]
		private Vector3 _Velocity;

		[Header("Rotation")]
		[SerializeField]
		private Vector3 _AngularVelocity;

		private Vector3 _OldPosition;

		private Quaternion _OldRotation;

		private protected override void OnEnable()
		{
			base.OnEnable();
			_OldPosition = base.transform.position;
			_OldRotation = base.transform.rotation;
		}

		private void OnDisable()
		{
			if (_ResetOnDisable)
			{
				base.transform.SetPositionAndRotation(_OldPosition, _OldRotation);
			}
		}

		private void Update()
		{
			base.transform.position += (_IsLocal ? base.transform.TransformDirection(_Velocity) : _Velocity) * Time.deltaTime;
			base.transform.rotation *= Quaternion.Euler(_AngularVelocity * Time.deltaTime);
		}
	}
}
