using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Characters.Behaviours.Snake
{
	public class SnakeMovementController : MonoBehaviour
	{
		public SnakeBodyPart HeadPrefab;

		public SnakeBodyPart BodyPrefab;

		public SnakeBodyPart TailPrefab;

		public float MinDistance;

		public float Speed = 1f;

		public float RotationSpeed = 50f;

		public int SnakeSize = 10;

		public float DamagePerSecond;

		public float PatrolTime = 30f;

		public float PatrolRadius = 200f;

		public float PatrolSpeed = 2f;

		public float PatrolRotationSpeed = 70f;

		public float AggroRadius = 200f;

		public float AggroTime = 10f;

		public float AggroSpeed = 2f;

		public float AggroRotationSpeed = 100f;

		public float RetainAggroDistance = 50f;

		public float RetainAggroAngle = 10f;

		public string EggDestroyedSound;

		public LayerMask PlayerLayer;

		[HideInInspector]
		public SnakeBodyPart SnakeHead;

		private readonly List<SnakeBodyPart> _bodyParts = new List<SnakeBodyPart>();

		private SnakePointerController _pointer;

		private Vector3 _dir;

		private float _currentSpeed;

		[HideInInspector]
		public float CurrentRotationSpeed;

		[HideInInspector]
		public bool Chasing;

		[HideInInspector]
		public bool Patrolling;

		public void Awake()
		{
			InteractiveWorldObject.OnNotify += EggDestroyed;
		}

		protected void Start()
		{
			_pointer = new GameObject("Pointer").AddComponent<SnakePointerController>();
			_pointer.Init(this);
			SnakeHead = AddHead();
			for (int i = 0; i < SnakeSize; i++)
			{
				AddBodyPart();
			}
			AddTail();
			_currentSpeed = Speed;
			CurrentRotationSpeed = RotationSpeed;
		}

		public void FixedUpdate()
		{
			Move();
		}

		public void OnDisable()
		{
			InteractiveWorldObject.OnNotify -= EggDestroyed;
		}

		private void Move()
		{
			_dir = _pointer.transform.position - SnakeHead.transform.position;
			if (!Chasing)
			{
				if (!Patrolling && _dir.magnitude < 100f)
				{
					while (_dir.magnitude < 100f)
					{
						_pointer.Reposition();
						_dir = _pointer.transform.position - SnakeHead.transform.position;
					}
				}
				if (Patrolling && (RuntimeGlobals.Camera.transform.position - SnakeHead.transform.position).magnitude < AggroRadius)
				{
					StartChase();
				}
			}
			else if ((SnakeHead.transform.position - Vector3.zero).magnitude > (float)WorldController.TerrainSettings.PlanetSize + (float)SnakeSize * (Speed / 2f))
			{
				StopChase();
			}
			Rotate();
			SnakeHead.transform.Translate(SnakeHead.transform.up * _currentSpeed * Time.fixedDeltaTime, Space.World);
			for (int i = 1; i < _bodyParts.Count; i++)
			{
				Transform transform = _bodyParts[i].transform;
				Transform transform2 = _bodyParts[i - 1].transform;
				float num = Vector3.Distance(transform2.position, transform.position);
				float t = Time.fixedDeltaTime * num / MinDistance * _currentSpeed;
				Vector3 position = Vector3.Slerp(transform.position, transform2.position, t);
				position.z = transform2.position.z + 0.01f;
				transform.position = position;
				transform.rotation = Quaternion.Slerp(transform.rotation, transform2.rotation, t);
			}
		}

		private void Rotate()
		{
			float num = Vector3.SignedAngle(SnakeHead.transform.up, _dir, Vector3.forward);
			if (Mathf.Abs(num) > 2f)
			{
				SnakeHead.transform.Rotate(Vector3.forward, CurrentRotationSpeed * (float)((num > 0f) ? 1 : (-1)) * Time.fixedDeltaTime, Space.Self);
				return;
			}
			float num2 = Mathf.Atan2(_dir.y, _dir.x) * 57.29578f;
			num2 -= 90f;
			SnakeHead.transform.rotation = Quaternion.Lerp(SnakeHead.transform.rotation, Quaternion.AngleAxis(num2, Vector3.forward), 0.5f);
		}

		public void EggDestroyed(NotificationData data)
		{
			if (data.Notification == ENotificationType.EggDestroyed && !Chasing)
			{
				StopAllCoroutines();
				StartCoroutine(Patrol(data.Sender.transform.position));
			}
		}

		private IEnumerator Patrol(Vector3 pos)
		{
			Patrolling = true;
			_currentSpeed = PatrolSpeed;
			CurrentRotationSpeed = PatrolRotationSpeed;
			Vector3 vector = new Vector3(pos.x, pos.y, _pointer.transform.position.z);
			_pointer.transform.position = vector + new Vector3(1f, 1f, 0f) * PatrolRadius;
			_pointer.PatrolPosition = vector;
			yield return new WaitForSeconds(PatrolTime);
			Patrolling = false;
			_currentSpeed = Speed;
			CurrentRotationSpeed = RotationSpeed;
		}

		private void StartChase()
		{
			StopAllCoroutines();
			_currentSpeed = Speed;
			CurrentRotationSpeed = RotationSpeed;
			if (WorldController.PlanetMusic != null)
			{
				WorldController.PlanetMusic.EnemyCount++;
			}
			if (!AudioController.IsPlaying(EggDestroyedSound))
			{
				AudioController.Play(EggDestroyedSound, base.transform);
			}
			StartCoroutine(Chase());
		}

		private IEnumerator Chase()
		{
			Patrolling = false;
			Chasing = true;
			_currentSpeed = AggroSpeed;
			CurrentRotationSpeed = AggroRotationSpeed;
			_pointer.Attach();
			yield return new WaitForSeconds(AggroTime);
			while (_dir.magnitude < RetainAggroDistance && Vector3.Angle(SnakeHead.transform.up, _dir) < RetainAggroAngle)
			{
				yield return null;
			}
			StopChase();
		}

		public void StopChase()
		{
			StopAllCoroutines();
			if (WorldController.PlanetMusic != null)
			{
				WorldController.PlanetMusic.EnemyCount--;
			}
			Chasing = false;
			_currentSpeed = Speed;
			CurrentRotationSpeed = RotationSpeed;
			_pointer.Detach();
		}

		public SnakeBodyPart AddHead()
		{
			SnakeBodyPart snakeBodyPart = Object.Instantiate(HeadPrefab, base.transform.position, Quaternion.identity);
			snakeBodyPart.transform.SetParent(base.transform);
			snakeBodyPart.Init(this);
			_bodyParts.Add(snakeBodyPart);
			return snakeBodyPart;
		}

		public void AddBodyPart()
		{
			SnakeBodyPart snakeBodyPart = _bodyParts.Last();
			SnakeBodyPart snakeBodyPart2 = Object.Instantiate(BodyPrefab, snakeBodyPart.transform.position, snakeBodyPart.transform.rotation);
			snakeBodyPart2.Init(this);
			snakeBodyPart2.transform.SetParent(base.transform);
			_bodyParts.Add(snakeBodyPart2);
		}

		public void AddTail()
		{
			SnakeBodyPart snakeBodyPart = _bodyParts.Last();
			SnakeBodyPart snakeBodyPart2 = Object.Instantiate(TailPrefab, snakeBodyPart.transform.position, snakeBodyPart.transform.rotation);
			snakeBodyPart2.Init(this);
			snakeBodyPart2.transform.SetParent(base.transform);
			_bodyParts.Add(snakeBodyPart2);
		}
	}
}
