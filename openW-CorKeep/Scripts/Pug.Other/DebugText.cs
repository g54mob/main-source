using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pug.UnityExtensions;
using UnityEngine;

public class DebugText : MonoBehaviour
{
	private struct PoolSystemMeters
	{
		public PugTextDigits inUse;

		public PugTextDigits peak;
	}

	public PugFont font;

	public SpriteRenderer tvSafeAreaOverlay;

	private GameObject junkRoot;

	private DebugHUDFlags F;

	private int accu;

	private float last;

	private const float updateInterval = 0.05f;

	private PugTextDigits fpsMeter;

	private PugTextDigits heapMeter;

	private PugTextDigits yielderMeter;

	private readonly List<PoolSystemMeters> poolSystemMeters = new List<PoolSystemMeters>();

	[NonSerialized]
	public PugTextDigits xInput;

	[NonSerialized]
	public PugTextDigits yInput;

	[NonSerialized]
	public PugTextDigits inputMag;

	[NonSerialized]
	public PugTextDigits fxInput;

	[NonSerialized]
	public PugTextDigits fyInput;

	[NonSerialized]
	public PugTextDigits fInputMag;

	private PugTextDigits screenW;

	private PugTextDigits screenH;

	private readonly List<GameObject> tempMessages = new List<GameObject>();

	private static readonly PugTextStyle meterStyle1 = new PugTextStyle
	{
		horizontalAlignment = PugTextStyle.HorizontalAlignment.left,
		color = Color.white.ColorWithNewAlpha(0.5f)
	};

	private static readonly PugTextStyle rightMeterStyle = new PugTextStyle
	{
		horizontalAlignment = PugTextStyle.HorizontalAlignment.right,
		color = Color.white.ColorWithNewAlpha(0.5f)
	};

	private static readonly PugTextStyle staticLabelStyle = new PugTextStyle
	{
		horizontalAlignment = PugTextStyle.HorizontalAlignment.left,
		color = Color.white.ColorWithNewAlpha(0.2f)
	};

	private static readonly PugTextStyle tempMessageStyle = new PugTextStyle
	{
		horizontalAlignment = PugTextStyle.HorizontalAlignment.left,
		verticalAlignment = PugTextStyle.VerticalAlignment.top,
		color = Color.yellow
	};

	private Vector2 offset = new Vector2(0f, 0f);

