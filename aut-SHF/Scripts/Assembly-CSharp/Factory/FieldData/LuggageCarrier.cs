using System;
using Factory.FieldObject;
using Models;

namespace Factory.FieldData
{
	public static class LuggageCarrier
	{
		public static void CreateLuggage<T>(T str, eLuggage product, int createCount = 1, int omakeCount = 0, bool luggageVisible = true, float? scale = null, LuggageFlag flag = (LuggageFlag)0, int coatingLevel = 0, eLuggage coatingColor = eLuggage.None) where T : ILuggageCarrier
		{
		}

		public static void CreateLuggage<T>(T str, eLuggage product, SerializableLuggage sl) where T : ILuggageCarrier
		{
		}

		public static bool IsFromRouteTail(Structure from, StructureAddr toAddr)
		{
			return false;
		}

		public static bool IsFromOutputPort(Structure from, StructureAddr toAddr)
		{
			return false;
		}

		public static bool IsToRouteHead(StructureAddr fromAddr, Structure to)
		{
			return false;
		}

		public static bool IsFromOutputPortOrRouteTail(Structure from, StructureAddr toAddr)
		{
			return false;
		}

		public static bool IsFromOutputPortOrRouteTail(Structure from, StructureAddr[] toAddrs)
		{
			return false;
		}

		public static bool IsFromTransportOutputPortOrRouteTail(Structure from, StructureAddr toAddr)
		{
			return false;
		}

		private static bool IsFromOutputWithProductOrRouteTail(Structure from, StructureAddr toAddr, out ILuggageCarrier adjustedFrom)
		{
			adjustedFrom = null;
			return false;
		}

		private static bool IsFromOutputWithProductOrRouteTail(Structure from, StructureAddr[] toAddrs, out ILuggageCarrier adjustedFrom)
		{
			adjustedFrom = null;
			return false;
		}

		public static bool TractionLuggageFromOutputOrRouteTail<T>(Structure from, T to, StructureAddr toAddr, bool forceVisible = true) where T : ILuggageCarrier
		{
			return false;
		}

		public static bool TractionLuggageFromTransport<T>(Structure from, T to, StructureAddr[] toAddrs, int needCount = 1, Func<ILuggageCarrier, bool> func = null) where T : ILuggageCarrier
		{
			return false;
		}

		public static bool PickupLuggage<T>(Structure from, T to, Func<eLuggage, bool> isFilterOk) where T : ILuggageCarrier
		{
			return false;
		}

		public static bool IsPickupable(Structure from, out ILuggageCarrier carrier)
		{
			carrier = null;
			return false;
		}

		public static bool InsertLuggage<T>(T from, Structure to, out bool? cautionIcon) where T : ILuggageCarrier
		{
			cautionIcon = null;
			return false;
		}

		private static bool IsInsertable(ILuggageCarrier fromCarrier, Structure to, out ILuggageCarrier toCarrier, out double luggageRate, out bool visible, out bool? cautionIcon, out Action<ILuggageCarrier> successCallback)
		{
			toCarrier = null;
			luggageRate = default(double);
			visible = default(bool);
			cautionIcon = null;
			successCallback = null;
			return false;
		}

		public static bool TractionLuggagePrivate<T>(T from, T to, int needCount) where T : ILuggageCarrier
		{
			return false;
		}

		public static void TractionLuggagePrivate<T>(T from, T to, bool forceVisible = true, bool forceMove = false) where T : ILuggageCarrier
		{
		}

		public static void DownsizeLuggage(Structure fromStr, StructureAddr toAddr)
		{
		}

		public static void ResetLuggageScale(ILuggageCarrier str)
		{
		}

		private static (Structure, StructureAddr) ChoiceLuggage(Structure[] fromStructures, StructureAddr? prioAddr, StructureAddr[] toAddrs)
		{
			return default((Structure, StructureAddr));
		}

		public static void LoadLuggageInto<T>(Structure[] fromStructures, StructureAddr? prioAddr, T to, StructureAddr[] toAddrs, bool luggageVisible = false) where T : ILuggageCarrier
		{
		}

		public static void LoadLuggageIntoFromOutputOrRouteTail<T>(Structure fromStr, T to, StructureAddr toAddr, bool luggageVisible = false, bool arrived = false) where T : ILuggageCarrier
		{
		}

		public static void GoalLuggage<T>(T str, out bool noExp) where T : ILuggageCarrier
		{
			noExp = default(bool);
		}

		public static void UpdateLuggage<T>(T str, double speed) where T : ILuggageCarrier
		{
		}

		public static bool IsLuggageInstantiate()
		{
			return false;
		}
	}
}
