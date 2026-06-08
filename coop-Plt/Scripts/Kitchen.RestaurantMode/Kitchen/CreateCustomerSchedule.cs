using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(CustomerSchedulingGroup))]
	public class CreateCustomerSchedule : RestaurantSystem
	{
		private struct SCacheHash : IComponentData
		{
			public int Hash;
		}

		public struct SAnalysis : IComponentData
		{
			public int SmallestGroupPossibility;

			public int LargestGroupPossibility;
		}

		private EntityQuery Players;

		private EntityQuery Schedule;

		private EntityQuery CustomerTypes;

		private EntityQuery SpawnMultipliers;

		private CustomerType GenericCustomerType;

		private List<ScheduleGroup> _Groups = new List<ScheduleGroup>();

		protected override void Initialise()
		{
			base.Initialise();
			Players = GetEntityQuery(new QueryHelper().All(typeof(CPlayer)).None(typeof(CJoiningPlayer)));
			Schedule = GetEntityQuery(typeof(CScheduledCustomer));
			CustomerTypes = GetEntityQuery(typeof(CCustomerSpawnDefinition), typeof(CCustomerType));
			SpawnMultipliers = GetEntityQuery(typeof(CCustomerSpawnModifier));
			RequireSingletonForUpdate<SKitchenParameters>();
		}

		private void FindCustomerType()
		{
			if (GenericCustomerType != null)
			{
				return;
			}
			foreach (CustomerType item in base.Data.Get<CustomerType>())
			{
				if (item.IsGenericGroup)
				{
					GenericCustomerType = item;
					break;
				}
			}
		}

		protected override void OnUpdate()
		{
			if (Has<SPracticeMode>())
			{
				return;
			}
			FindCustomerType();
			int num = GetOrDefault<SDay>().Day + (Has<SIsNightTime>() ? 1 : 0);
			using NativeArray<CCustomerSpawnModifier> nativeArray = SpawnMultipliers.ToComponentDataArray<CCustomerSpawnModifier>(Allocator.Temp);
			using NativeArray<CCustomerSpawnDefinition> spawns = CustomerTypes.ToComponentDataArray<CCustomerSpawnDefinition>(Allocator.Temp);
			using NativeArray<CCustomerType> types = CustomerTypes.ToComponentDataArray<CCustomerType>(Allocator.Temp);
			(FixedListInt128, FixedListFloat128) typeProbabilities = GetTypeProbabilities(spawns, types, GenericCustomerType.ID);
			FixedListInt128 item = typeProbabilities.Item1;
			FixedListFloat128 item2 = typeProbabilities.Item2;
			KitchenParameters parameters = GetOrDefault<SKitchenParameters>().Parameters;
			Factor factor = default(Factor);
			Factor factor2 = default(Factor);
			foreach (CCustomerSpawnModifier item3 in nativeArray)
			{
				factor += item3.BaseCustomerMultiplier;
				Factor factor3 = factor2;
				Factor perDayCustomerMultiplier = item3.PerDayCustomerMultiplier;
				factor2 = factor3 + perDayCustomerMultiplier.Repeat(num);
			}
			parameters.CustomersPerHour *= factor;
			parameters.CustomersPerHour *= factor2;
			SLargestTableSize orDefault = GetOrDefault<SLargestTableSize>();
			ScheduleParameters schedule_parameters = new ScheduleParameters
			{
				IsPracticeMode = Has<SPracticeMode>(),
				Day = num,
				Players = Players.CalculateEntityCount(),
				Parameters = parameters,
				CustomersPerHour = base.Data.Difficulty.CustomersPerHourBase,
				CustomersPerHourIncrease = base.Data.Difficulty.CustomersPerHourIncreasePerDay,
				Status = GetOrCreate<SGlobalStatusList>().StatusList,
				TypeValues = item,
				TypeProbabilities = item2,
				MaxTableSize = orDefault.LargestTableSize
			};
			int hashCode = schedule_parameters.GetHashCode();
			int hash = GetOrCreate<SCacheHash>().Hash;
			if (hashCode != hash)
			{
				base.EntityManager.DestroyEntity(Schedule);
				GetCustomersForDay(schedule_parameters);
				Set(new SCacheHash
				{
					Hash = hashCode
				});
				Set<SRequireSchedulingUpdate>();
			}
			else
			{
				Clear<SRequireSchedulingUpdate>();
			}
		}

		public float DetermineTotalCustomers(ScheduleParameters schedule_parameters)
		{
			float dayLength = ProgressionHelpers.GetDayLength(schedule_parameters.Day);
			float num = DifficultyHelpers.CustomerPlayersRateModifier(schedule_parameters.Players);
			float num2 = schedule_parameters.Parameters.CurrentCourses switch
			{
				1 => 1f, 
				2 => 1.25f, 
				3 => 1.5f, 
				_ => 1f, 
			};
			float num3 = schedule_parameters.Parameters.CustomersPerHour * DifficultyHelpers.CustomerModifierRateModifier(schedule_parameters.Parameters.CustomersPerHourReduction);
			float num4 = schedule_parameters.Day switch
			{
				0 => 1f, 
				1 => 1.25f, 
				2 => 1.5f, 
				_ => schedule_parameters.CustomersPerHour + schedule_parameters.CustomersPerHourIncrease * (float)(schedule_parameters.Day - 3), 
			};
			if (schedule_parameters.Day > 15)
			{
				num4 += schedule_parameters.CustomersPerHourIncrease * Mathf.Pow(schedule_parameters.Day - 15, 1.5f);
			}
			return dayLength / 25f * num3 * num4 * num / num2;
		}

		public void GetCustomersForDay(ScheduleParameters schedule_parameters)
		{
			int total_groups;
			using (Seed(1997821, schedule_parameters.Day))
			{
				float num = 0.2f;
				float num2 = 0.5f;
				float num3 = 0.8f;
				bool flag = schedule_parameters.HasStatus(RestaurantStatus.CustomersAllRush);
				float num4 = 1f;
				float num5 = DetermineTotalCustomers(schedule_parameters);
				if (schedule_parameters.HasStatus(RestaurantStatus.CustomersAfterClosingTime))
				{
					num4 = 1.2f;
					num5 *= num4;
				}
				SAnalysis t = new SAnalysis
				{
					SmallestGroupPossibility = 999
				};
				_Groups.Clear();
				for (int i = 0; i < schedule_parameters.TypeValues.Length; i++)
				{
					int id = schedule_parameters.TypeValues[i];
					float num6 = schedule_parameters.TypeProbabilities[i];
					if (!base.Data.TryGet<CustomerType>(id, out var output))
					{
						continue;
					}
					float expectedGroupSize = output.GetExpectedGroupSize(schedule_parameters);
					if (!(expectedGroupSize <= 0f))
					{
						float num7 = num5 * num6 / expectedGroupSize;
						(int, int) groupSizeBounds = output.GetGroupSizeBounds(schedule_parameters);
						t.SmallestGroupPossibility = Mathf.Min(t.SmallestGroupPossibility, groupSizeBounds.Item1);
						t.LargestGroupPossibility = Mathf.Max(t.LargestGroupPossibility, groupSizeBounds.Item2);
						for (int j = 0; (float)j < num7; j++)
						{
							_Groups.Add(new ScheduleGroup
							{
								Type = output
							});
						}
					}
				}
				Set(t);
				_Groups.ShuffleInPlace();
				total_groups = _Groups.Count;
				float num8 = 0.1f * num4 / (float)total_groups;
				for (int k = 0; k < _Groups.Count; k++)
				{
					CustomerType type = _Groups[k].Type;
					int groupSize = type.GetGroupSize(schedule_parameters);
					if (k == 0 && !flag)
					{
						AddGroup(type, groupSize, 0f, is_special: false);
						continue;
					}
					float num9 = num4 * (float)k / (float)total_groups;
					float num10 = Random.Range(num9 - num8, num9 + num8);
					if (num10 > 1f)
					{
						num10 = 1.1f + (num10 - 1f) * 2f;
					}
					else if (flag)
					{
						num10 = ((num10 < (num + num2) / 2f) ? num : ((num10 < (num2 + num3) / 2f) ? num2 : num3));
					}
					AddGroup(type, groupSize, Mathf.Clamp(num10, 0f, num4), is_special: false);
				}
				if (schedule_parameters.HasStatus(RestaurantStatus.MorningRush))
				{
					add_rush(num);
				}
				if (schedule_parameters.HasStatus(RestaurantStatus.LunchRush))
				{
					add_rush(num2);
				}
				if (schedule_parameters.HasStatus(RestaurantStatus.DinnerRush))
				{
					add_rush(num3);
				}
			}
			void add_rush(float time)
			{
				float num11 = Mathf.Max(1f, (float)total_groups * 0.15f);
				for (int l = 0; (float)l < num11; l++)
				{
					CustomerType genericCustomerType = GenericCustomerType;
					int groupSize2 = genericCustomerType.GetGroupSize(schedule_parameters);
					AddGroup(genericCustomerType, groupSize2, time, is_special: true);
				}
			}
		}

		private void AddGroup(CustomerType type, int group_size, float time, bool is_special)
		{
			if (!Has<SIsDayTime>() || !Require<STime>(out var comp) || !(time < comp.TimeOfDayUnbounded))
			{
				Entity e = base.EntityManager.CreateEntity(typeof(CScheduledCustomer));
				if (HasStatus(RestaurantStatus.PreparationTime))
				{
					float num = 0.16666669f;
					time = time / 1.2f + num;
				}
				Set(e, new CScheduledCustomer
				{
					GroupSize = group_size,
					TimeOfDay = time
				});
				Set(e, new CCustomerType
				{
					Type = type.ID
				});
				if (is_special)
				{
					Set<CExtraScheduledCustomer>(e);
				}
			}
		}

		public static (FixedListInt128, FixedListFloat128) GetTypeProbabilities(NativeArray<CCustomerSpawnDefinition> spawns, NativeArray<CCustomerType> types, int generic_type_id)
		{
			FixedListInt128 item = default(FixedListInt128);
			FixedListFloat128 item2 = default(FixedListFloat128);
			float num = 0f;
			foreach (CCustomerSpawnDefinition item4 in spawns)
			{
				num += item4.Probability;
			}
			float num2 = ((num > 1f) ? (1f / num) : 1f);
			float item3 = Mathf.Max(1f - num, 0f);
			for (int i = 0; i < spawns.Length; i++)
			{
				CCustomerSpawnDefinition cCustomerSpawnDefinition = spawns[i];
				CCustomerType cCustomerType = types[i];
				item.Add(in cCustomerType.Type);
				item2.Add(cCustomerSpawnDefinition.Probability * num2);
			}
			if (item3 > 0f)
			{
				item.Add(in generic_type_id);
				item2.Add(in item3);
			}
			return (item, item2);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
