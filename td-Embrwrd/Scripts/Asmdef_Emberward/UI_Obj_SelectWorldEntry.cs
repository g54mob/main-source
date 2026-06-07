using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_SelectWorldEntry : MonoBehaviour
{
	[SerializeField]
	private eWorldType worldType;

	[SerializeField]
	private Image image_Selected;

	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject node_Locked;

	[SerializeField]
	private GameObject node_Unlocked;

	[SerializeField]
	private TMP_Text text_WorldName;

	[SerializeField]
	private TMP_Text text_UnlockRequirement;

	[SerializeField]
	private GameObject node_ClearRecord;

	[SerializeField]
	private GameObject node_InfernalShard;

	[SerializeField]
	private Image image_WorldClearCheckmark;

	[SerializeField]
	private TMP_Text text_InfernalShardLevel;

	private bool isLocked;

	private Action<eWorldType> callbackOnClick;

	private Tweener tween;

	public eWorldType WorldType => default(eWorldType);

	public Button Button => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Setup(bool isLocked, eGameDifficultyType difficultyType, Action<eWorldType> callbackOnClick)
	{
	}

	private void OnClick()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}

	public void SetSelected(bool isSelected)
	{
	}
}
