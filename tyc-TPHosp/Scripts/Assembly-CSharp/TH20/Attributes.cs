#define LOG_LEVEL_VERBOSE
using System;

namespace TH20
{
	public class Attributes : MustCallDestroy
	{
		private bool _enabled = true;

		private readonly IAttributesInterface _owner;

		private readonly AttributeFloat[] _attributes;

		private float _lastUpdate;

		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				_enabled = value;
			}
		}

		protected Attributes(IAttributesInterface owner, string[] attributeNames)
		{
			_lastUpdate = GameTime.time;
			_attributes = new AttributeFloat[attributeNames.Length];
			_owner = owner;
			_owner.GetAttributesManager().Add(this);
		}

		public override void Destroy()
		{
			_owner.GetAttributesManager().Remove(this);
			AttributeFloat[] attributes = _attributes;
			for (int i = 0; i < attributes.Length; i++)
			{
				attributes[i]?.Destroy();
			}
			base.Destroy();
		}

		public int StringToEnumValue(string name)
		{
			int hashCode = name.GetHashCode();
			_owner.GetAttributeHashCodes(out var hashCodes);
			for (int i = 0; i < hashCodes.Length; i++)
			{
				if (hashCodes[i] == hashCode)
				{
					return i;
				}
			}
			return -1;
		}

		protected void Add(int enumValue, AttributeFloat attribute)
		{
			if (_attributes[enumValue] != null)
			{
				_owner.GetAttributeNames(out var names);
				Logging.Error(LogChannels.AI, "Attribute " + names[enumValue] + " already exists");
			}
			_attributes[enumValue] = attribute;
		}

		protected void Remove(int enumValue)
		{
			_attributes[enumValue] = null;
		}

		public void Copy(Attributes source)
		{
			if (GetType() != source.GetType())
			{
				Logging.Error(LogChannels.AI, "Attribute.Copy only works with matching Attributes types. {0} != {1}", GetType(), source.GetType());
			}
			for (int i = 0; i < _attributes.Length; i++)
			{
				if (_attributes[i] != null)
				{
					_attributes[i].SetValue(source._attributes[i].Value(), callCallbacks: false);
				}
			}
		}

		public void Update()
		{
			float time = GameTime.time;
			float deltaTime = time - _lastUpdate;
			_lastUpdate = time;
			if (!_enabled)
			{
				return;
			}
			_owner.GetAttributeNames(out var names);
			for (int i = 0; i < _attributes.Length; i++)
			{
				if (_attributes[i] != null)
				{
					float attributeModifierOverTime = _owner.GetAttributeModifierOverTime(names[i]);
					float attributeMultiplier = _owner.GetAttributeMultiplier(i);
					_attributes[i].Update(attributeModifierOverTime, deltaTime, attributeMultiplier);
				}
			}
		}

		public AttributeFloat GetAttribute(int enumValue)
		{
			if (enumValue < 0 || enumValue >= _attributes.Length)
			{
				Logging.Error(LogChannels.AI, "Enum value {0} is out of range of {1} attributes: {2} in class {3}", enumValue, _attributes.Length, ToString(), GetType());
				return null;
			}
			return _attributes[enumValue];
		}

		public override string ToString()
		{
			string text = string.Empty;
			_owner.GetAttributeNames(out var names);
			for (int i = 0; i < _attributes.Length; i++)
			{
				if (_attributes[i] != null)
				{
					text += $"{names[i]}: {(int)_attributes[i].Value()}, ";
				}
			}
			return text;
		}

		public void Iterate(Action<AttributeFloat> func)
		{
			AttributeFloat[] attributes = _attributes;
			foreach (AttributeFloat attributeFloat in attributes)
			{
				if (attributeFloat != null)
				{
					func.InvokeSafe(attributeFloat);
				}
			}
		}
	}
}
