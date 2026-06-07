using System;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetOscillatingLight : GadgetBase
	{
		public Transform head;

		public float frequency = 0.3f;

		public Vector2 amplitude = new Vector2(24f, 45f);

		public LightingGadgetController lighting;

		private GadgetSwitch controller;

		private float time;

		private float currentSpeed;

		protected override void Awake()
		{
			base.Awake();
			RegisterWireLink<GadgetSwitch>(ControllerLinked, ControllerUnlinked, allowMultipleLinks: false);
		}

		private void Update()
		{
			if (currentSpeed != 0f)
			{
				time = Mathf.Repeat(time + Time.deltaTime * currentSpeed, 1f);
				float num = time * 2f * (float)Math.PI;
				head.localRotation = Quaternion.Euler(Mathf.Sin(num * 2f) * amplitude.x, Mathf.Sin(num) * amplitude.y, 0f);
			}
		}

		private void ControllerLinked(GadgetSwitch controller)
		{
			this.controller = controller;
			controller.OnOutputValueUpdated += StateChanged;
			OnPowerStateChanged(false);
		}

		private void ControllerUnlinked(GadgetSwitch controller)
		{
			this.controller.OnOutputValueUpdated -= StateChanged;
			this.controller = null;
			OnPowerStateChanged(false);
		}

		protected override void OnAfterLinked()
		{
			base.OnAfterLinked();
			OnPowerStateChanged(false);
		}

		protected override void OnPowerStateChanged(bool _)
		{
			StateChanged(controller);
		}

		private void StateChanged(GadgetSwitch sw)
		{
			float f = GadgetSwitch.ValueOfPower(sw, this);
			f = Mathf.Sqrt(f);
			currentSpeed = frequency * f;
			lighting.UpdateColorAlpha(f);
		}
	}
}
