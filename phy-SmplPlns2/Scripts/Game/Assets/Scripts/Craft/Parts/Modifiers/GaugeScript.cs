using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Paint;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class GaugeScript : PartModifierScript
	{
		private class RuntimeGaugeIndicator
		{
			public GaugeData.GaugeIndicatorData Data { get; set; }

			public Func<float> Input { get; set; }

			public Transform Transform { get; set; }

			public RuntimeGaugeIndicator(GaugeData.GaugeIndicatorData data, Transform transform, Func<float> input)
			{
				Data = data;
				Transform = transform;
				Input = input;
			}
		}

		private Func<float> _faceInput;

		private MeshRenderer _gaugeBaseRenderer;

		private Transform _gaugeFace;

		private Material _gaugeFaceMaterial;

		private Mesh _gaugeFaceMesh;

		private MeshRenderer _gaugeFaceRenderer;

		private GameObject _gaugeIndicatorBase;

		private Transform _gaugeIndicatorPivot;

		private Transform _gaugeTrim;

		private MeshRenderer _gaugeTrimRenderer;

		private List<RuntimeGaugeIndicator> _indicators = new List<RuntimeGaugeIndicator>();

		private Transform _scalar;

		public GaugeData Gauge { get; private set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public override void GetRenderersForHighlight(ICollection<Renderer> renderers)
		{
			if (!Gauge.HideBase)
			{
				renderers.Add(_gaugeBaseRenderer);
			}
			if (!Gauge.HideFace)
			{
				renderers.Add(_gaugeFaceRenderer);
			}
			if (!Gauge.HideTrim)
			{
				renderers.Add(_gaugeTrimRenderer);
			}
		}

		public void Initialize(GaugeData gauge)
		{
			Gauge = gauge;
			_gaugeFace = Utilities.FindFirstGameObjectMyselfOrChildren("GaugeFace", base.gameObject).transform;
			_gaugeFaceRenderer = _gaugeFace.GetComponent<MeshRenderer>();
			_gaugeFaceRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
			_gaugeFaceRenderer.gameObject.layer = 21;
			_gaugeFaceMesh = _gaugeFaceRenderer.GetComponent<MeshFilter>().mesh;
			base.PartScript.PartMaterialScript.ApplyReservedPaintStyle(PaintStyle.AlbedoTextureSupersampledWithMipmapBias, _gaugeFaceMesh);
			_gaugeFaceMaterial = base.PartScript.Aircraft.Theme.RequestDefaultPartMaterialInstance();
			_gaugeFaceMaterial.SetFloat("_SupersampleMipmapBias", -1f);
			_gaugeFaceRenderer.material = _gaugeFaceMaterial;
			_gaugeBaseRenderer = Utilities.FindFirstGameObjectMyselfOrChildren("GaugeBase", base.gameObject).GetComponent<MeshRenderer>();
			_gaugeIndicatorPivot = Utilities.FindFirstGameObjectMyselfOrChildren("IndicatorPivot", base.gameObject).transform;
			_gaugeIndicatorBase = Utilities.FindFirstGameObjectMyselfOrChildren("GaugeIndicatorBase", base.gameObject);
			_gaugeTrim = Utilities.FindFirstGameObjectMyselfOrChildren("Trim", base.gameObject).transform;
			_scalar = Utilities.FindFirstGameObjectMyselfOrChildren("Scalar", base.gameObject).transform;
		}

		public void OnGaugeFaceChanged(Texture2D gaugeFaceTexture)
		{
			_gaugeFaceMaterial.mainTexture = gaugeFaceTexture;
			SetFaceEmission(Gauge.FaceEmissionDay, Gauge.FaceEmissionNight);
		}

		public void OnHiddenMeshChanged(bool hideBase, bool hideFace, bool hideTrim)
		{
			_gaugeBaseRenderer.enabled = !hideBase;
			_gaugeFaceRenderer.enabled = !hideFace;
			_gaugeTrimRenderer.enabled = !hideTrim;
		}

		public void OnIndicatorChanged()
		{
			foreach (RuntimeGaugeIndicator indicator in _indicators)
			{
				GameObject gameObject = indicator.Transform.gameObject;
				base.PartScript.PartMaterialScript.RemoveRenderer(gameObject.GetComponent<MeshRenderer>(), destroy: true);
				UnityEngine.Object.Destroy(gameObject);
			}
			_indicators.Clear();
			for (int i = 0; i < Gauge.Indicators.Length; i++)
			{
				GaugeData.GaugeIndicatorData gaugeIndicatorData = Gauge.Indicators[i];
				if (gaugeIndicatorData.NeedleType != GaugeData.IndicatorType.None)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(Resources.Load("Craft/Parts/Gauge/" + gaugeIndicatorData.NeedleType), _gaugeIndicatorPivot) as GameObject;
					gameObject2.name = $"{gaugeIndicatorData.NeedleType}-{i}";
					MeshRenderer component = gameObject2.GetComponent<MeshRenderer>();
					PartMaterialScript.RendererMaterialMap rendererMap = base.PartScript.PartMaterialScript.AddRenderer(component);
					base.PartScript.PartMaterialScript.InitializeMaterial(rendererMap);
					_indicators.Add(new RuntimeGaugeIndicator(gaugeIndicatorData, gameObject2.transform, null));
				}
			}
			if (_indicators.Count < 1 && _gaugeIndicatorBase.activeSelf)
			{
				_gaugeIndicatorBase.SetActive(value: false);
			}
			else if (_indicators.Count > 0 && !_gaugeIndicatorBase.activeSelf)
			{
				_gaugeIndicatorBase.SetActive(value: true);
			}
			OnZeroChanged();
		}

		public void OnScaleChanged(float scale)
		{
			_scalar.localScale = new Vector3(scale, 1f, scale);
		}

		public void OnTrimChanged(string trim)
		{
			if (_gaugeTrim.childCount > 0)
			{
				GameObject gameObject = _gaugeTrim.GetChild(0).gameObject;
				base.PartScript.PartMaterialScript.RemoveRenderer(gameObject.GetComponent<MeshRenderer>(), destroy: true);
				UnityEngine.Object.Destroy(_gaugeTrim.GetChild(0).gameObject);
			}
			GameObject gameObject2 = UnityEngine.Object.Instantiate(Resources.Load("Craft/Parts/Gauge/" + trim), _gaugeTrim) as GameObject;
			gameObject2.name = trim;
			_gaugeTrimRenderer = gameObject2.GetComponent<MeshRenderer>();
			PartMaterialScript.RendererMaterialMap rendererMap = base.PartScript.PartMaterialScript.AddRenderer(_gaugeTrimRenderer);
			base.PartScript.PartMaterialScript.InitializeMaterial(rendererMap);
			_gaugeTrimRenderer.enabled = !Gauge.HideTrim;
		}

		public void OnZeroChanged()
		{
			_gaugeFace.localRotation = Quaternion.Euler(0f, Gauge.FaceZero, 0f);
			foreach (RuntimeGaugeIndicator indicator in _indicators)
			{
				indicator.Transform.localRotation = Quaternion.Euler(0f, indicator.Data.Zero, 0f);
			}
		}

		public void SetFaceEmission(float emissionDay, float emissionNight)
		{
			_gaugeFaceMaterial.SetFloat("_EmissiveOverride", emissionDay);
			_gaugeFaceMaterial.SetFloat("_EmissiveOverrideNight", emissionNight);
		}

		protected virtual void OnDestroy()
		{
			if (_gaugeFaceMaterial != null)
			{
				base.PartScript.Aircraft.Theme.ReleaseDefaultPartMaterialInstance(_gaugeFaceMaterial);
				_gaugeFaceMaterial = null;
				_gaugeFaceRenderer.material = null;
			}
			if (_gaugeFaceMesh != null)
			{
				UnityEngine.Object.Destroy(_gaugeFaceMesh);
				_gaugeFaceMesh = null;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocal);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			GaugeData.GaugeRotationType rotationType = Gauge.RotationType;
			if (rotationType != GaugeData.GaugeRotationType.Indicator && rotationType == GaugeData.GaugeRotationType.Face)
			{
				_gaugeFace.localRotation = Quaternion.Euler(0f, Gauge.FaceZero + _faceInput() * Gauge.FaceMultiplier * (float)((!Gauge.FaceInvert) ? 1 : (-1)), 0f);
				return;
			}
			foreach (RuntimeGaugeIndicator indicator in _indicators)
			{
				indicator.Transform.localRotation = Quaternion.Euler(0f, indicator.Data.Zero + indicator.Input() * indicator.Data.Multiplier * (float)((!indicator.Data.Invert) ? 1 : (-1)), 0f);
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_faceInput = base.PartScript.Aircraft.Controls.GetAxisGetter(Gauge.FaceInput, -1f, base.PartScript);
			if (loadContext != CraftLoadContext.Designer)
			{
				for (int i = 0; i < _indicators.Count; i++)
				{
					_indicators[i].Input = base.PartScript.Aircraft.Controls.GetAxisGetter(_indicators[i].Data.Input, -1f, base.PartScript);
				}
			}
			return UniTask.CompletedTask;
		}
	}
}
