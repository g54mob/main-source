using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleShield : Module
{
	[SerializeField]
	private GameObject platePrefab;

	[NonSerialized]
	public ShieldPlate plate;

	[NonSerialized]
	public GameObject plateN;

	[NonSerialized]
	public GameObject plateS;

	private (bool, bool) previousActives;

	private List<Transform> previousCameraTargets;

	public float plateRicochetChance;

	public bool platesRicochet;

	public Sprite wideShield;

	[NonSerialized]
	[HideInInspector]
	public bool protectLowest;

	private float damageSoaked;

	public bool missilesReady;

	public int numberOfMissiles;

	public bool wavesReady;

	public float waveDamage;

	public float missileDamageNeeded;

	public float wavesDamageNeeded;

	public float missileDamageCounter;

	public float wavesDamageCounter;

	public event Action<GameObject, GameObject> TrackPlateDamageMitigated;

	private new void Awake()
	{
		base.Awake();
		GameObject gameObject = UnityEngine.Object.Instantiate(platePrefab, base.transform.parent);
		plate = gameObject.GetComponent<ShieldPlate>();
		damageSoaked = 0f;
	}

	private new void Start()
	{
		plate.moduleShield = this;
		plateN = plate.ShieldN;
		plateS = plate.ShieldS;
		plateN.GetComponent<Health>().isShield = true;
		plateS.GetComponent<Health>().isShield = true;
		base.OuterPartOutline = plate.GetComponent<Outline>();
		SetPlatesActive((true, true));
		plateN.GetComponent<Health>().OnDamageReduced += DamageMitigated;
		plateS.GetComponent<Health>().OnDamageReduced += DamageMitigated;
		plateN.GetComponent<Health>().OnDamageReduced += TrackSoakedDamage;
		plateS.GetComponent<Health>().OnDamageReduced += TrackSoakedDamage;
		previousCameraTargets = new List<Transform>();
		base.Start();
	}

	protected override void SetEmpSoundChannels()
	{
	}

	public override bool CanInteract()
	{
		if (protectLowest)
		{
			return false;
		}
		return base.CanInteract();
	}

	protected override void OnInteractStart(Interactor interactor)
	{
		if (!base.IsFullyBroken && !base.IsEMPattached)
		{
			base.OnInteractStart(interactor);
			plate.isPlateActive = true;
			ModuleStartAiming();
		}
	}

	protected override void OnInteractEnd(Interactor interactor)
	{
		base.OnInteractEnd(interactor);
		plate.isPlateActive = false;
		MonoBehaviour.print(plateS.GetComponent<Health>().ricochetChance);
		MonoBehaviour.print(plateN.GetComponent<Health>().ricochetChance);
		ModuleEndAiming();
	}

	private void SetRandomPlatesActive()
	{
		if (UnityEngine.Random.Range(0, 2) == 0)
		{
			previousActives = (true, false);
			SetPlatesActive((true, false));
		}
		else
		{
			previousActives = (false, true);
			SetPlatesActive((false, true));
		}
	}

	public void SetPlatesSize()
	{
		plateN.GetComponent<SpriteRenderer>().sprite = wideShield;
		plateS.GetComponent<SpriteRenderer>().sprite = wideShield;
		plateN.GetComponent<BoxCollider2D>().size = new Vector2(0.55f, 0.1f);
		plateS.GetComponent<BoxCollider2D>().size = new Vector2(0.55f, 0.1f);
		plate.GetComponent<BoxCollider2D>().size = new Vector2(0.26f, 0.41f);
	}

	public void SetPlatesActive((bool, bool) actives)
	{
		plateN.SetActive(actives.Item1);
		plateS.SetActive(actives.Item2);
	}

	protected override void StartAndPostUpgrade()
	{
		base.StartAndPostUpgrade();
		Vector3 plateScale = new Vector3(GetUpgradedStatValueByStatType(StatTypes.scale), 1f);
		StartCoroutine(SetPlatesCoroutine());
		IEnumerator SetPlatesCoroutine()
		{
			yield return new WaitUntil(() => (bool)plateN && (bool)plateS);
			plateN.transform.localScale = plateScale;
			plateS.transform.localScale = plateScale;
		}
	}

	public void SetPlateRicochet()
	{
		plateN.GetComponent<Health>().ricochetChance = plateRicochetChance;
		plateS.GetComponent<Health>().ricochetChance = plateRicochetChance;
	}

	protected override void Break(HealthChangeInfo info)
	{
		base.Break(info);
		previousActives = (plateN.activeInHierarchy, plateS.activeInHierarchy);
		SetPlatesActive((false, false));
		plate.Stop();
	}

	protected override void OnFix(HealthChangeInfo info)
	{
		base.OnFix(info);
		SetPlatesActive(previousActives);
	}

	public void TrackSoakedDamage(float damage)
	{
		damageSoaked += damage;
		wavesDamageCounter += damage;
		missileDamageCounter += damage;
		if (missilesReady && missileDamageCounter >= missileDamageNeeded)
		{
			ModuleMissile moduleByType = Train.Instance.GetModuleByType<ModuleMissile>();
			for (int i = 0; i < numberOfMissiles; i++)
			{
				moduleByType.SpawnMissile();
			}
			missileDamageCounter = 0f;
		}
		if (wavesReady && wavesDamageCounter >= wavesDamageNeeded)
		{
			ModuleDeflect moduleByType2 = Train.Instance.GetModuleByType<ModuleDeflect>();
			moduleByType2.SpawnWave(plateN.transform.position, plateN.transform.up, waveDamage);
			moduleByType2.SpawnWave(plateS.transform.position, plateS.transform.up, waveDamage);
			wavesDamageCounter = 0f;
		}
	}
}
