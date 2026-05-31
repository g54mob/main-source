using System;
using System.Collections.Generic;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public abstract class fsDirectConverter : fsBaseConverter
	{
		public abstract Type ModelType { get; }
	}
	public abstract class fsDirectConverter<TModel> : fsDirectConverter
	{
		public override Type ModelType => null;

		public sealed override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			serialized = null;
			return default(fsResult);
		}

		public sealed override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			return default(fsResult);
		}

		protected abstract fsResult DoSerialize(TModel model, Dictionary<string, fsData> serialized);

		protected abstract fsResult DoDeserialize(Dictionary<string, fsData> data, ref TModel model);
	}
}
