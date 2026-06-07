using System.Collections.Generic;
using UnityEngine;

namespace DV.Simulation.Brake
{
	public class Brakeset
	{
		private enum LapStates
		{
			Idle = 0,
			Release = 1,
			Apply = 2,
			ApplyEmergency = 3
		}

		public static readonly List<Brakeset> allSets = new List<Brakeset>();

		public readonly List<BrakeSystem> cars;

		public float pipeVolume;

		public float pipePressure = 1f;

		public bool isLeaking;

		public bool anyHandbrakeApplied;

		public int numEnabledTrainBrakeValves;

		public readonly BrakeSystem firstCar;

		public readonly BrakeSystem lastCar;

		public int id;

		private static int idCounter = 0;

		public static event HoseConnectionChangedDelegate HoseConnectionChanged;

		public static event BoolStateChangedDelegate BrakesetsChanged;

		public event BoolStateChangedDelegate LeakStateChanged;

		public event BoolStateChangedDelegate HandbrakesStateChanged;

		public event BoolStateChangedDelegate TrainBrakeCutoutStateChanged;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void StaticReload()
		{
			allSets.Clear();
			Brakeset.HoseConnectionChanged = null;
			Brakeset.BrakesetsChanged = null;
			idCounter = 0;
		}

		private Brakeset(List<BrakeSystem> cars)
		{
			this.cars = cars;
			pipeVolume = (float)cars.Count * 10f;
			firstCar = cars[0];
			lastCar = cars[cars.Count - 1];
			id = idCounter++;
		}

		public void Destroy()
		{
			if (cars.Count != 1)
			{
				Debug.LogError($"Can only destroy brake-set with single car (got {cars.Count})");
				return;
			}
			BrakeSystem brakeSystem = cars[0];
			if (brakeSystem.Front.IsHoseConnected)
			{
				Debug.LogError("Can only destroy unconnected brake-sets (front hose is connected)", brakeSystem);
			}
			else if (brakeSystem.Rear.IsHoseConnected)
			{
				Debug.LogError("Can only destroy unconnected brake-sets (rear hose is connected)", brakeSystem);
			}
			else
			{
				allSets.Remove(this);
			}
		}

		public HoseAndCock GetEndmost(bool front)
		{
			BrakeSystem brakeSystem;
			if (cars.Count == 1)
			{
				brakeSystem = firstCar;
				if (!front)
				{
					return brakeSystem.Rear;
				}
				return brakeSystem.Front;
			}
			brakeSystem = (front ? firstCar : lastCar);
			if (!brakeSystem.Front.IsFullyConnected)
			{
				return brakeSystem.Front;
			}
			return brakeSystem.Rear;
		}

		public static void Create(BrakeSystem initialCar)
		{
			Brakeset brakeset = new Brakeset(new List<BrakeSystem> { initialCar });
			allSets.Add(brakeset);
			initialCar.brakeset = brakeset;
			initialCar.indexInBrakeset = 0;
		}

		public static void Merge(BrakeSystem a, BrakeSystem b)
		{
			bool num = a.indexInBrakeset == 0;
			bool flag = b.indexInBrakeset != 0;
			if (num)
			{
				a.brakeset.cars.Reverse();
			}
			if (flag)
			{
				b.brakeset.cars.Reverse();
			}
			a.brakeset.cars.AddRange(b.brakeset.cars);
			Brakeset brakeset = new Brakeset(a.brakeset.cars);
			brakeset.pipeVolume = a.brakeset.pipeVolume + b.brakeset.pipeVolume;
			brakeset.pipePressure = Mathf.Lerp(a.brakeset.pipePressure, b.brakeset.pipePressure, b.brakeset.pipeVolume / brakeset.pipeVolume);
			allSets.Remove(a.brakeset);
			allSets.Remove(b.brakeset);
			allSets.Add(brakeset);
			for (int i = 0; i < brakeset.cars.Count; i++)
			{
				BrakeSystem brakeSystem = brakeset.cars[i];
				brakeSystem.brakeset = brakeset;
				brakeSystem.indexInBrakeset = i;
			}
			Brakeset.BrakesetsChanged?.Invoke(newState: true);
		}

