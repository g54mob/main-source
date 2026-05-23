#define ENABLE_DEBUG_LOGS
using Logic.Factory;
using UnityEngine;
using Utils;

namespace DebugTools
{
	public class AutoSaveOnQuit : MonoBehaviour
	{
		[SerializeField]
		private FactorySaver _factorySaver;

		private void OnApplicationQuit()
		{
			string text = SaveSystem.GameSavePath + "\\AutoSaveOnQuit";
			_factorySaver.SaveFactory(text);
			this.Log("AutoSave on quit to " + text, "OnApplicationQuit", 16);
		}
	}
}
