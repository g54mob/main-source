using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Coherence.Cloud
{
	[Serializable]
	public struct StorageObjectId : IEquatable<StorageObjectId>
	{
		[SerializeField]
		private string type;

		[SerializeField]
		private string id;

		public const int MaxLength = 4096;

		public string Type => null;

		public string Id => null;

		public StorageObjectId([DisallowNull] IFormattable type, [DisallowNull] IFormattable id)
		{
			this.type = null;
			this.id = null;
		}

		public StorageObjectId([DisallowNull] IFormattable type, [DisallowNull] string id)
		{
			this.type = null;
			this.id = null;
		}

		public StorageObjectId([DisallowNull] string type, [DisallowNull] IFormattable id)
		{
			this.type = null;
			this.id = null;
		}

		public StorageObjectId([DisallowNull] string type, [DisallowNull] string id)
		{
			this.type = null;
			this.id = null;
		}

		public override string ToString()
		{
			return null;
		}

		public bool Equals(StorageObjectId other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(StorageObjectId left, StorageObjectId right)
		{
			return false;
		}

		public static bool operator !=(StorageObjectId left, StorageObjectId right)
		{
			return false;
		}

		public static implicit operator StorageObjectId((string type, string id) item)
		{
			return default(StorageObjectId);
		}

		public static implicit operator StorageObjectId((IFormattable type, string id) item)
		{
			return default(StorageObjectId);
		}

		public static implicit operator StorageObjectId((string type, IFormattable id) item)
		{
			return default(StorageObjectId);
		}

		public static implicit operator StorageObjectId((IFormattable type, IFormattable id) item)
		{
			return default(StorageObjectId);
		}
	}
}
