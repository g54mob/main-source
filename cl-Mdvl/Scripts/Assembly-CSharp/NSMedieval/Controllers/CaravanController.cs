using System;
using NSEipix.Base;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.WorldMap;

namespace NSMedieval.Controllers
{
	public class CaravanController : MonoSingleton<CaravanController>
	{
		public delegate void CaravanStateChangedDelegate(CaravanInstance caravanInstance, CaravanState caravanState);

		public delegate void CaravanDelegate(CaravanInstance caravanInstance);

		public delegate void ResourceWithAmountDelegate(CaravanInstance caravanInstance, Resource resource, int amount);

		public CaravanStateChangedDelegate CaravanStateChangedEvent;

		public CaravanDelegate CaravanReturnedHomeEvent;

		public CaravanDelegate CaravanCreatedEvent;

		public CaravanDelegate CaravanFormingStartedEvent;

		public CaravanDelegate CaravanFormingCanceledEvent;

		public ResourceWithAmountDelegate CaravanConsumedFoodEvent;

		public WorkerController.HumanoidHandler SelectedHumanoidInCaravanEvent;

		public CaravanDelegate SelectedCaravanEvent;

		public event Action<ResourcePileInstance> PileAddedToCaravanEvent;

		public event Action<CaravanInstance, FactionInstance> TradeDealMadeEvent;

		public event Action<FactionInstance> TradeDealRemovedEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.PileAddedToCaravanEvent = null;
			this.TradeDealMadeEvent = null;
			this.TradeDealRemovedEvent = null;
		}

		public void CaravanStateChanged(CaravanInstance caravanInstance, CaravanState caravanState)
		{
			CaravanStateChangedEvent?.Invoke(caravanInstance, caravanState);
		}

		public void CaravanConsumedFood(CaravanInstance caravanInstance, Resource resource, int amount)
		{
			CaravanConsumedFoodEvent?.Invoke(caravanInstance, resource, amount);
		}

		public void CaravanReturnedHome(CaravanInstance caravanInstance)
		{
			CaravanReturnedHomeEvent?.Invoke(caravanInstance);
		}

		public void CaravanCreated(CaravanInstance caravanInstance)
		{
			CaravanCreatedEvent?.Invoke(caravanInstance);
		}

		public void CaravanFormingStarted(CaravanInstance caravanInstance)
		{
			CaravanFormingStartedEvent?.Invoke(caravanInstance);
		}

		public void CaravanFormingCanceled(CaravanInstance caravanInstance)
		{
			CaravanFormingCanceledEvent?.Invoke(caravanInstance);
		}

		public void SelectedWorkerInCaravan(HumanoidInstance humanoidInstance)
		{
			SelectedHumanoidInCaravanEvent?.Invoke(humanoidInstance);
		}

		public void SelectedCaravan(CaravanInstance caravanInstance)
		{
			SelectedCaravanEvent?.Invoke(caravanInstance);
		}

		public void PileAddedToCaravan(ResourcePileInstance resourcePileInstance)
		{
			this.PileAddedToCaravanEvent?.Invoke(resourcePileInstance);
		}

		public void TradeDealMade(CaravanInstance caravanInstance, FactionInstance factionInstance)
		{
			this.TradeDealMadeEvent?.Invoke(caravanInstance, factionInstance);
		}

		public void TradeDealRemoved(FactionInstance factionInstance)
		{
			this.TradeDealRemovedEvent?.Invoke(factionInstance);
		}
	}
}
