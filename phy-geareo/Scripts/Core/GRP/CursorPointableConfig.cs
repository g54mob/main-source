using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/CursorPointableConfig", fileName = "CursorPointableConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class CursorPointableConfig : ScriptableObject
	{
		public CursorConfig hover;

		public CursorConfig down;
	}
}
