using UnityEngine;

public class HeadCollisionRefresh : MonoBehaviour
{
	public FaceController faceController;

	private void OnEnable()
	{
		faceController.UpdateHeadCollisions();
	}
}
