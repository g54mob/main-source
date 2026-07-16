using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OperationAreaPiecePropertyLibrary", menuName = "Libraries/OperationAreaPiecePropertyLibrary")]
public class OperationAreaPiecePropertyLibrary : ScriptableObject
{
	public List<OperationAreaPieceProperty> pieceProperties = new List<OperationAreaPieceProperty>();

	public GameObject GetAreaPiecePropertyPrefab(int propertyId, AreaPieceProperty.PieceType type)
	{
		return pieceProperties[propertyId].GetAreaPiecePropertyByType(type).prefab;
	}
}
