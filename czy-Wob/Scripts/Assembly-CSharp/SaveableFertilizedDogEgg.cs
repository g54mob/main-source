using System;

[Serializable]
public class SaveableFertilizedDogEgg
{
	public SaveableDogEgg savedEgg;

	public float incubationLevel;

	public SerializableColor finalBodyBaseColor;

	public SerializableColor finalBodyEmissionColor;

	public SaveableFertilizedDogEgg()
	{
	}

	public SaveableFertilizedDogEgg(DogEgg eggRef)
	{
		incubationLevel = eggRef.GetIncubationLevel();
		savedEgg = eggRef.GetAssociatedSaveableEgg().GetCopy();
		finalBodyBaseColor = new SerializableColor(eggRef.GetFinalBodyBaseColor());
		finalBodyEmissionColor = new SerializableColor(eggRef.GetFinalBodyEmissionColor());
	}

	public void Load(DogEgg eggRef)
	{
		eggRef.LoadSaveableFertilizedDogEgg(this);
	}

	public SaveableFertilizedDogEgg GetCopy()
	{
		return new SaveableFertilizedDogEgg
		{
			savedEgg = savedEgg.GetCopy(),
			incubationLevel = incubationLevel,
			finalBodyBaseColor = finalBodyBaseColor.GetCopy(),
			finalBodyEmissionColor = finalBodyEmissionColor.GetCopy()
		};
	}
}
