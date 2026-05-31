using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS.BBT.TechTree
{
	[CreateAssetMenu(fileName = "New Category", menuName = "CTS/Tech Tree/New Category", order = 0)]
	public class TechTreeCategoriesSO : ScriptableObject
	{
		[SerializeField]
		public byte Order;

		[SerializeField]
		public LocalizedString CategoryName;

		[SerializeField]
		public LocalizedString CategoryDescription;

		[SerializeField]
		[Dropdown("sizeAvailable")]
		public float CategorySize;

		private float[] sizeAvailable = new float[6] { 0.2f, 0.3f, 0.33f, 0.4f, 0.5f, 0.6f };
	}
}
