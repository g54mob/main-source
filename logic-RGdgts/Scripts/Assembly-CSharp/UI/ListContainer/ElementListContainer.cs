using System;
using System.Collections.Generic;
using UI.Elements;
using UnityEngine;

namespace UI.ListContainer
{
	public class ElementListContainer : MonoBehaviour
	{
		[HideInInspector]
		public List<ButtonsParametersAndPrefabIndex> buttonParameters;

		public UIColoredButtonList uiScrollableElementList;

		public Transform scrollListContent;

		[SerializeField]
		public List<GameObject> elementColoredButtonPrefabs;

		private Action<int> OnListButtonSelected;

		public void Init(Action<int> OnListButtonSelected, Action<int> OnListButtonDoubleClicked, Action<int> OnListButtonEntered = null, Action<int> OnListButtonExit = null)
		{
		}

		private void SelectListButton(int thisButtonIndex)
		{
		}

		public void AddElement(ElementColoredButtonParameters elementP, int index = 0)
		{
		}

		public void AddElements(List<ButtonsParametersAndPrefabIndex> elementP)
		{
		}

		public void AddElementToUI(ElementColoredButtonParameters elementP, int nElementInList = 0)
		{
		}

		public void RefreshElementToUI(UIButton elementButton, ElementColoredButtonParameters elementP)
		{
		}

		public void ReplaceElement(ElementColoredButtonParameters elementP)
		{
		}

		public ElementColoredButtonParameters GetElement(int assetIndex)
		{
			return null;
		}

		public void ClearElementLists()
		{
		}

		public void InvokePointerDownListButton(ElementColoredButtonParameters buttonP)
		{
		}
	}
}
