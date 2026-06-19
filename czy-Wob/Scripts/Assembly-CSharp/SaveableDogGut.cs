using System;
using System.Collections.Generic;

[Serializable]
public class SaveableDogGut
{
	public List<SaveableGutFlora> gutFlora = new List<SaveableGutFlora>();

	public SaveableDogGut(DogGutController gutRef)
	{
		SaveGut(gutRef);
	}

	private SaveableDogGut()
	{
	}

	public SaveableDogGut GetCopy()
	{
		SaveableDogGut saveableDogGut = new SaveableDogGut();
		saveableDogGut.gutFlora = new List<SaveableGutFlora>();
		for (int i = 0; i < gutFlora.Count; i++)
		{
			saveableDogGut.gutFlora.Add(gutFlora[i].GetCopy());
		}
		return saveableDogGut;
	}

	public void LoadGut(DogGutController gutRef)
	{
		if (!(gutRef.GetDogGut() == null))
		{
			gutRef.GetDogGut().ClearGut();
			for (int i = 0; i < gutFlora.Count; i++)
			{
				gutRef.GetDogGut().SpawnSavedGutFlora(gutFlora[i]);
			}
		}
	}

	private void SaveGut(DogGutController gutRef)
	{
		DogGut dogGut = gutRef.GetDogGut();
		if (!(dogGut == null))
		{
			List<GutFloraBase> allGutFlora = dogGut.GetAllGutFlora();
			for (int i = 0; i < allGutFlora.Count; i++)
			{
				gutFlora.Add(new SaveableGutFlora(allGutFlora[i]));
			}
		}
	}
}
