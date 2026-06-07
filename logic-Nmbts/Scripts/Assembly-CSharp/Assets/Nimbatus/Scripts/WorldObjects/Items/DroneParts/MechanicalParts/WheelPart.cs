using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Components;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class WheelPart : BindableDronePart, IFuelConsumer
	{
		private const int MinSpeed = 0;

		private const int MaxSpeed = 720;

		[IntSetting("DronePartSettings/Speed", 0, 720, 91, UndoManager.EStoreReason.WheelSpeed)]
		public int Speed = 360;

		private const float MinRadius = 1f;

		private const float MaxRadius = 4f;

		[FloatSetting("DronePartSettings/Radius", 1f, 4f, 31, UndoManager.EStoreReason.WheelRadius)]
		public float Radius = 2f;

		[EnumSetting("DronePartSettings/Tire", UndoManager.EStoreReason.WheelTyre)]
		public ETyre SelectedCoating;

		public float MinHealth = 500f;

		public float MaxHealth = 3000f;

		public float MinMass = 0.5f;

		public float MaxMass = 3f;

		public float FuelPerSecond = 1f;

		public string MoveSoundName;

		public LayerMask StickLayers;

		public float StickForce = 100f;

		private CapsuleCollider _collider;

		private Dictionary<Collider, Collision> _collisions = new Dictionary<Collider, Collision>();

		private Vector3 _lastStickVector;

		private int _direction;

		private float _targetZ;

		private HingeJoint _hingeJoint;

		private float _fuelAmount;

		private bool _useEnergyAsFuel;

		private KeyBinding _rotateRight;

		private KeyBinding _rotateLeft;

		protected override void Validate()
		{
			base.Validate();
			Speed = Mathf.Clamp(Speed, 0, 720);
			Radius = Mathf.Clamp(Radius, 1f, 4f);
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_rotateLeft = new KeyBinding("Rotate Left", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.HingeRotationLeft));
			_rotateRight = new KeyBinding("Rotate Right", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.HingeRotationRight));
			return new List<KeyBinding> { _rotateRight, _rotateLeft };
		}

		public override void InitDronePerkSettings(List<DroneEffect> effects)
		{
			base.InitDronePerkSettings(effects);
			if (effects != null)
			{
				_useEnergyAsFuel = effects.OfType<SuperchargedBatteries>().Any();
			}
		}

		protected override void Awake()
		{
			IndividualJoint = true;
			base.Awake();
			_collider = GetComponent<CapsuleCollider>();
			_hingeJoint = GetComponent<HingeJoint>();
			_hingeJoint.useSpring = true;
			_hingeJoint.breakForce = 40000f;
			Joint = _hingeJoint;
		}

		protected override void Start()
		{
			base.Start();
			UpdateWheel();
		}

		public override void Update()
		{
			base.Update();
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				UpdateWheel();
			}
		}

		private void UpdateWheel()
		{
			if (_collider != null)
			{
				_collider.radius = Radius;
			}
			float t = Mathf.InverseLerp(1f, 4f, Radius);
			if (HealthPool != null)
			{
				HealthPool.MaxHealth = Mathf.RoundToInt(Mathf.Lerp(MinHealth, MaxHealth, t));
			}
			if (Rigidbody != null)
			{
				Rigidbody.mass = Mathf.Lerp(MinMass, MaxMass, t);
			}
			float num = 0.9f * Radius;
			if (base.Sprite != null)
			{
				base.Sprite.scale = new Vector3(num, num, 1f);
			}
			switch (SelectedCoating)
			{
			case ETyre.Rubber:
			{
				tk2dSprite sprite2 = base.Sprite;
				if ((object)sprite2 != null)
				{
					sprite2.SetSprite("Wheel");
				}
				ApplyPhysicMaterial(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.RubberTireMaterial);
				break;
			}
			case ETyre.Sticky:
			{
				tk2dSprite sprite = base.Sprite;
				if ((object)sprite != null)
				{
					sprite.SetSprite("WheelSticky");
				}
				ApplyPhysicMaterial(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.RubberTireMaterial);
				break;
			}
			}
			_fuelAmount = FuelPerSecond / 720f * (float)Speed;
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
				if (IsActive() && !Rigidbody.isKinematic)
				{
					EResourceType mat = (_useEnergyAsFuel ? EResourceType.Energy : EResourceType.Fuel);
					float amount = _fuelAmount * Time.fixedDeltaTime;
					bool flag = _rotateRight.IsPressed(KeyEventHub);
					bool flag2 = _rotateLeft.IsPressed(KeyEventHub);
					if (Speed > 0 && base.CurrentResourceHub.HasResource(mat, amount) && (flag || flag2))
					{
						StartSoundLoop(MoveSoundName);
						base.CurrentResourceHub.UseResourceFromParts(mat, amount);
						_direction = ((!flag) ? 1 : (-1));
						_targetZ += (float)(_direction * Speed) * Time.fixedDeltaTime;
						if (_targetZ >= 180f)
						{
							_targetZ -= 360f;
						}
						if (_targetZ <= -180f)
						{
							_targetZ += 360f;
						}
						_hingeJoint.spring = new JointSpring
						{
							damper = 0f,
							spring = 2000000f,
							targetPosition = _targetZ
						};
					}
					else
					{
						StopActiveSoundLoop();
						_hingeJoint.spring = new JointSpring
						{
							damper = 0f,
							spring = 0f,
							targetPosition = base.transform.localEulerAngles.z
						};
						_targetZ = base.transform.localEulerAngles.z;
					}
				}
				else
				{
					StopActiveSoundLoop();
				}
				StickWheel();
				Rigidbody.inertiaTensorRotation = Quaternion.identity;
			}
			base.FixedUpdate();
		}

		private void StickWheel()
		{
			if (SelectedCoating != ETyre.Sticky)
			{
				return;
			}
			if (_collisions.Count <= 0)
			{
				if (!Physics.Raycast(new Ray(base.transform.position, _lastStickVector), Radius + 1f, StickLayers, QueryTriggerInteraction.Ignore))
				{
					_lastStickVector = Vector3.zero;
					return;
				}
				Rigidbody.AddForce(_lastStickVector, ForceMode.Force);
			}
			_lastStickVector = Vector3.zero;
			foreach (KeyValuePair<Collider, Collision> collision in _collisions)
			{
				Vector3 normalized = (collision.Value.GetContact(0).point - base.transform.position).normalized;
				normalized *= StickForce * Time.fixedDeltaTime;
				normalized /= (float)_collisions.Count;
				if (collision.Value.rigidbody != null && !collision.Value.rigidbody.isKinematic)
				{
					collision.Value.rigidbody.AddForce(-normalized / 2f, ForceMode.Force);
					Rigidbody.AddForce(normalized / 2f, ForceMode.Force);
				}
				else
				{
					Rigidbody.AddForce(normalized, ForceMode.Force);
				}
				_lastStickVector += normalized;
			}
		}

		public override void OnCollisionEnter(Collision col)
		{
			HandleCollision(col, false);
			if (SelectedCoating == ETyre.Sticky && StickLayers.Contains(col.gameObject.layer) && !_collisions.ContainsKey(col.collider))
			{
				_collisions.Add(col.collider, col);
			}
		}

		public void OnCollisionStay(Collision col)
		{
			if (SelectedCoating == ETyre.Sticky && StickLayers.Contains(col.gameObject.layer))
			{
				if (_collisions.ContainsKey(col.collider))
				{
					_collisions[col.collider] = col;
				}
				else
				{
					_collisions.Add(col.collider, col);
				}
			}
		}

		public void OnCollisionExit(Collision col)
		{
			if (SelectedCoating == ETyre.Sticky && StickLayers.Contains(col.gameObject.layer) && _collisions.ContainsKey(col.collider))
			{
				_collisions.Remove(col.collider);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Speed") + ": " + LabelHelper.Orange + Speed + LabelHelper.NewLine;
			text = ((!_useEnergyAsFuel) ? (text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/FuelPerSecond") + ": " + LabelHelper.Orange + _fuelAmount.ToString("##0.##") + LabelHelper.NewLine) : (text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + _fuelAmount.ToString("##0.##") + LabelHelper.NewLine));
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Radius") + ": " + LabelHelper.Orange + Radius.ToString("##0.##") + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Tire") + ": " + LabelHelper.Orange + SelectedCoating.ToLocalizationString();
		}

		public override NimbatusItemData CreateData()
		{
			return new WheelPartData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			WheelPartData wheelPartData;
			if ((wheelPartData = data as WheelPartData) != null)
			{
				wheelPartData.Speed = Speed;
				wheelPartData.Radius = Radius;
				wheelPartData.Tyre = SelectedCoating;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			WheelPartData wheelPartData;
			if ((wheelPartData = data as WheelPartData) != null)
			{
				Speed = wheelPartData.Speed;
				Radius = wheelPartData.Radius;
				SelectedCoating = wheelPartData.Tyre;
			}
		}
	}
}
