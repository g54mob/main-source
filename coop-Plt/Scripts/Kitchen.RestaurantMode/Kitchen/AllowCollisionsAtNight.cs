using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class AllowCollisionsAtNight : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SCollisionsAllowed : IComponentData
		{
		}

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SCollisionsAllowed_4;

		protected override void OnUpdate()
		{
			bool flag = HasSingleton<SIsNightTime>();
			bool flag2 = HasSingleton<SCollisionsAllowed>();
			if (flag != flag2)
			{
				if (flag)
				{
					Entity entity = base.EntityManager.CreateEntity(typeof(SCollisionsAllowed));
					base.EntityManager.AddComponentData(entity, new CRequiresView
					{
						Type = ViewType.AllowPlayerCollisions
					});
				}
				else
				{
					base.EntityManager.DestroyEntity(_SingletonEntityQuery_SCollisionsAllowed_4.GetSingletonEntity());
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SCollisionsAllowed_4 = GetEntityQuery(ComponentType.ReadOnly<SCollisionsAllowed>());
		}
	}
}
