using System;
using System.Collections.Generic;

[Serializable]
public class OperationAreaPieceProperty
{
	public string areaPackage = "New Package";

	public List<AreaPieceProperty> properties = new List<AreaPieceProperty>();

	public AreaPieceProperty GetAreaPiecePropertyByType(AreaPieceProperty.PieceType type)
	{
		return properties.Find((AreaPieceProperty x) => x.pieceType == type);
	}
}
