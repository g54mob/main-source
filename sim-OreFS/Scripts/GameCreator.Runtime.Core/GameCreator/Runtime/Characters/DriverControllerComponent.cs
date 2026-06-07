using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[AddComponentMenu("")]
	public class DriverControllerComponent : MonoBehaviour
	{
		private event Action<ControllerColliderHit> EventControllerColliderHit;

		private void Awake()
		{
			base.hideFlags = HideFlags.DontSave | HideFlags.HideInHierarchy | HideFlags.HideInInspector;
		}

		private void OnDestroy()
		{
			this.EventControllerColliderHit = null;
		}

		public static DriverControllerComponent Register(Character self, Action<ControllerColliderHit> onHitCallback)
		{
			DriverControllerComponent driverControllerComponent = self.gameObject.AddComponent<DriverControllerComponent>();
			driverControllerComponent.EventControllerColliderHit += onHitCallback;
			return driverControllerComponent;
		}

		protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
		{
			this.EventControllerColliderHit?.Invoke(hit);
		}
	}
}
