using System;
using System.Collections.Generic;
using DV.HUD;
using DV.Interaction.Inputs;
using DV.Simulation.Controllers;
using Rewired;
using Rewired.UI.ControlMapper;
using UnityEngine;

namespace DV.KeyboardInput
{
	public abstract class AKeyboardInput : MonoBehaviour
	{
		[Serializable]
		public class ActionReference
		{
			public string name;

			public bool flip;

			private int actionId = -1;

			[NonSerialized]
			public OverridableBaseControl overridableBaseControl;

			private static Dictionary<int, InteriorControlsManager.ControlType> actionToControlType = new Dictionary<int, InteriorControlsManager.ControlType>
			{
				{
					17,
					InteriorControlsManager.ControlType.Throttle
				},
				{
					19,
					InteriorControlsManager.ControlType.TrainBrake
				},
				{
					21,
					InteriorControlsManager.ControlType.IndBrake
				},
				{
					23,
					InteriorControlsManager.ControlType.Reverser
				},
				{
					25,
					InteriorControlsManager.ControlType.DynamicBrake
				},
				{
					101,
					InteriorControlsManager.ControlType.TrainBrakeCutout
				},
				{
					27,
					InteriorControlsManager.ControlType.Handbrake
				},
				{
					29,
					InteriorControlsManager.ControlType.CylCock
				},
				{
					31,
					InteriorControlsManager.ControlType.Sander
				},
				{
					116,
					InteriorControlsManager.ControlType.Wipers
				},
				{
					132,
					InteriorControlsManager.ControlType.HeadlightsFront
				},
				{
					133,
					InteriorControlsManager.ControlType.HeadlightsRear
				},
				{
					117,
					InteriorControlsManager.ControlType.GearboxA
				},
				{
					118,
					InteriorControlsManager.ControlType.GearboxB
				},
				{
					130,
					InteriorControlsManager.ControlType.Bell
				},
				{
					119,
					InteriorControlsManager.ControlType.Firedoor
				},
				{
					120,
					InteriorControlsManager.ControlType.Injector
				},
				{
					121,
					InteriorControlsManager.ControlType.Damper
				},
				{
					122,
					InteriorControlsManager.ControlType.Blower
				},
				{
					123,
					InteriorControlsManager.ControlType.Blowdown
				}
			};

			public int id => DV.Interaction.Inputs.InputManager.Actions.GetActionID(actionId);

			public bool CanMoveOverridableBaseControl
			{
				get
				{
					if ((bool)overridableBaseControl)
					{
						return !overridableBaseControl.IsControlBlocked;
					}
					return true;
				}
			}

			public float Multiplier => (!flip) ? 1 : (-1);

			public void Initialize(InteriorControlsManager icm)
			{
				actionId = ReInput.mapping.GetActionId(name);
				if (actionId == -1)
				{
					Debug.LogError("Didn't find action: " + name);
				}
				if ((bool)icm && actionToControlType.TryGetValue(actionId, out var value) && icm.TryGetControl(value, out var reference))
				{
					overridableBaseControl = reference.overridableBaseControl;
				}
			}
		}

		private const float XZ_SQR_REACH_RANGE = 16f;

		private const float Y_REACH_RANGE = 2f;

		public abstract bool FixedUpdateTick { get; }

		public abstract void Tick(float deltaTime);

		public abstract void SetupActions(InteriorControlsManager interiorControlsManager);

		public bool PlayerCanReach()
		{
			if (Globals.G.GameParams.KeyboardDrivingAnywhereOnVehicleAllowed)
			{
				return true;
			}
			if (DV.Interaction.Inputs.InputManager.NewPlayer.controllers.JoystickAndCustomControllersCount() != 0)
			{
				return true;
			}
			Transform transform = ((PlayerManager.PlayerCamera == null) ? PlayerManager.PlayerTransform : PlayerManager.PlayerCamera.transform);
			Vector3 vector = base.transform.position - transform.position;
			if (Mathf.Abs(vector.y) > 2f)
			{
				return false;
			}
			vector.y = 0f;
			return vector.sqrMagnitude <= 16f;
		}
	}
}
