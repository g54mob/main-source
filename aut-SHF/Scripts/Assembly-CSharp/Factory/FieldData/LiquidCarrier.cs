using Models;

namespace Factory.FieldData
{
	public static class LiquidCarrier
	{
		public static void CreateLiquid<T>(T car, eLuggage liquid, double measure, double? forceCreateTime = null) where T : ILiquidCarrier
		{
		}

		public static void InitLiquid<T>(T str, double capacity, eLuggage color = eLuggage.None) where T : ILiquidCarrier
		{
		}

		public static bool IsConnectPipe(Structure from, StructureAddr toAddr)
		{
			return false;
		}

		public static bool IsFromPipeOutputPort(Structure from, StructureAddr toAddr, out ILiquidCarrier carrier)
		{
			carrier = null;
			return false;
		}

		public static bool IsToPipeInputPort(StructureAddr fromAddr, Structure to, out ILiquidCarrier carrier)
		{
			carrier = null;
			return false;
		}

		public static bool IsConnectPipePort(Structure from, StructureAddr toAddr, out ILiquidCarrier carrier)
		{
			carrier = null;
			return false;
		}

		public static bool IsFromPipeOrOutputPort(Structure from, StructureAddr toAddr, out ILiquidCarrier carrier)
		{
			carrier = null;
			return false;
		}

		public static bool IsToPipeOrInputPort(StructureAddr fromAddr, Structure to, out ILiquidCarrier carrier)
		{
			carrier = null;
			return false;
		}

		public static bool IsConnectPipeOrPipePort(Structure from, StructureAddr toAddr, out ILiquidCarrier carrier)
		{
			carrier = null;
			return false;
		}

		public static bool IsFromPipeTail(Structure from, StructureAddr toAddr)
		{
			return false;
		}

		public static (eCarrierResultFlag, double) PourLiquid<T>(T from, double speed) where T : ILiquidCarrier
		{
			return default((eCarrierResultFlag, double));
		}

		public static (eCarrierResultFlag, double) DiscardLiquid<T>(T to, double measure) where T : ILiquidCarrier
		{
			return default((eCarrierResultFlag, double));
		}

		public static LiquidFeedResult TractionLiquidFeed<T>(T from, T to, double speed) where T : ILiquidCarrier
		{
			return null;
		}

		public static eCarrierResultFlag UpdateLiquidBalance<T>(T a, T b, double speed) where T : ILiquidCarrier
		{
			return default(eCarrierResultFlag);
		}

		public static bool HasInk0<T>(T carrier) where T : ILiquidCarrier
		{
			return false;
		}

		public static bool HasInk2<T>(T carrier) where T : ILiquidCarrier
		{
			return false;
		}

		private static bool NullOrNoInk<T>(T carrier) where T : ILiquidCarrier
		{
			return false;
		}

		public static bool EqualsInk<T>(T a, T b) where T : ILiquidCarrier
		{
			return false;
		}

		private static eCarrierResultFlag Balance<T>(T from, T to, double speed) where T : ILiquidCarrier
		{
			return default(eCarrierResultFlag);
		}

		private static LiquidFeedResult Feed<T>(T from, T to, double speed) where T : ILiquidCarrier
		{
			return null;
		}

		private static (eCarrierResultFlag, double) Pour<T>(T to, double speed) where T : ILiquidCarrier
		{
			return default((eCarrierResultFlag, double));
		}

		public static void RemoveSpecificPipeLink(FactoryMap factoryMap, StructureAddr selfAddr, StructureAddr otherAddr, bool ignoreColor = false, bool cleanTank = false, eLuggage? pipeColor = null)
		{
		}
	}
}
