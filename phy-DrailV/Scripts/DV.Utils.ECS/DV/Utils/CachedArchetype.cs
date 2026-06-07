using System;
using Unity.Entities;

namespace DV.Utils
{
	public class CachedArchetype
	{
		private readonly ComponentType[] types;

		private EntityArchetype archetype;

		public EntityArchetype Archetype
		{
			get
			{
				if (!archetype.Valid)
				{
					archetype = World.DefaultGameObjectInjectionWorld.EntityManager.CreateArchetype(types);
				}
				return archetype;
			}
		}

		public CachedArchetype(params ComponentType[] types)
		{
			this.types = types;
		}

		public CachedArchetype(CachedArchetype otherArchetype, params ComponentType[] types)
		{
			this.types = new ComponentType[otherArchetype.types.Length + types.Length];
			Array.Copy(otherArchetype.types, this.types, otherArchetype.types.Length);
			Array.Copy(types, 0, this.types, otherArchetype.types.Length, types.Length);
		}
	}
}
