using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/CursorConfig", fileName = "CursorConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class CursorConfig : ScriptableObject
	{
		public Texture2D texture;

		public Vector2 hotSpot;

		public CursorMode mode;
	}
}
