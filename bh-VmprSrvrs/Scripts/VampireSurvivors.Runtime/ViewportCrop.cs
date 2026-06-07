using UnityEngine;

public class ViewportCrop : MonoBehaviour
{
	private Vector2 ScreenRes;

	private Vector2 _referenceResolution;

	private float _currentAspectRatio;

	private float _referenceAspectRatio;

	private float _percentageX;

	private float _percentageY;

	private Camera _camera;

	private float xSize;

	private float ySize;

	private float xOffset;

	private float yOffset;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
