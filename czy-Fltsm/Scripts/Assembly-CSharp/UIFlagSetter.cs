using PajamaLlama.Utilities;
using UnityEngine;

public class UIFlagSetter : MonoBehaviour, IUIFlagsProvider
{
	public enum ReleaseCondition
	{
		None = 0,
		Delay = 1,
		LeftStickRelease = 2,
		RightStickRelese = 3
	}

	[SerializeField]
	private InputFlags _activeInputs = InputFlags.All;

	[SerializeField]
	private PanelContainerFlags _panelContainerFlags;

	[SerializeField]
	private bool _blockRewired;

	[SerializeField]
	private bool _blockCancel;

	[SerializeField]
	private ReleaseCondition _releaseCondition;

	[SerializeField]
	[ConditionalEnumHide("_releaseCondition", 1, false, HideInInspector = true)]
	private float _delay;

	[SerializeField]
	[ConditionalEnumHide("_releaseCondition", 2, false, EnumValue2 = 3, HideInInspector = true)]
	private float _threshold = 0.1f;

	private bool _isDelayedRelease;

	private float _delayTime;

	public PanelContainerFlags Flags => _panelContainerFlags;

	public bool BlockCancel => _blockCancel;

	private void OnEnable()
	{
		OnActiveInputUpdated();
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
	}

	private void OnDisable()
	{
		if (_releaseCondition == ReleaseCondition.None)
		{
			if (_blockRewired)
			{
				RewiredComponent.Unblock();
			}
			UIManager.RemoveFlagsProvider(this);
		}
		else
		{
			_isDelayedRelease = true;
			_delayTime = 0f - Time.unscaledDeltaTime;
			FinalUpdate.Register(OnUpdateDelay);
		}
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
	}

	private void OnUpdateDelay()
	{
		switch (_releaseCondition)
		{
		case ReleaseCondition.Delay:
			_delayTime += Time.unscaledDeltaTime;
			if (_delay <= _delayTime)
			{
				Release();
			}
			break;
		case ReleaseCondition.LeftStickRelease:
			if (FlotsamInputManager.GetLeftStick().magnitude <= _threshold)
			{
				Release();
			}
			break;
		case ReleaseCondition.RightStickRelese:
			if (FlotsamInputManager.GetRightStick().magnitude <= _threshold)
			{
				Release();
			}
			break;
		}
	}

	private void Release()
	{
		FinalUpdate.Unregister(OnUpdateDelay);
		if (_blockRewired)
		{
			RewiredComponent.Unblock();
		}
		UIManager.RemoveFlagsProvider(this);
		_isDelayedRelease = false;
	}

	private void OnActiveInputUpdated(GameEvent gameEvent = null)
	{
		if (base.isActiveAndEnabled && FlotsamInputManager.HasActiveInput(_activeInputs))
		{
			if (_isDelayedRelease)
			{
				Release();
			}
			if (_blockRewired)
			{
				RewiredComponent.Block();
			}
			if (FlotsamInputManager.HasActiveInput(_activeInputs))
			{
				UIManager.AddFlagsProvider(this);
			}
		}
		else
		{
			Release();
		}
	}
}
