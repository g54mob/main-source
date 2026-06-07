using System;
using System.Collections.Generic;
using UI.Elements;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public struct UITicksModalInitParameters
	{
		public TableReference tableRef;

		public TableEntryReference titleEntryRef;

		public TableEntryReference messageEntryRef;

		public List<TableEntryReference> ticksEntryRef;

		public Action<List<UIToggle>> OnConfirm;

		public Action OnCancel;

		public bool areTogglesInGroup;

		public bool togglesAllowSwitchOff;

		public List<string> activeToggles;

		public UITicksModalInitParameters(TableReference tableRef, TableEntryReference titleEntryRef, TableEntryReference messageEntryRef, List<TableEntryReference> ticksEntryRef, Action<List<UIToggle>> OnConfirm, Action OnCancel, bool togglesAllowSwitchOff, bool areTogglesInGroup, List<string> activeToggles)
		{
			this.tableRef = default(TableReference);
			this.titleEntryRef = default(TableEntryReference);
			this.messageEntryRef = default(TableEntryReference);
			this.ticksEntryRef = null;
			this.OnConfirm = null;
			this.OnCancel = null;
			this.areTogglesInGroup = false;
			this.togglesAllowSwitchOff = false;
			this.activeToggles = null;
		}
	}
}
