using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "ExterminationDataSO", menuName = "BBT/ExterminationDataSO")]
	public class ExterminationDataSO : ScriptableObject
	{
		[SerializeField]
		[BoxGroup("Values")]
		[HideIf("ExterminetionType", ExterminationPanel.EExterminetionType.Protection)]
		private bool _isPercent;

		[SerializeField]
		[BoxGroup("Values")]
		[HideIf("_isPercent")]
		[ShowIf("ExterminetionType", ExterminationPanel.EExterminetionType.DownVigilance)]
		private int _value;

		[SerializeField]
		[BoxGroup("Values")]
		[MinValue(0f)]
		[MaxValue(1f)]
		[ShowIf("_isPercent")]
		private float _percentValue;

		[SerializeField]
		[BoxGroup("Price")]
		private int _price;

		[SerializeField]
		[BoxGroup("Price")]
		[Tooltip("Change la façon dont le prix est calculé")]
		private bool _useAddditionnal;

		[SerializeField]
		[BoxGroup("Price")]
		[Min(0.01f)]
		private float _priceModifier;

		[field: SerializeField]
		[field: BoxGroup("Values")]
		public ExterminationPanel.EExterminetionType ExterminetionType { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Values")]
		[field: MinValue(0f)]
		[field: MaxValue(1f)]
		[field: ShowIf("ExterminetionType", ExterminationPanel.EExterminetionType.Protection)]
		public float ProtectionFactor { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("ReUse")]
		public int DayBeforeReuse { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Graphic")]
		public LocalizedString Title { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Graphic")]
		public LocalizedString Effect { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Graphic")]
		public LocalizedString Description { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Graphic")]
		[field: ShowAssetPreview(64, 64)]
		public Sprite Picto { get; private set; }

		public int GetBasePrice()
		{
			return _price;
		}

		public float GetPriceMultiplier()
		{
			return _priceModifier;
		}

		public bool IsModifierAdditive()
		{
			return _useAddditionnal;
		}

		public int GetMultipliedPrice(int current)
		{
			float num = _price;
			if (_useAddditionnal)
			{
				num += num * _priceModifier * (float)current;
			}
			else
			{
				for (int i = 0; i < current; i++)
				{
					num *= _priceModifier;
				}
			}
			return Mathf.FloorToInt(num * MonoSingleton<MaeveExtermination>.Instance.DiscountMultiplier);
		}

		public int GetNewVigilance(int currentVigilance)
		{
			if (_isPercent)
			{
				if (currentVigilance - Mathf.FloorToInt((float)currentVigilance * _percentValue) <= 0)
				{
					return 0;
				}
				return currentVigilance - Mathf.FloorToInt((float)currentVigilance * _percentValue);
			}
			if (currentVigilance - _value <= 0)
			{
				return 0;
			}
			return currentVigilance - _value;
		}

		public string GetValueText()
		{
			if (_isPercent)
			{
				return Mathf.FloorToInt(_percentValue * 100f) + " % ";
			}
			return _value + " ";
		}

		public int GetValue()
		{
			if (_isPercent)
			{
				return Mathf.FloorToInt(_percentValue * 100f);
			}
			return _value;
		}
	}
}
