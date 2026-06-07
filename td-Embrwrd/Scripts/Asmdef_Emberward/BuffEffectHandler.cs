using System;
using UnityEngine;

public class BuffEffectHandler : Singleton<BuffEffectHandler>
{
	[SerializeField]
	private LineRenderer lineRenderer_BuffEffect;

	private ABaseBuffSettingData curData;

	private Action buffSuccessCallback;

	private bool isEffectOn;

	private ABaseTower currentPointingTower;

	private Obj_TetrisBlock currentPointingTetrisBlock;

	private AMonsterBase currentPointingMonster;

	private Vector3 currentPointingPosition;

	private Obj_TetrisBlock outlineTetrisBlock;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestGiveBuffToTower(ABaseTower tower, eItemType type, bool isFromPlayer, bool isPlayerAction, int sourceID)
	{
	}

	private void OnRequestGiveBuffToMonster(AMonsterBase monster, eItemType type, bool isFromPlayer, bool isPlayerAction)
	{
	}

	private void OnRequestStartBuffSelection(ABaseBuffSettingData data, Action callback)
	{
	}

	private void OnRequestImmediateBuffCast(ABaseBuffSettingData data, bool isFromPlayer, bool isPlayerAction)
	{
	}

	private void OnConfirmBuffSelection()
	{
	}

	private bool ConfirmBuffProc_Tower()
	{
		return false;
	}

	private bool ConfirmBuffProc_Tetris()
	{
		return false;
	}

	private bool ConfirmBuffProc_Monster()
	{
		return false;
	}

	private bool ConfirmBuffProc_MapArea()
	{
		return false;
	}

	private void OnCancelBuffSelection()
	{
	}

	private ABaseBuffSettingData AddBuffToTower(ABaseBuffSettingData buffData, ABaseTower tower, bool isFromPlayer, bool isPlayerAction, int sourceID)
	{
		return null;
	}

	private void AddBuffToTetris(ABaseBuffSettingData buffData, Obj_TetrisBlock tetris, bool isFromPlayer, bool isPlayerAction)
	{
	}

	private void AddBuffToMonster(ABaseBuffSettingData buffData, AMonsterBase monster, bool isFromPlayer, bool isPlayerAction)
	{
	}

	private void AddBuffToMapArea(ABaseBuffSettingData buffData, Vector3 position, bool isFromPlayer, bool isPlayerAction)
	{
	}

	private void Update()
	{
	}

	private bool CheckIsJoystickOnTower()
	{
		return false;
	}

	private bool CheckIsMouseOnTower()
	{
		return false;
	}

	private bool CheckIsJoystickOnTetris()
	{
		return false;
	}

	private bool CheckIsMouseOnTetris()
	{
		return false;
	}

	private bool CheckIsJoystickOnMonster()
	{
		return false;
	}

	private bool CheckIsMouseOnMonster()
	{
		return false;
	}

	private AMonsterBase GetMostImportantPointedMonster()
	{
		return null;
	}

	public bool IsCurrentBuffRangeRelated()
	{
		return false;
	}

	public float GetModifiedRange(float originalRange)
	{
		return 0f;
	}
}
