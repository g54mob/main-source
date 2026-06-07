using System;
using Coffee.UIExtensions;
using DG.Tweening;
using Data.Quests.SubQuestEvents;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class ButtonQuestHighlighter : MonoBehaviour
	{
		[SerializeField]
		private StartHighlightingUIButtonSubQuestEventSO _startHighlightQuestEvent;

		[SerializeField]
		private StopHighlightingUIButtonSubQuestEventSO _stopHighlightQuestEvent;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private GameObject _highlightPrefab;

		[SerializeField]
		private ParticleSystem _buttonHighlightParticlesPrefab;

		[SerializeField]
		private GameObject _parent;

		[SerializeField]
		private bool _disabled;

		private const float ScalePerUnitSize = 0.2f;

		private bool _isHighlighting;

		private ParticleSystem _spawnedHighlightParticle;

		private UIParticle[] _highlightUIParticles;

		[Button(null, EButtonEnableMode.Always)]
		public void StartHighlighting()
		{
			if (!_disabled)
			{
				_isHighlighting = true;
				StartHighlightingInternal();
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void StopHighlighting()
		{
			if (!_disabled)
			{
				_isHighlighting = false;
				StopHighlightInternal();
			}
		}

		private void StartHighlightingInternal()
		{
			StopHighlightInternal();
			if (_buttonHighlightParticlesPrefab != null)
			{
				_spawnedHighlightParticle = UnityEngine.Object.Instantiate(_buttonHighlightParticlesPrefab, _button.transform);
			}
			if (_parent == null)
			{
				_spawnedHighlightParticle?.transform.SetParent(_button.transform, worldPositionStays: false);
			}
			else
			{
				_spawnedHighlightParticle?.transform.SetParent(_parent.transform, worldPositionStays: false);
			}
			RectTransform rectTransform = _button.transform as RectTransform;
			if (rectTransform != null)
			{
				Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(rectTransform);
				float scale = Mathf.Max(bounds.size.x, bounds.size.y) * 0.2f;
				_highlightUIParticles = _spawnedHighlightParticle?.GetComponentsInChildren<UIParticle>();
				if (_highlightUIParticles != null)
				{
					UIParticle[] highlightUIParticles = _highlightUIParticles;
					for (int i = 0; i < highlightUIParticles.Length; i++)
					{
						highlightUIParticles[i].scale = scale;
					}
				}
			}
			if (_highlightPrefab != null)
			{
				CanvasGroup canvasGroup = _highlightPrefab.GetComponent<CanvasGroup>();
				if (canvasGroup == null)
				{
					canvasGroup = _highlightPrefab.AddComponent<CanvasGroup>();
				}
				canvasGroup.DOKill();
				canvasGroup.DOFade(1f, 1.5f);
			}
			_spawnedHighlightParticle?.Play();
		}

		private void StopHighlightInternal()
		{
			if (_highlightPrefab != null)
			{
				CanvasGroup component = _highlightPrefab.GetComponent<CanvasGroup>();
				if (component != null)
				{
					component.DOKill();
					component.DOFade(0f, 0.5f);
				}
			}
			if (!(_spawnedHighlightParticle == null))
			{
				_spawnedHighlightParticle.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
				UnityEngine.Object.Destroy(_spawnedHighlightParticle.gameObject);
				_spawnedHighlightParticle = null;
				_highlightUIParticles = Array.Empty<UIParticle>();
			}
		}

		public void SetEvents(StartHighlightingUIButtonSubQuestEventSO startEvent, StopHighlightingUIButtonSubQuestEventSO stopEvent)
		{
			StopHighlightInternal();
			_startHighlightQuestEvent = startEvent;
			_stopHighlightQuestEvent = stopEvent;
			if (_startHighlightQuestEvent != null)
			{
				_startHighlightQuestEvent.OnStartHighlightingButton += StartHighlighting;
			}
			if (_stopHighlightQuestEvent != null)
			{
				_stopHighlightQuestEvent.OnStopHighlightingButton += StopHighlighting;
			}
		}

		private void Awake()
		{
			if (_startHighlightQuestEvent != null)
			{
				_startHighlightQuestEvent.OnStartHighlightingButton += StartHighlighting;
			}
			if (_stopHighlightQuestEvent != null)
			{
				_stopHighlightQuestEvent.OnStopHighlightingButton += StopHighlighting;
			}
			if (_isHighlighting)
			{
				StartHighlightingInternal();
			}
		}

		private void OnDestroy()
		{
			if (_startHighlightQuestEvent != null)
			{
				_startHighlightQuestEvent.OnStartHighlightingButton -= StartHighlighting;
			}
			if (_stopHighlightQuestEvent != null)
			{
				_stopHighlightQuestEvent.OnStopHighlightingButton -= StopHighlighting;
			}
			StopHighlightInternal();
		}
	}
}
