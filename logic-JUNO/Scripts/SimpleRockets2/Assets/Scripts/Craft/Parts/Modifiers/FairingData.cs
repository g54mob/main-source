using System;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	public class FairingData : PartModifierData<FairingScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _fairingBase;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _jettisoned;

		[SerializeField]
		[DesignerPropertySlider(0f, 2.5f, 26, Label = "Jettison Spin", Tooltip = "The angular speed at which the fairings will spin after being jettisoned. It's to make them look cool when they are jettisoned. For fun.")]
		private float _jettisonSpin = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2.5f, 26, Label = "Jettison Speed", Tooltip = "The speed at which the fairings are jettisoned away from the craft.")]
		private float _jettisonVelocity = 1f;

		public bool FairingBase => _fairingBase;

		public bool Jettisoned
		{
			get
			{
				return _jettisoned;
			}
			set
			{
				_jettisoned = value;
			}
		}

		public float JettisonSpin => _jettisonSpin;

		public float JettisonVelocity => _jettisonVelocity;

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnVisibilityRequested(() => _jettisonSpin, (bool x) => _fairingBase);
			d.OnVisibilityRequested(() => _jettisonVelocity, (bool x) => _fairingBase);
			d.OnValueLabelRequested(() => _jettisonSpin, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _jettisonVelocity, (float x) => Utilities.FormatPercentage(x));
		}
	}
}
