using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Zoomer : MonoBehaviour
{
	[Readonly]
	public Examiner examiner;

	[Readonly]
	public HelpIris helpIris;

	[Readonly]
	public WatchHand watchHand;

	[Readonly]
	public List<Face> faces = new List<Face>();

	private bool active;

	private float fovDefault;

	private float fovSpeed;

	private Camera mainCamera;

	private int waitingForRelease;

	private int faceCheckRoundRobin;

	private Face.Score bestFaceScore = new Face.Score();

	private Face.Score workFaceScore = new Face.Score();

	private Face examinerFace
	{
		set
		{
			if (examiner != null)
			{
				examiner.face = value;
			}
		}
	}

	private void Start()
	{
		mainCamera = GetComponent<Camera>();
		fovDefault = mainCamera.fieldOfView;
	}

	private void OnEnable()
	{
		waitingForRelease = 2;
	}

	private void Update()
	{
		if (!Player.instance.inputEnabled)
		{
			waitingForRelease = 2;
			return;
		}
		if (waitingForRelease > 0)
		{
			if (!RInput.GetButton(53))
			{
				waitingForRelease--;
			}
			return;
		}
		bool flag = Player.instance.exploringNormally && RInput.GetButton(53);
		float num = 0f;
		if (flag)
		{
			UpdateBestFaceScore(true, 3);
			examinerFace = bestFaceScore.face;
			num = 40f;
		}
		else
		{
			UpdateBestFaceScore(false, 1);
			examinerFace = null;
			num = fovDefault;
		}
		UpdateHelpIris();
		mainCamera.fieldOfView = Mathf.SmoothDamp(mainCamera.fieldOfView, num, ref fovSpeed, 0.1f);
	}

	private void UpdateBestFaceScore(bool zooming, int maxExpensiveFacesToCheckPerFrame)
	{
		Face.Cost cost = Face.Cost.Cheap;
		workFaceScore.Invalidate();
		if (bestFaceScore.valid && !bestFaceScore.face.IsOnScreen(mainCamera, zooming, ref workFaceScore, ref cost))
		{
			bestFaceScore.Invalidate();
		}
		for (int i = 0; i < faces.Count; i++)
		{
			if (maxExpensiveFacesToCheckPerFrame <= 0)
			{
				break;
			}
			Face face = faces[faceCheckRoundRobin % faces.Count];
			faceCheckRoundRobin = (faceCheckRoundRobin + 1) % faces.Count;
			if (face != bestFaceScore.face)
			{
				if (face.IsOnScreen(mainCamera, false, ref workFaceScore, ref cost) && workFaceScore.IsBetterThan(bestFaceScore))
				{
					bestFaceScore.CopyFrom(workFaceScore);
				}
				if (cost == Face.Cost.Expensive)
				{
					maxExpensiveFacesToCheckPerFrame--;
				}
			}
			if (faceCheckRoundRobin == 0)
			{
				break;
			}
		}
	}

	private void UpdateHelpIris()
	{
		if (!(helpIris == null))
		{
			if (bestFaceScore.valid && Player.instance.exploringNormally && SaveData.it.HaveVisitedThisManyMoments(2))
			{
				helpIris.Charge(HelpIris.Kind.Zoom);
			}
			else
			{
				helpIris.Zero(HelpIris.Kind.Zoom);
			}
		}
	}
}
