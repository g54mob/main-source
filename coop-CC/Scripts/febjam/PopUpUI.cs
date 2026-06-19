using Aggro.Core;
using UnityEngine;
using UnityEngine.UI;

public class PopUpUI : EntityBehaviourBase, IInputController
{
	public Transform popUpTransform;

	public Image acknowledgementImage;

	public EasingFunction.Ease ease;

	public float easeSpeed = 5f;

	public float acknowledgementHoldTimeSec = 1f;

	private float _acknowledgementHoldTimer;

	private float _scale;

	private bool isOpen;

	public void TestOpen()
	{
		AggroInputManager.PushController(this);
	}

	public void Open()
	{
		isOpen = true;
	}

	public void TriggerPopUp()
	{
		AggroInputManager.PushController(this);
	}

	public void close()
	{
		isOpen = false;
	}

	protected override void OnUpdatePresentation()
	{
		if (AggroInputManager.input.PopUp.Close.IsPressed())
		{
			acknowledgementImage.gameObject.SetActive(value: true);
			acknowledgementImage.fillAmount = _acknowledgementHoldTimer / acknowledgementHoldTimeSec;
			_acknowledgementHoldTimer += Time.deltaTime;
			if (_acknowledgementHoldTimer > acknowledgementHoldTimeSec)
			{
				AggroInputManager.RemoveController(this);
				close();
			}
		}
		else
		{
			acknowledgementImage.gameObject.SetActive(value: false);
			_acknowledgementHoldTimer = 0f;
		}
		float num = (isOpen ? 1f : (-1f));
		_scale += num * easeSpeed * Time.deltaTime;
		_scale = Mathf.Clamp01(_scale);
		float num2 = EasingFunction.Evaluate(ease, _scale);
		popUpTransform.localScale = Vector3.one * num2;
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.PopUp.Enable();
		Open();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.PopUp.Disable();
		close();
	}
}
