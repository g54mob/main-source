using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemAmbulanceComponent : EntityTickComponent
	{
		private bool _isOutOfParkingSpace;

		public bool IsOutOfParkingSpace
		{
			get
			{
				return _isOutOfParkingSpace;
			}
			set
			{
				_isOutOfParkingSpace = value;
			}
		}
	}
}
