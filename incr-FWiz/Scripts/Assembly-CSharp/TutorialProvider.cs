using UnityEngine;

public class TutorialProvider : MonoBehaviour
{
	private TutorialData _currentTutorial;

	[SerializeField]
	protected bool _destroyed { get; private set; }

	public bool Initiated { get; private set; }

	private void Start()
	{
	}

	public void DoInitiate()
	{
	}

	public virtual void Initiate()
	{
	}

	public void SetTutorial(TutorialData tutorial)
	{
	}

	public virtual void OnDestroy()
	{
	}
}
