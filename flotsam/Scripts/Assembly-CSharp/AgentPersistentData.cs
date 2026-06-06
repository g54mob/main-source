using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PajamaLlama.Debugs;
using PajamaLlama.Flotsam.Morale;
using UnityEngine;

[Serializable]
public class AgentPersistentData : PersistentReference<Agent>
{
	public enum ParentType
	{
		None = 0,
		Construction = 1,
		Boat = 2,
		Landmark = 3
	}

	public VitalsPersistentData Vitals;

	public Vector3 Position;

	public ParentType Parent;

	public int ParentIndex;

	public InventoryPersistentData Inventory;

	public List<Assignment> Assignments;

	public bool IsCaptain;

	public bool SalvageLocked;

	public DrifterRigPersistentData DrifterRig;

	[OptionalField(VersionAdded = 3)]
	public PersistentReference<Quest>.Reference QuestToStart;

	[OptionalField(VersionAdded = 2)]
	public DrifterAttributes.PersistentData DrifterAttributes;

	[OptionalField(VersionAdded = 2)]
	public Morale.PersistentData Morale;

	[OptionalField(VersionAdded = 3)]
	public ushort AgentDescriptorID;

	public bool NoSwimming;

	public int[] StatusEffects;

	public string Name;

	public int VoicePackIndex = -1;

	public float VoicePitch = -1f;

	public Agent.EGender Gender;

	public int LookProperties = -1;

	public int PastBackground = -1;

	public int PresentBackground = -1;

	public AgentPersistentData(Agent agent)
		: base(agent)
	{
		Vitals = new VitalsPersistentData(agent.Vitals);
		Position = agent.transform.position;
		switch (agent.ReturnNavigator().Terrain)
		{
		case Navigator.TerrainType.Construction:
			Parent = ParentType.Construction;
			break;
		case Navigator.TerrainType.UnityNavMesh:
			Parent = ParentType.Landmark;
			break;
		default:
			if ((bool)agent.Boat)
			{
				Parent = ParentType.Boat;
				ParentIndex = agent.Boat.PersistentIndex;
				IsCaptain = agent.Boat.Captain == agent;
			}
			break;
		}
		Inventory = new InventoryPersistentData(agent.Inventory);
		Assignments = agent.Assignments;
		SalvageLocked = agent.SalvageLock;
		DrifterRig = new DrifterRigPersistentData(agent);
		DrifterAttributes = new DrifterAttributes.PersistentData(agent.Attributes);
		Morale = new Morale.PersistentData(agent.Morale);
		AgentDescriptorID = agent.Descriptor.UniqueID;
	}

	public void Restore(Community community)
	{
		Restore();
		if (community == null)
		{
			community = Community.ReturnRandomCommunity();
		}
		if (!ActorDescriptor.TryGet<AgentDescriptor>(out var actorDescriptor, AgentDescriptorID))
		{
			actorDescriptor = AgentDescriptor.Restore(this);
		}
		base.Instance = actorDescriptor.Restore(community, this);
		Vitals.Restore(base.Instance.Vitals);
		if (Inventory != null)
		{
			Inventory.Restore(base.Instance.Inventory, base.Instance.gameObject);
		}
		bool flag = false;
		foreach (Assignment assignment in Assignments)
		{
			if (assignment.Priority != AssignmentPriority.None)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			foreach (Assignment assignment2 in Assignments)
			{
				base.Instance.SetAssignmentEnabled(assignment2.Type, assignment2.Enabled, assignment2.Priority);
			}
		}
		base.Instance.SalvageLock = SalvageLocked;
		base.Instance.DrifterRig.SetAttributeVariation(base.Instance.Descriptor.AttributesVariation);
		if (DrifterAttributes != null)
		{
			DrifterAttributes.Restore(base.Instance.Attributes);
		}
		if (Morale != null)
		{
			Morale.Restore(base.Instance.Morale);
		}
	}

	public void RestoreReferences()
	{
		if (!(base.Instance == null))
		{
			RestoreNavigatorState();
		}
	}

	public void RestoreNavigatorState()
	{
		switch (Parent)
		{
		case ParentType.Construction:
			if (base.Instance.Community.IsPlayerCommunity())
			{
				base.Instance.ReturnNavigator().AttachToTarget(FlotsamGame.ReturnClosest(base.Instance.transform.position, Community.PlayerCommunity.Constructions).Target);
			}
			break;
		case ParentType.Boat:
		{
			if (PersistentReference<Boat>.TryReturnReference(ParentIndex, out var reference))
			{
				if (IsCaptain)
				{
					base.Instance.StartCoroutine(EmbarkCoroutine(base.Instance, reference));
				}
				else
				{
					base.Instance.StartCoroutine(BoardCoroutine(base.Instance, reference));
				}
			}
			else
			{
				Debugger.Warning("Unable to set boat as agent parent, invalid persistent index!", base.Instance);
			}
			break;
		}
		case ParentType.Landmark:
			base.Instance.transform.position = Position;
			base.Instance.ReturnNavigator().UpdateTerrain(Navigator.TerrainType.UnityNavMesh);
			break;
		}
	}

	private IEnumerator EmbarkCoroutine(Agent agent, Boat boat)
	{
		yield return new WaitForEndOfFrame();
		agent.UpdateActivity(Activity.Moving);
		boat.BoardCaptain(agent);
	}

	private IEnumerator BoardCoroutine(Agent agent, Boat boat)
	{
		yield return new WaitForEndOfFrame();
		yield return null;
		boat.ReservePassage(agent);
		boat.BoardPassenger(agent);
	}
}
