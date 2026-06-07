using System;
using UnityEngine;
using UnityEngine.UI;

public class IRCTab : MonoBehaviour
{
	[SerializeField]
	private IRCChannel channel;

	[SerializeField]
	private Button tabButton;

	[SerializeField]
	private Image tabImage;

	[SerializeField]
	private Sprite tabActive;

	[SerializeField]
	private Sprite tabInactive;

	public IRCChannel Channels => channel;

	public event Action<IRCTab> ChangeChannel;

	private void Awake()
	{
		tabButton.onClick.AddListener(delegate
		{
			this.ChangeChannel?.Invoke(this);
		});
	}

	public void SetActive()
	{
		tabImage.sprite = tabActive;
	}

	public void SetInactive()
	{
		tabImage.sprite = tabInactive;
	}
}
