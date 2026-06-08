using UnityEngine;

public class DungeonManagerGUI : MonoBehaviour
{
	public static DungeonManagerGUI Instance;

	public ShipsLogsWindow _shipsLogWindow { get; set; }

	public DerelictStatisticsWindow derelictStatisticsWindow { get; set; }

	public AliasFileEditor aliasFileEditor { get; set; }

	public bool isShowingDerelictStatisticsWindow { get; set; }

	private void Awake()
	{
		Instance = this;
		Disable();
	}

	private void OnGUI()
	{
		if (!DialogUI.Instance.IsShowing && aliasFileEditor != null)
		{
			aliasFileEditor.ShowWindow();
		}
	}

	public void Enable()
	{
		base.enabled = true;
	}

	public void Disable()
	{
		base.enabled = false;
	}
}
