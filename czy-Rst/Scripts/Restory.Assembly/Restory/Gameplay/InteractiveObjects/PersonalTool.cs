using Restory.Data.Equipment;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public class PersonalTool : PersonalObjectBase
	{
		[SerializeField]
		private ToolInfo toolInfo;

		public ToolInfo ToolInfo => toolInfo;
	}
}
