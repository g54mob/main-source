using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Assets.Nimbatus.Scripts.Tutorial
{
	public class Tutorial : SerializedScriptableObject
	{
		public ETutorialDifficulty Difficulty;

		public ETutorialType TutorialType;

		public TranslationTerm Name;

		[OdinSerialize]
		protected internal List<Subtutorial> Subtutorials = new List<Subtutorial>();
	}
}
