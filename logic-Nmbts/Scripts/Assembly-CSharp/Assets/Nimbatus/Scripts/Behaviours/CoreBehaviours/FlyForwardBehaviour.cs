using System;
using Assets.Nimbatus.Scripts.Behaviours.Radar;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class FlyForwardBehaviour : CoreBehaviour
	{
		public EnemyRadar Radar;

		public float ForwardAngle;

		public float ForwardForce = 200f;

		public float MaxTravelDistance;

		private bool _isInitialized;

		private Vector3 _startPosition;

		protected override void OnInit()
		{
			if (!_isInitialized)
			{
				_startPosition = OwnWorldObject.transform.position;
				_isInitialized = true;
			}
		}

		protected override void OnRelease()
		{
		}

		protected override void OnFixedUpdate()
		{
			if ((bool)Radar && Radar.NearestTarget == null && Vector3.Distance(OwnWorldObject.transform.position, _startPosition) < MaxTravelDistance)
			{
				Vector3 vector = new Vector3(Mathf.Cos(ForwardAngle * ((float)Math.PI / 180f)), Mathf.Sin(ForwardAngle * ((float)Math.PI / 180f)), 0f).normalized * ((OwnWorldObject.transform.position - _startPosition).magnitude + 10f);
				Vector3 vector2 = _startPosition + vector - OwnWorldObject.transform.position;
				OwnWorldObject.Rigidbody.AddForce(vector2.normalized * ForwardForce, ForceMode.Force);
			}
		}
	}
}
