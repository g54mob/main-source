using UnityEngine;

public class CruncherAppContent : MonoBehaviour
{
	public ComputerController controller;

	public virtual void Setup(ComputerController cc)
	{
	}

	public virtual void OnSetup()
	{
	}

	public virtual void PrintButton()
	{
	}

	public void OnPlayerTakePrint()
	{
	}
}
