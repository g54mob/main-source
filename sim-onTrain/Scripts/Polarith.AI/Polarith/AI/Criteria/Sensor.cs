namespace Polarith.AI.Criteria
{
	public abstract class Sensor<T> : ISensor<T>
	{
		public abstract int ReceptorCount { get; }

		public abstract IReceptor<T> this[int id] { get; }

		public abstract IReceptor<T> AddReceptor();

		public abstract IReceptor<T> InsertReceptor(int id);

		public abstract IReceptor<T> GetReceptor(int id);

		public abstract void RemoveReceptorAt(int id);

		public abstract void ClearReceptors();

		protected virtual void RepairAfterInsert(int id)
		{
			for (int i = id + 1; i < ReceptorCount; i++)
			{
				if (this[i] != null)
				{
					this[i].ID++;
				}
			}
			for (int j = 0; j < ReceptorCount; j++)
			{
				for (int k = 0; k < this[j].NeighbourIDs.Count; k++)
				{
					if (this[j].NeighbourIDs[k] >= 0)
					{
						this[j].NeighbourIDs[k] = ((this[j].NeighbourIDs[k] < id) ? this[j].NeighbourIDs[k] : (this[j].NeighbourIDs[k] + 1));
					}
				}
			}
		}

		protected virtual void RepairBeforeRemove(int id)
		{
			for (int i = id; i < ReceptorCount; i++)
			{
				if (this[i] != null)
				{
					this[i].ID = i - 1;
				}
			}
			for (int j = 0; j < ReceptorCount; j++)
			{
				if (j == id)
				{
					continue;
				}
				for (int k = 0; k < this[j].NeighbourIDs.Count; k++)
				{
					if (this[j].NeighbourIDs[k] == id)
					{
						this[j].NeighbourIDs[k] = -1;
					}
					else
					{
						this[j].NeighbourIDs[k] = ((this[j].NeighbourIDs[k] < id) ? this[j].NeighbourIDs[k] : (this[j].NeighbourIDs[k] - 1));
					}
				}
			}
		}
	}
}
