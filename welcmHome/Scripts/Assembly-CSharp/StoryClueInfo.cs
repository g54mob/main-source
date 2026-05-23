using UnityEngine;

public class StoryClueInfo : MonoBehaviour
{
	[SerializeField]
	private string storyClueName;

	[SerializeField]
	[TextArea(3, 10)]
	private string storyClueInfo;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public string ReturnName()
	{
		return storyClueName;
	}

	public string ReturnTextInfo()
	{
		return storyClueInfo;
	}
}
