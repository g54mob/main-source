using Libs;
using TMPro;
using UnityEngine;

public class DebugDetailUnitWindow : SingletonMonoBehaviour<DebugDetailUnitWindow>
{
	[SerializeField]
	private GameObject window;

	[SerializeField]
	private TMP_Text bufftext;

	[SerializeField]
	private GameObject detailWindow;

	[SerializeField]
	private TMP_Text detailText;

	private bool _isOpenWindow;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void SwitchDisplayWindow(bool on, string displayText = null)
	{
	}

	public void SetDetail(string detailLog)
	{
	}

	public void CloseDetailWindow()
	{
	}
}
