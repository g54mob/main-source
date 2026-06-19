using System.Collections.Generic;
using UnityEngine;

public static class TagGrabber
{
	public static List<GameObject> GetObjectsForTag(TagsEnum tagType)
	{
		if (tagType == TagsEnum.DOG)
		{
			return ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetAllDogs();
		}
		return ObjectRegistration.GetRegistrationScript().GetAllObjectsForTag(tagType);
	}
}
