using System;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class MyButton : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	public enum EButtonState
	{
		Active,
		Inactive,
		InactiveWithSelection
	}

	protected bool isHovering;

	public Transform scaleOnHover;

	protected Button button;

	public float hoverScale = 1.05f;

	private EButtonState state;

	public GameObject disabledOverlay;

	public AudioClip customSfx;

	protected float selectedAtTime;

	protected void Awake()
	{
		//IL_0025: Expected I, but got O
		Button button = GetButton();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r8_v2 (Il2CppClass<MyButton>)+1B0]");
		UnityAction call = new UnityAction(this, (IntPtr)0);
		nint num = (nint)this;
		button.m_OnClick.AddListener(call);
		Button button2 = GetButton();
		UnityAction call2 = PlaySfx;
		button2.m_OnClick.AddListener(call2);
	}

	public void SetFocus(bool focus)
	{
		Button button = GetButton();
		button.enabled = focus;
		Button button2 = GetButton();
		button2.interactable = focus;
		if (focus)
		{
			RefreshState();
		}
	}

	public void SetInteractable(bool interactable)
	{
		EButtonState eButtonState = (EButtonState)((interactable ? 1 : 0) ^ 1);
		state = eButtonState;
		RefreshState();
	}

	public void SetInteractableButKeepSelectionOn(bool interactable)
	{
		//IL_000e: Expected O, but got I4
		//IL_001b: Expected I4, but got O
		object obj = (interactable ? 1 : 0) ^ 1;
		EButtonState eButtonState = (EButtonState)(obj + obj);
		state = eButtonState;
		RefreshState();
	}

	private void RefreshState()
	{
		//IL_0015: Expected O, but got I4
		bool flag = state == EButtonState.Active;
		if (!flag)
		{
			object obj = state - 1;
			Button button;
			bool flag2;
			if (!flag)
			{
				if ((nint)obj != 1)
				{
					return;
				}
				button = GetButton();
				flag2 = true;
			}
			else
			{
				button = GetButton();
				flag2 = false;
			}
			button.enabled = flag2;
			Button button2 = GetButton();
			button2.interactable = false;
			if (disabledOverlay != null)
			{
				disabledOverlay.SetActive(value: true);
			}
		}
		else
		{
			Button button3 = GetButton();
			button3.enabled = true;
			Button button4 = GetButton();
			button4.interactable = true;
			if (disabledOverlay != null)
			{
				disabledOverlay.SetActive(value: false);
			}
		}
	}

	public void SetDisabledOverlayButKeepInteractable(bool enabled)
	{
		if (disabledOverlay != null)
		{
			disabledOverlay.SetActive(enabled);
		}
	}

	public abstract void StartHover();

	public abstract void StopHover();

	protected abstract void OnClick();

	protected void PlaySfx()
	{
		if (!(customSfx != null))
		{
			AudioManager.Instance.PlayButtonEnter();
		}
		else
		{
			AudioManager.Instance.PlaySfx(customSfx);
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		float time = Time.time;
		selectedAtTime = time;
		ButtonManager.StartedHoveringButton(this);
		if ((object)AudioManager.Instance != null)
		{
			AudioManager.Instance.PlayButtonSelect();
		}
	}

	protected unsafe void Update()
	{
		//IL_00d9: Invalid comparison between I4 and F4
		//IL_00b2: Expected O, but got Ref
		if (scaleOnHover != null)
		{
			Vector3 oneVector = default(Vector3);
			if (isHovering)
			{
				Vector3 localScale = scaleOnHover.localScale;
				oneVector = Vector3.oneVector;
			}
			else
			{
				Vector3 localScale2 = scaleOnHover.localScale;
			}
			float deltaTime = Time.deltaTime;
			float num = deltaTime * 18f;
			if (0f > num || num > 1f)
			{
			}
			scaleOnHover.localScale = (Vector3)(&oneVector);
		}
	}

	public Button GetButton()
	{
		if (button == null)
		{
			Button component = GetComponent<Button>();
			button = component;
		}
		return button;
	}
}
