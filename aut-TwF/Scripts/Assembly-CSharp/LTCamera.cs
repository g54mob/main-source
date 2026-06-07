using UnityEngine;

public class LTCamera : IsometricCamera
{
	[Header("LT Camera")]
	[SerializeField]
	private GameObject audioListenerObject;

	private ShakeCameraController shakeCameraController;

	public ShakeCameraController ShakeCameraController
	{
		get
		{
			return shakeCameraController;
		}
		set
		{
			shakeCameraController = value;
		}
	}

	protected override void InitCamera()
	{
		base.InitCamera();
		ShakeCameraController = base.OwnCamera.GetComponent<ShakeCameraController>();
	}

	protected override void Update()
	{
		base.Update();
		UpdateAudioListenerPosition();
	}

	private void UpdateAudioListenerPosition()
	{
		if (Physics.Raycast(ownCamera.transform.position, ownCamera.transform.forward, out var hitInfo, 200f, LayerMask.GetMask("Ground")))
		{
			audioListenerObject.transform.position = ownCamera.transform.position + (hitInfo.point - ownCamera.transform.position) * 0.4f;
		}
	}
}