	public void LayOut(DebugHUDFlags f)
	{
		F = f;
		if (junkRoot != null)
		{
			UnityEngine.Object.DestroyImmediate(junkRoot);
		}
		junkRoot = new GameObject("JRoot");
		junkRoot.transform.SetParent(base.transform, worldPositionStays: false);
		offset.Set(0f, 0f);
		if (tvSafeAreaOverlay != null)
		{
			tvSafeAreaOverlay.gameObject.SetActive(f.HasFlag(DebugHUDFlags.tvSafeAreaOverlay));
		}
		if (f.HasFlag(DebugHUDFlags.fps))
		{
			fpsMeter = NewField(4, rightMeterStyle);
			fpsMeter.transform.SetLocalPositionX(29.75f);
			NewLine();
		}
		else
		{
			fpsMeter = null;
		}
		if (f.HasFlag(DebugHUDFlags.heap))
		{
			heapMeter = NewField(9, rightMeterStyle, commas: true);
			heapMeter.transform.SetLocalPositionX(29.75f);
		}
		else
		{
			heapMeter = null;
		}
		offset.Set(0f, 0f);
		int integerDigits = 3;
		poolSystemMeters.Clear();
		if (f.HasFlag(DebugHUDFlags.pools))
		{
			NewLabel("--- POOLS ---");
			NewLine();
			foreach (IPoolSystem poolSystem in PoolSystemTracker.poolSystems)
			{
				PugTextDigits inUse = NewField(integerDigits, meterStyle1);
				NewLabel("/");
				PugTextDigits peak = NewField(integerDigits, meterStyle1);
				string text = poolSystem.Name;
				text = text.Substring(5, text.Length - 6);
				text = SquashString(text, 12);
				NewLabel(" " + text);
				NewLine();
				poolSystemMeters.Add(new PoolSystemMeters
				{
					inUse = inUse,
					peak = peak
				});
			}
			NewLabel("Yielders: ");
			yielderMeter = NewField(3, meterStyle1);
			NewLine();
			NewLine();
		}
		else
		{
			yielderMeter = null;
		}
		if (f.HasFlag(DebugHUDFlags.rawInput))
		{
			NewLabel("--- INPUT ---");
			NewLine();
			NewLabel("X: ");
			xInput = NewField(1, meterStyle1, commas: false, sign: true, 3);
			NewLabel(" ... ");
			fxInput = NewField(1, meterStyle1, commas: false, sign: true, 3);
			NewLine();
			NewLabel("Y: ");
			yInput = NewField(1, meterStyle1, commas: false, sign: true, 3);
			NewLabel(" ... ");
			fyInput = NewField(1, meterStyle1, commas: false, sign: true, 3);
			NewLine();
			NewLabel("Mag: ");
			inputMag = NewField(1, meterStyle1, commas: false, sign: false, 3);
			NewLabel(" ... ");
			fInputMag = NewField(1, meterStyle1, commas: false, sign: false, 3);
			NewLine();
			NewLine();
			NewLine();
		}
		else
		{
			xInput = null;
			yInput = null;
			inputMag = null;
			fxInput = null;
			fyInput = null;
			fInputMag = null;
		}
		if (f.HasFlag(DebugHUDFlags.screenSize))
		{
			NewLabel("--- Screen ---");
			NewLine();
			NewLabel("W: ");
			screenW = NewField(4, meterStyle1);
			NewLine();
			NewLabel("H: ");
			screenH = NewField(4, meterStyle1);
			NewLine();
			NewLine();
		}
		else
		{
			screenW = null;
			screenH = null;
		}
	}

