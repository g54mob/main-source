using ScheduleOne.Persistence.Datas;
using UnityEngine.Events;

namespace ScheduleOne.Management
{
	public class StringField : ConfigField
	{
		private string _defaultValue;

		private bool _canBeNullOrEmpty;

		public UnityEvent<string> onItemChanged;

		public string Value { get; protected set; }

		public int CharacterLimit { get; protected set; }

		public StringField(EntityConfiguration parentConfig, string defaultValue)
			: base(null)
		{
		}

		public void SetValue(string value, bool network)
		{
		}

		public void Configure(int characterLimit, bool canBeNullOrEmpty)
		{
		}

		public override bool IsValueDefault()
		{
			return false;
		}

		public StringFieldData GetData()
		{
			return null;
		}

		public void Load(StringFieldData data)
		{
		}
	}
}
