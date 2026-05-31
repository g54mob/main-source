using UnityEngine;

[CreateAssetMenu(fileName = "MapEditorSaveData", menuName = "InternalMapEditor/MapEditor Save Data")]
public class GridEditionDataSO : ScriptableObject
{
	public GridSaveData[] grid;

	public FurnitureSaveStruct[] furnitures;

	public GridEditionDataSO()
	{
		grid = new GridSaveData[0];
		furnitures = new FurnitureSaveStruct[0];
	}
}
