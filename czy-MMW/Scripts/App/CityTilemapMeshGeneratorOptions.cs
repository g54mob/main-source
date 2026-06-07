using UnityEngine;

public static class CityTilemapMeshGeneratorOptions
{
	public const string ShowPreviewMeshInPrefabEditorPrefKey = "CityTilemapMeshGenerator_ShowPreviewMeshInPrefab";

	public const string ShowPreviewMeshInGameEditorPrefKey = "CityTilemapMeshGenerator_ShowPreviewMeshInGame";

	public const string UpdatePreviewMeshWhileEditingTilemap = "CityTilemapMeshGenerator_UpdatePreviewMeshWhileEditingTilemap";

	public const string ShowWireMeshGizmoEditorPrefKey = "CityTilemapMeshGenerator_ShowWireMeshGizmo";

	public static bool UpdatePreviewMeshWhileEditing => GetOption("CityTilemapMeshGenerator_UpdatePreviewMeshWhileEditingTilemap");

	public static bool ShowWireMeshGizmo => GetOption("CityTilemapMeshGenerator_ShowWireMeshGizmo");

	public static bool ShowPreviewMesh
	{
		get
		{
			if (Application.isPlaying && GetOption("CityTilemapMeshGenerator_ShowPreviewMeshInGame"))
			{
				return true;
			}
			return GetOption("CityTilemapMeshGenerator_ShowPreviewMeshInPrefab");
		}
	}

	private static bool GetOption(string key)
	{
		if (key == "CityTilemapMeshGenerator_ShowPreviewMeshInGame")
		{
			return true;
		}
		return false;
	}
}
