using System.Linq;
using UnityEngine;

public class OVRLipSyncContextMorphTarget : MonoBehaviour
{
	[Tooltip("Skinned Mesh Rendered target to be driven by Oculus Lipsync")]
	public SkinnedMeshRenderer skinnedMeshRenderer;

	[Tooltip("Blendshape index to trigger for each viseme.")]
	public int[] visemeToBlendTargets = Enumerable.Range(0, OVRLipSync.VisemeCount).ToArray();

	[Tooltip("Enable using the test keys defined below to manually trigger each viseme.")]
	public bool enableVisemeTestKeys;

	[Tooltip("Test keys used to manually trigger an individual viseme - by default the QWERTY row of a US keyboard.")]
	public KeyCode[] visemeTestKeys = new KeyCode[15]
	{
		KeyCode.BackQuote,
		KeyCode.Tab,
		KeyCode.Q,
		KeyCode.W,
		KeyCode.E,
		KeyCode.R,
		KeyCode.T,
		KeyCode.Y,
		KeyCode.U,
		KeyCode.I,
		KeyCode.O,
		KeyCode.P,
		KeyCode.LeftBracket,
		KeyCode.RightBracket,
		KeyCode.Backslash
	};

	[Tooltip("Test key used to manually trigger laughter and visualise the results")]
	public KeyCode laughterKey = KeyCode.CapsLock;

	[Tooltip("Blendshape index to trigger for laughter")]
	public int laughterBlendTarget = OVRLipSync.VisemeCount;

	[Range(0f, 1f)]
	[Tooltip("Laughter probability threshold above which the laughter blendshape will be activated")]
	public float laughterThreshold = 0.5f;

	[Range(0f, 3f)]
	[Tooltip("Laughter animation linear multiplier, the final output will be clamped to 1.0")]
	public float laughterMultiplier = 1.5f;

	[Range(1f, 100f)]
	[Tooltip("Smoothing of 1 will yield only the current predicted viseme, 100 will yield an extremely smooth viseme response.")]
	public int smoothAmount = 70;

	private OVRLipSyncContextBase lipsyncContext;

	private void Start()
	{
		if (skinnedMeshRenderer == null)
		{
			Debug.LogError("LipSyncContextMorphTarget.Start Error: Please set the target Skinned Mesh Renderer to be controlled!");
			return;
		}
		lipsyncContext = GetComponent<OVRLipSyncContextBase>();
		if (lipsyncContext == null)
		{
			Debug.LogError("LipSyncContextMorphTarget.Start Error: No OVRLipSyncContext component on this object!");
		}
		else
		{
			lipsyncContext.Smoothing = smoothAmount;
		}
	}

	private void Update()
	{
		if (lipsyncContext != null && skinnedMeshRenderer != null)
		{
			OVRLipSync.Frame currentPhonemeFrame = lipsyncContext.GetCurrentPhonemeFrame();
			if (currentPhonemeFrame != null)
			{
				SetVisemeToMorphTarget(currentPhonemeFrame);
				SetLaughterToMorphTarget(currentPhonemeFrame);
			}
			CheckForKeys();
			if (smoothAmount != lipsyncContext.Smoothing)
			{
				lipsyncContext.Smoothing = smoothAmount;
			}
		}
	}

	private void CheckForKeys()
	{
		if (enableVisemeTestKeys)
		{
			for (int i = 0; i < OVRLipSync.VisemeCount; i++)
			{
				CheckVisemeKey(visemeTestKeys[i], i, 100);
			}
		}
		CheckLaughterKey();
	}

	private void SetVisemeToMorphTarget(OVRLipSync.Frame frame)
	{
		for (int i = 0; i < visemeToBlendTargets.Length; i++)
		{
			if (visemeToBlendTargets[i] != -1)
			{
				skinnedMeshRenderer.SetBlendShapeWeight(visemeToBlendTargets[i], frame.Visemes[i] * 100f);
			}
		}
	}

	private void SetLaughterToMorphTarget(OVRLipSync.Frame frame)
	{
		if (laughterBlendTarget != -1)
		{
			float laughterScore = frame.laughterScore;
			laughterScore = ((laughterScore < laughterThreshold) ? 0f : (laughterScore - laughterThreshold));
			laughterScore = Mathf.Min(laughterScore * laughterMultiplier, 1f);
			laughterScore *= 1f / laughterThreshold;
			skinnedMeshRenderer.SetBlendShapeWeight(laughterBlendTarget, laughterScore * 100f);
		}
	}

	private void CheckVisemeKey(KeyCode key, int viseme, int amount)
	{
		if (Input.GetKeyDown(key))
		{
			lipsyncContext.SetVisemeBlend(visemeToBlendTargets[viseme], amount);
		}
		if (Input.GetKeyUp(key))
		{
			lipsyncContext.SetVisemeBlend(visemeToBlendTargets[viseme], 0);
		}
	}

	private void CheckLaughterKey()
	{
		if (Input.GetKeyDown(laughterKey))
		{
			lipsyncContext.SetLaughterBlend(100);
		}
		if (Input.GetKeyUp(laughterKey))
		{
			lipsyncContext.SetLaughterBlend(0);
		}
	}
}
