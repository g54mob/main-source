using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

[ExecuteInEditMode]
public class PugColorCyclingController : MonoBehaviour
{
	public enum ApplyTo
	{
		SpriteRendererInThisTransform = 0,
		AllChildSpriteRenderers = 1,
		SpecificSpriteRenderers = 2
	}

	private class MPBHandler
	{
		private readonly SpriteRenderer spriteRenderer;

		public readonly MaterialPropertyBlock mpb;

		public void GetMPB()
		{
			spriteRenderer.GetPropertyBlock(mpb);
		}

		public void SetMPB()
		{
			spriteRenderer.SetPropertyBlock(mpb);
		}

		public MPBHandler(SpriteRenderer sr)
		{
			if (sr == null)
			{
				Debug.LogWarning("No SR!");
				return;
			}
			spriteRenderer = sr;
			mpb = new MaterialPropertyBlock();
			spriteRenderer.GetPropertyBlock(mpb);
		}
	}

	private class GroupPlaybackInfo
	{
		public int groupID;

		public TimerSimple timer;

		public bool loop;

		public int frameCount;

		public int startOffset;

		public AnimationCurve curve;
	}

	[Tooltip("Color cycling data is now edited through a standalone tool. You'll find it in the Radical gdrive (under Software)")]
	public PugColorCyclingData cyclingData;

	private GroupPlaybackInfo[] groupPlayback;

	private Vector4 groupOffsets;

	private Vector4 defaultGroupOffsets;

	public ApplyTo applyTo;

	public List<SpriteRenderer> applyToSpecificSRs = new List<SpriteRenderer>();

	public bool unscaledTime;

	public Dictionary<string, int> patternNames = new Dictionary<string, int>();

	private static readonly int GroupOffsetsID = Shader.PropertyToID("groupOffsets");

	private static readonly int IndexedTextureID = Shader.PropertyToID("_IndexedTex");

	private static readonly int PatternTextureID = Shader.PropertyToID("_PatternTex");

	private List<MPBHandler> mpbs = new List<MPBHandler>();

	public void ResetMPBs()
	{
		mpbs.Clear();
		foreach (SpriteRenderer applyToSpecificSR in applyToSpecificSRs)
		{
			mpbs.Add(new MPBHandler(applyToSpecificSR));
		}
		switch (applyTo)
		{
		case ApplyTo.SpriteRendererInThisTransform:
			mpbs.Add(new MPBHandler(GetComponent<SpriteRenderer>()));
			break;
		case ApplyTo.AllChildSpriteRenderers:
		{
			SpriteRenderer[] componentsInChildren = GetComponentsInChildren<SpriteRenderer>(includeInactive: true);
			foreach (SpriteRenderer sr in componentsInChildren)
			{
				mpbs.Add(new MPBHandler(sr));
			}
			break;
		}
		default:
			Debug.LogWarning("Unknown applytype " + applyTo);
			goto case ApplyTo.SpriteRendererInThisTransform;
		case ApplyTo.SpecificSpriteRenderers:
			break;
		}
		foreach (MPBHandler mpb in mpbs)
		{
			mpb.GetMPB();
			mpb.mpb.SetVector(GroupOffsetsID, groupOffsets);
			mpb.mpb.SetTexture(IndexedTextureID, cyclingData.indexedTexture);
			mpb.mpb.SetTexture(PatternTextureID, cyclingData.patternTexture);
			mpb.SetMPB();
		}
	}

	private void Awake()
	{
		groupPlayback = new GroupPlaybackInfo[4];
		groupOffsets = default(Vector4);
		defaultGroupOffsets = default(Vector4);
		ResetMPBs();
		for (int i = 0; i < 4; i++)
		{
			groupPlayback[i] = new GroupPlaybackInfo
			{
				groupID = i,
				timer = new TimerSimple(1f, unscaledTime)
			};
		}
		for (int j = 0; j < cyclingData.patterns.Count; j++)
		{
			patternNames[cyclingData.patterns[j].name] = j;
		}
	}

	private void OnDisable()
	{
	}

	public void SetColorCyclingData(PugColorCyclingData newColorCyclingData)
	{
		cyclingData = newColorCyclingData;
		ResetMPBs();
	}

	private void SendGroupOffsetsToShader()
	{
		foreach (MPBHandler mpb in mpbs)
		{
			mpb.GetMPB();
			mpb.mpb.SetVector(GroupOffsetsID, groupOffsets);
			mpb.SetMPB();
		}
	}

