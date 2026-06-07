using System;
using UnityEngine;
using UnityEngine.UI;

public class EditMeshDialog : MonoBehaviour
{
	public InputField pivotX;

	public InputField pivotY;

	public InputField pivotZ;

	public InputField nameField;

	public InputField scaleX;

	public InputField scaleY;

	public InputField scaleZ;

	public GameObject errorPane;

	public Text errorMessage;

	public Text vertexCountText;

	[NonSerialized]
	public CPack.CPackMesh mesh;

	public void OnEnable()
	{
	}

	public void Show(CPack.CPackMesh mesh)
	{
	}

	public void OnNameChanged()
	{
	}

	public void OnFlipX()
	{
	}

	public void OnFlipY()
	{
	}

	public void OnFlipZ()
	{
	}

	public void OnRotX()
	{
	}

	public void OnRotY()
	{
	}

	public void OnRotZ()
	{
	}

	public void OnMovePivotX(float val)
	{
	}

	public void OnMovePivotY(float val)
	{
	}

	public void OnMovePivotZ(float val)
	{
	}

	public void OnMoveScaleX(float val)
	{
	}

	public void OnMoveScaleY(float val)
	{
	}

	public void OnMoveScaleZ(float val)
	{
	}

	public void OnMoveScaleAll(float val)
	{
	}

	public void OnSetScale()
	{
	}

	public void OnMovePivot()
	{
	}

	public void RecalculateNormals()
	{
	}

	public void OnReimport()
	{
	}

	public void OnExport()
	{
	}

	public void AutoSetPivot()
	{
	}

	private void RefreshPreview()
	{
	}

	private string MeshToString()
	{
		return null;
	}
}
