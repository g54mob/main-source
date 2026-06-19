using System;
using System.Collections;

public abstract class CinematicEvent
{
	public Action AnnounceComplete;

	public void Initiate()
	{
	}

	public abstract IEnumerator DoCinematicAction();
}
