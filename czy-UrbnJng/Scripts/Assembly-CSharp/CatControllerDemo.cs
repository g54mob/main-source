using MalbersAnimations.Controller;
using UnityEngine;

public class CatControllerDemo : MonoBehaviour
{
	public MAnimal mAnimal;

	public void PlayMode(int modeNumber)
	{
		mAnimal.Mode_Activate(modeNumber);
	}
}
