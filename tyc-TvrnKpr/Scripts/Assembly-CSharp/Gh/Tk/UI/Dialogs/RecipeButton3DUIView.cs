using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class RecipeButton3DUIView : Button3DUIView
	{
		[SerializeField]
		private TextMeshProI18n _name;

		[SerializeField]
		private Transform _preview;

		[SerializeField]
		private TextBlock3DUIView _description;

		private CraftProcess _craftProcess;

		public CraftProcess CraftProcess
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
