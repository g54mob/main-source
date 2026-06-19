using System.Collections.Generic;
using UnityEngine;

public class InputSimulator : MonoBehaviour
{
	private List<KeyCode> simulatedInput = new List<KeyCode>();

	private Dictionary<GameObject, List<KeyCode>> dogSpecificSimulatedInput = new Dictionary<GameObject, List<KeyCode>>();

	public void SimulateInputList(List<KeyCode> keys)
	{
		simulatedInput.Clear();
		simulatedInput.AddRange(keys);
	}

	public void ClearInputForDog(GameObject dog)
	{
		dogSpecificSimulatedInput.Remove(dog);
	}

	public void ClearInput()
	{
		simulatedInput.Clear();
		dogSpecificSimulatedInput.Clear();
	}

	public List<KeyCode> GetSimulatedInput()
	{
		return simulatedInput;
	}

	public bool HasSimulatedInput()
	{
		return simulatedInput.Count > 0;
	}
}
