using System;
using Febucci.TextAnimatorCore.Settings;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	[Serializable]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Settings/Animator Settings", fileName = "Animator Settings for Text Animator")]
	public class AnimatorSettingsScriptable : ScriptableObject, ISettingsProvider<AnimatorSettings>
	{
		[SerializeField]
		private AnimatorSettings settings = new AnimatorSettings();

		public AnimatorSettings Settings => settings;
	}
}
