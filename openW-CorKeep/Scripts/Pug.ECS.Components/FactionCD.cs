using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent]
public struct FactionCD : IComponentData, IQueryTypeParameter
{
	public struct FactionsCanAttackLookUp
	{
		public BlobArray<ulong> canAttackBitMask;
	}

	private static BooleanMatrix factionMatrix;

	[GhostField]
	public FactionID faction;

	[GhostField]
	public FactionID originalFaction;

	[GhostField]
	public ulong befriendedBitMask;

	[GhostField]
	public int pvpTeam;

	public BlobAssetReference<FactionsCanAttackLookUp> factionsLookUp;

	public bool IsFriendlyFire(FactionCD targetFaction, WorldInfoCD worldInfoCD)
	{
		return !CanAttack(targetFaction, worldInfoCD);
	}

	public bool CanAttack(FactionCD targetFaction, WorldInfoCD worldInfoCD)
	{
		if (!factionsLookUp.IsCreated)
		{
			return true;
		}
		if (faction == FactionID.Player && targetFaction.faction == FactionID.Player)
		{
			if (worldInfoCD.pvpEnabled && pvpTeam != targetFaction.pvpTeam && pvpTeam != -1)
			{
				return targetFaction.pvpTeam != -1;
			}
			return false;
		}
		if (HasBefriendedFaction(targetFaction))
		{
			return false;
		}
		return (factionsLookUp.Value.canAttackBitMask[(int)faction] & (ulong)(1L << (int)targetFaction.faction)) != 0;
	}

	public bool CanHeal(FactionCD targetFaction, WorldInfoCD worldInfoCD)
	{
		if (faction == targetFaction.faction)
		{
			return !CanAttack(targetFaction, worldInfoCD);
		}
		return false;
	}

	public readonly bool HasBefriendedFaction(FactionCD targetFaction)
	{
		if ((targetFaction.befriendedBitMask & (ulong)(1L << (int)faction)) == 0L)
		{
			return (befriendedBitMask & (ulong)(1L << (int)targetFaction.faction)) != 0;
		}
		return true;
	}

	public void SetBefriendedFaction(FactionID factionToBefriend, bool value)
	{
		if (value)
		{
			befriendedBitMask |= (ulong)(1L << (int)factionToBefriend);
		}
		else
		{
			befriendedBitMask &= (ulong)(~(1L << (int)factionToBefriend));
		}
	}

	public void ChangePvPTeam()
	{
		pvpTeam = (pvpTeam + 1) % 8;
	}

	public int ToCharmedConditionValue()
	{
		return ((int)faction << 3) | pvpTeam;
	}

	public static void GetCharmerFaction(int charmedConditionValue, out FactionID charmerFaction, out int charmerPvpTeam)
	{
		charmerFaction = (FactionID)(charmedConditionValue >> 3);
		int num = 7;
		charmerPvpTeam = charmedConditionValue & num;
	}
}
