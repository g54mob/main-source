using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Elements
{
	public class FileDirectoryBar : MonoBehaviour
	{
		private List<UIPathButton> folderButtonsList;

		public GameObject pathButtonPrefab;

		public Transform pathArea;

		[NonSerialized]
		[HideInInspector]
		public UIPathButton currentFolderButton;

		private Action<string> OnDirectorySelected;

		public void Init(Action<string> onDirectorySelected, string path)
		{
		}

		public void AddButton(string folderPath, string name = null)
		{
		}

		public void OnFolderSelected(UIPathButton folderButton)
		{
		}

		public void RemoveFolderFromPath()
		{
		}

		public void RemoveButton(int i)
		{
		}
	}
}
