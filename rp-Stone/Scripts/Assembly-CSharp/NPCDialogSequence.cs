using System;
using System.Collections.Generic;

public class NPCDialogSequence
{
	public class StepReturnData
	{
		public bool hasEnded;

		public AsciiAnimation animation;

		public string message;
	}

	private Queue<AsciiAnimation> animationQueue = new Queue<AsciiAnimation>();

	private Queue<string> sfxQueue = new Queue<string>();

	private Queue<string> dialogQueue = new Queue<string>();

	private Queue<Action> callbackQueue = new Queue<Action>();

	private Sfx currentSfx;

	public int Count => dialogQueue.Count;

	public StepReturnData Next()
	{
		StepReturnData stepReturnData = new StepReturnData();
		if (dialogQueue.Count <= 0)
		{
			stepReturnData.hasEnded = true;
			return stepReturnData;
		}
		stepReturnData.animation = animationQueue.Dequeue();
		string text = sfxQueue.Dequeue();
		if (text != null)
		{
			PlaySFX(text);
		}
		stepReturnData.message = dialogQueue.Dequeue();
		if (stepReturnData.message != null && stepReturnData.message.StartsWith("tid_"))
		{
			stepReturnData.message = Te.xt(stepReturnData.message);
		}
		callbackQueue.Dequeue()?.Invoke();
		return stepReturnData;
	}

	public void Clear()
	{
		animationQueue.Clear();
		sfxQueue.Clear();
		dialogQueue.Clear();
		callbackQueue.Clear();
	}

	public void Add(AsciiAnimation anm, string sfxId = null, string dialogMessage = null, Action callback = null)
	{
		animationQueue.Enqueue(anm);
		sfxQueue.Enqueue(sfxId);
		dialogQueue.Enqueue(dialogMessage);
		callbackQueue.Enqueue(callback);
	}

	public void Add(string dialogMessage, Action callback = null)
	{
		animationQueue.Enqueue(null);
		sfxQueue.Enqueue(null);
		dialogQueue.Enqueue(dialogMessage);
		callbackQueue.Enqueue(callback);
	}

	public void Add(string sfxId, string dialogMessage, Action callback = null)
	{
		animationQueue.Enqueue(null);
		sfxQueue.Enqueue(sfxId);
		dialogQueue.Enqueue(dialogMessage);
		callbackQueue.Enqueue(callback);
	}

	public void AddCallback(Action callback)
	{
		animationQueue.Enqueue(null);
		sfxQueue.Enqueue(null);
		dialogQueue.Enqueue(null);
		callbackQueue.Enqueue(callback);
	}

	private void PlaySFX(string sfxName)
	{
		if (currentSfx != null)
		{
			currentSfx.Stop();
		}
		currentSfx = SfxController.singleton.Play(sfxName);
	}
}
