using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ADAMessageEditor : MonoBehaviour
{
	public GameObject messageRowPrefab;

	public GameObject textBlockPrefab;

	public GameObject imageBlockPrefab;

	public InputField addMessageKeyInputField;

	public GameObject addDialog;

	public GameObject editDialog;

	public GameObject blocksPanel;

	public GameObject infoContainer;

	public TMP_Text infoText;

	public GameObject messageContainer;

	public GameObject blocksContainer;

	private string _activeMessage;

	private string activeMessage
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void UnselectAllMessages()
	{
	}

	public void DumpAll()
	{
	}

	public void OnEnable()
	{
	}

	public void ShowInfo(string text)
	{
	}

	public void Refresh()
	{
	}

	public void RefreshBlocks()
	{
	}

	public void OnShowMessage(string key)
	{
	}

	public void OnAddMessage()
	{
	}

	public void OnDeleteMessage(string key)
	{
	}

	public void OnEditMessage(string key)
	{
	}

	public void OnAddTextBlock()
	{
	}

	public void OnAddImageBlock()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
