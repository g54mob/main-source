using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.MiniMap
{
	public class MinimapUIObject : MonoBehaviour
	{
		public UITexture Texture;

		[HideInInspector]
		public MinimapObject MinimapObject;

		public void Init(MinimapObject minimapObject)
		{
			MinimapObject = minimapObject;
			Texture.mainTexture = minimapObject.Icon;
		}

		public Vector2 CalculatePosition(Minimap map)
		{
			return Vector3.ClampMagnitude(((Vector2)MinimapObject.transform.position - map.WorldCenter) * (map.Size / map.MaxWorldSize), map.Size / 2f);
		}
	}
}
