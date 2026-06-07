using System.Linq;
using DG.Tweening;
using HighlightPlus;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartHighlightEffect
	{
		private HighlightEffect _highlightEffect;

		private PartScript _part;

		private bool _refresh;

		public bool IsHighlighted => _highlightEffect?.highlighted ?? false;

		public PartHighlightEffect(PartScript part)
		{
			_part = part;
		}

		public void DisableHighlight()
		{
			_refresh = false;
			if (IsHighlighted)
			{
				_highlightEffect.highlighted = false;
			}
		}

		public void EnableHighlight(float opacity, Color32 color, int sortingPriority = 0)
		{
			if (_highlightEffect == null)
			{
				GameObject gameObject = new GameObject("Highlight");
				gameObject.transform.SetParent(_part.transform, worldPositionStays: false);
				_highlightEffect = gameObject.AddComponent<HighlightEffect>();
				_highlightEffect.outlineVisibility = Visibility.AlwaysOnTop;
				_highlightEffect.camerasLayerMask = 1;
				_part.Aircraft.OnAircraftStructureChanged += Aircraft_OnAircraftStructureChanged;
			}
			if (!IsHighlighted || opacity != _highlightEffect.outline)
			{
				_highlightEffect.outlineWidth = 0f;
				DOTween.To(() => _highlightEffect.outlineWidth, delegate(float x)
				{
					_highlightEffect.outlineWidth = x;
				}, 0.25f, 0.25f).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true);
			}
			_highlightEffect.outlineQuality = HighlightPlus.QualityLevel.High;
			_highlightEffect.outline = opacity;
			_highlightEffect.outlineColor = color;
			_highlightEffect.sortingPriority = sortingPriority;
			_refresh = true;
		}

		public void LateUpdate()
		{
			if (_refresh)
			{
				_refresh = false;
				_highlightEffect.Refresh(discardCachedMeshes: true);
				HighlightEffect highlightEffect = _highlightEffect;
				Transform transform = _highlightEffect.transform;
				Renderer[] renderers = _part.PartMaterialScript.RendererMaps.Select((PartMaterialScript.RendererMaterialMap x) => x.Renderer).ToArray();
				highlightEffect.SetTargets(transform, renderers);
				_highlightEffect.highlighted = true;
			}
		}

		public void OnDestroy()
		{
			if (_highlightEffect != null)
			{
				_part.Aircraft.OnAircraftStructureChanged -= Aircraft_OnAircraftStructureChanged;
			}
		}

		public void Refresh()
		{
			_refresh = IsHighlighted;
		}

		private void Aircraft_OnAircraftStructureChanged()
		{
			_refresh = IsHighlighted;
		}
	}
}
