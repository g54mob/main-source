using MG_BlocksEngine2.Block.Instruction;

public class Block_WhenRocketReachHeight : BE2_InstructionBase, I_BE2_Instruction
{
	public new string Operation()
	{
		string stringValue = base.Section0Inputs[0].StringValue;
		float floatValue = base.Section0Inputs[1].FloatValue;
		if (GameManager.S.currentLanchedRocket == null)
		{
			return "0";
		}
		bool flag = false;
		switch (stringValue)
		{
		case "=":
			flag = GameManager.S.currentLanchedRocket.transform.position.y == floatValue;
			break;
		case ">":
			flag = GameManager.S.currentLanchedRocket.transform.position.y > floatValue;
			break;
		case "<":
			flag = GameManager.S.currentLanchedRocket.transform.position.y < floatValue;
			break;
		}
		if (flag)
		{
			return "1";
		}
		return "0";
	}
}
