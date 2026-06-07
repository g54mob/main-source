using System.IO;
using UnityEngine;

public class CreationThumbnailGenerator : MonoBehaviour
{
	[SerializeField]
	private Camera targetCamera;

	[SerializeField]
	private GameObject creationFolder;

	[SerializeField]
	private GameObject referenceBlock;

	private RenderTexture renderTexture;

	private Rect thumbnailRect;

	private Texture2D thumbnailTexture;

	private CreationView lastCreationView;

	private void Awake()
	{
		renderTexture = targetCamera.targetTexture;
		thumbnailRect = new Rect(0f, 0f, renderTexture.width, renderTexture.height);
		thumbnailTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, mipChain: false);
		referenceBlock.SetActive(value: false);
	}

	private void SetCreationModel(CreationModel creationModel)
	{
		if (creationModel != null)
		{
			if (lastCreationView != null)
			{
				lastCreationView.RecycleAllBlocksBeforeDestroying();
				Object.Destroy(lastCreationView.gameObject);
			}
			CreationController creationController = CreationControllerBuilder.BuildModelController(creationModel, creationFolder.transform);
			GameObject obj = creationController.view.gameObject;
			CreationUtil.NormalizeCreationScale(creationController.view, referenceBlock.transform.localScale.x);
			obj.transform.position = referenceBlock.transform.position;
			obj.transform.rotation = referenceBlock.transform.rotation;
			obj.SetLayersRecursively(LayerNames.Thumbnail);
			lastCreationView = creationController.view;
		}
	}

	public Sprite GenerateThumbnailImage(CreationModel creationModel, string filePathToSave)
	{
		base.gameObject.SetActive(value: true);
		SetCreationModel(creationModel);
		targetCamera.Render();
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = renderTexture;
		thumbnailTexture.ReadPixels(thumbnailRect, 0, 0);
		thumbnailTexture.Apply();
		RenderTexture.active = active;
		base.gameObject.SetActive(value: false);
		if (!string.IsNullOrEmpty(filePathToSave))
		{
			byte[] buffer = thumbnailTexture.EncodeToPNG();
			using (FileStream output = File.Open(filePathToSave, FileMode.Create))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(output))
				{
					binaryWriter.Write(buffer);
				}
			}
		}
		return Sprite.Create(thumbnailTexture, thumbnailRect, new Vector2(0.5f, 0.5f), 100f);
	}
}
