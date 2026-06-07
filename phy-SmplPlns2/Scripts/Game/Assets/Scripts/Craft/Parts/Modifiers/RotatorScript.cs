using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class RotatorScript : PartModifierScript
	{
		private InputControllerScript _inputX;

		private InputControllerScript _inputY;

		private InputControllerScript _inputZ;

		private RotatorData _rotator;

		private GameObject _target;

		public float CurrentRotationAngle { get; set; }

		public float DynamicSensitivity { get; set; }

		public bool Invert { get; set; }

		public Vector3 NeutralLocalAngles { get; set; }

		public RotatorData Rotator => _rotator;

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void Initialize(RotatorData rotator)
		{
			_rotator = rotator;
			try
			{
				_target = Utilities.FindGameObjectRelativeTo(base.gameObject, rotator.Target);
			}
			catch (Exception)
			{
				Debug.LogError("Could not find rotator target: " + rotator.Target);
			}
		}

		public void UpdateNeutralPosition()
		{
			if (_target != null)
			{
				NeutralLocalAngles = _target.transform.localEulerAngles;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private InputControllerScript GetInputController(string name, List<InputControllerScript> modifiers)
		{
			foreach (InputControllerScript modifier in modifiers)
			{
				if (modifier.InputController.Name.ToLower() == name.ToLower())
				{
					return modifier;
				}
			}
			return null;
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (_rotator != null && _rotator.Enabled)
			{
				float x = 0f;
				float y = 0f;
				float z = 0f;
				if (_inputX != null)
				{
					x = _inputX.Value;
				}
				if (_inputY != null)
				{
					y = _inputY.Value;
				}
				if (_inputZ != null)
				{
					z = _inputZ.Value;
				}
				if (_target != null)
				{
					_target.transform.localEulerAngles = NeutralLocalAngles;
				}
				Vector3 vector = new Vector3(x, y, z);
				if (Invert)
				{
					vector *= -1f;
				}
				Vector3 eulers = vector * DynamicSensitivity;
				if (_target != null)
				{
					_target.transform.Rotate(eulers);
				}
				CurrentRotationAngle = eulers.y;
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			List<InputControllerScript> modifiers = base.PartScript.GetModifiers<InputControllerScript>();
			_inputX = GetInputController(_rotator.InputX, modifiers);
			_inputY = GetInputController(_rotator.InputY, modifiers);
			_inputZ = GetInputController(_rotator.InputZ, modifiers);
			UpdateNeutralPosition();
			DynamicSensitivity = 1f;
			return UniTask.CompletedTask;
		}
	}
}
