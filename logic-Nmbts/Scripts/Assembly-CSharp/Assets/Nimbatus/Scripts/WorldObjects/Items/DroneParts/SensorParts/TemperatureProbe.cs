using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;
using Vectrosity;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class TemperatureProbe : SensorPart
	{
		[HideInInspector]
		[BoolSetting("DronePartSettings/HideSensor", UndoManager.EStoreReason.HideSensor)]
		public bool HideSensor;

		private const float MinRange = 0f;

		private const float MaxRange = 100f;

		private const int MinTemp = -100;

		private const int MaxTemp = 100;

		public float Range;

		[IntSetting("DronePartSettings/MinTemperature", -100, 100, 200, UndoManager.EStoreReason.TemperatureProbeMin)]
		public int MinTemperature;

		[IntSetting("DronePartSettings/MaxTemperature", -100, 100, 200, UndoManager.EStoreReason.TemperatureProbeMax)]
		public int MaxTemperature;

		[EnumSetting("DronePartSettings/Detection", UndoManager.EStoreReason.TemperatureProbeDetection)]
		public ETemperatureProbeDetectionType DetectionType;

		public float Width;

		public Material LineMaterial;

		public tk2dSprite HitLight;

		private VectorLine _line;

		private Vector3[] _linePoints;

		private EventKeyBinding _detectEvent;

		private LayerMask _layerMask;

		private bool _wasDetected;

		private ETemperatureProbeDetectionType _startDetectionType;

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
			DetectionType = ETemperatureProbeDetectionType.OtherObjects;
		}

		private void InitLayerMask(NimbatusDrone drone)
		{
			_layerMask = 0;
			if (drone != null)
			{
				if (DetectionType == ETemperatureProbeDetectionType.DroneParts)
				{
					AddToLayer(drone, ESensorDetectionType.OwnDrone, ref _layerMask);
				}
				if (DetectionType == ETemperatureProbeDetectionType.OtherObjects)
				{
					AddToLayer(drone, ESensorDetectionType.Enemies, ref _layerMask);
					AddToLayer(drone, ESensorDetectionType.EnemyStructures, ref _layerMask);
					AddToLayer(drone, ESensorDetectionType.CollectableObject, ref _layerMask);
					AddToLayer(drone, ESensorDetectionType.Obstacles, ref _layerMask);
				}
			}
		}

		private void AddToLayer(NimbatusDrone drone, ESensorDetectionType sensorDetection, ref LayerMask mask)
		{
			foreach (KeyValuePair<ESensorDetectionType, LayerMask> sensorLayerMask in drone.SensorLayerMasks)
			{
				if (sensorDetection.HasFlag(sensorLayerMask.Key))
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
			Ray ray = new Ray(base.transform.position, direction);
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
				RaycastHit raycastHit = array[0];
				float num = Range;
				RaycastHit[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					RaycastHit raycastHit2 = array2[i];
					float magnitude = (raycastHit2.point - base.transform.position).magnitude;
					if (magnitude < num)
					{
						num = magnitude;
						raycastHit = raycastHit2;
					}
				}
				bool flag3 = _layerMask.Contains(raycastHit.collider.gameObject.layer);
				HealthPool component = raycastHit.collider.gameObject.GetComponent<HealthPool>();
				if (raycastHit.collider.gameObject != base.gameObject && flag3 && component != null && component.CurrentTemperature <= (float)MaxTemperature && component.CurrentTemperature >= (float)MinTemperature)
				{
					flag2 = true;
					_lastHitPoint = raycastHit.point;
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
			return new TemperatureProbeData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			TemperatureProbeData temperatureProbeData;
			if ((temperatureProbeData = data as TemperatureProbeData) != null)
			{
				temperatureProbeData.DetectionType = DetectionType;
				temperatureProbeData.MinTemp = MinTemperature;
				temperatureProbeData.MaxTemp = MaxTemperature;
				temperatureProbeData.HideSensor = HideSensor;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			TemperatureProbeData temperatureProbeData;
			if ((temperatureProbeData = data as TemperatureProbeData) != null)
			{
				DetectionType = temperatureProbeData.DetectionType;
				MinTemperature = temperatureProbeData.MinTemp;
				MaxTemperature = temperatureProbeData.MaxTemp;
				HideSensor = temperatureProbeData.HideSensor;
			}
		}
	}
}
