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
	[DesignerPartModifier("Simple Scale")]
	public class GenericPartData : PartModifierData<GenericPartScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _attachmentSize = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _baseMass = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _basePrize = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _massSizeRate = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _priceSizeRate = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Order = 15, Tooltip = "Changes the overall size of the part.")]
		private float _scale = 1f;

		public float AttachmentSize => _attachmentSize * _scale;

		public override float MassDry => _baseMass * Mathf.Pow(_scale, _massSizeRate) * 0.01f;

		public override long Price => (long)(_basePrize * Mathf.Pow(_scale, _priceSizeRate));

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

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _scale, delegate
			{
				d.Manager.RefreshUI();
				base.Script.UpdateScale(repositionAttachedParts: true);
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
		}
	}
}
