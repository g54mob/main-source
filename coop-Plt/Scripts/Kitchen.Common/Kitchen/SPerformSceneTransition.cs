using Unity.Entities;

namespace Kitchen
{
	public struct SPerformSceneTransition : IComponentData
	{
		public SceneType NextScene;

		public TransitionStage Stage;

		public bool StageComplete;
	}
}
