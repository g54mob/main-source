using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InstructionSlotBase : MonoBehaviour, IRecyclableObject
{
	private Button deleteButton;

	private InstructionSlotDragHandler instructionSlotDrag;

	private List<Image> slotImages;

	private CanvasGroup canvasGroup;

	private WaitForEndOfFrame waitForEndOfFrame;

	public string ObjectTypeId { get; set; }

	public event Action OnInstructionDeleteEvent;

	public event Action<bool> OnSlotBeginOrEndDragEvent;

	public event Action<int, int, InstructionDropZone> OnInstructionEndDragEvent;

	protected virtual void Awake()
	{
		deleteButton = base.transform.FindComponent<Button>("DeleteButton", isRecursively: true);
		instructionSlotDrag = base.transform.GetComponentInChildren<InstructionSlotDragHandler>(includeInactive: true);
		canvasGroup = GetComponent<CanvasGroup>();
		deleteButton.onClick.AddListener(delegate
		{
			this.OnInstructionDeleteEvent?.Invoke();
		});
		instructionSlotDrag.OnBeginDragEvent += delegate
		{
			this.OnSlotBeginOrEndDragEvent?.Invoke(obj: true);
		};
		instructionSlotDrag.OnEndDragEvent += delegate
		{
			this.OnSlotBeginOrEndDragEvent?.Invoke(obj: false);
		};
		instructionSlotDrag.OnInstructionEndDragEvent += delegate(int oldIndex, int newIndex, InstructionDropZone dropZone)
		{
			this.OnInstructionEndDragEvent?.Invoke(oldIndex, newIndex, dropZone);
		};
		slotImages = new List<Image>();
		Image[] componentsInChildren = base.transform.GetComponentsInChildren<Image>(includeInactive: true);
		foreach (Image image in componentsInChildren)
		{
			if (!(image.color != Util.HexToColor("#212224FF")))
			{
				slotImages.Add(image);
			}
		}
		waitForEndOfFrame = new WaitForEndOfFrame();
	}

	public void BlinkSlot()
	{
		canvasGroup.alpha = 0f;
		StartCoroutine(BlinkSlotUpdate());
		IEnumerator BlinkSlotUpdate()
		{
			while (canvasGroup.alpha < 1f)
			{
				canvasGroup.alpha += Time.deltaTime * 4f;
				yield return waitForEndOfFrame;
			}
		}
	}

	public void SetSlotHighlight(bool isHighlighted)
	{
		for (int i = 0; i < slotImages.Count; i++)
		{
			slotImages[i].color = (isHighlighted ? Util.HexToColor("#323335FF") : Util.HexToColor("#212224FF"));
		}
	}

	public abstract Instruction GetInstruction();

	public virtual void OnInstantiation()
	{
	}

	public virtual void OnUnistantiation()
	{
		this.OnInstructionDeleteEvent = null;
		this.OnSlotBeginOrEndDragEvent = null;
		this.OnInstructionEndDragEvent = null;
	}
}
