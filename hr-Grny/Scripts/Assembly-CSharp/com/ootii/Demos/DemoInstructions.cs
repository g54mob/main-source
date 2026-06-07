using UnityEngine;
using UnityEngine.UI;

namespace com.ootii.Demos
{
	public class DemoInstructions : MonoBehaviour
	{
		[Tooltip("Contains the Title, Description, and Input Settings to display.")]
		public DemoProperties DemoProperties;

		[Tooltip("Key to toggle the instructions panel on or off.")]
		public KeyCode ToggleKey;

		[Header("Item Template")]
		[Tooltip("Prefab template for displaying the input items.")]
		public GameObject InputItemPrefab;

		[Header("UI Elements")]
		[Tooltip("Text UI element to display the title.")]
		public Text Title;

		[Tooltip("Text UI element to display the description.")]
		public Text Description;

		[Tooltip("UI Element that holds the input items.")]
		public RectTransform InputItemsPanel;

		[Tooltip("The CanvasGroup that controls this element's visibility.")]
		public CanvasGroup CanvasGroup;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private bool GetKeyDown(KeyCode rKey)
		{
			return false;
		}
	}
}
