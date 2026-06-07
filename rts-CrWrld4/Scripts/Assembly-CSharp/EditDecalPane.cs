using UnityEngine;
using UnityEngine.UI;

public class EditDecalPane : MonoBehaviour
{
	public InputField decalGUIDInputField;

	public InspectorInt decalWidth;

	public InspectorInt decalHeight;

	public InspectorFloat decalTileX;

	public InspectorFloat decalTileY;

	public InspectorColor decalColor;

	public InspectorBool followCreeper;

	public InspectorChoice stretchChoice;

	public InspectorBool pointFiltering;

	public InspectorBool wrapMode;

	public InspectorChoice imageChoice;

	public InspectorBool flipHorizontal;

	public InspectorBool flipVertical;

	public InspectorBool rotate0;

	public InspectorBool rotate90;

	public InspectorBool rotate180;

	public InspectorBool rotate270;

	public InspectorBool showOnCliffs;

	public InspectorBool visible;

	private TerrainDecal decal;

	public void CloseEditor()
	{
	}

	public void Update()
	{
	}

	public void OnDisable()
	{
	}

	public TerrainDecal GetDecal()
	{
		return null;
	}

	public void ShowEditor(TerrainDecal decal)
	{
	}

	public void OnApply()
	{
	}

	public void OnDeleteDecal()
	{
	}

	public void LoadPNGFromFile()
	{
	}

	private void LoadFileBrowserOutput(string path)
	{
	}

	private void FileBrowserWindowClosed()
	{
	}
}
