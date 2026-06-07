using System;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables
{
	[Serializable]
	[XmlInclude(typeof(NoReceivable))]
	[XmlInclude(typeof(DronePartReceivable))]
	[XmlInclude(typeof(OreReceivable))]
	[XmlInclude(typeof(HealthReceivable))]
	[XmlInclude(typeof(ThreatReceivable))]
	[XmlInclude(typeof(WeaponReceivable))]
	[XmlInclude(typeof(TechnologyReceivable))]
	[XmlInclude(typeof(MultiPartReceivable))]
	[XmlInclude(typeof(UpgradeReceivable))]
	[XmlInclude(typeof(EffectReceivable))]
	public abstract class BaseReceivable
	{
		public abstract EReceivableType Type();

		public abstract T GetReward<T>();

		public abstract Texture2D GetIcon();

		public abstract string GetTitle();

		public abstract string GetAmount();

		public abstract void HandleReward();

		public abstract bool IsPositive();

		public virtual string GetToolTip()
		{
			return GetTitle();
		}

		public virtual bool IsDuplicate(BaseReceivable receivable)
		{
			return Type() == receivable.Type();
		}
	}
}
