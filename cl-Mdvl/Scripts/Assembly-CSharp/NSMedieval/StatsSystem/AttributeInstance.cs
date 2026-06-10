using System;
using NSEipix.Repository;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	[FVSerializableKey("AttributeInstance", "")]
	public class AttributeInstance : ISerializationCallbackReceiver, IFVSerializable
	{
		[SerializeField]
		private AttributeType type;

		[NonSerialized]
		private float multiplier;

		[NonSerialized]
		private Attribute blueprint;

		[NonSerialized]
		private StatsInstance owner;

		[NonSerialized]
		private bool isDisabled;

		[NonSerialized]
		private float difficultyModifier;

		public AttributeType Type => type;

		public float Value
		{
			get
			{
				if (isDisabled)
				{
					return 1f;
				}
				return Mathf.Round(Blueprint.Value * multiplier * difficultyModifier * 1000f) * 0.001f;
			}
		}

		public float BaseValue => Blueprint.Value;

		public float Multiplier => multiplier;

		public bool IsDisabled
		{
			get
			{
				return isDisabled;
			}
			set
			{
				isDisabled = value;
			}
		}

		public Attribute Blueprint
		{
			get
			{
				if (blueprint != null)
				{
					return blueprint;
				}
				Attribute attribute = owner?.Owner?.GetAttributeOverride(type);
				blueprint = ((attribute != null) ? attribute : Repository<AttributeRepository, Attribute>.Instance.GetByID(type.ToString()));
				return blueprint;
			}
		}

		public AttributeInstance(AttributeType type, StatsInstance owner)
		{
			this.type = type;
			Attribute attributeOverride = owner.Owner.GetAttributeOverride(type);
			blueprint = ((attributeOverride != null) ? attributeOverride : Repository<AttributeRepository, Attribute>.Instance.GetByID(type.ToString()));
			multiplier = 1f;
			this.owner = owner;
			difficultyModifier = blueprint.GetDifficultyModifier();
		}

		public void RefreshDifficultyModifier()
		{
			difficultyModifier = blueprint.GetDifficultyModifier();
		}

		public void RefreshOverride(StatsInstance owner)
		{
			Attribute attributeOverride = owner.Owner.GetAttributeOverride(type);
			blueprint = ((attributeOverride != null) ? attributeOverride : Repository<AttributeRepository, Attribute>.Instance.GetByID(type.ToString()));
		}

		public void SetOwner(StatsInstance owner)
		{
			this.owner = owner;
			difficultyModifier = Blueprint.GetDifficultyModifier();
		}

		public void OnAfterDeserialize()
		{
			if (type != AttributeType.None)
			{
				multiplier = 1f;
			}
		}

		public void OnBeforeSerialize()
		{
		}

		public void SetMultiplier(float value)
		{
			multiplier = value;
		}

		public void ResetMultiplier()
		{
			if (!Blueprint.DontReset)
			{
				multiplier = 1f;
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.WriteEnum("type", type);
		}

		public AttributeInstance(FVDeserializer deserializer)
		{
			type = deserializer.ReadEnum("type", AttributeType.None);
			OnAfterDeserialize();
		}

		public void Dispose()
		{
			owner = null;
			blueprint = null;
		}
	}
}
