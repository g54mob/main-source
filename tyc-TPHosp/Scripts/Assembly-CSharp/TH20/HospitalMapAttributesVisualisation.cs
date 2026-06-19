using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class HospitalMapAttributesVisualisation : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			[Serializable]
			public class AttributeConfig
			{
				public float MinValue = -1f;

				public float MiddleValue;

				public float MaxValue = 1f;

				public Texture2D Gradient;
			}

			public AttributeConfig Temperature;

			public AttributeConfig Attractiveness;

			public AttributeConfig Hygiene;
		}

		private readonly Config _config;

		private readonly VisualManager _visualManager;

		private readonly WorldState _worldState;

		private Texture2D _texture;

		private HospitalAttributeMap.Attribute _currentAttribute = HospitalAttributeMap.Attribute.None;

		public HospitalAttributeMap.Attribute CurrentAttribute => _currentAttribute;

		public HospitalMapAttributesVisualisation(Config config, VisualManager visualManager, WorldState worldState)
		{
			_config = config;
			_visualManager = visualManager;
			_worldState = worldState;
			foreach (HospitalMap hospitalMap in worldState.HospitalMaps)
			{
				if (hospitalMap.Room.Definition._type != RoomDefinition.Type.AmbulanceBay)
				{
					AddHospitalMap(hospitalMap);
				}
			}
		}

		private void AddHospitalMap(HospitalMap hospitalMap)
		{
			_texture = new Texture2D(hospitalMap.Width, hospitalMap.Height, TextureFormat.RFloat, mipChain: false);
			_texture.filterMode = FilterMode.Bilinear;
			_texture.wrapMode = TextureWrapMode.Clamp;
		}

		public void ShowAttributeMap(HospitalAttributeMap.Attribute attribute)
		{
			if (attribute != HospitalAttributeMap.Attribute.None && _currentAttribute != attribute)
			{
				_currentAttribute = attribute;
				_texture.LoadRawTextureData(_worldState.HospitalAttributeMaps[(int)attribute].Bytes);
				_texture.Apply();
				switch (attribute)
				{
				case HospitalAttributeMap.Attribute.Temperature:
					_visualManager.RoomLightingManager.EnableHospitalMap(_texture, _config.Temperature);
					break;
				case HospitalAttributeMap.Attribute.Attractiveness:
					_visualManager.RoomLightingManager.EnableHospitalMap(_texture, _config.Attractiveness);
					break;
				case HospitalAttributeMap.Attribute.Hygiene:
					_visualManager.RoomLightingManager.EnableHospitalMap(_texture, _config.Hygiene);
					break;
				}
			}
		}

		public void HideAttributeMap()
		{
			if (_currentAttribute != HospitalAttributeMap.Attribute.None)
			{
				_currentAttribute = HospitalAttributeMap.Attribute.None;
			}
		}

		public void Update()
		{
			if (_currentAttribute != HospitalAttributeMap.Attribute.None)
			{
				_texture.LoadRawTextureData(_worldState.HospitalAttributeMaps[(int)_currentAttribute].Bytes);
				_texture.Apply();
			}
		}

		public float MinValue(HospitalAttributeMap.Attribute attribute)
		{
			return attribute switch
			{
				HospitalAttributeMap.Attribute.Temperature => _config.Temperature.MinValue, 
				HospitalAttributeMap.Attribute.Attractiveness => _config.Attractiveness.MinValue, 
				HospitalAttributeMap.Attribute.Hygiene => _config.Hygiene.MinValue, 
				_ => throw new ArgumentOutOfRangeException("attribute", attribute, null), 
			};
		}

		public float MaxValue(HospitalAttributeMap.Attribute attribute)
		{
			return attribute switch
			{
				HospitalAttributeMap.Attribute.Temperature => _config.Temperature.MaxValue, 
				HospitalAttributeMap.Attribute.Attractiveness => _config.Attractiveness.MaxValue, 
				HospitalAttributeMap.Attribute.Hygiene => _config.Hygiene.MaxValue, 
				_ => throw new ArgumentOutOfRangeException("attribute", attribute, null), 
			};
		}
	}
}
