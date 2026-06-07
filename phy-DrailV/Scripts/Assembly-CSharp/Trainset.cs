using System.Collections.Generic;
using UnityEngine;

public class Trainset
{
	public delegate void TrainsetsChangedDelegate(bool merged);

	public static readonly List<Trainset> allSets = new List<Trainset>();

	public readonly List<TrainCar> cars;

	public readonly List<int> locoIndices;

	public readonly TrainCar firstCar;

	public readonly TrainCar lastCar;

	public int id;

	private static int idCounter = 0;

	public static event TrainsetsChangedDelegate TrainsetsChanged;

	private Trainset(List<TrainCar> cars)
	{
		this.cars = cars;
		id = idCounter++;
		locoIndices = new List<int>();
		for (int i = 0; i < cars.Count; i++)
		{
			if (cars[i].IsLoco)
			{
				locoIndices.Add(i);
			}
		}
		firstCar = cars[0];
		lastCar = cars[cars.Count - 1];
	}

	public void Destroy()
	{
		if (cars.Count != 1)
		{
			Debug.LogError($"Can only destroy train-set with single car (got {cars.Count})");
		}
		else
		{
			allSets.Remove(this);
		}
	}

	public Coupler GetEndmost(bool front)
	{
		if (cars.Count == 1)
		{
			TrainCar trainCar = cars[0];
			if (!front)
			{
				return trainCar.rearCoupler;
			}
			return trainCar.frontCoupler;
		}
		TrainCar trainCar2 = (front ? firstCar : lastCar);
		if (!trainCar2.frontCoupler.IsCoupled())
		{
			return trainCar2.frontCoupler;
		}
		return trainCar2.rearCoupler;
	}

	public static void Create(TrainCar initialCar)
	{
		Trainset trainset = new Trainset(new List<TrainCar> { initialCar });
		allSets.Add(trainset);
		initialCar.trainset = trainset;
		initialCar.indexInTrainset = 0;
	}

	public static void Merge(TrainCar a, TrainCar b)
	{
		bool num = a.indexInTrainset == 0;
		bool flag = b.indexInTrainset != 0;
		if (num)
		{
			a.trainset.cars.Reverse();
		}
		if (flag)
		{
			b.trainset.cars.Reverse();
		}
		a.trainset.cars.AddRange(b.trainset.cars);
		b.trainset.cars.Clear();
		Trainset trainset = new Trainset(a.trainset.cars);
		allSets.Remove(a.trainset);
		allSets.Remove(b.trainset);
		allSets.Add(trainset);
		for (int i = 0; i < trainset.cars.Count; i++)
		{
			TrainCar trainCar = trainset.cars[i];
			trainCar.trainset = trainset;
			trainCar.indexInTrainset = i;
		}
		Trainset.TrainsetsChanged?.Invoke(merged: true);
	}

	public static void Split(TrainCar carA, TrainCar carB)
	{
		if (carA.indexInTrainset > carB.indexInTrainset)
		{
			TrainCar trainCar = carB;
			TrainCar trainCar2 = carA;
			carA = trainCar;
			carB = trainCar2;
		}
		List<TrainCar> list = carA.trainset.cars;
		int count = list.Count - carB.indexInTrainset;
		List<TrainCar> range = list.GetRange(carB.indexInTrainset, count);
		list.RemoveRange(carB.indexInTrainset, count);
		Trainset trainset = new Trainset(list);
		Trainset trainset2 = new Trainset(range);
		allSets.Remove(carA.trainset);
		allSets.Add(trainset);
		allSets.Add(trainset2);
		for (int i = 0; i < trainset.cars.Count; i++)
		{
			TrainCar trainCar3 = trainset.cars[i];
			trainCar3.trainset = trainset;
			trainCar3.indexInTrainset = i;
		}
		for (int j = 0; j < trainset2.cars.Count; j++)
		{
			TrainCar trainCar4 = trainset2.cars[j];
			trainCar4.trainset = trainset2;
			trainCar4.indexInTrainset = j;
		}
		Trainset.TrainsetsChanged?.Invoke(merged: false);
	}
}
