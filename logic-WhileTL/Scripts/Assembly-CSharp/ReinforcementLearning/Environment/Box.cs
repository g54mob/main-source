namespace ReinforcementLearning.Environment
{
	public class Box
	{
		public int xMin;

		public int xMax;

		public int yMin;

		public int yMax;

		public Box(int xMin, int xMax, int yMin, int yMax)
		{
			this.xMin = xMin;
			this.xMax = xMax;
			this.yMin = yMin;
			this.yMax = yMax;
		}

		public static bool Intersection(Box a, Box b)
		{
			return a.Intersection(b);
		}

		public bool Intersection(Box box)
		{
			Box box2;
			Box box3;
			if (xMin < box.xMin)
			{
				box2 = this;
				box3 = box;
			}
			else
			{
				box2 = box;
				box3 = this;
			}
			if (box3.xMin > box2.xMax)
			{
				return false;
			}
			if (box2.yMin > box3.yMin)
			{
				Box box4 = box2;
				box2 = box3;
				box3 = box4;
			}
			return box3.yMin <= box2.yMax;
		}

		public void Move(int x, int y)
		{
			xMin += x;
			xMax += x;
			yMin += y;
			yMax += y;
		}
	}
}
