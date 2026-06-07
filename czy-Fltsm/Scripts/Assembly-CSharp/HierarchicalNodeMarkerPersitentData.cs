using System;
using PajamaLlama.Debugs;
using UnityEngine;

[Serializable]
public class HierarchicalNodeMarkerPersitentData
{
	public PersistentReference<Construction>.Reference Construction;

	public int MarkerIndex;

	[NonSerialized]
	public HierarchicalNodeMarker Instance;

	public HierarchicalNodeMarkerPersitentData(HierarchicalNodeMarker marker)
	{
		Construction = marker.Construction;
		MarkerIndex = 0;
		HierarchicalNodeMarker[] componentsInChildren = marker.Construction.GetComponentsInChildren<HierarchicalNodeMarker>();
		int num = componentsInChildren.Length;
		for (int i = 0; i < num; i++)
		{
			if (componentsInChildren[i] == marker)
			{
				MarkerIndex = i;
				break;
			}
		}
	}

	public void Restore()
	{
		if (Construction.TryReturn(out var instance))
		{
			HierarchicalNodeMarker[] componentsInChildren = instance.GetComponentsInChildren<HierarchicalNodeMarker>();
			if (MarkerIndex < componentsInChildren.Length)
			{
				Instance = componentsInChildren[MarkerIndex];
				if (MarkerIndex != 0)
				{
					Debug.Log(Instance.name);
				}
			}
			else
			{
				Debugger.Warning("[Persistence]: Construction marker index out of bounds, defaulting to primary marker.");
				Instance = instance.Target.PrimaryMarker;
			}
		}
		else
		{
			Debugger.Warning("[Persistence]: Construction with index " + Construction.PersistentIndex + " not found! Could it be that it is not yet restored?");
		}
	}
}
