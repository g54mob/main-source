using UnityEngine;

public class UniqueSectionOffset : MonoBehaviour
{
	private static int counter;

	private void Awake()
	{
		MeshRenderer component = base.gameObject.GetComponent<MeshRenderer>();
		if (component != null)
		{
			for (int i = 0; i < component.materials.Length; i++)
			{
				counter = (counter + 1) % 64;
			}
		}
	}
}
