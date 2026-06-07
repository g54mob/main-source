using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialTargetXYMovement : MonoBehaviour
	{
		public float Speed;

		public float RotationSpeed;

		public float DistanceX;

		public float DistanceY;

		public float timeOffset;

		private Vector3 _startPosition;

		private float _time;

		private float _angle;

		private void Start()
		{
			_startPosition = base.transform.position;
			_time += timeOffset;
		}

		private void FixedUpdate()
		{
			_time += Time.fixedDeltaTime * Speed;
			Vector3 vector = new Vector3(Mathf.Sin(_time * (float)Math.PI * 2f) * DistanceX, Mathf.Sin(_time * (float)Math.PI * 2f) * DistanceY, 0f);
			base.transform.position = _startPosition + vector;
			base.transform.eulerAngles = new Vector3(0f, 0f, (base.transform.position.x + base.transform.position.y) * RotationSpeed);
		}
	}
}
