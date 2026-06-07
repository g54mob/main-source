using System;
using UnityEngine.Events;

namespace Crosstales.FB
{
	[Serializable]
	public class OnSaveFileCompleted : UnityEvent<bool, string>
	{
	}
}
