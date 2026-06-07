using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class CameraFocusPart : BindableDronePart
	{
		public tk2dSprite OutputLed;

		public CameraFocusRemnant Remnant;

		private KeyBinding _inputBinding;

		private bool _wasActive;

		private CameraFocusRemnant _rem;

		private bool _disableTracker;

		protected override void Start()
		{
			base.Start();
			OutputLed.color = Color.red;
			_disableTracker = RunningModeSpecifics.Can(ERunningModeSpecific.DisableCameraFocusParts);
		}

		public override void OnDisable()
		{
			if (_rem != null)
			{
				if (_wasActive)
				{
					_rem.transform.position = base.transform.position;
					_rem.Init();
				}
				else
				{
					_rem.Destroy();
				}
			}
			base.OnDisable();
			if (RuntimeGlobals.Camera != null)
			{
				RuntimeGlobals.Camera.RemoveTracker(base.transform);
			}
		}

		public override void FixedUpdate()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				return;
			}
			base.FixedUpdate();
			if (!RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !RuntimeGlobals.IsGamePaused && CanControlDrone && !IsBroken)
			{
				bool flag = _inputBinding.IsPressed(KeyEventHub);
				OutputLed.color = (flag ? Color.green : Color.red);
				if (flag && !_wasActive && !_disableTracker)
				{
					if (_rem == null)
					{
						_rem = Object.Instantiate(Remnant, base.transform.position, base.transform.rotation);
					}
					RuntimeGlobals.Camera.AddTracker(base.transform, true, true);
					_wasActive = true;
				}
				else if (!flag && _wasActive)
				{
					if (!_disableTracker)
					{
						RuntimeGlobals.Camera.RemoveTracker(base.transform);
					}
					_wasActive = false;
				}
			}
			else if (!RuntimeGlobals.IsGamePaused)
			{
				OutputLed.color = Color.red;
				if (_wasActive)
				{
					RuntimeGlobals.Camera.RemoveTracker(base.transform);
					_wasActive = false;
				}
			}
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				OutputLed.color = Color.red;
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_inputBinding = new KeyBinding("Activate", KeyCode.None);
			return new List<KeyBinding> { _inputBinding };
		}
	}
}
