using MyBox;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class AspectRatioCameraFitter : MonoBehaviour
{
	public Vector2 CoverSize;

	public float m_Ratio;

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private Vector2 targetAspectRatio;

	private readonly Vector2 rectCenter;

	private Vector2 lastResolution;

	private void OnValidate()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void SetResolution()
	{
	}

	private void CalculateCameraRect(Vector2 currentScreenResolution)
	{
	}

	public Vector2 GetVisualRatio()
	{
		return default(Vector2);
	}

	public Vector3 LerpByDistance(Vector3 A, Vector3 B, float x)
	{
		return default(Vector3);
	}
}
