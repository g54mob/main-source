using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class LandmarkRescueable : LandmarkInteractable
{
	[SerializeField]
	private ActorType _actorType;

	[SerializeField]
	[ConditionalEnumHide("_actorType", 0, true)]
	private Activity _activity;

	[FormerlySerializedAs("IsHuman")]
	[SerializeField]
	private bool _isHuman;

	[Header("Narrative")]
	[SerializeField]
	private ItemProperties _requiredItem;

	[SerializeField]
	private int _requiredItemCost;

	[SerializeField]
	[Tooltip("List of other rescueables that are rescued when this recueable is rescued through dialogue.")]
	private LandmarkRescueable[] _buddies;

	[SerializeField]
	private LandmarkRescueableUnlockable _unlockable;

	private Navigator _navigator;

	private NavMeshObstacle _obstacle;

	public ActorType ActorType => _actorType;

	public ActorDescriptor Descriptor { get; private set; }

	public ActorBehaviour Actor { get; private set; }

	public Agent Agent { get; private set; }

	public Bird Bird { get; private set; }

	public bool IsRescued { get; private set; }

	public ItemProperties RequiredItem => _requiredItem;

	public int RequiredItemCost => _requiredItemCost;

	public LandmarkRescueableUnlockable Unlockable => _unlockable;

	public override void Initialize(LandmarkBehaviour landmarkBehaviour)
	{
	}

	public void Restore(ActorBehaviour actor)
	{
		InitializeActor(actor);
	}

	public bool Spawn(ActorDescriptor descriptor)
	{
		if (descriptor == null && descriptor.ActorType != _actorType)
		{
			return false;
		}
		Descriptor = descriptor;
		if ((bool)descriptor.Actor)
		{
			Actor = descriptor.Actor;
			IsRescued = true;
		}
		else
		{
			InitializeActor(descriptor.Spawn(Community.ReturnRandomCommunity(), base.transform.position));
			IsRescued = false;
		}
		return true;
	}

	public ActorDescriptor Spawn()
	{
		Descriptor = ActorDescriptor.CreateInstance(_actorType);
		InitializeActor(Descriptor.Spawn(Community.ReturnRandomCommunity(), base.transform.position));
		return Descriptor;
	}

	private void InitializeActor(ActorBehaviour actor)
	{
		Actor = actor;
		Actor.transform.SetParent(base.transform);
		Actor.transform.localPosition = Vector3.zero;
		Actor.transform.localRotation = Quaternion.Euler(Vector3.zero);
		base.IsInteractable = true;
		if (Actor is Agent agent)
		{
			Agent = agent;
			Agent.Descriptor.SetIsRefugee(isRefugee: true);
			_navigator = Agent.ReturnNavigator();
			_navigator.UpdateTerrain(Navigator.TerrainType.Construction);
			_navigator.SetupNavigationModes();
			_navigator.enabled = false;
			_obstacle = Agent.gameObject.AddComponent<NavMeshObstacle>();
			_obstacle.shape = NavMeshObstacleShape.Capsule;
			_obstacle.carving = true;
			_obstacle.carveOnlyStationary = true;
			_obstacle.carvingMoveThreshold = 0.5f;
			Agent.UpdateActivity((_activity != Activity.None) ? _activity : Activity.Idling);
		}
	}

	public void PrepareForRescue()
	{
		if ((bool)_obstacle)
		{
			Object.Destroy(_obstacle);
		}
		if ((bool)Actor)
		{
			Actor.PrepareForRescue();
			Actor.transform.SetParent(null);
		}
	}

	public void Rescue()
	{
		if (IsRescued)
		{
			return;
		}
		PrepareForRescue();
		Actor?.Rescue();
		IsRescued = true;
		if (!_buddies.IsNullOrEmpty())
		{
			LandmarkRescueable[] buddies = _buddies;
			for (int i = 0; i < buddies.Length; i++)
			{
				buddies[i].Rescue();
			}
		}
	}

	public IEnumerator IsRescuedCoroutine(Project project, Boat rescueingBoat = null)
	{
		PrepareForRescue();
		yield return new WaitForSeconds(1f);
		Actor?.Rescue(project, rescueingBoat);
		IsRescued = true;
	}

	public bool HasValidRescueables()
	{
		if (Agent != null && Agent.IsAlive)
		{
			return true;
		}
		return Actor;
	}

	private bool WasRescued(ActorDescriptor actorDescriptor)
	{
		foreach (Day day in GameManager.TimeManager.Days)
		{
			if (day.Report.WasActorRescued(actorDescriptor))
			{
				return true;
			}
		}
		return false;
	}
}
