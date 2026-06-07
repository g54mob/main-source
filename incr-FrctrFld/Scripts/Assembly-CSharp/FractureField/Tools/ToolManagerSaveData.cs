using Reactivity;

namespace FractureField.Tools
{
	public class ToolManagerSaveData : IConvertableSaveData
	{
		public Ref<ToolType> CurrentToolType { get; set; }

		public RDictionary<ToolType, RBool> UnlockedTools { get; set; }

		protected ToolManagerSaveData Save(ToolManager data)
		{
			return null;
		}
	}
}
