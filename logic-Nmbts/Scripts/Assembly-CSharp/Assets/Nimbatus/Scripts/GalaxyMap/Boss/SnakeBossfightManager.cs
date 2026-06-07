using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events;
using Assets.Nimbatus.Scripts.Characters.Behaviours.Bossfights;
using Assets.Nimbatus.Scripts.Common.Cursor;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Boss
{
	public class SnakeBossfightManager : BossfightManager
	{
		public class ExcludeAngle
		{
			public float Min;

			public float Max;
		}

		[Header("Snake")]
		public SnakeBossfightBodyPart HeadPrefab;

		public SnakeBossfightBodyPart TailPrefab;

		public List<SnakeBossfightBodyPart> BodyBuilder = new List<SnakeBossfightBodyPart>();

		public float MinDistance;

		public Transform StartPosition;

		public CursorToBossfight Cursor;

		[Header("Arena")]
		public Crusher DoorCrusher;

		public Transform ArenaCenter;

		public float DronePartCheckDiameter;

		public float RoamDiameter;

		public float SpawnDiameter;

		public float DisappearDiameter;

		public float RoamPointerSpeed;

		public List<ExcludeAngle> ExcludedAngles = new List<ExcludeAngle>();

		public List<SnakeBossfightSpike> Spikes = new List<SnakeBossfightSpike>();

		public string SpikeHitSfx;

		[Header("Sound")]
		public string Phase0Ambient;

		public string Phase1Ambient;

		public string Phase0Music;

		public string Phase1Music;

		public string Phase2Music;

		[Header("Phase 1")]
		public float P1Speed = 40f;

		public float P1TurnSpeed;

		public float P1Damage = 65f;

		public float P1FleeSpeed = 65f;

		public float MinRoamTime = 6f;

		public float MaxRoamTime = 12f;

		public float MinWaitTime = 8f;

		public float MaxWaitTime = 12f;

		[Header("Phase 2")]
		public float P2Speed = 70f;

		public float P2TurnSpeed;

		public float P2Damage = 75f;

		public float MinFollowTime = 8f;

		public float MaxFollowTime = 16f;

		public int MinConsecutiveFollows = 2;

		public int MaxConsecutiveFollows = 3;

		public float P2FleeSpeed = 85f;

		public float ChargeTime = 5f;

		public float ChargeAttackSpeed = 100f;

		public float ChargeTurnSpeed = 60f;

		public float ChargeDamage;

		public GameObject ChargeTellPrefab;

		public string ChargeSoundEffect;

		public string AttackSoundEffect;

		public int MinConsecutiveCharges = 1;

		public int MaxConsecutiveCharges = 3;

		public float StunTime = 8f;

		public AnimationCurve StunHeadCurve;

		public AnimationCurve StunLengthCurve;

		public AnimationCurve StunAmpCurve;

		[Header("Phase 3")]
		public float P3Speed = 80f;

		public float P3TurnSpeed;

		public float P3Damage = 100f;

		public float P3FollowTime = 10f;

		public float P3ChargeTime = 4f;

		public float P3AimSpeed = 50f;

		public float P3ShootTime = 4f;

		private SnakeBossfightBodyPart _snakeHead;

		private readonly List<SnakeBossfightBodyPart> _bodyParts = new List<SnakeBossfightBodyPart>();

		private SnakeBossfightBodyPart _snakeTail;

		private bool _initialized;

		private bool _lockMovement;

		private bool _fleeing;

		private bool _wasFleeing;

		private bool _charging;

		private bool _stunned;

		private bool _wasStunned;

		private Vector3 _stunPoint;

		private bool _stopping;

		private Transform _pointer;

		private bool _lockPointer;

		private bool _attachPointer;

		private Vector3 _dir;

		private int _currentPhase;

		[HideInInspector]
		public float CurrentSpeed;

		public float TargetSpeed
		{
			get
			{
				if (_stopping)
				{
					return 0f;
				}
				switch (_currentPhase)
				{
				case 1:
					if (_fleeing)
					{
						return P1FleeSpeed;
					}
					return P1Speed;
				case 2:
					if (_fleeing)
					{
						return P2FleeSpeed;
					}
					if (_charging)
					{
						return ChargeAttackSpeed;
					}
					return P2Speed;
				case 3:
					return P3Speed;
				default:
					return 0f;
				}
			}
		}

		public float CurrentTurnSpeed
		{
			get
			{
				switch (_currentPhase)
				{
				case 1:
					return P1TurnSpeed;
				case 2:
					if (_charging)
					{
						return ChargeTurnSpeed;
					}
					return P2TurnSpeed;
				case 3:
					if (_stopping)
					{
						return P3AimSpeed;
					}
					return P3TurnSpeed;
				default:
					return 0f;
				}
			}
		}

		public float CurrentDamage
		{
			get
			{
				switch (_currentPhase)
				{
				case 1:
					return P1Damage;
				case 2:
					if (_charging && !_stunned)
					{
						return ChargeDamage;
					}
					return P2Damage;
				case 3:
					return P3Damage;
				default:
					return 0f;
				}
			}
		}

		public IEnumerator _SpeedDamper()
		{
			CurrentSpeed = TargetSpeed;
			float vel = 0f;
			while (true)
			{
				float smoothTime = (_stopping ? 2f : 0.5f);
				CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, TargetSpeed, ref vel, smoothTime);
				yield return null;
			}
		}

		public override void Init()
		{
			if (Cursor != null)
			{
				Cursor.Init(this);
			}
			StartCoroutine(_Fight());
		}

		public override void Update()
		{
			base.Update();
			if (_initialized && !_lockPointer && !_attachPointer)
			{
				Vector3 vector = (_pointer.transform.position - ArenaCenter.position).normalized * RoamDiameter * (Mathf.PingPong(Time.time * 0.2f, 0.5f) + 1f);
				_pointer.transform.position = ArenaCenter.position + new Vector3(vector.x, vector.y, base.transform.position.z);
				_pointer.transform.RotateAround(ArenaCenter.position, Vector3.forward, RoamPointerSpeed * Time.smoothDeltaTime);
			}
		}

		public void FixedUpdate()
		{
			if (_initialized && !_lockMovement)
			{
				Move();
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			InteractiveWorldObject.OnNotify -= Flee;
		}

		private IEnumerator _Fight()
		{
			AudioController.SetCategoryVolume("Music", RuntimeGlobals.Settings.MusicVolume);
			AudioController.SetCategoryVolume("Sound", RuntimeGlobals.Settings.SoundEffectVolume);
			AudioObject phase0Music = AudioController.PlayMusic(Phase0Music);
			AudioObject phase0Ambient = CreateAmbientAudio(Phase0Ambient);
			while (DoorCrusher.IsReady)
			{
				yield return null;
			}
			_snakeHead = AddHead();
			foreach (SnakeBossfightBodyPart item in BodyBuilder)
			{
				AddBodyPart(item);
			}
			_snakeTail = AddTail();
			_pointer = UnityEngine.Object.Instantiate(new GameObject(), base.transform).transform;
			float angle = UnityEngine.Random.Range(0f, 360f);
			Vector3 circularPosition = GetCircularPosition(angle);
			_pointer.position = new Vector3(circularPosition.x, circularPosition.y, _snakeHead.transform.position.z);
			InteractiveWorldObject.OnNotify += Flee;
			StartCoroutine(_SpeedDamper());
			_initialized = true;
			NextPhase();
			_snakeHead.Remnant.SetActive(false);
			_snakeHead.SetEyeOpen(false);
			_bodyParts.ForEach(delegate(SnakeBossfightBodyPart snakeBossfightBodyPart2)
			{
				snakeBossfightBodyPart2.ChangeEyeState(false);
			});
			phase0Music.FadeOut(1f);
			phase0Ambient.FadeOut(1f);
			AudioObject phase1Music = AudioController.PlayMusic(Phase1Music);
			phase1Music.FadeIn(1f);
			AudioObject phase1Ambient = AudioController.Play(Phase1Ambient, ArenaCenter.transform);
			phase1Ambient.FadeIn(1f);
			Coroutine p1 = StartCoroutine(_Phase1());
			while (_currentPhase == 1)
			{
				if (_bodyParts.Where((SnakeBossfightBodyPart snakeBossfightBodyPart2) => snakeBossfightBodyPart2.Armor != null).All((SnakeBossfightBodyPart snakeBossfightBodyPart2) => snakeBossfightBodyPart2.Armor.HealthPool.IsDead))
				{
					NextPhase();
				}
				yield return null;
			}
			StopCoroutine(p1);
			Spikes.ForEach(delegate(SnakeBossfightSpike s)
			{
				s.Activate(true);
			});
			yield return StartCoroutine(_ReturnToHole());
			yield return new WaitForSeconds(3f);
			phase1Music.FadeOut(1f);
			AudioObject phase2Music = AudioController.PlayMusic(Phase2Music);
			phase2Music.FadeIn(1f);
			Coroutine p2 = StartCoroutine(_Phase2());
			_bodyParts.Where((SnakeBossfightBodyPart snakeBossfightBodyPart2) => snakeBossfightBodyPart2 != _snakeHead).ToList().ForEach(delegate(SnakeBossfightBodyPart snakeBossfightBodyPart2)
			{
				snakeBossfightBodyPart2.ChangeEyeState(true);
			});
			while (_currentPhase == 2)
			{
				if (_bodyParts.Where((SnakeBossfightBodyPart snakeBossfightBodyPart2) => snakeBossfightBodyPart2 != _snakeHead && snakeBossfightBodyPart2.Eye != null).All((SnakeBossfightBodyPart snakeBossfightBodyPart2) => snakeBossfightBodyPart2.Eye.HealthPool.IsDead))
				{
					NextPhase();
				}
				yield return null;
			}
			StopCoroutine(p2);
			Spikes.ForEach(delegate(SnakeBossfightSpike s)
			{
				s.Activate(false);
			});
			_lockPointer = true;
			_stopping = true;
			yield return new WaitForEndOfFrame();
			List<SnakeBossfightBodyPart> list = _bodyParts.ToList();
			int index = list.Count;
			while (index > 1)
			{
				index--;
				SnakeBossfightBodyPart snakeBossfightBodyPart = list[index];
				_bodyParts.Remove(snakeBossfightBodyPart);
				snakeBossfightBodyPart.Die();
				if (index == 1)
				{
					_snakeHead.Remnant.SetActive(true);
				}
				yield return new WaitForSeconds(0.3f);
			}
			yield return new WaitForSeconds(0.5f);
			_lockPointer = false;
			_stopping = false;
			Attach();
			_snakeHead.gameObject.SetActive(true);
			_snakeHead.SetEyeOpen(true);
			_snakeHead.ChangeEyeState(true);
			GameObject obj = new GameObject();
			obj.transform.parent = _snakeHead.transform;
			Vector3 position = _snakeHead.Eye.transform.position;
			position.z += 0.1f;
			obj.transform.position = position;
			obj.transform.localRotation = _snakeHead.Eye.transform.localRotation;
			obj.AddComponent<SpriteRenderer>().sprite = _snakeHead.Eye.GetComponent<SpriteRenderer>().sprite;
			Coroutine p3 = StartCoroutine(_Phase3());
			while (_currentPhase == 3)
			{
				if (_snakeHead.Eye.HealthPool.IsDead)
				{
					NextPhase();
				}
				yield return null;
			}
			StopCoroutine(p3);
			_attachPointer = false;
			_stopping = true;
			yield return new WaitForSeconds(2f);
			_lockMovement = true;
			_snakeHead.Die();
			yield return new WaitForSeconds(2f);
			phase2Music.FadeOut(1.5f);
			phase1Ambient.FadeOut(1.5f);
			phase0Music = AudioController.PlayMusic(Phase0Music);
			phase0Music.FadeIn(1.5f);
			phase0Ambient = CreateAmbientAudio(Phase0Ambient);
			phase0Ambient.FadeIn(1.5f);
			FinishBossfight();
		}

		private AudioObject CreateAmbientAudio(string sound)
		{
			AudioObject audioObject = AudioController.PlayAmbienceSound(Phase0Ambient, ArenaCenter.transform);
			AudioSource component = audioObject.GetComponent<AudioSource>();
			component.rolloffMode = AudioRolloffMode.Linear;
			component.maxDistance = DisappearDiameter * 2.4f;
			component.minDistance = DisappearDiameter * 1.2f;
			return audioObject;
		}

		public void NextPhase()
		{
			_currentPhase++;
		}

		private IEnumerator _Phase1()
		{
			while (_currentPhase == 1)
			{
				yield return StartCoroutine(_EmergeFromHole());
				float roamTime = UnityEngine.Random.Range(MinRoamTime, MaxRoamTime);
				float t = 0f;
				while (t < roamTime && !_fleeing)
				{
					t += Time.deltaTime;
					yield return null;
				}
				yield return StartCoroutine(_ReturnToHole());
			}
		}

		private IEnumerator _Phase2()
		{
			while (_currentPhase == 2)
			{
				int follows = UnityEngine.Random.Range(MinConsecutiveFollows, MaxConsecutiveFollows);
				for (int i = 0; i < follows; i++)
				{
					if (_wasFleeing)
					{
						break;
					}
					yield return StartCoroutine(_Follow());
				}
				_wasFleeing = false;
				int charges = UnityEngine.Random.Range(MinConsecutiveCharges, MaxConsecutiveCharges);
				for (int i = 0; i < charges; i++)
				{
					if (_wasStunned)
					{
						break;
					}
					yield return StartCoroutine(_Charge());
				}
				_wasStunned = false;
				_wasFleeing = false;
			}
		}

		private IEnumerator _Phase3()
		{
			while (_currentPhase == 3)
			{
				yield return new WaitForSeconds(P3FollowTime);
				_stopping = true;
				_snakeHead.ChargeLaser(true);
				yield return new WaitForSeconds(P3ChargeTime);
				_snakeHead.ChargeLaser(false);
				_snakeHead.ActivateEyeWeapon(true);
				yield return new WaitForSeconds(P3ShootTime);
				_stopping = false;
				_snakeHead.ActivateEyeWeapon(false);
			}
		}

		private void Flee(NotificationData data)
		{
			if (data.Notification == ENotificationType.SnakeBossPartDestroyed && !_charging)
			{
				_fleeing = true;
				_wasFleeing = true;
			}
		}

		private IEnumerator _EmergeFromHole()
		{
			float angle = UnityEngine.Random.Range(0f, 360f);
			Vector3 pos = GetCircularPosition(angle);
			_lockPointer = false;
			_lockMovement = true;
			yield return new WaitForEndOfFrame();
			foreach (SnakeBossfightBodyPart bodyPart in _bodyParts)
			{
				bodyPart.transform.position = pos;
				float angle2 = Vector3.SignedAngle(bodyPart.transform.up, ArenaCenter.position - bodyPart.transform.position, bodyPart.transform.forward);
				bodyPart.transform.Rotate(bodyPart.transform.forward, angle2);
				bodyPart.gameObject.SetActive(true);
			}
			yield return new WaitForEndOfFrame();
			_lockMovement = false;
		}

		private IEnumerator _ReturnToHole()
		{
			int phase = _currentPhase;
			float angle = UnityEngine.Random.Range(0f, 360f);
			Vector3 circularPosition = GetCircularPosition(angle);
			circularPosition = ArenaCenter.position + (circularPosition - ArenaCenter.position) * ((float)BodyBuilder.Count / 5f);
			_lockPointer = true;
			_pointer.position = circularPosition;
			while (Vector2.Distance(ArenaCenter.position, _snakeTail.transform.position) < DisappearDiameter)
			{
				if (_currentPhase != phase)
				{
					_lockPointer = false;
					{
						foreach (SnakeBossfightBodyPart bodyPart in _bodyParts)
						{
							bodyPart.gameObject.SetActive(true);
						}
						yield break;
					}
				}
				foreach (SnakeBossfightBodyPart bodyPart2 in _bodyParts)
				{
					bodyPart2.gameObject.SetActive(Vector2.Distance(bodyPart2.transform.position, ArenaCenter.position) < DisappearDiameter);
				}
				yield return null;
			}
			_lockPointer = false;
			_fleeing = false;
			float seconds = UnityEngine.Random.Range(MinWaitTime, MaxWaitTime);
			yield return new WaitForSeconds(seconds);
		}

		private IEnumerator _Follow()
		{
			if (_currentPhase != 2)
			{
				yield break;
			}
			yield return StartCoroutine(_EmergeFromHole());
			Attach();
			_bodyParts.Where((SnakeBossfightBodyPart p) => p != _snakeHead).ToList().ForEach(delegate(SnakeBossfightBodyPart p)
			{
				p.ActivateEyeWeapon(true);
			});
			float t = 0f;
			float followTime = UnityEngine.Random.Range(MinFollowTime, MaxFollowTime);
			int phase = _currentPhase;
			while (t < followTime)
			{
				t += Time.deltaTime;
				if (_currentPhase != phase)
				{
					_attachPointer = false;
					yield break;
				}
				yield return null;
			}
			_attachPointer = false;
			_bodyParts.ForEach(delegate(SnakeBossfightBodyPart p)
			{
				p.ActivateEyeWeapon(false);
			});
			yield return StartCoroutine(_ReturnToHole());
		}

		private IEnumerator _Charge()
		{
			if (_currentPhase != 2)
			{
				yield break;
			}
			_charging = true;
			_lockMovement = true;
			_lockPointer = true;
			yield return new WaitForEndOfFrame();
			Transform target = GetTarget();
			float startAngle = Vector3.SignedAngle(ArenaCenter.right, target.position - ArenaCenter.position, ArenaCenter.forward);
			Vector3 startPos = GetOppositePosition(startAngle);
			Vector3 vector = startPos + (target.position - startPos).normalized * DisappearDiameter * 4f;
			_pointer.position = vector;
			foreach (SnakeBossfightBodyPart bodyPart in _bodyParts)
			{
				bodyPart.transform.position = startPos;
				float angle = Vector3.SignedAngle(bodyPart.transform.up, vector - bodyPart.transform.position, bodyPart.transform.forward);
				bodyPart.transform.Rotate(bodyPart.transform.forward, angle);
				bodyPart.gameObject.SetActive(true);
			}
			GameObject charge = UnityEngine.Object.Instantiate(ChargeTellPrefab, startPos, Quaternion.identity, base.transform);
			if (!string.IsNullOrEmpty(ChargeSoundEffect))
			{
				AudioController.Play(ChargeSoundEffect);
			}
			float t = 0f;
			int phase = _currentPhase;
			while (t < ChargeTime)
			{
				t += Time.deltaTime;
				if (_currentPhase != phase)
				{
					_lockPointer = false;
					_lockMovement = false;
					UnityEngine.Object.Destroy(charge);
					yield break;
				}
				vector = startPos + (target.position - startPos).normalized * DisappearDiameter * 4f;
				_pointer.position = vector;
				Rotate();
				charge.transform.position = startPos + (vector - startPos).normalized * DisappearDiameter * (t / ChargeTime) / 2f;
				charge.transform.rotation = _snakeHead.transform.rotation;
				yield return null;
			}
			_stunned = false;
			_lockMovement = false;
			UnityEngine.Object.Destroy(charge);
			if (!string.IsNullOrEmpty(AttackSoundEffect))
			{
				AudioController.Play(AttackSoundEffect);
			}
			while (Vector2.Distance(ArenaCenter.position, _snakeTail.transform.position) < DisappearDiameter)
			{
				if (_currentPhase != phase)
				{
					UnityEngine.Object.Destroy(charge);
					_lockPointer = false;
					{
						foreach (SnakeBossfightBodyPart bodyPart2 in _bodyParts)
						{
							bodyPart2.gameObject.SetActive(true);
						}
						yield break;
					}
				}
				if (_stunned)
				{
					_charging = false;
					_lockPointer = false;
					yield return StartCoroutine(_Stun());
					yield break;
				}
				foreach (SnakeBossfightBodyPart bodyPart3 in _bodyParts)
				{
					bodyPart3.gameObject.SetActive(Vector2.Distance(bodyPart3.transform.position, ArenaCenter.position) < DisappearDiameter);
				}
				yield return null;
			}
			_charging = false;
			_lockPointer = false;
			float seconds = UnityEngine.Random.Range(MinWaitTime, MaxWaitTime);
			yield return new WaitForSeconds(seconds);
		}

		private IEnumerator _Stun()
		{
			_lockMovement = true;
			if (!string.IsNullOrEmpty(SpikeHitSfx))
			{
				AudioController.Play(SpikeHitSfx);
			}
			Quaternion startRot = _snakeHead.transform.rotation;
			float num = UnityEngine.Random.Range(30f, 50f);
			int num2 = ((Vector3.SignedAngle(_snakeHead.transform.position, _stunPoint, Vector3.forward) < 0f) ? 1 : (-1));
			Quaternion endRot = startRot * Quaternion.AngleAxis(num * (float)num2, Vector3.forward);
			Vector3 spineVector = (_snakeTail.transform.position - _snakeHead.transform.position).normalized;
			float initDist = Vector2.Distance(_snakeHead.transform.position, _bodyParts[1].transform.position);
			int phase = _currentPhase;
			float t = 0f;
			while (t < StunTime)
			{
				if (_currentPhase != phase)
				{
					_lockMovement = false;
					_stunned = false;
					yield break;
				}
				if (_fleeing)
				{
					break;
				}
				t += Time.deltaTime;
				_snakeHead.transform.rotation = Quaternion.Slerp(startRot, endRot, StunHeadCurve.Evaluate(t / StunTime));
				for (int i = 1; i < _bodyParts.Count; i++)
				{
					Transform transform = _bodyParts[i].transform;
					Transform transform2 = _bodyParts[i - 1].transform;
					float num3 = initDist * StunLengthCurve.Evaluate(t / StunTime);
					float num4 = 40f * StunAmpCurve.Evaluate(t / StunTime);
					float num5 = 4f * StunAmpCurve.Evaluate(t / StunTime);
					float num6 = Mathf.Sin(t * num5 + (float)i);
					Vector3 vector = transform2.position + spineVector * num3 + TransformHelper.RotateVector(spineVector, 90f).normalized * num6 * num4;
					Vector3 b = transform2.position + (vector - transform2.position).normalized * num3;
					b.z = transform.position.z;
					transform.position = Vector3.Slerp(transform.position, b, 3.3f * Time.deltaTime);
					float angle = Vector3.SignedAngle(transform.up, transform2.position - transform.position, Vector3.forward);
					transform.transform.Rotate(Vector3.forward, angle);
				}
				yield return null;
			}
			_lockMovement = false;
			yield return StartCoroutine(_ReturnToHole());
			_stunned = false;
		}

		public void Stun(Vector3 point)
		{
			if (_charging)
			{
				_stunned = true;
				_wasStunned = true;
				_stunPoint = point;
			}
		}

		private Vector3 GetCircularPosition(float angle)
		{
			angle = CheckExclusion(angle);
			Vector3 vector = new Vector3(Mathf.Cos(angle * ((float)Math.PI / 180f)), Mathf.Sin(angle * ((float)Math.PI / 180f)), 0f).normalized * SpawnDiameter;
			return ArenaCenter.position + vector;
		}

		private Vector3 GetOppositePosition(float startAngle)
		{
			float num = startAngle + 180f;
			int num2 = ((UnityEngine.Random.Range(0, 2) == 0) ? 1 : (-1));
			num += (float)(UnityEngine.Random.Range(-20, 20) * num2);
			num = CheckExclusion(num);
			Vector3 vector = new Vector3(Mathf.Cos(num * ((float)Math.PI / 180f)), Mathf.Sin(num * ((float)Math.PI / 180f)), 0f).normalized * SpawnDiameter;
			return ArenaCenter.position + vector;
		}

		private float CheckExclusion(float angle)
		{
			foreach (ExcludeAngle excludedAngle in ExcludedAngles)
			{
				if (angle > excludedAngle.Min && angle < excludedAngle.Max)
				{
					int num = ((UnityEngine.Random.Range(0, 2) == 0) ? 1 : (-1));
					angle += Mathf.Abs(excludedAngle.Max - excludedAngle.Min) * (float)num;
				}
			}
			if (angle > 360f)
			{
				angle -= 360f;
			}
			else if (angle < 0f)
			{
				angle += 360f;
			}
			return angle;
		}

		private Transform GetTarget()
		{
			Transform firstTarget = RuntimeGlobals.Camera.GetFirstTarget();
			if ((firstTarget.position - ArenaCenter.position).magnitude < DronePartCheckDiameter)
			{
				return firstTarget;
			}
			firstTarget = RuntimeGlobals.NimbatusPlayer.Drone.RootDronePart.transform;
			if ((firstTarget.position - ArenaCenter.position).magnitude < DronePartCheckDiameter)
			{
				return firstTarget;
			}
			firstTarget = RuntimeGlobals.NimbatusPlayer.GetChildrenTransforms().FirstOrDefault((Transform c) => (c.transform.position - ArenaCenter.position).magnitude < DronePartCheckDiameter);
			if (firstTarget != null)
			{
				return firstTarget;
			}
			return ArenaCenter;
		}

		private void Move()
		{
			Rotate();
			_snakeHead.transform.Translate(_snakeHead.transform.up * CurrentSpeed * Time.fixedDeltaTime, Space.World);
			for (int i = 1; i < _bodyParts.Count; i++)
			{
				if (_bodyParts[i].Attached)
				{
					Transform transform = _bodyParts[i].transform;
					Transform transform2 = _bodyParts[i - 1].transform;
					float num = Vector3.Distance(transform2.position, transform.position);
					float t = Time.fixedDeltaTime * num / MinDistance * CurrentSpeed;
					Vector3 position = Vector3.Slerp(transform.position, transform2.position, t);
					position.z = transform2.position.z + 0.01f;
					transform.position = position;
					transform.rotation = Quaternion.Slerp(transform.rotation, transform2.rotation, t);
				}
			}
		}

		private void Rotate()
		{
			_dir = _pointer.position - _snakeHead.transform.position;
			float num = Vector3.SignedAngle(_snakeHead.transform.up, _dir, Vector3.forward);
			if (Mathf.Abs(num) > 2f)
			{
				_snakeHead.transform.Rotate(Vector3.forward, CurrentTurnSpeed * (float)((num > 0f) ? 1 : (-1)) * Time.fixedDeltaTime, Space.Self);
				return;
			}
			float num2 = Mathf.Atan2(_dir.y, _dir.x) * 57.29578f;
			num2 -= 90f;
			_snakeHead.transform.rotation = Quaternion.Lerp(_snakeHead.transform.rotation, Quaternion.AngleAxis(num2, Vector3.forward), 0.5f);
		}

		private SnakeBossfightBodyPart AddHead()
		{
			SnakeBossfightBodyPart snakeBossfightBodyPart = UnityEngine.Object.Instantiate(HeadPrefab, StartPosition.position, Quaternion.identity);
			snakeBossfightBodyPart.IsHead = true;
			snakeBossfightBodyPart.Init(this);
			snakeBossfightBodyPart.transform.SetParent(base.transform);
			_bodyParts.Add(snakeBossfightBodyPart);
			return snakeBossfightBodyPart;
		}

		private void AddBodyPart(SnakeBossfightBodyPart prefab)
		{
			SnakeBossfightBodyPart snakeBossfightBodyPart = _bodyParts.Last();
			SnakeBossfightBodyPart snakeBossfightBodyPart2 = UnityEngine.Object.Instantiate(prefab, snakeBossfightBodyPart.transform.position, snakeBossfightBodyPart.transform.rotation);
			snakeBossfightBodyPart2.Init(this);
			snakeBossfightBodyPart2.transform.SetParent(base.transform);
			_bodyParts.Add(snakeBossfightBodyPart2);
		}

		private SnakeBossfightBodyPart AddTail()
		{
			SnakeBossfightBodyPart snakeBossfightBodyPart = _bodyParts.Last();
			SnakeBossfightBodyPart snakeBossfightBodyPart2 = UnityEngine.Object.Instantiate(TailPrefab, snakeBossfightBodyPart.transform.position, snakeBossfightBodyPart.transform.rotation);
			snakeBossfightBodyPart2.Init(this);
			snakeBossfightBodyPart2.transform.SetParent(base.transform);
			_bodyParts.Add(snakeBossfightBodyPart2);
			return snakeBossfightBodyPart2;
		}

		public void Attach()
		{
			_attachPointer = true;
			StartCoroutine(_StayAttached());
		}

		private IEnumerator _StayAttached()
		{
			Transform target = GetTarget();
			while (_attachPointer)
			{
				if (target == null)
				{
					target = GetTarget();
				}
				_pointer.position = new Vector3(target.position.x, target.position.y, base.transform.position.z);
				yield return null;
			}
		}
	}
}
