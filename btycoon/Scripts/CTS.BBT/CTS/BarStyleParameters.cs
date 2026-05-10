using System.Collections.Generic;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "BarStyle", menuName = "BBT/Influence/Bar Style")]
	public class BarStyleParameters : ScriptableObject
	{
		[field: SerializeField]
		public EBarStyle BarStyle { get; private set; }

		[field: SerializeField]
		public Sprite Icon { get; private set; }

		[field: SerializeField]
		public LocalizedString StyleNameText { get; private set; }

		[field: SerializeField]
		public LocalizedString StyleDescText { get; private set; }

		[field: SerializeField]
		public LocalizedString LockStyleNameText { get; private set; }

		[field: SerializeField]
		public LocalizedString LockStyleDescText { get; private set; }

		[field: SerializeField]
		public Color StyleColor { get; private set; }

		[field: SerializeField]
		public EUnlockKey UnlockKey { get; private set; }

		[field: SerializeField]
		public bool AvailableInDemo { get; private set; }

		[field: SerializeField]
		public bool Available { get; private set; }

		[field: SerializeField]
		public SerializableDictionary<ESubSpecies, float> CustomerRepartition { get; private set; } = new SerializableDictionary<ESubSpecies, float>();

		[field: SerializeField]
		public List<LocalizedString> TypeOfHumanAttracted { get; private set; }

		public bool IsLocked
		{
			get
			{
				if (Available)
				{
					return !UnlockingManager.ContainKey(UnlockKey);
				}
				return true;
			}
		}

		public bool Equals(BarStyleParameters other)
		{
			return BarStyle == other.BarStyle;
		}

		public ESubSpecies SelectCustomerType()
		{
			return CustomerRepartition.DrawWeightedRandom();
		}
	}
}
