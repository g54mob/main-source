using Unity.Entities;

namespace Kitchen
{
	public struct STutorialSystemMarker : IComponentData
	{
		public TutorialStage Stage;
	}
}
