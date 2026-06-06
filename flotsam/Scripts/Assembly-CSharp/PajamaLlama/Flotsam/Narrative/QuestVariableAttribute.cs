using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	public class QuestVariableAttribute : PropertyAttribute
	{
		public QuestVariableType Type { get; private set; }

		public QuestVariableAttribute(QuestVariableType type)
		{
			Type = type;
		}
	}
}
