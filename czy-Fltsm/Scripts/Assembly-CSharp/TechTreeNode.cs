using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using I2.Loc;
using UnityEngine;

public class TechTreeNode : ScriptableObject
{
	[Serializable]
	public class SerializableRequirements
	{
		public List<TechTreeRequirement> Requirements;

		public void Add(TechTreeRequirement requirement)
		{
			Requirements.Add(requirement);
		}

		public bool Remove(TechTreeRequirement requirment)
		{
			return Requirements.Remove(requirment);
		}
	}

	private static readonly Regex UNKNOW_NAME_REGEX = new Regex("\\S");

	public string Guid;

	public Vector2 Position;

	[SerializeField]
	private List<TechTreeNode> _dependencies = new List<TechTreeNode>();

	[SerializeField]
	private LocalizedString _name;

	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private bool _firstSelected;

	[SerializeField]
	[TechTreeRequirements]
	private SerializableRequirements _requirements;

	[SerializeField]
	private List<ResearchUnlockable> _unlockables;

	public List<TechTreeNode> Dependencies => _dependencies;

	public List<TechTreeRequirement> Requirements => _requirements.Requirements;

	public string Name => _name;

	public Sprite Icon => _icon;

	public int Cost => GetRequirementAmount<KnowledgeRequirement>();

	public IReadOnlyList<ResearchUnlockable> Unlockables => _unlockables;

	public bool FirstSelected => _firstSelected;

	public void Unlock()
	{
		foreach (ResearchUnlockable unlockable in _unlockables)
		{
			unlockable.Unlock();
		}
	}

	public void AddDependency(TechTreeNode node)
	{
		_dependencies.AddUnique(node);
	}

	public void RemoveDependency(TechTreeNode node)
	{
		_dependencies.Remove(node);
	}

	public void LinkRequirementProvider(TechTreeRequirementProvider requirementProvider)
	{
		foreach (TechTreeRequirement requirement in _requirements.Requirements)
		{
			if (requirementProvider.IsProviderFor(requirement))
			{
				requirement.SetProvider(requirementProvider);
			}
		}
	}

	public bool IsResearchable()
	{
		if (IsUnlocked())
		{
			return false;
		}
		foreach (TechTreeNode dependency in _dependencies)
		{
			if (!dependency.IsUnlocked())
			{
				return false;
			}
		}
		foreach (TechTreeRequirement requirement in _requirements.Requirements)
		{
			if (!requirement.IsMet())
			{
				return false;
			}
		}
		return true;
	}

	public bool IsUnlocked()
	{
		foreach (ResearchUnlockable unlockable in _unlockables)
		{
			if (!unlockable.IsUnlocked())
			{
				return false;
			}
		}
		return true;
	}

	public bool IsUnknown()
	{
		foreach (TechTreeRequirement requirement in _requirements.Requirements)
		{
			if (requirement.Flags.HasFlag(TechTreeRequirementFlags.Unknown) && !requirement.IsMet())
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsRequirement(TechTreeRequirement requirement)
	{
		return _requirements.Requirements.Contains(requirement);
	}

	public bool ContainsRequirement<T>(out T requirement) where T : TechTreeRequirement
	{
		foreach (TechTreeRequirement requirement2 in _requirements.Requirements)
		{
			if (requirement2 is T val)
			{
				requirement = val;
				return true;
			}
		}
		requirement = null;
		return false;
	}

	public int GetRequirementAmount<T>() where T : TechTreeRequirement
	{
		foreach (TechTreeRequirement requirement in _requirements.Requirements)
		{
			if (requirement is T && requirement.TryGetAmount(out var amount))
			{
				return amount;
			}
		}
		return 0;
	}

	public string GetNameUnknownified(string replacement = "?")
	{
		if (!IsUnknown())
		{
			return _name;
		}
		return UNKNOW_NAME_REGEX.Replace(_name, replacement);
	}
}
