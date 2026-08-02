using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BloodEffectsPack
{
	public class ProjectorSpriteController_URP : MonoBehaviour
	{
		[Space(10f)]
		public int columns = 1;

		public int rows = 1;

		public int frameLength = 1;

		private float tile_x = 1f;

		private float tile_y = 1f;

		private float offset_x;

		private float offset_y;

		private void Start()
		{
			tile_x = 1f / (float)rows;
			tile_y = 1f / (float)columns;
			SetProjector();
			SetFrameIndex(0);
		}

		private void Update()
		{
		}

		public void SetProjector()
		{
			DecalProjector componentInChildren = GetComponentInChildren<DecalProjector>();
			componentInChildren.uvScale = new Vector2(tile_x, tile_y);
			componentInChildren.uvBias = new Vector2(offset_x, offset_y);
		}

		public void SetFrameIndex(int frame)
		{
			int num = frame % frameLength;
			int num2 = num % columns;
			int num3 = num / rows;
			Vector2 vector = default(Vector2);
			vector.x = 1f / (float)columns;
			vector.y = 1f / (float)rows;
			Vector2 vector2 = default(Vector2);
			vector2.x = (float)num2 * vector.x;
			vector2.y = 1f - vector.y - (float)num3 * vector.y;
			GetComponentInChildren<DecalProjector>().uvBias = new Vector2(vector2.x, vector2.y);
		}
	}
}
