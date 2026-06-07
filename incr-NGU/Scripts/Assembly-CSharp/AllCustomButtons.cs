using UnityEngine;

public class AllCustomButtons : MonoBehaviour
{
	public CustomButton1Controller energy1;

	public CustomButton1Controller energy2;

	public CustomButton1Controller magic1;

	public CustomButton1Controller magic2;

	public void updateMenu()
	{
		energy1.updateButtons();
		energy2.updateButtons();
		magic1.updateButtons();
		magic2.updateButtons();
	}
}
