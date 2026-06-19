using UnityEngine;

public class DogPersonalityTrait : MonoBehaviour
{
	public string traitName;

	public string traitDescription;

	public void SetTrait(string nameValue, string descriptionValue)
	{
		traitName = nameValue;
		traitDescription = descriptionValue;
	}
}
