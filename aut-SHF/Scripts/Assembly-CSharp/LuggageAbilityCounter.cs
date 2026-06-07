using System;
using System.Collections.Generic;
using Libs;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class LuggageAbilityCounter : SingletonMonoBehaviour<LuggageAbilityCounter>
{
	[Serializable]
	public class StageCell<T> where T : Enum
	{
		public T id;

		public SideCounterCell cellPrefab;
	}

	public enum SpecialCell
	{
		None = 0,
		SoulOrdealCell = 1
	}

	[Header("Inspector系")]
	[SerializeField]
	private LuggageAblityCell cellPrefab;

	[SerializeField]
	[Tooltip("特殊なステージのCellPrefab")]
	private List<StageCell<eStageId>> stageCellPrefab;

	[SerializeField]
	private List<StageCell<SpecialCell>> specialCellPrefab;

	[SerializeField]
	private RectTransform content;

	[SerializeField]
	private Button button;

	[SerializeField]
	private Image buttonImage;

	[SerializeField]
	private LuggageAbilityDetail luggageAbilityDetail;

	[Header("開閉アニメーションの再生時間")]
	[SerializeField]
	private float playAnimationTime;

	[SerializeField]
	private Sprite closeImage;

	[SerializeField]
	private Sprite openImage;

	private Dictionary<eLuggage, LuggageAblityCell> cellList;

	private List<SideCounterCell> fixedCells;

	private bool isOpenCounter;

	public bool IsOpenCounter
	{
		get
		{
			return false;
		}
		private set
		{
		}
	}

	private void Awake()
	{
	}

	public void Init()
	{
	}

	public void CreateOrUpdateAbilityCell(eLuggage luggage)
	{
	}

	public void UpdateFixedCell(eLuggage luggage)
	{
	}

	public void UpdateAllCell()
	{
	}

	public void ResetAll()
	{
	}

	public void SwitchOpenAll()
	{
	}

	public void OnClickOpenCloseButton()
	{
	}

	public void OnPointerEnterItem(eLuggage luggage)
	{
	}

	public void OnPointerExitItem()
	{
	}

	public void CreateEventCell(eStageId stageId)
	{
	}

	private void CreateSpecialCell()
	{
	}
}
