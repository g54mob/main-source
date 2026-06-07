using System;
using Unity.Collections;

namespace Gh.Tk
{
	[PersistenceOptIn]
	public class AtmosphereGrid : IDisposable
	{
		public int runtimeDataId;

		public NativeArray<float> values;

		public NativeArray<sbyte> outputs;

		public NativeArray<sbyte> equilibriumValues;

		public bool outputsDirty;

		public bool equlibriumValuesDirty;

		public void Save(DataStore data)
		{
		}

		public void Load(DataStore data)
		{
		}

		public void Dispose()
		{
		}
	}
}
