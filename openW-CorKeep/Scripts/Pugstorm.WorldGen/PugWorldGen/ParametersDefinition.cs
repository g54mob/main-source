using UnityEngine;

namespace PugWorldGen
{
	[CreateAssetMenu(menuName = "Pug/World Gen/Parameters Definition", fileName = "Parameters Definition", order = 1)]
	public class ParametersDefinition : ScriptableObject
	{
		public ParameterDefinition[] parameters = new ParameterDefinition[0];
	}
}
