using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public interface IDetailModifier : ISpawner, IModifier
	{
		bool NeedDetailClear();

		void ApplyDetailClear(DetailData td);

		void ApplyDetailStamp(DetailData dd, Dictionary<Terrain, Dictionary<int, List<RenderTexture>>> resultBuffers, OcclusionData od);

		void InqDetailPrototypes(List<DetailPrototypeSerializable> prototypes);

		bool NeedCurvatureMap();

		bool NeedFlowMap();

		bool NeedSDF();
	}
}
