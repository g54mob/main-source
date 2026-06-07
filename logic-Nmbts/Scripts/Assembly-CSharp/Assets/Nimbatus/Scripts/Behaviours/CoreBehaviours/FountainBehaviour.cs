using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class FountainBehaviour : CoreBehaviour
	{
		public float Height;

		public float Width;

		public float LerpSpeed;

		public LayerMask HitLayer;

		public LineRenderer LineRenderer;

		public GameObject ParticleEffect;

		public GameObject ExitParticles;

		public float ActiveTimeMax;

		public float ActiveTimeMin;

		public float PauseTime;

		public float Damage;

		public float Force;

		public float TemperatureChange;

		public List<EChemicalState> DeactivateOnChemicalState = new List<EChemicalState>();

		public bool HasSound;

		[ShowIf("HasSound", true)]
		public string SoundLoopIdle;

		[ShowIf("HasSound", true)]
		public string SoundLoopActive;

		private bool _stopCoroutine;

		private float _targetHeight;

		private float _currentHeight;

		private bool _isDisabled;

		private float _activeTime;

		private RaycastHit[] _hit;

		protected override void OnInit()
		{
			OwnWorldObject.StartCoroutine(FountainCoroutine());
			if (HasSound)
			{
				OwnWorldObject.StartSoundLoop(SoundLoopIdle);
			}
			_activeTime = Random.Range(ActiveTimeMin, ActiveTimeMax);
			_isDisabled = false;
		}

		private IEnumerator FountainCoroutine()
		{
			_stopCoroutine = false;
			while (!_stopCoroutine)
			{
				ParticleEffect.SetActive(true);
				float currentTime = 0f;
				OwnWorldObject.StopActiveSoundLoop();
				OwnWorldObject.StartSoundLoop(SoundLoopActive);
				while (currentTime < _activeTime)
				{
					if (_isDisabled)
					{
						yield return true;
						break;
					}
					yield return new WaitForFixedUpdate();
					currentTime += Time.deltaTime;
					_targetHeight = Height;
					_hit = new RaycastHit[3];
					for (int i = 0; i < _hit.Length; i++)
					{
						Debug.DrawRay(LineRenderer.transform.position + (i - 1) * LineRenderer.transform.right * Width / 2f, LineRenderer.transform.up * _currentHeight, Color.blue);
						if (Physics.Raycast(LineRenderer.transform.position + (i - 1) * LineRenderer.transform.right * Width / 2f, LineRenderer.transform.up, out _hit[i], _currentHeight, HitLayer))
						{
							if (_hit[i].rigidbody != null)
							{
								_hit[i].rigidbody.AddForceAtPosition(OwnWorldObject.transform.up * Force * Time.fixedDeltaTime, _hit[i].point);
							}
							_targetHeight = (_currentHeight = _hit[i].distance);
							_hit[i].collider.gameObject.SendMessage("TakeDamage", new DamageInformation(Damage * Time.fixedDeltaTime, EDamageReason.Environment, OwnWorldObject), SendMessageOptions.DontRequireReceiver);
							_hit[i].collider.gameObject.SendMessage("ChangeTemperatureBy", TemperatureChange * Time.fixedDeltaTime, SendMessageOptions.DontRequireReceiver);
						}
					}
					if (OwnWorldObject.HealthPool != null && DeactivateOnChemicalState.Contains(OwnWorldObject.HealthPool.CurrentState))
					{
						currentTime = _activeTime;
					}
				}
				_targetHeight = 0f;
				OwnWorldObject.StopActiveSoundLoop();
				OwnWorldObject.StartSoundLoop(SoundLoopIdle);
				yield return new WaitForSeconds(PauseTime);
			}
		}

		protected override void OnUpdate()
		{
			if (OwnWorldObject.HealthPool != null && DeactivateOnChemicalState.Contains(OwnWorldObject.HealthPool.CurrentState))
			{
				_isDisabled = true;
			}
			else
			{
				_isDisabled = false;
			}
			_currentHeight = Mathf.Lerp(_currentHeight, _targetHeight, Time.deltaTime * LerpSpeed);
			LineRenderer.SetPosition(0, Vector3.zero);
			LineRenderer.SetPosition(1, Vector3.up * _currentHeight);
			ParticleEffect.transform.position = LineRenderer.transform.position + LineRenderer.transform.up * _currentHeight;
			if (_currentHeight <= 0f)
			{
				LineRenderer.enabled = false;
			}
			else
			{
				LineRenderer.enabled = true;
			}
			if (_isDisabled)
			{
				LineRenderer.enabled = false;
				ParticleEffect.SetActive(false);
				ExitParticles.SetActive(false);
			}
			else
			{
				ParticleEffect.SetActive(true);
				ExitParticles.SetActive(true);
			}
		}

		protected override void OnRelease()
		{
			_stopCoroutine = false;
		}
	}
}
