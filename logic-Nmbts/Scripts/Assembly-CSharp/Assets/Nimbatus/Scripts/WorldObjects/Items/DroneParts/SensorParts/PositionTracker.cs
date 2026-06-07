using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class PositionTracker : BindableDronePart
	{
		public tk2dSprite OutputLed;

		private KeyBinding _inputBinding;

		[NonSerialized]
		[HideInInspector]
		public bool IsTrackerActive;

		public static List<PositionTracker> Trackers = new List<PositionTracker>();

		public static PositionTracker GetNearestActiveTracker(Vector2 position)
		{
			float num = 1000f;
			PositionTracker result = null;
			for (int i = 0; i < Trackers.Count; i++)
			{
				PositionTracker positionTracker = Trackers[i];
				if (positionTracker.IsTrackerActive)
				{
					float num2 = Vector2.Distance(positionTracker.transform.position, position);
					if (num2 < num)
					{
						num = num2;
						result = positionTracker;
					}
				}
			}
			return result;
		}

		protected override void Start()
		{
			base.Start();
			IsTrackerActive = false;
			OutputLed.color = Color.red;
			Trackers.Add(this);
		}

		public override void OnDisable()
		{
			base.OnDisable();
			IsTrackerActive = false;
			Trackers.Remove(this);
		}

		public override void FixedUpdate()
		{
			if (RuntimeGlobals.RunningMode != ERunningMode.DroneCustomization)
			{
				base.FixedUpdate();
				if (IsActive())
				{
					IsTrackerActive = _inputBinding.IsPressed(KeyEventHub);
					OutputLed.color = (IsTrackerActive ? Color.green : Color.red);
				}
				else
				{
					OutputLed.color = Color.red;
				}
				if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
				{
					OutputLed.color = Color.red;
				}
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_inputBinding = new KeyBinding("Activate", KeyCode.None);
			return new List<KeyBinding> { _inputBinding };
		}
	}
}
