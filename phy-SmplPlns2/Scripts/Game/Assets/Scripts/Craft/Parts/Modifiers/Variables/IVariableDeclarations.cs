using System.Collections.Generic;

namespace Assets.Scripts.Craft.Parts.Modifiers.Variables
{
	public interface IVariableDeclarations : IVariableOutput
	{
		IEnumerator<string> GetVariableOutputs();
	}
}
