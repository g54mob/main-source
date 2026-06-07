using System;
using System.Collections.Generic;
using UI.Common;
using UnityEngine;
using UnityEngine.Localization.Tables;
using UnityEngine.UI;

namespace UI.Elements
{
	public class UIToggle : MonoBehaviour
	{
		[NonSerialized]
		[HideInInspector]
		public Toggle toggle;

		public UIText label;

		private ToggleGroup toggleGroup;

		public TableReference tableRef;

		public TableEntryReference labelRef;

		private Dictionary<int, Action<bool>> onToggleValueChangeDict;

		private IUIToggleModule[] toggleModules;

		public Action<bool> OnToggleValueChange
		{
			set
			{
			}
		}

		public void Init()
		{
		}

		public void SetToggleLocalization(TableReference tableRef, TableEntryReference labelRef)
		{
		}

		public void SetToggleText(TableReference tableRef, TableEntryReference labelRef)
		{
		}

		public void SetToggleGroup(ToggleGroup toggleGroup)
		{
		}

		public void SetValue(bool value)
		{
		}

		public void Enable()
		{
		}

		public void SetColor(UIColorStates color)
		{
		}

		public void Disable()
		{
		}

		private void ToggleValueChanged(bool toggleValue)
		{
		}

		public void AddActionToDict(int priority, Action<bool> action)
		{
		}

		public void ResetModules()
		{
		}
	}
}
