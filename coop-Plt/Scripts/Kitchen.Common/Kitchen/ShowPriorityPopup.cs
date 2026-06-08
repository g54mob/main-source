using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ShowPriorityPopup : GenericSystemBase
	{
		private EntityQuery Popups;

		private EntityQuery HiddenPopups;

		protected override void Initialise()
		{
			base.Initialise();
			Popups = GetEntityQuery(typeof(CPopup));
			HiddenPopups = GetEntityQuery(typeof(CPopup), typeof(CHideView));
			RequireForUpdate(Popups);
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = Popups.ToEntityArray(Allocator.Temp);
			using NativeArray<CPopup> nativeArray2 = Popups.ToComponentDataArray<CPopup>(Allocator.Temp);
			using (HiddenPopups.ToEntityArray(Allocator.Temp))
			{
				Entity entity = default(Entity);
				int num = -1;
				bool flag = false;
				for (int i = 0; i < nativeArray2.Length; i++)
				{
					if (!nativeArray2[i].Dismiss && (nativeArray2[i].Priority > num || (nativeArray2[i].Priority == num && !flag && !HasComponent<CHideView>(nativeArray[i]))))
					{
						num = nativeArray2[i].Priority;
						entity = nativeArray[i];
						flag = !HasComponent<CHideView>(nativeArray[i]);
					}
				}
				foreach (Entity item in nativeArray)
				{
					if (entity == item)
					{
						base.EntityManager.RemoveComponent<CHideView>(entity);
					}
					else
					{
						base.EntityManager.AddComponent<CHideView>(item);
					}
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
