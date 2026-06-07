using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Serializable]
	public struct MiniatureWargameSkill
	{
		[SerializeField]
		private int m_lifePoints;

		[SerializeField]
		private WargameSkillCondition m_condition;

		[Space(10f)]
		[SerializeField]
		private List<WargameSkillEffect> m_effects;

		[SerializeField]
		[TermsPopup("")]
		private string m_descriptionKey;

		public int LifePoints => m_lifePoints;

		public WargameSkillCondition Condition => m_condition;

		public IEnumerable<WargameSkillEffect> Effects
		{
			get
			{
				foreach (WargameSkillEffect effect in m_effects)
				{
					if (effect != null)
					{
						yield return effect;
					}
					else
					{
						Debug.LogError("NULL EFFECT");
					}
				}
			}
		}

		public string DescriptionKey => m_descriptionKey;

		public void SetLifePoints(int lifePoints)
		{
			m_lifePoints = lifePoints;
		}

		public void SetCondition(WargameSkillCondition condition)
		{
			m_condition = condition;
		}
	}
}
