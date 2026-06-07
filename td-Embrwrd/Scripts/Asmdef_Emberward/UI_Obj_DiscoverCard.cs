using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Obj_DiscoverCard : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[CompilerGenerated]
	private sealed class _003CCo_FlyToTarget_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Obj_DiscoverCard _003C_003E4__this;

		public float duration;

		public Vector3 targetPos;

		private Vector3 _003CstartPos_003E5__2;

		private Vector3 _003CstartScale_003E5__3;

		private float _003Ctimer_003E5__4;

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
		public _003CCo_FlyToTarget_003Ed__23(int _003C_003E1__state)
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
	private UI_CardFace cardFace;

	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject node_InventoryFull;

	[SerializeField]
	private TMP_Text text_ItemName;

	[SerializeField]
	private TMP_Text text_Count;

	[SerializeField]
	private TMP_Text text_Cost;

	[SerializeField]
	private Sprite sprite_QuestionMark;

	[SerializeField]
	private ParticleSystem particle_Clicked;

	[SerializeField]
	private DiscoverRewardData curData;

	private bool isClicked;

	public Action<UI_Obj_DiscoverCard> OnCardClicked;

	public DiscoverRewardData Data => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClickButton()
	{
	}

	public void SetupContent(DiscoverRewardData data)
	{
	}

	public void ToggleCard(bool isOn)
	{
	}

	private void Toggle(bool isOn)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void FlyToTarget(Vector3 targetPos, float duration)
	{
	}

	[IteratorStateMachine(typeof(_003CCo_FlyToTarget_003Ed__23))]
	private IEnumerator Co_FlyToTarget(Vector3 targetPos, float duration)
	{
		return null;
	}
}
