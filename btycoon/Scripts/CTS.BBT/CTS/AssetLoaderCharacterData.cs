using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/DLC/Character Data Loader")]
	public class AssetLoaderCharacterData : ScriptableLoader
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

		public override void Load()
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
