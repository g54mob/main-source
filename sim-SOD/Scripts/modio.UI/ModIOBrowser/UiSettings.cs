using ModIOBrowser.Implementation;
using UnityEngine;

namespace ModIOBrowser
{
	[CreateAssetMenu(fileName = "UiSettings.asset", menuName = "ModIo/UiSettings")]
	public class UiSettings : ScriptableObject
	{
		public bool StandaloneUsesVKDelegate;

		public bool AndroidUsesVKDelegate;

		public bool IOSUsesVKDelegate;

		public TranslatedLanguages Language;

		[HideInInspector]
		public GlyphPlatforms GlyphPlatform;

		[Range(0f, 1f)]
		public float volume;

		public bool ShouldWeUseVirtualKeyboardDelegate()
		{
			return false;
		}
	}
}
