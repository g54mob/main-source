using SimulationScripts.BibiteScripts;
using UnityEngine;

public class BrainIconHolder : MonoBehaviour
{
	public static BrainIconHolder instance;

	public Sprite[] brainIcons;

	public Sprite[] brainFunctionsIcons;

	private void Start()
	{
		instance = this;
	}

	public Sprite GetIconOfIndex(int i)
	{
		return brainIcons[i];
	}

	public Sprite GetIconOfFunction(NEATBrain.NodeType type)
	{
		return brainFunctionsIcons[(int)(type - 1)];
	}
}
