using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MilkShake;

[Serializable]
public class ShakeInstance
{
	public ShakeParameters ShakeParameters;

	public float StrengthScale;

	public float RoughnessScale;

	public bool RemoveWhenStopped;

	private ShakeState _003CState_003Ek__BackingField;

	private bool _003CIsPaused_003Ek__BackingField;

	private int baseSeed;

	private float seed1;

	private float seed2;

	private float seed3;

	private float noiseTimer;

	private float fadeTimer;

	private float fadeInTime;

	private float fadeOutTime;

	private float pauseTimer;

	private float pauseFadeTime;

	private int lastUpdatedFrame;

	public ShakeState State
	{
		get
		{
			return _003CState_003Ek__BackingField;
		}
		private set
		{
			_003CState_003Ek__BackingField = value;
		}
	}

	public bool IsPaused
	{
		get
		{
			return _003CIsPaused_003Ek__BackingField;
		}
		private set
		{
			_003CIsPaused_003Ek__BackingField = value;
		}
	}

	public bool IsFinished
	{
		get
		{
			if (_003CState_003Ek__BackingField != ShakeState.Stopped)
			{
				return false;
			}
			return RemoveWhenStopped;
		}
	}

	public float CurrentStrength
	{
		get
		{
			ShakeParameters shakeParameters = ShakeParameters;
			float num = shakeParameters.strength * fadeTimer;
			return num * StrengthScale;
		}
	}

	public float CurrentRoughness
	{
		get
		{
			ShakeParameters shakeParameters = ShakeParameters;
			float num = shakeParameters.roughness * fadeTimer;
			return num * RoughnessScale;
		}
	}

	public ShakeInstance(int? seed = null)
	{
		//IL_00c9: Expected F4, but got I4
		//IL_0018: Expected I4, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		int? num = default(int?);
		if ((object)seed == null)
		{
			int value = UnityEngine.Random.Range(-10000, 10000);
			num = value;
		}
		int num2 = (baseSeed = num.Value);
		StrengthScale = 1f;
		RoughnessScale = 1f;
		float num3 = (float)num2 * 0.5f;
		float num4 = (float)num2 / 3f;
		seed1 = num3;
		seed2 = num4;
		float num5 = (float)num2 * 0.25f;
		seed3 = num5;
		fadeTimer = 0f;
		pauseTimer = 0f;
		noiseTimer = num2;
	}

	public ShakeInstance(IShakeParameters shakeData, int? seed = null)
	{
		//IL_00c9: Expected F4, but got I4
		//IL_0018: Expected I4, but got I8
		//IL_00ff: Expected F4, but got I4
		//IL_0118: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		int? num = default(int?);
		if ((object)seed == null)
		{
			int value = UnityEngine.Random.Range(-10000, 10000);
			num = value;
		}
		int num2 = (baseSeed = num.Value);
		fadeTimer = 0f;
		pauseTimer = 0f;
		StrengthScale = 1f;
		RoughnessScale = 1f;
		float num3 = (float)num2 / 3f;
		seed2 = num3;
		float num4 = (float)num2 * 0.5f;
		seed1 = num4;
		float num5 = (float)num2 * 0.25f;
		seed3 = num5;
		noiseTimer = num2;
		ShakeParameters shakeParameters = new ShakeParameters(shakeData);
		ShakeParameters = shakeParameters;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		fadeInTime = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		fadeOutTime = num2;
		_003CState_003Ek__BackingField = ShakeState.FadingIn;
	}

