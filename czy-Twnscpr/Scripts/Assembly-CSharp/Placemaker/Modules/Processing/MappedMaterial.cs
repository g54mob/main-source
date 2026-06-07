using System;
using UnityEngine;

namespace Placemaker.Modules.Processing
{
	[Serializable]
	public struct MappedMaterial
	{
		public string srcName;

		public Material targetMaterial;

		public bool replaceableColor;

		public bool cantTouchOtherColor;

		public bool reallyCantTouchOtherColor;

		public bool softNormalsInTangent;

		public bool edgeProfile;

		public bool onlyMergeAdjecent;

		public bool attachment;

		public bool attachee;

		public bool outputMesh;

		public bool blocker;

		public bool combineBlocker;

		public bool outlineUvs;

		public float normalSideMultiplier;

		public MaterialType materialType;
	}
}
