using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Toggle GameObject (Enable-Disable)")]
	public class ToggleGameObject : MonoBehaviour
	{
		public int index;

		public GameObject[] gameObjects;

		public void SetActive(int index)
		{
			this.index = index;
			if (index < 0 || index >= gameObjects.Length)
			{
				for (int i = 0; i < gameObjects.Length; i++)
				{
					if (gameObjects[i] != null)
					{
						gameObjects[i].SetActive(value: true);
					}
				}
				return;
			}
			for (int j = 0; j < gameObjects.Length; j++)
			{
				if (gameObjects[j] != null)
				{
					gameObjects[j].SetActive(j == index);
				}
			}
		}

		public void SetActiveNext()
		{
			index++;
			if (index >= gameObjects.Length)
			{
				index = 0;
			}
			SetActive(index);
		}

		public void SetActivePrevious()
		{
			index--;
			if (index < 0)
			{
				index = gameObjects.Length - 1;
			}
			SetActive(index);
		}
	}
}
