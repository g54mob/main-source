using System;
using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Characters.Behaviours.Snake
{
	public class SnakePointerController : MonoBehaviour
	{
		private SnakeMovementController _snake;

		private float _angle;

		private float _lastAngle;

		[HideInInspector]
		public Vector3 PatrolPosition;

		public void Init(SnakeMovementController snake)
		{
			_snake = snake;
			Reposition();
		}

		public void Update()
		{
			if (_snake.Patrolling)
			{
				base.transform.RotateAround(PatrolPosition, Vector3.forward, _snake.CurrentRotationSpeed / 2f * Time.smoothDeltaTime);
			}
			else if (!_snake.Chasing)
			{
				Vector3 vector = base.transform.position.normalized * WorldController.TerrainSettings.PlanetSize * (Mathf.PingPong(Time.time * 0.05f, 0.5f) + 1.1f);
				base.transform.position = new Vector3(vector.x, vector.y, base.transform.position.z);
				base.transform.RotateAround(Vector3.zero, Vector3.forward, _snake.CurrentRotationSpeed / 8f * Time.smoothDeltaTime);
			}
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, _snake.transform.position.z);
		}

		public void Reposition()
		{
			_lastAngle = _angle;
			int num = 1;
			if (UnityEngine.Random.Range(0, 2) == 1)
			{
				num = -1;
			}
			_angle = _lastAngle + UnityEngine.Random.Range(120f, 240f) * (float)num;
			Vector3 position = new Vector3(Mathf.Cos(_angle * ((float)Math.PI / 180f)), Mathf.Sin(_angle * ((float)Math.PI / 180f)), base.transform.position.z).normalized * WorldController.TerrainSettings.PlanetSize * UnityEngine.Random.Range(1.1f, 1.6f);
			base.transform.position = position;
		}

		public void Attach()
		{
			StartCoroutine(StayAttached());
		}

		public void Detach()
		{
			StopAllCoroutines();
		}

		private IEnumerator StayAttached()
		{
			Transform target = null;
			while (true)
			{
				if (target == null)
				{
					target = RuntimeGlobals.Camera.GetFirstTarget();
				}
				base.transform.position = new Vector3(target.position.x, target.position.y, base.transform.position.z);
				yield return null;
			}
		}
	}
}
