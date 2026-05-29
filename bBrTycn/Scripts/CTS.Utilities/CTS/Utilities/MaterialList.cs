using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.Utilities
{
	[CreateAssetMenu(menuName = "CTS/Material List")]
	public class MaterialList : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<StringKey, Material> _materials = new SerializableDictionary<StringKey, Material>();

		public ReadOnlyDictionary<StringKey, Material> Materials => _materials;
	}
}
