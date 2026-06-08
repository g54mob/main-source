using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Customer Type", menuName = "Kitchen/Customer Type")]
	public class CustomerType : GameDataObject
	{
		public bool IsGenericGroup;

		public bool RelativeGroupSize;

		public int MinGroupSize;

		public int MaxGroupSize;

		public PatienceValues PatienceModifiers;

		public OrderingValues OrderingModifiers;

		public List<PlayerCosmetic> Cosmetics = new List<PlayerCosmetic>();

		public List<ICustomerProperty> Properties = new List<ICustomerProperty>();

		protected override void InitialiseDefaults()
		{
			PatienceModifiers = PatienceValues.Ones;
			OrderingModifiers = OrderingValues.Ones;
		}

		public (int, int) GetGroupSizeBounds(ScheduleParameters schedule_parameters)
		{
			int item = MinGroupSize + (RelativeGroupSize ? schedule_parameters.Parameters.MinimumGroupSize : 0);
			int item2 = MaxGroupSize + (RelativeGroupSize ? schedule_parameters.Parameters.MaximumGroupSize : 0);
			return (item, item2);
		}

		public float GetExpectedGroupSize(ScheduleParameters schedule_parameters)
		{
			int num = MinGroupSize + (RelativeGroupSize ? schedule_parameters.Parameters.MinimumGroupSize : 0);
			int num2 = MaxGroupSize + (RelativeGroupSize ? schedule_parameters.Parameters.MaximumGroupSize : 0);
			return (float)(num + num2) / 2f;
		}

		public int GetGroupSize(ScheduleParameters schedule_parameters)
		{
			int minInclusive = MinGroupSize + (RelativeGroupSize ? schedule_parameters.Parameters.MinimumGroupSize : 0);
			int num = MaxGroupSize + (RelativeGroupSize ? schedule_parameters.Parameters.MaximumGroupSize : 0);
			return Random.Range(minInclusive, num + 1);
		}
	}
}
