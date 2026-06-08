using Unity.Entities;

namespace Kitchen
{
	public struct CHalloweenOrder : IComponentData
	{
		public bool IsTrick;

		public TrickTreatStates State;

		private static TrickTreatStates[] Tricks = new TrickTreatStates[6]
		{
			TrickTreatStates.TrickStartFire,
			TrickTreatStates.TrickNoPayment,
			TrickTreatStates.TrickExtraMess,
			TrickTreatStates.TrickDoubleOrder,
			TrickTreatStates.TrickExtraRubbish,
			TrickTreatStates.TrickChangeOrders
		};

		private static TrickTreatStates[] Treats = new TrickTreatStates[2]
		{
			TrickTreatStates.TreatDoubleMoney,
			TrickTreatStates.TreatBuffFloors
		};

		public bool IsTreat => !IsTrick;

		public static CHalloweenOrder Trick => new CHalloweenOrder
		{
			IsTrick = true,
			State = Tricks.Random()
		};

		public static CHalloweenOrder Treat => new CHalloweenOrder
		{
			IsTrick = false,
			State = Treats.Random()
		};
	}
}
