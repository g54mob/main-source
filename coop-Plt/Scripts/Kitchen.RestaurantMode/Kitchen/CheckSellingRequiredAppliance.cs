using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kitchen.Layouts;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	public class CheckSellingRequiredAppliance : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SWarning : IComponentData
		{
		}

		private EntityQuery Unlocks;

		private EntityQuery CurrentAppliances;

		private EntityQuery ParcelsAppliances;

		private EntityQuery Slots;

		private EntityQuery UnsellableAppliances;

		protected override void Initialise()
		{
			base.Initialise();
			Unlocks = GetEntityQuery(typeof(CProgressionUnlock));
			CurrentAppliances = GetEntityQuery(new QueryHelper().All(typeof(CAppliance)).None(typeof(CDestroyApplianceAtDay)));
			ParcelsAppliances = GetEntityQuery(typeof(CLetterAppliance));
			UnsellableAppliances = GetEntityQuery(new QueryHelper().All(typeof(CUnsellableAppliance), typeof(CPosition)).None(typeof(CHeldAppliance)));
		}

		public static bool IsMissingCleaningProcess(NativeArray<CAppliance> current_appliances, NativeArray<CLetterAppliance> current_parcels = default(NativeArray<CLetterAppliance>))
		{
			foreach (CAppliance item in current_appliances)
			{
				if (!GameData.Main.TryGet<Appliance>(item, out var output, warn_if_fail: true))
				{
					continue;
				}
				foreach (Appliance.ApplianceProcesses process in output.Processes)
				{
					if (process.Validity != ProcessValidity.DoesNotRegister && AssetReference.MustHaveOneOfProcesses.Contains(process.Process.ID))
					{
						return false;
					}
				}
			}
			if (current_parcels.IsCreated)
			{
				foreach (CLetterAppliance item2 in current_parcels)
				{
					if (!GameData.Main.TryGet<Appliance>(item2.ApplianceID, out var output2, warn_if_fail: true))
					{
						continue;
					}
					foreach (Appliance.ApplianceProcesses process2 in output2.Processes)
					{
						if (process2.Validity != ProcessValidity.DoesNotRegister && AssetReference.MustHaveOneOfProcesses.Contains(process2.Process.ID))
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		protected override void OnUpdate()
		{
			GameData data = base.Data;
			using NativeArray<Entity> nativeArray = Unlocks.ToEntityArray(Allocator.Temp);
			using NativeArray<CAppliance> current_appliances = CurrentAppliances.ToComponentDataArray<CAppliance>(Allocator.Temp);
			HashSet<Process> hashSet = new HashSet<Process>();
			new HashSet<int>();
			bool flag = false;
			bool flag2 = false;
			foreach (Entity item in nativeArray)
			{
				if (!base.Data.TryGet<Dish>(GetComponent<CProgressionUnlock>(item).ID, out var output))
				{
					continue;
				}
				if (output.RequiresCleaning)
				{
					flag = true;
					foreach (Dish.MenuItem unlocksMenuItem in output.UnlocksMenuItems)
					{
						if (unlocksMenuItem.Phase == MenuPhase.Main)
						{
							flag2 = true;
						}
					}
				}
				foreach (Process requiredProcess in output.RequiredProcesses)
				{
					hashSet.Add((requiredProcess.IsPseudoprocessFor == null) ? requiredProcess : requiredProcess.IsPseudoprocessFor);
				}
			}
			foreach (CAppliance item2 in current_appliances)
			{
				if (!data.TryGet<Appliance>(item2, out var output2, warn_if_fail: true))
				{
					continue;
				}
				foreach (Appliance.ApplianceProcesses process in output2.Processes)
				{
					if (process.Validity != ProcessValidity.DoesNotRegister)
					{
						hashSet.Remove(process.Process);
					}
				}
			}
			NativeArray<CLetterAppliance> nativeArray2 = ParcelsAppliances.ToComponentDataArray<CLetterAppliance>(Allocator.Temp);
			foreach (CLetterAppliance item3 in nativeArray2)
			{
				if (item3.ApplianceID == 0 || !data.TryGet<Appliance>(item3.ApplianceID, out var output3, warn_if_fail: true))
				{
					continue;
				}
				foreach (Appliance.ApplianceProcesses process2 in output3.Processes)
				{
					if (process2.Validity != ProcessValidity.DoesNotRegister)
					{
						hashSet.Remove(process2.Process);
					}
				}
			}
			nativeArray2.Dispose();
			using NativeArray<CPosition> nativeArray3 = UnsellableAppliances.ToComponentDataArray<CPosition>(Allocator.Temp);
			bool flag3 = false;
			foreach (CPosition item4 in nativeArray3)
			{
				flag3 |= LayoutHelpers.IsOutsidePlayable(base.TileManager.GetTile(item4).Type);
				if (flag3)
				{
					break;
				}
			}
			if ((flag && IsMissingCleaningProcess(current_appliances) && flag2) || hashSet.Count > 0 || flag3)
			{
				Set<SWarning>();
			}
			else
			{
				Clear<SWarning>();
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
