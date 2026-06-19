using UnityEngine;
using UnityEngine.UI;

public class DogBuilderTab : MonoBehaviour
{
	public GeneCategory category;

	public bool activateOnStart;

	private void Start()
	{
		AddCallback();
		if (activateOnStart)
		{
			GetComponent<Button>().onClick.Invoke();
		}
	}

	private void AddCallback()
	{
		DogBuilder builderRef = base.transform.root.GetComponent<DogBuilder>();
		if (builderRef == null)
		{
			builderRef = base.transform.root.GetComponentInChildren<DogBuilder>();
		}
		if (builderRef != null)
		{
			GetComponent<Button>().onClick.AddListener(delegate
			{
				builderRef.SetGeneCategory(category, base.gameObject);
			});
		}
	}
}
