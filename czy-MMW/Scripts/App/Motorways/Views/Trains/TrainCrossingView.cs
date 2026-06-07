using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Views.Trains
{
	public class TrainCrossingView : MonoBehaviour, IView, TrainCrossingModel.IObserver, IReusable
	{
		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				TrainCrossingView trainCrossingView = client.Scope.Get<TrainCrossingView>();
				trainCrossingView.Initialize(model as TrainCrossingModel);
				client.AddView(trainCrossingView);
			}
		}

		private TrainCrossingModel _trainCrossingModel;

		[Dependency]
		private GameCamera _gameCamera;

		public TrainCrossingModel Model => _trainCrossingModel;

		private void Initialize(TrainCrossingModel trainCrossingModel)
		{
			_trainCrossingModel = trainCrossingModel;
			base.transform.position = (Vector3)TilemapModel.GetWorldPositionForCoordinates(_trainCrossingModel.Tile.Coordinates);
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void OnSignalChanged(TrainSignalState trainSignalState)
		{
		}

		public void Reset()
		{
			_trainCrossingModel = null;
			base.transform.position = Vector3.zero;
		}
	}
}
