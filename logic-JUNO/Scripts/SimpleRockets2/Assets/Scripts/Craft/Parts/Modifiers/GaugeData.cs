using System;
using System.Collections.Generic;
using System.Linq;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Parts.Decals;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Gauge")]
	[PartModifierTypeId("Gauge")]
	public class GaugeData : PartModifierData<GaugeScript>
	{
		[Serializable]
		public enum GaugeRotationType
		{
			Indicator = 0,
			Face = 10
		}

		public const string GaugeFaceTexturesRootPath = "Decals/Hidden/GaugeFaces/";

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "None" }, Label = "Face Type", Order = 5, Tooltip = "The texture to use for the face of the gauge.")]
		private string _faceType;

		[SerializeField]
		[DesignerPropertySlider(-180f, 180f, 73, Label = "Face Zero", Order = 21, Tooltip = "Rotates the background marks to place the zero at alternative points.")]
		private float _faceZero;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Flip Face", Order = 45, Tooltip = "Flips the background marks of the gauge.")]
		private bool _flipFace;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Hide Face", Order = 50, Tooltip = "Hides the background marks of the gauge.")]
		private bool _hideFace;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Hide Indicator", Order = 60, Tooltip = "Hides the indicator.")]
		private bool _hideIndicator;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 1.5f, 21, Label = "Indicator Length", Order = 16, Tooltip = "Changes the length of the indicator.")]
		private float _indicatorLength = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _indicatorOffset = Vector3.zero;

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "Indicator1", "Indicator2", "Indicator3", "Indicator4", "Indicator5" }, Label = "Indicator Needle", Order = 10, Tooltip = "Defines the style of the indicator.")]
		private string _indicatorType = "Indicator1";

		[SerializeField]
		[DesignerPropertySlider(-180f, 180f, 73, Label = "Indicator Zero", Order = 20, Tooltip = "Defines the starting position of the indicator.")]
		private float _indicatorZero;

		[SerializeField]
		[DesignerPropertySlider(0f, 360f, 37, Label = "Input Multiplier", Order = 30, Tooltip = "Scales the range of the input times the indicated multiplier.")]
		private float _multiplier = 360f;

		[NonSerialized]
		private GaugeBaseData _pairedBase;

		[SerializeField]
		[DesignerPropertySpinner(new object[]
		{
			GaugeRotationType.Indicator,
			GaugeRotationType.Face
		}, Label = "Rotation", Order = 13, Tooltip = "Whether to rotate the indicator or the face of the gauge.")]
		private GaugeRotationType _rotationType;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Order = 15, Tooltip = "Changes the overall size of the gauge.")]
		private float _scale = 1f;

		public string FaceType => _faceType;

		public float FaceZero => _faceZero;

		public bool FlipFace => _flipFace;

		public bool HideFace => _hideFace;

		public bool HideIndicator => _hideIndicator;

		public float IndicatorLength => _indicatorLength;

		public Vector3 IndicatorOffset => _indicatorOffset;

		public string IndicatorType => _indicatorType;

		public float IndicatorZero => _indicatorZero;

		public override float MassDry => 0.2f * Scale * 0.01f;

		public float Multiplier
		{
			get
			{
				if (!Mathf.Approximately(_multiplier, 0f))
				{
					return _multiplier;
				}
				return 1f;
			}
		}

		public override long Price => (long)(50f * Scale);

		public GaugeRotationType RotationType => _rotationType;

		public override float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
			}
		}

		public void PairConnectedBase()
		{
			foreach (AttachPoint attachPoint in base.Part.AttachPoints)
			{
				foreach (PartConnection partConnection in attachPoint.PartConnections)
				{
					GaugeBaseData gaugeBaseData = partConnection.GetOtherPart(base.Part)?.GetModifier<GaugeBaseData>();
					if (gaugeBaseData != null)
					{
						PairWithBase(gaugeBaseData);
					}
				}
			}
		}

		public void PairWithBase(GaugeBaseData baseData, bool copyBaseScale = false)
		{
			if (copyBaseScale)
			{
				_scale = baseData.Scale;
				base.Script.UpdateScale();
			}
			baseData.MatchGauge(this);
			_pairedBase = baseData;
		}

		public void SetScale(float newScale)
		{
			_scale = newScale;
			base.Script.UpdateScale();
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnSpinnerValuesRequested(() => _faceType, UpdateFaceTypeOptions);
			d.OnValueLabelRequested(() => _faceType, GetFaceTypeLabel);
			d.OnPropertyChanged(() => _faceType, delegate
			{
				base.Script.ApplyGaugeFaceDecalTexture();
			});
			d.OnPropertyChanged(() => _scale, delegate
			{
				base.Script.UpdateScale();
				_pairedBase?.MatchGauge(this);
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _multiplier, (float x) => (!Mathf.Approximately(x, 0f)) ? x.ToString() : "None");
			d.OnPropertyChanged(() => _hideFace, delegate
			{
				base.Script.UpdateHiddenMeshes();
			});
			d.OnPropertyChanged(() => _hideIndicator, delegate
			{
				base.Script.UpdateHiddenMeshes();
			});
			d.OnPropertyChanged(() => _indicatorZero, delegate
			{
				base.Script.UpdateZeroPosition();
			});
			d.OnPropertyChanged(() => _faceZero, delegate
			{
				base.Script.UpdateZeroPosition();
			});
			d.OnPropertyChanged(() => _indicatorLength, delegate
			{
				base.Script.UpdateIndicatorLength();
			});
			d.OnValueLabelRequested(() => _indicatorLength, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _flipFace, delegate(bool newVal, bool oldVal)
			{
				base.Script.FlipFaceUvs(newVal, oldVal);
			});
			d.OnPropertyChanged(() => _indicatorType, delegate
			{
				base.Script.UpdateIndicatorType();
			});
			d.OnValueLabelRequested(() => _indicatorType, (string x) => x.Insert(9, " "));
		}

		private string GetFaceTypeLabel(string faceType)
		{
			return Game.Instance.PartDecalManager.GetDecal("Decals/Hidden/GaugeFaces/" + faceType, !string.IsNullOrEmpty(faceType))?.DisplayName ?? "None";
		}

		private void UpdateFaceTypeOptions(List<string> faceTypeList)
		{
			faceTypeList.Clear();
			foreach (DecalInfo item in Game.Instance.PartDecalManager.Decals.Where((DecalInfo x) => x.Path.StartsWith("Decals/Hidden/GaugeFaces/")))
			{
				faceTypeList.Add(item.Path.Substring("Decals/Hidden/GaugeFaces/".Length));
			}
			faceTypeList.Add(string.Empty);
		}
	}
}
