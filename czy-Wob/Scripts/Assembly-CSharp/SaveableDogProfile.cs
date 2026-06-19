using System;

[Serializable]
public class SaveableDogProfile
{
	public string defaultName;

	public SaveableDogProfile(string defaultName)
	{
		this.defaultName = defaultName;
	}

	public SaveableDogProfile(DogProfile existingProfile)
	{
		defaultName = existingProfile.defaultName;
	}

	public SaveableDogProfile GetCopy()
	{
		return new SaveableDogProfile(defaultName);
	}
}
