using Unity.Entities;

namespace Kitchen
{
	public struct CRequestSave : IComponentData
	{
		public SaveType SaveType;
	}
}
