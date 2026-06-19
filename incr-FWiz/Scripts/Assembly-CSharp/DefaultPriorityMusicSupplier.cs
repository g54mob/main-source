using System;
using System.Collections.Generic;
using FMODUnity;

[Serializable]
public class DefaultPriorityMusicSupplier : PriorityMusicSupplier
{
	public int Priority;

	public List<EventReference> EventReferences;

	private int _index;

	public bool WaitForGameLoaded;

	public override int SupplierPriority => 0;

	private void OnEnable()
	{
	}

	public void OnEnabledAndReady()
	{
	}

	private void OnDisable()
	{
	}

	public override EventReference RequestSong()
	{
		return default(EventReference);
	}

	public void AddSong(EventReference song)
	{
	}
}
