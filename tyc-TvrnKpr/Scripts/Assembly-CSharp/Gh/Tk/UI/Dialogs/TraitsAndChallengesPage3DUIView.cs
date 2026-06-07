using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class TraitsAndChallengesPage3DUIView : TavernSetupPage3DUIView
	{
		[SerializeField]
		private Container3DUIView _traitsContainer;

		[SerializeField]
		private ScenarioTrait3DUIView _traitPrefab;

		[SerializeField]
		private Container3DUIView _challengesContainer;

		[SerializeField]
		private ScenarioChallenge3DUIView _challengePrefab;

		protected override void RenderPageInternal()
		{
		}
	}
}
