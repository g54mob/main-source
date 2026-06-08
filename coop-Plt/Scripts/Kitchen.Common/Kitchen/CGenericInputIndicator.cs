using Unity.Entities;

namespace Kitchen
{
	public struct CGenericInputIndicator : IComponentData
	{
		public InputIndicatorMessage Message;

		public int CreateForPlayer;
	}
}
