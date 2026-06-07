using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ADAMessageLog : MonoBehaviour
{
	public GameObject mapIndicatorLinePrefab;

	public GameObject messageLogRowPrefab;

	public GameObject textBlockPrefab;

	public GameObject imageBlockPrefab;

	public GameObject blocksPanel;

	public GameObject messageContainer;

	public GameObject blocksContainer;

	public GameObject leftPane;

	public GameObject rightPane;

	public GameObject noMessagesText;

	public Toggle autoReveal;

	public GameObject closeButton;

	private string _activeMessage;

	private int hideUIOverrideInitialVal;

	private bool isQuitting;

	private List<MapIndicatorLine> mapIndicators;

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

	public void OnEnable()
	{
	}

	public void OnApplicationQuit()
	{
	}

	public void OnDisable()
	{
	}

	public void Update()
	{
	}

	public void OnToggleAutoReveal(bool val)
	{
	}

	public void SetReveal(bool val)
	{
	}

	public void OnToggleReveal()
	{
	}

	public void DisableGO()
	{
	}

	public void Close()
	{
	}

	public void Show(string key)
	{
	}

	public void OnShowMessage(string key)
	{
	}

	private void Refresh()
	{
	}

	public void RefreshBlocks()
	{
	}

	private void ShowIndicators()
	{
	}

	private void DestroyAllMapIndicators()
	{
	}

	private void UnselectAllMessages()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
