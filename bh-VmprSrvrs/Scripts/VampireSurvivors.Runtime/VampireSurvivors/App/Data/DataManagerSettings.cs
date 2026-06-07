using System;
using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.App.Data
{
	[Serializable]
	public class DataManagerSettings
	{
		[SerializeField]
		private TextAsset _AchievementDataJsonAsset;

		[SerializeField]
		private TextAsset _ArcanaDataJsonAsset;

		[SerializeField]
		private TextAsset _CharacterDataJsonAsset;

		[SerializeField]
		private TextAsset _EnemyDataJsonAsset;

		[SerializeField]
		private TextAsset _HitVfxDataJsonAsset;

		[SerializeField]
		private TextAsset _ItemDataJsonAsset;

		[SerializeField]
		private TextAsset _LimitBreakDataJsonAsset;

		[SerializeField]
		private TextAsset _MusicDataJsonAsset;

		[SerializeField]
		private TextAsset _PowerUpDataJsonAsset;

		[SerializeField]
		private TextAsset _PropsDataJsonAsset;

		[SerializeField]
		private TextAsset _SecretsDataJsonAsset;

		[SerializeField]
		private TextAsset _StageDataJsonAsset;

		[SerializeField]
		private TextAsset _WeaponDataJsonAsset;

		[SerializeField]
		private TextAsset _AlbumDataJsonAsset;

		[SerializeField]
		private TextAsset _CustomMerchantsDataJsonAsset;

		[SerializeField]
		private TextAsset _AllCPUAsset;

		[SerializeField]
		private TextAsset _AdventureDataJsonAsset;

		[SerializeField]
		private TextAsset _AdventuresStageSetDataJsonAsset;

		[SerializeField]
		private TextAsset _AdventuresStagesJsonAsset;

		[SerializeField]
		private TextAsset _AdventuresMerchantsDataJsonAsset;

		public TextAsset AchievementDataJsonAsset => null;

		public TextAsset ArcanaDataJsonAsset => null;

		public TextAsset CharacterDataJsonAsset => null;

		public TextAsset EnemyDataJsonAsset => null;

		public TextAsset HitVfxDataJsonAsset => null;

		public TextAsset ItemDataJsonAsset => null;

		public TextAsset LimitBreakDataJsonAsset => null;

		public TextAsset MusicDataJsonAsset => null;

		public TextAsset PowerUpDataJsonAsset => null;

		public TextAsset PropsDataJsonAsset => null;

		public TextAsset SecretsDataJsonAsset => null;

		public TextAsset StageDataJsonAsset => null;

		public TextAsset WeaponDataJsonAsset => null;

		public TextAsset AdventureDataJsonAsset => null;

		public TextAsset AdventuresStageSetDataJsonAsset => null;

		public TextAsset AdventuresStagesJsonAsset => null;

		public TextAsset AdventuresMerchantsDataJsonAsset => null;

		public TextAsset AlbumDataJsonAsset => null;

		public TextAsset CustomMerchantsDataJsonAsset => null;

		public TextAsset AllCPUAsset => null;

		public void AddToAssetList(List<TextAsset> assets, bool includeAdventures = false)
		{
		}
	}
}
