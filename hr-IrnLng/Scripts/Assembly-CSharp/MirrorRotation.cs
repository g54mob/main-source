using UnityEngine;

public class MirrorRotation : MonoBehaviour
{
	public Transform MirrorThis;

	public bool MirrorMainCamera;

	private void Start()
	{
		if (MirrorMainCamera)
		{
			MirrorThis = Camera.main.transform;
		}
	}

	private void Update()
	{
		base.transform.eulerAngles = MirrorThis.eulerAngles;
	}
}
