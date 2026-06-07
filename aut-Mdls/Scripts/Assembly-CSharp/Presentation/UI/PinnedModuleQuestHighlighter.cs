using System;
using Coffee.UIExtensions;
using DG.Tweening;
using Data.Quests.SubQuestEvents;
using Presentation.FactoryFloor.PinnedBar;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class PinnedModuleQuestHighlighter : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private GameObject _highlightPrefab;

		[SerializeField]
		private ParticleSystem _buttonHighlightParticlesPrefab;

		[SerializeField]
		private PinnedModuleButton _pinnedModuleButton;

		[Header("Null will default to immediate button parent")]
		[SerializeField]
		private GameObject _parent;

		private StartHighlightingUIPinnedModuleSubQuestEventSO _startHighlightQuestEvent;

		private StopHighlightingUIButtonSubQuestEventSO _stopHighlightQuestEvent;

		private const float ScalePerUnitSize = 0.2f;

		private bool _isHighlighting;

		private ParticleSystem _spawnedHighlightParticle;

		private UIParticle[] _highlightUIParticles;

		private ModuleViewerData _moduleViewerData;

		private int _shapeIndex;

		public bool IsHighlighting => _isHighlighting;

		public static event Action<bool> OnPinnedModuleHighlightChanged;

		private void StartHighlighting(ModuleViewerData moduleViewerData, int shapeIndex)
		{
			if (moduleViewerData == _moduleViewerData && shapeIndex == _shapeIndex)
			{
				_isHighlighting = true;
				PinnedModuleQuestHighlighter.OnPinnedModuleHighlightChanged(obj: true);
				StartHighlightingInternal();
			}
		}

		private void StopHighlighting()
		{
			_isHighlighting = false;
			PinnedModuleQuestHighlighter.OnPinnedModuleHighlightChanged(obj: false);
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

		public void SetEvents(StartHighlightingUIPinnedModuleSubQuestEventSO startEvent, StopHighlightingUIButtonSubQuestEventSO stopEvent, ModuleViewerData moduleViewerData, int shapeIndex)
		{
			_moduleViewerData = moduleViewerData;
			_shapeIndex = shapeIndex;
			StopHighlightInternal();
			_startHighlightQuestEvent = startEvent;
			_stopHighlightQuestEvent = stopEvent;
			RemoveAllEvents();
			if (_startHighlightQuestEvent != null)
			{
				_startHighlightQuestEvent.OnStartHighlightingPinnedModule += StartHighlighting;
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
			RemoveAllEvents();
			StopHighlightInternal();
		}

		private void RemoveAllEvents()
		{
			if (_startHighlightQuestEvent != null)
			{
				_startHighlightQuestEvent.OnStartHighlightingPinnedModule -= StartHighlighting;
			}
			if (_stopHighlightQuestEvent != null)
			{
				_stopHighlightQuestEvent.OnStopHighlightingButton -= StopHighlighting;
			}
		}

		static PinnedModuleQuestHighlighter()
		{
			PinnedModuleQuestHighlighter.OnPinnedModuleHighlightChanged = delegate
			{
			};
		}
	}
}
