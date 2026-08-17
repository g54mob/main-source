using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.UI;

public class RandomizeOptionsButtonMobile : MobileConfig
{
	private Button _Fader;

	private PlayerOptions _playerOptions;

	private void Construct(PlayerOptions playerOptions)
	{
		_playerOptions = playerOptions;
	}

	public void Open()
	{
		GameObject gameObject = _Fader.gameObject;
		gameObject.SetActive(value: true);
		Button fader = _Fader;
		UnityAction call = Close;
		fader.m_OnClick.AddListener(call);
	}

	public void Close()
	{
		Button fader = _Fader;
		Button.ButtonClickedEvent onClick = fader.m_OnClick;
		UnityAction unityAction = Close;
		MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
		((UnityEventBase)onClick).m_Calls.RemoveListener(((Delegate)unityAction).m_target, methodImpl);
		GameObject gameObject = _Fader.gameObject;
		gameObject.SetActive(value: false);
	}

	protected override void Apply()
	{
		//IL_0144: Expected O, but got I4
		//IL_0155: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		if (_playerOptions != null)
		{
			PlayerOptions playerOptions = _playerOptions;
			if (playerOptions._003CIsInitialized_003Ek__BackingField && _IsPortrait)
			{
				PlayerOptionsData config = playerOptions.Config;
				bool flag = config.HasCollectedItem(ItemType.RELIC_BANGER);
				PlayerOptionsData config2 = _playerOptions.Config;
				if (config2.HasCollectedItem(ItemType.RELIC_TRISECTION))
				{
					RectTransform component = GetComponent<RectTransform>();
					Vector2 sizeDelta = default(Vector2);
					component.sizeDelta = sizeDelta;
					_ShouldScaleToFitWidth = true;
					_ShouldAnchorPosFromRelativePosition = true;
					_MaxHeightPercentage = 0.1f;
					_ = 1028443341;
					if (!flag)
					{
						_ShouldForceRectTransformSize = flag;
						_RelativeAnchorPosition = (Vector2)1048576000;
						_MaxWidthPercentage = 0.45f;
					}
					else
					{
						_ShouldForceRectTransformSize = true;
						_ForcedSize = (Vector2)1127022592;
						_ = 1121020805;
						_RelativeAnchorPosition = (Vector2)1041385762;
						_MaxWidthPercentage = 0.225f;
					}
				}
			}
		}
		base.Apply();
		if (!_hasInitialized)
		{
			return;
		}
		if (_IsPortrait)
		{
			PlayerOptions playerOptions2 = _playerOptions;
			if (!playerOptions2._003CIsInitialized_003Ek__BackingField)
			{
				return;
			}
			PlayerOptionsData config3 = playerOptions2.Config;
			if (config3.HasCollectedItem(ItemType.RELIC_TRISECTION))
			{
				return;
			}
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	private void SetupValuesBasedOnCollectionState()
	{
		//IL_0144: Expected O, but got I4
		//IL_0155: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		if (_playerOptions == null)
		{
			return;
		}
		PlayerOptions playerOptions = _playerOptions;
		if (!playerOptions._003CIsInitialized_003Ek__BackingField || !_IsPortrait)
		{
			return;
		}
		PlayerOptionsData config = playerOptions.Config;
		bool flag = config.HasCollectedItem(ItemType.RELIC_BANGER);
		PlayerOptionsData config2 = _playerOptions.Config;
		if (config2.HasCollectedItem(ItemType.RELIC_TRISECTION))
		{
			RectTransform component = GetComponent<RectTransform>();
			Vector2 sizeDelta = default(Vector2);
			component.sizeDelta = sizeDelta;
			_ShouldScaleToFitWidth = true;
			_ShouldAnchorPosFromRelativePosition = true;
			_MaxHeightPercentage = 0.1f;
			_ = 1028443341;
			if (!flag)
			{
				_ShouldForceRectTransformSize = flag;
				_RelativeAnchorPosition = (Vector2)1048576000;
				_MaxWidthPercentage = 0.45f;
			}
			else
			{
				_ShouldForceRectTransformSize = true;
				_ForcedSize = (Vector2)1127022592;
				_ = 1121020805;
				_RelativeAnchorPosition = (Vector2)1041385762;
				_MaxWidthPercentage = 0.225f;
			}
		}
	}
}
