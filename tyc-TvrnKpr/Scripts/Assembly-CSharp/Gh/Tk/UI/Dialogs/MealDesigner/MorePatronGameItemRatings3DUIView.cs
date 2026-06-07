using System.Collections.Generic;
using I18n;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class MorePatronGameItemRatings3DUIView : Button3DUIView
	{
		public TextMeshProI18n numberText;

		public IEnumerable<PatronGameItemRating3DUIView> Ratings;

		public void Refresh()
		{
		}
	}
}
