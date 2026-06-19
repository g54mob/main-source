using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour
{
	public bool applyRegisteredComponentsToChildren = true;

	public List<BehaviorScoreModifier> behaviorScoreModifiers = new List<BehaviorScoreModifier>();

	protected bool isHeldByPlayer;

	private List<ulong> currentUsers = new List<ulong>();

	private List<ulong> currentFocusingDogs = new List<ulong>();

	private float multipleUsersCheckTimerLow = 1f;

	private float multipleUsersCheckTimerHigh = 3f;

	private float timeUntilNextMultiUserCheck;

	private void Update()
	{
		if (timeUntilNextMultiUserCheck > 0f)
		{
			timeUntilNextMultiUserCheck -= Time.deltaTime;
		}
		if (timeUntilNextMultiUserCheck > 0f)
		{
			return;
		}
		for (int i = 0; i < currentUsers.Count; i++)
		{
			for (int j = 0; j < currentUsers.Count; j++)
			{
				if (i != j)
				{
					ProcessMultipleUsers(currentUsers[i], currentUsers[j]);
				}
			}
		}
		timeUntilNextMultiUserCheck = Random.Range(multipleUsersCheckTimerLow, multipleUsersCheckTimerHigh);
	}

	public float GetMultiplierForBehavior(DogBehaviorTargetedEnum behavior)
	{
		float result = 1f;
		for (int i = 0; i < behaviorScoreModifiers.Count; i++)
		{
			if (behaviorScoreModifiers[i].modifiedBehaviors.Contains(behavior))
			{
				return behaviorScoreModifiers[i].finalScoreMultiplier;
			}
		}
		return result;
	}

	public void AddUser(ulong newUser)
	{
		if (currentUsers.Contains(newUser))
		{
			Debug.LogError("Attempting to double-add user: " + newUser + " to object: " + this);
		}
		else
		{
			currentUsers.Add(newUser);
		}
	}

	public void RemoveUser(ulong user)
	{
		if (currentUsers.Contains(user))
		{
			currentUsers.Remove(user);
		}
	}

	public List<ulong> GetUseList()
	{
		return currentUsers;
	}

	public virtual bool HasCustomInteractionPoint()
	{
		return false;
	}

	public virtual Vector3 GetInteractionPoint()
	{
		return ObjectUtil.GetObjCenter(base.gameObject);
	}

	public virtual Transform GetInteractionPointTransform()
	{
		return null;
	}

	public virtual Transform GetFocusTransform()
	{
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			rigidbody = GetComponentInChildren<Rigidbody>();
		}
		if (rigidbody != null)
		{
			return rigidbody.transform;
		}
		return base.transform;
	}

	public void AddFocusingDog(ulong newFocusDog)
	{
		if (currentFocusingDogs.Contains(newFocusDog))
		{
			Debug.LogError(string.Concat("Attempting to dobule-add focusing dog: ", newFocusDog, " to object: ", base.gameObject, " : ", base.gameObject.GetInstanceID()));
		}
		else
		{
			currentFocusingDogs.Add(newFocusDog);
		}
	}

	public void RemoveFocusingDog(ulong focusDog)
	{
		if (currentFocusingDogs.Contains(focusDog))
		{
			currentFocusingDogs.Remove(focusDog);
		}
	}

	public List<ulong> GetFocusList()
	{
		return currentFocusingDogs;
	}

	public bool IsObjectInUseByAnotherDog(ulong dogID)
	{
		if (currentUsers.Count > 1 || (currentUsers.Count == 1 && !currentUsers.Contains(dogID)))
		{
			return true;
		}
		return false;
	}

	public virtual void OnRegisteredComponentsAdded()
	{
	}

	public bool IsObjectHeldByPlayer()
	{
		return isHeldByPlayer;
	}

	public virtual void OnObjectGrabbedByPlayer()
	{
		isHeldByPlayer = true;
		for (int i = 0; i < currentUsers.Count; i++)
		{
			ProcessMultipleUsers(currentUsers[i], 0uL, fromPlayer: true);
		}
	}

	public virtual Rigidbody GetGrabbedBody(GameObject clickedBody)
	{
		return clickedBody.GetComponent<Rigidbody>();
	}

	public virtual void OnObjectDroppedByPlayer()
	{
		isHeldByPlayer = false;
	}

	public virtual void OnObjectThrownByPlayer()
	{
	}

	public virtual void OnObjectGrabbedByDog(GameObject dog)
	{
		ulong uID = dog.GetComponent<ObjectID>().GetUID();
		if (currentUsers.Count > 0)
		{
			for (int i = 0; i < currentUsers.Count; i++)
			{
				ProcessMultipleUsers(currentUsers[i], uID);
			}
		}
		AddUser(uID);
		timeUntilNextMultiUserCheck = multipleUsersCheckTimerHigh;
	}

	public virtual void OnObjectDroppedByDog(GameObject dog)
	{
		RemoveUser(dog.GetComponent<ObjectID>().GetUID());
	}

	public virtual void OnObjectThrownByDog(GameObject dog)
	{
	}

	public virtual void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
	}

	public virtual void OnObjectInteractedWithByDog(GameObject dog, FeelingTowardsTarget interactionType)
	{
		if (CompareTag(Tags.DOG))
		{
			GetComponent<DoggyBrain>().OnInteractedWithByDog(dog, interactionType);
		}
	}

	protected virtual void ProcessMultipleUsers(ulong existingUser, ulong newUser, bool fromPlayer = false)
	{
		if (!fromPlayer && existingUser == newUser)
		{
			return;
		}
		float newWeight = 1f;
		DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		GameObject target = null;
		if (!fromPlayer)
		{
			target = globalComponent.GetDogFromID(newUser);
		}
		GameObject dogFromID = globalComponent.GetDogFromID(existingUser);
		DogAI component = dogFromID.GetComponent<DogAI>();
		DoggyBrain component2 = dogFromID.GetComponent<DoggyBrain>();
		DogPersonality personality = component2.GetPersonality();
		FoodPersonalityType foodPersonality = personality.GetFoodPersonality();
		SocialPersonalityType socialPersonality = personality.GetSocialPersonality();
		MischiefPersonalityType mischiefPersonality = personality.GetMischiefPersonality();
		NicenessPersonalityType nicenessPersonalityType = personality.GetNicenessPersonalityType();
		if (nicenessPersonalityType == NicenessPersonalityType.NICE && mischiefPersonality == MischiefPersonalityType.POLITE)
		{
			dogFromID.GetComponent<MouthController>().DropObject();
			return;
		}
		bool flag = false;
		bool flag2 = false;
		if (nicenessPersonalityType == NicenessPersonalityType.MEAN)
		{
			flag = true;
		}
		else if (CompareTag(Tags.FOOD) && foodPersonality == FoodPersonalityType.FOOD_OBSESSED)
		{
			flag = true;
		}
		else if (CompareTag(Tags.FOOD) && foodPersonality != FoodPersonalityType.FOOD_AVERSE && component2.IsHungry())
		{
			flag = true;
		}
		if (nicenessPersonalityType == NicenessPersonalityType.NICE && flag)
		{
			flag = false;
			flag2 = true;
		}
		if (mischiefPersonality == MischiefPersonalityType.POLITE)
		{
			flag2 = false;
		}
		if (flag)
		{
			DistractionGrowl newDistraction = new DistractionGrowl(component, newWeight, target);
			component.TryAddNewDistraction(newDistraction, useTimeSinceLastDistraction: false);
			return;
		}
		if (flag2)
		{
			DistractionComplain newDistraction2 = new DistractionComplain(component, newWeight, target);
			component.TryAddNewDistraction(newDistraction2, useTimeSinceLastDistraction: false);
			return;
		}
		switch (socialPersonality)
		{
		case SocialPersonalityType.SOCIAL:
			component2.UpdateAnger(0.1f);
			component2.UpdateStress(0.1f);
			dogFromID.GetComponent<DogParticleController>().RequestHappyUpdateParticles();
			return;
		case SocialPersonalityType.ALOOF:
			dogFromID.GetComponent<MouthController>().DropObject();
			return;
		}
		if (Random.value < 0.25f)
		{
			DistractionComplain newDistraction3 = new DistractionComplain(component, newWeight, target);
			component.TryAddNewDistraction(newDistraction3, useTimeSinceLastDistraction: false);
		}
	}
}
