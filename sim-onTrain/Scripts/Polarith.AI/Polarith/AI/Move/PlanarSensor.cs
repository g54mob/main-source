using System;
using System.Collections.Generic;
using Polarith.AI.Criteria;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public sealed class PlanarSensor : Sensor
	{
		[Tooltip("Specifies how this sensor is oriented with respect to a virtual axis-aligned plane.")]
		[SerializeField]
		[HideInInspector]
		private PlanarOrientationType planarOrientation;

		[Tooltip("The current rotation with respect to the set 'PlanarOrientation'.")]
		[SerializeField]
		[HideInInspector]
		private Quaternion rotation = Quaternion.identity;

		[Tooltip("The inverse of the current rotation with respect to the set 'PlanarOrientation'.")]
		[SerializeField]
		[HideInInspector]
		private Quaternion inverseRotation = Quaternion.identity;

		public override Sensor Clone
		{
			get
			{
				PlanarSensor planarSensor = new PlanarSensor();
				planarSensor.receptors = new List<Receptor>();
				for (int i = 0; i < receptors.Count; i++)
				{
					planarSensor.receptors.Add(receptors[i].Clone);
				}
				planarSensor.planarOrientation = planarOrientation;
				planarSensor.rotation = rotation;
				planarSensor.inverseRotation = inverseRotation;
				return planarSensor;
			}
		}

		public override Quaternion Rotation => rotation;

		public override Quaternion InverseRotation => inverseRotation;

		public PlanarOrientationType PlanarOrientation
		{
			get
			{
				return planarOrientation;
			}
			set
			{
				if (value != planarOrientation)
				{
					if (value == PlanarOrientationType.PlaneXY)
					{
						rotation = inverseRotation;
						inverseRotation = Quaternion.identity;
						Rotate();
						Round();
						rotation = Quaternion.identity;
					}
					else
					{
						rotation = Quaternion.Euler(90f, 0f, 0f);
						inverseRotation = Quaternion.Euler(-90f, 0f, 0f);
						Rotate();
						Round();
					}
				}
				planarOrientation = value;
			}
		}

		public override VectorProjectionType ProjectionMode
		{
			get
			{
				if (PlanarOrientation != PlanarOrientationType.PlaneXY)
				{
					return VectorProjectionType.PlaneXZ;
				}
				return VectorProjectionType.PlaneXY;
			}
		}

		public static PlanarSensor CreateLine(int receptorCount, float width, float positionY, PlanarOrientationType planarOrientation = PlanarOrientationType.PlaneXY)
		{
			PlanarSensor planarSensor = new PlanarSensor();
			float num = (0f - width) * 0.5f;
			float newMax = 0f - num;
			planarSensor.ClearReceptors();
			for (int i = 0; i < receptorCount; i++)
			{
				IReceptor<Structure> receptor = planarSensor.AddReceptor();
				receptor.Structure.Direction = Vector3.up;
				receptor.Structure.Position = new Vector3(Mathf2.MapLinear(num, newMax, 0f, receptorCount - 1, i), positionY, 0f);
			}
			planarSensor.PlanarOrientation = planarOrientation;
			planarSensor.Round();
			planarSensor.InitializeNeighbours(closed: false);
			return planarSensor;
		}

		public static PlanarSensor CreateCircle(int receptorCount, float radius, PlanarOrientationType planarOrientation = PlanarOrientationType.PlaneXY)
		{
			PlanarSensor planarSensor = new PlanarSensor();
			double num = Math.PI * 2.0 / (double)receptorCount;
			planarSensor.ClearReceptors();
			for (int i = 0; i < receptorCount; i++)
			{
				double num2 = (double)i * num;
				float x = (float)Math.Round((decimal)Math.Sin(num2), 6);
				float y = (float)Math.Round((decimal)Math.Cos(num2), 6);
				IReceptor<Structure> receptor = planarSensor.AddReceptor();
				receptor.Structure.Direction = new Vector3(x, y, 0f);
				receptor.Structure.Position = radius * receptor.Structure.Direction;
			}
			planarSensor.PlanarOrientation = planarOrientation;
			planarSensor.Round();
			planarSensor.InitializeNeighbours(closed: true);
			return planarSensor;
		}

		public override IReceptor<Structure> AddReceptor()
		{
			IReceptor<Structure> receptor = base.AddReceptor();
			receptor.NeighbourIDs.Clear();
			receptor.NeighbourIDs.Add(-1);
			receptor.NeighbourIDs.Add(-1);
			return receptor;
		}

		public override IReceptor<Structure> InsertReceptor(int id)
		{
			IReceptor<Structure> receptor = base.InsertReceptor(id);
			receptor.NeighbourIDs.Clear();
			receptor.NeighbourIDs.Add(-1);
			receptor.NeighbourIDs.Add(-1);
			return receptor;
		}

		public int GetNeighbourID(int id, int targetNeighbour)
		{
			if (targetNeighbour == 0)
			{
				return id;
			}
			int num = 0;
			while (targetNeighbour != 0)
			{
				if (targetNeighbour < 0)
				{
					num = receptors[id].NeighbourIDs[0];
					targetNeighbour++;
				}
				else if (targetNeighbour > 0)
				{
					num = receptors[id].NeighbourIDs[1];
					targetNeighbour--;
				}
				if (num == -1)
				{
					return -1;
				}
				id = num;
			}
			return num;
		}

		public void InitializeNeighbours(bool closed)
		{
			if (receptors.Count != 0)
			{
				receptors[0].NeighbourIDs.Clear();
				receptors[0].NeighbourIDs.Add(closed ? ((receptors.Count - 1) % receptors.Count) : (-1));
				receptors[0].NeighbourIDs.Add(1 % receptors.Count);
				for (int i = 1; i < receptors.Count - 1; i++)
				{
					receptors[i].NeighbourIDs.Clear();
					receptors[i].NeighbourIDs.Add((i - 1) % receptors.Count);
					receptors[i].NeighbourIDs.Add((i + 1) % receptors.Count);
				}
				if (receptors.Count >= 2)
				{
					int num = receptors.Count - 1;
					receptors[num].NeighbourIDs.Clear();
					receptors[num].NeighbourIDs.Add((num - 1) % receptors.Count);
					receptors[num].NeighbourIDs.Add(closed ? ((num + 1) % receptors.Count) : (-1));
				}
			}
		}

		private void Rotate()
		{
			for (int i = 0; i < receptors.Count; i++)
			{
				Structure structure = receptors[i].Structure;
				structure.Position = rotation * structure.Position;
				structure.Direction = rotation * structure.Direction;
			}
		}

		private void Round()
		{
			for (int i = 0; i < receptors.Count; i++)
			{
				receptors[i].Structure.RoundVectors();
			}
		}
	}
}
