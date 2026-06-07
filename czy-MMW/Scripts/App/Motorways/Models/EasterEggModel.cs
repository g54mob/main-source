using Factory;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class EasterEggModel : Model<EasterEggModel.Frame, EasterEggModel.IObserver>
	{
		public class Frame : IFrame
		{
			public VehicleModel currentEasterEggVehicle;

			public void Reset()
			{
				currentEasterEggVehicle = null;
			}

			public bool CloneInto(IFrame cloneState, IScope scope)
			{
				((Frame)cloneState).currentEasterEggVehicle = currentEasterEggVehicle;
				return true;
			}
		}

		public interface IObserver
		{
			void OnEasterEggVehicleChanged(int oldVehicleId, int newVehicleId);
		}

		private const string EasterEggCityName = "Copenhagen";

		private const int EasterEggGroupIndex = 0;

		private const float EasterEggSpawnProbability = 1f;

		[Dependency]
		private IScope _gameScope;

		public bool ShouldBeEasterEggVehicle(VehicleModel vehicleModel)
		{
			if (base.CurrentFrame.currentEasterEggVehicle != null)
			{
				return base.CurrentFrame.currentEasterEggVehicle == vehicleModel;
			}
			if (_gameScope.Get<MotorwaysGame>().MapDefinition.CityNameEnum.ToString().Equals("Copenhagen") && vehicleModel.house.GroupIndex == 0 && UnityEngine.Random.value < 1f)
			{
				base.CurrentFrame.currentEasterEggVehicle = vehicleModel;
				base.NextFrame.currentEasterEggVehicle = vehicleModel;
				return true;
			}
			return false;
		}

		public EasterEggModel()
			: base(1)
		{
		}
	}
}
