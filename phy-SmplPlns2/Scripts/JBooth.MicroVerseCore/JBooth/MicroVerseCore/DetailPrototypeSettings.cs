using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[CreateAssetMenu(fileName = "DetailPrototypeSettings", menuName = "MicroVerse/Detail Prototype Settings")]
	public class DetailPrototypeSettings : ScriptableObject
	{
		public DetailPrototypeSerializable prototype;
	}
}
