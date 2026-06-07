using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class RunnerInstructionsList : TRunner<InstructionList>
	{
		public void Cancel()
		{
			m_Value?.Cancel();
		}
	}
}
