using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Construction))]
public class School : MonoBehaviour, IBuildableExtendable, IPersistentReference
{
	[Serializable]
	public class PersistentData : BuildableExtendablePersistentData<School>
	{
		public float CurrentTimer;

		public PersistentReference<Project>.Reference Project;

		public PersistentReference<Agent>.Reference CurrentDrifter;

		public PersistentReference<Item>.Reference CurrentItem;

		public PersistentData(School school)
			: base(school)
		{
		}

		public override void RestoreData(Buildable buildable)
		{
			if (buildable.TryGetComponent<School>(out var component))
			{
				base.Instance = component;
				base.Instance.Restore(this);
			}
		}

		public override void RestoreReferences()
		{
			if (base.Instance != null)
			{
				base.Instance.RestoreReferences(this);
			}
		}

		public override void PopulateReferences()
		{
			base.Instance.PopulateReferences(this);
		}
	}

	[SerializeField]
	private ProjectProperties _projectProperties;

	[SerializeField]
	private AttachableSlots _slots;

	[SerializeField]
	private Storage _storage;

	private Construction _construction;

	private Agent[] _students;

	public UnityEvent OnCurrentDrifterUpdatedEvent { get; private set; } = new UnityEvent();

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public Project Project { get; private set; }

	public int SlotCount => _slots.Count;

	public CommunityResearch CommunityResearch { get; private set; }

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Buildable.TryReturnBuildableExtendable<Construction>(out _construction);
		CommunityResearch = buildable.Community.Research;
		_students = new Agent[_slots.Count];
	}

	public void Finish(bool restored = false)
	{
		if (!restored)
		{
			InstantiateProject();
		}
	}

	public void Remove()
	{
		StopProject(ProjectFlags.BuildableRemoved);
	}

	public bool StartStudying(Agent agent)
	{
		if (_slots.Attach(agent.transform, out var i))
		{
			_students[i] = agent;
			agent.UpdateActivity(Activity.Learning);
			if ((bool)Buildable.BuildableAnimator.Animator)
			{
				Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 1);
			}
			OnCurrentDrifterUpdatedEvent.Invoke();
			return true;
		}
		return false;
	}

	public void StopStudying(Agent agent)
	{
		agent.UpdateActivity(Activity.Idling);
		_slots.Detach(agent.transform, GameManager.AgentManager.AgentParent);
		RemoveStudent(agent);
		if (_slots.IsEmpty() && (bool)Buildable.BuildableAnimator.Animator)
		{
			Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 0);
		}
		if (!agent.ReturnNavigator().AttachToTarget(_construction.Target))
		{
			agent.ReturnNavigator().AttachToTarget(agent.ReturnClosestWalkwayConstruction().Target);
		}
		OnCurrentDrifterUpdatedEvent.Invoke();
	}

	public bool Study(Agent agent)
	{
		float deltaTime = Time.deltaTime;
		if (deltaTime <= 0f)
		{
			return true;
		}
		return agent.Study(CommunityResearch.AllocateStudyTime(deltaTime, _storage), CommunityResearch.GetStudyExperiencePerSecond());
	}

	private void InstantiateProject()
	{
		Project = new Project(_projectProperties, base.gameObject);
		Project.AssignmentLimit = _slots.TransformData.Length;
		Buildable.Community.QueueProject(Project);
	}

	private void StopProject(ProjectFlags flags)
	{
		if (Project != null)
		{
			Project.Stop(flags);
			Project = null;
		}
	}

	private void RemoveStudent(Agent agent)
	{
		for (int i = 0; i < _students.Length; i++)
		{
			if (_students[i] == agent)
			{
				_students[i] = null;
				break;
			}
		}
	}

	public bool CanLearn()
	{
		return CommunityResearch.HasStudyTime();
	}

	public Agent GetStudent(int slotIndex)
	{
		return _students[slotIndex];
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public bool CanBeSalvaged()
	{
		return true;
	}

	public void Shutdown()
	{
		Deactivate();
		StopProject(ProjectFlags.Cancelled);
	}

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new PersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		PersistentData persistentData2 = persistentData as PersistentData;
		if (persistentData2.Project != null && persistentData2.Project.TryReturn(out var instance))
		{
			Project = instance;
			Project.AssignmentLimit = _slots.TransformData.Length;
		}
		int count = Buildable.Community.Projects.Count;
		while (0 < count--)
		{
			Project project = Buildable.Community.Projects[count];
			if (project.Properties == _projectProperties && project.Target == base.gameObject && project != Project)
			{
				project.Stop(ProjectFlags.Exception);
				Debug.LogException(new Exception("Duplicate Learn At School project was stopped"));
			}
		}
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		PersistentData persistentData2 = persistentData as PersistentData;
		if (Project != null)
		{
			persistentData2.Project = Project;
		}
	}

	public void OnDeconstruct()
	{
	}

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public void Upgrade(Buildable buildable)
	{
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	public float ReturnWeight()
	{
		return 0f;
	}
}
