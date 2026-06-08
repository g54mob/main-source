using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public abstract class PackLoader<T> : GenericSystemBase, IPackLoader where T : struct, IPackSaveObject
	{
		public bool LoadEntity(EntityManager ctx, ISaveObject save_object)
		{
			if (!(save_object is T val))
			{
				return false;
			}
			val.Load(ctx);
			return true;
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
