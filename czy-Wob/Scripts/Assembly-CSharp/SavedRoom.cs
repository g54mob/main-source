using System;
using System.Collections.Generic;

[Serializable]
public class SavedRoom : SavedBuildObject
{
	public string carpetPath;

	public string wallpaperPath;

	public int numberOfDensToBuild;

	public List<SaveablePlacedObject> placedPlants = new List<SaveablePlacedObject>();

	public List<SaveablePlacedObject> placedPuddles = new List<SaveablePlacedObject>();

	public List<SaveablePlacedObject> placedObjects = new List<SaveablePlacedObject>();
}
