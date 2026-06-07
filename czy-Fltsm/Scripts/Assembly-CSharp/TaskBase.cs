using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

[Serializable]
public abstract class TaskBase : PolymorphicPropertyDrawerListItem
{
	public delegate bool ValidateTarget(ITarget target);

	protected ProjectAssignment _assignment;

	protected Project _project;

	protected Agent _agent;

	protected Inventory _agentInventory;

	protected bool _interruptMoveAgent;

	protected float _itemTransferDuration = 0.3f;

	private ITarget _moveToTarget;

	private static Dictionary<TaskType, Color> _typeColors = new Dictionary<TaskType, Color>
	{
		{
			TaskType.MoveAgent,
			new Color32(byte.MaxValue, 184, 95, byte.MaxValue)
		},
		{
			TaskType.TransferItems,
			new Color32(0, 170, 160, byte.MaxValue)
		},
		{
			TaskType.MoveItems,
			new Color32(128, 177, 128, byte.MaxValue)
		},
		{
			TaskType.CompleteComposition,
			new Color32(byte.MaxValue, 122, 90, byte.MaxValue)
		},
		{
			TaskType.AddToCommunity,
			new Color32(70, 32, 102, byte.MaxValue)
		},
		{
			TaskType.ConsumeItem,
			Color.red
		},
		{
			TaskType.SalvageMarker,
			new Color32(0, 170, byte.MaxValue, byte.MaxValue)
		},
		{
			TaskType.ReserveFillInventory,
			new Color32(41, 178, 169, byte.MaxValue)
		},
		{
			TaskType.MoorBoat,
			new Color32(161, 179, 209, byte.MaxValue)
		},
		{
			TaskType.ReserveBoat,
			new Color32(161, 179, 209, byte.MaxValue)
		},
		{
			TaskType.EmbarkBoat,
			new Color32(0, 179, 209, byte.MaxValue)
		},
		{
			TaskType.ProduceItem,
			new Color32(byte.MaxValue, 216, 0, byte.MaxValue)
		},
		{
			TaskType.Anchor,
			new Color32(byte.MaxValue, 0, 127, byte.MaxValue)
		},
		{
			TaskType.ToggleSails,
			new Color32(byte.MaxValue, byte.MaxValue, 127, byte.MaxValue)
		},
		{
			TaskType.Rejuvenate,
			new Color32(200, 200, 0, byte.MaxValue)
		},
		{
			TaskType.InvestigateLandmark,
			new Color32(100, 100, 0, byte.MaxValue)
		},
		{
			TaskType.Fishing,
			new Color32(0, 170, byte.MaxValue, byte.MaxValue)
		},
		{
			TaskType.HaulCommunityItems,
			new Color32(byte.MaxValue, 150, byte.MaxValue, byte.MaxValue)
		},
		{
			TaskType.ReserveRejuvenator,
			new Color32(179, byte.MaxValue, 102, byte.MaxValue)
		},
		{
			TaskType.Research,
			new Color32(50, byte.MaxValue, 50, byte.MaxValue)
		},
		{
			TaskType.LearnAtSchool,
			new Color32(75, byte.MaxValue, 50, byte.MaxValue)
		}
	};

	public abstract TaskType Type { get; }

	public virtual bool DoYieldReturn => true;

	public virtual void Initialize(ProjectAssignment assignment)
	{
		_assignment = assignment;
		_project = assignment.Project;
		_agent = assignment.Agent;
		_agentInventory = _agent.ReturnInventory();
		_moveToTarget = null;
	}

	public virtual void Stop()
	{
	}

	public abstract IEnumerator RunTaskCoroutine(Agent agent, Project project);

	protected IEnumerator MoveAgentCoroutine(ITarget target, bool allowIncompletePath = false)
	{
		yield return MoveAgentCoroutine(target, (ITarget t) => true, allowIncompletePath);
	}

	protected IEnumerator MoveAgentCoroutine(ITarget target, ValidateTarget validateTarget, bool allowIncompletePath = false)
	{
		yield return MoveAgentCoroutine(_assignment.Agent, _assignment.Project, target, validateTarget, allowIncompletePath);
	}

	protected IEnumerator MoveAgentCoroutine(Agent agent, Project project, ITarget target, ValidateTarget validateTarget, bool allowIncompletePath = false)
	{
		if (target == null)
		{
			Debugger.Error("No target given to move to!");
		}
		else
		{
			if (target == _moveToTarget)
			{
				yield break;
			}
			_moveToTarget = target;
			Navigator navigator = agent.ReturnNavigator();
			if (navigator.StartNavigation(target, allowIncompletePath))
			{
				while (navigator.State != NavigatorState.Idling && validateTarget(target))
				{
					yield return null;
				}
			}
			else
			{
				Debug.LogException(new Exception($"'{agent.Name}' was unable to start navigation to '{target}' while assigned to '{project.Properties}' project."));
			}
		}
	}

