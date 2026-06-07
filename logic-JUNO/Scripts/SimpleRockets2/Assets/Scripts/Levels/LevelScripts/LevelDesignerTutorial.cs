using Assets.Scripts.Design;
using Assets.Scripts.Design.Tutorial;
using Assets.Scripts.Design.Tutorial.Sandbox;
using ModApi.Levels;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class LevelDesignerTutorial : Level
	{
		private DesignerTutorial _tutorial;

		public override void InitializeRequirements()
		{
		}

		protected override void OnDesignSceneLoading()
		{
			base.OnDesignSceneLoading();
		}

		protected override void OnDesignSceneReady()
		{
			base.OnDesignSceneReady();
			DesignerScript designer = Game.Instance.Designer as DesignerScript;
			_tutorial = new SandboxTutorial(designer);
			_tutorial.TutorialComplete += OnTutorialComplete;
			_tutorial.StartTutorial("Tutorial-Sandbox");
		}

		private void OnTutorialComplete()
		{
			CompleteLevel(success: true, 0f);
		}
	}
}
