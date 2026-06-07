using System;
using UnityEngine;

public class TransportBox
{
	[Serializable]
	public class SaveBox
	{
		public IProductOrder Order;

		public uint From;

		public uint To;

		public int Point;

		public int APoint;

		public float Progress;

		public float Speed = 1f;

		public SaveBox()
		{
		}

		public SaveBox(TransportBox box)
		{
			Order = box.Order;
			From = ((box.From != null) ? box.From.Parent.DID : 0u);
			To = ((box.To != null) ? box.To.Parent.DID : 0u);
			Progress = box.Progress;
			Point = box.CPoint;
			APoint = box.APoint;
			Speed = box.Speed;
		}
	}

	public IProductOrder Order;

	public Conveyor From;

	public Conveyor To;

	public int CPoint;

	public int APoint;

	public int LastFloor = -2;

	public float Progress;

	public float Wait;

	public float Speed = 1f;

	public Quaternion Rotation;

	public bool Destroyed;

	public SaveBox ToSerializable()
	{
		return new SaveBox(this);
	}

	public void ClearOrder()
	{
		if (Order != null)
		{
			Order.RemoveFromStorage();
		}
	}

	public bool Update(float delta)
	{
		if (From == null)
		{
			if (To == null)
			{
				ClearOrder();
				return true;
			}
			From = To;
			To = null;
			if (From.CurrentBoxes[0] != null && From.CurrentBoxes[0] != this)
			{
				ClearOrder();
				return true;
			}
			PutOnConveyor(From, 0);
			CPoint = 0;
			Progress = 0f;
		}
		if (CPoint >= From.ConveyorPoints.Length - 1 && To == null)
		{
			To = From.GetOutput(Order, 0, true, Wait);
			if (To == null)
			{
				Wait += delta;
				return From.NotifyBox(this, true);
			}
			Wait = 0f;
			ClearConveyor(From);
			PutOnConveyor(To, 0);
			if (To.InstaNotify && To.NotifyBox(this, true))
			{
				return true;
			}
		}
		if (CPoint + 1 < From.ConveyorPoints.Length)
		{
			TransportBox transportBox = From.CurrentBoxes[GetNextPoint(1)];
			if (transportBox != null && transportBox != this)
			{
				Progress = 0f;
				return false;
			}
			int nextPoint = GetNextPoint();
			if (APoint != nextPoint && From.CurrentBoxes[nextPoint] == null)
			{
				ClearConveyors();
				PutOnConveyor(From, nextPoint);
			}
		}
		float num = Speed;
		if (From.Speed >= 0f)
		{
			num = (Speed = From.Speed);
		}
		Progress += delta * num * From.Parent.BoostValue * 1.5f;
		while (Progress > 1f)
		{
			if (CPoint + 1 < From.ConveyorPoints.Length)
			{
				int num2 = CPoint + 1;
				if (From.CurrentBoxes[num2] != null && From.CurrentBoxes[num2] != this)
				{
					Progress = 0f;
					return false;
				}
				ClearConveyor(From);
				CPoint = num2;
				PutOnConveyor(From, num2);
			}
			else
			{
				if (To == null)
				{
					if (From.CurrentBoxes[GetNextPoint()] != this)
					{
						ClearOrder();
						return true;
					}
					Progress = 0f;
					return From.NotifyBox(this, true);
				}
				ClearConveyor(To);
				ClearConveyor(From);
				CPoint = 0;
				APoint = 0;
				From = To;
				if (From.NotifyBox(this, false))
				{
					return true;
				}
				To = ((From.ConveyorPoints.Length == 1) ? From.GetOutput(Order, 0, true, Wait) : null);
				if (To != null)
				{
					Wait = 0f;
					ClearConveyor(From);
					PutOnConveyor(To, 0);
					if (To.InstaNotify && To.NotifyBox(this, true))
					{
						return true;
					}
				}
				else
				{
					Wait += delta;
					int nextPoint2 = GetNextPoint();
					if (From.CurrentBoxes[nextPoint2] == null || From.CurrentBoxes[nextPoint2] == this)
					{
						PutOnConveyor(From, nextPoint2);
					}
					else
					{
						if (nextPoint2 == 0 || (From.CurrentBoxes[0] != null && From.CurrentBoxes[0] != this))
						{
							ClearOrder();
							return true;
						}
						PutOnConveyor(From, 0);
					}
				}
			}
			Progress -= 1f;
		}
		return false;
	}

	public void PutOnConveyor(Conveyor c, int point)
	{
		APoint = point;
		c.CurrentBoxes[APoint] = this;
	}

	public int GetNextPoint(int offset = 0)
	{
		int num = CPoint + offset;
		if (To == null)
		{
			if (From == null)
			{
				return num;
			}
			return Mathf.Min(num + 1, From.ConveyorPoints.Length - 1);
		}
		if (From == null)
		{
			return 0;
		}
		return num;
	}

	public void ClearConveyor(Conveyor con)
	{
		if (!(con != null))
		{
			return;
		}
		for (int i = 0; i < con.CurrentBoxes.Length; i++)
		{
			if (con.CurrentBoxes[i] == this)
			{
				con.CurrentBoxes[i] = null;
			}
		}
	}

	public void ClearConveyors()
	{
		ClearConveyor(From);
		ClearConveyor(To);
	}

	public int GetFloor()
	{
		return Mathf.FloorToInt(GetPosition().y / 2f + 0.01f);
	}

	public Vector3 GetPosition()
	{
		if (From == null)
		{
			if (!(To == null))
			{
				return To.GetCachedPoint(CPoint);
			}
			return Vector3.zero;
		}
		if (To == null)
		{
			if (CPoint + 1 < From.ConveyorPoints.Length)
			{
				return Vector3.Lerp(From.GetCachedPoint(CPoint), From.GetCachedPoint(CPoint + 1), Progress);
			}
			return From.GetCachedPoint(CPoint);
		}
		Vector3 cachedPoint = From.GetCachedPoint(CPoint);
		Vector3 b = ((CPoint + 1 < From.ConveyorPoints.Length) ? From.GetCachedPoint(CPoint + 1) : To.GetCachedPoint(0));
		return Vector3.Lerp(cachedPoint, b, Progress);
	}

	public TransportBox()
	{
		Rotation = Quaternion.Euler(0f, Utilities.RandomValue * 360f, 0f);
	}

	public void Clear()
	{
		Order = null;
		From = null;
		To = null;
		Progress = 0f;
		CPoint = 0;
		APoint = 0;
		LastFloor = -2;
		Destroyed = false;
		Wait = 0f;
		Speed = 1f;
	}
}
