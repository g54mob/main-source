using System;
using Febucci.TextAnimatorCore.Settings;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	[Serializable]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Settings/Typewriter Settings", fileName = "Typewriter Settings for Text Animator")]
	public class TypewriterSettingsScriptable : ScriptableObject, ISettingsProvider<UnityTypewriterSettings>
	{
		[SerializeField]
		public UnityTypewriterSettings settings = new UnityTypewriterSettings();

		public UnityTypewriterSettings Settings => settings;
	}
}
