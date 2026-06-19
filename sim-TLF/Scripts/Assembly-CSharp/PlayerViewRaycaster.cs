using UnityEngine;

public class PlayerViewRaycaster : MonoBehaviour
{
	[Header("Links")]
	[SerializeField]
	private RaycasterInfo _playerObserverInfo;

	private RaycasterInfo _defaultInfo;

	private void Awake()
	{
		_defaultInfo = _playerObserverInfo;
	}

	private void FixedUpdate()
	{
		if (Camera.main != null)
		{
			_playerObserverInfo.ShootRay(Camera.main);
		}
	}

	public void ChangeRayInfo(RaycasterInfo info)
	{
		_playerObserverInfo = info;
	}

	public void ReyInfoToDefault()
	{
		_playerObserverInfo = _defaultInfo;
	}
}
