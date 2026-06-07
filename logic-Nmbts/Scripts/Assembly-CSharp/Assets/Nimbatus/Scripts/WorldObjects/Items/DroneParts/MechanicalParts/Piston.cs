using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class Piston : SensorPart
	{
		[FloatSetting("DronePartSettings/Speed", 0.5f, 10f, 20, UndoManager.EStoreReason.PistonSpeed)]
		public float ExtendSpeed;

		[FloatSetting("DronePartSettings/Range", 0.5f, 10f, 20, UndoManager.EStoreReason.PistonDistance)]
		public float ExtendDistance;

		public string MoveSoundName;

		public LineRenderer ThickLine;

		public LineRenderer ThinLine;

		private KeyBinding _extend;

		private KeyBinding _retract;

		private EventKeyBinding _isExtended;

		private EventKeyBinding _isRetracted;

		private bool _wasExtended;

		private bool _wasRetracted;

		private Vector2 _originalAnchor;

		private float _t;

		protected override void Awake()
		{
			CustomLineRenderer = true;
			LineRenderer = ThickLine;
			base.Awake();
			Joint.autoConfigureConnectedAnchor = false;
		}

		protected override void Start()
		{
			base.Start();
			_t = 0f;
			_originalAnchor = base.transform.localPosition;
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (IsBroken || HealthPool.CurrentState == EChemicalState.Frozen)
			{
				StopActiveSoundLoop();
				ThickLine.enabled = false;
				ThinLine.enabled = false;
			}
			else if (IsActive() && Joint != null)
			{
				if (_extend.IsPressed(KeyEventHub))
				{
					if (_t < 1f)
					{
						StartSoundLoop(MoveSoundName);
						_t += Time.fixedDeltaTime * ExtendSpeed * 1f / ExtendDistance;
					}
					else
					{
						_t = 1f;
						StopActiveSoundLoop();
					}
				}
				else if (_retract.IsPressed(KeyEventHub))
				{
					if (_t > 0f)
					{
						StartSoundLoop(MoveSoundName);
						_t -= Time.fixedDeltaTime * ExtendSpeed * 1f / ExtendDistance;
					}
					else
					{
						_t = 0f;
						StopActiveSoundLoop();
					}
				}
				else
				{
					StopActiveSoundLoop();
				}
				Joint.connectedAnchor = Vector2.Lerp(_originalAnchor, _originalAnchor + _originalAnchor.normalized * ExtendDistance, _t);
				if (_t <= 0f)
				{
					if (!_wasRetracted)
					{
						_isRetracted.PressKey(true, KeyEventHub);
						_wasRetracted = true;
						StopActiveSoundLoop();
					}
				}
				else if (_wasRetracted)
				{
					_isRetracted.PressKey(false, KeyEventHub);
					_wasRetracted = false;
				}
				if (_t >= 1f)
				{
					if (!_wasExtended)
					{
						_isExtended.PressKey(true, KeyEventHub);
						_wasExtended = true;
						StopActiveSoundLoop();
					}
				}
				else if (_wasExtended)
				{
					_isExtended.PressKey(false, KeyEventHub);
					_wasExtended = false;
				}
			}
			else
			{
				StopActiveSoundLoop();
			}
		}

		public override void Update()
		{
			base.Update();
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				_originalAnchor = base.transform.localPosition;
			}
			if (ParentDronePart != null || DronePartRangeManager.SelectedItem != null)
			{
				DronePart obj = ParentDronePart ?? DronePartRangeManager.SelectedItem;
				Vector3 vector = obj.Rigidbody.transform.TransformPoint(_originalAnchor);
				ThickLine.enabled = true;
				Vector3 position = new Vector3(vector.x, vector.y, 1f);
				Vector3 childAttachPosition = obj.GetChildAttachPosition(base.transform);
				childAttachPosition.z = 1f;
				Vector3 position2 = childAttachPosition;
				ThickLine.SetPosition(0, position);
				ThickLine.SetPosition(1, position2);
				if (Vector3.Distance(base.transform.localPosition, _originalAnchor) > 0f)
				{
					Vector3 position3 = base.transform.position;
					position3.z = 1f;
					ThinLine.enabled = true;
					ThinLine.SetPosition(0, position);
					ThinLine.SetPosition(1, position3);
				}
				else
				{
					ThinLine.enabled = false;
				}
			}
			else
			{
				ThickLine.enabled = false;
				ThinLine.enabled = false;
			}
			if (IsBroken || ParentDronePart == null)
			{
				ThickLine.enabled = false;
				ThinLine.enabled = false;
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			if (_wasRetracted)
			{
				_isRetracted.PressKey(false, KeyEventHub);
			}
			if (_wasExtended)
			{
				_isExtended.PressKey(false, KeyEventHub);
			}
		}

		protected override void DronePartBreak()
		{
			ThickLine.enabled = false;
			ThinLine.enabled = false;
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_extend = new KeyBinding("Extend", KeyCode.None, false);
			_retract = new KeyBinding("Retract", KeyCode.None, false);
			return new List<KeyBinding> { _extend, _retract };
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_isExtended = new EventKeyBinding("Fully extended", KeyCode.None);
			_isRetracted = new EventKeyBinding("Fully retracted", KeyCode.None);
			return new List<EventKeyBinding> { _isExtended, _isRetracted };
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Speed") + ": " + LabelHelper.Orange + ExtendSpeed + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Range") + ": " + LabelHelper.Orange + ExtendDistance;
		}

		public override NimbatusItemData CreateData()
		{
			return new PistonData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			PistonData pistonData;
			if ((pistonData = data as PistonData) != null)
			{
				pistonData.Distance = ExtendDistance;
				pistonData.Speed = ExtendSpeed;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			PistonData pistonData;
			if ((pistonData = data as PistonData) != null)
			{
				ExtendDistance = pistonData.Distance;
				ExtendSpeed = pistonData.Speed;
			}
		}
	}
}
