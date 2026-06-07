using System.Collections;
using DV;
using UnityEngine;

public class TutorialPlayerDetector : MonoBehaviour
{
	public enum TutorialPlayerDetectorType
	{
		Office = 0,
		NearLoco = 1,
		CargoCar = 2,
		InsideCab = 3,
		NearCouplers = 4,
		NewLoco = 5,
		TurntableController = 6,
		StationOffice = 7,
		Bounds = 8
	}

	public delegate void PlayerPresenceDelegate(TutorialPlayerDetector sender, bool playerPresent);

	public bool playerPresent;

	public TutorialPlayerDetectorType detectorType;

	[SerializeField]
	private Transform hint;

	[SerializeField]
	private bool intervalCheck;

	[SerializeField]
	private float intervalDuration;

	private Collider[] detectionColliders;

	private Coroutine checkCoro;

	private bool checkInProgress;

	public event PlayerPresenceDelegate PlayerPresenceChanged;

	public Transform GetHintTransform()
	{
		if (!(hint != null))
		{
			return base.transform;
		}
		return hint;
	}

	private void Awake()
	{
		detectionColliders = GetComponentsInChildren<Collider>(includeInactive: true);
		if (!checkInProgress)
		{
			base.enabled = false;
		}
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			playerPresent = false;
			checkInProgress = false;
			if (checkCoro != null)
			{
				StopCoroutine(checkCoro);
				checkCoro = null;
			}
		}
	}

	public void StartChecking(bool intervalCheck = false, float intervalDuration = 0f)
	{
		this.intervalCheck = intervalCheck;
		this.intervalDuration = intervalDuration;
		base.enabled = true;
		checkInProgress = true;
		if (intervalCheck)
		{
			if (checkCoro != null)
			{
				StopCoroutine(checkCoro);
			}
			checkCoro = StartCoroutine(IntervalCheck());
		}
	}

	public void StopChecking()
	{
		base.enabled = false;
		checkInProgress = false;
	}

	private void LateUpdate()
	{
		if (!intervalCheck)
		{
			CheckForPlayer();
		}
	}

	private IEnumerator IntervalCheck()
	{
		while (true)
		{
			yield return WaitFor.Seconds(intervalDuration);
			CheckForPlayer();
		}
	}

	private void CheckForPlayer()
	{
		if (PlayerManager.PlayerCamera == null || !TimeUtil.IsFlowing)
		{
			return;
		}
		Vector3 position = PlayerManager.PlayerCamera.transform.position;
		bool flag = false;
		Collider[] array = detectionColliders;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].ClosestPoint(position) == position)
			{
				flag = true;
				break;
			}
		}
		if (playerPresent != flag)
		{
			playerPresent = flag;
			this.PlayerPresenceChanged?.Invoke(this, playerPresent);
		}
	}
}
