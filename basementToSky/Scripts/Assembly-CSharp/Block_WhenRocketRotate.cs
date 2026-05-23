using MG_BlocksEngine2.Block.Instruction;
using UnityEngine;

public class Block_WhenRocketRotate : BE2_InstructionBase, I_BE2_Instruction
{
	public new string Operation()
	{
		string stringValue = base.Section0Inputs[0].StringValue;
		string stringValue2 = base.Section0Inputs[1].StringValue;
		float floatValue = base.Section0Inputs[2].FloatValue;
		if (GameManager.S.currentLanchedRocket == null)
		{
			return "0";
		}
		Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);
		Quaternion rotation2 = GameManager.S.currentLanchedRocket.transform.rotation;
		Quaternion quaternion = Quaternion.Inverse(rotation) * rotation2;
		Vector3 vector = quaternion * Vector3.forward;
		Vector3 vector2 = quaternion * Vector3.up;
		float num = 0f;
		num = stringValue switch
		{
			"X" => (0f - Mathf.Atan2(vector.y, vector.z)) * 57.29578f, 
			"Y" => Mathf.Atan2(vector.x, vector.z) * 57.29578f, 
			"Z" => (0f - Mathf.Atan2(vector2.x, vector2.y)) * 57.29578f, 
			_ => (0f - Mathf.Atan2(vector.y, vector.z)) * 57.29578f, 
		};
		bool flag = false;
		switch (stringValue2)
		{
		case "=":
			flag = Mathf.RoundToInt(num) == Mathf.RoundToInt(floatValue);
			break;
		case ">":
			flag = num > floatValue;
			break;
		case "<":
			flag = num < floatValue;
			break;
		}
		if (flag)
		{
			return "1";
		}
		return "0";
	}
}
