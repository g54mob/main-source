using Gh.Tk.Story.Structure;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class ScenarioChallenge3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private CheckBox3DUIView _checkBox;

		[SerializeField]
		private Transform _iconSocket;

		private ScenarioChallenge _challenge;

		private static GameObject _defaultIconPrefab;

		private GameObject _iconInstance;

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnAchievementUnlockedChanged(object sender, EventArgs<PlayerProfile.AchievementEntry> e)
		{
		}

		public void SetChallenge(ScenarioChallenge challenge)
		{
		}

		private void SetIcon(string iconId)
		{
		}
	}
}
