using UnityEngine;

namespace NSMedieval.Layers
{
	public interface IHideObject
	{
		void UpdateObjectLayerInfo(params MeshRenderer[] activeMeshRenderers);
	}
}
