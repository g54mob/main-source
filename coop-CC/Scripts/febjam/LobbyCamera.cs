using Aggro.Core;
using UnityEngine;
using UnityEngine.Rendering;

public class LobbyCamera : AggroManagerBase<LobbyCamera>
{
	public Transform originalTransform;

	public Transform[] playerTargetTransforms;

	public bool zoomIn;

	private int _playerIndex;

	public float camSpeed = 0.5f;

	private Camera _camera;

	public Volume zoomedVolume;

	protected override void OnEntityCreated()
	{
		_camera = GetComponent<Camera>();
	}

	protected override void OnUpdatePresentationEarly()
	{
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			LobbyPlayer lobbyPlayer = player.GetObject<LobbyPlayer>();
			_playerIndex = lobbyPlayer.lobbyPlayerIndex;
		}
		zoomIn = false;
	}

	protected override void OnUpdatePresentation()
	{
		Vector3 b = (zoomIn ? playerTargetTransforms[_playerIndex].position : originalTransform.position);
		Quaternion b2 = (zoomIn ? playerTargetTransforms[_playerIndex].rotation : originalTransform.rotation);
		float b3 = (zoomIn ? 40f : 12f);
		base.transform.position = Vector3.Lerp(base.transform.position, b, camSpeed * Time.deltaTime);
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b2, camSpeed * Time.deltaTime);
		_camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, b3, camSpeed * Time.deltaTime);
		zoomedVolume.weight = Mathf.Lerp(zoomedVolume.weight, zoomIn ? 1 : 0, camSpeed * Time.deltaTime);
	}
}
