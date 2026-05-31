using NaughtyAttributes;
using UnityEngine;

namespace CTS.Core
{
	[CreateAssetMenu(menuName = "CTS/String Key", fileName = "New String Key")]
	[DefaultExecutionOrder(-10000)]
	public class ScriptableStringKey : ScriptableObject
	{
		[SerializeField]
		[ReadOnly]
		private string _key;

		internal StringKey _stringKey;

		public string Key
		{
			get
			{
				if (string.IsNullOrEmpty(_key))
				{
					UpdateName();
				}
				return _key;
			}
		}

		private void OnEnable()
		{
			_stringKey = new StringKey(_key);
		}

		private void OnValidate()
		{
			UpdateName();
		}

		private void UpdateName()
		{
			if (!(this == null) && !(_key == base.name))
			{
				_key = base.name;
				_stringKey = new StringKey(_key);
			}
		}
	}
}
