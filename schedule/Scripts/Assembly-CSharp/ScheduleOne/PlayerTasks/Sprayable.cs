using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks
{
	public class Sprayable : Draggable
	{
		[SerializeField]
		[Header("Sprayable Components")]
		private Transform _sprayOrigin;

		[SerializeField]
		[Header("Gizmos")]
		private bool _drawGizmos;

		public Action _onSuccessfulSpray;

		public UnityEvent onSpray;

		private float _sprayRadius;

		private float _sprayDistance;

		private Vector3 _currentTargetPosition;

		public void Initialise(float sprayRadius, float sprayDistance)
		{
		}

		protected override void Update()
		{
		}

		private void Spray()
		{
		}

		public void SetCurrentTarget(Vector3 position)
		{
		}

		private bool DoesHitTarget(Vector3 rayOrigin, Vector3 rayDirection, Vector3 sphereCenter, float sphereRadius, float maxDistance)
		{
			return false;
		}

		public void SubscribeToSuccessfulSpray(Action callback)
		{
		}

		public void UnsubscribeFromSuccessfulSpray(Action callback)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
