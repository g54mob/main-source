using System;
using System.Collections.Generic;
using Reactivity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.Quarry.UI.Tip
{
	public class TipController : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private RectTransform _tipRect;

		[SerializeField]
		private LayoutElement _tipLayoutElement;

		[SerializeField]
		private TMP_Text _tipText;

		[SerializeField]
		private GameObject _tipNoteContainer;

		[SerializeField]
		private TMP_Text _pendingTipText;

		private float _lastTipClosed;

		private float _currentTipShownAt;

		private const float DelayBetweenTips = 3f;

		private const float NoteShowDelay = 30f;

		public bool IsOpen => false;

		private List<(TipType TipType, Func<string> GetDescription)> QueuedTips { get; }

		private void Awake()
		{
		}

		private void Setup()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private bool IsTipUsed(TipType tipType)
		{
			return false;
		}

		private void QueueTip(TipType tipType, Func<string> getDescription)
		{
		}

		private void ShowQueuedTip()
		{
		}

		private void SetupTip<T>(TipType tipType, Func<string> getDescription, T dependency, Func<T, bool> showCondition, Func<T, bool> cancelCondition = null) where T : class, IReactiveDependency
		{
		}

		public void Clicked()
		{
		}
	}
}
