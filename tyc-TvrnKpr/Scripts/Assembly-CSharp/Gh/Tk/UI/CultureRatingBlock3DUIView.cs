using Gh.Tk.UI.Dialogs.MealDesigner;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class CultureRatingBlock3DUIView : BaseBlock3DUIView
	{
		[SerializeField]
		private PatronGameItemRatingContainer3DUIView _patronRatings;

		public override void SetBlockData(string data)
		{
		}

		private IPatronRatable GetPatronRatable(string data)
		{
			return null;
		}
	}
}
