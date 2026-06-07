using PajamaLlama.Math;
using TMPro;
using UnityEngine;

public class WorldMapCompassBearing : MonoBehaviour
{
	[SerializeField]
	private Transform _rotationContainer;

	[SerializeField]
	private SpriteRenderer _iconRenderer;

	[SerializeField]
	private TextMeshPro _distanceText;

	[SerializeField]
	[Tooltip("The distance that the townheart needs to have moved forward on the X-axis before the bearing becomes invisisble")]
	private float _visibleDistance = 2000f;

	[SerializeField]
	private AnimationCurve _visibilityCurve;

	private WorldMapTownheart _townheart;

	private Vector2 _targetDirection;

	private float _radius;

	private Vector3 _scale;

	public bool IsInitialized => _townheart != null;

	public IWorldMapCompassBearingTarget Target { get; private set; }

	public void Initialize(WorldMapTownheart townheart)
	{
		_townheart = townheart;
		_radius = GameManager.Settings.GameplaySettings.SwimmingRadius;
		_scale = _rotationContainer.transform.localScale;
	}

	private void LateUpdate()
	{
		UpdateBearing();
	}

	public void Activate(IWorldMapCompassBearingTarget target)
	{
		Target = target;
		_iconRenderer.sprite = target.BearingIcon;
		base.gameObject.SetActive(value: true);
		UpdateBearing();
	}

	public void UpdateBearing()
	{
		if (!(_townheart == null))
		{
			Vector3 position = _townheart.Position;
			Vector3 worldPosition = Target.WorldPosition;
			float num = position.DistanceToLeveled(worldPosition);
			float num2 = _townheart.Position.x - Target.WorldPosition.x;
			_rotationContainer.transform.localScale = _scale * _visibilityCurve.Evaluate(Mathf.Clamp01(num2 / _visibleDistance));
			if (num <= _radius)
			{
				_rotationContainer.gameObject.SetActive(value: false);
				return;
			}
			_rotationContainer.gameObject.SetActive(value: true);
			_rotationContainer.localPosition = new Vector3(0f, 0f, _radius);
			_targetDirection.x = worldPosition.x - position.x;
			_targetDirection.y = worldPosition.z - position.z;
			_distanceText.text = Mathf.FloorToInt(num).ToString();
			float y = Vector2.SignedAngle(_targetDirection, Vector2.up);
			base.transform.rotation = Quaternion.Euler(new Vector3(0f, y, 0f));
		}
	}
}
