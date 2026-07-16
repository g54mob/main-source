using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Get Resource/Create New")]
public class MilestoneGetResource : Milestone
{
	[field: SerializeField]
	public Res Resource { get; private set; }

	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.GetResource;
		switch (Resource)
		{
		case Res.Scrap:
			ResourceManager.Instance.Scrap.OnValueAdded += AddProgress;
			break;
		case Res.Ammo:
			ResourceManager.Instance.Ammo.OnValueAdded += AddProgress;
			break;
		case Res.Cores:
			ResourceManager.Instance.Cores.OnValueAdded += AddProgress;
			break;
		case Res.Any:
			ResourceManager.Instance.Scrap.OnValueAdded += AddProgress;
			ResourceManager.Instance.Ammo.OnValueAdded += AddProgress;
			ResourceManager.Instance.Cores.OnValueAdded += AddProgress;
			break;
		default:
			Debug.LogError("Resource not selected.");
			break;
		}
	}

	public void AddProgress(float progress)
	{
		base.Progress += progress;
		UpdateProgress();
		if (base.Progress >= Goal)
		{
			Complete();
		}
	}

	public override void Complete()
	{
		base.Complete();
		switch (Resource)
		{
		case Res.Scrap:
			ResourceManager.Instance.Scrap.OnValueAdded -= AddProgress;
			break;
		case Res.Ammo:
			ResourceManager.Instance.Ammo.OnValueAdded -= AddProgress;
			break;
		case Res.Cores:
			ResourceManager.Instance.Cores.OnValueAdded -= AddProgress;
			break;
		case Res.Any:
			ResourceManager.Instance.Scrap.OnValueAdded -= AddProgress;
			ResourceManager.Instance.Ammo.OnValueAdded -= AddProgress;
			ResourceManager.Instance.Cores.OnValueAdded -= AddProgress;
			break;
		default:
			Debug.LogError("Resource missing.");
			break;
		}
	}
}
