using UnityEngine;

public class RoofPointObject : MonoBehaviour
{
	public RoofEditWindow Parent;

	public MeshRenderer Rend;

	public Material NormalMat;

	public Material HighlightMat;

	public Material ErrorMat;

	public Material LowLightMat;

	private bool _highlight;

	private bool _lowLight;

	private bool _error;

	public Vector2 P
	{
		get
		{
			return base.transform.position.FlattenVector3();
		}
	}

	public void Init(RoofEditWindow parent, Vector2 roofPosition)
	{
		Parent = parent;
		SetPosition(roofPosition);
	}

	public void LowLight(bool h)
	{
		_lowLight = h;
		UpdateColor();
	}

	public void Highlight(bool h)
	{
		_highlight = h;
		UpdateColor();
	}

	public void Error(bool e)
	{
		_error = e;
		UpdateColor();
	}

	private void UpdateColor()
	{
		if (_lowLight)
		{
			Rend.sharedMaterial = LowLightMat;
		}
		else if (_highlight)
		{
			Rend.sharedMaterial = HighlightMat;
		}
		else if (_error)
		{
			Rend.sharedMaterial = ErrorMat;
		}
		else
		{
			Rend.sharedMaterial = NormalMat;
		}
	}

	public void SetPosition(Vector2 pos)
	{
		base.transform.position = pos.ToVector3((float)(GameSettings.Instance.ActiveFloor * 2) + Parent.HeightSlider.value);
	}

	public void UpdatePosition()
	{
		base.transform.position = base.transform.position.ReplaceY((float)(GameSettings.Instance.ActiveFloor * 2) + Parent.HeightSlider.value);
	}
}
