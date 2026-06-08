using LeTai.Asset.TranslucentImage;
using UnityEngine;

[RequireComponent(typeof(TranslucentImage))]
public class TranslucentImageSourceAssigner : MonoBehaviour
{
	private TranslucentImage translucentImage;

	private void Awake()
	{
		translucentImage = GetComponent<TranslucentImage>();
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			ChangeScene(OverwritingSingleton<IngameUi>.Instance);
		}
		IngameUi.OnSceneChanged += ChangeScene;
	}

	private void ChangeScene(IngameUi newIngameUi)
	{
		translucentImage.source = newIngameUi.translucentImageSource;
	}
}
