using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views.MeshGeneration
{
	public class DestinationMesh : MonoBehaviour
	{
		public enum Type
		{
			Square = 0,
			Circle = 1,
			StationHorizontal = 2,
			StationVertical = 3
		}

		public Type type;

		public TileDirection direction;

		public ThemeComponentGroupTarget groupTarget;
	}
}
