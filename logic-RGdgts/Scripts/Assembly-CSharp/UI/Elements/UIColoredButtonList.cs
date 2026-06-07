using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Elements
{
	public class UIColoredButtonList : MonoBehaviour
	{
		[NonSerialized]
		[HideInInspector]
		public List<UIButton> listButton;

		public Action<int> OnClick;

		public Action<int> OnDoubleClick;

		public Action<int> OnEnter;

		public Action<int> OnExit;

		[NonSerialized]
		[HideInInspector]
		public UIButton currentButtonSelected;

		public void Init(Action<int> onClickAction, Action<int> onDoubleClickAction = null, Action<int> OnListButtonEntered = null, Action<int> OnListButtonExit = null)
		{
		}

		public void AddListButton(UIButton button)
		{
		}

		public void SetOnClickListButton(UIButton button, int i = -1)
		{
		}

		public void ResetNotSelectedButtons(int index)
		{
		}

		public void InvokePointerDownListElement(int index)
		{
		}

		public UIButton GetListButton(int index)
		{
			return null;
		}

		public int GetListLenght()
		{
			return 0;
		}

		public void RemoveListButton(int index)
		{
		}

		public void Clear()
		{
		}
	}
}
