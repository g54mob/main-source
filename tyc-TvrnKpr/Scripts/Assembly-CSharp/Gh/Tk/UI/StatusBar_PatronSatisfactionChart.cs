using Gh.Tk.UI.Dialogs;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class StatusBar_PatronSatisfactionChart : PatronSatisfactionChart
	{
		public GameObject pawn;

		protected override int AverageSatisfactionTextNumber
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override GameObject GetModel(PatronData data)
		{
			return null;
		}
	}
}
