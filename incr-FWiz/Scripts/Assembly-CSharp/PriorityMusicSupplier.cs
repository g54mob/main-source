using FMODUnity;
using UnityEngine;

public abstract class PriorityMusicSupplier : MonoBehaviour
{
	public int FadeInTimeOverride;

	public int FadeOutDurationOverride;

	public bool Supplied;

	public abstract int SupplierPriority { get; }

	public void Supply()
	{
	}

	public void EndSupply()
	{
	}

	public abstract EventReference RequestSong();

	public virtual void OnSongEnd()
	{
	}

	private void OnDestroy()
	{
	}
}
