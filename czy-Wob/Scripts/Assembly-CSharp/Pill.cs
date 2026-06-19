using System.Collections.Generic;
using UnityEngine;

public class Pill : Eatable
{
	public Renderer capRenderer;

	public Renderer containerRenderer;

	public string newGene;

	public bool mutateDog;

	public List<GeneMod> geneticMods = new List<GeneMod>();

	protected override void OnBiteTaken(GameObject dog)
	{
		bool flag = !ApplyNewGene(dog);
		bool flag2 = !flag;
		if (!flag2)
		{
			flag2 = ApplyGeneticMods(dog);
		}
		if (mutateDog)
		{
			flag = false;
			flag2 = true;
			DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
			SaveableDog saveableDogFromDog = globalComponent.GetSaveableDogFromDog(dog);
			MasterDogGene component = dog.GetComponent<MasterDogGene>();
			saveableDogFromDog.dogGene.dogGene = MasterDogGene.MutateGenome(component.GetFullGene());
			globalComponent.UpdateSaveableDog(saveableDogFromDog);
			component.MapDogGene(saveableDogFromDog.dogGene);
		}
		if (flag2)
		{
			RebuildDog(dog, flag);
		}
	}

	private bool ApplyNewGene(GameObject dog)
	{
		if (newGene == null)
		{
			return false;
		}
		DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		SaveableDog saveableDogFromDog = globalComponent.GetSaveableDogFromDog(dog);
		saveableDogFromDog.dogGene.dogGene = newGene;
		globalComponent.UpdateSaveableDog(saveableDogFromDog);
		return true;
	}

	private bool ApplyGeneticMods(GameObject dog)
	{
		if (geneticMods.Count == 0)
		{
			return false;
		}
		MasterDogGene component = dog.GetComponent<MasterDogGene>();
		for (int i = 0; i < geneticMods.Count; i++)
		{
			geneticMods[i].ApplyMod(component);
		}
		return true;
	}

	private void RebuildDog(GameObject dog, bool saveGene)
	{
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).RebuildDog(dog, saveGene);
	}
}
