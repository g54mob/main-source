using System.Text;
using UnityEngine;

namespace UMA.CharacterSystem.Examples
{
	public class LogToText : MonoBehaviour
	{
		private StringBuilder buffer;

		private bool changed;

		private void Start()
		{
		}

		private void Application_logMessageReceivedThreaded(string condition, string stackTrace, LogType type)
		{
		}

		private void Update()
		{
		}
	}
}
