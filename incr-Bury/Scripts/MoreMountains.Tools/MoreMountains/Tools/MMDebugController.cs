using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Utilities/MM Debug Controller")]
	public class MMDebugController : MonoBehaviour
	{
		public bool DebugLogsEnabled = true;

		public bool DebugDrawEnabled = true;

		protected virtual void Awake()
		{
			MMDebug.SetDebugLogsEnabled(DebugLogsEnabled);
			MMDebug.SetDebugDrawEnabled(DebugDrawEnabled);
		}
	}
}
