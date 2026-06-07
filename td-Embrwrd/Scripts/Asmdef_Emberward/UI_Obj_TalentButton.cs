using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[SelectionBase]
public class UI_Obj_TalentButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
{
	public enum eState
	{
		NOT_INITIALIZED = -1,
		UNAVALIABLE = 0,
		AVALIABLE = 1,
		HALFWAY = 2,
		LEARNED = 3,
		LOCKED = 4
	}

	[CompilerGenerated]
	private sealed class _003CCR_PlaySmallBounceAnimation_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public UI_Obj_TalentButton _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_PlaySmallBounceAnimation_003Ed__59(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private UI_HoldableButton button;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private Image image_Frame;

	[SerializeField]
	private Image image_EnergyFill;

	[SerializeField]
	private Sprite sprite_Frame_Learned;

	[SerializeField]
	private Sprite sprite_Frame_Avaliable;

	[SerializeField]
	private Sprite sprite_Frame_Halfway;

	[SerializeField]
	private Sprite sprite_Frame_Unavaliable;

	[SerializeField]
	private Sprite sprite_Frame_Locked;

	[SerializeField]
	private TMP_Text text_Cost;

	[SerializeField]
	private TMP_Text text_Level;

	[SerializeField]
	private GameObject node_Locked;

	[SerializeField]
	private Transform node_Shake;

	[SerializeField]
	private Transform node_LockInDemoVersion;

	[SerializeField]
	private Color Color_Text_Puchaseable;

	[SerializeField]
	private Color Color_Text_Unpuchaseable;

	[SerializeField]
	private Vector2Int coordintate;

	[SerializeField]
	private eState state;

	private UI_TalentPage_Popup ref_TalentPage;

	private readonly float HOLD_BUTTON_MAX_TIME_NORMAL;

	private readonly float HOLD_BUTTON_MAX_TIME_FAST;

	private float energyFillLevel;

	public Action<UI_Obj_TalentButton, int, TalentSetting, bool> FillFullCallback;

	public Action<UI_Obj_TalentButton> ButtonDownCallback;

	public Action<UI_Obj_TalentButton> ButtonUpCallback;

	public Action<UI_Obj_TalentButton, TalentSetting> ButtonMouseInCallback;

	public Action<UI_Obj_TalentButton> ButtonMouseOutCallback;

	private bool isHoldButton;

	private int index;

	private TalentSetting talentData;

	private bool isSelectedByController;

	private float soundPlayTimer;

	private float buttonPressedTime;

	private Tweener punchPosTween;

	public UI_HoldableButton Button => null;

	public Transform Node_Shake => null;

	public Vector2Int Coordinate
	{
		get
		{
			return default(Vector2Int);
		}
		set
		{
		}
	}

	public eState State => default(eState);

	public int Index => 0;

	public void SetupContent(int index, TalentSetting data, UI_TalentPage_Popup ref_TalentPage)
	{
	}

	private void UpdateText()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnExpChanged(int value)
	{
	}

	public void OnButtonDown()
	{
	}

	public void OnButtonUp()
	{
	}

	private void Update()
	{
	}

	private void OnHoldButton()
	{
	}

	public void PlayLearnTalentAnimation(bool playFullSound)
	{
	}

	public void PlaySmallBounceAnimation(Vector3 origin, float delay)
	{
	}

	public void PlayUnavailableAnimation()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_PlaySmallBounceAnimation_003Ed__59))]
	private IEnumerator CR_PlaySmallBounceAnimation(float delay)
	{
		return null;
	}

	private bool IsLocked()
	{
		return false;
	}

	public void SwitchState(eState targetState)
	{
	}

	public void ToggleButton(bool isOn)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private float GetHoldButtonMaxTime()
	{
		return 0f;
	}

	public void OnSelect(BaseEventData eventData)
	{
	}

	public void OnDeselect(BaseEventData eventData)
	{
	}

	public void OnSubmit(BaseEventData eventData)
	{
	}
}
