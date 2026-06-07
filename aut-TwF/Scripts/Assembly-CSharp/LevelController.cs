using UnityEngine;
using UnityEngine.Rendering;

public class LevelController : MonoBehaviour
{
	[SerializeField]
	private Transform spawnTransform;

	[SerializeField]
	private Volume postProcessingProfile;

	public Transform SpawnTransform
	{
		get
		{
			return spawnTransform;
		}
		set
		{
			spawnTransform = value;
		}
	}

	public Volume PostProcessingProfile
	{
		get
		{
			return postProcessingProfile;
		}
		set
		{
			postProcessingProfile = value;
		}
	}

	protected virtual void Awake()
	{
		if ((bool)GameManager.instance)
		{
			GameManager.instance.CurrentLevelController = this;
		}
	}

	protected virtual void Start()
	{
	}
}
