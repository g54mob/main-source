using DarkTonic.MasterAudio;
using UnityEngine;

[AudioScriptOrder(-10)]
public class ListenerFollower : MonoBehaviour
{
	private Transform _transToFollow;

	private GameObject _goToFollow;

	private Transform _trans;

	private GameObject _go;

	public GameObject GameObj => null;

	public Transform Trans => null;

	private void Awake()
	{
	}

	public void StartFollowing(Transform transToFollow, float trigRadius)
	{
	}

	public void ManualUpdate()
	{
	}

	private void BatchOcclusionRaycasts()
	{
	}
}
