using System;
using Coherence.Common;
using Coherence.Log;
using UnityEngine;

namespace Coherence.Toolkit
{
	public class FloatingOriginManager
	{
		public const float WorldPositionMaxRange = 1.7014117E+38f;

		public const double FloatingOriginPreciseRange = 10000000000000.0;

		public Action<FloatingOriginShiftArgs> OnFloatingOriginShifted;

		public Action<FloatingOriginShiftArgs> OnAfterFloatingOriginShifted;

		private readonly IClient client;

		private readonly IEntitiesManager entitiesManager;

		private readonly Coherence.Log.Logger logger;

		internal FloatingOriginManager(IClient client, IEntitiesManager entitiesManager, Coherence.Log.Logger logger)
		{
		}

		public bool SetFloatingOrigin(Vector3d newOrigin)
		{
			return false;
		}

		public Vector3d GetFloatingOrigin()
		{
			return default(Vector3d);
		}

		public bool TranslateFloatingOrigin(Vector3d translation)
		{
			return false;
		}

		public bool TranslateFloatingOrigin(Vector3 translation)
		{
			return false;
		}

		private void ShiftNetworkedObjectPositions(Vector3d delta)
		{
		}
	}
}
