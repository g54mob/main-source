using System;
using UnityEngine;

[Serializable]
public class SaveableDogCore
{
	public delegate void ThumbnailGenerationCallback(ThumbnailSet newSet);

	public string dogName;

	public SaveableDogGene dogGene;

	public DogAge dogAge;

	public SaveableThumbSet thumbSet;

	public SaveableDogProfile dogProfile;

	public SaveableDogPersonality dogPersonality;

	public DeathReason dogDeathReason = DeathReason.OLD_AGE;

	public DogLabelType labelType;

	[NonSerialized]
	public Sprite defaultThumbnail;

	[NonSerialized]
	private GameObject thumbnailDog;

	public SaveableDogCore(SaveableDogGene gene, string name, DogAge age, SaveableDogProfile profile, SaveableDogPersonality personality, DeathReason reason, DogLabelType newLabelType, SaveableThumbSet newThumbSet)
	{
		dogAge = age;
		dogName = name;
		dogDeathReason = reason;
		dogGene = gene.GetCopy();
		dogProfile = profile.GetCopy();
		dogPersonality = personality.GetCopy();
		if (newThumbSet != null)
		{
			thumbSet = newThumbSet.GetCopy();
			defaultThumbnail = thumbSet.defaultPortrait.Load();
		}
		labelType = newLabelType;
	}

	public SaveableDogCore(DogCore c)
	{
		c.SaveCore(this);
	}

	public void Load(DogCore c)
	{
		c.LoadSaveableDogCore(this);
	}

	public SaveableDogCore GetCopy()
	{
		SaveableThumbSet newThumbSet = null;
		if (thumbSet != null)
		{
			newThumbSet = thumbSet.GetCopy();
		}
		if (dogProfile == null)
		{
			return new SaveableDogCore(dogGene.GetCopy(), dogName, dogAge, new SaveableDogProfile(dogName), new SaveableDogPersonality(new DogPersonality(traitsAllowed: false)), dogDeathReason, labelType, newThumbSet);
		}
		return new SaveableDogCore(personality: (dogPersonality == null) ? new SaveableDogPersonality(new DogPersonality(traitsAllowed: false)) : dogPersonality.GetCopy(), gene: dogGene.GetCopy(), name: dogName, age: dogAge, profile: dogProfile.GetCopy(), reason: dogDeathReason, newLabelType: labelType, newThumbSet: newThumbSet);
	}

	public void CacheThumbnail()
	{
		if (thumbSet == null || !(defaultThumbnail != null))
		{
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).RequestNewDog(new Vector3(1000f, 1000f, 1000f), Quaternion.identity, dogGene, null, manualDog: false, dogProfile: dogProfile, callback: OnThumbnailDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: dogAge, customDogAgeProgress: 0f);
		}
	}

	private void OnThumbnailDogCreated(GameObject dog)
	{
		thumbnailDog = dog;
		Rigidbody[] componentsInChildren = thumbnailDog.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody obj in componentsInChildren)
		{
			obj.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			obj.isKinematic = true;
		}
		DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		globalComponent.StartCoroutine(globalComponent.GenerateDogThumbnailFromDog(dog, 0uL, highQuality: false, OnThumbnailGenerated));
	}

	private void OnThumbnailGenerated(ThumbnailSet newSet)
	{
		if (thumbnailDog != null)
		{
			UnityEngine.Object.Destroy(thumbnailDog);
			thumbnailDog = null;
		}
		thumbSet = new SaveableThumbSet(newSet);
		defaultThumbnail = newSet.defaultThumb;
	}
}
