using Unity.Entities;

namespace Kitchen
{
	public struct SSelectedLocation : IComponentData
	{
		public bool Valid;

		public CLocationChoice Selected;
	}
}
