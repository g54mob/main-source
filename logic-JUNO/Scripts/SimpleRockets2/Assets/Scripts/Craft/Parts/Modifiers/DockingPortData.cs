using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Docking Port")]
	public class DockingPortData : PartModifierData<DockingPortScript>
	{
		[SerializeField]
		[DesignerPropertySlider(0f, 2f, 51, Order = 2, Label = "Magnet Strength", Tooltip = "Changes how strong the magnet in the docking port is to make docking easier, at a higher cost.")]
		private float _magnetForce = 1f;

		[SerializeField]
		[DesignerPropertySlider(-2f, 2f, 5, Order = 1, Label = "Size", Tooltip = "Changes the overall size of the docking port.", TechTreeIdForMaxValue = "MaxSize.Docking")]
		private float _scale;

		public override long Price => (int)(50000.0 * (double)ScaledScale * (double)ScaledScale * (double)(_magnetForce + 0.1f));

		public float MagnetForce => _magnetForce * ScaledScale * ScaledScale;

		public override float MassDry => ((base.Version == 1) ? 200f : (500f * Mathf.Pow(ScaledScale, 3f))) * 0.01f;

		public override float Scale => _scale;

		public float ScaledScale => Mathf.Pow(2f, _scale);

		public override string ScaleCareerID => "MaxSize.Docking";

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(ScaledScale));
			d.OnPropertyChanged(() => _scale, delegate
			{
				d.Manager.RefreshUI();
				base.Script.UpdateScale(repositionAttachedParts: true);
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				base.Part.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnValueLabelRequested(() => _magnetForce, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _magnetForce, delegate
			{
				d.Manager.RefreshUI();
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				base.Part.PartScript.CraftScript.SetStructureChanged();
			});
		}
	}
}
