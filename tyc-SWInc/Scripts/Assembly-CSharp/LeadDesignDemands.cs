using System;
using System.Linq;

public static class LeadDesignDemands
{
	[Flags]
	public enum Demand
	{
		Fire = 0,
		FixedRate = 1,
		NonBinding = 2,
		ExclusiveLead = 4,
		LuxuryMeal = 8,
		LuxuryCar = 0x10,
		PrivateOffice = 0x20,
		GoldenHandshake = 0x40,
		Royalties = 0x80,
		IPOwnership = 0x100
	}

	public class DemandChoice
	{
		public uint ID;

		public Demand Choice1;

		public Demand Choice2;

		public float Cost1;

		public float Cost2;

		public float Threshold;

		public Action<Employee> Enact1;

		public Action<Employee> Enact2;

		public DemandChoice(uint iD, Demand choice1, Demand choice2, float threshold)
		{
			ID = iD;
			Choice1 = choice1;
			Choice2 = choice2;
			Threshold = threshold;
		}

		public int GetChoiceIndex(Demand demand)
		{
			if (Choice1 != demand)
			{
				return 1;
			}
			return 0;
		}
	}

	public const float RoyaltyPercent = 0.05f;

	public const float LuxuryCarPrice = 300000f;

	public const float LuxuryMealPrice = 3000f;

	public const int GoldenYears = 5;

	public static DemandChoice[] Demands = new DemandChoice[5]
	{
		new DemandChoice(1u, Demand.FixedRate, Demand.Fire, 0.2f),
		new DemandChoice(2u, Demand.NonBinding, Demand.ExclusiveLead, 0.4f)
		{
			Enact2 = EnactExclusiveLead
		},
		new DemandChoice(4u, Demand.LuxuryMeal, Demand.LuxuryCar, 0.6f)
		{
			Cost2 = 300000f
		},
		new DemandChoice(8u, Demand.PrivateOffice, Demand.GoldenHandshake, 0.8f)
		{
			Enact1 = EnactPrivateOffice
		},
		new DemandChoice(16u, Demand.Royalties, Demand.IPOwnership, 0.9f)
	};

	public static uint AllDemands = Demands.Aggregate(0u, (uint x, DemandChoice y) => x | y.ID);

	public static DemandChoice GetChoice(uint id)
	{
		for (int i = 0; i < Demands.Length; i++)
		{
			if (Demands[i].ID == id)
			{
				return Demands[i];
			}
		}
		return null;
	}

	public static DemandChoice GetChoice(Demand demand)
	{
		for (int i = 0; i < Demands.Length; i++)
		{
			DemandChoice demandChoice = Demands[i];
			if (demandChoice.Choice1 == demand || demandChoice.Choice2 == demand)
			{
				return demandChoice;
			}
		}
		return null;
	}

	private static void EnactPrivateOffice(Employee emp)
	{
		if (emp.MyActor != null && emp.MyActor.isActiveAndEnabled && emp.MyActor.UsingPoint != null && emp.MyActor.UsingPoint.Parent.Type.Equals("Computer"))
		{
			Furniture parent = emp.MyActor.UsingPoint.Parent;
			if (parent.Reserved == emp.MyActor)
			{
				parent.Reserved = null;
			}
			parent.IsOn = false;
			emp.MyActor.UsingPoint = null;
			emp.MyActor.AIScript.currentNode = emp.MyActor.AIScript.BehaviorNodes["Loiter"];
		}
	}

	private static void EnactExclusiveLead(Employee emp)
	{
		if (emp.MyActor != null)
		{
			emp.MyActor.ChangeRole(Employee.EmployeeRole.Lead, false, false);
		}
		else
		{
			emp.SetRoles(emp.CurrentRoleBit & ~Employee.RoleBit.Lead, emp.SecondaryRole);
		}
	}
}
