using System;
using System.Collections.Generic;

namespace NSMedieval.UI
{
	public class InfoPanelAction
	{
		public int CurrentIndex { get; private set; }

		public KeyValuePair<SelectionInputActionData, Action>[] ObjectActions { get; }

		public bool IsMultiAction => ObjectActions.Length > 1;

		public bool IsToggle { get; }

		public InfoPanelAction(KeyValuePair<SelectionInputActionData, Action>[] objectActions)
		{
			CurrentIndex = 0;
			ObjectActions = objectActions;
			IsToggle = IsMultiAction;
		}

		public InfoPanelAction(KeyValuePair<SelectionInputActionData, Action>[] objectActions, int currentIndex)
		{
			CurrentIndex = currentIndex;
			ObjectActions = objectActions;
			IsToggle = IsMultiAction;
		}

		public InfoPanelAction(KeyValuePair<SelectionInputActionData, Action>[] objectActions, int currentIndex, bool isToggle)
		{
			CurrentIndex = currentIndex;
			ObjectActions = objectActions;
			IsToggle = isToggle;
		}

		public SelectionInputActionData GetCurrentActionData()
		{
			return ObjectActions[CurrentIndex].Key;
		}

		public void RunCurrentAction()
		{
			ObjectActions[CurrentIndex].Value?.Invoke();
			SetNextIndex();
		}

		private void SetNextIndex()
		{
			CurrentIndex = GetNextIndex();
		}

		private int GetNextIndex()
		{
			int num = CurrentIndex + 1;
			if (num >= ObjectActions.Length)
			{
				num = 0;
			}
			return num;
		}
	}
}
