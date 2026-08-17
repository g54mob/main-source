using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class BossLamp : MonoBehaviour
{
	private float chargeTime = 3f;

	private float chargeProgress;

	public Renderer zoneRenderer;

	public Renderer lampRenderer;

	private MaterialPropertyBlock zonePropertyBlock;

	public Color zoneColor;

	private Color startColor;

	public Material lampPostMaterial;

	public Material lampPostMaterialOff;

	private float zoneRadius;

	private static int numPlayers;

	private bool hasPlayer;

	public GameObject minimapIcon;

	public GameObject altarIcon;

	public Image circleProgress;

	public CanvasGroup circleParent;

	public AudioSource audioStart;

	public AudioSource audioLoop;

	public AudioSource audioComplete;

	public AudioSource audioAbort;

	public GameObject light;

	public GameObject lampExplosionPrefab;

	public EffectPlayer finishedFx;

	public EffectPlayer randomGoOutEffect;

	private bool charging;

	private float pitchStart = 0.5f;

	private float pitchEnd = 1.5f;

	private bool isTurnedOn;

	public static Action A_Activate;

	public static Action A_Deactivate;

	private bool wasLoopAudioPlayingWhenPaused;

	private int randomDeactivateTimeMin = 20;

	private int randomDeactivateTimeMax = 75;

	private float timeToDeactivate;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<bool> b = OnPause;
		Delegate obj = Delegate.Combine(MyTime.A_Pause, b);
		if ((object)obj == null)
		{
			MyTime.A_Pause = (Action<bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		if (action != null)
		{
			MyTime.A_Pause = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<bool> value = OnPause;
		Delegate obj = Delegate.Remove(MyTime.A_Pause, value);
		if ((object)obj == null)
		{
			MyTime.A_Pause = (Action<bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		if (action != null)
		{
			MyTime.A_Pause = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private unsafe void Start()
	{
		//IL_001d: Expected O, but got Ref
		//IL_0034: Expected O, but got Ref
		//IL_00bd: Expected O, but got Ref
		hasPlayer = false;
		Transform transform = minimapIcon.transform;
		float num = default(float);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num));
		transform.rotation = (Quaternion)(&num);
		circleParent.alpha = 0f;
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		zonePropertyBlock = materialPropertyBlock;
		zoneRenderer.Internal_GetPropertyBlock(zonePropertyBlock);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossLamp)+44]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossLamp)+48]");
		_ = 0;
		startColor = zoneColor;
		_ = 0;
		zonePropertyBlock.SetColor("_MainColor", (Color)(&num));
		zoneRenderer.Internal_SetPropertyBlock(zonePropertyBlock);
		zoneRenderer.enabled = false;
		GameObject gameObject = zoneRenderer.gameObject;
		SphereCollider component = gameObject.GetComponent<SphereCollider>();
		float num2 = (float)component.bounds.m_Extents + 0.25f;
		zoneRadius = num2;
	}

	public bool HasPlayer()
	{
		//IL_01f2: Expected I4, but got O
		//IL_01a5: Invalid comparison between F4 and I4
		//IL_01b6: Invalid comparison between F4 and I4
		if ((object)zoneRenderer != null)
		{
			Transform transform = zoneRenderer.transform;
			if ((object)transform != null)
			{
				Vector3 position = transform.position;
				if ((object)MyPlayer.Instance != null)
				{
					Transform transform2 = MyPlayer.Instance.transform;
					if ((object)transform2 != null)
					{
						Vector3 position2 = transform2.position;
						if (!isTurnedOn)
						{
							return false;
						}
						float num = position.y - position2.y;
						float num2 = position.x - position2.x;
						float num3 = position.z - position2.z;
						float num4 = num * num;
						float num5 = num2 * num2;
						float num6 = num3 * num3;
						float num7 = num4 + num5;
						float num8 = num7 + num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
						if ((isTurnedOn ? 1 : 0) <= (false ? 1 : 0))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
						}
						else
						{
							double num9 = Math.Sqrt(num8);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
						bool flag = zoneRadius < 0f;
						bool flag2 = zoneRadius == 0f;
						bool flag3 = !flag;
						bool flag4 = !flag2;
						return flag4 & flag3;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void Update()
	{
		//IL_0032: Invalid comparison between I4 and F4
		//IL_007e: Invalid comparison between I4 and F4
		//IL_011d: Invalid comparison between I4 and F4
		//IL_016c: Expected O, but got Ref
		//IL_018d: Invalid comparison between I4 and F4
		if (!(chargeProgress < 1f) || (!charging && !(0f < chargeProgress)))
		{
			return;
		}
		float num3;
		if (!charging)
		{
			float num = chargeTime * 0.25f;
			float num2 = MyTime.deltaTime / num;
			num3 = chargeProgress - num2;
		}
		else
		{
			float num4 = MyTime.deltaTime / chargeTime;
			float num5 = num4 + chargeProgress;
			num3 = num5;
		}
		chargeProgress = num3;
		if (num3 < 1f)
		{
			if (!(0f < num3))
			{
				chargeProgress = 0f;
			}
		}
		else
		{
			chargeProgress = 1f;
			Complete();
		}
		float num6 = pitchEnd - pitchStart;
		float num7 = num6 * chargeProgress;
		float pitch = num7 + pitchStart;
		audioLoop.pitch = pitch;
		circleProgress.fillAmount = chargeProgress;
		if (0f > chargeProgress || chargeProgress > 1f)
		{
		}
		object obj = default(object);
		zonePropertyBlock.SetColor("_MainColor", (Color)(&obj));
		zoneRenderer.Internal_SetPropertyBlock(zonePropertyBlock);
		if (!(0f < chargeProgress))
		{
			chargeProgress = 0f;
			zoneRenderer.enabled = false;
		}
	}

	private void OnPause(bool paused)
	{
		if (!paused)
		{
			if (wasLoopAudioPlayingWhenPaused != paused)
			{
				audioLoop.Play();
			}
		}
		else
		{
			bool isPlaying = audioLoop.isPlaying;
			wasLoopAudioPlayingWhenPaused = isPlaying;
			audioLoop.Pause();
		}
	}

	private unsafe void Complete()
	{
		//IL_00c3: Expected O, but got Ref
		//IL_00c3: Expected O, but got Ref
		light.SetActive(value: true);
		isTurnedOn = true;
		audioLoop.Stop();
		audioComplete.Play();
		circleParent.alpha = 0f;
		finishedFx.Play();
		minimapIcon.SetActive(value: false);
		altarIcon.SetActive(value: false);
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		object obj2 = default(object);
		GameObject gameObject = UnityEngine.Object.Instantiate(lampExplosionPrefab, (Vector3)(&obj), (Quaternion)(&obj2));
		ControllerShaker.Shake(0, 0.4f, 0.2f);
		ExtendRandomDeactivateTime();
		lampRenderer.SetMaterial(lampPostMaterial);
		Action a_Activate = A_Activate;
		if (A_Activate != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v297.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void Deactivate()
	{
		if (isTurnedOn)
		{
			isTurnedOn = false;
			charging = false;
			chargeProgress = 0f;
			light.SetActive(value: false);
			zoneRenderer.enabled = false;
			lampRenderer.SetMaterial(lampPostMaterialOff);
			randomGoOutEffect.Play();
			minimapIcon.SetActive(value: true);
			Action a_Deactivate = A_Deactivate;
			if (A_Deactivate != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v53.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private void OnTriggerEnter()
	{
		if (!isTurnedOn && !charging)
		{
			circleParent.alpha = 1f;
			zoneRenderer.enabled = true;
			charging = true;
			audioLoop.pitch = 1f;
			audioLoop.volume = 1f;
			audioStart.Play();
			audioLoop.Play();
		}
	}

	private void FixedUpdate()
	{
		//IL_009f: Invalid comparison between I4 and F4
		if (isTurnedOn && !HasPlayer() && !(0.85f > GraveyardBossRoom.darknessLightIntensityMultiplier) && !(0f < (timeToDeactivate -= MyTime.fixedDeltaTime)))
		{
			Deactivate();
		}
	}

	private void CheckRandomDeactivate()
	{
		//IL_009f: Invalid comparison between I4 and F4
		if (isTurnedOn && !HasPlayer() && !(0.85f > GraveyardBossRoom.darknessLightIntensityMultiplier) && !(0f < (timeToDeactivate -= MyTime.fixedDeltaTime)))
		{
			Deactivate();
		}
	}

	private void ExtendRandomDeactivateTime()
	{
		//IL_0029: Expected F4, but got I4
		int num = MyRandom.random.Next(randomDeactivateTimeMin, randomDeactivateTimeMax);
		timeToDeactivate = num;
	}

	private void OnTriggerExit()
	{
		if (!isTurnedOn)
		{
			circleParent.alpha = 0f;
			charging = false;
			audioAbort.Play();
			audioLoop.Stop();
		}
		else
		{
			ExtendRandomDeactivateTime();
		}
	}
}
