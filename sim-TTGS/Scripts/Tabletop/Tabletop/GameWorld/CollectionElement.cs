using System.Collections.Generic;

namespace Tabletop.GameWorld
{
	public readonly struct CollectionElement
	{
		public readonly int UID;

		public readonly MiniatureData data;

		public readonly bool discovered;

		public readonly bool present;

		public readonly bool[] pieces;

		public readonly int piecesCount;

		public readonly int completed;

		public readonly int painted;

		public readonly int totalAssembled;

		public CollectionElement(int uid)
		{
			UID = uid;
			data = MiniatureDatabase.Get(uid);
			discovered = false;
			present = true;
			pieces = new bool[data.NecessaryPiecesCount];
			piecesCount = 0;
			completed = 0;
			painted = 0;
			totalAssembled = 0;
		}

		public CollectionElement(MiniatureData data)
		{
			UID = ((data != null) ? data.UID : 0);
			this.data = data;
			discovered = false;
			present = true;
			pieces = new bool[(data != null) ? data.NecessaryPiecesCount : 0];
			piecesCount = 0;
			completed = 0;
			painted = 0;
			totalAssembled = 0;
		}

		public CollectionElement(int uid, int completedCount, int paintedCount, HashSet<int> piecesSet)
		{
			UID = uid;
			data = MiniatureDatabase.Get(uid);
			discovered = true;
			present = completedCount + paintedCount > 0 || piecesSet.IsValid();
			pieces = new bool[(data != null) ? data.NecessaryPiecesCount : 0];
			piecesCount = 0;
			if (piecesSet.IsValid() && pieces.Length != 0)
			{
				for (int i = 0; i < data.NecessaryPiecesCount; i++)
				{
					if (piecesSet.Contains(i))
					{
						pieces[i] = true;
						piecesCount++;
					}
				}
			}
			completed = completedCount;
			painted = paintedCount;
			totalAssembled = completed + painted;
		}

		public CollectionElement(MiniatureData data, int completedCount, int paintedCount, HashSet<int> piecesSet)
		{
			UID = ((data != null) ? data.UID : 0);
			this.data = data;
			discovered = true;
			present = completedCount + paintedCount > 0 || piecesSet.IsValid();
			pieces = new bool[(data != null) ? data.NecessaryPiecesCount : 0];
			piecesCount = 0;
			if (piecesSet.IsValid() && pieces.Length != 0)
			{
				for (int i = 0; i < data.NecessaryPiecesCount; i++)
				{
					if (piecesSet.Contains(i))
					{
						pieces[i] = true;
						piecesCount++;
					}
				}
			}
			completed = completedCount;
			painted = paintedCount;
			totalAssembled = completed + painted;
		}

		public override int GetHashCode()
		{
			return UID;
		}

		public override bool Equals(object obj)
		{
			if (obj is CollectionElement collectionElement)
			{
				return UID == collectionElement.UID;
			}
			if (obj is bool flag)
			{
				return data != null == flag;
			}
			return false;
		}

		public static bool operator ==(CollectionElement e1, CollectionElement e2)
		{
			return e1.UID == e2.UID;
		}

		public static bool operator !=(CollectionElement e1, CollectionElement e2)
		{
			return e1.UID != e2.UID;
		}
	}
}
