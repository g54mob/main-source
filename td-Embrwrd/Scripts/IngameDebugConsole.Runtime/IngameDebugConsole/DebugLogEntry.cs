using System;
using UnityEngine;

namespace IngameDebugConsole
{
	public class DebugLogEntry : IEquatable<DebugLogEntry>
	{
		private const int HASH_NOT_CALCULATED = -623218;

		public string logString;

		public string stackTrace;

		private string completeLog;

		public Sprite logTypeSpriteRepresentation;

		public int count;

		private int hashValue;

		public void Initialize(string logString, string stackTrace)
		{
		}

		public bool Equals(DebugLogEntry other)
		{
			return false;
		}

		public bool MatchesSearchTerm(string searchTerm)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
