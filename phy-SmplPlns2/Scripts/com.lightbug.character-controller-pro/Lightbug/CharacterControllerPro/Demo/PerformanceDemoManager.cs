using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class PerformanceDemoManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject characterPrefab;

		[SerializeField]
		private Transform prefabInstantiationReference;

		[SerializeField]
		private Text textField;

		[SerializeField]
		private float maxInstantiationDistance = 50f;

		private int numberOfCharacters;

		private List<CharacterActor> characterActors = new List<CharacterActor>(50);

		private void Awake()
		{
			if (characterPrefab == null)
			{
				Debug.Log("Missing prefab! Destroying this component...");
				Object.Destroy(this);
			}
		}

		public void AddCharacters(int charactersToAdd)
		{
			if (!(characterPrefab == null))
			{
				for (int i = 0; i < charactersToAdd; i++)
				{
					GameObject gameObject = Object.Instantiate(characterPrefab, prefabInstantiationReference.position + Vector3.right * Random.Range(0f - maxInstantiationDistance, maxInstantiationDistance) + Vector3.forward * Random.Range(0f - maxInstantiationDistance, maxInstantiationDistance), Quaternion.identity * Quaternion.Euler(0f, Random.Range(0f, 180f), 0f));
					characterActors.Add(gameObject.GetComponent<CharacterActor>());
				}
				numberOfCharacters += charactersToAdd;
				if (textField != null)
				{
					textField.text = numberOfCharacters.ToString();
				}
			}
		}

		public void RemoveCharacters(int charactersToEliminate)
		{
			if (numberOfCharacters < charactersToEliminate)
			{
				RemoveAllCharacters();
				return;
			}
			for (int num = charactersToEliminate - 1; num >= 0; num--)
			{
				Object.Destroy(characterActors[num].gameObject);
				characterActors.RemoveAt(num);
			}
			numberOfCharacters -= charactersToEliminate;
			if (textField != null)
			{
				textField.text = numberOfCharacters.ToString();
			}
		}

		public void RemoveAllCharacters()
		{
			RemoveCharacters(numberOfCharacters);
		}
	}
}
