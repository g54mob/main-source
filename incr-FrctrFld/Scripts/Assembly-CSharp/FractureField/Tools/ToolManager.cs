using Reactivity;

namespace FractureField.Tools
{
	public class ToolManager : ToolManagerSaveData, ISaveData<ToolManager, ToolManagerSaveData>
	{
		private CFloat _currentToolFracture;

		private CFloat _currentToolPierce;

		private CFloat _currentToolRange;

		private CBool _canPurchaseAnyTool;

		public CFloat CurrentFractureMultiplier => null;

		public CFloat CurrentPierceMultiplier => null;

		public CFloat CurrentToolRange => null;

		public CBool CanPurchaseAnyTool => null;

		public ToolManager Load()
		{
			return null;
		}

		public ToolManagerSaveData Save()
		{
			return null;
		}

		public void Init()
		{
		}

		public Tool GetCurrentTool()
		{
			return null;
		}

		public Tool GetTool(ToolType type)
		{
			return null;
		}

		public void SetCurrentTool(ToolType toolType)
		{
		}

		public bool IsToolUnlocked(ToolType toolType)
		{
			return false;
		}

		public bool CanPurchaseTool(ToolType toolType)
		{
			return false;
		}

		public bool PurchaseTool(ToolType toolType)
		{
			return false;
		}

		public bool TryAutomaticallyPurchaseCheapest()
		{
			return false;
		}

		public void UnlockTool(ToolType toolType)
		{
		}

		private void DoPrestigeLayerReset()
		{
		}
	}
}
