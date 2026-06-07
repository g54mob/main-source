using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.Achievements.UI
{
	public class AchievementTooltip : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateTooltip_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AchievementTooltip _003C_003E4__this;

			public bool fadeIn;

			private float _003CelapsedTime_003E5__2;

			private float _003CstartAlpha_003E5__3;

			private float _003CtargetAlpha_003E5__4;

			private float _003Cduration_003E5__5;

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
			public _003CAnimateTooltip_003Ed__20(int _003C_003E1__state)
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

		[Header("References")]
		public RectTransform Rect;

		public CanvasGroup CanvasGroup;

		[SerializeField]
		private GameObject _contentGO;

		[SerializeField]
		private TMP_Text _nameText;

		[SerializeField]
		private TMP_Text _descriptionText;

		[Header("Tooltip Animation")]
		[SerializeField]
		private float _tooltipFadeInDuration;

		[SerializeField]
		private float _tooltipFadeOutDuration;

		[SerializeField]
		private AnimationCurve _tooltipFadeCurve;

		private GraphicRaycaster _raycaster;

		private Coroutine _tooltipCoroutine;

		private readonly Vector2 _tooltipOffset;

		private AchievementItem _currentItem;

		private bool _isVisible;

		private Canvas Canvas => null;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void ShowTooltip(AchievementItem item)
		{
		}

		private void HideTooltip()
		{
		}

		private void PositionTooltipAtCursor()
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateTooltip_003Ed__20))]
		private IEnumerator AnimateTooltip(bool fadeIn)
		{
			return null;
		}

		private void OnDisable()
		{
		}

		public void Setup(string name, string description)
		{
		}
	}
}
