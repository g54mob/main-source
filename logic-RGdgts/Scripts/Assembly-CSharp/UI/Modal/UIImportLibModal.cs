using System;
using System.Collections.Generic;
using UI.Elements;
using UI.ListContainer;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Modal
{
	public class UIImportLibModal : UIModal<UIImportLibModalInitParameters>
	{
		private ElementListContainer libListContainer;

		private Action<LibsController.Lib> OnElementSelected;

		private Action OnModalClosed;

		private LocalizedString localizedStringTitle;

		[SerializeField]
		private UIButton openButton;

		[SerializeField]
		private UIButton closeButton;

		private LibsController.Lib selectedLib;

		public RectTransform RGLibsTitle;

		public RectTransform ExternalLibsTitle;

		public override void Init(UIModalManager modalManager, UIImportLibModalInitParameters initParameters, List<UIButton> modalOpenButton)
		{
		}

		public override void OnOpen()
		{
		}

		public void OnConfirmButton()
		{
		}

		public override void OnClose()
		{
		}

		public override void DisablePanel()
		{
		}

		public override void EnablePanel()
		{
		}

		private void FillFileList()
		{
		}

		private void FillLibraries(LibsController.Lib lib)
		{
		}

		private void OnElementClicked(int libIndex)
		{
		}

		private void OnElementDoubleClicked(int libIndex)
		{
		}

		public override void Set()
		{
		}

		private void Clear()
		{
		}
	}
}
