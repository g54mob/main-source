using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class CharacterMeshDataSO : ScriptableObject, IIndentifiable
	{
		[SerializeField]
		public Mesh mesh;

		[SerializeField]
		public CharacterMaterialDataSO[] characterMaterialData;

		private static readonly List<IndexedMaterial> _randomList = new List<IndexedMaterial>();

		[field: SerializeField]
		public int ID { get; private set; }

		public bool TryGetSpecificMaterial(int id, out IndexedMaterial outMaterial)
		{
			outMaterial = default(IndexedMaterial);
			if (id == 0)
			{
				return false;
			}
			CharacterMaterialDataSO[] array = characterMaterialData;
			foreach (CharacterMaterialDataSO characterMaterialDataSO in array)
			{
				if (characterMaterialDataSO.ID == id)
				{
					outMaterial = new IndexedMaterial
					{
						material = characterMaterialDataSO.material,
						index = characterMaterialDataSO.ID
					};
				}
			}
			return false;
		}

		public bool TryGetMaterial(CharacterData data, out IndexedMaterial outMat)
		{
			_randomList.Clear();
			CharacterMaterialDataSO[] array = characterMaterialData;
			foreach (CharacterMaterialDataSO characterMaterialDataSO in array)
			{
				if (characterMaterialDataSO.ID != 0 && data.IsValid(characterMaterialDataSO.characterData))
				{
					_randomList.Add(new IndexedMaterial
					{
						material = characterMaterialDataSO.material,
						index = characterMaterialDataSO.ID
					});
				}
			}
			if (_randomList.Count == 0)
			{
				outMat = default(IndexedMaterial);
				return false;
			}
			outMat = _randomList.GetRandom();
			return true;
		}

		public IndexedMaterial GetMaterial(CharacterData data)
		{
			TryGetMaterial(data, out var outMat);
			return outMat;
		}
	}
}
