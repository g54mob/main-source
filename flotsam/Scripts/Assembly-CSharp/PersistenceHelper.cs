using System.Collections.Generic;
using PajamaLlama.Debugs;

public static class PersistenceHelper
{
	public static int[] ReturnPersistentReferenceIndices<T>(List<T> references) where T : IPersistentReference
	{
		int num = references?.Count ?? 0;
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = references[i].PersistentIndex;
		}
		return array;
	}

	public static List<Item> ReturnRestoredItems(int[] indices)
	{
		List<Item> list = new List<Item>();
		if (indices == null)
		{
			return list;
		}
		int num = (list.Capacity = indices.Length);
		for (int i = 0; i < num; i++)
		{
			if (PersistentReference<Item>.TryReturnReference(indices[i], out var reference))
			{
				list.Add(reference);
			}
		}
		if (num != list.Count)
		{
			Debugger.Warning("Persisted item count mismatch!");
		}
		return list;
	}
}
