using System.Collections.Generic;
using UnityEngine;

public abstract class AObj_RandomPlacement : MonoBehaviour
{
	public enum eEnableType
	{
		[InspectorName("永遠啟用")]
		Always = 0,
		[InspectorName("正常關限定")]
		NormalOnly = 1,
		[InspectorName("腐化關限定")]
		CorruptedOnly = 2
	}

	[SerializeField]
	protected List<RandomPlacementData> list_RandomPlacementData;

	[SerializeField]
	[Header("是否專屬於腐化場景")]
	protected eEnableType enableType;

	[Header("是否遊戲開始就自動放置")]
	[SerializeField]
	protected bool doAutoPlacementOnStart;

	[SerializeField]
	[Header("是否接收遊戲的隨機放置請求")]
	protected bool doReceiveRandomPlacementRequest;

	protected List<GameObject> list_PlacedObjects;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestStartRandomPlacement()
	{
	}

	public abstract void TriggerRandomPlacement();
}