	public unsafe ShakeResult UpdateShake(float deltaTime)
	{
		//IL_000e: Expected O, but got I4
		//IL_0009: Expected native int or pointer, but got O
		//IL_00ed: Expected O, but got F4
		//IL_00e8: Expected native int or pointer, but got O
		//IL_0199: Expected native int or pointer, but got O
		//IL_01ec: Invalid comparison between F4 and I4
		//IL_06a4: Invalid comparison between I4 and F4
		//IL_02ad: Expected F4, but got I4
		//IL_03ce: Invalid comparison between F4 and I4
		//IL_0700: Invalid comparison between I4 and F4
		//IL_045a: Expected F4, but got I4
		//IL_036e: Invalid comparison between F4 and I4
		//IL_0512: Invalid comparison between F4 and I4
		ShakeResult shakeResult = default(ShakeResult);
		((ShakeResult*)(nint)shakeResult)->PositionShake = (Vector3)0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,dword ptr [rbx+2Ch]\"");
		float x = noiseTimer + seed1;
		float num = Mathf.PerlinNoise(x, 0f);
		float num2 = num - 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+2Ch]\"");
		float num3 = num2 + num2;
		float num4 = Mathf.PerlinNoise(0f, noiseTimer);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,dword ptr [rbx+2Ch]\"");
		float num5 = num4 - 0.5f;
		float x2 = noiseTimer + seed3;
		float num6 = num5 + num5;
		float num7 = Mathf.PerlinNoise(x2, noiseTimer);
		ShakeParameters shakeParameters = ShakeParameters;
		float num8 = num7 - 0.5f;
		float num9 = num8 + num8;
		if (ShakeParameters != null)
		{
			float num10 = shakeParameters.strength * fadeTimer;
			float num11 = num10 * StrengthScale;
			float num12 = num3 * num11;
			float num13 = num6 * num11;
			float num14 = num12 * (float)shakeParameters.positionInfluence;
			float num15 = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v3 (MilkShake.ShakeParameters)+28]");
			float num16 = num15 * 0f;
			float num17 = num9 * num11;
			((ShakeResult*)(nint)shakeResult)->PositionShake = (Vector3)num14;
			float num18 = num17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v3 (MilkShake.ShakeParameters)+2C]");
			float num19 = num18 * 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,dword ptr [rbx+2Ch]\"");
			float num20 = Mathf.PerlinNoise(noiseTimer, seed3);
			float y = noiseTimer + seed2;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+2Ch]\"");
			float num21 = Mathf.PerlinNoise(0f, y);
			float y2 = noiseTimer + seed1;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+2Ch]\"");
			float num22 = Mathf.PerlinNoise(noiseTimer, y2);
			ShakeParameters shakeParameters2 = ShakeParameters;
			float num23 = num22 - 0.5f;
			float num24 = num23 + num23;
			if (ShakeParameters != null)
			{
				float num25 = shakeParameters2.strength * fadeTimer;
				float num26 = num25 * StrengthScale;
				float num27 = num24 * num26;
				Vector3 rotationShake = default(Vector3);
				((ShakeResult*)(nint)shakeResult)->RotationShake = rotationShake;
				float num28 = num27;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v7 (MilkShake.ShakeParameters)+38]");
				float num29 = num28 * 0f;
				int frameCount = Time.frameCount;
				if (frameCount != lastUpdatedFrame)
				{
					if (pauseFadeTime > 0f)
					{
						float num30 = deltaTime / pauseFadeTime;
						if (!_003CIsPaused_003Ek__BackingField)
						{
							float num31 = pauseTimer - num30;
							pauseTimer = num31;
						}
						else
						{
							float num32 = num30 + pauseTimer;
							pauseTimer = num32;
						}
					}
					float num33 = pauseTimer;
					if (!(0f > pauseTimer))
					{
						if (num33 > 1f)
						{
							num33 = 1f;
						}
					}
					else
					{
						num33 = 0f;
					}
					ShakeParameters shakeParameters3 = ShakeParameters;
					pauseTimer = num33;
					if (ShakeParameters == null)
					{
						goto IL_0539;
					}
					bool flag = _003CState_003Ek__BackingField == ShakeState.FadingIn;
					float num34 = 1f - num33;
					float num35 = shakeParameters3.roughness * fadeTimer;
					float num36 = num35 * RoughnessScale;
					float num37 = num34 * deltaTime;
					float num38 = num36 * num37;
					float num39 = num38 + noiseTimer;
					noiseTimer = num39;
					if (!flag)
					{
						if (_003CState_003Ek__BackingField == ShakeState.FadingOut)
						{
							if (!(fadeOutTime > 0f))
							{
								fadeTimer = 0f;
							}
							else
							{
								float num40 = deltaTime / fadeOutTime;
								float num41 = fadeTimer - num40;
								fadeTimer = num41;
							}
						}
					}
					else if (!(fadeInTime > 0f))
					{
						fadeTimer = 1f;
					}
					else
					{
						float num42 = deltaTime / fadeInTime;
						float num43 = num42 + fadeTimer;
						fadeTimer = num43;
					}
					float num44 = fadeTimer;
					if (!(0f > fadeTimer))
					{
						if (num44 > 1f)
						{
							num44 = 1f;
						}
					}
					else
					{
						num44 = 0f;
					}
					fadeTimer = num44;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C6C10h\"");
					if (num44 == 1f)
					{
						if (ShakeParameters == null)
						{
							goto IL_0539;
						}
						if (shakeParameters3.shakeType != ShakeType.Sustained)
						{
							if (shakeParameters3.shakeType == ShakeType.OneShot)
							{
								fadeOutTime = shakeParameters3.fadeOut;
								RemoveWhenStopped = true;
								_003CState_003Ek__BackingField = ShakeState.FadingOut;
							}
						}
						else
						{
							_003CState_003Ek__BackingField = ShakeState.Sustained;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803C6C1Eh\"");
						if (num44 == 0f)
						{
							_003CState_003Ek__BackingField = ShakeState.Stopped;
						}
					}
					int frameCount2 = Time.frameCount;
					lastUpdatedFrame = frameCount2;
				}
				return shakeResult;
			}
		}
		goto IL_0539;
		IL_0539:
		return (ShakeResult)new NullReferenceException();
	}

	public void Start(float fadeTime)
	{
		fadeInTime = fadeTime;
		_003CState_003Ek__BackingField = ShakeState.FadingIn;
	}

	public void Stop(float fadeTime, bool removeWhenStopped)
	{
		fadeOutTime = fadeTime;
		RemoveWhenStopped = removeWhenStopped;
		_003CState_003Ek__BackingField = ShakeState.FadingOut;
	}

	public void Pause(float fadeTime)
	{
		//IL_001e: Invalid comparison between I4 and F4
		pauseFadeTime = fadeTime;
		_003CIsPaused_003Ek__BackingField = true;
		if (!(0f < fadeTime))
		{
			pauseTimer = 1f;
		}
	}

	public void Resume(float fadeTime)
	{
		//IL_001e: Invalid comparison between I4 and F4
		pauseFadeTime = fadeTime;
		_003CIsPaused_003Ek__BackingField = false;
		if (!(0f < fadeTime))
		{
			pauseTimer = 0f;
		}
	}

	public void TogglePaused(float fadeTime)
	{
		//IL_0074: Invalid comparison between I4 and F4
		//IL_0040: Invalid comparison between I4 and F4
		pauseFadeTime = fadeTime;
		if (!_003CIsPaused_003Ek__BackingField)
		{
			_003CIsPaused_003Ek__BackingField = true;
			if (!(0f < fadeTime))
			{
				pauseTimer = 1f;
			}
		}
		else
		{
			_003CIsPaused_003Ek__BackingField = false;
			if (!(0f < fadeTime))
			{
				pauseTimer = 0f;
			}
		}
	}

	private unsafe Vector3 getPositionShake()
	{
		//IL_00d4: Expected native int or pointer, but got O
		//IL_00f8: Expected native int or pointer, but got O
		//IL_0105: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,dword ptr [rbx+2Ch]\"");
		float x = noiseTimer + seed1;
		float num = Mathf.PerlinNoise(x, 0f);
		float num2 = num - 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+2Ch]\"");
		float num3 = num2 + num2;
		float num4 = Mathf.PerlinNoise(0f, noiseTimer);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,dword ptr [rbx+2Ch]\"");
		float num5 = num4 - 0.5f;
		float x2 = noiseTimer + seed3;
		float num6 = num5 + num5;
		float num7 = Mathf.PerlinNoise(x2, noiseTimer);
		float num8 = num7 - 0.5f;
		ShakeParameters shakeParameters = ShakeParameters;
		float num9 = num8 + num8;
		if (ShakeParameters != null)
		{
			float num10 = shakeParameters.strength * fadeTimer;
			float num11 = num10 * StrengthScale;
			float num12 = num3 * num11;
			float num13 = num6 * num11;
			float x3 = num12 * (float)shakeParameters.positionInfluence;
			float num14 = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (MilkShake.ShakeParameters)+28]");
			float y = num14 * 0f;
			float num15 = num9 * num11;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = x3;
			float num16 = num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (MilkShake.ShakeParameters)+2C]");
			float z = num16 * 0f;
			((Vector3*)(nint)vector)->y = y;
			((Vector3*)(nint)vector)->z = z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	private unsafe Vector3 getRotationShake()
	{
		//IL_00d4: Expected native int or pointer, but got O
		//IL_00f8: Expected native int or pointer, but got O
		//IL_0105: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,dword ptr [rbx+2Ch]\"");
		float num = Mathf.PerlinNoise(noiseTimer, seed3);
		float num2 = num - 0.5f;
		float y = noiseTimer + seed2;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+2Ch]\"");
		float num3 = num2 + num2;
		float num4 = Mathf.PerlinNoise(0f, y);
		float num5 = num4 - 0.5f;
		float y2 = noiseTimer + seed1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+2Ch]\"");
		float num6 = num5 + num5;
		float num7 = Mathf.PerlinNoise(noiseTimer, y2);
		float num8 = num7 - 0.5f;
		ShakeParameters shakeParameters = ShakeParameters;
		float num9 = num8 + num8;
		if (ShakeParameters != null)
		{
			float num10 = shakeParameters.strength * fadeTimer;
			float num11 = num10 * StrengthScale;
			float num12 = num3 * num11;
			float num13 = num6 * num11;
			float x = num12 * (float)shakeParameters.rotationInfluence;
			float num14 = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v2 (MilkShake.ShakeParameters)+34]");
			float y3 = num14 * 0f;
			float num15 = num9 * num11;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = x;
			float num16 = num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v2 (MilkShake.ShakeParameters)+38]");
			float z = num16 * 0f;
			((Vector3*)(nint)vector)->y = y3;
			((Vector3*)(nint)vector)->z = z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	private float getNoise(float x, float y)
	{
		float num = Mathf.PerlinNoise(x, y);
		float num2 = num - 0.5f;
		return num2 + num2;
	}
}
