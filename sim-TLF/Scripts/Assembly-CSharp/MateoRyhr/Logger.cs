using UnityEngine;

namespace MateoRyhr
{
	public class Logger : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField]
		private bool _showLog;

		public void Log(object message, Object sender)
		{
			if (_showLog)
			{
				Debug.Log(message, sender);
			}
		}
	}
}
