using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Solar
{
	[Serializable]
	[DesignerPartModifier("Solar Panel", PanelOrder = 2000)]
	public class SolarPanelData : PartModifierData<SolarPanelScript>
	{
		public const float Density = 500f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _efficiency = 0.46f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2.5f, 21, Label = "Length", Order = 15, Tooltip = "Changes the length of the solar panel")]
		private float _length = 1.3f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2.5f, 21, Label = "Width", Order = 16, Tooltip = "Changes the width of the solar panel")]
		private float _width = 1f;

		public float Efficiency
		{
			get
			{
				if (!Game.InDesignerScene)
				{
					return _efficiency * Mathf.Max(0f, (0.015f - 2.5E-05f * base.Part.PartScript.Temperature) * base.Part.PartScript.Temperature - 1.25f);
				}
				return _efficiency;
			}
		}

		public float Length
		{
			get
			{
				return _length;
			}
			set
			{
				_length = value;
				base.Script.UpdateScale();
			}
		}

		public override float MassDry => CalculatePanelVolume() * 500f * 0.01f;

		public override long Price => (long)(100000f * _efficiency * _efficiency * _efficiency * _width * _length);

		public float Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
				base.Script.UpdateScale();
			}
		}

		public float CalculatePanelArea()
		{
			float num = 0.8f * _length;
			float num2 = 0.65f * _width;
			return num * num2;
		}

		public float CalculatePanelVolume()
		{
			float num = 0.65f * _length;
			float num2 = 0.65f * _width;
			return 0.0175f * num * num2;
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnPropertyChanged(() => _length, delegate
			{
				UpdateScale();
			});
			d.OnPropertyChanged(() => _width, delegate
			{
				UpdateScale();
			});
			d.OnValueLabelRequested(() => _length, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _width, (float x) => Utilities.FormatPercentage(x));
			d.OnPartStyleChanged(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, base.Part.Styles[0].Style.GetData("Efficiency", 1f), delegate(SolarPanelData x, float y)
				{
					x._efficiency = y;
				});
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
		}

		private void UpdateScale()
		{
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, _length, delegate(SolarPanelData x, float y)
			{
				x.Length = y;
			});
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, _width, delegate(SolarPanelData x, float y)
			{
				x.Width = y;
			});
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
