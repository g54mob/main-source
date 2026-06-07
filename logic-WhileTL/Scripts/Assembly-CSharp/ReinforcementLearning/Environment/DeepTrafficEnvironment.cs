using System;
using UnityEngine;

namespace ReinforcementLearning.Environment
{
	public class DeepTrafficEnvironment : IEnvironment<DeepTrafficEnvPresets, DeepTrafficState, CellObjects[], DeepTrafficAction>
	{
		public readonly DeepTrafficEnvPresets presets;

		private DeepTrafficState state;

		public System.Random random;

		public Action<DeepTrafficState> RenderFunction;

		public DeepTrafficState FullState => state;

		public float PlayerSpeed => (float)state.player.speed + (float)state.player.speedShift / (float)presets.changeSpeedThreshold * (float)state.player.speedDir;

		public int StateSize => presets.PatchesAhead * (2 * presets.LanesSide + 1) + presets.PatchesBehind * (2 * presets.LanesSide + 1) - Mathf.Min(presets.carHeight, presets.PatchesBehind);

		public CellObjects[] State
		{
			get
			{
				CellObjects[] array = new CellObjects[presets.PatchesAhead * (2 * presets.LanesSide + 1) + presets.PatchesBehind * (2 * presets.LanesSide + 1) - Mathf.Min(presets.carHeight, presets.PatchesBehind)];
				int num = state.player.x - presets.LanesSide;
				int num2 = state.player.x + presets.LanesSide;
				int num3 = state.player.y - presets.PatchesBehind + 1;
				int num4 = state.player.y + presets.PatchesAhead;
				CellObjects[,] array2 = new CellObjects[num2 - num + 1, num4 - num3 + 1];
				Car[] dummyCars = state.dummyCars;
				foreach (Car car in dummyCars)
				{
					if (IsInSegment(num, num2, car.x) && car.y >= num3)
					{
						int num5 = car.x - num;
						int num6 = Math.Min(car.y, num4) - num3;
						int num7 = Math.Max(car.y - presets.carHeight + 1, num3) - num3;
						for (int num8 = num6; num8 >= num7; num8--)
						{
							array2[num5, num8] = CellObjects.car;
						}
					}
					if (car.xDir == 0)
					{
						continue;
					}
					car.x += car.xDir;
					if (IsInSegment(num, num2, car.x) && car.y >= num3)
					{
						int num9 = car.x - num;
						int num10 = Math.Min(car.y, num4) - num3;
						int num11 = Math.Max(car.y - presets.carHeight + 1, num3) - num3;
						for (int num12 = num10; num12 >= num11; num12--)
						{
							array2[num9, num12] = CellObjects.car;
						}
					}
					car.x -= car.xDir;
				}
				for (int j = num; j <= num2; j++)
				{
					for (int k = num3; k <= num4; k++)
					{
						if (!IsInSegment(0, presets.width - 1, j))
						{
							array2[j - num, k - num3] = CellObjects.wall;
						}
					}
				}
				int num13 = 0;
				for (int l = num3; l <= num4; l++)
				{
					for (int m = num; m <= num2; m++)
					{
						if (m != state.player.x || !IsInSegment(state.player.y - Car.height + 1, state.player.y, l))
						{
							array[num13] = array2[m - num, l - num3];
							num13++;
						}
					}
				}
				return array;
			}
		}

		public long ActionsNumber => 5L;

		public DeepTrafficEnvironment(DeepTrafficEnvPresets presets, System.Random random)
		{
			this.presets = presets;
			Car.height = this.presets.carHeight;
			Car.safetyHeight = this.presets.carSafetyHeight;
			this.random = random;
			Init();
		}

		private bool IsInSegment(int xMin, int xMax, int x)
		{
			if (x >= xMin)
			{
				return x <= xMax;
			}
			return false;
		}

		private bool IsInBox(int xMin, int xMax, int yMin, int yMax, int x, int y)
		{
			if (IsInSegment(xMin, xMax, x))
			{
				return IsInSegment(yMin, yMax, y);
			}
			return false;
		}

		public void Render()
		{
			RenderFunction(state);
		}

		public CellObjects[] Reset()
		{
			Init();
			return State;
		}

