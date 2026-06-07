using UnityEngine;

public class FogOfWarCtrl : MonoBehaviour
{
	[SerializeField]
	private Renderer renderer_Area;

	[SerializeField]
	private float radius;

	private void Reset()
	{
	}

	public bool IsValid()
	{
		return false;
	}

	public void SetRadius(float radius)
	{
	}

	public float GetRadius()
	{
		return 0f;
	}
}
