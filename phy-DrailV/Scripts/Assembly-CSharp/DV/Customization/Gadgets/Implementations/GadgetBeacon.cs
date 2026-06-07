using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetBeacon : GadgetBase
	{
		public float saturation = 0.75f;

		public LightingGadgetController lighting;

		public Transform head;

		public float rotationSpeed = 360f;

		private GadgetSwitch controller;

		private float rotateSpeed;

		private float angle;

		public float CurrentValue { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			RegisterWireLink<GadgetSwitch>(ControllerLinked, ControllerUnlinked, allowMultipleLinks: false);
		}

		private void Update()
		{
			if (rotateSpeed != 0f)
			{
				angle = Mathf.Repeat(angle + rotateSpeed * Time.deltaTime, 360f);
				head.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
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

		protected override void OnPowerStateChanged(bool _ = false)
		{
			StateChanged(controller);
		}

		private void StateChanged(GadgetSwitch sw)
		{
			float f = (CurrentValue = GadgetSwitch.ValueOfPower(sw, this));
			f = Mathf.Sqrt(f);
			rotateSpeed = rotationSpeed * f;
			lighting.UpdateColorAlpha(f);
		}

		protected override void OnItemAssigned()
		{
			if (!base.GadgetItem.AttributeQuery("HUE", out var value))
			{
				value = 0f;
			}
			lighting.color = Color.HSVToRGB(value / 360f, saturation, 1f);
			OnPowerStateChanged(false);
		}
	}
}
