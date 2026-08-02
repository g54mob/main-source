using UnityEngine;

public class ChunkPreLoader : MonoBehaviour
{
	public ChunkDataHolder chunkDataHolder;

	public BiomesAndAreas selectedBiom;

	public void SetPreLoadObjects()
	{
		if (!(chunkDataHolder == null))
		{
			chunkDataHolder.LoadPreGeneratedObjects();
		}
	}

	public void GetAllCells()
	{
		if (!(chunkDataHolder == null))
		{
			chunkDataHolder.GetAllCells();
		}
	}

	public void AddMultipleSelected()
	{
		if (!(chunkDataHolder == null))
		{
			chunkDataHolder.AddMultipleSelected(selectedBiom);
		}
	}

	public void RemoveSelecteds()
	{
		if (!(chunkDataHolder == null))
		{
			chunkDataHolder.RemoveSelecteds();
		}
	}

	public void SetPreArrangedChests()
	{
		if (!(chunkDataHolder == null))
		{
			chunkDataHolder.LoadPreArrangedChests();
		}
	}

	public void DeleteDuplicatedPrespawnedObjects()
	{
		if (!(chunkDataHolder == null))
		{
			chunkDataHolder.DeleteDuplicatedPrespawnedObjects();
		}
	}
}
