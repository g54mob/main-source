using System.Collections;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	public abstract class TileGeneratorBase : PersistentProperties
	{
		public override Types Type => Types.TileGeneratorBase;

		public Vector2 StartPosition { get; protected set; } = Vector2.zero;

		public abstract Rect MinimumBounds { get; }

		public abstract float Scale { get; set; }

		public virtual bool IsEndTile => false;

		public abstract void Initialize(bool isStartingTile = false);

		public virtual IEnumerator Generate(IWorldTile worldTile, int seed)
		{
			Debug.Log($"TileGenerator seed: {seed}");
			Random.InitState(seed);
			yield return Generate(worldTile);
		}

		public abstract IEnumerator Generate(IWorldTile worldTile);

		public virtual void Restore(IWorldTile worldTile)
		{
		}

		public abstract bool TryReturnTownheartStartPosition(out Vector3 position);

		public virtual bool TryReturnWorldMapRegionMeshAndBounds(out Mesh mesh, out Rect bounds)
		{
			mesh = null;
			bounds = default(Rect);
			return false;
		}

		public virtual bool HasRegionOfType(params WorldRegionType[] worldRegionTypes)
		{
			return true;
		}
	}
}
