using System;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERTree
	{
		public Color color;

		public float heightScale;

		public Color lightmapColor;

		public Vector3 position;

		public int prototypeIndex;

		public float widthScale;

		public ERTree(TreeInstance instance)
		{
			color = instance.color;
			heightScale = instance.heightScale;
			lightmapColor = instance.lightmapColor;
			position = instance.position;
			prototypeIndex = instance.prototypeIndex;
			widthScale = instance.widthScale;
		}

		public TreeInstance SetERTreeInstance(ERTree eRTreeinstance)
		{
			return new TreeInstance
			{
				color = eRTreeinstance.color,
				heightScale = eRTreeinstance.heightScale,
				lightmapColor = eRTreeinstance.lightmapColor,
				position = eRTreeinstance.position,
				prototypeIndex = eRTreeinstance.prototypeIndex,
				widthScale = eRTreeinstance.widthScale
			};
		}
	}
}
