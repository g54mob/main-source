using DV.Common;
using DV.Util;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios.Common
{
	public interface IScenarioCRUD
	{
		ObservableCollectionExt<IScenario> Scenarios { get; }

		ObservableCollectionExt<ITrain> Trains { get; }

		ObservableCollectionExt<IDifficulty> Difficulties { get; }

		string BaseStoragePath { get; }

		void Reload();

		void Flush();

		IScenario CreateScenario();

		IDifficulty CreateDifficulty();

		ITrain CreateTrain();

		ICar CreateCar(string liveryName, bool reversed, string cargo = null);

		IScenario CreateCopyOf(IScenario scenario);

		ITrain CreateCopyOf(ITrain train);

		IDifficulty CreateCopyOf(IDifficulty difficulty);

		void DeleteScenario(IScenario scenarioToDelete);

		void DeleteTrain(ITrain trainToDelete);

		void DeleteDifficulty(IDifficulty difficultyToDelete);

		string GetAutoIncrementName(IScenariosThing thing);

		JObject SerializeThing(IThing thing);

		IScenario ScenarioFromJson(JObject json, string fileName = "");

		IDifficulty DifficultyFromJson(JObject json, string fileName = "");

		ITrain TrainFromJson(JObject json, string fileName = "");
	}
}
