using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : CTSBehaviour
{
	[SerializeField]
	private SimpleAction _action;

	[InjectScope(EGetScope.Children)]
	[SerializeField]
	[Inject(false)]
	private Button _button;

	public event Action<ActionButton> Stopped;

	public event Action<ActionButton> Started;

	protected override void OnAwake()
	{
		base.OnAwake();
		_action = GetComponent<SimpleAction>();
	}

	public void QuickPlay()
	{
		OnButtonClicked();
	}

	private void StartAction()
	{
		if (!_action.enabled)
		{
			this.Started?.Invoke(this);
			_action.StartAction();
		}
	}

	public void EndAction()
	{
		if (_action.enabled)
		{
			_action.EndAction();
			this.Stopped?.Invoke(this);
		}
	}

	protected override void OnEnabled()
	{
		base.OnEnabled();
		if ((bool)_button)
		{
			_button.onClick.AddListener(OnButtonClicked);
		}
		_action.Stopped += OnActionStopped;
	}

	private void OnButtonClicked()
	{
		StartAction();
	}

	protected override void OnDisabled()
	{
		base.OnDisabled();
		if ((bool)_button)
		{
			_button.onClick.RemoveListener(OnButtonClicked);
		}
		_action.Stopped -= OnActionStopped;
	}

	private void OnActionStopped(SimpleAction button)
	{
		this.Stopped?.Invoke(this);
	}
}
