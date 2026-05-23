using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class StatusEffectGroup : MonoBehaviour
	{
		[Serializable]
		public struct StatusParticle<T> where T : Enum
		{
			public T subType;

			public BaseBattleEffect effect;
		}

		[Serializable]
		public struct StatusMaterial<T> where T : Enum
		{
			public T subType;

			public Material material;
		}

		public List<StatusParticle<eSlowType>> slowTypeEffectSlot;

		public List<StatusMaterial<eStopType>> stopTypeMaterialSlot;

		public Material defaultMaterial;

		public void PlayEffect<T>(T subType)
		{
		}

		public void StopEffect<T>(T subType)
		{
		}

		private BaseBattleEffect GetTargetEffect<T>(T subType)
		{
			return null;
		}

		public Material GetTargetMaterial<T>(T subType)
		{
			return null;
		}

		public void ChangeStopMaterial(BaseEnemy enemy, eStopType stopType)
		{
		}
	}
}
