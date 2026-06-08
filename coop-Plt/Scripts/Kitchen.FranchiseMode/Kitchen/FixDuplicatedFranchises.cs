using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class FixDuplicatedFranchises : FranchiseSystem
	{
		private EntityQuery Franchises;

		protected override void Initialise()
		{
			base.Initialise();
			Franchises = GetEntityQuery(typeof(CFranchiseItem));
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = Franchises.ToEntityArray(Allocator.Temp);
			using NativeArray<CFranchiseItem> nativeArray2 = Franchises.ToComponentDataArray<CFranchiseItem>(Allocator.Temp);
			if (nativeArray.Length < 2)
			{
				return;
			}
			for (int num = nativeArray.Length - 1; num >= 0; num--)
			{
				for (int i = 0; i < num; i++)
				{
					if (AreEquivalent(nativeArray2[num], nativeArray2[i]))
					{
						base.EntityManager.DestroyEntity(nativeArray[num]);
					}
				}
			}
		}

		private bool AreEquivalent(CFranchiseItem f1, CFranchiseItem f2)
		{
			if (f1.Name != f2.Name)
			{
				return false;
			}
			if (f1.MapSeed.IntValue != f2.MapSeed.IntValue)
			{
				return false;
			}
			if (!f1.Cards.IsEquivalent(f2.Cards))
			{
				return false;
			}
			return true;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
