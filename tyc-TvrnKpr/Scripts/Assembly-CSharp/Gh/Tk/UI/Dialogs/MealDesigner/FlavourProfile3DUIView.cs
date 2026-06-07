using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class FlavourProfile3DUIView : MonoBehaviour
	{
		[SerializeField]
		private FlavourGauge3DUIView _grossGauge;

		[SerializeField]
		private FlavourGauge3DUIView _toughGauge;

		[SerializeField]
		private FlavourGauge3DUIView _sweetGauge;

		[SerializeField]
		private FlavourGauge3DUIView _pureGauge;

		public void SetValues(int gross, int sweet, int tough, int pure)
		{
		}

		public void SetPreviewValues(int? gross = null, int? sweet = null, int? tough = null, int? pure = null)
		{
		}
	}
}
