using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FinalizedListEntry : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public TextMeshProUGUI text;

	public TextMeshProUGUI uploadText;

	public Button uploadButton;

	public RawImage previewImage;

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

	private void CheckSubmitted()
	{
	}

	public void OnClick()
	{
	}

	public void OnPointerEnter(PointerEventData ped)
	{
	}

	public void OnPointerExit(PointerEventData ped)
	{
	}

	public void PlayButtonClicked()
	{
	}

	public void DeleteButtonClicked()
	{
	}

	public void UploadButtonClicked()
	{
	}
}
