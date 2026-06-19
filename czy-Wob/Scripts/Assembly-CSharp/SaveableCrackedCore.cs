using System;

[Serializable]
public class SaveableCrackedCore
{
	public CoreQuality quality;

	public SaveableCrackedCore(CoreQuality newQuality)
	{
		quality = newQuality;
	}

	public SaveableCrackedCore(CrackedDogCore c)
	{
		quality = c.GetCoreQuality();
	}

	public void Load(CrackedDogCore c)
	{
		c.SetAssociatedCoreQuality(quality);
	}

	public SaveableCrackedCore GetCopy()
	{
		return new SaveableCrackedCore(quality);
	}
}
