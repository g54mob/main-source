using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class ProximitySensor : SensorPart
	{
		[HideInInspector]
		[BoolSetting("DronePartSettings/HideSensor", UndoManager.EStoreReason.HideSensor)]
		public bool HideSensor;

		private const float MinRange = 0f;

		private const float MaxRange = 30f;

		[FloatSetting("DronePartSettings/Range", 0f, 30f, 31, UndoManager.EStoreReason.ProximitySensorRange)]
		public float Range;

		public Renderer SensorArea;

		private const float MinAngle = 10f;

		private const float MaxAngle = 360f;

		[FloatSetting("DronePartSettings/Angle", 10f, 360f, 36, UndoManager.EStoreReason.ProximitySensorAngle)]
		public float Angle;

		[EnumSetting("DronePartSettings/Detection", UndoManager.EStoreReason.DistanceSensor)]
		public ESensorDetectionType DetectionType;

		public tk2dSprite HitLight;

		private EventKeyBinding _detectEvent;

		private LayerMask _layerMask;

		private ESensorDetectionType _startDetectionType;

		private bool _wasDetected;

		protected override void Validate()
		{
			base.Validate();
			Range = Mathf.Clamp(Range, 0f, 30f);
			Angle = Mathf.Clamp(Angle, 10f, 360f);
		}

		protected override void Awake()
		{
			base.Awake();
			DetectionType = ESensorDetectionType.Enemies;
		}

		protected override void Start()
		{
			base.Start();
			_startDetectionType = DetectionType;
			InitLayerMask(RootDrone);
		}

		private void InitLayerMask(NimbatusDrone drone)
		{
			_layerMask = 0;
			if (!(drone != null))
			{
				return;
			}
			foreach (KeyValuePair<ESensorDetectionType, LayerMask> sensorLayerMask in drone.SensorLayerMasks)
			{
				if (DetectionType.HasFlag(sensorLayerMask.Key) && sensorLayerMask.Key != ESensorDetectionType.MissionTarget)
				{
					_layerMask = (int)_layerMask | (int)sensorLayerMask.Value;
				}
			}
		}

		public override void PrepareForImage()
		{
			base.PrepareForImage();
			SensorArea.gameObject.SetActive(false);
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			return new List<KeyBinding>();
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (_startDetectionType != DetectionType)
			{
				InitLayerMask(RootDrone);
			}
			if (IsBroken)
			{
				return;
			}
			bool flag = Raycast();
			if (IsActive())
			{
				VisualizeDetection(flag);
				if (flag && !_wasDetected)
				{
					_detectEvent.PressKey(true, KeyEventHub);
				}
				else if (_wasDetected && !flag)
				{
					_detectEvent.PressKey(false, KeyEventHub);
				}
				_wasDetected = flag;
			}
			else
			{
				VisualizeDetection(RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization && flag);
			}
		}

		public override void Update()
		{
			base.Update();
			if (!IsBroken && !HideSensor)
			{
				SensorArea.gameObject.SetActive(true);
			}
			else
			{
				SensorArea.gameObject.SetActive(false);
			}
		}

		public void VisualizeDetection(bool detected)
		{
			float value = 180f - Angle / 2f;
			float value2 = 180f + Angle / 2f;
			Color red = Color.red;
			red.a = 0.075f;
			Color green = Color.green;
			green.a = 0.075f;
			SensorArea.gameObject.transform.localScale = Vector3.one * Range * 2f;
			SensorArea.material.SetFloat("_Angle1", value);
			SensorArea.material.SetFloat("_Angle2", value2);
			SensorArea.material.SetColor("_Color", detected ? green : red);
			if (detected)
			{
				HitLight.color = Color.green;
			}
			else
			{
				HitLight.color = Color.red;
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			if (_wasDetected)
			{
				_detectEvent.PressKey(false, KeyEventHub);
			}
		}

		public bool Raycast()
		{
			for (float num = (0f - Angle) / 2f; num <= Angle / 2f; num += Angle / 20f)
			{
				if (Raycast(Quaternion.AngleAxis(num, Vector3.forward) * base.transform.right))
				{
					return true;
				}
			}
			return false;
		}

		public bool Raycast(Vector3 direction)
		{
			Vector3 position = base.transform.position;
			position.z = 0f;
			Ray ray = new Ray(position, direction);
			RaycastHit[] array = Physics.RaycastAll(ray, Range, _layerMask);
			bool flag = array.Length != 0;
			if (!flag && !DetectionType.Contains(ESensorDetectionType.OwnDrone))
			{
				ray.origin = ray.GetPoint(Range);
				ray.direction = -ray.direction;
				array = Physics.RaycastAll(ray, Range, _layerMask);
				flag = array.Length != 0;
			}
			bool flag2 = false;
			Vector2 hitPoint;
			if (flag)
			{
				flag2 = CheckRay(array, out hitPoint, false, _layerMask);
			}
			if (!flag2 && DetectionType.Contains(ESensorDetectionType.MissionTarget))
			{
				LayerMask layerMask = 0;
				layerMask = (int)layerMask | (int)RootDrone.SensorLayerMasks[ESensorDetectionType.MissionTarget];
				RaycastHit[] array2 = Physics.RaycastAll(new Ray(position, direction), Range, layerMask);
				if (array2.Length != 0)
				{
					flag2 = CheckRay(array2, out hitPoint, true, layerMask);
				}
			}
			return flag2;
		}

		private bool CheckRay(RaycastHit[] allHits, out Vector2 hitPoint, bool checkMissionTargets, LayerMask mask)
		{
			RaycastHit raycastHit = allHits[0];
			float num = Range;
			for (int i = 0; i < allHits.Length; i++)
			{
				RaycastHit raycastHit2 = allHits[i];
				float magnitude = (raycastHit2.point - base.transform.position).magnitude;
				if (magnitude < num)
				{
					num = magnitude;
					raycastHit = raycastHit2;
				}
			}
			bool flag = mask.Contains(raycastHit.collider.gameObject.layer);
			if (raycastHit.collider.gameObject.layer == 8 && DetectionType.Contains(ESensorDetectionType.Resources) && !DetectionType.Contains(ESensorDetectionType.Terrain))
			{
				flag = TerrainModificationHelper.IsCollectable(raycastHit.point);
			}
			if (checkMissionTargets)
			{
				GameObject g = ((raycastHit.rigidbody != null) ? raycastHit.rigidbody.gameObject : raycastHit.collider.gameObject);
				flag = BaseSingleton<MissionTargetManager>.Instance.IsDetectedAsMissionTarget(g);
			}
			if (raycastHit.collider.gameObject != base.gameObject && flag)
			{
				hitPoint = raycastHit.point;
				return true;
			}
			hitPoint = Vector2.zero;
			return false;
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_detectEvent = new EventKeyBinding("Detection Event", KeyCode.None, true);
			return new List<EventKeyBinding> { _detectEvent };
		}

		public void OnDestroy()
		{
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Range") + ": " + LabelHelper.Orange + Range + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Angle") + ": " + LabelHelper.Orange + Angle + "°";
		}

		public override NimbatusItemData CreateData()
		{
			return new ProximitySensorData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			ProximitySensorData proximitySensorData;
			if ((proximitySensorData = data as ProximitySensorData) != null)
			{
				proximitySensorData.DetectionType = DetectionType;
				proximitySensorData.Range = Range;
				proximitySensorData.Angle = Angle;
				proximitySensorData.HideSensor = HideSensor;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			ProximitySensorData proximitySensorData;
			if ((proximitySensorData = data as ProximitySensorData) != null)
			{
				DetectionType = proximitySensorData.DetectionType;
				Angle = proximitySensorData.Angle;
				Range = proximitySensorData.Range;
				HideSensor = proximitySensorData.HideSensor;
			}
		}
	}
}
