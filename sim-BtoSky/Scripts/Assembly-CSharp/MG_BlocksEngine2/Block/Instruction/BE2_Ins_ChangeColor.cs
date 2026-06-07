using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_ChangeColor : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private string _value;

		public new void Function()
		{
			_input0 = base.Section0Inputs[0];
			_value = _input0.StringValue;
			Color color = Color.white;
			switch (_value)
			{
			case "Random":
				color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 255f);
				break;
			case "Red":
				ColorUtility.TryParseHtmlString("#FF0000", out color);
				break;
			case "Orange":
				ColorUtility.TryParseHtmlString("#FF7F00", out color);
				break;
			case "Yellow":
				ColorUtility.TryParseHtmlString("#FFFF00", out color);
				break;
			case "Green":
				ColorUtility.TryParseHtmlString("#00FF00", out color);
				break;
			case "Blue":
				ColorUtility.TryParseHtmlString("#0000FF", out color);
				break;
			case "Indigo":
				ColorUtility.TryParseHtmlString("#2E2B5F", out color);
				break;
			case "Violet":
				ColorUtility.TryParseHtmlString("#8B00FF", out color);
				break;
			}
			base.TargetObject.Transform.GetComponent<Renderer>().materials[0].SetColor("_Color", color);
			ExecuteNextInstruction();
		}
	}
}
