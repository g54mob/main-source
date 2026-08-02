using System.Collections.Generic;
using Polarith.AI.Criteria;
using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class Sensor : Sensor<Structure>
	{
		[Tooltip("All contained receptor instances forming the shape of this sensor.")]
		[SerializeField]
		protected List<Receptor> receptors = new List<Receptor>();

		public abstract Sensor Clone { get; }

		public abstract Quaternion Rotation { get; }

		public abstract Quaternion InverseRotation { get; }

		public abstract VectorProjectionType ProjectionMode { get; }

		public override int ReceptorCount => receptors.Count;

		public override IReceptor<Structure> this[int id] => receptors[id];

		public override IReceptor<Structure> AddReceptor()
		{
			Receptor receptor = new Receptor();
			receptor.ID = receptors.Count;
			receptors.Add(receptor);
			return receptor;
		}

		public override IReceptor<Structure> InsertReceptor(int id)
		{
			Receptor receptor = new Receptor();
			receptor.ID = id;
			receptors.Insert(id, receptor);
			RepairAfterInsert(id);
			return receptor;
		}

		public override IReceptor<Structure> GetReceptor(int id)
		{
			return receptors[id];
		}

		public override void RemoveReceptorAt(int id)
		{
			RepairBeforeRemove(id);
			receptors.RemoveAt(id);
		}

		public override void ClearReceptors()
		{
			receptors.Clear();
		}
	}
}
