using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IRCLine : MonoBehaviour, IPoolRentListener
{
	[Serializable]
	public struct Formatting
	{
		public bool showBackground;

		public int spacing;

		public string divider;

		public Color color;

		public float usernameWidth;

		public float dividerWidth;

		public float messageWidth;
	}

	[SerializeField]
	private RectTransform root;

	[SerializeField]
	private TMP_Text usernameText;

	[SerializeField]
	private TMP_Text dividerText;

	[SerializeField]
	private TMP_Text messageText;

	[SerializeField]
	private Image background;

	[SerializeField]
	private HorizontalLayoutGroup layout;

	[SerializeField]
	private Formatting standardFormat;

	[SerializeField]
	private Formatting systemFormat;

	public void SetContent(IRCMessage message)
	{
		Format(message.Channel.HasFlag(IRCChannel.System) ? systemFormat : standardFormat);
		usernameText.text = message.Username;
		usernameText.color = message.Color;
		messageText.text = message.Message;
		messageText.ForceMeshUpdate();
		LayoutRebuilder.ForceRebuildLayoutImmediate(root);
	}

	private void Format(Formatting format)
	{
		background.enabled = format.showBackground;
		layout.spacing = format.spacing;
		usernameText.rectTransform.sizeDelta = new Vector2(format.usernameWidth, usernameText.rectTransform.sizeDelta.y);
		dividerText.rectTransform.sizeDelta = new Vector2(format.dividerWidth, dividerText.rectTransform.sizeDelta.y);
		dividerText.color = format.color;
		dividerText.text = format.divider;
		messageText.rectTransform.sizeDelta = new Vector2(format.messageWidth, messageText.rectTransform.sizeDelta.y);
		messageText.color = format.color;
	}

	public void OnRent()
	{
		base.transform.SetAsLastSibling();
	}
}
