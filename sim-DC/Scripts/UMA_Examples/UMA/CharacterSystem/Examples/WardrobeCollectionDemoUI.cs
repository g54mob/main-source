using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UMA.CharacterSystem.Examples
{
	public class WardrobeCollectionDemoUI : MonoBehaviour
	{
		public TestCustomizerDD thisCustomizer;

		public GameObject collectionButtonPrefab;

		public int coverImageIndex;

		public GameObject dialogBoxes;

		public GameObject messageBox;

		public Text messageHeader;

		public Text messageBody;

		public UnityEvent onLoadCollection;

		public void OnEnable()
		{
		}

		public void GenerateCollectionButtons()
		{
		}

		public void LoadSelectedCollection(string collectionName)
		{
		}
	}
}
