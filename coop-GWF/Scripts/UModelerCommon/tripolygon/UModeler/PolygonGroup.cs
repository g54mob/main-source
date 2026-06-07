using System;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class PolygonGroup
	{
		public string name;

		[SerializeField]
		private ulong instanceID_ = ((UMContext.activeModeler != null) ? UModeler.GenerateID() : 0);

		public ulong instanceID => instanceID_;

		public PolygonGroup Clone()
		{
			return new PolygonGroup
			{
				name = name,
				instanceID_ = instanceID_
			};
		}

		public int GetPolygonCount()
		{
			int num = 0;
			for (int i = 0; i < UMContext.activeModeler.editableMesh.GetPolygonCount(); i++)
			{
				if (UMContext.activeModeler.editableMesh.GetPolygon(i).groupID == instanceID)
				{
					num++;
				}
			}
			return num;
		}
	}
}
