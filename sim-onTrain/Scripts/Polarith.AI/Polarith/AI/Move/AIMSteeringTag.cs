using System;
using System.Collections.Generic;
using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Perception/AIM Steering Tag")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-steeringtag.html")]
	[DisallowMultipleComponent]
	public sealed class AIMSteeringTag : MonoBehaviour
	{
		[Tooltip("Custom identifier of this object.")]
		public string Label;

		[Tooltip("Specifies the importance of the object for a behaviour algorithm.")]
		public float Significance = 1f;

		[Tooltip("Specifies a custom radius for this object. This radius can be used by behaviours, for example, to approximate an object's bounding volume.")]
		[OpenRangeMin(0f)]
		public float Radius;

		[Tooltip("Injects custom information into the corresponding extracted percept.")]
		public List<float> Values = new List<float>();

		[Tooltip("Determines if the velocity of this object should be tracked. If 'true', the corresponding extracted percept is having a valid velocity when there is no (non-kinematic) rigidbody.")]
		public bool TrackVelocity;

		[Tooltip("Determines if the perception pipeline should obtain the local bounds for this object for each percept update. The local bounds are given by the 'SteeringPercept.ColliderBoundsOBB' and 'SteeringPercept.VisualBounds'.")]
		public bool UpdateLocalBounds;

		[Tooltip("If true, the perception pipeline will NOT obtain the local OOB for this object. This might be helpful, if you use physics models of your Rigidbody or Transform that have rotations beyond (-)180 degrees. You don't need this option in common scenarios. Note that you might receive them once and disable the updates afterwards using the API.")]
		public bool IgnoreLocalBounds;

		[NonSerialized]
		public Vector3 Velocity;

		private Vector3 oldPosition;

		private void Start()
		{
			oldPosition = base.transform.position;
		}

		private void LateUpdate()
		{
			if (TrackVelocity)
			{
				Vector3 velocity = (base.transform.position - oldPosition) / Time.deltaTime;
				if (velocity.magnitude > 1E-06f)
				{
					Velocity = velocity;
				}
			}
			oldPosition = base.transform.position;
		}

		private void OnDrawGizmosSelected()
		{
			if (Radius > 0f)
			{
				Gizmos.color = Colors.Blue;
				Gizmos.DrawWireSphere(base.transform.position, Radius);
			}
		}
	}
}
