namespace Factory.FieldData
{
	public static class MachineExtension
	{
		public static bool HasPipeTileVariation(this eMachine self)
		{
			return false;
		}

		public static bool IsBridge(this eMachine self)
		{
			return false;
		}

		public static bool IsBridgeConveyer(this eMachine self)
		{
			return false;
		}

		public static bool IsNeedRouteGuide(this eMachine self)
		{
			return false;
		}

		public static bool IsBridgeAndTeleporter(this eMachine self)
		{
			return false;
		}

		public static bool IsPipe(this eMachine self)
		{
			return false;
		}

		public static bool IsPipeCategory(this eMachine self)
		{
			return false;
		}

		public static bool IsComposite(this eMachine self)
		{
			return false;
		}

		public static bool IsMultilayerPipe(this eMachine self)
		{
			return false;
		}

		public static bool IsStream(this eMachine self)
		{
			return false;
		}

		public static bool IsSmartMech(this eMachine self)
		{
			return false;
		}

		public static bool IsParallelMechShortSide(this eMachine self)
		{
			return false;
		}

		public static bool IsRelocatableMachine(this ePrimaryMachineCategory primaryCategory, ePaletteCategory paletteCategory)
		{
			return false;
		}

		public static bool IsInserter(this eMachine self)
		{
			return false;
		}
	}
}
