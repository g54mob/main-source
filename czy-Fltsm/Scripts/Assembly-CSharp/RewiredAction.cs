using System;
using I2.Loc;
using PajamaLlama.Utilities;
using Rewired;
using RewiredConsts;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class RewiredAction : IRewiredAction, IRewiredComponent
{
	[ActionIdProperty(typeof(RewiredConsts.Action))]
	[FormerlySerializedAs("Id")]
	[SerializeField]
	private int _id;

	[SerializeField]
	private int _priority;

	[FormerlySerializedAs("Name")]
	[SerializeField]
	private LocalizedString _description;

	[SerializeField]
	private LocalizedString _prefix;

	[FormerlySerializedAs("InputFlags")]
	[Tooltip("The flags used to determine if the action is active (Handles Inputs)")]
	public InputFlags ActiveFlags;

	[Tooltip("The flags used to determin if the action should be displayed in the RewiredActionInfoBar")]
	public InputFlags InfoBarFlags;

	[SerializeField]
	private RewiredActionInfoBarContext _actionInfoBarContext;

	[SerializeField]
	private int _infoBarSortingOrder = 1024;

	private RewiredComponent.Wait _wait;

	private float _clickDownTime;

	public int ActionId => _id;

	public int Priority => _priority;

	public int SortingOrder => _infoBarSortingOrder;

	public LocalizedString Description => _description;

	public LocalizedString Prefix => _prefix;

	public RewiredAction()
	{
	}

	public RewiredAction(int id, LocalizedString description)
	{
		_id = id;
		_description = description;
		ActiveFlags = InputFlags.All;
		InfoBarFlags = InputFlags.All;
	}

	public void ActivateWait(RewiredComponent.Wait wait = RewiredComponent.Wait.None)
	{
		if (wait != RewiredComponent.Wait.None)
		{
			_wait = wait;
		}
		else if (FlotsamInputManager.GetButtonDown(_id))
		{
			_wait = RewiredComponent.Wait.ForUp;
		}
		else
		{
			if (!FlotsamInputManager.GetButtonUp(_id))
			{
				_wait = RewiredComponent.Wait.None;
				return;
			}
			_wait = RewiredComponent.Wait.ForNextFrame;
		}
		FinalUpdate.Register(OnFinalUpdate);
	}

	private void OnFinalUpdate()
	{
		switch (_wait)
		{
		case RewiredComponent.Wait.ForUp:
			if (FlotsamInputManager.GetButtonUp(_id))
			{
				_wait = RewiredComponent.Wait.None;
			}
			break;
		case RewiredComponent.Wait.ForNextFrame:
			_wait = RewiredComponent.Wait.None;
			break;
		case RewiredComponent.Wait.ForUpAndAxisZero:
			if (!FlotsamInputManager.GetButtonDown(_id) && !FlotsamInputManager.GetButton(_id) && !FlotsamInputManager.GetButtonUp(_id) && FlotsamInputManager.GetAxis(_id) == 0f)
			{
				_wait = RewiredComponent.Wait.None;
			}
			break;
		}
		if (_wait == RewiredComponent.Wait.None)
		{
			FinalUpdate.Unregister(OnFinalUpdate);
		}
	}

	private void AddToActionInfoBar()
	{
		if ((bool)_actionInfoBarContext)
		{
			_actionInfoBarContext.AddActions(this);
		}
		else
		{
			UIManager.AddRewiredActionInfo(this);
		}
	}

	private void RemoveFromActionInfoBar()
	{
		if ((bool)_actionInfoBarContext)
		{
			_actionInfoBarContext.RemoveActions(this);
		}
		else
		{
			UIManager.RemoveRewiredActionInfo(this);
		}
	}

	public void Enable()
	{
		RewiredComponent.RegisterRewiredComponent(this);
	}

	public void Disable()
	{
		RewiredComponent.UnregisterRewiredComponent(this);
	}

	public static void AddToActionInfoBar(params RewiredAction[] actions)
	{
		for (int i = 0; i < actions.Length; i++)
		{
			actions[i].AddToActionInfoBar();
		}
	}

	public static void RemoveFromActionInfoBar(params RewiredAction[] actions)
	{
		for (int i = 0; i < actions.Length; i++)
		{
			actions[i].RemoveFromActionInfoBar();
		}
	}

	public float GetAxis()
	{
		if (IsActive())
		{
			return FlotsamInputManager.GetAxis(_id);
		}
		return 0f;
	}

	public float GetAxisRaw()
	{
		if (IsActive())
		{
			return FlotsamInputManager.GetAxis(_id);
		}
		return 0f;
	}

	public bool GetButton()
	{
		if (IsActive())
		{
			return FlotsamInputManager.GetButton(_id);
		}
		return false;
	}

	public bool GetButtonDown()
	{
		if (IsActive())
		{
			return FlotsamInputManager.GetButtonDown(_id);
		}
		return false;
	}

	public bool GetButtonUp()
	{
		if (IsActive())
		{
			return FlotsamInputManager.GetButtonUp(_id);
		}
		return false;
	}

	public bool GetButtonRepeating()
	{
		if (IsActive())
		{
			return FlotsamInputManager.GetButtonRepeating(_id);
		}
		return false;
	}

	public bool GetButtonShortPress()
	{
		if (IsActive())
		{
			return FlotsamInputManager.GetButtonShortPress(_id);
		}
		return false;
	}

	public bool GetButtonDoublePressUp()
	{
		if (IsActive())
		{
			return FlotsamInputManager.GetButtonDoublePressUp(_id);
		}
		return false;
	}

	public bool GetButtonTimedPress(float time)
	{
		if (IsActive())
		{
			return FlotsamInputManager.GetButtonTimedPress(_id, time);
		}
		return false;
	}

	public bool GetButtonClick(float interval = 0.15f)
	{
		if (IsActive())
		{
			if (FlotsamInputManager.GetButtonDown(_id))
			{
				_clickDownTime = Time.unscaledTime;
			}
			else if (FlotsamInputManager.GetButtonUp(_id))
			{
				return Time.unscaledTime - _clickDownTime <= interval;
			}
		}
		return false;
	}

	public bool VisibleInRewiredActionInfoBar()
	{
		return (FlotsamInputManager.ActiveInput & InfoBarFlags) != 0;
	}

	private bool IsActive()
	{
		if (_wait == RewiredComponent.Wait.None)
		{
			return (FlotsamInputManager.ActiveInput & ActiveFlags) != 0;
		}
		return false;
	}
}
