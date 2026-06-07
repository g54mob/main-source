using System;
using UnityEngine;

[Serializable]
public class ProjectTargetPersistentData
{
	public enum TargetType
	{
		None = 0,
		Null = 1,
		Flotsam = 2,
		Construction = 3,
		Boat = 4,
		Agent = 5,
		Marker = 6,
		Landmark = 7,
		Decoration = 8
	}

	public TargetType Type;

	public int CommunityPersistentIndex;

	public int PersistentIndex;

	public ProjectTargetPersistentData(GameObject target, bool allowTargetTypeNull)
	{
		PersistentIndex = ReturnTargetPersistentIndex(target, allowTargetTypeNull, out Type, out CommunityPersistentIndex);
	}

	public bool TryRestore(out GameObject target, bool allowTargetTypeNull)
	{
		target = null;
		switch (Type)
		{
		case TargetType.Null:
			if (!allowTargetTypeNull)
			{
				Debug.LogException(new NotImplementedException("A null reference was persisted as project target!"));
			}
			return allowTargetTypeNull;
		case TargetType.Flotsam:
		{
			if (PersistentReference<Flotsam>.TryReturnReference(PersistentIndex, out var reference7))
			{
				target = reference7.gameObject;
				return true;
			}
			Debug.LogException(new NotImplementedException($"Unable to restore {Type} as project target!"));
			return false;
		}
		default:
		{
			if (Type != TargetType.Landmark && !Community.Communities.TryGetValueAtIndex(CommunityPersistentIndex, out var _))
			{
				Debug.LogException(new NotImplementedException("Unable to restore project target, community could not be found!"));
				return false;
			}
			target = Type switch
			{
				TargetType.Boat => PersistentReference<Boat>.TryReturnReference(PersistentIndex, out var reference) ? reference.gameObject : null, 
				TargetType.Construction => PersistentReference<Construction>.TryReturnReference(PersistentIndex, out var reference2) ? reference2.gameObject : null, 
				TargetType.Agent => PersistentReference<Agent>.TryReturnReference(PersistentIndex, out var reference3) ? reference3.gameObject : null, 
				TargetType.Marker => PersistentReference<Marker>.TryReturnReference(PersistentIndex, out var reference4) ? reference4.gameObject : null, 
				TargetType.Landmark => PersistentReference<Landmark>.TryReturnReference(PersistentIndex, out var reference5) ? reference5.gameObject : null, 
				TargetType.Decoration => PersistentReference<Decoration>.TryReturnReference(PersistentIndex, out var reference6) ? reference6.gameObject : null, 
				_ => null, 
			};
			if (target == null)
			{
				Debug.LogException(new NotImplementedException($"Unable to restore {Type} as project target!"));
				return false;
			}
			return true;
		}
		}
	}

	public int ReturnTargetPersistentIndex(GameObject target, bool allowTargetTypeNull, out TargetType type, out int communityPersistentIndex)
	{
		type = TargetType.None;
		communityPersistentIndex = -1;
		int num = -1;
		Flotsam component;
		Boat component2;
		Construction component3;
		Agent component4;
		Marker component5;
		Landmark component6;
		Decoration component7;
		if (target == null)
		{
			type = TargetType.Null;
		}
		else if (target.TryGetComponent<Flotsam>(out component))
		{
			type = TargetType.Flotsam;
			num = component.PersistentIndex;
		}
		else if (target.TryGetComponent<Boat>(out component2))
		{
			type = TargetType.Boat;
			communityPersistentIndex = Community.ReturnCommunityIndex(component2.Buildable.Community);
			num = component2.PersistentIndex;
		}
		else if (target.TryGetComponent<Construction>(out component3))
		{
			type = TargetType.Construction;
			communityPersistentIndex = Community.ReturnCommunityIndex(component3.Buildable.Community);
			num = component3.PersistentIndex;
		}
		else if (target.TryGetComponent<Agent>(out component4))
		{
			type = TargetType.Agent;
			communityPersistentIndex = Community.ReturnCommunityIndex(component4.Community);
			num = component4.PersistentIndex;
		}
		else if (target.TryGetComponent<Marker>(out component5))
		{
			type = TargetType.Marker;
			communityPersistentIndex = Community.ReturnCommunityIndex(component5.Community);
			num = component5.PersistentIndex;
		}
		else if (target.TryGetComponent<Landmark>(out component6))
		{
			type = TargetType.Landmark;
			communityPersistentIndex = -1;
			num = component6.PersistentIndex;
		}
		else if (target.TryGetComponent<Decoration>(out component7))
		{
			type = TargetType.Decoration;
			communityPersistentIndex = Community.ReturnCommunityIndex(component7.Community);
			num = component7.PersistentIndex;
		}
		if (num == -1 && !allowTargetTypeNull)
		{
			Debug.LogException(new NotImplementedException($"Target \"{target}\" does not have a valid target component; persistence will not work as intended!"));
		}
		return num;
	}
}
