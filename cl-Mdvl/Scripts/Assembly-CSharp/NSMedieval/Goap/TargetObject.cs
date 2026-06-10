using NSMedieval.State;

namespace NSMedieval.Goap
{
	public readonly struct TargetObject
	{
		private readonly IGoapTargetable objectInstance;

		private readonly Vec3Int reachablePosition;

		public bool IsInitialized { get; }

		public IGoapTargetable ObjectInstance => objectInstance;

		public Vec3Int ReachablePosition => reachablePosition;

		public TargetObject(IGoapTargetable objectInstance, Vec3Int reachablePosition)
		{
			this.objectInstance = objectInstance;
			this.reachablePosition = reachablePosition;
			IsInitialized = true;
		}

		public TargetObject(Vec3Int reachablePosition)
		{
			objectInstance = null;
			this.reachablePosition = reachablePosition;
			IsInitialized = true;
		}

		public TargetObject(IGoapTargetable targetObj)
		{
			if (targetObj == null)
			{
				objectInstance = null;
				reachablePosition = Vec3Int.zero;
				IsInitialized = false;
			}
			else
			{
				objectInstance = targetObj;
				reachablePosition = targetObj.GetGridPosition();
				IsInitialized = true;
			}
		}

		public T GetObjectAs<T>() where T : class, IGoapTargetable
		{
			return objectInstance as T;
		}

		public IReservable GetAsReservable()
		{
			return (IReservable)objectInstance;
		}

		public override string ToString()
		{
			return string.Format("{0} {1}: {2}, {3}: {4}", "TargetObject", "objectInstance", objectInstance, "reachablePosition", reachablePosition);
		}
	}
}
