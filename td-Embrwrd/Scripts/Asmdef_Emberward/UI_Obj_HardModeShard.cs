using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[SelectionBase]
public class UI_Obj_HardModeShard : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	[Serializable]
	public class shardTypeToMaterialPair
	{
		public eHardModeShardType shardType;

		public Material material;
	}

	[SerializeField]
	private eHardModeShardType shardType;

	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject node_Content;

	[SerializeField]
	private Image image_Level1;

	[SerializeField]
	private Image image_Level2;

	[SerializeField]
	private Image image_Level3;

	[SerializeField]
	private GameObject node_Outline;

	[SerializeField]
	private Image image_OutlineLevel1;

	[SerializeField]
	private Image image_OutlineLevel2;

	[SerializeField]
	private Image image_OutlineLevel3;

	[SerializeField]
	private GameObject node_Locked;

	[SerializeField]
	private List<shardTypeToMaterialPair> shardTypeToMaterialPairs;

	private Vector3 startPosition;

	private quaternion startRotation;

	private Vector3 startScale;

	private int level;

	private Action<eHardModeShardType, int, UI_Obj_HardModeShard> onClickCallBack;

	private bool isLocked;

	private bool isAvailable;

	public eHardModeShardType ShardType => default(eHardModeShardType);

	public int Level => 0;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}

	private void OnClickButton()
	{
	}

	public void MoveToTarget(Transform targetTransform, float duration, Action onComplete = null)
	{
	}

	public void MoveBackToStart(float duration, Action onComplete = null)
	{
	}

	public void OverrideShardType(eHardModeShardType shardType)
	{
	}

	public void Setup(int level, Action<eHardModeShardType, int, UI_Obj_HardModeShard> onClickCallBack)
	{
	}

	public void SetLocked()
	{
	}

	public void SetLevel(int level)
	{
	}

	public void ToggleActivated(bool isActivated)
	{
	}

	public void ToggleAvailable(bool isAvailable)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnSelect(BaseEventData eventData)
	{
	}

	public void OnDeselect(BaseEventData eventData)
	{
	}
}
