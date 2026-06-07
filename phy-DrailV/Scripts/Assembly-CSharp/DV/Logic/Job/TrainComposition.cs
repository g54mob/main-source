using System.Collections.Generic;
using System.Linq;

namespace DV.Logic.Job
{
	public class TrainComposition
	{
		public List<Car> cars;

		public TrainComposition(Car car)
		{
			cars = new List<Car>();
			cars.Add(car);
			TrainCompositionController.Instance.AddTrainComposition(this);
		}

		public TrainComposition(List<Car> cars)
		{
			this.cars = cars;
			TrainCompositionController.Instance.AddTrainComposition(this);
		}

		public Car GetCarAtIndex(int index)
		{
			return cars.ElementAtOrDefault(index);
		}

		public Car GetCarByID(string ID)
		{
			return cars.Where((Car car) => car.ID == ID).FirstOrDefault();
		}

		public bool ContainsCar(Car car)
		{
			return cars.Contains(car);
		}

		public bool ContainsCar(string ID)
		{
			return cars.Where((Car car) => car.ID == ID).Any();
		}

		public bool CheckOrderOfCars(List<string> carIDs)
		{
			if (carIDs.Count != cars.Count)
			{
				return false;
			}
			for (int i = 0; i < cars.Count; i++)
			{
				if (cars[i].ID != carIDs[i])
				{
					return false;
				}
			}
			return true;
		}

		public void AddTrainCompositionAtFront(TrainComposition trainComposition)
		{
			cars.InsertRange(0, trainComposition.cars);
			TrainCompositionController.Instance.RemoveTrainComposition(trainComposition);
		}

		public void AddTrainCompositionAtBack(TrainComposition trainComposition)
		{
			cars.AddRange(trainComposition.cars);
			TrainCompositionController.Instance.RemoveTrainComposition(trainComposition);
		}

		public void AddOnFront(Car car)
		{
			cars.Insert(0, car);
		}

		public void AddOnBack(Car car)
		{
			cars.Add(car);
		}

		public TrainComposition RemoveFromFront()
		{
			Car car = cars.First();
			cars.RemoveAt(0);
			return new TrainComposition(car);
		}

		public TrainComposition RemoveFromBack()
		{
			Car car = cars.Last();
			cars.RemoveAt(cars.Count - 1);
			return new TrainComposition(car);
		}

		public TrainComposition RemoveFromIndexToFront(int index)
		{
			List<Car> range = cars.GetRange(0, index + 1);
			cars.RemoveRange(0, index + 1);
			return new TrainComposition(range);
		}

		public TrainComposition RemoveFromIndexToBack(int index)
		{
			List<Car> range = cars.GetRange(index, cars.Count - index);
			cars.RemoveRange(index, cars.Count - index);
			return new TrainComposition(range);
		}

		public bool AreAllCarsOnTrack(Track track)
		{
			foreach (Car car in cars)
			{
				if (car.CurrentTrack != track)
				{
					return false;
				}
			}
			return true;
		}
	}
}