		private void GenerateDummyCar(int carsGenerated)
		{
			int num = 0;
			int num2;
			int num3;
			bool flag;
			do
			{
				num++;
				num2 = random.Next(presets.width);
				num3 = random.Next(presets.height);
				flag = true;
				if (num == 20)
				{
					if (presets.differentWays)
					{
						do
						{
							flag = true;
							num2 = random.Next(presets.width);
							for (int i = 0; i < carsGenerated; i++)
							{
								Car car = state.dummyCars[i];
								flag &= car.x != num2;
							}
						}
						while (!flag);
					}
					state.dummyCars[carsGenerated] = new Car(num2, -10, presets.baseCarSpeed);
					return;
				}
				for (int j = 0; j < carsGenerated; j++)
				{
					Car car2 = state.dummyCars[j];
					flag = ((!presets.differentWays) ? (flag & (car2.x != num2 || Math.Abs(car2.y - num3) >= ((!presets.sparseCars) ? 1 : 2) * (Car.height + Car.safetyHeight))) : (flag & (car2.x != num2 && (Math.Abs(car2.x - num2) > 1 || Math.Abs(car2.y - num3) >= ((!presets.sparseCars) ? 1 : 2) * (Car.height + Car.safetyHeight)))));
				}
			}
			while (!(flag & (state.player.x != num2 || Math.Abs(state.player.y - num3) >= Car.height + Car.safetyHeight)));
			state.dummyCars[carsGenerated] = new Car(num2, num3, presets.baseCarSpeed);
		}

		private void Init()
		{
			state = new DeepTrafficState
			{
				player = new Car(presets.width / 2, presets.height / 3, presets.baseCarSpeed, isPlayer: true),
				dummyCars = new Car[presets.carNumber]
			};
			for (int i = 0; i < presets.carNumber; i++)
			{
				GenerateDummyCar(i);
			}
		}

		public Episode<CellObjects[], DeepTrafficAction> Step(DeepTrafficAction action)
		{
			Episode<CellObjects[], DeepTrafficAction> obj = new Episode<CellObjects[], DeepTrafficAction>
			{
				state = State,
				action = action,
				isDone = false
			};
			GetAction(action, state.player);
			Update();
			float num = state.player.speed - presets.baseCarSpeed;
			obj.nextState = State;
			obj.reward = num;
			return obj;
		}

		private void GetAction(DeepTrafficAction action, Car car)
		{
			switch (action)
			{
			case DeepTrafficAction.acelerate:
				StartSpeedChange(car, 1);
				break;
			case DeepTrafficAction.decelerate:
				StartSpeedChange(car, -1);
				break;
			case DeepTrafficAction.goLeft:
				StartTurn(car, -1);
				break;
			case DeepTrafficAction.goRight:
				StartTurn(car, 1);
				break;
			}
		}

		private void StartTurn(Car car, int dir)
		{
			if (car.x + dir >= 0 && car.x + dir < presets.width && car.xDir == 0)
			{
				bool flag = true;
				Car[] dummyCars = state.dummyCars;
				foreach (Car car2 in dummyCars)
				{
					flag &= (car.x + dir != car2.x && (car.x + 2 * dir != car2.x || car2.xDir != -dir)) || ((car.y > car2.y || car.y + Car.safetyHeight < car2.y - presets.carHeight + 1) && (car.y <= car2.y || car2.y + Car.safetyHeight < car.y - presets.carHeight + 1));
				}
				if (flag & ((car.x + dir != state.player.x && (car.x + 2 * dir != state.player.x || state.player.xDir != -dir)) || (car.y + Car.safetyHeight < state.player.y - presets.carHeight + 1 && state.player.y + Car.safetyHeight < car.y - presets.carHeight + 1)))
				{
					car.xDir = dir;
					car.speedDir = (car.speedShift = 0);
				}
			}
		}

		private void StartSpeedChange(Car car, int dir)
		{
			if (car.speed + dir > presets.maxCarSpeed || car.speed + dir < 0 || car.xDir != 0)
			{
				return;
			}
			if (dir == 1)
			{
				Box box = new Box(car.x, car.x, car.y, car.y + Car.safetyHeight);
				Car[] dummyCars = state.dummyCars;
				foreach (Car car2 in dummyCars)
				{
					if (car != car2 && box.Intersection(car2.Box) && car2.speed == car.speed && car2.speedDir != 1)
					{
						return;
					}
				}
				if (car != state.player && box.Intersection(state.player.Box) && state.player.speed == car.speed && state.player.speedDir != 1)
				{
					return;
				}
			}
			car.speedDir = dir;
		}

