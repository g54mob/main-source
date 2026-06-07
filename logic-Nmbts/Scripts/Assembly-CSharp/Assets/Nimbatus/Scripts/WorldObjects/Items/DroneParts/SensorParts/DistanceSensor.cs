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
using Vectrosity;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class DistanceSensor : SensorPart
	{
		[HideInInspector]
		[BoolSetting("DronePartSettings/HideSensor", UndoManager.EStoreReason.HideSensor)]
		public bool HideSensor;

		private const float MinRange = 0f;

		private const float MaxRange = 100f;

		[FloatSetting("DronePartSettings/Range", 0f, 100f, 101, UndoManager.EStoreReason.DistanceSensorRange)]
		public float Range;

		[EnumSetting("DronePartSettings/Detection", UndoManager.EStoreReason.DistanceSensor)]
		public ESensorDetectionType DetectionType;

		public float Width;

		public Material LineMaterial;

		public tk2dSprite HitLight;

		private VectorLine _line;

		private Vector3[] _linePoints;

		private EventKeyBinding _detectEvent;

		private LayerMask _layerMask;

		private bool _wasDetected;

		private ESensorDetectionType _startDetectionType;

		private Vector2 _lastHitPoint;

		protected override void Validate()
		{
			base.Validate();
			Range = Mathf.Clamp(Range, 0f, 100f);
		}

		protected override void Awake()
		{
			base.Awake();
			Range = 10f;
			DetectionType = ESensorDetectionType.Enemies;
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

		protected override void Start()
		{
			base.Start();
			_startDetectionType = DetectionType;
			InitLayerMask(RootDrone);
			_linePoints = new Vector3[20];
			float width = Width * 0.005f * (float)Mathf.Max(900, RuntimeGlobals.MainCamera.pixelHeight);
			_line = new VectorLine("laser", _linePoints, LineMaterial, width, LineType.Continuous, Joins.Fill);
			_line.SetColor(Color.red);
			_wasDetected = false;
			_lastHitPoint = base.transform.position + base.transform.right * Range;
		}

		public override void PrepareForImage()
		{
			base.PrepareForImage();
			_line.active = false;
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
			if (!IsBroken)
			{
				bool flag = Raycast(base.transform.right);
				if (IsActive())
				{
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
			}
			else
			{
				_line.active = false;
			}
		}

		public override void Update()
		{
			base.Update();
			_line.active = !HideSensor;
			if (!IsBroken && !HideSensor)
			{
				if (_line.color == Color.red)
				{
					_lastHitPoint = base.transform.position + base.transform.right * Range;
				}
				ShowBeam(base.transform.position, Vector2.Distance(base.transform.position, _lastHitPoint));
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
			_lastHitPoint = base.transform.position + direction * Range;
			bool flag2 = false;
			if (flag)
			{
				flag2 = CheckRay(array, out _lastHitPoint, false, _layerMask);
			}
			if (!flag2 && DetectionType.Contains(ESensorDetectionType.MissionTarget))
			{
				LayerMask layerMask = 0;
				layerMask = (int)layerMask | (int)RootDrone.SensorLayerMasks[ESensorDetectionType.MissionTarget];
				RaycastHit[] array2 = Physics.RaycastAll(new Ray(position, direction), Range, layerMask);
				if (array2.Length != 0)
				{
					flag2 = CheckRay(array2, out _lastHitPoint, true, layerMask);
				}
			}
			if (flag2)
			{
				HitLight.color = Color.green;
				_line.SetColor(Color.green);
			}
			else
			{
				HitLight.color = Color.red;
				_line.SetColor(Color.red);
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
			DestroyBeam();
		}

		public void ShowBeam(Vector3 startPos, float distance)
		{
			_linePoints = new Vector3[2]
			{
				startPos,
				startPos + base.transform.right * distance
			};
			if (_line != null)
			{
				_line.Resize(_linePoints);
				_line.SetTextureScale(1f);
				_line.Draw3D();
			}
		}

		public void DestroyBeam()
		{
			if (_line != null)
			{
				_line.active = false;
				VectorLine.Destroy(ref _line);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Range") + ": " + LabelHelper.Orange + Range;
		}

		public override NimbatusItemData CreateData()
		{
			return new DistanceSensorData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			DistanceSensorData distanceSensorData;
			if ((distanceSensorData = data as DistanceSensorData) != null)
			{
				distanceSensorData.Range = Range;
				distanceSensorData.DetectionType = DetectionType;
				distanceSensorData.HideSensor = HideSensor;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			DistanceSensorData distanceSensorData;
			if ((distanceSensorData = data as DistanceSensorData) != null)
			{
				Range = distanceSensorData.Range;
				DetectionType = distanceSensorData.DetectionType;
				HideSensor = distanceSensorData.HideSensor;
			}
		}
	}
}
