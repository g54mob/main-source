using System.Collections.Generic;
using KitchenData.Workshop;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "WorkshopRecipe", menuName = "Kitchen/Workshop/Recipe")]
	public class WorkshopRecipe : GameDataObject
	{
		public List<IWorkshopIndividualCondition> Conditions = new List<IWorkshopIndividualCondition>();

		public List<IWorkshopGroupCondition> GroupConditions = new List<IWorkshopGroupCondition>();

		public IWorkshopProduct Output;

		public bool IsSatisfied(List<Appliance> inputs, out Appliance output)
		{
			output = null;
			if (inputs.Count != Conditions.Count)
			{
				return false;
			}
			if (!IsSatisfied(inputs, Conditions, 0, 0))
			{
				return false;
			}
			if (!GroupConditions.TrueForAll((IWorkshopGroupCondition c) => c.Matches(inputs)))
			{
				return false;
			}
			return Output.GetResult(inputs, out output);
		}

		private bool IsSatisfied(List<Appliance> inputs, List<IWorkshopIndividualCondition> conditions, int condition_mask, int input_mask)
		{
			for (int i = 0; i < conditions.Count; i++)
			{
				if (condition_mask.GetBit(i))
				{
					continue;
				}
				for (int j = 0; j < inputs.Count; j++)
				{
					if (!input_mask.GetBit(j) && conditions[i].Matches(inputs[j]))
					{
						if (input_mask.CountBits() + 1 >= inputs.Count)
						{
							return true;
						}
						int condition_mask2 = condition_mask.SetBit(i);
						int input_mask2 = input_mask.SetBit(j);
						if (IsSatisfied(inputs, conditions, condition_mask2, input_mask2))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		protected override void InitialiseDefaults()
		{
		}
	}
}
