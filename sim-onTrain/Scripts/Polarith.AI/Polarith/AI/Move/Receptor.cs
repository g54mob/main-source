using System;
using Polarith.AI.Criteria;

namespace Polarith.AI.Move
{
	[Serializable]
	public sealed class Receptor : Receptor<Structure>
	{
		public Receptor Clone
		{
			get
			{
				Receptor receptor = new Receptor();
				receptor.Structure.Copy(base.Structure);
				receptor.ID = base.ID;
				for (int i = 0; i < base.NeighbourIDs.Count; i++)
				{
					receptor.NeighbourIDs.Add(base.NeighbourIDs[i]);
				}
				return receptor;
			}
		}
	}
}
