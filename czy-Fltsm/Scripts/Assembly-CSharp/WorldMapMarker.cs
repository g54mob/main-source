using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.UI;

public class WorldMapMarker : MonoBehaviour
{
	[SerializeField]
	private Image _markerVisual;

	[SerializeField]
	private Color _inRangeColor = Color.white;

	[SerializeField]
	private Color _outOfRangeColor = Color.red;

	private Camera _worldMapCamera;

	private RectTransform _canvasRectTransform;

	private WorldMap _worldMap;

	private float _interactableRadius;

	public IWorldMapMarkerTarget Target { get; private set; }

	public void Initialize(WorldMap worldMap, RectTransform canvasRectTransform, IWorldMapMarkerTarget target)
	{
		_worldMap = worldMap;
		_worldMapCamera = worldMap.WorldCameraController.Camera;
		_canvasRectTransform = canvasRectTransform;
		_interactableRadius = GameManager.Settings.GameplaySettings.InteractionRadius;
		Target = target;
	}

	private void Update()
	{
		Vector3 vector = ReturnTargetWorldPosition();
		Vector3 position = _worldMap.Townheart.transform.position;
		_markerVisual.overrideSprite = Target.Icon;
		_markerVisual.color = (vector.IsInRange(position, _interactableRadius) ? _inRangeColor : _outOfRangeColor);
		Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(_worldMapCamera, vector);
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRectTransform, screenPoint, null, out var localPoint))
		{
			base.transform.localPosition = localPoint;
		}
	}

	private Vector3 ReturnTargetWorldPosition()
	{
		return WorldManager.ReturnLocalToWorldPosition(Target.LocalPosition);
	}
}
