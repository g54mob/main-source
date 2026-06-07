using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class RecipeTemplatePicker3DUIView : MonoBehaviour
	{
		[SerializeField]
		private RecipeButton3DUIView _recipeButtonPrefab;

		[SerializeField]
		private Container3DUIView _contentContainer;

		private void Start()
		{
		}

		public void ShowTemplates(IEnumerable<CraftProcess> templates, Action<CraftProcess> callback)
		{
		}

		public void Close()
		{
		}
	}
}
