using System.Collections.Generic;
using UnityEngine;

public class FileSystemController : MonoBehaviour
{
	public enum StackType
	{
		filingSystem = 0,
		pile = 1
	}

	[Header("Setup")]
	public StackType stackMode;

	public InteractableController controller;

	public GameObject filePrefab;

	public Vector3 pagesOffset;

	public EvidenceMultiPage ev;

	[Space(5f)]
	[Tooltip("Apply a postion & rotation to the top pages group")]
	public Vector3 frontPagesPos;

	public Vector3 frontPagesEuler;

	public Dictionary<int, List<EvidenceMultiPage.MultiPageContent>> content;

	public int pageCount;

	[Header("File System")]
	public Transform frontBunch;

	public Transform rearBunch;

	public int currentPage;

	public List<Transform> fontPages;

	public List<Transform> rearPages;

	private float moveProgress;

	public void Setup(InteractableController newController)
	{
	}

	public void SetPage(int newPage, bool instant = false)
	{
	}

	private void Update()
	{
	}
}
