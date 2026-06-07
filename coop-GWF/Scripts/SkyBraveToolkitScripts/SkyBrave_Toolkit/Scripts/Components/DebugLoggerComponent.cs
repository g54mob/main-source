using UnityEngine;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class DebugLoggerComponent : MonoBehaviour
	{
		[Header("Logic")]
		[SerializeField]
		private bool _showLogs = true;

		[SerializeField]
		private string _prefix;

		[SerializeField]
		private Color _prefixColor = Color.yellow;

		private string _hexColor;

		private void OnValidate()
		{
			_hexColor = "#" + ColorUtility.ToHtmlStringRGBA(_prefixColor);
		}

		public void LogMessageWithSender(object message, Object sender)
		{
			if (_showLogs)
			{
				Debug.Log($"<color={_hexColor}>{_prefix}:</color> {message}", sender);
			}
		}

		public void LogMessage(string message)
		{
			if (_showLogs)
			{
				Debug.Log("<color=" + _hexColor + ">" + _prefix + ":</color> " + message);
			}
		}
	}
}
