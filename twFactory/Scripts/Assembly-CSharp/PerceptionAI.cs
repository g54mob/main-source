using UnityEngine;

public class PerceptionAI : MonoBehaviour
{
	public enum ESense
	{
		Sight = 0,
		Hearing = 1,
		Proximity = 2
	}

	public delegate void OnEnterPerception(GameObject go, ESense sense);

	public delegate void OnExitPerception(GameObject go, ESense sense);

	public delegate void OnSensePropertyChanged(float value);

	[Header("Perception AI")]
	[SerializeField]
	private bool detectAllies;

	[SerializeField]
	private bool detectEnemies = true;

	[Header("Sight")]
	[SerializeField]
	private bool sightEnabled;

	[SerializeField]
	[Min(0f)]
	private float sightRadius = 5f;

	[SerializeField]
	[Min(0f)]
	private float sightAngle = 90f;

	[SerializeField]
	private float sightHeight = 1f;

	[SerializeField]
	private LayerMask sightBlockingLayers = 0;

	[Header("Hearing")]
	[SerializeField]
	private bool hearingEnabled;

	[SerializeField]
	private float hearingRadius = 2.5f;

	[Header("Proximity")]
	[SerializeField]
	private bool proximityEnabled;

	[SerializeField]
	private float proximityRadius = 2.5f;

	private Rigidbody rigidB;

	private PerceptionSense_Sight sightSense;

	private PerceptionSense_Hearing hearingSense;

	private PerceptionSense_Proximity proximitySense;

	private Controller controller;

	public bool DetectAllies
	{
		get
		{
			return detectAllies;
		}
		set
		{
			detectAllies = value;
		}
	}

	public bool DetectEnemies
	{
		get
		{
			return detectEnemies;
		}
		set
		{
			detectEnemies = value;
		}
	}

	public float SightRadius
	{
		get
		{
			return sightRadius;
		}
		set
		{
			sightRadius = value;
		}
	}

	public float SightAngle
	{
		get
		{
			return sightAngle;
		}
		set
		{
			sightAngle = value;
		}
	}

	public float SightHeight
	{
		get
		{
			return sightHeight;
		}
		set
		{
			sightHeight = value;
		}
	}

	public LayerMask SightBlockingLayers
	{
		get
		{
			return sightBlockingLayers;
		}
		set
		{
			sightBlockingLayers = value;
		}
	}

	public float HearingRadius
	{
		get
		{
			return hearingRadius;
		}
		set
		{
			hearingRadius = value;
		}
	}

	public float ProximityRadius
	{
		get
		{
			return proximityRadius;
		}
		set
		{
			proximityRadius = value;
			this.onProximityRadiusChanged?.Invoke(proximityRadius);
		}
	}

	public Controller Controller => controller;

	public event OnEnterPerception onEnterPerception;

	public event OnExitPerception onExitPerception;

	public event OnSensePropertyChanged onProximityRadiusChanged;

	private void Awake()
	{
		controller = GetComponent<Controller>();
		if (sightEnabled)
		{
			InitSight();
		}
		if (hearingEnabled)
		{
			InitHearing();
		}
		if (proximityEnabled)
		{
			InitProximity();
		}
	}

	private void InitSight()
	{
		if (!sightSense)
		{
			InitRigidbody();
			GameObject gameObject = new GameObject("Perception_Sight");
			gameObject.transform.SetParent(base.transform);
			gameObject.layer = base.gameObject.layer;
			sightSense = gameObject.AddComponent<PerceptionSense_Sight>();
			sightSense.InitSense(this);
			sightSense.onEnterSense += OnEnterSight;
			sightSense.onExitSense += OnExitSight;
		}
	}

	private void InitHearing()
	{
		if (!hearingSense)
		{
			InitRigidbody();
			GameObject gameObject = new GameObject("Perception_Hearing");
			gameObject.transform.SetParent(base.transform);
			gameObject.layer = base.gameObject.layer;
			hearingSense = gameObject.AddComponent<PerceptionSense_Hearing>();
			hearingSense.InitSense(this);
			hearingSense.onEnterSense += OnEnterHearing;
			hearingSense.onExitSense += OnExitHearing;
		}
	}

	private void InitProximity()
	{
		if (!proximitySense)
		{
			InitRigidbody();
			GameObject gameObject = new GameObject("Perception_Proximity");
			gameObject.transform.SetParent(base.transform);
			gameObject.layer = base.gameObject.layer;
			proximitySense = gameObject.AddComponent<PerceptionSense_Proximity>();
			proximitySense.InitSense(this);
			proximitySense.onEnterSense += OnEnterProximity;
			proximitySense.onExitSense += OnExitProximity;
		}
	}

	private void InitRigidbody()
	{
		if (!rigidB)
		{
			rigidB = base.gameObject.AddComponent<Rigidbody>();
			rigidB.isKinematic = true;
			rigidB.useGravity = false;
		}
	}

	private void OnEnterSight(GameObject go)
	{
		this.onEnterPerception?.Invoke(go, ESense.Sight);
	}

	private void OnExitSight(GameObject go)
	{
		this.onExitPerception?.Invoke(go, ESense.Sight);
	}

	private void OnEnterHearing(GameObject go)
	{
		this.onEnterPerception?.Invoke(go, ESense.Hearing);
	}

	private void OnExitHearing(GameObject go)
	{
		this.onExitPerception?.Invoke(go, ESense.Hearing);
	}

	private void OnEnterProximity(GameObject go)
	{
		this.onEnterPerception?.Invoke(go, ESense.Proximity);
	}

	private void OnExitProximity(GameObject go)
	{
		this.onExitPerception?.Invoke(go, ESense.Proximity);
	}
}
