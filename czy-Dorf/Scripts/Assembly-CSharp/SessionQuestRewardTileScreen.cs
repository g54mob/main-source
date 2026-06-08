using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SessionQuestRewardTileScreen : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
{
	private sealed class _003CRotateTile_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CRotateTile_003Ed__7(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			if (_003C_003E1__state != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
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
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private float tileRotationSpeed = 90f;

	[SerializeField]
	private float brakingFactor = 0.8f;

	private SessionQuestMenuCard sessionQuestMenuCard;

	private bool rotating;

	private RawImage renderDisplay;

	private float currentDelta;

	public void Setup(SessionQuestMenuCard sessionQuestMenuCard)
	{
		renderDisplay = GetComponent<RawImage>();
		base.name = $"RewardTileScreen_{sessionQuestMenuCard.SessionQuest}";
		this.sessionQuestMenuCard = sessionQuestMenuCard;
	}

	private IEnumerator RotateTile()
	{
		return new _003CRotateTile_003Ed__7(0);
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (sessionQuestMenuCard.QuestState != RewardState.Hidden)
		{
			StartCoroutine(RotateTile());
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		rotating = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void DisplayLevel(int levelIndex)
	{
		renderDisplay.texture = sessionQuestMenuCard.TileViewer.GetRenderTexture(levelIndex);
	}
}
