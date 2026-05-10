using System;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "CharacterTool/Character Specific Clothes")]
	public class CharacterSpecificClothesData : ScriptableObject
	{
		[SerializeField]
		private CharacterBodyDataSO _femBody;

		[SerializeField]
		private int _femMaterialIndex;

		[SerializeField]
		private CharacterBodyDataSO _mascBody;

		[SerializeField]
		private int _mascMaterialIndex;

		[field: SerializeField]
		public LocalizedString Name { get; private set; }

		public static event Action ClothesChanged;

		public void ChangeClothes(CharacterVisualControler characterVisualController)
		{
			if (characterVisualController.CharacterData.Gender == EGender.Female)
			{
				characterVisualController.ChangeClothes(_femBody, _femMaterialIndex);
			}
			else
			{
				characterVisualController.ChangeClothes(_mascBody, _mascMaterialIndex);
			}
			CharacterSpecificClothesData.ClothesChanged?.Invoke();
		}

		public bool IsCurrent(CharacterData data)
		{
			if (data.Gender == EGender.Female)
			{
				if (data.bodyDataIndex == _femBody.ID)
				{
					return data.bodyMaterialGroupIndex == _femMaterialIndex;
				}
				return false;
			}
			if (data.bodyDataIndex == _mascBody.ID)
			{
				return data.bodyMaterialGroupIndex == _mascMaterialIndex;
			}
			return false;
		}
	}
}
