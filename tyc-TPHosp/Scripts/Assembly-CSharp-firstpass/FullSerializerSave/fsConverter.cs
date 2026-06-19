using System;

namespace FullSerializerSave
{
	public abstract class fsConverter : fsBaseConverter
	{
		public abstract bool CanProcess(Type type);
	}
}
