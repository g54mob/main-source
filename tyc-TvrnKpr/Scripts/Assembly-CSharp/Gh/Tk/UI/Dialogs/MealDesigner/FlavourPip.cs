using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class FlavourPip : MonoBehaviour
	{
		[SerializeField]
		private Transform _fullPip;

		[SerializeField]
		private Transform _emptyPip;

		[SerializeField]
		private Transform _gainingPip;

		[SerializeField]
		private Transform _losingPip;

		public void SetState(PipState state)
		{
		}
	}
}
