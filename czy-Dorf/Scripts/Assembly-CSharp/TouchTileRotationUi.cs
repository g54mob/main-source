using UnityEngine;

public class TouchTileRotationUi : MonoBehaviour
{
	[SerializeField]
	private Canvas canvas;

	private void Start()
	{
		canvas.worldCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
	}
}
