using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class MotorizedHinge : BindableDronePart
	{
		private const int MinSpeed = 0;

		private const int MaxSpeed = 200;

		[IntSetting("DronePartSettings/Speed", 0, 200, 100, UndoManager.EStoreReason.MotorizedHingeSpeed)]
		public int Speed = 20;

		public string MoveSoundName;

		private int _direction;

		private HingeJoint _hingeJoint;

		private KeyBinding _rotateRight;

		private KeyBinding _rotateLeft;

		protected override void Validate()
		{
			base.Validate();
			Speed = Mathf.Clamp(Speed, 0, 200);
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_rotateLeft = new KeyBinding("Rotate Left", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.HingeRotationLeft));
			_rotateRight = new KeyBinding("Rotate Right", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.HingeRotationRight));
			return new List<KeyBinding> { _rotateRight, _rotateLeft };
		}

		protected override void Awake()
		{
			IndividualJoint = true;
			base.Awake();
			_hingeJoint = GetComponent<HingeJoint>();
			_hingeJoint.useSpring = true;
			_hingeJoint.breakForce = 40000f;
			Joint = _hingeJoint;
		}

		protected override void Start()
		{
			base.Start();
			_hingeJoint.spring = new JointSpring
			{
				damper = 0f,
				spring = 2000000f,
				targetPosition = 0f
			};
		}

		public override void FixedUpdate()
		{
			if (_hingeJoint == null)
			{
				StopActiveSoundLoop();
				base.FixedUpdate();
				return;
			}
			if (IsBroken || HealthPool.CurrentState == EChemicalState.Frozen)
			{
				StopActiveSoundLoop();
				_hingeJoint.useSpring = false;
			}
			else
			{
				_hingeJoint.useSpring = true;
				if (IsActive() && !Rigidbody.isKinematic && _hingeJoint != null)
				{
					bool flag = _rotateRight.IsPressed(KeyEventHub);
					bool flag2 = _rotateLeft.IsPressed(KeyEventHub);
					if (flag || flag2)
					{
						StartSoundLoop(MoveSoundName);
						_direction = ((!flag) ? 1 : (-1));
						float num = _hingeJoint.spring.targetPosition + (float)(_direction * Speed) * Time.fixedDeltaTime;
						if (num >= 180f)
						{
							num -= 360f;
						}
						if (num <= -180f)
						{
							num += 360f;
						}
						_hingeJoint.spring = new JointSpring
						{
							damper = 0f,
							spring = 2000000f,
							targetPosition = num
						};
					}
					else
					{
						StopActiveSoundLoop();
					}
				}
				else
				{
					StopActiveSoundLoop();
				}
			}
			base.FixedUpdate();
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Speed") + ": " + LabelHelper.Orange + Speed;
		}

		public override NimbatusItemData CreateData()
		{
			return new MotorizedHingeData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			MotorizedHingeData motorizedHingeData = data as MotorizedHingeData;
			if (motorizedHingeData != null)
			{
				motorizedHingeData.Speed = Speed;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			MotorizedHingeData motorizedHingeData = data as MotorizedHingeData;
			if (motorizedHingeData != null)
			{
				Speed = motorizedHingeData.Speed;
			}
		}
	}
}
