using System;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[PartModifierTypeId("KomodoNoseCone")]
	public class KomodoNoseConeData : PartModifierData<KomodoNoseConeScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _autoResize = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _defaultRadius = 0.43f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2.5f, 41)]
		private float _scale = 1f;

		public float DefaultRadius => _defaultRadius;

		public override float MassDry
		{
			get
			{
				float num = base.Part.PartType.Mass * base.Part.Config.MassScale;
				return _scale * _scale * num - num;
			}
		}

		public override long Price => Mathf.CeilToInt((float)base.Part.PartType.Price * _scale - (float)base.Part.PartType.Price);

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
			base.OnDesignerInitialization(d);
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _scale, delegate(float newValue, float oldValue)
			{
				base.Script.UpdateScale(newValue);
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnVisibilityRequested(() => _scale, (bool x) => base.Part.PartConnections.Count < 1 || !_autoResize || base.Part.PartConnections[0].Attachments[0].GetOtherAttachPoint(base.Part.AttachPoints[0]).Radius < _defaultRadius);
		}
	}
}
