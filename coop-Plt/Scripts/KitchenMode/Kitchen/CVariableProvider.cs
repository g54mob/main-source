using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CVariableProvider : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int Current;

		public int Provide1;

		public int Provide2;

		public int Provide3;

		public int Provide => Current switch
		{
			0 => Provide1, 
			1 => Provide2, 
			2 => Provide3, 
			_ => Provide1, 
		};
	}
}
