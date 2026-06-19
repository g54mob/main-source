using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraOptionsHelper : MonoBehaviour
{
	private PostProcessLayer postFXRef;

	private void Start()
	{
		postFXRef = GetComponent<PostProcessLayer>();
		SyncPostFX();
	}

	public void SyncPostFX()
	{
		if (postFXRef != null)
		{
			postFXRef.enabled = GameSettings.GetStoredPostFX();
		}
	}
}
