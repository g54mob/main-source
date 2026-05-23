using UnityEngine;

public class MyTubeManager : MonoBehaviour
{
	public static MyTubeManager S;

	public int totalSubscribers;

	public int lastVidSubscribers;

	public void Awake()
	{
		if (S != null && S != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			S = this;
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
