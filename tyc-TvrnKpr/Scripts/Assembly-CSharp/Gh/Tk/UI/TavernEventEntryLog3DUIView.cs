using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class TavernEventEntryLog3DUIView : BaseInteractable3DUIView
	{
		private int _currentFocusIndex;

		[SerializeField]
		private List<GameObject> _chaosObjects;

		[SerializeField]
		private List<GameObject> _nonChaosObjects;

		[SerializeField]
		private GameObject _targetIcon;

		[SerializeField]
		private TextBlock3DUIView _textBlock;

		public float paddingIconOffset;

		public bool suspendInteractionIfNoTarget;

		public List<TavernLog.TavernEventLogEntry> CurrentEntries { get; private set; }

		public bool ShowTimestamp { get; set; }

		public void SetEntries(IEnumerable<TavernLog.TavernEventLogEntry> entries)
		{
		}

		protected override void OnClickedInternal()
		{
		}

		private bool CanBeFocused()
		{
			return false;
		}

		private void FocusOnEvent()
		{
		}

		public void AddDuplicate(TavernLog.TavernEventLogEntry entry)
		{
		}

		private bool IsTargetSet()
		{
			return false;
		}

		private void UpdateVisual()
		{
		}

		private void OnTextChanged(object sender, EventArgs e)
		{
		}

		private void OnTextChanged()
		{
		}
	}
}
