using UnityEngine;

public class KeepTextWithinSafeZone : MonoBehaviour
{
	[SerializeField]
	[Range(0f, 1f)]
	private float _safeZoneMultiplierX = 0.7f;

	[SerializeField]
	[Range(0f, 1f)]
	private float _safeZoneMultiplierY = 0.7f;

	[SerializeField]
	private Transform _transformToCheckDistance;

	[SerializeField]
	private Rect _characterBounds;

	[SerializeField]
	private PugText _text;

	private Rect _realCharacterBounds;

	private Vector3 _positionOffset = Vector3.zero;

	[SerializeField]
	private Vector4 _offset;

	private Vector2[] _rectPoints = new Vector2[4];
}
