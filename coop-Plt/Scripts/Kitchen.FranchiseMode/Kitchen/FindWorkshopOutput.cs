using System.Collections.Generic;
using KitchenData;
using Sirenix.Utilities;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class FindWorkshopOutput : FranchiseSystem
	{
		private EntityQuery Inputs;

		private List<Appliance> InputAppliances = new List<Appliance>();

		private IEnumerable<WorkshopRecipe> Recipes;

		private int CachedIDSum;

		protected override void Initialise()
		{
			base.Initialise();
			Inputs = GetEntityQuery(typeof(CWorkshopInput), typeof(CItemHolder));
		}

		protected override void OnUpdate()
		{
			if (Inputs.IsEmpty || !Require<SWorkshopOutput>(out var comp))
			{
				return;
			}
			if (Recipes == null)
			{
				Recipes = base.Data.Get<WorkshopRecipe>();
			}
			using NativeArray<CItemHolder> nativeArray = Inputs.ToComponentDataArray<CItemHolder>(Allocator.Temp);
			InputAppliances.Clear();
			int num = 0;
			foreach (CItemHolder item in nativeArray)
			{
				if (Require<CCrateAppliance>((Entity)item, out CCrateAppliance comp2) && base.Data.TryGet<Appliance>(comp2.Appliance, out var output, warn_if_fail: true))
				{
					InputAppliances.Add(output);
					num += output.ID;
				}
			}
			if (num == CachedIDSum)
			{
				return;
			}
			CachedIDSum = num;
			Set(new SWorkshopOutput
			{
				Nonce = comp.Nonce
			});
			if (InputAppliances.IsNullOrEmpty())
			{
				return;
			}
			foreach (WorkshopRecipe recipe in Recipes)
			{
				if (recipe.IsSatisfied(InputAppliances, out var output2))
				{
					Set(new SWorkshopOutput
					{
						Nonce = comp.Nonce,
						OutputAppliance = output2.ID,
						IsReady = true
					});
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
