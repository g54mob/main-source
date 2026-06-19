using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ChatMessageItem : MonoBehaviour
	{
		[SerializeField]
		private Image _background;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private TMP_Text _messageLabel;

		[SerializeField]
		private TMP_Text _timeStampLabel;

		[SerializeField]
		private PlayerAvatar _avatar;

		[SerializeField]
		private Image _avatarSideIcon;

		[SerializeField]
		private Color _chatBackgroundColor;

		[SerializeField]
		private Color _chatFontColor;

		[SerializeField]
		private Color _eventBackgroundColor;

		[SerializeField]
		private Color _eventFontColor;

		[SerializeField]
		private Color _startBackgroundColor;

		[SerializeField]
		private Color _startFontColor;

		[SerializeField]
		private Color _nodeCompletedBackgroundColor;

		[SerializeField]
		private Color _nodeCompletedFontColor;

		[SerializeField]
		private Color _victoryNodeCompletedBackgroundColor;

		[SerializeField]
		private Color _victoryNodeCompletedFontColor;

		[SerializeField]
		private Color _npcChatBackgroundColor;

		[SerializeField]
		private Color _npcChatFontColor;

		[SerializeField]
		private Color _playerJoinedBackgroundColor;

		[SerializeField]
		private Color _playedJoinedFontColor;

		[SerializeField]
		private Color _playerLeftKickedBackgroundColor;

		[SerializeField]
		private Color _playerLeftKickedFontColor;

		[SerializeField]
		private Sprite _acceptedInviteIcon;

		[SerializeField]
		private Sprite _rejectedInviteIcon;

		[SerializeField]
		private Sprite _startedTaskIcon;

		[SerializeField]
		private Sprite _completedTaskIcon;

		[SerializeField]
		private Sprite _completedVictoryTaskIcon;

		public OnlinePlayerID PlayerID { get; private set; }

		public void Setup(CollaborativeProject.ChatMessage chatMessage)
		{
			if (chatMessage.Type == CollaborativeProject.ChatMessageType.EventNPCChat)
			{
				_name.text = chatMessage.Name;
				_messageLabel.text = chatMessage.Message;
				_messageLabel.fontStyle = FontStyles.Normal;
				_messageLabel.color = _npcChatFontColor;
				_avatar.OverrideSprite = chatMessage.Icon;
				_background.color = _npcChatBackgroundColor;
				_timeStampLabel.text = string.Empty;
				GameObjectUtils.SetActive(_avatarSideIcon.gameObject, isActive: false);
				PlayerID = OnlinePlayerID.Nil;
				return;
			}
			PlayerID = chatMessage.PlayerID;
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(PlayerID);
			_timeStampLabel.text = StringUtils.FormatTimeSpan(OnlineManager.GetServerTime() - chatMessage.Timestamp);
			_name.text = ((PlayerID != OnlinePlayerID.Nil && playerInfo != null) ? playerInfo.DisplayName : ScriptLocalization.Misc.Unknown_CS);
			_messageLabel.text = chatMessage.Message.Truncate(CollaborativeProject.ChatCharacterLimit);
			_avatar.PlayerID = PlayerID;
			if (chatMessage.Type == CollaborativeProject.ChatMessageType.Chat)
			{
				_messageLabel.fontStyle = FontStyles.Normal;
				_messageLabel.color = _chatFontColor;
				_background.color = _chatBackgroundColor;
				_avatarSideIcon.overrideSprite = OnlineManager.DefaultAvatarSprite;
				GameObjectUtils.SetActive(_avatarSideIcon.gameObject, isActive: false);
				return;
			}
			if (chatMessage.Type == CollaborativeProject.ChatMessageType.EventAcceptedInvite)
			{
				_avatarSideIcon.overrideSprite = _acceptedInviteIcon;
				_messageLabel.color = _playedJoinedFontColor;
				_background.color = _playerJoinedBackgroundColor;
				GameObjectUtils.SetActive(_avatarSideIcon.gameObject, isActive: true);
			}
			else if (chatMessage.Type == CollaborativeProject.ChatMessageType.EventRejectedInvite)
			{
				_avatarSideIcon.overrideSprite = _rejectedInviteIcon;
				_messageLabel.color = _playerLeftKickedFontColor;
				_background.color = _playerLeftKickedBackgroundColor;
				GameObjectUtils.SetActive(_avatarSideIcon.gameObject, isActive: true);
			}
			else if (chatMessage.Type == CollaborativeProject.ChatMessageType.EventStartTask)
			{
				_avatarSideIcon.overrideSprite = _startedTaskIcon;
				_messageLabel.color = _startFontColor;
				_background.color = _startBackgroundColor;
				GameObjectUtils.SetActive(_avatarSideIcon.gameObject, isActive: true);
			}
			else if (chatMessage.Type == CollaborativeProject.ChatMessageType.EventCompletedTask)
			{
				_avatarSideIcon.overrideSprite = _completedTaskIcon;
				_messageLabel.color = _nodeCompletedFontColor;
				_background.color = _nodeCompletedBackgroundColor;
				GameObjectUtils.SetActive(_avatarSideIcon.gameObject, isActive: true);
			}
			else if (chatMessage.Type == CollaborativeProject.ChatMessageType.EventCompletedVictoryTask)
			{
				_avatarSideIcon.overrideSprite = _completedVictoryTaskIcon;
				_messageLabel.color = _victoryNodeCompletedFontColor;
				_background.color = _victoryNodeCompletedBackgroundColor;
				GameObjectUtils.SetActive(_avatarSideIcon.gameObject, isActive: true);
			}
			_messageLabel.fontStyle = FontStyles.Italic;
			_messageLabel.color = _eventFontColor;
			_background.color = _eventBackgroundColor;
		}
	}
}
