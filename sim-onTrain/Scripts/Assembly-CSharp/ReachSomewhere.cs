using UnityEngine;

public class ReachSomewhere : MonoBehaviour
{
	public string reachAddress;

	public bool triggerOnEnter = true;

	public bool oneTimeOnly = true;

	private bool hasTriggered;

	private void Start()
	{
		if (GetComponent<Collider>() == null)
		{
			base.gameObject.AddComponent<BoxCollider>().isTrigger = true;
			Debug.LogWarning("ReachSomewhere '" + reachAddress + "' için Collider eklendi. Boyutunu ayarlamayı unutma!");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (triggerOnEnter && other.CompareTag("Player"))
		{
			TriggerReach();
		}
	}

	public void TriggerReach()
	{
		if (oneTimeOnly && hasTriggered)
		{
			return;
		}
		if (string.IsNullOrEmpty(reachAddress))
		{
			Debug.LogError("ReachAddress boş! Lütfen bir adres girin.");
		}
		else if (TSPlayerTutorialManager.Instance != null)
		{
			TSPlayerTutorialManager.Instance.IncreaseReachSomewhere(reachAddress);
			hasTriggered = true;
			Debug.Log("Reached destination: " + reachAddress);
			if (oneTimeOnly)
			{
				base.gameObject.SetActive(value: false);
			}
		}
		else
		{
			Debug.LogError("TSPlayerTutorialManager bulunamadı!");
		}
	}
}
