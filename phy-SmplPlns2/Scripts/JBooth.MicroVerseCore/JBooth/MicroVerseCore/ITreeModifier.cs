using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public interface ITreeModifier : ISpawner, IModifier
	{
		bool NeedTreeClear();

		void ApplyTreeClear(TreeData td);

		void ApplyTreeStamp(TreeData vd, Dictionary<Terrain, List<TreeJobHolder>> jobs, OcclusionData od);

		void ProcessTreeStamp(TreeData vd, Dictionary<Terrain, List<TreeJobHolder>> jobs, OcclusionData od);

		void InqTreePrototypes(List<TreePrototypeSerializable> prototypes);

		bool NeedCurvatureMap();

		bool NeedFlowMap();

		bool OccludesOthers();

		bool NeedSDF();
	}
}
