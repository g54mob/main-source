using System;
using DG.Tweening;
using Gh.Tk.UI;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class Alert_3DUIView : BaseInteractable3DUIView
	{
		private TooltipData _tooltip;

		private GameObject _currentIcon;

		private TextMeshProI18n _numberValueText;

		private bool _isPositionDirty;

		private Tweener _destinationTween;

		[SerializeField]
		private Countdown3DUIView _timer;

		public Action<Alert_3DUIView> OnClickAction { get; set; }

		public int Number { get; private set; }

		public TooltipData Tooltip
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Priority { get; private set; }

		public string CurrentAlertType { get; private set; }

		protected override void Start()
		{
		}

		public void SetDestinationPosition(Vector3 destinationPosition)
		{
		}

		protected override void OnDisable()
		{
		}

		public void Kill()
		{
		}

		public override void OnClicked()
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		public void SetAlertType(string alertTypeId)
		{
		}

		public void SetNumberValue(int number)
		{
		}

		public void SetIcon(string iconPrefabId)
		{
		}

		protected string GetBadgeDingSound()
		{
			return null;
		}

		protected void PlayDingSound()
		{
		}

		public override void Nudge(bool withSound = true)
		{
		}

		public void ShowTimer()
		{
		}

		public void HideTimer()
		{
		}

		public void SetTimerValue(float percentage)
		{
		}
	}
}
