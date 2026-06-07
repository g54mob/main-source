using System.Collections.Generic;
using Easing;
using Factory.Pools;
using UnityEngine;

namespace Motorways.Views
{
	public class DynamicRoadMesh : MonoBehaviour, IReusable
	{
		[SerializeField]
		private LineRenderer _outlineRenderer;

		[SerializeField]
		private LineRenderer _roadRenderer;

		[SerializeField]
		private LineRenderer _cursorRenderer;

		[SerializeField]
		private Material _activeMaterial;

		[SerializeField]
		private Material _mothballedMaterial;

		[SerializeField]
		private int EndCapResolution = 16;

		[SerializeField]
		private VisualConstantsData _visualConstants;

		private float _cursorWidthFactor = -1f;

		private float _outlineWidthFactor = -1f;

		private float _roadWidthFactor = -1f;

		private RoadState _roadState = RoadState.Active;

		private const float OutlineWidth = 1.2f;

		private const float InnerWidth = 0.8f;

		private static readonly int ShaderRotationId = Shader.PropertyToID("_Rotation");

		private static readonly int MinimumAlphaId = Shader.PropertyToID("_MinimumAlpha");

		private readonly TweenFloat _alphaTween = new TweenFloat();

		private PermanenceProgressRoadView _permanenceProgressRoadView;

		private TileView _tileView;

		private MaterialPropertyBlock _materialPropertyBlock;

		public bool HasEndCap
		{
			get
			{
				return _outlineRenderer.numCapVertices > 0;
			}
			set
			{
				_outlineRenderer.numCapVertices = (value ? EndCapResolution : 0);
				_roadRenderer.numCapVertices = (value ? EndCapResolution : 0);
				_cursorRenderer.numCapVertices = (value ? EndCapResolution : 0);
			}
		}

		public float CursorWidthFactor
		{
			get
			{
				return _cursorWidthFactor;
			}
			set
			{
				_cursorWidthFactor = value;
				float num = value * 1.2f;
				_cursorRenderer.startWidth = num;
				_cursorRenderer.endWidth = num;
			}
		}

		public float OutlineWidthFactor
		{
			get
			{
				return _outlineWidthFactor;
			}
			set
			{
				_outlineWidthFactor = value;
				float num = _visualConstants.OutlineAppearCurve.Evaluate(value) * 1.2f;
				_outlineRenderer.startWidth = num;
				_outlineRenderer.endWidth = num;
			}
		}

		public float RoadWidthFactor
		{
			get
			{
				return _roadWidthFactor;
			}
			set
			{
				_roadWidthFactor = value;
				float num = _visualConstants.InnerAppearCurve.Evaluate(value) * 0.8f;
				_roadRenderer.startWidth = num;
				_roadRenderer.endWidth = num;
			}
		}

		public RoadState RoadState
		{
			get
			{
				return _roadState;
			}
			set
			{
				_roadState = value;
				if (_roadState != RoadState.None)
				{
					_roadRenderer.sharedMaterial = (((_roadState & RoadState.VisiblyActive) != RoadState.None) ? _activeMaterial : _mothballedMaterial);
				}
			}
		}

		private void Awake()
		{
			_materialPropertyBlock = new MaterialPropertyBlock();
		}

		public void Initialize(TileView tileView, PermanenceZoneTextureLibrary permanenceZoneTextureLibrary, bool hasPermanenceProgressView)
		{
			_tileView = tileView;
			_permanenceProgressRoadView = new PermanenceProgressRoadView(_materialPropertyBlock, _roadRenderer, _tileView, permanenceZoneTextureLibrary, _visualConstants, hasPermanenceProgressView);
			UpdatePermanenceShaderValues();
		}

		public void UpdatePermanenceShaderValues()
		{
			_permanenceProgressRoadView.UpdatePermanenceValues();
		}

		public void SetPermanenceVisibility(bool hasPermanenceProgressView)
		{
			_permanenceProgressRoadView?.SetPermanenceVisibility(hasPermanenceProgressView);
		}

		public void SetPathPoints(List<Vector2> path)
		{
			_cursorRenderer.positionCount = path.Count;
			_outlineRenderer.positionCount = path.Count;
			_roadRenderer.positionCount = path.Count;
			for (int i = 0; i < path.Count; i++)
			{
				_cursorRenderer.SetPosition(i, path[i]);
				_outlineRenderer.SetPosition(i, path[i]);
				_roadRenderer.SetPosition(i, path[i]);
			}
		}

		public void SetCursorRendererHazardStripesAngle(float angle = 0f)
		{
			_cursorRenderer.material.SetFloat(ShaderRotationId, angle);
		}

		public void SetCursorRendererHazardStripesEnabled(bool stripesEnabled, bool tween)
		{
			float num = (stripesEnabled ? 0f : 1f);
			if (tween)
			{
				float start = _cursorRenderer.material.GetFloat(MinimumAlphaId);
				_alphaTween.Start(start, num, 0.3f, Easings.Functions.CubicEaseOut);
			}
			else
			{
				_cursorRenderer.material.SetFloat(MinimumAlphaId, num);
			}
		}

		private void Update()
		{
			if (_alphaTween.IsActive)
			{
				_cursorRenderer.material.SetFloat(MinimumAlphaId, _alphaTween.Tick(Time.deltaTime));
			}
		}

		public void SetCursorRendererFadeout(float startFade, float endFade, float endAlpha)
		{
			Gradient gradient = new Gradient();
			gradient.SetKeys(_cursorRenderer.colorGradient.colorKeys, new GradientAlphaKey[3]
			{
				new GradientAlphaKey(1f, 0f),
				new GradientAlphaKey(1f, startFade),
				new GradientAlphaKey(endAlpha, endFade)
			});
			_cursorRenderer.colorGradient = gradient;
		}

		public void Reset()
		{
			_cursorWidthFactor = -1f;
			_outlineWidthFactor = -1f;
			_roadWidthFactor = -1f;
			_roadState = RoadState.Active;
			_roadRenderer.sharedMaterial = _activeMaterial;
			_permanenceProgressRoadView = null;
		}
	}
}
