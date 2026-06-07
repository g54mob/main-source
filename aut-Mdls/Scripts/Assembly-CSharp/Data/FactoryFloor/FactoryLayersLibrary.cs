using UnityEngine;

namespace Data.FactoryFloor
{
	[CreateAssetMenu(menuName = "Factory/FactoryLayersLibrary", fileName = "FactoryLayersLibrary", order = 0)]
	public class FactoryLayersLibrary : ScriptableObject
	{
		[SerializeField]
		private FactoryLayer[] _factoryLayers;

		public FactoryLayer[] Layers => _factoryLayers;

		public void ClearAll()
		{
			FactoryLayer[] factoryLayers = _factoryLayers;
			for (int i = 0; i < factoryLayers.Length; i++)
			{
				factoryLayers[i].Clear();
			}
		}
	}
}
