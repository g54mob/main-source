using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class GravitySensor : SensorPart
	{
		private const int MinTolerance = 1;

		private const int MaxTolerance = 360;

		[HideInInspector]
		[IntSetting("DronePartSettings/Tolerance", 1, 360, 1000, UndoManager.EStoreReason.GravitySensorTolerance)]
		public int Tolerance = 10;

		[HideInInspector]
		[EnumSetting("DronePartSettings/Target", UndoManager.EStoreReason.GravitySensorTarget)]
		public ESensorDirectionTarget DirectionTarget;

		[HideInInspector]
		[EnumSetting("DronePartSettings/FallbackTarget", UndoManager.EStoreReason.GravitySensorTargetFallback)]
		public ESensorDirectionTarget DirectionTargetFallback;

		public Renderer ToleranceZone;

		public Renderer RightZone;

		public Renderer LeftZone;

		public GravitySensorPointer Pointer;

		public Color RightZoneColor;

		public Color LeftZoneColor;

		public Color ToleranceZoneColor;

		private EventKeyBinding _rightEvent;

		private EventKeyBinding _leftEvent;

		private bool _rightPressed;

		private bool _leftPressed;

		protected override void Validate()
		{
			base.Validate();
			Tolerance = Mathf.Clamp(Tolerance, 1, 360);
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			return new List<KeyBinding>();
		}

		protected override void Start()
		{
			base.Start();
			LeftZone.material.SetColor("_Color", LeftZoneColor);
			RightZone.material.SetColor("_Color", RightZoneColor);
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			Vector3 position = Input.mousePosition + new Vector3(0f, 0f, Mathf.Abs(Camera.main.transform.position.z));
			Vector2 mousePos = RuntimeGlobals.MainCamera.ScreenToWorldPoint(position);
			Vector2 myPos = new Vector2(base.transform.position.x, base.transform.position.y);
			Vector2 gravitydir;
			Vector2 vector;
			Vector2 gravitydir2;
			if (GetDirection(DirectionTarget, mousePos, myPos, out gravitydir))
			{
				vector = gravitydir;
				if (DirectionTarget == ESensorDirectionTarget.NextWaypoint)
				{
					TrackWaypoint(true);
				}
			}
			else if (GetDirection(DirectionTargetFallback, mousePos, myPos, out gravitydir2))
			{
				vector = gravitydir2;
				if (DirectionTargetFallback == ESensorDirectionTarget.NextWaypoint)
				{
					TrackWaypoint(true);
				}
			}
			else
			{
				vector = Vector3.zero;
			}
			Pointer.SetDirection(vector);
			Vector3 vector2 = -base.transform.up + new Vector3(0f, 0f, -0.2f);
			float value = 180f - (float)Tolerance / 2f;
			float value2 = 180f + (float)Tolerance / 2f;
			ToleranceZone.material.SetFloat("_Angle1", value);
			ToleranceZone.material.SetFloat("_Angle2", value2);
			ToleranceZone.material.SetColor("_Color", ToleranceZoneColor);
			LeftZone.material.SetFloat("_Angle1", value2);
			LeftZone.material.SetFloat("_Angle2", 360f);
			RightZone.material.SetFloat("_Angle1", 0f);
			RightZone.material.SetFloat("_Angle2", value);
			if (IsActive())
			{
				float num = Vector2.Angle(vector2, vector);
				if (Vector3.Cross(vector2, vector).z > 0f)
				{
					num = 360f - num;
				}
				num -= 180f;
				if (num > -180f + (float)Tolerance / 2f && num <= 0f)
				{
					if (!_rightPressed)
					{
						_rightEvent.PressKey(true, KeyEventHub);
						_rightPressed = true;
						RightZone.material.SetColor("_Color", Color.green);
					}
				}
				else
				{
					if (_rightPressed)
					{
						_rightEvent.PressKey(false, KeyEventHub);
						_rightPressed = false;
					}
					RightZone.material.SetColor("_Color", RightZoneColor);
				}
				if (num > 0f && num < 180f - (float)Tolerance / 2f)
				{
					if (!_leftPressed)
					{
						_leftEvent.PressKey(true, KeyEventHub);
						_leftPressed = true;
						LeftZone.material.SetColor("_Color", Color.green);
					}
				}
				else
				{
					if (_leftPressed)
					{
						_leftEvent.PressKey(false, KeyEventHub);
						_leftPressed = false;
					}
					LeftZone.material.SetColor("_Color", LeftZoneColor);
				}
			}
			if (IsBroken)
			{
				if (_rightPressed)
				{
					_rightEvent.PressKey(false, KeyEventHub);
					_rightPressed = false;
				}
				if (_leftPressed)
				{
					_leftEvent.PressKey(false, KeyEventHub);
					_leftPressed = false;
				}
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			if (_rightPressed)
			{
				_rightEvent.PressKey(false, KeyEventHub);
				_rightPressed = false;
			}
			if (_leftPressed)
			{
				_leftEvent.PressKey(false, KeyEventHub);
				_leftPressed = false;
			}
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_rightEvent = new EventKeyBinding("Tilted Right", KeyCode.None, true);
			_leftEvent = new EventKeyBinding("Tilted Left", KeyCode.None, true);
			return new List<EventKeyBinding> { _rightEvent, _leftEvent };
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Tolerance") + ": " + LabelHelper.Orange + Tolerance + " °";
		}

		public override NimbatusItemData CreateData()
		{
			return new GravitySensorData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			GravitySensorData gravitySensorData;
			if ((gravitySensorData = data as GravitySensorData) != null)
			{
				gravitySensorData.Tolerance = Tolerance;
				gravitySensorData.DirectionTarget = DirectionTarget;
				gravitySensorData.DirectionTargetFallback = DirectionTargetFallback;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			GravitySensorData gravitySensorData;
			if ((gravitySensorData = data as GravitySensorData) != null)
			{
				Tolerance = gravitySensorData.Tolerance;
				DirectionTarget = gravitySensorData.DirectionTarget;
				DirectionTargetFallback = gravitySensorData.DirectionTargetFallback;
			}
		}
	}
}
