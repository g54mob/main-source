using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/SignalVisualConfig", fileName = "SignalVisualConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class SignalVisualConfig : ScriptableObject
	{
		public int valueMaterialIndex;

		public int channelMaterialIndex;

		public Gradient colorOverValue;

		public Gradient textColorOverValue;

		[Header("Sprites")]
		public Sprite sprUpArrow;

		public Sprite sprDownArrow;

		public Sprite sprRightArrow;

		public Sprite sprLeftArrow;

		public Sprite sprSpace;
	}
}
