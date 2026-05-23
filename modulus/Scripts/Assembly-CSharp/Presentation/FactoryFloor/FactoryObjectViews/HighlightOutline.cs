using System.Collections.Generic;
using Data.Variables;
using Linework.WideOutline;
using NaughtyAttributes;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews
{
	public class HighlightOutline : MonoBehaviour
	{
		[SerializeField]
		private FactoryObjectView _objectView;

		[SerializeField]
		private WideOutlineSettings _outlineSetting;

		[SerializeField]
		private List<MeshRenderer> _affectedRenderers = new List<MeshRenderer>();

		[SerializeField]
		private BoolVariableSO _uiVisibility;

		private Dictionary<MeshRenderer, uint> _rendOriginalLayers;

		private bool _isHighlightingOutline;

		private const uint OUTLINE_LAYER = 2u;

		public void SetOutLineSetting(WideOutlineSettings outlineSetting)
		{
			_outlineSetting = outlineSetting;
		}

		private void Awake()
		{
			Initialize();
		}

		private void OnDestroy()
		{
			UnInitialize();
		}

		protected virtual void Initialize()
		{
			FillRendOriginalLayers();
			_objectView.ObjectSelected += Show;
			_objectView.ObjectDeSelected += Hide;
			_objectView.OnHideView += OnHideView;
			if (_uiVisibility != null)
			{
				_uiVisibility.ValueChanged += HandleUIVisibilityChanged;
			}
		}

		protected virtual void UnInitialize()
		{
			_objectView.ObjectSelected -= Show;
			_objectView.ObjectDeSelected -= Hide;
			_objectView.OnHideView -= OnHideView;
			if (_uiVisibility != null)
			{
				_uiVisibility.ValueChanged -= HandleUIVisibilityChanged;
			}
			_isHighlightingOutline = false;
		}

		protected void FillRendOriginalLayers()
		{
			_rendOriginalLayers = new Dictionary<MeshRenderer, uint>();
			foreach (MeshRenderer affectedRenderer in _affectedRenderers)
			{
				_rendOriginalLayers.Add(affectedRenderer, affectedRenderer.renderingLayerMask);
			}
		}

		private void OnHideView(bool wasPreview)
		{
			Hide();
		}

		public void Show()
		{
			if (_uiVisibility != null && !_uiVisibility.Value)
			{
				return;
			}
			_isHighlightingOutline = true;
			foreach (MeshRenderer affectedRenderer in _affectedRenderers)
			{
				if (affectedRenderer != null)
				{
					affectedRenderer.renderingLayerMask = 2u;
				}
			}
		}

		public void Hide()
		{
			_isHighlightingOutline = false;
			foreach (MeshRenderer affectedRenderer in _affectedRenderers)
			{
				if (affectedRenderer != null)
				{
					affectedRenderer.renderingLayerMask = _rendOriginalLayers[affectedRenderer];
				}
			}
		}

		public void SetColor(Color color)
		{
			_outlineSetting.Outlines[0].color = color;
		}

		private void HandleUIVisibilityChanged(bool isVisible)
		{
			if (!isVisible && _isHighlightingOutline)
			{
				Hide();
			}
		}

		[Button("Auto fill mesh renderers", EButtonEnableMode.Always)]
		protected void AutofillRenderers()
		{
			_affectedRenderers.Clear();
			MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer item in componentsInChildren)
			{
				_affectedRenderers.Add(item);
			}
		}

		[Button("Auto fill view", EButtonEnableMode.Always)]
		private void AutofillView()
		{
			_objectView = GetComponent<FactoryObjectView>();
		}
	}
}
