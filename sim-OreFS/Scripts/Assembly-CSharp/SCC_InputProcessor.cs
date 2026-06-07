using UnityEngine;

[AddComponentMenu("BoneCracker Games/Simple Car Controller/SCC Input Processor")]
public class SCC_InputProcessor : MonoBehaviour
{
	public SCC_Inputs inputs = new SCC_Inputs();

	public bool inputActive;

	public bool receiveInputsFromInputManager = true;

	public bool smoothInputs = true;

	public float smoothingFactor = 5f;

	private void Update()
	{
		if (inputs == null)
		{
			inputs = new SCC_Inputs();
		}
		if (receiveInputsFromInputManager && inputActive)
		{
			if (smoothInputs)
			{
				inputs.throttleInput = Mathf.MoveTowards(inputs.throttleInput, SCC_Singleton<SCC_InputManager>.Instance.inputs.throttleInput, Time.deltaTime * smoothingFactor);
				inputs.steerInput = Mathf.MoveTowards(inputs.steerInput, SCC_Singleton<SCC_InputManager>.Instance.inputs.steerInput, Time.deltaTime * smoothingFactor);
				inputs.brakeInput = Mathf.MoveTowards(inputs.brakeInput, SCC_Singleton<SCC_InputManager>.Instance.inputs.brakeInput, Time.deltaTime * smoothingFactor);
				inputs.handbrakeInput = Mathf.MoveTowards(inputs.handbrakeInput, SCC_Singleton<SCC_InputManager>.Instance.inputs.handbrakeInput, Time.deltaTime * smoothingFactor);
			}
			else
			{
				inputs = SCC_Singleton<SCC_InputManager>.Instance.inputs;
			}
		}
		else if (receiveInputsFromInputManager && !inputActive)
		{
			inputs.throttleInput = 0f;
			inputs.steerInput = 0f;
			inputs.brakeInput = 0f;
			inputs.handbrakeInput = 0f;
		}
	}

	public void setGlobalInput(bool status)
	{
		inputActive = status;
	}

	public void OverrideInputs(SCC_Inputs newInputs)
	{
		if (!smoothInputs)
		{
			inputs = newInputs;
			return;
		}
		inputs.throttleInput = Mathf.MoveTowards(inputs.throttleInput, newInputs.throttleInput, Time.deltaTime * smoothingFactor);
		inputs.steerInput = Mathf.MoveTowards(inputs.steerInput, newInputs.steerInput, Time.deltaTime * smoothingFactor);
		inputs.brakeInput = Mathf.MoveTowards(inputs.brakeInput, newInputs.brakeInput, Time.deltaTime * smoothingFactor);
		inputs.handbrakeInput = Mathf.MoveTowards(inputs.handbrakeInput, newInputs.handbrakeInput, Time.deltaTime * smoothingFactor);
	}

	public void ResetInputs()
	{
		if (inputs == null)
		{
			inputs = new SCC_Inputs();
		}
		inputs.throttleInput = 0f;
		inputs.steerInput = 0f;
		inputs.brakeInput = 0f;
		inputs.handbrakeInput = 1f;
	}
}
