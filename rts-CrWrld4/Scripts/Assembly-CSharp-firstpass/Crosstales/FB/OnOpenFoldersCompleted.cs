using System;
using UnityEngine.Events;

namespace Crosstales.FB
{
	[Serializable]
	public class OnOpenFoldersCompleted : UnityEvent<bool, string, string>
	{
	}
}
