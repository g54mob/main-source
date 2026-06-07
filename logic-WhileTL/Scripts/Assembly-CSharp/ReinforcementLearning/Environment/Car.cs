using System;

namespace ReinforcementLearning.Environment
{
	public class Car : ICloneable
	{
		public static int height;

		public static int safetyHeight;

		public int x;

		public int xShift;

		public int xDir;

		public int y;

		public int yShift;

		public int speed;

		public int speedShift;

		public int speedDir;

		public bool isPlayer;

		public bool ActionStarted
		{
			get
			{
				if (xDir == 0)
				{
					return speedDir != 0;
				}
				return true;
			}
		}

		public Box Box
		{
			get
			{
				int num = x;
				int num2 = x;
				if (xDir < 0)
				{
					num--;
				}
				else if (xDir > 0)
				{
					num2++;
				}
				return new Box(num, num2, y - height + 1, y);
			}
		}

		public Car(int x, int y, int speed, bool isPlayer = false)
		{
			this.x = x;
			this.y = y;
			this.speed = speed;
			this.isPlayer = isPlayer;
		}

		public object Clone()
		{
			return new Car(x, y, speed, isPlayer)
			{
				xShift = xShift,
				xDir = xDir,
				yShift = yShift,
				speedShift = speedShift,
				speedDir = speedDir
			};
		}
	}
}
