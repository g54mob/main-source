using System;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCreator.Runtime.Common.SaveSystem
{
	[Serializable]
	[Title("Player Prefs")]
	[Category("Player Prefs")]
	[Image(typeof(IconDiskSolid), ColorTheme.Type.Blue)]
	[Description("Store all game information using Unity Player Prefs")]
	public class StoragePlayerPrefs : TDataStorage
	{
		public override Task DeleteAll()
		{
			PlayerPrefs.DeleteAll();
			return Task.FromResult(1);
		}

		public override Task DeleteKey(string key)
		{
			PlayerPrefs.DeleteKey(key);
			return Task.FromResult(1);
		}

		public override Task<bool> HasKey(string key)
		{
			return Task.FromResult(PlayerPrefs.HasKey(key));
		}

		public override Task<object> Get(string key, Type type)
		{
			string input = PlayerPrefs.GetString(key, string.Empty);
			input = base.Cryptography.Decrypt(input);
			return Task.FromResult((!string.IsNullOrEmpty(input)) ? JsonUtility.FromJson(input, type) : null);
		}

		public override Task Set(string key, object value)
		{
			string input = JsonUtility.ToJson(value);
			input = base.Cryptography.Encrypt(input);
			PlayerPrefs.SetString(key, input);
			return Task.FromResult(1);
		}

		public override Task Commit()
		{
			return Task.FromResult(1);
		}
	}
}
