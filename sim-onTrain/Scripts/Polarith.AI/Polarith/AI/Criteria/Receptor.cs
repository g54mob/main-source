using System.Collections.Generic;
using UnityEngine;

namespace Polarith.AI.Criteria
{
	public class Receptor<T> : IReceptor<T> where T : new()
	{
		[Tooltip("Problem space representation of a receptor.")]
		[SerializeField]
		private T structure = new T();

		[Tooltip("Identification number of this receptor which should be unique within a 'Sensor' instance.")]
		[SerializeField]
		private int id;

		[Tooltip("Holds the IDs of all associated neighbours.")]
		[SerializeField]
		private List<int> neighbourIDs = new List<int>();

		public IList<int> NeighbourIDs => neighbourIDs;

		public int ID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public T Structure
		{
			get
			{
				return structure;
			}
			set
			{
				structure = value;
			}
		}
	}
}
