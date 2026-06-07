using System;
using Coffee.UIExtensions;
using DG.Tweening;
using Data.Buildings;
using Data.Quests.SubQuestEvents;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class BuildingButtonQuestHighlighter : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private GameObject _highlightPrefab;

		[SerializeField]
		private ParticleSystem _buttonHighlightParticlesPrefab;

		[Header("Null will default to immediate button parent")]
		[SerializeField]
		private GameObject _parent;

		private StartHighlightingUIBuildingButtonSubQuestEventSO _startHighlightQuestEvent;

		private StopHighlightingUIButtonSubQuestEventSO _stopHighlightQuestEvent;

		private const float ScalePerUnitSize = 0.2f;

		private bool _isHighlighting;

		private ParticleSystem _spawnedHighlightParticle;

		private UIParticle[] _highlightUIParticles;

		private BuildingObjectData _buildingObjectData;

		[Button(null, EButtonEnableMode.Always)]
		public void StartHighlighting(BuildingObjectData buildingObjectData)
		{
			if (!(buildingObjectData != _buildingObjectData))
			{
				_isHighlighting = true;
				StartHighlightingInternal();
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void StopHighlighting()
		{
			_isHighlighting = false;
			StopHighlightInternal();
		}

		private void StartHighlightingInternal()
		{
			StopHighlightInternal();
			_spawnedHighlightParticle = UnityEngine.Object.Instantiate(_buttonHighlightParticlesPrefab, _button.transform);
			if (_parent == null)
			{
				_spawnedHighlightParticle.transform.SetParent(_button.transform, worldPositionStays: false);
			}
			else
			{
				_spawnedHighlightParticle.transform.SetParent(_parent.transform, worldPositionStays: false);
			}
			RectTransform rectTransform = _button.transform as RectTransform;
			if (rectTransform != null)
			{
				Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(rectTransform);
				float scale = Mathf.Max(bounds.size.x, bounds.size.y) * 0.2f;
				_highlightUIParticles = _spawnedHighlightParticle.GetComponentsInChildren<UIParticle>();
				UIParticle[] highlightUIParticles = _highlightUIParticles;
				for (int i = 0; i < highlightUIParticles.Length; i++)
				{
					highlightUIParticles[i].scale = scale;
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
			_spawnedHighlightParticle.Play();
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

		public void SetEvents(StartHighlightingUIBuildingButtonSubQuestEventSO startEvent, StopHighlightingUIButtonSubQuestEventSO stopEvent, BuildingObjectData buildingObjectData)
		{
			_buildingObjectData = buildingObjectData;
			StopHighlightInternal();
			_startHighlightQuestEvent = startEvent;
			_stopHighlightQuestEvent = stopEvent;
			Unsubscribe();
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
			if (_isHighlighting)
			{
				StartHighlightingInternal();
			}
		}

		private void OnDestroy()
		{
			Unsubscribe();
			StopHighlightInternal();
		}

		private void Unsubscribe()
		{
			if (_startHighlightQuestEvent != null)
			{
				_startHighlightQuestEvent.OnStartHighlightingButton -= StartHighlighting;
			}
			if (_stopHighlightQuestEvent != null)
			{
				_stopHighlightQuestEvent.OnStopHighlightingButton -= StopHighlighting;
			}
		}
	}
}
