using ModApi.GameLoop.Interfaces;

namespace Assets.Scripts.GameLoop
{
	public delegate void ExecuteSubsetCallback<TLoop>(TLoop loop, IUpdateGroup group, int order) where TLoop : IGameLoop;
}
