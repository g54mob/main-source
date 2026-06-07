using Dhs5.Utility.Updates;

public struct DelayedCallHandle
{
	public static DelayedCallHandle Empty = new DelayedCallHandle(0uL);

	public readonly ulong key;

	internal DelayedCallHandle(ulong key)
	{
		this.key = key;
	}

	public readonly void Kill()
	{
		if (key != 0)
		{
			Updater.KillDelayedCall(this);
		}
	}

	public bool IsValid()
	{
		if (key != 0)
		{
			return Updater.Instance.DoesDelayedCallExist(key);
		}
		return false;
	}

	public float GetTimeLeft()
	{
		if (key != 0 && Updater.Instance.GetDelayedCallTimeLeft(key, out var timeLeft))
		{
			return timeLeft;
		}
		return -1f;
	}

	public int GetFramesLeft()
	{
		if (key != 0 && Updater.Instance.GetDelayedCallFramesLeft(key, out var framesLeft))
		{
			return framesLeft;
		}
		return -1;
	}
}
