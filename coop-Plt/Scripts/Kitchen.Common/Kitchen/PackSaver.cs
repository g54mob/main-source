using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public abstract class PackSaver<T> : GenericSystemBase, IPackSaver where T : struct, IPackSaveObject
	{
		public virtual bool PrepareEntity(EntityManager ctx, Entity e)
		{
			if (SaveEntity(ctx, e, out var _))
			{
				ctx.DestroyEntity(e);
				return true;
			}
			return false;
		}

		public bool SaveEntity(EntityManager ctx, Entity e, out ISaveObject save_object)
		{
			T val = default(T);
			bool result = val.Save(ctx, e);
			save_object = val;
			return result;
		}

		protected override void OnUpdate()
		{
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
