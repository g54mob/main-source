using System.Collections.Generic;
using Gh.Tk.UI;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class NotificationChecklistItem3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private CheckBox3DUIView _checkBox;

		[SerializeField]
		private GameObject _onCheckedEffected;

		[SerializeField]
		private TextBlock3DUIView _textBlock;

		[SerializeField]
		private BoxCollider _standardCollider;

		[SerializeField]
		private BoxCollider _extendedCollider;

		[SerializeField]
		private GameObject _rightSideHelpIcon;

		[SerializeField]
		private GameObject _rightSideHelpVideoIcon;

		private TooltipData _tooltipData;

		[SerializeField]
		private GameObject _buttonBacker;

		[SerializeField]
		private Color _defaultTextColor;

		[SerializeField]
		private Color _buttonItemTextColor;

		public List<GameObject> pipTemplates;

		[SerializeField]
		public Transform _pipContainer;

		private List<GameObject> _pips;

		[SerializeField]
		private Material _pipPositiveMaterial;

		[SerializeField]
		private Material _pipNegativeMaterial;

		[SerializeField]
		private float _pipSpacing;

		private float _previousPipValue;

		private int _previousTotalPipValue;

		public const int FULL_WIDTH_PIP_COUNT = 50;

		[SerializeField]
		private GameObject _fullWidthPipPrefab;

		private GameObject _fullWidthPip;

		public TMP_Text Text => null;

		public UINotificationData.ChecklistItem Data { get; private set; }

		public void UpdateChecklistItem(UINotificationData.ChecklistItem checklistItem)
		{
		}

		protected override void OnDisable()
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		private void UpdatePips(UINotificationData.ChecklistItem checklistItem)
		{
		}

		private GameObject GetFullWidthPip()
		{
			return null;
		}
	}
}
