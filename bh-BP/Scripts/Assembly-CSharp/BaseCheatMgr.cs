using System.Collections.Generic;
using UnityEngine;

public class BaseCheatMgr : MonoBehaviour
{
	public static BaseCheatMgr I;

	public bool EnableEditorHarvest;

	public HarvestUpgradeType EditorHarvest;

	public bool EnableEditorTut;

	public BaseTutType EditorTut;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void MyUpdate()
	{
	}

	private void OnLBReceived(List<LBEntry> list)
	{
	}

	public void ApplyCheat(BaseCheatType ct)
	{
	}
}
