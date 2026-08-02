using System;
using System.Collections.Generic;
using UnityEngine;

namespace Polarith.AI.Move
{
	internal sealed class NavMeshFeeler
	{
		private List<Vector3> directions = new List<Vector3>();

		private NavMeshFeelerType type;

		public int Count => directions.Count;

		public Vector3 this[int i] => directions[i];

		public NavMeshFeeler(NavMeshFeelerType type, int count)
		{
			this.type = type;
			SetCount(count);
		}

		public void SetCount(int count)
		{
			if (count != directions.Count)
			{
				Build(count);
			}
		}

		public void SetType(NavMeshFeelerType type)
		{
			if (this.type != type)
			{
				this.type = type;
				Build(directions.Count);
			}
		}

		private void Build(int count)
		{
			directions.Clear();
			for (int i = 0; i < count; i++)
			{
				switch (type)
				{
				case NavMeshFeelerType.Circle:
					directions.Add(CalcFeelerInCircle(i, count));
					break;
				case NavMeshFeelerType.Fan:
					directions.Add(CalcFeelerInFan(i, count));
					break;
				default:
					directions.Add(CalcFeelerInCircle(i, count));
					break;
				}
			}
		}

		private Vector3 CalcFeelerInCircle(int index, int count)
		{
			float f = (float)index / (float)count * (float)Math.PI * 2f;
			return new Vector3(Mathf.Sin(f), 0f, Mathf.Cos(f));
		}

		private Vector3 CalcFeelerInFan(int index, int count)
		{
			int num = count / 2;
			float num2 = 0f;
			float num3 = (float)Math.PI / 2f / (float)(num + 1);
			if (index >= num)
			{
				num2 = num3 * (float)(index + 2) - (float)Math.PI / 2f;
				if (index == count - 1 && count % 2 != 0)
				{
					num2 = 0f;
				}
			}
			else
			{
				num2 = num3 * (float)(index + 1) - (float)Math.PI / 2f;
			}
			return new Vector3(Mathf.Sin(num2), 0f, Mathf.Cos(num2));
		}
	}
}
