using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkScale : MonoBehaviour
{
	public List<GameObject> scaledObject = new List<GameObject>();

	public float valueMult = 1f;

	[SerializeField]
	private TrashBin[] bins;

	private void Start()
	{
		StartCoroutine(CleanListRoutine());
	}

	private void Update()
	{
	}

	private IEnumerator CleanListRoutine()
	{
		while (true)
		{
			for (int num = scaledObject.Count - 1; num >= 0; num--)
			{
				GameObject gameObject = scaledObject[num];
				if (gameObject == null || !gameObject.activeInHierarchy || !gameObject.GetComponentInChildren<Collider>().enabled)
				{
					scaledObject.RemoveAt(num);
				}
			}
			yield return new WaitForSeconds(0.2f);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.name);
		if (other.gameObject.TryGetComponent<ITrash>(out var component))
		{
			scaledObject.Add(other.gameObject);
			component.OnStatusChanged += Trash_OnStatusChanged;
		}
	}

	private void Trash_OnStatusChanged(ITrash trash)
	{
		GameObject item = (trash as MonoBehaviour).gameObject;
		if (scaledObject.Contains(item))
		{
			scaledObject.Remove(item);
			trash.OnStatusChanged -= Trash_OnStatusChanged;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log(other.gameObject.name);
		if (other.gameObject.TryGetComponent<ITrash>(out var component) && scaledObject.Contains(other.gameObject))
		{
			scaledObject.Remove(other.gameObject);
			component.OnStatusChanged -= Trash_OnStatusChanged;
		}
	}

	public float GetTotalValue()
	{
		float num = 0f;
		foreach (GameObject item in scaledObject)
		{
			num += item.GetComponent<Rigidbody>().mass;
		}
		return Mathf.Round(num * valueMult * 10f) / 10f;
	}

	public void ClearAll()
	{
		foreach (GameObject item in scaledObject)
		{
			Object.Destroy(item);
		}
		scaledObject.Clear();
		TrashBin[] array = bins;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].RefillTrashes();
		}
	}
}
