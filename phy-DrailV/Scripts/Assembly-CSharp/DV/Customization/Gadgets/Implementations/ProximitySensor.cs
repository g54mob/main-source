using System.Collections;
using DV.CabControls;
using DV.CabControls.Spec;
using DV.Items;
using DV.JObjectExtstensions;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class ProximitySensor : MonoBehaviour
	{
		private const string KEY_CHANNEL = "channelKnob";

		private const string KEY_RANGE = "rangeKnob";

		private const float NO_LOAD_ON_ENABLE = -1f;

		private static readonly Collider[] trainCarHits = new Collider[128];

		private static int scanLayerMask = -1;

		public float backOffset = 2f;

		public float deduction = 0.2f;

		[Range(0f, 1f)]
		public float coneWidth = 0.1f;

		public float collumnWidth = 12f;

		public float collumnHeight = 24f;

		public float measurementInterval = 0.25f;

		public float[] rangeSettings = new float[6] { 100f, 50f, 20f, 10f, 5f, 2f };

		public Rotary rotChannel;

		public Rotary rotRange;

		public AudioClip couplerSnapSound;

		public AudioClip couplerUnsnapSound;

		public Transform handleTransform;

		public Vector3 handleSnappedRotation;

		private ControlImplBase rotaryChannel;

		private ControlImplBase rotaryRange;

		private float timestamp;

		private float lastDistance;

		private float newDistance;

		private int channel;

		private SnappableItem snappable;

		private float loadOnEnableRange = -1f;

		private float loadOnEnableChannel = -1f;

		private Coroutine loadInteractablesCoro;

		public int RangeSetting { get; set; }

		public float Range => rangeSettings[RangeSetting];

		public TrainCar SnappedToCar
		{
			get
			{
				if (!(snappable.SnappedTo is ItemSnapPointCoupler itemSnapPointCoupler))
				{
					return null;
				}
				return itemSnapPointCoupler.Car;
			}
		}

		public ItemSnapPointCoupler SnappedToCoupler
		{
			get
			{
				if (!(snappable.SnappedTo is ItemSnapPointCoupler result))
				{
					return null;
				}
				return result;
			}
		}

		public int Channel
		{
			get
			{
				return channel;
			}
			set
			{
				if (channel != value)
				{
					channel = value;
					SingletonBehaviour<ProximitySensorNetwork>.Instance.RaiseSensorSettingsChanged(this);
				}
			}
		}

		private void Awake()
		{
			if (scanLayerMask == -1)
			{
				scanLayerMask = LayerMask.GetMask("Train_Big_Collider");
			}
			SetupListeners(on: true);
		}

		private void OnEnable()
		{
			if (loadOnEnableRange != -1f || loadOnEnableChannel != -1f)
			{
				if (loadInteractablesCoro != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Stop(loadInteractablesCoro);
				}
				loadInteractablesCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(LoadInteractablesCoro());
			}
		}

		private void Start()
		{
			rotaryChannel = rotChannel.GetComponent<ControlImplBase>();
			rotaryRange = rotRange.GetComponent<ControlImplBase>();
			rotaryChannel.ValueChanged += ChannelChanged;
			rotaryRange.ValueChanged += RangeChanged;
			ChannelChanged(new ValueChangedEventArgs(rotaryChannel.Value, rotaryChannel.Value));
			RangeChanged(new ValueChangedEventArgs(rotaryRange.Value, rotaryRange.Value));
			snappable = GetComponent<SnappableItem>();
			snappable.ItemSnappingChanged += SnappedChanged;
			SnappedChanged(snappable, snappable.IsSnapped, SnapPointTypes.None);
		}

		private void SetupListeners(bool on)
		{
			ItemSaveData component = GetComponent<ItemSaveData>();
			if (on)
			{
				component.ItemSaveDataRequested += OnItemSaveDataRequested;
				component.ItemSaveDataLoaded += OnItemSaveDataLoaded;
			}
			else
			{
				component.ItemSaveDataRequested -= OnItemSaveDataRequested;
				component.ItemSaveDataLoaded -= OnItemSaveDataLoaded;
			}
		}

		private void OnItemSaveDataLoaded(JObject data)
		{
			if (!rotaryChannel || !rotaryRange)
			{
				Debug.LogError("SaveDataLoaded called before rotaries were set up!");
				return;
			}
			bool activeInHierarchy = base.gameObject.activeInHierarchy;
			float? num = data.GetFloat("channelKnob");
			if (num.HasValue)
			{
				if (activeInHierarchy)
				{
					rotaryChannel.SetValue(num.Value);
				}
				else
				{
					loadOnEnableChannel = num.Value;
					ChannelChanged(new ValueChangedEventArgs(loadOnEnableChannel, loadOnEnableChannel));
				}
			}
			float? num2 = data.GetFloat("rangeKnob");
			if (num2.HasValue)
			{
				if (activeInHierarchy)
				{
					rotaryRange.SetValue(num2.Value);
					return;
				}
				loadOnEnableRange = num2.Value;
				RangeChanged(new ValueChangedEventArgs(loadOnEnableRange, loadOnEnableRange));
			}
		}

		private IEnumerator LoadInteractablesCoro()
		{
			yield return null;
			yield return null;
			if (!base.gameObject.activeInHierarchy)
			{
				Debug.LogWarning("ProximitySensor GO got disabled while in LoadInteractablesCoro", this);
				loadInteractablesCoro = null;
				yield break;
			}
			if (loadOnEnableChannel != -1f)
			{
				rotaryChannel.SetValue(loadOnEnableChannel);
				loadOnEnableChannel = -1f;
			}
			if (loadOnEnableRange != -1f)
			{
				rotaryRange.SetValue(loadOnEnableRange);
				loadOnEnableRange = -1f;
			}
			loadInteractablesCoro = null;
		}

		private JObject OnItemSaveDataRequested(JObject data)
		{
			if (!rotaryChannel || !rotaryRange)
			{
				Debug.LogError("SaveDataLoaded called before rotaries were set up!");
				return data;
			}
			data.SetFloat("channelKnob", (loadOnEnableChannel == -1f) ? rotaryChannel.Value : loadOnEnableChannel);
			data.SetFloat("rangeKnob", (loadOnEnableRange == -1f) ? rotaryRange.Value : loadOnEnableRange);
			return data;
		}

		public float ReadDistance()
		{
			float num = timestamp - Time.time;
			if (num < 0f)
			{
				timestamp = Time.time + measurementInterval;
				lastDistance = newDistance;
				Measure(out newDistance);
				num = measurementInterval;
			}
			float num2 = Mathf.LerpUnclamped(newDistance, lastDistance, num / measurementInterval);
			if (num2 > Range)
			{
				num2 = Range;
			}
			return num2;
		}

		private void SnappedChanged(SnappableItem item, bool snapped, SnapPointTypes _)
		{
			if (snapped)
			{
				lastDistance = rangeSettings[rangeSettings.Length - 1];
				newDistance = lastDistance;
				timestamp = 0f;
				if (!SingletonBehaviour<ProximitySensorNetwork>.Instance.active.Contains(this))
				{
					SingletonBehaviour<ProximitySensorNetwork>.Instance.active.Add(this);
					SingletonBehaviour<ProximitySensorNetwork>.Instance.RaiseSensorSettingsChanged(this);
				}
				couplerSnapSound.Play(item.SnappedTo.transform.position);
				handleTransform.localEulerAngles = handleSnappedRotation;
			}
			else
			{
				if (SingletonBehaviour<ProximitySensorNetwork>.Instance.active.Remove(this))
				{
					SingletonBehaviour<ProximitySensorNetwork>.Instance.RaiseSensorSettingsChanged(this);
				}
				couplerUnsnapSound.Play(base.transform.position);
				handleTransform.localEulerAngles = Vector3.zero;
			}
		}

		private bool Measure(out float distance)
		{
			Vector3 checkDirection = base.transform.forward;
			Vector3 checkPosition = base.transform.position - checkDirection * backOffset;
			float num = rangeSettings[RangeSetting];
			float d = num + backOffset;
			bool hasAny = false;
			distance = num;
			TrainCar snappedToCar = SnappedToCar;
			if (snappedToCar == null)
			{
				return false;
			}
			int num2 = Physics.OverlapBoxNonAlloc(checkPosition + checkDirection * (num / 2f), new Vector3(collumnWidth / 2f, collumnHeight / 2f, num / 2f), trainCarHits, base.transform.rotation, scanLayerMask, QueryTriggerInteraction.Ignore);
			for (int i = 0; i < num2; i++)
			{
				Collider collider = trainCarHits[i];
				TrainCar trainCar = TrainCar.Resolve(collider.gameObject);
				if (trainCar == snappedToCar)
				{
					continue;
				}
				if (trainCar != null)
				{
					if (trainCar.frontCoupler != null)
					{
						Qualify(trainCar.frontCoupler.transform.position);
					}
					if (trainCar.rearCoupler != null)
					{
						Qualify(trainCar.rearCoupler.transform.position);
					}
				}
				if (!(trainCar != null))
				{
					BufferStop componentInParent = collider.GetComponentInParent<BufferStop>();
					if (componentInParent != null)
					{
						Qualify(componentInParent.transform.TransformPoint(BufferStop.COUPLER_POINT));
					}
				}
			}
			if (!hasAny)
			{
				return false;
			}
			d -= backOffset + deduction;
			if (d <= 0f)
			{
				d = 0f;
			}
			distance = d;
			return true;
			void Qualify(Vector3 position)
			{
				Vector3 vector = position - checkPosition;
				float sqrMagnitude = vector.sqrMagnitude;
				if (!(sqrMagnitude > d * d))
				{
					float num3 = Mathf.Sqrt(sqrMagnitude);
					if (!(Vector3.Dot(vector / num3, checkDirection) <= 1f - coneWidth))
					{
						hasAny = true;
						d = num3;
					}
				}
			}
		}

		private void ChannelChanged(ValueChangedEventArgs value)
		{
			Channel = Mathf.RoundToInt(value.newValue * (float)(rotChannel.notches - 1));
		}

		private void RangeChanged(ValueChangedEventArgs value)
		{
			RangeSetting = Mathf.RoundToInt(value.newValue * (float)(rotRange.notches - 1));
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<ProximitySensorNetwork>.Instance.active.Remove(this);
				if (loadInteractablesCoro != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Stop(loadInteractablesCoro);
				}
			}
			SetupListeners(on: false);
		}

		private void OnDrawGizmosSelected()
		{
			float num = rangeSettings[RangeSetting];
			Vector3 forward = base.transform.forward;
			Vector3 vector = base.transform.position - forward * backOffset;
			Gizmos.matrix = Matrix4x4.TRS(vector + forward * (num / 2f), base.transform.rotation, new Vector3(collumnWidth / 2f, collumnHeight / 2f, num / 2f));
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one * 2f);
			Gizmos.matrix = Matrix4x4.identity;
			float num2 = Mathf.Acos(1f - coneWidth) * 57.29578f;
			forward *= num;
			Gizmos.DrawLine(vector, vector + Quaternion.Euler(num2, 0f, 0f) * forward);
			Gizmos.DrawLine(vector, vector + Quaternion.Euler(0f - num2, 0f, 0f) * forward);
			Gizmos.DrawLine(vector, vector + Quaternion.Euler(0f, num2, 0f) * forward);
			Gizmos.DrawLine(vector, vector + Quaternion.Euler(0f, 0f - num2, 0f) * forward);
		}
	}
}
