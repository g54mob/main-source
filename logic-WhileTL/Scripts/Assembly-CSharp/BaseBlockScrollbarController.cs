using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseBlockScrollbarController : ActiveComponent
{
	public Transform blocksContentTransform;

	private GameObject baseLidarBlockPrefab;

	private List<GameObject> objectHoldersList = new List<GameObject>();

	protected override void OnInit()
	{
		base.OnInit();
		baseLidarBlockPrefab = Resources.Load<GameObject>("Prefabs/BaseLidarBlock");
	}

	public override void Init()
	{
		base.Init();
		Clear();
	}

	private void BeginDragAction(PointerEventData eventData)
	{
		DragController component = eventData.pointerDrag.GetComponent<DragController>();
		LidarBlockController component2 = eventData.pointerDrag.GetComponent<LidarBlockController>();
		eventData.pointerDrag = UnityEngine.Object.Instantiate(eventData.pointerDrag, base.transform.parent, worldPositionStays: true);
		eventData.pointerDrag.GetComponent<DragController>().endDragAction = component.endDragAction;
		eventData.pointerDrag.GetComponent<LidarBlockController>().Init(component2.LidarName);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_BlockFromList");
	}

	public void AddObject(GameObject obj, string lidarKeyName, Action<PointerEventData> endDragAction = null)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(baseLidarBlockPrefab, blocksContentTransform);
		obj = UnityEngine.Object.Instantiate(obj, gameObject.transform, worldPositionStays: false);
		obj.GetComponent<LidarBlockController>().Init(lidarKeyName);
		objectHoldersList.Add(gameObject);
		obj.transform.SetAsFirstSibling();
		obj.transform.localPosition = Vector3.zero;
		DragController component = obj.GetComponent<DragController>();
		component.beginDragAction = BeginDragAction;
		component.endDragAction = endDragAction;
	}

	public void Clear()
	{
		objectHoldersList.ForEach(delegate(GameObject x)
		{
			UnityEngine.Object.DestroyObject(x);
		});
		objectHoldersList.Clear();
	}
}
