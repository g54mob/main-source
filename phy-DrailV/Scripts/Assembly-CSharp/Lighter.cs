using System.Collections;
using DV.CabControls;
using DV.Hazmat;
using DV.Interaction;
using DV.Items;
using DV.JObjectExtstensions;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Lighter : MonoBehaviour, IIgnitable, IInteractionPointProvider
{
	private const string LIGHTER_STATE_SAVE_KEY = "Lighter_state";

	private static readonly int ANIMATION_SPEED_HASH = Animator.StringToHash("animation_speed");

	[Header("Lighter elements")]
	public ItemFlameBase flame;

	public ParticleSystem sparks;

	[Header("Audio")]
	public AudioClip openSound;

	public AudioClip closeSound;

	public AudioClip flintSound;

	public bool isOpen;

	private ItemBase item;

	private Animator lighterAnimator;

	[SerializeField]
	private float animationSpeed;

	[SerializeField]
	private SphereCollider ignitionCollider;

	private Igniter igniter;

	private ItemScrolling scrolling;

	private ItemSaveData itemSaveData;

	private TrainItemActivityHandlerOverrideDynamic activityHandler;

	private Coroutine initCoro;

	public bool Ignited => igniter.enabled;

	public bool IgnitionAllowed
	{
		get
		{
			if (isOpen && !Ignited)
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
		igniter.terrainClearance = 1f;
		igniter.SetIgnoredIgnitable(this);
		lighterAnimator = GetComponent<Animator>();
		lighterAnimator.keepAnimatorControllerStateOnDisable = true;
		lighterAnimator.SetFloat(ANIMATION_SPEED_HASH, animationSpeed);
		flame.FlameIgnited += OnFlameIgnited;
		flame.FlameExtinguished += OnFlameExtinguished;
		activityHandler = GetComponent<TrainItemActivityHandlerOverrideDynamic>();
		if (TryGetComponent<ItemSaveData>(out itemSaveData))
		{
			itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
			itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
		}
	}

	private void Start()
	{
		initCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Init());
	}

	private IEnumerator Init()
	{
		yield return WaitFor.EndOfFrame;
		item = GetComponent<ItemBase>();
		if (item == null)
		{
			Debug.LogError("Couldn't find ItemBase on Lighter!", this);
		}
		if (VRManager.IsVREnabled())
		{
			ItemScrollingVR itemScrollingVR = base.gameObject.AddComponent<ItemScrollingVR>();
			scrolling = itemScrollingVR;
		}
		else
		{
			scrolling = base.gameObject.AddComponent<ItemScrollingNonVR>();
		}
		scrolling.invertHorizontal = true;
		SetupListeners(on: true);
		initCoro = null;
	}

	private void OnEnable()
	{
		if (!isOpen)
		{
			lighterAnimator.Play("lighter_case_top_close", 0);
		}
	}

	private void OnDestroy()
	{
		if (initCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.StopCoroutine(initCoro);
		}
		SetupListeners(on: false);
	}

	private void SetupListeners(bool on)
	{
		RespawnOnDrop component = GetComponent<RespawnOnDrop>();
		if (on)
		{
			if (component != null && component.respawnOnDropThroughFloor)
			{
				component.Respawned += OnItemRespawn;
			}
			scrolling.Scrolled += OnScrolled;
			item.Used += OnUse;
			return;
		}
		if (component != null)
		{
			component.Respawned -= OnItemRespawn;
		}
		if ((bool)scrolling)
		{
			scrolling.Scrolled -= OnScrolled;
		}
		item.Used -= OnUse;
		flame.FlameIgnited -= OnFlameIgnited;
		flame.FlameExtinguished -= OnFlameExtinguished;
		if (itemSaveData != null)
		{
			itemSaveData.ItemSaveDataLoaded -= OnItemSaveDataLoaded;
			itemSaveData.ItemSaveDataRequested -= OnItemSaveDataRequested;
		}
	}

	private void OnFlameIgnited()
	{
		igniter.enabled = true;
		activityHandler.ToggleRange(longRange: true);
	}

	private void OnFlameExtinguished()
	{
		igniter.enabled = false;
		activityHandler.ToggleRange(longRange: false);
	}

	private void OnScrolled(ScrollAction direction)
	{
		if (direction.IsPositive() == isOpen)
		{
			if (isOpen)
			{
				CloseLid();
			}
			else
			{
				OpenLid();
			}
		}
	}

	private void OnUse()
	{
		LightFire();
	}

	public bool LightFire(bool playSound = true, bool spark = true)
	{
		if (!isOpen || Ignited || flame.IsUnderWater())
		{
			return false;
		}
		if ((double)Random.value < 0.7)
		{
			flame.UpdateFlameIntensity(1f);
		}
		if (spark)
		{
			sparks.Play();
		}
		if (playSound)
		{
			flintSound.Play(base.transform.position, 1f, 1f, 0f, 0.1f, 500f, default(AudioSourceCurves), null, base.transform);
		}
		return true;
	}

	public void IgniteNow()
	{
		igniter.IgniteNow();
	}

	public void IgniteSpecificObject(IIgnitable ignitable)
	{
		igniter.IgniteSpecificObject(ignitable);
	}

	public void OpenLid(bool playSound = true)
	{
		lighterAnimator.StopPlayback();
		lighterAnimator.CrossFade("lighter_case_top_open", 0.25f);
		isOpen = true;
		if (playSound)
		{
			openSound.Play(base.transform.position, 1f, 1f, 0f, 0.1f, 500f, default(AudioSourceCurves), null, base.transform);
		}
	}

	public void CloseLid(bool forced = false)
	{
		lighterAnimator.StopPlayback();
		if (!forced)
		{
			lighterAnimator.CrossFade("lighter_case_top_close", 0.25f);
			closeSound.Play(base.transform.position, 1f, 1f, 0f, 0.1f, 500f, default(AudioSourceCurves), null, base.transform);
		}
		isOpen = false;
		flame.UpdateFlameIntensity(0f, forced);
	}

	public bool IsFireOn()
	{
		return flame.IsLit;
	}

	private void OnItemRespawn(RespawnOnDrop _, ItemBase __)
	{
		if (isOpen)
		{
			CloseLid(forced: true);
		}
	}

	public void ReactToControllerAcceleration()
	{
		if (isOpen)
		{
			CloseLid();
		}
		else
		{
			OpenLid();
		}
	}

	private void OnItemSaveDataLoaded(JObject data)
	{
		if (data == null)
		{
			return;
		}
		int? num = data.GetInt("Lighter_state");
		int valueOrDefault = num.GetValueOrDefault();
		if (!num.HasValue)
		{
			return;
		}
		int num2 = 1;
		int num3 = 2;
		bool flag = (valueOrDefault & num2) == num2;
		bool flag2 = (valueOrDefault & num3) == num3;
		if (flag)
		{
			if (lighterAnimator == null)
			{
				lighterAnimator = GetComponent<Animator>();
			}
			lighterAnimator.StopPlayback();
			lighterAnimator.CrossFade("lighter_case_top_open", 0f);
			isOpen = true;
			if (flag2)
			{
				flame.UpdateFlameIntensity(1f, forced: true);
			}
		}
		else if (flag2)
		{
			Debug.LogWarning("Lighter load state mismatch: should be lit but closed. Skipping lighting fire.", this);
		}
	}

	private JObject OnItemSaveDataRequested(JObject data)
	{
		int num = (isOpen ? 1 : 0) | (Ignited ? 2 : 0);
		if (num == 0)
		{
			data.Remove("Lighter_state");
		}
		else
		{
			data.SetInt("Lighter_state", num);
		}
		return data;
	}

	public bool Ignite(float ignitionStrength)
	{
		return LightFire(playSound: false, spark: false);
	}

	public Transform GetTransform()
	{
		return base.transform;
	}
}
