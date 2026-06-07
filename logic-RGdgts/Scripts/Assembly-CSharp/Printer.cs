using System;
using UnityEngine;

public class Printer : MonoBehaviour, ILogOrigin
{
	public enum State
	{
		Idle = 0,
		Printing = 1,
		Destroying = 2
	}

	public struct PrintStatus
	{
		public int printedPixels;

		public int totalPixels;

		public float percentual => 0f;
	}

	public int printerHeight;

	public float printSpeed;

	public float destroySpeed;

	public int fixedHeight;

	public int rotation;

	public Sticker.Position printedStickerPosition;

	public float printedStickerZ;

	public Transform root;

	protected Sticker currentSticker;

	private Action<bool> onPrintComplete;

	private Action<PrintStatus> onPrintProgress;

	private int printingTotalPixels;

	private Action<bool> onDestroyComplete;

	private State state;

	public bool IsIdle => false;

	public Sticker Print(StickerData stickerData, Action<bool> onComplete = null, Action<PrintStatus> onProgress = null)
	{
		return null;
	}

	public void DestroySticker(Action<bool> onDestroyComplete = null)
	{
	}

	public void DetachSticker()
	{
	}

	public void AttachSticker(Sticker sticker)
	{
	}

	public Vector3 GetStickerDestination(Sticker sticker)
	{
		return default(Vector3);
	}

	protected virtual void Update()
	{
	}

	private void UpdateIdle()
	{
	}

	private PrintStatus GetPrintStatus()
	{
		return default(PrintStatus);
	}

	private void UpdatePrinting()
	{
	}

	private void UpdateDestroying()
	{
	}

	protected virtual void OnDestroyComplete(bool result)
	{
	}

	protected virtual void OnPrintComplete(bool result)
	{
	}
}
