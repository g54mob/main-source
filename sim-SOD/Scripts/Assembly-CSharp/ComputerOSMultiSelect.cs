using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ComputerOSMultiSelect : MonoBehaviour
{
	public delegate void NewSelection();

	public delegate void ChangePage();

	[Serializable]
	public class OSMultiOption
	{
		public string text;

		public Human human;

		public StateSaveData.MessageThreadSave msgThread;

		public int msgIndex;

		[NonSerialized]
		public Company.SalesRecord salesRecord;

		[NonSerialized]
		public Sprite iconSprite;

		public OSMultiOption(string newText, Human newHuman)
		{
		}

		public OSMultiOption()
		{
		}
	}

	public ComputerController controller;

	public GameObject elementPrefab;

	public List<ComputerOSMultiSelectElement> options;

	public RectTransform elementParent;

	public ComputerOSMultiSelectElement selected;

	public bool usePages;

	public int page;

	public int maxPerPage;

	public List<OSMultiOption> allOptions;

	public event NewSelection OnNewSelection
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event ChangePage OnChangePage
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Setup(ComputerController newComp)
	{
	}

	public void UpdateElements(List<OSMultiOption> newOptions)
	{
	}

	private void SpawnList()
	{
	}

	public void NextPage(int newPage)
	{
	}

	public void SetSelected(ComputerOSMultiSelectElement newSelection)
	{
	}
}
