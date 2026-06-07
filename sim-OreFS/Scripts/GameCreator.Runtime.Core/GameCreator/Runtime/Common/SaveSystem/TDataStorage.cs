using System;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCreator.Runtime.Common.SaveSystem
{
	[Serializable]
	[Title("Save System")]
	public abstract class TDataStorage : IDataStorage
	{
		[NonSerialized]
		private IDataEncryption m_Cryptography;

		protected IDataEncryption Cryptography
		{
			get
			{
				if (m_Cryptography == null)
				{
					Debug.LogError("No Encryption system provided");
					m_Cryptography = new EncryptionNone();
				}
				return m_Cryptography;
			}
		}

		public Task WithEncryption(IDataEncryption encryption)
		{
			m_Cryptography = encryption;
			return Task.FromResult(1);
		}

		public abstract Task Commit();

		public abstract Task DeleteAll();

		public abstract Task DeleteKey(string key);

		public abstract Task<bool> HasKey(string key);

		public abstract Task<object> Get(string key, Type type);

		public abstract Task Set(string key, object value);
	}
}
