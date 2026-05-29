using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos
{
	[RequireComponent(typeof(AHeightArrayBlockModelProvider))]
	public class Map : MonoBehaviour
	{
		private AHeightArrayBlockModelProvider blockModelProvider;

		private BlockModel blockModel;

		private void Awake()
		{
			blockModelProvider = GetComponent<AHeightArrayBlockModelProvider>();
			blockModel = blockModelProvider.GenerateBlockModel();
		}

		public Block GetBlock(Vector3 _Position)
		{
			return blockModel.GetBlock((int)_Position.x, (int)_Position.y, (int)_Position.z);
		}
	}
}
