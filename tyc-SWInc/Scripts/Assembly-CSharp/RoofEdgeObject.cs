using UnityEngine;

public class RoofEdgeObject : MonoBehaviour
{
	public RoofEditWindow Parent;

	public RoofPointObject A;

	public RoofPointObject B;

	public MeshRenderer Rend;

	public Material NormalMat;

	public Material LowLightMat;

	public Material ErrorMat;

	private bool _lowLight;

	private bool _error;

	public void LowLight(bool h)
	{
		_lowLight = h;
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
		else if (_error)
		{
			Rend.sharedMaterial = ErrorMat;
		}
		else
		{
			Rend.sharedMaterial = NormalMat;
		}
	}

	public void Init(RoofEditWindow parent, RoofPointObject a, RoofPointObject b)
	{
		Parent = parent;
		A = a;
		B = b;
		RefreshPosition();
	}

	public void RefreshPosition()
	{
		Vector3 position = A.transform.position;
		Vector3 position2 = B.transform.position;
		Vector3 forward = position - position2;
		base.transform.SetPositionAndRotation((position + position2) * 0.5f, Quaternion.LookRotation(forward));
		base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.y, forward.magnitude);
	}
}
