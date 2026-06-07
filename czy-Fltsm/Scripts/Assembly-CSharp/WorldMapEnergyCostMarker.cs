using TMPro;
using UnityEngine;

public class WorldMapEnergyCostMarker : MonoBehaviour
{
	[SerializeField]
	private TextMeshPro _amountText;

	[SerializeField]
	private MeshRenderer _markerMeshRenderer;

	[SerializeField]
	private Color _inRangeColor = Color.white;

	[SerializeField]
	private Color _outOfRangeColor = Color.white;

	private Vector3 _position;

	private Transform _amountTransform;

	private WorldMapCameraController _worldMapCameraController;

	private void Awake()
	{
		_amountTransform = _amountText.transform;
		_position = new Vector3(0f, 0f, 0f);
	}

	public void Initialize(float amount, Vector2 position, WorldMapCameraController controller, bool inRange)
	{
		_amountText.text = amount.ToString("F0");
		_position.x = position.x;
		_position.z = position.y;
		base.transform.position = _position;
		_worldMapCameraController = controller;
		if (inRange)
		{
			_markerMeshRenderer.material.SetColor("_Color", _inRangeColor);
		}
		else
		{
			_markerMeshRenderer.material.SetColor("_Color", _outOfRangeColor);
		}
	}

	private void Update()
	{
		Vector3 eulerAngles = _worldMapCameraController.transform.rotation.eulerAngles;
		Vector3 eulerAngles2 = _amountTransform.rotation.eulerAngles;
		_amountText.transform.rotation = Quaternion.Euler(eulerAngles2.x, eulerAngles.y, eulerAngles2.z);
	}
}
