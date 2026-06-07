using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialTargetCircleMovement : MonoBehaviour
	{
		public float AngleSpeed;

		public float Radius;

		private Vector3 _startPosition;

		private float _time;

		private float _angle;

		private void Start()
		{
			_startPosition = base.transform.position;
		}

		private void FixedUpdate()
		{
			_time += Time.fixedDeltaTime;
			_angle += AngleSpeed;
			_angle = Mathf.Repeat(_angle, 360f);
			Vector3 vector = new Vector3(Mathf.Cos(_angle * ((float)Math.PI / 180f)) * Radius, Mathf.Sin(_angle * ((float)Math.PI / 180f)) * Radius, 0f);
			base.transform.position = _startPosition + vector;
			base.transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(base.transform.position.y - _startPosition.y, base.transform.position.x - _startPosition.x) * 57.29578f);
		}
	}
}
