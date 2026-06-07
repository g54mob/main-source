using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	protected GameObject target;

	protected Camera ownCamera;

	[SerializeField]
	protected bool useUnscaledTime;

	public virtual GameObject Target
	{
		get
		{
			return target;
		}
		set
		{
			target = value;
		}
	}

	public Camera OwnCamera
	{
		get
		{
			return ownCamera;
		}
		protected set
		{
			ownCamera = value;
		}
	}

	private void OnValidate()
	{
		SpawnOwnCamera();
	}

	private void SpawnOwnCamera()
	{
		OwnCamera = GetComponentInChildren<Camera>();
		if (!OwnCamera)
		{
			GameObject gameObject = new GameObject("Camera", typeof(Camera));
			gameObject.transform.SetParent(base.transform);
			OwnCamera = gameObject.GetComponent<Camera>();
		}
	}

	protected virtual void Awake()
	{
		InitCamera();
	}

	protected virtual void InitCamera()
	{
		SpawnOwnCamera();
	}

	protected virtual float GetDeltaTime()
	{
		if (!useUnscaledTime)
		{
			return Time.deltaTime;
		}
		return Time.unscaledDeltaTime;
	}
}
