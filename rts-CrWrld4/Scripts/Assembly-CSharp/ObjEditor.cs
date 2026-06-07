using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions.ColorPicker;

public class ObjEditor : MonoBehaviour
{
	public GameObject posContainer;

	public GameObject scaleContainer;

	public GameObject rotationContainer;

	public GameObject labelsContainer;

	public InputField nameInput;

	public InputField posX;

	public InputField posY;

	public InputField posZ;

	public InputField rotX;

	public InputField rotY;

	public InputField rotZ;

	public InputField scaleX;

	public InputField scaleY;

	public InputField scaleZ;

	public Dropdown meshDropdown;

	public Text internalMeshChosenText;

	public GameObject internalChosenMesh;

	public ModelBrowser modelBrowser;

	public Text meshModeButtonText;

	public Text textureModeButtonText;

	public Dropdown textureDropdown;

	public GameObject textureRow;

	public Button colorButton;

	public InputField colorBrightness;

	public ColorPickerControl colorPicker;

	[NonSerialized]
	public CModObjRow row;

	private bool suppressColorPick;

	public void Show(CModObjRow row)
	{
	}

	public void OnMeshModeChange()
	{
	}

	public void OnTextureModeChange()
	{
	}

	private void SetMeshDropdown()
	{
	}

	private void SetTextureDropdown()
	{
	}

	public void OnNameChange(string val)
	{
	}

	public void OnMeshChange(int i)
	{
	}

	public void OnInternalMeshChange(string meshName)
	{
	}

	public void OnTextureChange(int i)
	{
	}

	public void OnPosX(string val)
	{
	}

	public void OnPosY(string val)
	{
	}

	public void OnPosZ(string val)
	{
	}

	public void OnRotX(string val)
	{
	}

	public void OnRotY(string val)
	{
	}

	public void OnRotZ(string val)
	{
	}

	public void OnScaleX(string val)
	{
	}

	public void OnScaleY(string val)
	{
	}

	public void OnScaleZ(string val)
	{
	}

	public void OnClone()
	{
	}

	public void OnColorPicked(Color color)
	{
	}

	public void OnColorBrightness(string val)
	{
	}

	public void OnShowColorPicker()
	{
	}
}
