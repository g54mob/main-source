using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public class MooringPointPersistentData : BuildableExtendablePersistentData<MooringPoint>
{
	public PersistentReference<Boat>.Reference MooredBoat;

	[OptionalField(VersionAdded = 2)]
	public PersistentReference<Boat>.Reference LinkedBoat;

	public BoatType[] PreferredBoatTypes;

	public MooringPointPersistentData(MooringPoint mooringPoint)
		: base(mooringPoint)
	{
	}

	public override void PopulateReferences()
	{
		base.Instance.PopulateReferences(this);
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryReturnBuildableExtendable<MooringPoint>(out var buildableExtendable))
		{
			base.Instance = buildableExtendable;
			base.Instance.Restore(this);
		}
	}

	public override void RestoreReferences()
	{
		if (base.Instance != null)
		{
			RestoreLinkedBoat();
		}
	}

	public void RestoreMooredBoat()
	{
		if (!MooredBoat.IsNull() && base.Instance.MooredBoat == null && MooredBoat.TryReturnInstance(out var reference))
		{
			base.Instance.LinkBoat(reference);
			base.Instance.MoorBoat(reference, true);
		}
	}

	public void RestoreLinkedBoat()
	{
		if (!LinkedBoat.IsNull() && base.Instance.LinkedBoat == null && LinkedBoat.TryReturnInstance(out var reference))
		{
			base.Instance.LinkBoat(reference);
		}
	}

	public static void RestoreMooredBoats()
	{
		foreach (MooringPointPersistentData reference in PersistentReference<MooringPoint>._references)
		{
			reference?.RestoreMooredBoat();
		}
	}

	public static void LinkUnlinkedBoats()
	{
		List<Boat> list = Community.PlayerCommunity.ReturnAllBoats();
		for (int i = 0; i < list.Count; i++)
		{
			Boat boat = list[i];
			if ((bool)boat.TownMooringPoint)
			{
				continue;
			}
			foreach (MooringPointPersistentData reference in PersistentReference<MooringPoint>._references)
			{
				if (!reference.Instance.LinkedBoat)
				{
					reference.Instance.LinkBoat(boat);
					break;
				}
			}
		}
	}
}