		public static void Split(BrakeSystem carA, BrakeSystem carB)
		{
			if (carA.indexInBrakeset > carB.indexInBrakeset)
			{
				BrakeSystem brakeSystem = carB;
				BrakeSystem brakeSystem2 = carA;
				carA = brakeSystem;
				carB = brakeSystem2;
			}
			List<BrakeSystem> list = carA.brakeset.cars;
			int count = list.Count - carB.indexInBrakeset;
			List<BrakeSystem> range = list.GetRange(carB.indexInBrakeset, count);
			list.RemoveRange(carB.indexInBrakeset, count);
			Brakeset brakeset = new Brakeset(list);
			Brakeset brakeset2 = new Brakeset(range);
			brakeset.pipePressure = (brakeset2.pipePressure = carA.brakeset.pipePressure);
			allSets.Remove(carA.brakeset);
			allSets.Add(brakeset);
			allSets.Add(brakeset2);
			for (int i = 0; i < brakeset.cars.Count; i++)
			{
				BrakeSystem brakeSystem3 = brakeset.cars[i];
				brakeSystem3.brakeset = brakeset;
				brakeSystem3.indexInBrakeset = i;
			}
			for (int j = 0; j < brakeset2.cars.Count; j++)
			{
				BrakeSystem brakeSystem4 = brakeset2.cars[j];
				brakeSystem4.brakeset = brakeset2;
				brakeSystem4.indexInBrakeset = j;
			}
			Brakeset.BrakesetsChanged?.Invoke(newState: false);
		}

		private void BalanceMainReservoirs()
		{
			for (int i = 0; i < cars.Count - 1; i++)
			{
				if (!cars[i].hasCompressor || !cars[i].hasMainResConnections)
				{
					continue;
				}
				bool flag = false;
				int j = i + 1;
				float num = cars[i].MainResAirMass;
				float num2 = cars[i].mainResVolume;
				for (; j < cars.Count && cars[j].hasMainResConnections; j++)
				{
					if (cars[j].hasCompressor)
					{
						flag = true;
						num += cars[j].MainResAirMass;
						num2 += cars[j].mainResVolume;
					}
				}
				if (flag)
				{
					float mainReservoirPressureUnsmoothed = num / num2;
					for (int k = i; k < j; k++)
					{
						if (cars[k].hasCompressor)
						{
							cars[k].mainReservoirPressureUnsmoothed = mainReservoirPressureUnsmoothed;
						}
					}
				}
				i = j + 1;
			}
		}

		private void Tick(float dt)
		{
			HoseAndCock endmost = GetEndmost(front: true);
			HoseAndCock endmost2 = GetEndmost(front: false);
			bool isOpenToAtmosphere = endmost.IsOpenToAtmosphere;
			bool isOpenToAtmosphere2 = endmost2.IsOpenToAtmosphere;
			bool flag = isLeaking;
			isLeaking = isOpenToAtmosphere || isOpenToAtmosphere2;
			if (isLeaking != flag)
			{
				this.LeakStateChanged?.Invoke(isLeaking);
			}
			float target = 0f;
			float target2 = 0f;
			if (isLeaking)
			{
				float p = pipePressure;
				BrakeSystem.VentToAtmosphere(dt, ref p, pipeVolume, BrakeSystemConsts.ANGLE_COCK_EQ_SPEED_MULTIPLIER);
				if (p < 1.05f)
				{
					p = 1f;
				}
				float num = Mathf.Abs(p - pipePressure) / (dt * 6f);
				pipePressure = p;
				if (isOpenToAtmosphere && isOpenToAtmosphere2)
				{
					target = (target2 = num * 0.5f);
				}
				else if (isOpenToAtmosphere)
				{
					target = num;
				}
				else
				{
					target2 = num;
				}
			}
			endmost.exhaustFlow = Mathf.SmoothDamp(endmost.exhaustFlow, target, ref endmost.exhaustFlowRef, 0.1f);
			endmost2.exhaustFlow = Mathf.SmoothDamp(endmost2.exhaustFlow, target2, ref endmost2.exhaustFlowRef, 0.1f);
			BalanceMainReservoirs();
			bool flag2 = anyHandbrakeApplied;
			anyHandbrakeApplied = false;
			int num2 = 0;
			foreach (BrakeSystem car in cars)
			{
				if (car.handbrakePosition > 0f)
				{
					anyHandbrakeApplied = true;
				}
				if (car.hasTrainBrake && car.trainBrakeCutout)
				{
					num2++;
				}
				car.Tick(dt);
			}
			if (anyHandbrakeApplied != flag2)
			{
				this.HandbrakesStateChanged?.Invoke(anyHandbrakeApplied);
			}
			if (num2 != numEnabledTrainBrakeValves)
			{
				numEnabledTrainBrakeValves = num2;
				this.TrainBrakeCutoutStateChanged?.Invoke(num2 != 1);
			}
		}

		public static void TickAll(float dt)
		{
			foreach (Brakeset allSet in allSets)
			{
				allSet.Tick(dt);
			}
		}

		internal static void FireHoseConnectionChanged(bool connected, HoseAndCock a, HoseAndCock b)
		{
			Brakeset.HoseConnectionChanged?.Invoke(connected, a, b);
		}
	}
}
