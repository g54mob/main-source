using System;
using MessagePipe;
using UnityEngine;
using UnityEngine.UI;

public class GnormanHighlighting : MonoBehaviour
{
	[SerializeField]
	private GameObject highlight;

	[SerializeField]
	private Button waitForInteraction;

	[SerializeField]
	private GnormanAction action;

	[SerializeField]
	private int step;

	private IDisposable _subscriptions;

	private void Awake()
	{
		highlight.SetActive(value: false);
		EventHub.Scene.For().Subscribe(HandleGnormanActionStep, Array.Empty<MessageHandlerFilter<GnormanActionStepStarted>>()).Subscribe(delegate
		{
			HandleGnormanDismissed();
		}, Array.Empty<MessageHandlerFilter<GnormanActionFinished>>())
			.Build(this);
	}

	private void OnEnable()
	{
		if (Database.State.Gnorman.Action.Value == action && Database.State.Gnorman.Index.Value == step)
		{
			ShowHighlight();
		}
	}

	private void OnDisable()
	{
		HideHighlight();
	}

	public void Configure(GnormanAction forAction, int forStep)
	{
		action = forAction;
		step = forStep;
	}

	private void HandleGnormanActionStep(GnormanActionStepStarted ctx)
	{
		if (ctx.Action == action && ctx.Step == step)
		{
			ShowHighlight();
		}
		else
		{
			HideHighlight();
		}
	}

	private void HandleGnormanDismissed()
	{
		HideHighlight();
	}

	private void ShowHighlight()
	{
		if (!highlight.activeSelf)
		{
			highlight.SetActive(value: true);
			if ((bool)waitForInteraction)
			{
				waitForInteraction.onClick.AddListener(HandleClick);
			}
		}
	}

	private void HideHighlight()
	{
		if (highlight.activeSelf)
		{
			highlight.SetActive(value: false);
			if ((bool)waitForInteraction)
			{
				waitForInteraction.onClick.RemoveListener(HandleClick);
			}
		}
	}

	private void HandleClick()
	{
		HideHighlight();
		EventHub.Scene.Publish(new GnormanStepPerformed(action, step));
	}
}
