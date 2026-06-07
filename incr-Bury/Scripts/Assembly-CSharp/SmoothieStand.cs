using UnityEngine;

public class SmoothieStand : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			Berry component = other.transform.root.gameObject.GetComponent<Berry>();
			PickUppable component2 = other.transform.root.gameObject.GetComponent<PickUppable>();
			if ((bool)component && (bool)component2 && component2.GetItemIdentity() == ItemIdentity.Smoothie)
			{
				Puzzle_Smoothie.Singleton.CheckEnteredSmoothie(component);
			}
		}
	}
}
