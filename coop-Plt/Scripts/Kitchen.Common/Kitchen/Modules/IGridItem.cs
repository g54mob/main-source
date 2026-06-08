using UnityEngine;

namespace Kitchen.Modules
{
	public interface IGridItem
	{
		int SnapshotKey { get; }

		Texture2D GetSnapshot();
	}
}
