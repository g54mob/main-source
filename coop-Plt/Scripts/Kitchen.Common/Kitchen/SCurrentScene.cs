using Unity.Entities;

namespace Kitchen
{
	public struct SCurrentScene : IComponentData
	{
		public SceneType Type;
	}
}
