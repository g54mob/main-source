using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Coherence.Toolkit.ComponentActions
{
	[ComponentAction(typeof(Rigidbody), "Is Kinematic")]
	public sealed class KinematicRigidbodyComponentAction : ComponentAction
	{
		[Tooltip("When there's no authority over this entity, set 'Is Kinematic' to enabled.")]
		[SerializeField]
		[FormerlySerializedAs("setOnRemote")]
		private bool enableOnRemote;

		[Tooltip("When there's authority over this entity, set 'Is Kinematic' to disabled.")]
		[SerializeField]
		[FormerlySerializedAs("resetOnAuthority")]
		private bool disableOnAuthority;

		[Obsolete("Access to this member will be removed in a future version.")]
		[Deprecated("07/2024", 1, 2, 4, Reason = "Field was renamed for clarity and made private to improve encapsulation.")]
		public bool setOnRemote
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Access to this member will be removed in a future version.")]
		[Deprecated("07/2024", 1, 2, 4, Reason = "Field was renamed for clarity and made private to improve encapsulation.")]
		public bool resetOnAuthority
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override void OnAuthority()
		{
		}

		public override void OnRemote()
		{
		}
	}
}
