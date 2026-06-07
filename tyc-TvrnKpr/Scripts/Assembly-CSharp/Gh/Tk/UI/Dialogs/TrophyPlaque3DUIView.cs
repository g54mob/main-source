using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class TrophyPlaque3DUIView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProI18n _titleText;

		[SerializeField]
		private TextMeshProI18n _descriptionText;

		[SerializeField]
		private TextMeshProI18n _progressBarText;

		[SerializeField]
		private BaseProgressBar3DUIView _progressBar;

		private Achievement _achievement;

		public void SetData(Achievement displayedAchievement)
		{
		}

		public void Refresh()
		{
		}
	}
}
