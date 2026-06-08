using System.Collections.Generic;
using Unity.Entities;

namespace Kitchen
{
	public static class EntityManagerExtensions
	{
		public static EntityContext Context(this EntityManager manager)
		{
			return new EntityContext(manager);
		}

		public static bool RequireComponent<T>(this EntityManager manager, Entity e, out T component) where T : struct, IComponentData
		{
			if (!manager.HasComponent<T>(e))
			{
				component = default(T);
				return false;
			}
			component = manager.GetComponentData<T>(e);
			return true;
		}

		public static bool RequireBuffer<T>(this EntityManager manager, Entity e, out DynamicBuffer<T> component) where T : struct, IBufferElementData
		{
			if (!manager.HasComponent<T>(e))
			{
				component = default(DynamicBuffer<T>);
				return false;
			}
			component = manager.GetBuffer<T>(e);
			return true;
		}

		public static T GetOrDefault<T>(this EntityManager manager, Entity e) where T : struct, IComponentData
		{
			manager.RequireComponent<T>(e, out var component);
			return component;
		}

		public static List<PlayerInputData> GatherInputs(this EntityManager manager, DynamicBuffer<CCapturedUserInput> captures)
		{
			List<PlayerInputData> list = new List<PlayerInputData>();
			for (int i = 0; i < captures.Length; i++)
			{
				CCapturedUserInput cCapturedUserInput = captures[i];
				PlayerInputData item = default(PlayerInputData);
				if (manager.RequireComponent<CPlayer>(cCapturedUserInput.User, out var component))
				{
					if (!manager.HasComponent<CInputData>(cCapturedUserInput.User))
					{
						item.Input = CInputData.Disconnected;
						item.PlayerID = component.ID;
					}
					else
					{
						item.Input = manager.GetComponentData<CInputData>(cCapturedUserInput.User);
						item.PlayerID = component.ID;
					}
					list.Add(item);
				}
			}
			return list;
		}
	}
}
