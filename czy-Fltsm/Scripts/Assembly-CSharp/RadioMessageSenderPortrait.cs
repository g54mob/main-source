using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class RadioMessageSenderPortrait : SceneBehaviour
{
	[SerializeField]
	private OutlinedImage _senderImage;

	[SerializeField]
	private TMP_Text _nameLabel;

	[SerializeField]
	private Color _selectedColor = Color.white;

	public UnityAction<RadioMessageSenderPortrait> OnRead;

	private AgentDescriptor _sender;

	public RadioMessage Message { get; private set; }

	public void Initialize(RadioMessage message)
	{
		Message = message;
		if (message != null)
		{
			_sender = message.Sender;
			_nameLabel.text = _sender.Name;
			if (PortraitGenerator.HasStaticPortrait(_sender))
			{
				UpdatePortrait();
			}
			else
			{
				GameEventDispatcher.AddListener(GameEventType.AgentPortraitGenerated, UpdatePortrait);
			}
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentPortraitGenerated, UpdatePortrait);
	}

	public void OpenMessage()
	{
		Debug.Log(new NotImplementedException());
	}

	public void Select()
	{
		_senderImage.OverrideOutlineColor(_selectedColor);
	}

	public void Deselect()
	{
		_senderImage.RestoreOutlineColor();
	}

	private void UpdatePortrait(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent && agentEvent.AgentDescriptor == _sender)
		{
			UpdatePortrait();
			GameEventDispatcher.RemoveListener(GameEventType.AgentPortraitGenerated, UpdatePortrait);
		}
	}

	private void UpdatePortrait()
	{
		_senderImage.Initialize(PortraitGenerator.ReturnStaticPortrait(_sender));
	}
}
