using UnityEngine;

public class VampireSurvivorsBatToggle : MonoBehaviour
{
	public void ClickedToggle(bool isOn)
	{
		if (!isOn)
		{
			for (int num = GameManager.ins.vampireBats.Count - 1; num >= 0; num--)
			{
				GameObject obj = GameManager.ins.vampireBats[num].gameObject;
				GameManager.ins.vampireBats.RemoveAt(num);
				Object.Destroy(obj);
			}
		}
	}
}
