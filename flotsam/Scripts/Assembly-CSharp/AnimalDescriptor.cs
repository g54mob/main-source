using System;
using System.Runtime.Serialization;
using Assets.Code.Animals;
using UnityEngine;

public abstract class AnimalDescriptor : ActorDescriptor
{
	[Serializable]
	public abstract class AnimaleDescriptorPersistentData : PersistentDataBase
	{
		[OptionalField(VersionAdded = 1)]
		private int _portraitIndex;

		public int PortraitIndex => _portraitIndex;

		protected AnimaleDescriptorPersistentData(AnimalDescriptor animalDescriptor)
			: base(animalDescriptor)
		{
			_portraitIndex = animalDescriptor._portraitIndex;
		}
	}

	private AnimalProperties _properties;

	private int _portraitIndex;

	public override PanelID PanelID => PanelID.AnimalPanel;

	public Sprite Portrait { get; private set; }

	public override WorldMapScoutingId ScoutingId => _properties.ScoutingId;

	protected AnimalDescriptor(AnimalProperties properties)
		: base(properties.ActorType)
	{
		_properties = properties;
		SetName(GenerateName());
		SetPortraitIndex(-1);
	}

	protected AnimalDescriptor(AnimalProperties properties, AnimaleDescriptorPersistentData persistentData)
		: base(persistentData)
	{
		_properties = properties;
		SetPortraitIndex(persistentData.PortraitIndex);
	}

	protected override string GenerateName()
	{
		return _properties.GenerateName();
	}

	protected void SetPortraitIndex(int index)
	{
		if (_properties.Portraits.IsValidIndex(index))
		{
			_portraitIndex = index;
		}
		else
		{
			_portraitIndex = _properties.Portraits.GetRandomIndex();
		}
		Portrait = _properties.Portraits[_portraitIndex];
	}
}
