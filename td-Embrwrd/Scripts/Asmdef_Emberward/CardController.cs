using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class CardController : MonoBehaviour
{
	public enum eCardControllerState
	{
		NORMAL = 0,
		DRAGGING = 1
	}

	public enum eCardAlignType
	{
		CENTER = 0,
		LEFT = 1,
		RIGHT = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_DelayCheckScholarEffect_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CardController _003C_003E4__this;

		private int _003CcurrentCardCount_003E5__2;

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
		public _003CCR_DelayCheckScholarEffect_003Ed__30(int _003C_003E1__state)
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
	private List<AUICard> list_Cards;

	[SerializeField]
	private UI_PlayerDeck ui_PlayerDeck;

	[SerializeField]
	private eCardControllerState state;

	[SerializeField]
	[Header("卡片開始排列的節點")]
	private Transform node_CardStartPoint;

	[SerializeField]
	[Header("卡片結束排列的節點")]
	private Transform node_CardEndPoint;

	[Header("卡片放置節點")]
	[SerializeField]
	private Transform node_CardParent;

	[SerializeField]
	[Header("卡片排列方式")]
	private eCardAlignType cardAlignType;

	[FormerlySerializedAs("cardSpacing")]
	[Header("每張卡片的間距")]
	[SerializeField]
	private float cardSpacing_Horizontal;

	[Header("每張卡片的間距")]
	[SerializeField]
	[FormerlySerializedAs("cardSpacing")]
	private float cardSpacing_Vertical;

	[SerializeField]
	[Header("卡片最大旋轉角度")]
	private float cardMaxRotation;

	[SerializeField]
	private int cardInARow;

	[SerializeField]
	private float maxCardLayoutDistance;

	private float lastScholarEffectCheckTime;

	private Coroutine CR_ScholarEffect;

	private bool isProcessingScholarEffect;

	private AUICard currentPlacementCard;

	private int currentPlacementIndex;

	private AUICard currentMouseOverCard;

	private int currentMouseOverIndex;

	public List<AUICard> List_Cards => null;

	public eCardControllerState State => default(eCardControllerState);

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestDiscardCardFromHand(CardData data)
	{
	}

	private void OnHandCardReplaced(CardData oldData, CardData newData)
	{
	}

	private void OnGameStateChanged(eGameState fromState, eGameState toState)
	{
	}

	private void OnTriggerHandCardVfx_AddRune(CardData data, int slot)
	{
	}

	private void OnAddCardToHand(CardData cardData, Vector3 flyInOriginPosition)
	{
	}

	private void OnCardChanged(List<CardData> cardDataList)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DelayCheckScholarEffect_003Ed__30))]
	private IEnumerator CR_DelayCheckScholarEffect()
	{
		return null;
	}

	private void CharacterEffect_Scholar()
	{
	}

	private AUICard CreateCardUI(CardData cardData)
	{
		return null;
	}

	public void RegisterCard(AUICard card)
	{
	}

	public void UnregisterCard(AUICard card)
	{
	}

	public void SetState(eCardControllerState targetState)
	{
	}

	public bool IsState(eCardControllerState state)
	{
		return false;
	}

	public void SetCurrentPlacementCard(AUICard card)
	{
	}

	public void SetCurrentMouseOverCard(AUICard card)
	{
	}

	public void ClearCurrentMouseOverCard(AUICard card)
	{
	}

	public Vector3 GetCardLocalPositionBySiblingIndex(AUICard card)
	{
		return default(Vector3);
	}

	public Vector3 GetCardLocalRotationBySiblingIndex(AUICard card)
	{
		return default(Vector3);
	}

	public float GetCardSpacing()
	{
		return 0f;
	}

	public AUICard GetNearestCardInRange(AUICard card, float range)
	{
		return null;
	}
}
