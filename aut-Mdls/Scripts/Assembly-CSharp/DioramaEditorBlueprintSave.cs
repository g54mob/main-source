using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DioramaEditorBlueprintSave : ScriptableObject
{
	public List<DioramaEditorBlueprint.PositionedShapeData> BlueprintDatas;

	public Texture2D Icon;

	public DioramaEditorBlueprintSave(List<DioramaEditorBlueprint.PositionedShapeData> blueprintDatas)
	{
		BlueprintDatas = blueprintDatas;
	}

	public DioramaEditorBlueprintSave()
	{
	}
}
