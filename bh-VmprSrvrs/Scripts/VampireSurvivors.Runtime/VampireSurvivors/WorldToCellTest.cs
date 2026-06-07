using UnityEngine;
using UnityEngine.Tilemaps;

namespace VampireSurvivors
{
	public class WorldToCellTest : MonoBehaviour
	{
		[SerializeField]
		protected PhaserTilemap tilemap;

		[SerializeField]
		protected SpriteRenderer targetSprite;

		[SerializeField]
		protected bool drawOrig;

		[SerializeField]
		protected bool drawCalc;

		private void OnDrawGizmosSelected()
		{
		}

		private Vector3Int WorldToCell(Tilemap tilemap, Vector3 point)
		{
			return default(Vector3Int);
		}
	}
}
