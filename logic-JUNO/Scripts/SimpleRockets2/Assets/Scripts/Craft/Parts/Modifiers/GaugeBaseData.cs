using System;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Gauge Base")]
	[PartModifierTypeId("GaugeBase")]
	public class GaugeBaseData : PartModifierData<GaugeBaseScript>
	{
		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Hide Base", Order = 20, Tooltip = "Changes the visual style of the base plate. Purely for cosmetic purposes.")]
		private bool _hideBase;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Hide Rim", Order = 30, Tooltip = "Changes the visual style of the rim that surrounds the gauge. Purely for cosmetic purposes.")]
		private bool _hideRim;

		[NonSerialized]
		private GaugeData _pairedGauge;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Order = 10, Tooltip = "Changes the overall size of the gauge.")]
		private float _scale = 1f;

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "Trim1", "Trim2" }, Label = "Rim Style", Order = 40, Tooltip = "Changes the style of the rim that surrounds the gauge.")]
		private string _trimType = "Trim1";

		public bool HideBase => _hideBase;

		public bool HideRim => _hideRim;

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

		public string TrimType => _trimType;

		public void MatchGauge(GaugeData gauge)
		{
			_pairedGauge = gauge;
			_scale = gauge.Scale;
			base.Script.UpdateScale();
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnPropertyChanged(() => _scale, delegate
			{
				base.Script.UpdateScale();
				_pairedGauge?.SetScale(_scale);
			});
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _hideBase, delegate
			{
				base.Script.UpdateHiddenMeshes();
			});
			d.OnPropertyChanged(() => _hideRim, delegate
			{
				base.Script.UpdateHiddenMeshes();
			});
			d.OnPropertyChanged(() => _trimType, delegate
			{
				base.Script.UpdateTrimType();
			});
			d.OnValueLabelRequested(() => _trimType, (string x) => x.Insert(4, " "));
		}
	}
}
