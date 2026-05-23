using System.Collections.Generic;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using UnityEngine;

namespace Battle
{
	public class SallyUnit : SingletonMonoBehaviour<SallyUnit>
	{
		[Header("レベルEffect")]
		public GameObject efUnitBufRed;

		public GameObject efUnitBufGreen;

		public GameObject efUnitBufBlue;

		public GameObject efUnitBufYellow;

		public GameObject efUnitBufGray;

		[Header("共通エフェクト類")]
		public Material pertrifactionMat;

		public HitEffect pertrifactionHit;

		private Dictionary<eUnit, BaseUnit> _addressableUnitCache;

		private Dictionary<eMiracle, BaseMiracle> _addressableMiracleCache;

		public static Transform tf;

		private WaveInfoData _waveInfo;

		public List<eLuggage> SallyStandby { get; set; }

		private bool SallyOk => false;

		public static Vector3 ConvertToSallyLocal(Vector3 world)
		{
			return default(Vector3);
		}

		private void Awake()
		{
		}

		public void UpdateSallyUnit()
		{
		}

		public void CountUpLuggage(eLuggage luggage, int coatLevel)
		{
		}

		private void ScoreUpdate(eLuggage luggage)
		{
		}

		public void CreateBattleObj(eLuggage luggage)
		{
		}

		private void RegisterHeroInstance(eLuggage luggage, eUnit unit)
		{
		}

		public void RegisterMiracleInstance(eLuggage luggage, eMiracle miracle)
		{
		}

		public void CreateHero(eLuggage luggage, eUnit unitId)
		{
		}

		public void CreateMiracle(eLuggage luggage, eMiracle miracleId, bool clickMode = false)
		{
		}

		private GameObject GetLevelEffectObj(eLuggage luggage)
		{
			return null;
		}
	}
}
