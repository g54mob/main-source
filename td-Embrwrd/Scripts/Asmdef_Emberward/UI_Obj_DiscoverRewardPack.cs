using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Obj_DiscoverRewardPack : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public enum eJoystickSelectType
	{
		SELECT_CARD = 0,
		SELECT_PACK = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_ShowProc_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Obj_DiscoverRewardPack _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CCR_ShowProc_003Ed__34(int _003C_003E1__state)
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
	private Image image_Frame_Selected;

	[SerializeField]
	private Image image_Black_Foreground;

	[SerializeField]
	private Button button;

	[SerializeField]
	private Transform node_Anchors;

	[SerializeField]
	private List<Transform> nodes_CardAnchor_1;

	[SerializeField]
	private List<Transform> nodes_CardAnchor_2;

	[SerializeField]
	private List<Transform> nodes_CardAnchor_3;

	[SerializeField]
	private List<Transform> nodes_CardAnchor_4;

	[SerializeField]
	private List<Transform> nodes_CardAnchor_5;

	[SerializeField]
	private List<Transform> nodes_CardAnchor_6;

	[SerializeField]
	private List<GameObject> list_Chains;

	[SerializeField]
	private Image image_Unknown;

	[SerializeField]
	private List<UI_Obj_ShopCard> list_CreatedCards;

	private DiscoverRewardPack rewardPackData;

	[SerializeField]
	private int curChainIndex;

	private eJoystickSelectType joystickSelectType;

	private bool isSelectOutlineOn;

	public Button Button => null;

	public List<UI_Obj_ShopCard> List_CreatedCards => null;

	public event Action<UI_Obj_DiscoverRewardPack, DiscoverRewardPack, List<Vector3>> OnCardClicked
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClickButton()
	{
	}

	private void Update()
	{
	}

	public void SetupContent(DiscoverRewardPack rewardPackData)
	{
	}

	private void OnCardClickedCallback(UI_Obj_ShopCard card)
	{
	}

	private void CardClickedProc()
	{
	}

	public List<Transform> GetCardAnchorsByCardCount(int cardCount)
	{
		return null;
	}

	public void Toggle(bool isOn)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowProc_003Ed__34))]
	private IEnumerator CR_ShowProc()
	{
		return null;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void ToggleChains(int index, bool isOn)
	{
	}

	public void ToggleShowUnknown(bool isOn)
	{
	}

	public void SetJoystickSelectType(eJoystickSelectType selectType)
	{
	}

	public void PlaySelectedAnim()
	{
	}

	public void PlayShineAnim()
	{
	}

	public void ToggleBlackForeground(bool isOn)
	{
	}

	public void ToggleSelectedEffect(bool isOn)
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}
}