	protected IEnumerator RunHaulStateCoroutine(Agent agent, ItemToHaul.HaulState state, DrifterRigEventType animationEventType)
	{
		ItemToHaul itemToHaul;
		while (_assignment.TryReturnItemToHaul(state, out itemToHaul))
		{
			yield return MoveAgentCoroutine(itemToHaul.MoveToTarget);
			if (itemToHaul.HasValidProject())
			{
				new AgentActionEvent(GameEventType.AgentActionStartedWorking, agent, DrifterAttributes.AttributeType.Athletics).Dispatch();
				yield return itemToHaul.IncrementStateCoroutine(animationEventType);
				new AgentActionItemPropertiesEvent(GameEventType.AgentActionItemHauled, agent, itemToHaul.Item.Properties, DrifterAttributes.AttributeType.Athletics).Dispatch();
				new AgentActionEvent(GameEventType.AgentActionStoppedWorking, agent, DrifterAttributes.AttributeType.Athletics).Dispatch();
			}
		}
	}

	public virtual ProjectBlocker ReturnBlockers(Agent agent)
	{
		return ProjectBlocker.None;
	}

	public virtual ProjectBlocker ReturnBlockers(Project project)
	{
		return ProjectBlocker.None;
	}

	public virtual bool ReturnCanFinish(Project project)
	{
		return true;
	}

	public virtual bool TryReturnAgentPriority(out int priority, Project project, Agent agent, int weight)
	{
		priority = 0;
		return false;
	}

	protected ITarget ReturnTarget(Agent agent, Project project, MoveTarget moveTarget, Item item = null)
	{
		switch (moveTarget)
		{
		default:
			return null;
		case MoveTarget.ProjectTarget:
		{
			if ((bool)project.Target && project.Target.TryGetComponent<Boat>(out var component))
			{
				if (component.CurrentMooringPoint != null)
				{
					return component.CurrentMooringPoint.EmbarkTarget;
				}
				return component.GetComponent<Target>();
			}
			return project.NavigationTarget;
		}
		case MoveTarget.ItemLocation:
			if (item == null)
			{
				Debugger.Error($"Please define an item to search storage for: MoveTarget {moveTarget}.");
				return null;
			}
			if (item.Owner == null)
			{
				Debugger.Error($"Item has no owner: MoveTarget {moveTarget}.");
				return null;
			}
			return item.Owner.GetComponentInChildren<Target>();
		case MoveTarget.NearestStorage:
		{
			if (item == null)
			{
				Debugger.Error($"Please define an item to search storage for: MoveTarget {moveTarget}.");
				return null;
			}
			Storage storage = agent.ReturnClosestStorage(item);
			if (storage != null)
			{
				if (agent.Boat == storage.GetComponent<Target>())
				{
					Debugger.Log("Found boat as target for NearestStorage ReturnWayPointSet().", null, 3);
				}
				return storage.GetComponentInChildren<Target>();
			}
			Debugger.Warning("Found no available storage.");
			return null;
		}
		case MoveTarget.NearestConstruction:
		case MoveTarget.NearestCommunityConstruction:
		{
			Construction construction = agent.ReturnClosestConstruction(onlyFinished: true);
			if (construction == null)
			{
				Debug.LogError("No construction available to move to!");
				return null;
			}
			return construction.ReturnGoToTownTarget(agent);
		}
		case MoveTarget.ProjectTargetMooringPoint:
			return project.NavigationTarget.ReturnClosestMooringPoint(agent).MooringTarget;
		}
	}

	protected ITarget ReturnTarget(MoveTarget moveTarget, Item item = null)
	{
		return ReturnTarget(_assignment.Agent, _assignment.Project, moveTarget, item);
	}

	protected bool TryReturnTargetBuildableExtendable<T>(Project project, out T buildableExtendable) where T : IBuildableExtendable
	{
		buildableExtendable = default(T);
		if ((bool)project.TargetBuildable)
		{
			return project.TargetBuildable.TryReturnBuildableExtendable<T>(out buildableExtendable);
		}
		return false;
	}

	public Color ReturnTypeColor()
	{
		if (!_typeColors.TryGetValue(Type, out var value))
		{
			value = UnityEngine.Random.ColorHSV();
			_typeColors.Add(Type, value);
		}
		return value;
	}
}
