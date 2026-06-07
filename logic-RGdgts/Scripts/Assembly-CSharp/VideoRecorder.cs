using System.Collections.Generic;
using RenderHeads.Media.AVProMovieCapture;
using SE.EvilLib.Core;
using UnityEngine;

public class VideoRecorder : MonoBehaviour
{
	private static VideoRecorder _Instance;

	private string savePath;

	[Separator]
	[SerializeField]
	private Material matCursor;

	[SerializeField]
	private Camera camRec;

	[SerializeField]
	private Transform mouseTarget;

	[Separator]
	[SerializeField]
	private bool testWithoutSaving;

	[ReadOnly]
	[SerializeField]
	private bool isRecording;

	[ReadOnly]
	[SerializeField]
	private string lastVideoFileName;

	[Space]
	public bool dbgCmd_openRecDir;

	[Space]
	[SerializeField]
	private VideoRecordPresetId testPresetId;

	public bool dbgCmd_startRec;

	public bool dbgCmd_stopRec;

	private List<VideoRecordPreset> videoRecPresets;

	private VideoRecordPreset curRecPreset;

	private CaptureFromTexture capturePlugin;

	private Camera camMain;

	private Vector3 mousePosPixel;

	private Vector3 mousePosWorld;

	private RenderTexture rt;

	public static VideoRecorder Instance => null;

	public bool IsRecording => false;

	public void DBGCMD_OPENRECDIR()
	{
	}

	public void DBGCMD_STARTREC()
	{
	}

	public void DBGCMD_STOPREC()
	{
	}

	private void Start()
	{
	}

	private void Init()
	{
	}

	private void LateUpdate()
	{
	}

	private void UpdateMouseTarget()
	{
	}

	public void StartRecording(VideoRecordPresetId presetId)
	{
	}

	public void StopRecording()
	{
	}

	private void UpdateRenderTexture()
	{
	}
}
