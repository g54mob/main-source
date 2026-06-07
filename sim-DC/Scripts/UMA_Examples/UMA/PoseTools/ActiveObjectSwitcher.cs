using UnityEngine;

namespace UMA.PoseTools
{
	public class ActiveObjectSwitcher : MonoBehaviour
	{
		public GameObject[] objects;

		public GameObject activeObj;

		private int selected;

		private string[] names;

		public int xPos;

		public int yPos;

		private void Start()
		{
		}

		private void OnGUI()
		{
		}
	}
}
