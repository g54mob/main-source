using Sirenix.OdinInspector;
using UnityEngine;

namespace Platforms.PlatformDebugConfigurations
{
	[CreateAssetMenu(menuName = "Kitchen/Build/Platform Debug Config", fileName = "PlatformDebugConfiguration", order = 0)]
	public class PlatformDebugConfiguration : SerializedScriptableObject
	{
		private static PlatformDebugConfiguration _Default;

		public bool Active;

		public GenericDebugConfig Generic;

		public SwitchFailureFlags Switch;

		public static PlatformDebugConfiguration Default
		{
			get
			{
				if (_Default == null)
				{
					SetSingleton();
				}
				return _Default;
			}
			private set
			{
				_Default = value;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void SetSingleton()
		{
		}
	}
}
