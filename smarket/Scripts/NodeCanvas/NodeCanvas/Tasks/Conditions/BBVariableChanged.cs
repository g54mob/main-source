using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Name("On Variable Changed", 0)]
	[Category("✫ Blackboard")]
	public class BBVariableChanged : ConditionTask
	{
		[BlackboardOnly]
		public BBObjectParameter targetVariable;

		protected override string info => null;

		protected override string OnInit()
		{
			return null;
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override bool OnCheck()
		{
			return false;
		}

		private void OnValueChanged(object varValue)
		{
		}
	}
}
