using UnityEngine;

public class CastleCenter : MonoBehaviour
{
	public static Vector3 CastleCenterPosition;

	public static CastleCenter instance;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		CastleCenterPosition = base.transform.position;
	}
}
