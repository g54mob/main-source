using System;
using UnityEngine.Events;

namespace Crosstales.FB
{
	[Serializable]
	public class OnOpenFilesCompleted : UnityEvent<bool, string, string>
	{
	}
}
