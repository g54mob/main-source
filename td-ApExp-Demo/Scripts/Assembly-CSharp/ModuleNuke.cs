using UnityEngine;

public class ModuleNuke : Module
{
	private bool isLoaded = true;

	private int nukeCount = 1;

	[SerializeField]
	private GameObject nukePrefab;

	[SerializeField]
	private new GameObject explosionPrefab;

	[SerializeField]
	private Transform nukeSpawnTf;

	public override bool CanBeActivated => true;

	public int NukeCount
	{
		get
		{
			return nukeCount;
		}
		set
		{
			nukeCount = value;
			TryReload();
		}
	}

	public float Heal { get; set; }

	protected new void Awake()
	{
		base.Awake();
	}

	protected override void SetEmpSoundChannels()
	{
	}

	public override bool CanInteract()
	{
		if (isLoaded)
		{
			return base.CanInteract();
		}
		return false;
	}

	protected override void OnInteractStart(Interactor interactor)
	{
		if (!base.IsFullyBroken && !base.IsEMPattached)
		{
			base.OnInteractStart(interactor);
			StartLaunch();
		}
	}

	protected override void OnInteractUpdate(Interactor interactor)
	{
		base.OnInteractUpdate(interactor);
	}

	protected override void OnInteractEnd(Interactor interactor)
	{
		base.OnInteractEnd(interactor);
	}

	public void AnimInstantiateNuke()
	{
		Nuke component = Object.Instantiate(nukePrefab, nukeSpawnTf.transform.position, Quaternion.identity).GetComponent<Nuke>();
		component.Damage = GetUpgradedStatValueByStatType(StatTypes.damage);
		component.Heal = Heal;
		component.Destroyed += TryReload;
	}

	public void StartLaunch()
	{
		if (NukeCount != 0)
		{
			NukeCount--;
			anim.Play("Launch");
			isLoaded = false;
		}
	}

	private void TryReload()
	{
		if (nukeCount > 0)
		{
			anim.Play("Loaded");
			isLoaded = true;
		}
	}
}
