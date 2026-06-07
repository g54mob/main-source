using System.Collections;
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
	public class ActiveHinge : BindableDronePart
	{
		public const float MinAngle = -90f;

		public const float MaxAngle = 90f;

		[HideInInspector]
		[FloatSetting("DronePartSettings/Angle", -90f, 90f, 19, UndoManager.EStoreReason.FlipperAngle)]
		public float Angle;

		public float Speed;

		public const float Force = 2000000f;

		public AnimationCurve Movement;

		public GameObject AngleIndicator;

		public string ActiveSound;

		private HingeJoint _hingeJoint;

		private KeyBinding _open;

		private KeyBinding _close;

		private bool _isOpen;

		private bool _isMoving;

		private Coroutine _currentCoroutine;

		protected override void Validate()
		{
			base.Validate();
			Angle = Mathf.Clamp(Angle, -90f, 90f);
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

		public override List<KeyBinding> GetKeyBindings()
		{
			_open = new KeyBinding("Activate", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.DefaultShootButton));
			_close = new KeyBinding("Deactivate", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.SecondaryShootButton));
			return new List<KeyBinding> { _open, _close };
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Angle") + ": " + LabelHelper.Orange + Angle.ToString("F2");
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
			AngleIndicator.transform.localEulerAngles = Vector3.forward * Angle;
		}

		public override void Update()
		{
			base.Update();
			float num = (_isOpen ? (0f - Angle) : Angle);
			AngleIndicator.transform.localEulerAngles = Vector3.forward * num;
			AngleIndicator.gameObject.SetActive(!_isMoving);
		}

		public override void FixedUpdate()
		{
			if (Rigidbody == null)
			{
				Rigidbody = GetComponentInParent<Rigidbody>();
			}
			if (_hingeJoint == null)
			{
				base.FixedUpdate();
				return;
			}
			if (IsBroken || HealthPool.CurrentState == EChemicalState.Frozen)
			{
				_hingeJoint.useSpring = false;
			}
			else
			{
				_hingeJoint.useSpring = true;
				if (IsActive() && !RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !RuntimeGlobals.IsGamePaused && CanControlDrone)
				{
					if (_open.IsPressed(KeyEventHub))
					{
						if (!_isOpen)
						{
							if (_currentCoroutine != null)
							{
								StopCoroutine(_currentCoroutine);
							}
							_currentCoroutine = StartCoroutine(_Activate(true));
						}
					}
					else if (_close.IsPressed(KeyEventHub) && _isOpen)
					{
						if (_currentCoroutine != null)
						{
							StopCoroutine(_currentCoroutine);
						}
						_currentCoroutine = StartCoroutine(_Activate(false));
					}
				}
			}
			base.FixedUpdate();
		}

		private IEnumerator _Activate(bool open)
		{
			if (_hingeJoint != null)
			{
				_isMoving = true;
				StartSoundLoop(ActiveSound);
				float startRotation = _hingeJoint.angle;
				float targetRotation = (open ? Angle : 0f);
				float t = 0f;
				float time = 2f / Speed / 90f * Mathf.Abs(startRotation - targetRotation);
				while (t < time)
				{
					t += Time.fixedDeltaTime;
					float targetPosition = Mathf.Lerp(startRotation, targetRotation, Movement.Evaluate(t / time));
					_hingeJoint.spring = new JointSpring
					{
						damper = 0f,
						spring = 2000000f,
						targetPosition = targetPosition
					};
					yield return null;
				}
				_hingeJoint.spring = new JointSpring
				{
					damper = 0f,
					spring = 2000000f,
					targetPosition = targetRotation
				};
				_isOpen = open;
				_isMoving = false;
				StopActiveSoundLoop();
			}
		}

		public override void FlipHorizontally(Vector3 flipPos)
		{
			base.FlipHorizontally(flipPos);
			Angle *= -1f;
		}

		public override void FlipVertically(Vector3 flipPos)
		{
			base.FlipVertically(flipPos);
			Angle *= -1f;
		}

		public override NimbatusItemData CreateData()
		{
			return new ActiveHingeData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			ActiveHingeData activeHingeData;
			if ((activeHingeData = data as ActiveHingeData) != null)
			{
				activeHingeData.Angle = Angle;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			ActiveHingeData activeHingeData;
			if ((activeHingeData = data as ActiveHingeData) != null)
			{
				Angle = activeHingeData.Angle;
			}
		}
	}
}
