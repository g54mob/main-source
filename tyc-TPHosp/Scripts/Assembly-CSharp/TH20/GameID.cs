using System;
using Steamworks;

namespace TH20
{
	public struct GameID : IEquatable<GameID>, IComparable<GameID>
	{
		public static readonly GameID Unknown = new GameID(0u);

		private ulong _appID;

		public GameID(uint appID)
		{
			_appID = appID;
		}

		public GameID(ulong appID)
		{
			_appID = appID;
		}

		public uint AsUint()
		{
			return (uint)_appID;
		}

		public int CompareTo(GameID other)
		{
			return _appID.CompareTo(other._appID);
		}

		public bool Equals(GameID other)
		{
			return other._appID == _appID;
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return -981191744 + _appID.GetHashCode();
		}

		public override string ToString()
		{
			return _appID.ToString();
		}

		public static bool operator ==(GameID x, GameID y)
		{
			return x._appID == y._appID;
		}

		public static bool operator !=(GameID x, GameID y)
		{
			return !(x == y);
		}

		public static implicit operator GameID(CGameID value)
		{
			return new GameID(value.m_GameID);
		}

		public static implicit operator CGameID(GameID value)
		{
			return new CGameID(value._appID);
		}

		public static implicit operator GameID(uint value)
		{
			return new GameID(value);
		}
	}
}
