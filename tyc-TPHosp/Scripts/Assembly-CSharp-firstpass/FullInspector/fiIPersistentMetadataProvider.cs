using System;
using FullInspector.Internal;

namespace FullInspector
{
	public interface fiIPersistentMetadataProvider
	{
		Type MetadataType { get; }

		void RestoreData(fiUnityObjectReference target);

		void Reset(fiUnityObjectReference target);
	}
}
