using System;
using System.Collections;
using System.Collections.Generic;
using UI.Elements;
using UI.ListContainer;
using UnityEngine;

namespace UI.Apps
{
	public class LearnApp : MultiToolApp
	{
		[SerializeField]
		private ElementListContainer tutorialListContainer;

		[SerializeField]
		private ElementListContainer starterKitListContainer;

		[SerializeField]
		private UIButton tutorialTabButton;

		[SerializeField]
		private UIButton starterKitTabButton;

		private UIButton currentTabSelected;

		private SerializedGadgetMetaData currentSelectedGadget;

		private int currentSelectedIndex;

		private bool isStarting;

		[SerializeField]
		private UIButton docButton;

		[SerializeField]
		private UIButton linksButton;

		[SerializeField]
		private UIButton videoButton;

		[SerializeField]
		private UIButton printButton;

		private Dictionary<UIButton, ElementListContainer> gadgetTabsDict;

		private AssetListConverter converter;

		private Coroutine waitToCloseProjectorCo;

		public override void Init()
		{
		}

		private void ResetNotSelectedTabButtonsToIcon()
		{
		}

		private void InitTabButtons()
		{
		}

		private void SelectTab(UIButton tab)
		{
		}

		private void OpenUrlButtonAction(string table, string title, string message, UIButton button, Action<bool> onConfirm)
		{
		}

		private void OpenDocumentation()
		{
		}

		private void OpenDocumentationConfirm(bool confirm)
		{
		}

		private void OpenVideoTutorial()
		{
		}

		private void OpenVideoTutorialConfirm(bool confirm)
		{
		}

		private void OpenLinks()
		{
		}

		private void OpenLinksConfirm(bool confirm)
		{
		}

		public override void AppStart()
		{
		}

		public override void AppStop()
		{
		}

		private void OnElementSelected(int gadgetIndex)
		{
		}

		private void Print()
		{
		}

		private void OnGadgetPrinted()
		{
		}

		protected void OnGadgetButtonExit(int gadgetIndex)
		{
		}

		protected IEnumerator WaitToCloseProjectorCO()
		{
			return null;
		}

		private void StopCoroutines()
		{
		}

		public override bool NeedGadget()
		{
			return false;
		}
	}
}
