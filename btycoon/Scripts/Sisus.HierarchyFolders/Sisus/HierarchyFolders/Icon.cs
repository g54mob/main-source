using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Sisus.HierarchyFolders
{
	[Serializable]
	public class Icon
	{
		[CanBeNull]
		public Texture closed;

		[CanBeNull]
		public Texture open;

		public override bool Equals(object obj)
		{
			if (!(obj is Icon icon))
			{
				return false;
			}
			if (closed == icon.closed)
			{
				return open == icon.open;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (-2017190570 * -1521134295 + EqualityComparer<Texture>.Default.GetHashCode(closed)) * -1521134295 + EqualityComparer<Texture>.Default.GetHashCode(open);
		}
	}
}
