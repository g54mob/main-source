using Factory.FieldObject;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	public interface ILuggageCarrier
	{
		StructureAddr GetAddr { get; }

		Luggage Luggage { get; set; }

		eLuggage HasLuggageId { get; }

		double LuggageRate { get; set; }

		int LuggageCount { get; set; }

		int LuggageOmakeCount { get; set; }

		double CreateTime { get; set; }

		double LoadingTime { get; set; }

		bool IsLuggageGoal { get; }

		Vector2 FromVector { get; }

		Vector2 ToVector { get; }

		bool LuggageVisible { get; set; }

		bool IsPushBacked { get; set; }

		double CarHornLevel { get; set; }

		double UpdateLuggageSpeedForDebug { get; set; }

		bool ComeFromInserter { get; set; }

		bool IsLuggageGoalAndIsEmptyNext(ILuggageCarrier next);

		void InfectionCarHornLevel(ILuggageCarrier from);

		void Vanish();

		void RemoveLuggage(bool force = false, bool exceptInserter = false);

		bool ClearOutputProduct();

		void CreateOutputProduct(eLuggage product, int craftCount, int omakeCount = 0, bool luggageVisible = true, float? scale = null, LuggageFlag flag = (LuggageFlag)0, bool noRecord = false);

		void TractionOutputProduct<T>(T from, bool forceVisible = true, bool noRecord = false) where T : ILuggageCarrier;

		bool SetOutputProductFromLuggage(bool addManufacture = true);

		string ToMinimum();
	}
}
