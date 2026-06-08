using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Effect", menuName = "Kitchen/Effect")]
	public class Effect : GameDataObject, IEffectPropertySource
	{
		public List<IEffectProperty> Properties;

		public IEffectRange EffectRange;

		public IEffectCondition EffectCondition;

		public IEffectType EffectType;

		public EffectRepresentation EffectInformation;

		IEffectRange IEffectPropertySource.EffectRange => EffectRange;

		IEffectCondition IEffectPropertySource.EffectCondition => EffectCondition;

		IEffectType IEffectPropertySource.EffectType => EffectType;

		EffectRepresentation IEffectPropertySource.EffectInformation => EffectInformation;

		protected override void InitialiseDefaults()
		{
			Properties = new List<IEffectProperty>();
		}
	}
}
