using System.Collections.Generic;
using UnityEngine;

public class PhotoCameraController : MonoBehaviour
{
	[SerializeField]
	private Camera cam;

	[SerializeField]
	private List<RenderTexture> list_Photos;

	[SerializeField]
	private Vector2Int renderTextureSize;

	private void Reset()
	{
	}

	public void TakePhoto()
	{
	}

	public bool DoHavePhoto(int index)
	{
		return false;
	}

	public int GetPhotoCount()
	{
		return 0;
	}

	public RenderTexture GetLatestPhoto()
	{
		return null;
	}

	public RenderTexture GetPhoto(int index)
	{
		return null;
	}

	public void ClearPhotos()
	{
	}
}
