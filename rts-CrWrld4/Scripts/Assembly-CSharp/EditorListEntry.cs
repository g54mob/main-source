using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EditorListEntry : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public TextMeshProUGUI text;

	public RawImage previewImage;

	public GameObject finalizedArea;

	public TextMeshProUGUI uploadText;

	public Button uploadButton;

	private DirectoryInfo _directory;

	private Texture2D thumbnail;

	private int thumbNailSize;

	public DirectoryInfo directory
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public DirectoryInfo finalizedDirectory => null;

	private void CheckSubmitted()
	{
	}

	public void OnPointerEnter(PointerEventData ped)
	{
	}

	public void OnPointerExit(PointerEventData ped)
	{
	}

	public void OnClick()
	{
	}

	public void PlayButtonClicked()
	{
	}

	public void UploadButtonClicked()
	{
	}

	public void EditButtonClicked()
	{
	}

	public void DeleteButtonClicked()
	{
	}
}
