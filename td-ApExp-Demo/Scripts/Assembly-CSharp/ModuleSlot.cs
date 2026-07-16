using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ModuleSlot : MonoBehaviour
{
	public delegate void NewModuleSetHandler(Module newModule);

	[SerializeField]
	private GameObject ps;

	private BoxCollider2D bc2d;

	private Animator damageAnim;

	[SerializeField]
	private ParticleSystem[] damagePSs;

	[SerializeField]
	private GameObject moduleEmpPs;

	[SerializeField]
	private ParticleSystem moduleBurnPs;

	[SerializeField]
	private ParticleSystem[] moduleSmoke1Ps;

	[SerializeField]
	private ParticleSystem[] moduleSmoke2Ps;

	[SerializeField]
	private ParticleSystem[] moduleSmoke3Ps;

	[SerializeField]
	private ParticleSystem[] moduleSmoke4Ps;

	[SerializeField]
	private ParticleSystem[] moduleSmokeExternalLeft3Ps;

	[SerializeField]
	private ParticleSystem[] moduleSmokeExternalRight3Ps;

	private SpriteRenderer damageSr;

	private SpriteRenderer sr;

	private AudioSource audioSource;

	[SerializeField]
	private AudioClip sparksSound;

	[SerializeField]
	private AudioClip fireSound;

	private DamageStates currentDamageState;

	[NonSerialized]
	public bool coalInfusionOn;

	[NonSerialized]
	public float coalFillPercent;

	private bool roofVisible;

	[field: SerializeField]
	public Wagon Wagon { get; private set; }

	[field: SerializeField]
	public Module Module { get; private set; }

	[field: SerializeField]
	public ModuleCombatTypes ModuleType { get; private set; }

	[field: SerializeField]
	public Transform NorthAnchor { get; set; }

	[field: SerializeField]
	public Transform SouthAnchor { get; set; }

	[field: SerializeField]
	public Transform BurnPs { get; set; }

	public event NewModuleSetHandler OnNewModuleSet;

	private void Awake()
	{
		Wagon = base.transform.parent.parent.GetComponent<Wagon>();
		bc2d = GetComponent<BoxCollider2D>();
		sr = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
		Transform transform = base.transform.Find("Damage Sprite");
		damageAnim = transform.GetComponent<Animator>();
		damageSr = transform.GetComponent<SpriteRenderer>();
		Train instance = Train.Instance;
		instance.OnShowRoof = (Action<bool>)Delegate.Combine(instance.OnShowRoof, new Action<bool>(HideParticlesOnTop));
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
		Train instance = Train.Instance;
		instance.OnShowRoof = (Action<bool>)Delegate.Remove(instance.OnShowRoof, new Action<bool>(HideParticlesOnTop));
	}

	private void HealthComponent_OnBurnEvent(bool burning)
	{
		if (burning)
		{
			moduleBurnPs.Play();
		}
		else
		{
			moduleBurnPs.Stop();
		}
	}

	private void Update()
	{
		float num = Mathf.Max(Train.Instance?.TrainSpeedNormalized ?? 0f, 0.75f);
		if (currentDamageState != DamageStates.Broken)
		{
			return;
		}
		for (int i = 0; i < damagePSs.Length; i++)
		{
			ParticleSystem particleSystem = damagePSs[i];
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = particleSystem.velocityOverLifetime;
			velocityOverLifetime.speedModifier = num;
			if (i < 5)
			{
				particleSystem.transform.localScale = new Vector3(num, num, 1f);
			}
			else
			{
				particleSystem.transform.localScale = new Vector3(num, 0f - num, 1f);
			}
		}
	}

	public void SetModuleType(ModuleCombatTypes mt)
	{
		ModuleType = mt;
	}

	public void SetModule(EnhancementModule module)
	{
		GameObject modulePrefab = module.ModulePrefab;
		Module module2 = (Module = UnityEngine.Object.Instantiate(modulePrefab, base.transform.position + modulePrefab.transform.localPosition, modulePrefab.transform.rotation, base.transform).transform.GetComponent<Module>());
		this.OnNewModuleSet?.Invoke(Module);
		Train.Instance.HealthComponent.RaiseMaxHealthByWithHeal(Train.Instance.healthIncreasePerModule);
		if (coalInfusionOn && module2.CanBeActivated)
		{
			module2.GetComponent<Interactable>().OnInteractStart += CoalInfusion;
		}
		Train.Instance.RefreshModules();
	}

	public void TransferModule(ModuleSlot newSlot)
	{
		Module.transform.parent = newSlot.transform;
		Module.transform.position = newSlot.transform.position;
		Module.ModuleSlot = newSlot;
		newSlot.Module = Module;
		Module = null;
		Train.Instance.RefreshModules();
	}

	public void SwapModules(ModuleSlot newSlot)
	{
		Module.transform.parent = newSlot.transform;
		newSlot.Module.transform.parent = base.transform;
		Module.transform.position = newSlot.transform.position;
		newSlot.Module.transform.position = base.transform.position;
		Module.ModuleSlot = newSlot;
		newSlot.Module.ModuleSlot = this;
		Module module = Module;
		Module = newSlot.Module;
		newSlot.Module = module;
		Train.Instance.RefreshModules();
	}

	public void RemoveModule()
	{
		if (coalInfusionOn && Module.CanBeActivated)
		{
			Module.GetComponent<Interactable>().OnInteractStart -= CoalInfusion;
		}
		Module.OnRemoveModule();
		UnityEngine.Object.Destroy(Module.gameObject);
		Module = null;
		Train.Instance.HealthComponent.ChangeMaxHealthBy(0f - Train.Instance.healthIncreasePerModule);
		Train.Instance.RefreshModules();
	}

	public void SetDamageState(DamageStates damageState)
	{
		if (damageState == currentDamageState)
		{
			return;
		}
		currentDamageState = damageState;
		if (damageState != DamageStates.Broken)
		{
			ParticleSystem[] array = damagePSs;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Stop();
			}
		}
		switch (damageState)
		{
		case DamageStates.None:
			StopAllSmokeParticles();
			audioSource.Stop();
			break;
		case DamageStates.Smoke1:
		{
			StopAllSmokeParticles();
			ParticleSystem[] array = moduleSmoke1Ps;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Play();
			}
			audioSource.clip = sparksSound;
			audioSource.loop = false;
			audioSource.Play();
			break;
		}
		case DamageStates.Smoke2:
		{
			StopAllSmokeParticles();
			ParticleSystem[] array = moduleSmoke2Ps;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Play();
			}
			audioSource.clip = sparksSound;
			audioSource.loop = false;
			audioSource.Play();
			break;
		}
		case DamageStates.Smoke3:
		{
			StopAllSmokeParticles();
			ParticleSystem[] array = moduleSmoke3Ps;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Play();
			}
			array = moduleSmokeExternalLeft3Ps;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Play();
			}
			array = moduleSmokeExternalRight3Ps;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Play();
			}
			break;
		}
		case DamageStates.Broken:
		{
			StopAllSmokeParticles();
			ParticleSystem[] array = damagePSs;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Play();
			}
			array = moduleSmoke3Ps;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Play();
			}
			audioSource.clip = fireSound;
			audioSource.loop = true;
			audioSource.Play();
			break;
		}
		}
	}

	public Vector3 ClosestPoint(Vector3 position)
	{
		return bc2d.ClosestPoint(position);
	}

	public void CoalInfusion(Interactor interactor)
	{
		Train.Instance.CoalSeconds += Train.Instance.CoalSecondsCapacity * coalFillPercent / 100f;
	}

	private void StopAllSmokeParticles()
	{
		ParticleSystem[] array = moduleSmoke1Ps;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
		array = moduleSmoke2Ps;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
		array = moduleSmoke3Ps;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
		array = moduleSmoke4Ps;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
		array = moduleSmokeExternalLeft3Ps;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
		array = moduleSmokeExternalRight3Ps;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
	}

	private void HideParticlesOnTop(bool visible)
	{
		if (visible)
		{
			ps.transform.localPosition = new Vector3(-5000f, -5000f, 0f);
		}
		else
		{
			ps.transform.localPosition = Vector3.zero;
		}
	}

	public Transform GetAnchorPoint(bool north)
	{
		if (!north)
		{
			return SouthAnchor;
		}
		return NorthAnchor;
	}

	public void SetEmpPs(bool isOn)
	{
		moduleEmpPs.SetActive(isOn);
	}
}
