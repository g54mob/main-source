using System;
using System.Text;
using HeathenEngineering.SteamworksIntegration.API;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct RemoteStorageFile : IEquatable<RemoteStorageFile>
	{
		public string name;

		public int size;

		public DateTime timestamp;

		public byte[] Data => RemoteStorage.Client.FileRead(name);

		public bool Equals(RemoteStorageFile other)
		{
			if (name.Equals(other.name) && size.Equals(other.size))
			{
				return timestamp.Equals(other.timestamp);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj.GetType() == typeof(RemoteStorageFile))
			{
				return Equals((RemoteStorageFile)obj);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return name.GetHashCode() ^ size.GetHashCode() ^ timestamp.GetHashCode();
		}

		public override string ToString()
		{
			return RemoteStorage.Client.FileReadString(name, Encoding.UTF8);
		}

		public string ToString(Encoding encoding)
		{
			return RemoteStorage.Client.FileReadString(name, encoding);
		}

		public T ToJson<T>()
		{
			return RemoteStorage.Client.FileReadJson<T>(name, Encoding.UTF8);
		}

		public T ToJson<T>(Encoding encoding)
		{
			return RemoteStorage.Client.FileReadJson<T>(name, encoding);
		}

		public static bool operator ==(RemoteStorageFile l, RemoteStorageFile r)
		{
			return l.Equals(r);
		}

		public static bool operator !=(RemoteStorageFile l, RemoteStorageFile r)
		{
			return !l.Equals(r);
		}
	}
}
