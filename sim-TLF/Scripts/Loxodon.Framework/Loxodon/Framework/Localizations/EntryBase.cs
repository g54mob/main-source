using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	public abstract class EntryBase
	{
		[SerializeField]
		protected string key;

		[SerializeField]
		protected ValueType type;

		public string Key
		{
			get
			{
				return key;
			}
			set
			{
				key = value;
			}
		}

		public ValueType Type
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
			}
		}
	}
}
