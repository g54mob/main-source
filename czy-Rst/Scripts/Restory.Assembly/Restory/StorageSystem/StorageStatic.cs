using System;

namespace Restory.StorageSystem
{
	[Serializable]
	public class StorageStatic : StorageBase
	{
		public StorageStatic(int size)
			: base(size)
		{
		}
	}
}
