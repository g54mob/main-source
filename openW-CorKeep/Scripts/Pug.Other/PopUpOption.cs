using System;
using Pug.UnityExtensions;
using UnityEngine;

public class PopUpOption : RadicalMenuOption
{
	private const float HOLD_TIME_TO_SKIP = 1f;

	[Tooltip("The value pressing this option will send. In most cases, 0 = cancel and 1 = confirm.")]
	[SerializeField]
	private int _optionValue;

	[SerializeField]
	private float _blockAccidentalInputDuration = 1f;

	[SerializeField]
	private GameObject _exitContainer;

	[SerializeField]
	private GameObject _exitMaskBarPivot;

	private TimerSimple? _blockAccidentalInputTimer;

	private bool _isHoldToConfirm;

	private bool _isHoldingToConfirm;

	private float _playerHoldSkipTimer;

	private bool _popsAllMenus;

	public bool PopsAllMenus => _popsAllMenus;

	public event Action<PopUpOption, PopupResponse> PopupOptionActivated;

	public override bool IsSelectionEnabled(bool visualOnly)
	{
		bool flag = base.IsSelectionEnabled(visualOnly);
		bool flag2;
		bool flag3;
		if (flag)
		{
			flag2 = visualOnly;
			if (!flag2)
			{
				TimerSimple? blockAccidentalInputTimer = _blockAccidentalInputTimer;
				if (blockAccidentalInputTimer.HasValue)
				{
					TimerSimple valueOrDefault = blockAccidentalInputTimer.GetValueOrDefault();
					if (!valueOrDefault.isRunning || valueOrDefault.isTimerElapsed)
					{
						flag3 = false;
						goto IL_0042;
					}
				}
				flag3 = true;
				goto IL_0042;
			}
			goto IL_0048;
		}
		goto IL_004a;
		IL_004a:
		return flag;
		IL_0048:
		flag = flag2;
		goto IL_004a;
		IL_0042:
		flag2 = !flag3;
		goto IL_0048;
	}

	private void Start()
	{
		SetHoldingToConfirm(isHoldingToConfirm: false);
	}

	private void OnEnable()
	{
		_blockAccidentalInputTimer = new TimerSimple(_blockAccidentalInputDuration, unscaled: true, startTimer: true);
	}

	public void SetBlockAccidentalInputDuration(float duration)
	{
		_blockAccidentalInputDuration = duration;
	}

	public void SetHoldToConfirm(bool isHoldToConfirm)
	{
		_isHoldToConfirm = isHoldToConfirm;
	}

	public void SetPopsAllMenus(bool popsAllMenus)
	{
		_popsAllMenus = popsAllMenus;
	}

	public void SetHoldingToConfirm(bool isHoldingToConfirm)
	{
		if (!_isHoldingToConfirm)
		{
			_playerHoldSkipTimer = 0f;
		}
		_isHoldingToConfirm = isHoldingToConfirm;
		_exitContainer.SetActive(_isHoldingToConfirm);
	}

	public override void OnActivated()
	{
		if (_isHoldToConfirm)
		{
			SetHoldingToConfirm(isHoldingToConfirm: true);
		}
		else
		{
			Activate();
		}
	}

	public override bool CanBeActivated()
	{
		TimerSimple? blockAccidentalInputTimer = _blockAccidentalInputTimer;
		bool flag;
		if (blockAccidentalInputTimer.HasValue)
		{
			TimerSimple valueOrDefault = blockAccidentalInputTimer.GetValueOrDefault();
			if (!valueOrDefault.isRunning || valueOrDefault.isTimerElapsed)
			{
				flag = false;
				goto IL_0030;
			}
		}
		flag = true;
		goto IL_0030;
		IL_0030:
		if (flag)
		{
			return false;
		}
		return canBeActivated;
	}

	protected override void Update()
	{
		if (_isHoldingToConfirm && (Manager.input.IsMenuInteractButtonPressed() || Manager.input.IsMenuMouseInteractButtonPressed()))
		{
			_playerHoldSkipTimer = Mathf.Clamp(_playerHoldSkipTimer + Time.deltaTime, 0f, 1f);
			if (_playerHoldSkipTimer >= 1f)
			{
				Activate();
			}
		}
		else
		{
			_playerHoldSkipTimer = Mathf.Clamp(_playerHoldSkipTimer - Time.deltaTime, 0f, 1f);
			_isHoldingToConfirm = false;
		}
		if (_playerHoldSkipTimer <= 0f)
		{
			SetHoldingToConfirm(isHoldingToConfirm: false);
		}
		_playerHoldSkipTimer = Mathf.Clamp(_playerHoldSkipTimer, 0f, 1f);
		_exitMaskBarPivot.transform.localScale = new Vector3(_playerHoldSkipTimer / 1f, 1f, 1f);
		base.Update();
	}

	private void Activate()
	{
		TimerSimple? blockAccidentalInputTimer = _blockAccidentalInputTimer;
		bool flag;
		if (blockAccidentalInputTimer.HasValue)
		{
			TimerSimple valueOrDefault = blockAccidentalInputTimer.GetValueOrDefault();
			if (!valueOrDefault.isRunning || valueOrDefault.isTimerElapsed)
			{
				flag = false;
				goto IL_0030;
			}
		}
		flag = true;
		goto IL_0030;
		IL_0030:
		if (!flag)
		{
			_isHoldingToConfirm = false;
			base.OnActivated();
			this.PopupOptionActivated?.Invoke(this, new PopupResponse(_optionValue));
		}
	}
}
