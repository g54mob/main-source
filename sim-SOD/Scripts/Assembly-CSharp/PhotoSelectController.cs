using System.Collections.Generic;
using UnityEngine;

public class PhotoSelectController : MonoBehaviour
{
	public class CitAsk
	{
		public Human citizen;

		public Case.CaseElement element;
	}

	[Header("References")]
	public RectTransform pageRect;

	public WindowContentController wcc;

	[Header("Prefabs")]
	public GameObject photoPrefab;

	private List<PhotoSelectButtonController> spawned;

	public void Setup(WindowContentController newWcc)
	{
	}
}
