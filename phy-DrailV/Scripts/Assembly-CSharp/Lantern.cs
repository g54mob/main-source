using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.Hazmat;
using DV.Interaction;
using DV.Items;
using DV.JObjectExtstensions;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class Lantern : MonoBehaviour, IIgnitable, IInteractionPointProvider
{
	private const string STATE_SAVE_KEY = "On";

	private const string WICK_STATE_KEY = "Wick_state";

	private const float WICK_DEFAULT_VALUE = 1f;

	[SerializeField]
	private LanternFlame flame;

	[SerializeField]
	private GameObject rotaryGO;

	[SerializeField]
	private Transform wick;

	[SerializeField]
	private SphereCollider ignitionCollider;

	private ControlImplBase knob;

	private Rigidbody wickRigidbody;

	[SerializeField]
	private Vector3 wickScrollingRelativeTorque = new Vector3(0f, 1.5E-05f, 0f);

	[SerializeField]
	private Vector3 wickLocalPositionMin = new Vector3(0f, 0f, 0.19733f);

	[SerializeField]
	private Vector3 wickLocalPositionMax = new Vector3(0f, 0f, 0.18693f);

	private float wickSize;

	private ItemScrolling wickScrolling;

	private ItemSaveData itemSaveData;

	private Coroutine initCoro;

	private bool initialized;

	private bool loadKnobValueOnEnable;

	private TrainItemActivityHandlerOverrideDynamic activityHandler;

	private Dictionary<MeshRenderer, ShadowCastingMode> meshRendererShadowCastingModeCache = new Dictionary<MeshRenderer, ShadowCastingMode>();

	private Igniter igniter;

	public bool Ignited
	{
		get
		{
			if (!igniter)
			{
				return false;
			}
			return igniter.enabled;
		}
	}

	public bool IgnitionAllowed
	{
		get
		{
			if (!Ignited && wickSize > 0f)
			{
				return !flame.IsUnderWater();
			}
			return false;
		}
	}

	public SphereCollider OverlapInteractionCollider => ignitionCollider;

	public Transform InteractionPoint
	{
		get
		{
			if (!(flame != null))
			{
				return null;
			}
			return flame.transform;
		}
	}

	private void Awake()
	{
		igniter = ignitionCollider.gameObject.AddComponent<Igniter>();
		igniter.enabled = false;
		igniter.ignitionStrength = 1f;
		igniter.objectsRadius = ignitionCollider.radius;
		igniter.terrainClearance = 0f;
		igniter.SetIgnoredIgnitable(this);
		activityHandler = GetComponent<TrainItemActivityHandlerOverrideDynamic>();
		flame.FlameIgnited += OnFlameIgnited;
		flame.FlameExtinguished += OnFlameExtinguished;
		UpdateWickRelatedLogic(1f);
		if (TryGetComponent<ItemSaveData>(out itemSaveData))
		{
			itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
			itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
		}
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer meshRenderer in componentsInChildren)
		{
			meshRendererShadowCastingModeCache.Add(meshRenderer, meshRenderer.shadowCastingMode);
		}
		initCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(DelayedInitialize());
	}

	private void OnFlameIgnited()
	{
		igniter.enabled = true;
		foreach (KeyValuePair<MeshRenderer, ShadowCastingMode> item in meshRendererShadowCastingModeCache)
		{
			MeshRenderer key = item.Key;
			if (!(key == null))
			{
				key.shadowCastingMode = ShadowCastingMode.Off;
			}
		}
		activityHandler.ToggleRange(longRange: true);
	}

	private void OnFlameExtinguished()
	{
		igniter.enabled = false;
		foreach (KeyValuePair<MeshRenderer, ShadowCastingMode> item in meshRendererShadowCastingModeCache)
		{
			MeshRenderer key = item.Key;
			if (!(key == null))
			{
				key.shadowCastingMode = item.Value;
			}
		}
		activityHandler.ToggleRange(longRange: false);
	}

	private void OnEnable()
	{
		if (loadKnobValueOnEnable)
		{
			StartCoroutine(DelayedSetKnobValue());
		}
	}

	private IEnumerator DelayedSetKnobValue()
	{
		yield return WaitFor.FixedUpdate;
		knob.SetValue(wickSize);
		yield return WaitFor.FixedUpdate;
		knob.SetValue(wickSize);
		UpdateWickRelatedLogic(wickSize);
		loadKnobValueOnEnable = false;
	}

	private void OnDestroy()
	{
		if (initCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.StopCoroutine(initCoro);
		}
		SetupListeners(on: false);
	}

	private IEnumerator DelayedInitialize()
	{
		yield return WaitFor.EndOfFrame;
		Initialize();
		initCoro = null;
	}

	protected virtual void Initialize()
	{
		knob = rotaryGO.GetComponent<ControlImplBase>();
		wickRigidbody = knob.GetComponent<Rigidbody>();
		if (VRManager.IsVREnabled())
		{
			wickScrolling = base.gameObject.AddComponent<ItemScrollingVR>();
		}
		else
		{
			wickScrolling = base.gameObject.AddComponent<ItemScrollingNonVR>();
		}
		SetupListeners(on: true);
	}

	protected virtual void SetupListeners(bool on)
	{
		if (on)
		{
			if ((bool)knob)
			{
				knob.ValueChanged += OnWickValueChanged;
			}
			if ((bool)wickScrolling)
			{
				wickScrolling.Scrolled += OnWickScrolled;
			}
			return;
		}
		if ((bool)knob)
		{
			knob.ValueChanged -= OnWickValueChanged;
		}
		if ((bool)wickScrolling)
		{
			wickScrolling.Scrolled -= OnWickScrolled;
		}
		if ((bool)itemSaveData)
		{
			itemSaveData.ItemSaveDataLoaded -= OnItemSaveDataLoaded;
			itemSaveData.ItemSaveDataRequested -= OnItemSaveDataRequested;
		}
	}

	private void OnWickScrolled(ScrollAction direction)
	{
		wickRigidbody.AddRelativeTorque(wickScrollingRelativeTorque * direction.IsPositive().ToDir(), ForceMode.Impulse);
	}

	private void OnWickValueChanged(ValueChangedEventArgs args)
	{
		UpdateWickRelatedLogic(args.newValue);
	}

	private void UpdateWickRelatedLogic(float desiredWickValue)
	{
		desiredWickValue = Mathf.Clamp01(desiredWickValue);
		SetWickLocalPosition(desiredWickValue);
		if (flame.IsLit)
		{
			flame.UpdateFlameIntensity(desiredWickValue);
		}
	}

	private void SetWickLocalPosition(float relativeValue)
	{
		wickSize = Mathf.Clamp01(relativeValue);
		wick.localPosition = Vector3.Lerp(wickLocalPositionMin, wickLocalPositionMax, wickSize);
	}

	private void OnItemSaveDataLoaded(JObject data)
	{
		if (data == null)
		{
			knob.SetValue(1f);
			return;
		}
		float? num = data.GetFloat("Wick_state");
		float valueOrDefault = num.GetValueOrDefault();
		if (num.HasValue)
		{
			wickSize = Mathf.Clamp01(valueOrDefault);
		}
		else
		{
			wickSize = 1f;
		}
		bool? flag = data.GetBool("On");
		bool valueOrDefault2 = flag == true;
		if (flag.HasValue && valueOrDefault2)
		{
			flame.UpdateFlameIntensity(wickSize, forced: true);
		}
		if (base.gameObject.activeInHierarchy)
		{
			knob.SetValue(wickSize);
			UpdateWickRelatedLogic(wickSize);
		}
		else
		{
			loadKnobValueOnEnable = true;
		}
	}

	private JObject OnItemSaveDataRequested(JObject data)
	{
		if (flame.IsLit)
		{
			data.SetBool("On", value: true);
		}
		else
		{
			data.Remove("On");
		}
		if (wickSize >= 0.99f)
		{
			data.Remove("Wick_state");
		}
		else
		{
			data.SetFloat("Wick_state", wickSize);
		}
		return data;
	}

	public bool Ignite(float _)
	{
		if (flame.IsUnderWater())
		{
			return false;
		}
		flame.UpdateFlameIntensity(wickSize);
		return true;
	}

	public Transform GetTransform()
	{
		return base.transform;
	}
}
