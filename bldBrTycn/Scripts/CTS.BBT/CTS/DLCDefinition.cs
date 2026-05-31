using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/DLC/DLC Definition", fileName = "DLCDefinition")]
	public class DLCDefinition : ScriptableObject
	{
		[SerializeField]
		private ScriptableLoader[] _scriptableLoaders;

		[field: SerializeField]
		public StringKey DLCKey { get; private set; }

		public bool IsDLCInstalled()
		{
			return CTSSingleton<GamePlatform>.Instance.Library.IsDLCInstalled(DLCKey);
		}

		public virtual void OnLoaded()
		{
			ScriptableLoader[] scriptableLoaders = _scriptableLoaders;
			for (int i = 0; i < scriptableLoaders.Length; i++)
			{
				scriptableLoaders[i].Load();
			}
		}
	}
}
