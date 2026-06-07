using System;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Gnorman : MonoBehaviour, IPointerMoveHandler, IEventSystemHandler
{
	[SerializeField]
	private RectTransform messageRect;

	[SerializeField]
	private LocalizeStringHandler messageHandler;

	[SerializeField]
	private LocalizeStringHandler nextHandler;

	[SerializeField]
	private RectTransform renderTexture;

	[SerializeField]
	private Button nextButton;

	[SerializeField]
	private Button minimizeButton;

	private void Awake()
	{
		Initializer.Context(nextButton).AddListener(HandleNext).Context(minimizeButton)
			.AddListener(Database.Commands.Gnorman.ToggleVisibility)
			.Context(minimizeButton.gameObject)
			.SetInactive()
			.Context(messageRect.gameObject)
			.SetInactive()
			.Context(renderTexture.gameObject)
			.SetInactive()
			.SceneEvents()
			.Subscribe(HandleGnormanActionStart, Array.Empty<MessageHandlerFilter<GnormanActionStarted>>())
			.Subscribe(HandleActionListener, Array.Empty<MessageHandlerFilter<GnormanStepPerformed>>())
			.Build(this);
		Database.State.Gnorman.Visible.SubscribeToSetActive(renderTexture.gameObject).AddTo(this);
	}

	private void Start()
	{
		LoadGnorman();
	}

	public void OnPointerMove(PointerEventData eventData)
	{
		minimizeButton.gameObject.SetActive(!Database.State.Gnorman.InProgress && RectTransformUtility.RectangleContainsScreenPoint(renderTexture, eventData.position, UI.Registry.cameras.main));
	}

	private void LoadGnorman()
	{
		if (Database.State.Gnorman.InProgress)
		{
			messageRect.gameObject.SetActive(value: true);
			renderTexture.gameObject.SetActive(value: true);
			nextButton.gameObject.SetActive(value: true);
			ShowMessage();
		}
	}

	private void HandleGnormanActionStart(GnormanActionStarted ctx)
	{
		if (ctx.Action != GnormanAction.None)
		{
			Database.Commands.Gnorman.Activate(ctx.Action);
			messageRect.gameObject.SetActive(value: true);
			renderTexture.gameObject.SetActive(value: true);
			nextButton.gameObject.SetActive(value: true);
			ShowMessage();
		}
	}

	private void HandleActionListener(GnormanStepPerformed ctx)
	{
		if (Database.State.Studio.Tutorial.Value && (Database.State.Gnorman.Action.Value == ctx.Action || Database.State.Gnorman.Index.Value == ctx.Step))
		{
			HandleNext();
		}
	}

	private void HandleNext()
	{
		if (Database.Commands.Gnorman.MoveNext())
		{
			ShowMessage();
			return;
		}
		messageRect.gameObject.SetActive(value: false);
		Database.Commands.Gnorman.EndAction();
	}

	private void ShowMessage()
	{
		nextHandler.SetValue("hasNext", Database.State.Gnorman.HasNextLine);
		GnormanFluffActionLine currentLine = Database.State.Gnorman.CurrentLine;
		messageHandler.SetLocalizedString(currentLine.message);
		if (currentLine.animation != GnormanAnimation.None)
		{
			Database.State.Gnorman.Animation.Value = currentLine.animation;
		}
		if (currentLine.playSfx)
		{
			Audio.PlaySfx(currentLine.sfx);
		}
		if (Database.State.Gnorman.Action.Value.IsTutorial())
		{
			HandleTutorialMessage();
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(messageRect);
	}

	private void HandleTutorialMessage()
	{
		nextButton.gameObject.SetActive(!Database.State.Gnorman.CurrentTutorialLine.listenToEvent);
		EventHub.Scene.Publish(new GnormanActionStepStarted(Database.State.Gnorman.Action.Value, Database.State.Gnorman.Index.Value));
	}

	private void Force(GnormanAction action)
	{
		HandleGnormanActionStart(new GnormanActionStarted(action));
	}
}