	private void Awake()
	{
		if (!Manager.DEBUG_MODE)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			LayOut((DebugHUDFlags)0);
		}
	}

	private void Update()
	{
		accu++;
		float num = Time.unscaledTime - last;
		if (num >= 0.05f)
		{
			UpdateMeters(num);
			accu = 0;
			last = Time.unscaledTime;
		}
	}

	private void UpdateMeters(float dt)
	{
		if (F.HasFlag(DebugHUDFlags.fps))
		{
			fpsMeter.RenderInt(Mathf.RoundToInt((float)accu / dt));
		}
		if (F.HasFlag(DebugHUDFlags.rawInput))
		{
			Vector2 inputAxisValue = Manager.input.singleplayerInputModule.GetInputAxisValue(PlayerInput.InputAxisType.CHARACTER_MOVEMENT_HORIZONTAL, PlayerInput.InputAxisType.CHARACTER_MOVEMENT_VERTICAL);
			xInput.RenderFloat(inputAxisValue.x);
			yInput.RenderFloat(inputAxisValue.y);
			inputMag.RenderFloat(inputAxisValue.magnitude);
			Vector2 vector = PlayerController.ProcessMovementInput(inputAxisValue);
			fxInput.RenderFloat(vector.x);
			fyInput.RenderFloat(vector.y);
			fInputMag.RenderFloat(vector.magnitude);
		}
		if (F.HasFlag(DebugHUDFlags.heap))
		{
			long totalMemory = GC.GetTotalMemory(forceFullCollection: false);
			heapMeter.RenderInt((int)((totalMemory <= int.MaxValue) ? totalMemory : 0));
		}
		if (F.HasFlag(DebugHUDFlags.pools))
		{
			for (int i = 0; i < poolSystemMeters.Count; i++)
			{
				PoolSystemMeters obj = poolSystemMeters[i];
				IPoolSystem poolSystem = PoolSystemTracker.poolSystems[i];
				obj.inUse.RenderInt(poolSystem.AllocatedCount);
				obj.peak.RenderInt(poolSystem.PeakUse);
			}
			yielderMeter.RenderInt(Yielders.GetUsage());
		}
		if (F.HasFlag(DebugHUDFlags.screenSize))
		{
			screenW.RenderInt(Screen.width);
			screenH.RenderInt(Screen.height);
		}
	}

	public void Print(string message)
	{
		Debug.Log("[DebugText] " + message);
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		foreach (GameObject tempMessage in tempMessages)
		{
			tempMessage.transform.position = new Vector3(tempMessage.transform.position.x, tempMessage.transform.position.y + 0.5f, tempMessage.transform.position.z);
		}
		GameObject gameObject = new GameObject("TempMessage: " + message);
		gameObject.transform.parent = base.transform;
		gameObject.layer = base.gameObject.layer;
		gameObject.transform.localPosition = new Vector3(0f, -16.25f, base.transform.position.z);
		font.RenderNonPooled(message, tempMessageStyle, gameObject.transform, out var _, out var _);
		tempMessages.Add(gameObject);
		StartCoroutine(NukeOldestMessage());
	}

	private IEnumerator NukeOldestMessage()
	{
		yield return Yielders.PauseUnscaled(1f);
		GameObject obj = tempMessages[0];
		tempMessages.RemoveAt(0);
		UnityEngine.Object.DestroyImmediate(obj);
	}

	private void NewLine()
	{
		offset = new Vector2(0f, offset.y - 0.5f);
	}

	private void NewLabel(string s)
	{
		GameObject gameObject = new GameObject();
		gameObject.transform.parent = junkRoot.transform;
		gameObject.layer = base.gameObject.layer;
		gameObject.transform.localPosition = offset;
		font.RenderNonPooled(s, staticLabelStyle, gameObject.transform, out var _, out var _);
		SpriteRenderer spriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>().Last();
		offset = new Vector2(base.transform.InverseTransformPoint(spriteRenderer.transform.position).x + (float)font.charDims.x * 0.0625f * 0.5f, offset.y);
	}

	private PugTextDigits NewField(int integerDigits, PugTextStyle style, bool commas = false, bool sign = false, int decimalDigits = 0)
	{
		GameObject obj = new GameObject();
		obj.transform.parent = junkRoot.transform;
		obj.layer = base.gameObject.layer;
		obj.transform.localPosition = offset;
		obj.SetActive(value: false);
		PugTextDigits pugTextDigits = obj.AddComponent<PugTextDigits>();
		pugTextDigits.font = font;
		pugTextDigits.style = style;
		pugTextDigits.integerDigits = integerDigits;
		pugTextDigits.decimalDigits = decimalDigits;
		pugTextDigits.commaInterval = (commas ? 3 : 0);
		pugTextDigits.sign = sign;
		obj.SetActive(value: true);
		SpriteRenderer spriteRenderer = obj.GetComponentsInChildren<SpriteRenderer>().Last();
		offset = new Vector2(base.transform.InverseTransformPoint(spriteRenderer.transform.position).x + (float)font.charDims.x * 0.0625f * 0.5f, offset.y);
		return pugTextDigits;
	}

	public static string SquashString(string src, int targetLength, bool hardLimit = true, bool hardLimitEllipsis = true)
	{
		int num = targetLength;
		StringBuilder stringBuilder = new StringBuilder(targetLength);
		int num2 = src.Length - 1;
		while (num2 >= 0 && num2 >= num)
		{
			char value = src[num2];
			bool flag = num2 == 0 || !char.IsLetter(src[num2 - 1]);
			bool flag2 = "aeiouy".Contains(value);
			bool num3 = " _-".Contains(value);
			bool flag3 = true;
			if (num3)
			{
				flag3 = true;
			}
			else if (flag || !flag2)
			{
				flag3 = false;
			}
			if (!flag3)
			{
				num--;
				stringBuilder.Insert(0, value);
			}
			num2--;
		}
		if (num > 0)
		{
			stringBuilder.Insert(0, src.Substring(0, Math.Min(src.Length, num)));
		}
		if (hardLimit && stringBuilder.Length > targetLength)
		{
			string text = stringBuilder.ToString(0, targetLength);
			if (hardLimitEllipsis)
			{
				text += "...";
			}
			return text;
		}
		return stringBuilder.ToString();
	}
}
