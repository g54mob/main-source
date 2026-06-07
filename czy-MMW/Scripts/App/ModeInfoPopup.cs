using System;
using Factory;
using JetBrains.Annotations;
using Motorways;
using Popups;
using UnityEngine;
using UnityEngine.UI;

public class ModeInfoPopup : BasePopup
{
	[Dependency]
	protected PopupStack _popupStack;

	[Dependency]
	protected GameCamera _gameCamera;

	[SerializeField]
	protected LocalizedTextUI _headerText;

	[SerializeField]
	protected LocalizedTextUI _info1TitleText;

	[SerializeField]
	protected LocalizedTextUI _info2TitleText;

	[SerializeField]
	protected LocalizedTextUI _info1BodyText;

	[SerializeField]
	protected LocalizedTextUI _info2BodyText;

	[SerializeField]
	private Image _image1;

	[SerializeField]
	private Image _image2;

	[SerializeField]
	private Sprite _endlessSprite1;

	[SerializeField]
	private Sprite _endlessSprite2;

	[SerializeField]
	private Sprite _expertSprite1;

	[SerializeField]
	private Sprite _expertSprite2;

	[SerializeField]
	private Sprite _creativeSprite1;

	[SerializeField]
	private Sprite _creativeSprite2;

	private Action _onConfirmed;

	public void Initialize(IScope scope, GameMode gameMode, Action onConfirmed = null)
	{
		switch (gameMode)
		{
		case GameMode.Endless:
			_headerText.SetStringId(scope, StringId.Endless_Mode_Name);
			_info1TitleText.SetStringId(scope, StringId.ModeInfoPopup_Endless1_Title);
			_info1BodyText.SetStringId(scope, StringId.ModeInfoPopup_Endless1_Body);
			_info2TitleText.SetStringId(scope, StringId.ModeInfoPopup_Endless2_Title);
			_info2BodyText.SetStringId(scope, StringId.ModeInfoPopup_Endless2_Body);
			_image1.sprite = _endlessSprite1;
			_image2.sprite = _endlessSprite2;
			break;
		case GameMode.Expert:
			_headerText.SetStringId(scope, StringId.Expert_Mode_Name);
			_info1TitleText.SetStringId(scope, StringId.ModeInfoPopup_Expert1_Title);
			_info1BodyText.SetStringId(scope, StringId.ModeInfoPopup_Expert1_Body);
			_info2TitleText.SetStringId(scope, StringId.ModeInfoPopup_Expert2_Title);
			_info2BodyText.SetStringId(scope, StringId.ModeInfoPopup_Expert2_Body);
			_image1.sprite = _expertSprite1;
			_image2.sprite = _expertSprite2;
			break;
		case GameMode.Creative:
			_headerText.SetStringId(scope, StringId.Creative_Mode_Name);
			_info1TitleText.SetStringId(scope, StringId.Tutorial_CreativeMode_Info1_Header);
			if (scope.Get<InputState>().CurrentDeviceInputType == DeviceInputType.Mouse)
			{
				_info1BodyText.SetStringId(scope, StringId.Tutorial_CreativeMode_Info1_Body_Mouse);
			}
			else
			{
				_info1BodyText.SetStringId(scope, StringId.Tutorial_CreativeMode_Info1_Body_TouchOrController);
			}
			_info2TitleText.SetStringId(scope, StringId.Tutorial_CreativeMode_Info2_Header);
			_info2BodyText.SetStringId(scope, StringId.Tutorial_CreativeMode_Info2_Body);
			_image1.sprite = _creativeSprite1;
			_image2.sprite = _creativeSprite2;
			break;
		}
		_onConfirmed = onConfirmed;
	}

	public override void OnPopupClosed()
	{
		base.OnPopupClosed();
		_onConfirmed?.Invoke();
	}

	[UsedImplicitly]
	public void ClosePressed()
	{
		_popupStack.PopPopup();
	}

	public override void Reset()
	{
		base.Reset();
	}
}
