using UnityEngine;

public class CameraButtonScript : ImportantObjectClass
{
	public bool TakePictureButton;

	public Vector3 RotateDir;

	public MainComputerController Comp;

	public AudioSource ButtonSound;

	public override void DoInteraction()
	{
		if (TakePictureButton)
		{
			Comp.TakePicture();
			ButtonSound.Play();
		}
		else
		{
			Comp.RotateCam(RotateDir * Comp.RotationAmount);
		}
	}
}
