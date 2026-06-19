using OUSystems.Basics.Effects;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	private Transform _playerTransform;

	public ShakeReceiver ShakeReciever;

	[SerializeField]
	private float _catchupSpeed;

	[SerializeField]
	private Vector3 _offset;

	private bool _instantClip;

	public float BaseOrthographicSize;

	public float OrthographicZoomRange;

	[field: SerializeField]
	public Camera Camera { get; private set; }

	public bool InstantClip
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void Initiate(Transform playerTransform)
	{
	}

	private void OnDestroy()
	{
	}

	public void SetPosition(Vector3 position)
	{
	}

	private void LateUpdate()
	{
	}
}
