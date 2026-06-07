using System;
using System.Collections.Generic;
using UnityEngine;

namespace UltimateReplay.Core
{
	[Serializable]
	public sealed class ReplayIdentity : IEquatable<ReplayIdentity>
	{
		internal const int maxGenerateAttempts = 512;

		internal const int unassignedID = -1;

		private static List<ReplayIdentity> usedIds;

		[SerializeField]
		private short id = -1;

		public static readonly int byteSize;

		private bool IsGenerated => id != -1;

		static ReplayIdentity()
		{
			usedIds = new List<ReplayIdentity>();
			byteSize = 2;
			usedIds.Clear();
		}

		public ReplayIdentity()
		{
		}

		public ReplayIdentity(short id)
		{
			this.id = id;
		}

		public ReplayIdentity(int id)
		{
			this.id = (short)id;
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			ReplayIdentity replayIdentity = obj as ReplayIdentity;
			if (replayIdentity == null)
			{
				return false;
			}
			return Equals(replayIdentity);
		}

		public bool Equals(ReplayIdentity obj)
		{
			if (obj == null)
			{
				return false;
			}
			return id == obj.id;
		}

		public override string ToString()
		{
			return $"ReplayIdentity({id})";
		}

		public static bool operator ==(ReplayIdentity a, ReplayIdentity b)
		{
			if ((object)a == null)
			{
				return (object)b == null;
			}
			if (object.Equals(a, b))
			{
				return true;
			}
			return a.Equals(b);
		}

		public static bool operator !=(ReplayIdentity a, ReplayIdentity b)
		{
			if ((object)a == null)
			{
				return (object)b != null;
			}
			return !a.Equals(b);
		}

		public static implicit operator short(ReplayIdentity identity)
		{
			return identity.id;
		}

		public static void RegisterIdentity(ReplayIdentity identity)
		{
			if (!IsUnique(identity))
			{
				Generate(identity);
			}
			if (!usedIds.Contains(identity))
			{
				usedIds.Add(identity);
			}
		}

		public static void UnregisterIdentity(ReplayIdentity identity)
		{
			if (usedIds.Contains(identity))
			{
				usedIds.Remove(identity);
			}
		}

		private static void Generate(ReplayIdentity identity)
		{
			short num = -1;
			short num2 = 0;
			byte[] array = new byte[2];
			System.Random random = new System.Random((int)DateTime.Now.Ticks);
			do
			{
				if (num2 > 512)
				{
					throw new OperationCanceledException("Attempting to find a unique replay id took too long. The operation was canceled to prevent a long or infinite loop");
				}
				random.NextBytes(array);
				num = (short)((array[0] << 8) | array[1]);
				num2++;
			}
			while (num == -1 || !IsValueUnique(num));
			identity.id = num;
		}

		private static bool IsValueUnique(short value)
		{
			foreach (ReplayIdentity usedId in usedIds)
			{
				if (usedId.id == value)
				{
					return false;
				}
			}
			return true;
		}

		private static bool IsUnique(ReplayIdentity identity)
		{
			if (!identity.IsGenerated)
			{
				return false;
			}
			foreach (ReplayIdentity usedId in usedIds)
			{
				if ((object)usedId != identity && usedId.id == identity.id)
				{
					return false;
				}
			}
			return true;
		}
	}
}
