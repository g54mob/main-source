using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Dialogs.Data;
using UnityEngine;

namespace NSMedieval.Dialogs
{
	public class DialogViewManager : MonoSingleton<DialogViewManager>
	{
		public Action<int> OnClose;

		[SerializeField]
		private DialogView view;

		private readonly List<GameObject> tempAdditionalViews = new List<GameObject>();

		public void OpenDialog(DialogContent dialogContent, bool appendCloseToButtons = true)
		{
			if (appendCloseToButtons)
			{
				for (int i = 0; i < dialogContent.Options.Count; i++)
				{
					DialogOption dialogOption = dialogContent.Options[i];
					int indexClosureCopy = i;
					dialogOption.OnSelected = (Action)Delegate.Combine(dialogOption.OnSelected, (Action)delegate
					{
						for (int j = 0; j < dialogContent.Options.Count; j++)
						{
							if (dialogContent.Options[j] != null)
							{
								dialogContent.Options[j].OnSelected = null;
							}
						}
						Close(indexClosureCopy);
					});
				}
			}
			view.Open(dialogContent);
		}

		public void OpenDialog(string text, string title = "")
		{
			DialogContent dialogContent = new DialogContent();
			dialogContent.ContentBodyText = text;
			dialogContent.WindowTitle = title;
			OpenDialog(dialogContent);
		}

		public void Close(int selectedOptionIndex)
		{
			view.Close();
			OnClose?.Invoke(selectedOptionIndex);
			ClearAdditionalTempViews();
		}

		public void CloseSilent()
		{
			view.Close();
			ClearAdditionalTempViews();
		}

		public void AddTempAdditionalView(Canvas canvas)
		{
			if (canvas == null)
			{
				Log.Error("Failed to add temp additional view clone: it is null", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Dialog\\DialogViewManager.cs");
				return;
			}
			canvas.sortingOrder = view.GetComponent<Canvas>().sortingOrder + 1;
			tempAdditionalViews.Add(canvas.gameObject);
		}

		private void ClearAdditionalTempViews()
		{
			foreach (GameObject tempAdditionalView in tempAdditionalViews)
			{
				UnityEngine.Object.Destroy(tempAdditionalView);
			}
			tempAdditionalViews.Clear();
		}
	}
}
