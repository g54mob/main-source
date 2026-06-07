using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	public class RichPath
	{
		private int currentPart;

		private readonly List<RichPathPart> parts;

		public Seeker seeker;

		public ITransform transform;

		public Vector3 Endpoint { get; private set; }

		public bool CompletedAllParts => false;

		public bool IsLastPart => false;

		public void Clear()
		{
		}

		public void Initialize(Seeker seeker, Path path, bool mergePartEndpoints, bool simplificationMode)
		{
		}

		public void NextPart()
		{
		}

		public RichPathPart GetCurrentPart()
		{
			return null;
		}

		public void GetRemainingPath(List<Vector3> buffer, Vector3 currentPosition, out bool requiresRepath)
		{
			requiresRepath = default(bool);
		}
	}
}