	public void Play(int patternID, bool loop = false, float speed = 1f)
	{
		PugColorCyclingData.Pattern pattern = cyclingData.patterns[patternID];
		GroupPlaybackInfo[] array = groupPlayback;
		foreach (GroupPlaybackInfo groupPlaybackInfo in array)
		{
			if (IsNthBitHigh(pattern.groupMask, groupPlaybackInfo.groupID))
			{
				groupOffsets[groupPlaybackInfo.groupID] = pattern.groupOffsets[groupPlaybackInfo.groupID];
				groupPlaybackInfo.loop = loop;
				groupPlaybackInfo.timer.Start((float)pattern.frameCount / ((float)pattern.fps * speed));
				groupPlaybackInfo.frameCount = pattern.frameCount;
				groupPlaybackInfo.startOffset = pattern.groupOffsets[groupPlaybackInfo.groupID];
				groupPlaybackInfo.curve = pattern.curve;
			}
		}
		SendGroupOffsetsToShader();
	}

	public void Play(string patternName, bool loop = false, float speed = 1f)
	{
		Play(patternNames[patternName], loop, speed);
	}

	public void StopAllPlayback()
	{
		for (int i = 0; i < cyclingData.patterns.Count; i++)
		{
			Stop(i);
		}
	}

	public void Stop(int i)
	{
		PugColorCyclingData.Pattern pattern = cyclingData.patterns[i];
		for (int j = 0; j < 4; j++)
		{
			if (IsNthBitHigh(pattern.groupMask, j))
			{
				groupOffsets[j] = defaultGroupOffsets[j];
				groupPlayback[j].timer.Stop();
			}
		}
		SendGroupOffsetsToShader();
	}

	public void Stop(string patternName)
	{
		Stop(patternNames[patternName]);
	}

	public void SetPaletteFromPatternFrame(int patternID, int frame = 0, bool setAsDefaultPalette = true)
	{
		if (!cyclingData.patterns.IsValidIndex(patternID))
		{
			Debug.LogWarning($"missing pattern #{patternID} in {cyclingData.name}", this);
			return;
		}
		PugColorCyclingData.Pattern pattern = cyclingData.patterns[patternID];
		if (pattern == null)
		{
			Debug.LogWarning($"null pattern #{patternID} in {cyclingData.name}", this);
			return;
		}
		if (frame < 0 || frame >= pattern.frameCount)
		{
			Debug.LogWarning($"missing frame #{frame} in pattern #{patternID} in {cyclingData.name}", this);
			return;
		}
		GroupPlaybackInfo[] array = groupPlayback;
		foreach (GroupPlaybackInfo groupPlaybackInfo in array)
		{
			if (IsNthBitHigh(pattern.groupMask, groupPlaybackInfo.groupID))
			{
				groupOffsets[groupPlaybackInfo.groupID] = pattern.groupOffsets[groupPlaybackInfo.groupID] + frame;
				if (setAsDefaultPalette)
				{
					defaultGroupOffsets[groupPlaybackInfo.groupID] = groupOffsets[groupPlaybackInfo.groupID];
				}
			}
		}
		SendGroupOffsetsToShader();
	}

	public void SetPaletteFromPatternFrame(string patternName, int frame = 0, bool setAsDefaultPalette = true)
	{
		SetPaletteFromPatternFrame(patternNames[patternName], frame, setAsDefaultPalette);
	}

	private void LateUpdate()
	{
		GroupPlaybackInfo[] array = groupPlayback;
		foreach (GroupPlaybackInfo groupPlaybackInfo in array)
		{
			if (!groupPlaybackInfo.timer.isRunning)
			{
				continue;
			}
			if (groupPlaybackInfo.timer.isTimerElapsed)
			{
				if (!groupPlaybackInfo.loop)
				{
					groupPlaybackInfo.timer.Stop();
					groupPlaybackInfo.startOffset = (int)defaultGroupOffsets[groupPlaybackInfo.groupID];
					groupOffsets[groupPlaybackInfo.groupID] = defaultGroupOffsets[groupPlaybackInfo.groupID];
					continue;
				}
				groupPlaybackInfo.timer.Start();
			}
			float num = groupPlaybackInfo.curve.Evaluate(groupPlaybackInfo.timer.elapsedRatio) * (float)groupPlaybackInfo.frameCount;
			if (!cyclingData.smooth)
			{
				num = Mathf.Floor(num);
			}
			groupOffsets[groupPlaybackInfo.groupID] = (float)groupPlaybackInfo.startOffset + num;
		}
		SendGroupOffsetsToShader();
	}

	private static bool IsNthBitHigh(uint v, int idx)
	{
		return (v & (1 << idx)) != 0;
	}
}
