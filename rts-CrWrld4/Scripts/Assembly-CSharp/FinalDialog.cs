using TMPro;
using UnityEngine;

public class FinalDialog : MonoBehaviour
{
	public TextMeshProUGUI titleText;

	public ResultsRow[] resultRows;

	public GameObject columnHeaders0;

	public GameObject columnHeaders1;

	public GameObject leftCol;

	public GameObject rightCol;

	public GameObject playLogContainer;

	public GameObject playLogHiddenContainer;

	public PlayLogPanel playLogPanel;

	public TextMeshProUGUI playLogHiddenContainerText;

	public void OnEnable()
	{
	}

	public void Init(string GUID)
	{
	}

	private void RefreshRows(bool forceShowPlayLog)
	{
	}

	public void OnPlayLogSubmitted(bool val)
	{
	}

	public void OnKeepPlaying()
	{
	}
}
