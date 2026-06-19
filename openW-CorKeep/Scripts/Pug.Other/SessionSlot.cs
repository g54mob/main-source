using System;
using UnityEngine;

public class SessionSlot : RadicalMenuOption
{
	private const int MAX_WORLD_NAME_LENGTH = 14;

	[SerializeField]
	private PugText _hostName;

	[SerializeField]
	private PugText _worldName;

	[SerializeField]
	private PugText _worldMode;

	[SerializeField]
	private WorldInfoTable _worldInfoTable;

	[SerializeField]
	private SpriteRenderer _worldIcon;

	[SerializeField]
	private PugText _playerCount;

	[SerializeField]
	private SpriteRenderer _selectMarker;

	[SerializeField]
	private Animator _animator;

	private PlatformSession _session;

	private SelectSessionMenu _selectSessionMenu;

	public PlatformSession Session => _session;

	public void Init(PlatformSession session, SelectSessionMenu selectSessionMenu)
	{
		_session = session;
		_selectSessionMenu = selectSessionMenu;
		UpdateHostName(session.FriendInSession);
		if (session.SessionParams != null)
		{
			string text = ((session.SessionParams.WorldName.Length >= 14) ? (session.SessionParams.WorldName.Substring(0, 11) + "...") : session.SessionParams.WorldName);
			_worldName.Render(text, rewindEffectAnims: true);
			_playerCount.Render($"{session.CurrentPlayers}/{session.SessionParams.MaxPlayers}", rewindEffectAnims: true);
			_worldMode.Render(session.SessionParams.WorldMode.ToString() + "Mode", rewindEffectAnims: true);
			_worldMode.SetTempColor(Manager.text.GetModeColor(Mathf.Max(0, (int)session.SessionParams.WorldMode)));
			_worldIcon.sprite = _worldInfoTable.worldIcons[Math.Clamp(session.SessionParams.IconIndex, 0, _worldInfoTable.worldIcons.Count - 1)];
		}
		base.gameObject.SetActive(value: true);
	}

	public override void OnSelected()
	{
		_animator.SetTrigger("active");
		_selectMarker.gameObject.SetActive(value: true);
		_selectSessionMenu?.GetScrollWindow().MoveScrollToIncludePosition(base.transform.localPosition.y, 1f);
		base.OnSelected();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		_animator.SetTrigger("inactive");
		SetAsInactive();
		base.OnDeselected(playEffect);
	}

	public override void OnActivated()
	{
		Manager.networking.OfflineSession = false;
		Manager.networking.JoinSessionDirect(_session.JoinString, checkPrivileges: false);
		base.OnActivated();
	}

	private void UpdateHostName(PlatformUserID userID)
	{
		if (!(Manager.platform.platformImpl is IPlatformUserManager platformUserManager))
		{
			return;
		}
		platformUserManager.GetUserProfile(userID, UserImageSize.None, delegate(UserPlatformProfile profile)
		{
			if (profile != null)
			{
				_hostName.Render(profile.UserName, rewindEffectAnims: true);
			}
		});
	}

	public void SetAsInactive()
	{
		_selectMarker.gameObject.SetActive(value: false);
	}

	public void ResetSelectedOption()
	{
		SetAsInactive();
	}
}
