using UnityEngine;
using UnityEngine.UI;

public class ForumMessageController : ActiveComponent
{
	[SceneBind("UserDataField/NameText")]
	private Text nameText;

	[SceneBind("UserDataField/AvatarImage")]
	private Image avatarImage;

	[SceneBind("MessageField/Text")]
	private Text messageText;

	private ForumMessageData messageData;

	private float depthTabSize = 70f;

	private static Color evenColor;

	private static Color oddColor;

	public string Name
	{
		get
		{
			return nameText.text;
		}
		set
		{
			nameText.text = value;
		}
	}

	public string Message
	{
		get
		{
			return messageText.text;
		}
		set
		{
			messageText.text = value;
		}
	}

	public Sprite Avatar
	{
		get
		{
			return avatarImage.sprite;
		}
		set
		{
			avatarImage.sprite = value;
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		evenColor = new Color(74f / 85f, 0.9137255f, 0.9372549f);
		oddColor = new Color(0.8235294f, 0.8980392f, 0.9411765f);
		depthTabSize = 70f;
	}

	public void Init(ForumMessageData messageData)
	{
		base.Init();
		this.messageData = messageData;
		SetData();
		SetDepth();
	}

	public void Init(string messageDataKeyName)
	{
		Init(Logic.GetForumMessageDataByKeyName(messageDataKeyName));
	}

	private void SetData()
	{
		if (messageData.authorKey.ToLower() == "@player")
		{
			Name = ActiveComponent.Model.P.playerUnit.name;
		}
		else
		{
			Name = messageData.Author;
		}
		Message = messageData.Message.Replace("@Player", ActiveComponent.Model.P.playerUnit.name);
		Avatar = messageData.AvatarSprite;
	}

	public void SetDepth()
	{
		Vector2 sizeDelta = base.gameObject.GetComponent<RectTransform>().sizeDelta;
		sizeDelta.x = base.gameObject.transform.parent.parent.parent.GetComponent<RectTransform>().rect.width - depthTabSize * (float)messageData.depth;
		base.gameObject.GetComponent<RectTransform>().sizeDelta = sizeDelta;
		base.gameObject.GetComponent<Image>().color = ((messageData.depth % 2 == 0) ? evenColor : oddColor);
	}
}
