using UnityEngine;

namespace Data.Blueprints
{
	[CreateAssetMenu(menuName = "UI/BlueprintsColorLibrary")]
	public class BlueprintsColorLibrary : ScriptableObject
	{
		[SerializeField]
		private Color[] _colors;

		public Color[] Colors => _colors;
	}
}
