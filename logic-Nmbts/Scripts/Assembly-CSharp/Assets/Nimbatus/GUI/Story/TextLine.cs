using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.GUI.Story
{
	[Serializable]
	public class TextLine
	{
		public TranslationTerm Text;

		public bool Italic;

		public bool AutoContinue;

		public bool UsePreviousLabel;

		[ShowIf("UsePreviousLabel", true)]
		public int ReturnsToAdd;

		[HideIf("UsePreviousLabel", true)]
		public float LocalYPosition;

		[HideIf("UsePreviousLabel", true)]
		public bool OverwriteFontSize;

		[HideIf("UsePreviousLabel", true)]
		[ShowIf("OverwriteFontSize", true)]
		public int FontSize;

		[HideIf("UsePreviousLabel", true)]
		public bool Center;
	}
}
