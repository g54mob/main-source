using OUSystems.Basics.DataStructures;
using UnityEngine;

public class SceneInteractionUI : MonoBehaviour
{
	private static int _disabledStacks;

	public static BoolContainer Enabled { get; private set; }

	public static void StackDisable()
	{
	}

	public static void StackEnable()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnUpdateEnabled(bool enabled)
	{
	}
}
