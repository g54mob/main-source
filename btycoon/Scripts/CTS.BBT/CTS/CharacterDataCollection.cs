using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Characters/Data Collection")]
	public class CharacterDataCollection : ScriptableObject
	{
		[SerializeField]
		private List<CharacterBodyDataSO> _clothes;

		[SerializeField]
		private List<CharacterMaterialDataSO> _bodySkins;

		[SerializeField]
		private List<CharacterMaterialDataSO> _headSkins;

		[SerializeField]
		private List<CharacterMaterialDataSO> _eyes;

		[SerializeField]
		private List<CharacterMeshDataSO> _hairs;

		[SerializeField]
		private List<CharacterBlenshapeDataSO> _blendShapes;

		public ReadOnlyList<CharacterBodyDataSO> Clothes => _clothes;

		public ReadOnlyList<CharacterMaterialDataSO> BodySkins => _bodySkins;

		public ReadOnlyList<CharacterMaterialDataSO> HeadSkins => _headSkins;

		public ReadOnlyList<CharacterMaterialDataSO> Eyes => _eyes;

		public ReadOnlyList<CharacterMeshDataSO> Hairs => _hairs;

		public ReadOnlyList<CharacterBlenshapeDataSO> BlendShapes => _blendShapes;

		public void AddToManager()
		{
			foreach (CharacterBodyDataSO item in _clothes)
			{
				CharacterVisualManager.AddClothing(item);
			}
			foreach (CharacterMaterialDataSO bodySkin in _bodySkins)
			{
				CharacterVisualManager.AddBodySkin(bodySkin);
			}
			foreach (CharacterMaterialDataSO headSkin in _headSkins)
			{
				CharacterVisualManager.AddHeadSkin(headSkin);
			}
			foreach (CharacterMaterialDataSO eye in _eyes)
			{
				CharacterVisualManager.AddEyeSkin(eye);
			}
			foreach (CharacterMeshDataSO hair in _hairs)
			{
				CharacterVisualManager.AddHair(hair);
			}
			foreach (CharacterBlenshapeDataSO blendShape in _blendShapes)
			{
				CharacterVisualManager.AddBlendShape(blendShape);
			}
		}
	}
}