		private void BoundCarSpeed(int num, bool[] used)
		{
			Car car;
			if (num == -1)
			{
				car = state.player;
			}
			else
			{
				if (used[num])
				{
					return;
				}
				car = state.dummyCars[num];
				used[num] = true;
			}
			Box box = new Box(car.x, car.x, car.y, car.y + Car.safetyHeight);
			if (car.xDir < 0)
			{
				box.xMin--;
			}
			else if (car.xDir > 0)
			{
				box.xMax++;
			}
			for (int i = 0; i < presets.carNumber; i++)
			{
				if (box.Intersection(state.dummyCars[i].Box))
				{
					BoundCarSpeed(i, used);
					if (state.dummyCars[i].speed < car.speed)
					{
						car.speed = state.dummyCars[i].speed;
						car.speedShift = state.dummyCars[i].speedShift;
						car.speedDir = state.dummyCars[i].speedDir;
					}
					else if (state.dummyCars[i].speed == car.speed && state.dummyCars[i].speedDir < car.speedDir)
					{
						car.speedShift = state.dummyCars[i].speedShift;
						car.speedDir = state.dummyCars[i].speedDir;
					}
					else if (state.dummyCars[i].speed == car.speed && state.dummyCars[i].speedDir == car.speedDir)
					{
						car.speedShift = state.dummyCars[i].speedShift;
					}
				}
			}
			if (box.Intersection(state.player.Box))
			{
				if (state.player.speed < car.speed)
				{
					car.speed = state.player.speed;
					car.speedShift = state.player.speedShift;
					car.speedDir = state.player.speedDir;
				}
				else if (state.player.speed == car.speed && state.player.speedDir < car.speedDir)
				{
					car.speedShift = state.player.speedShift;
					car.speedDir = state.player.speedDir;
				}
				else if (state.player.speed == car.speed && state.player.speedDir == car.speedDir)
				{
					car.speedShift = state.player.speedShift;
				}
			}
		}

		private void BoundAllCarsSpeed()
		{
			bool[] used = new bool[presets.carNumber];
			BoundCarSpeed(-1, used);
			for (int i = 0; i < presets.carNumber; i++)
			{
				BoundCarSpeed(i, used);
			}
		}

		private int GenerateNewHeight(Car carToUpdate)
		{
			int x = carToUpdate.x;
			int num = 0;
			int num2;
			bool flag;
			do
			{
				num++;
				num2 = random.Next(presets.height + Car.height + Car.safetyHeight - 1, presets.height + Car.height + Car.safetyHeight - 1 + presets.carHeight * 4 * ((!presets.sparseCars) ? 1 : 2));
				flag = true;
				Car[] dummyCars = state.dummyCars;
				foreach (Car car in dummyCars)
				{
					if (car != carToUpdate)
					{
						flag = ((!presets.differentWays) ? (flag & (car.x != x || Math.Abs(car.y - num2) >= ((!presets.sparseCars) ? 1 : 2) * (Car.height + Car.safetyHeight))) : (flag & (Math.Abs(car.y - num2) >= ((!presets.sparseCars) ? 1 : 2) * (Car.height + Car.safetyHeight))));
					}
				}
				flag &= state.player.x != x || Math.Abs(state.player.y - num2) >= Car.height + Car.safetyHeight;
				if (num == 20)
				{
					return -5;
				}
			}
			while (!flag);
			return num2;
		}

		private void Update(Car car)
		{
			if (car.xDir != 0)
			{
				car.xShift++;
			}
			if (car.xShift == presets.changeXThreshold)
			{
				car.x += car.xDir;
				car.xShift = 0;
				car.xDir = 0;
			}
			if (car.speedDir != 0)
			{
				car.speedShift++;
			}
			if (car.speedShift == presets.changeSpeedThreshold)
			{
				car.speed += car.speedDir;
				car.speedShift = 0;
				car.speedDir = 0;
			}
			if (car.isPlayer)
			{
				Car[] dummyCars = state.dummyCars;
				for (int i = 0; i < dummyCars.Length; i++)
				{
					dummyCars[i].yShift -= car.speed;
				}
				return;
			}
			car.yShift += car.speed;
			if (car.yShift >= presets.changeYThreshold)
			{
				int num = car.yShift / presets.changeYThreshold;
				car.yShift %= presets.changeYThreshold;
				car.y += num;
				if (car.y > presets.height + Car.height + Car.safetyHeight - 1 + presets.carHeight * 6 * ((!presets.sparseCars) ? 1 : 2))
				{
					car.xDir = (car.xShift = (car.speedDir = (car.speedShift = (car.yShift = 0))));
					car.speed = presets.baseCarSpeed;
					if (!presets.differentWays)
					{
						car.x = random.Next(presets.width);
					}
					car.y = GenerateNewHeight(car);
				}
			}
			if (-car.yShift < presets.changeYThreshold)
			{
				return;
			}
			int num2 = -car.yShift / presets.changeYThreshold;
			car.yShift = -(-car.yShift % presets.changeYThreshold);
			car.y -= num2;
			if (car.y < -10)
			{
				car.xDir = (car.xShift = (car.speedDir = (car.speedShift = (car.yShift = 0))));
				car.speed = presets.baseCarSpeed;
				if (!presets.differentWays)
				{
					car.x = random.Next(presets.width);
				}
				car.y = GenerateNewHeight(car);
			}
		}

		private void Update()
		{
			Update(state.player);
			Car[] dummyCars = state.dummyCars;
			foreach (Car car in dummyCars)
			{
				GetAction(GetBotAction(), car);
				Update(car);
			}
			BoundAllCarsSpeed();
		}

		private DeepTrafficAction GetBotAction()
		{
			return DeepTrafficAction.noAction;
		}
	}
}
