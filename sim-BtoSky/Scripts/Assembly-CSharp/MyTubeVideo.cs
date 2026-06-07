using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyTubeVideo : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI vidName;

	[SerializeField]
	private TextMeshProUGUI scoreText;

	public RawImage vidImage;

	public int vidIndex;

	public float vidScore;

	public string vidUrl;

	public string thumbnailUrl;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void VidCreated()
	{
		LoadThumbnail(thumbnailUrl);
		vidName.text = $"Flight {vidIndex}";
	}

	public void LoadThumbnail(string filePath)
	{
		if (!File.Exists(filePath))
		{
			Debug.LogWarning("썸네일 파일이 없습니다: " + filePath);
			return;
		}
		byte[] data = File.ReadAllBytes(filePath);
		Texture2D texture2D = new Texture2D(2, 2);
		texture2D.LoadImage(data);
		if (vidImage.texture != null)
		{
			Object.Destroy(vidImage.texture);
		}
		vidImage.texture = texture2D;
		vidImage.gameObject.SetActive(value: true);
	}

	public void DeleteVideo()
	{
		File.Delete(thumbnailUrl);
		File.Delete(vidUrl);
		Object.Destroy(base.gameObject);
	}
}
