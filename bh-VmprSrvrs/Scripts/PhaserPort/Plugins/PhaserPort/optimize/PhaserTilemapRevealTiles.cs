using UnityEngine;

namespace Plugins.PhaserPort.optimize
{
	public class PhaserTilemapRevealTiles : MonoBehaviour
	{
		[SerializeField]
		protected int randomSeed;

		[SerializeField]
		protected PhaserTilemap tilemap;

		protected void OnDrawGizmosSelected()
		{
		}
	}
}
