using System.Linq;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class GaugeScript : PartModifierScript<GaugeData>, IFlightUpdate, IGameLoopItem, IFlightStart, IDesignerStart
	{
		private Transform _gaugeFace;

		private Transform _gaugeIndicator;

		private Transform _gaugeIndicatorBase;

		private IInputController _input;

		private Transform _scalar;

		private Texture2D _texture;

		private string _texturePath;

		public void ApplyGaugeFaceDecalTexture()
		{
			IRendererMaterialMap rendererMaterialMap = base.PartScript.PartMaterialScript.RendererMaps.FirstOrDefault((IRendererMaterialMap x) => x.Renderer.name == "GaugeFace1");
			if (rendererMaterialMap == null)
			{
				Debug.LogError("Unable to find the gauge face renderer.");
				return;
			}
			string faceType = base.Data.FaceType;
			if (faceType != _texturePath)
			{
				if (_texture != null)
				{
					Game.Instance.PartDecalManager.UnloadDecal("Decals/Hidden/GaugeFaces/" + _texturePath);
					_texture = null;
					_texturePath = null;
				}
				if (!string.IsNullOrWhiteSpace(faceType))
				{
					_texture = Game.Instance.PartDecalManager.LoadDecal("Decals/Hidden/GaugeFaces/" + faceType);
					if (_texture != null)
					{
						_texturePath = faceType;
					}
					else
					{
						Debug.LogError("Could not load gauge face decal texture '" + faceType + "'");
					}
				}
			}
			rendererMaterialMap.DecalTexture = _texture;
			rendererMaterialMap.DecalTextureOffsetAndTiling = new Vector4(1f, 1f, 0f, 0f);
			rendererMaterialMap.DecalTextureMaterialLevels = new Vector4i(3, 2, 4, -1);
			if (!Game.InFlightScene)
			{
				rendererMaterialMap.ApplyDecalTexture();
			}
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			base.Data.PairConnectedBase();
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_input = GetInputController("Gauge");
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (!base.Data.HideIndicator)
			{
				GaugeData.GaugeRotationType rotationType = base.Data.RotationType;
				if (rotationType != GaugeData.GaugeRotationType.Indicator && rotationType == GaugeData.GaugeRotationType.Face)
				{
					_gaugeFace.localRotation = Quaternion.Euler(0f, 0f, base.Data.FaceZero + _input.Value * base.Data.Multiplier);
				}
				else
				{
					_gaugeIndicator.localRotation = Quaternion.Euler(0f, 0f, base.Data.IndicatorZero + _input.Value * base.Data.Multiplier);
				}
			}
		}

		public void FlipFaceUvs(bool newVal, bool oldVal)
		{
			if (newVal != oldVal)
			{
				Mesh mesh = _gaugeFace.GetComponent<MeshFilter>().mesh;
				Vector2[] uv = mesh.uv;
				for (int i = 0; i < uv.Length; i++)
				{
					uv[i] = new Vector2(1f - uv[i].x, uv[i].y);
				}
				mesh.SetUVs(0, uv);
				Renderer component = _gaugeFace.GetComponent<Renderer>();
				base.PartScript.PartMaterialScript.RemoveRenderer(component);
				base.PartScript.PartMaterialScript.AddRenderer(component);
				if (Game.InFlightScene)
				{
					ApplyGaugeFaceDecalTexture();
				}
			}
		}

		public override void OnConnectedToPart(PartConnectedEventData e)
		{
			base.OnConnectedToPart(e);
			GaugeBaseData modifier = e.TargetPart.GetModifier<GaugeBaseData>();
			if (modifier != null)
			{
				base.Data.PairWithBase(modifier, e.IsProcessedFirst);
			}
		}

		public void UpdateHiddenMeshes()
		{
			_gaugeFace.GetComponent<MeshRenderer>().enabled = !base.Data.HideFace;
			_gaugeIndicatorBase.GetComponent<MeshRenderer>().enabled = !base.Data.HideIndicator;
			_gaugeIndicator.GetComponent<MeshRenderer>().enabled = !base.Data.HideIndicator;
		}

		public void UpdateIndicatorLength()
		{
			_gaugeIndicator.localScale = new Vector3(1f, base.Data.IndicatorLength, 1f);
		}

		public void UpdateIndicatorType()
		{
			base.PartScript.PartMaterialScript.RemoveRenderer(_gaugeIndicator.GetComponent<Renderer>());
			Object.Destroy(_gaugeIndicator.gameObject);
			_gaugeIndicator = (Object.Instantiate(Resources.Load("Craft/Parts/Prefabs/Gauges/" + base.Data.IndicatorType), _gaugeIndicatorBase) as GameObject).transform;
			base.PartScript.PartMaterialScript.AddRenderer(_gaugeIndicator.GetComponent<Renderer>());
			UpdateZeroPosition();
			UpdateIndicatorLength();
			UpdateHiddenMeshes();
		}

		public void UpdateScale()
		{
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 0.2f * base.Data.Scale;
			}
			_scalar.localScale = new Vector3(base.Data.Scale, base.Data.Scale, 1f);
			UpdateIndicatorLength();
		}

		public void UpdateZeroPosition()
		{
			_gaugeIndicator.localRotation = Quaternion.Euler(0f, 0f, base.Data.IndicatorZero);
			_gaugeFace.localRotation = Quaternion.Euler(0f, 0f, base.Data.FaceZero);
		}

		protected virtual void OnDestroy()
		{
			if (_texturePath != null)
			{
				Game.Instance.PartDecalManager.UnloadDecal("Decals/Hidden/GaugeFaces/" + _texturePath);
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_scalar = Utilities.FindFirstGameObjectMyselfOrChildren("Scalar", base.gameObject).transform;
			_gaugeFace = Utilities.FindFirstGameObjectMyselfOrChildren("GaugeFace1", _scalar.gameObject).transform;
			_gaugeIndicatorBase = Utilities.FindFirstGameObjectMyselfOrChildren("GaugeIndicatorBase", _scalar.gameObject).transform;
			_gaugeIndicator = Utilities.FindFirstGameObjectMyselfOrChildren("GaugeIndicator", _scalar.gameObject).transform;
			UpdateIndicatorType();
			UpdateHiddenMeshes();
			ApplyGaugeFaceDecalTexture();
			UpdateScale();
			UpdateZeroPosition();
			_gaugeIndicatorBase.localPosition += base.Data.IndicatorOffset / 50f;
			if (base.Data.FlipFace)
			{
				FlipFaceUvs(newVal: true, oldVal: false);
			}
		}
	}
}
