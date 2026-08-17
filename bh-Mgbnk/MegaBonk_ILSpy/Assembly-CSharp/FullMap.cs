using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.MapGeneration;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.UI.InGame.FullMap;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class FullMap : MonoBehaviour
{
	public Camera mapCamera;

	private float worldSize;

	private int textureSize = 64;

	private float revealRadius = 110f;

	private Texture2D fogTexture;

	private Color32[] pixels;

	public Material mapMaterial;

	public Transform mapDisplayTransform;

	public GameObject statsWindow;

	private int mapsOpen;

	private bool[] fullyRevealed;

	private bool[] visitedCords;

	private HashSet<int> revealedIndices;

	private Vector3 lastPos;

	private void Awake()
	{
		//IL_01c5: Expected O, but got I4
		//IL_0238: Expected O, but got I4
		//IL_024e: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0195: Expected O, but got I4
		Delegate a_GenerationComplete = MapGenerationController.A_GenerationComplete;
		Action action = OnGenerationComplete;
		Delegate obj = Delegate.Combine(MapGenerationController.A_GenerationComplete, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			MapGenerationController.A_GenerationComplete = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj3 = 0;
				obj4 = obj;
				goto IL_026c;
			}
			MapGenerationController.A_GenerationComplete = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_027c;
			}
		}
		Action<bool> b = OnMapToggle;
		Delegate obj6 = Delegate.Combine(FullMapUi.A_Toggle, b);
		if ((object)obj6 == null)
		{
			FullMapUi.A_Toggle = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action3 = default(Action<bool>);
		bool flag4 = action3 == null;
		a_GenerationComplete = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (flag4)
		{
			goto IL_025c;
		}
		FullMapUi.A_Toggle = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag5 = obj7 == null;
		a_GenerationComplete = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (!flag5)
		{
			return;
		}
		goto IL_026c;
		IL_026c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_025c;
		IL_027c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_025c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_027c;
	}

	private void OnDestroy()
	{
		//IL_01c5: Expected O, but got I4
		//IL_0238: Expected O, but got I4
		//IL_024e: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0195: Expected O, but got I4
		Delegate a_GenerationComplete = MapGenerationController.A_GenerationComplete;
		Action action = OnGenerationComplete;
		Delegate obj = Delegate.Remove(MapGenerationController.A_GenerationComplete, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			MapGenerationController.A_GenerationComplete = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj3 = 0;
				obj4 = obj;
				goto IL_026c;
			}
			MapGenerationController.A_GenerationComplete = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_027c;
			}
		}
		Action<bool> b = OnMapToggle;
		Delegate obj6 = Delegate.Combine(FullMapUi.A_Toggle, b);
		if ((object)obj6 == null)
		{
			FullMapUi.A_Toggle = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action3 = default(Action<bool>);
		bool flag4 = action3 == null;
		a_GenerationComplete = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (flag4)
		{
			goto IL_025c;
		}
		FullMapUi.A_Toggle = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag5 = obj7 == null;
		a_GenerationComplete = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (!flag5)
		{
			return;
		}
		goto IL_026c;
		IL_026c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_025c;
		IL_027c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_025c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_027c;
	}

	private void OnMapToggle(bool on)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected I4, but got Unknown
		object obj = (on ? 1 : 0) * 2;
		object obj2 = obj - 1;
		int num = mapsOpen + obj2;
		mapsOpen = num;
	}

	private unsafe void OnGenerationComplete()
	{
		//IL_0086: Expected F4, but got O
		//IL_0049: Expected O, but got Ref
		Transform transform = mapCamera.transform;
		transform.parentInternal = null;
		worldSize = (float)MapInfo.mapSize;
		Transform transform2 = mapCamera.transform;
		float num = default(float);
		transform2.position = (Vector3)(&num);
		float orthographicSize = worldSize * 0.5f;
		mapCamera.orthographicSize = orthographicSize;
		InitFogTexture();
	}

	private void InitFogTexture()
	{
		//IL_015a: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_0063: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		object obj = textureSize * textureSize;
		bool[] array = new bool[obj];
		fullyRevealed = array;
		object obj2 = textureSize * textureSize;
		bool[] array2 = new bool[obj2];
		visitedCords = array2;
		bool mipChain = default(bool);
		Texture2D texture2D = new Texture2D(textureSize, textureSize, TextureFormat.R8, mipChain);
		fogTexture = texture2D;
		fogTexture.filterMode = FilterMode.Bilinear;
		object obj3 = textureSize * textureSize;
		Color32[] array3 = new Color32[obj3];
		pixels = array3;
		Color32[] array4 = pixels;
		object obj4 = 0;
		object obj5 = 0;
		while ((nint)obj4 < array4.Length)
		{
			Color32[] array5 = pixels;
			object obj6 = obj5 + 1;
			_ = 4278190080L;
			array4 = pixels;
			obj4 = obj6;
			obj5 = obj6;
		}
		fogTexture.SetPixels32(pixels);
		fogTexture.Apply();
		mapMaterial.SetTexture("_FogTex", fogTexture);
	}

	private void Update()
	{
		if (!PlayerStats.HasStats())
		{
			return;
		}
		Component component;
		if (!MyInputManager.GetButton(MyInputManager.MapOverlay))
		{
			component = mapDisplayTransform;
		}
		else
		{
			component = mapDisplayTransform;
			if (!MyTime.paused)
			{
				GameObject gameObject = mapDisplayTransform.gameObject;
				if (!gameObject.activeInHierarchy)
				{
					GameObject gameObject2 = mapDisplayTransform.gameObject;
					gameObject2.SetActive(value: true);
					statsWindow.SetActive(value: true);
				}
				return;
			}
		}
		GameObject gameObject3 = component.gameObject;
		if (gameObject3.activeInHierarchy)
		{
			GameObject gameObject4 = mapDisplayTransform.gameObject;
			gameObject4.SetActive(value: false);
			statsWindow.SetActive(value: false);
		}
	}

	private unsafe void FixedUpdate()
	{
		//IL_0073: Expected O, but got Ref
		if (fogTexture != null && !ChallengesTracker.HasChallengeModifier("blind"))
		{
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			object obj = default(object);
			QueueRevealFog((Vector3)(&obj));
			if (mapsOpen > 0)
			{
				RevealFog();
			}
		}
	}

	private void QueueRevealFog(Vector3 worldPos)
	{
		//IL_0316: Expected I, but got O
		//IL_00d9: Invalid comparison between F4 and I4
		//IL_0121: Expected O, but got F4
		//IL_0131: Expected O, but got F4
		//IL_01af: Expected O, but got F4
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_026a: Expected I4, but got O
		//IL_0289: Expected O, but got I4
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		nint num = (nint)typeof(Math);
		float num2 = position.x - (float)lastPos;
		float num3 = position.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FullMap)+84]");
		float num4 = num3 - 0f;
		float num5 = position.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FullMap)+88]");
		float num6 = num5 - 0f;
		float num7 = num4 * num4;
		float num8 = num2 * num2;
		float num9 = num6 * num6;
		float num10 = num7 + num8;
		float num11 = num10 + num9;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rcx_v8 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
		}
		else
		{
			double num12 = Math.Sqrt(num11);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
		if (1f > 0f)
		{
			return;
		}
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position2 = transform2.position;
		lastPos = (Vector3)position2.x;
		object obj = worldSize ^ -0f;
		_ = position2.z;
		float num13 = (float)obj * 0.5f;
		if (num13 > worldPos.x)
		{
			return;
		}
		float num14 = worldSize * 0.5f;
		if (worldPos.x > num14)
		{
			return;
		}
		object obj2 = worldSize ^ -0f;
		float num15 = (float)obj2 * 0.5f;
		if (num15 > worldPos.z)
		{
			return;
		}
		float num16 = worldSize * 0.5f;
		bool flag = worldPos.z < num16;
		if (worldPos.z > num16)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+2Ch]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+2Ch]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm1\"");
		object obj3 = transform2 * textureSize;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm2\"");
		int num17 = (int)(obj3 + (object)position2);
		if (flag)
		{
			return;
		}
		object obj4 = textureSize * textureSize;
		if (num17 < (nint)obj4)
		{
			bool[] array = visitedCords;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v9 (System.Int32)+20+v123 @ rcx_v14 (System.Boolean[])]");
			if ((nint)0 == 0)
			{
				_ = 1;
				bool flag2 = revealedIndices.Add(num17);
			}
		}
	}

	private bool IsMapOpen()
	{
		int num = mapsOpen ^ mapsOpen;
		int num2 = mapsOpen & num;
		bool flag = num2 < 0;
		bool flag2 = mapsOpen < 0;
		bool flag3 = mapsOpen == 0;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		return flag5 & flag4;
	}

	private void RevealFog()
	{
		//IL_0063: Expected O, but got I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected I4, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected I4, but got Unknown
		//IL_00d4: Expected O, but got F8
		//IL_00fa: Expected I, but got O
		//IL_06bd: Invalid comparison between O and F8
		//IL_0114: Expected I, but got O
		//IL_011d: Expected O, but got F8
		//IL_0702: Invalid comparison between O and F8
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected I4, but got Unknown
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected I4, but got Unknown
		//IL_01e9: Expected O, but got I4
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected I, but got Unknown
		//IL_0241: Expected I, but got O
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected I, but got Unknown
		//IL_0279: Invalid comparison between I and F8
		//IL_0610: Invalid comparison between I4 and F8
		//IL_0317: Expected F8, but got I4
		//IL_036d: Expected I, but got O
		//IL_03dd: Expected O, but got I4
		HashSet<int> hashSet = revealedIndices;
		bool flag = revealedIndices == null;
		Texture2D texture2D = (Texture2D)(object)this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3 (System.Collections.Generic.HashSet`1<System.Int32>)+20]");
			if ((nint)0 <= (nint)0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18106E6B0");
			nint num = 0;
			object obj = 0;
			HashSet<int>.Enumerator enumerator = default(HashSet<int>.Enumerator);
			float num4 = default(float);
			while (enumerator.MoveNext())
			{
				float num2 = revealRadius / worldSize;
				int num3 = (int)(num4 / textureSize);
				int num5 = (int)(num4 % textureSize);
				double a = (double)textureSize * (double)num2;
				double num6 = Math.Ceiling(a);
				double num7 = num6 * num6;
				object obj2 = 0.0 - num6;
				double num8 = num7;
				int num9 = num5;
				int num10 = num5;
				nint num11 = (nint)typeof(Math);
				int num12 = num3;
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
				{
					nint num13 = obj2 * obj2;
					object obj3 = 0.0 - num6;
					num = num13;
					while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
					{
						num10 = obj2 + num9;
						bool flag2 = num10 < 0;
						if (!flag2)
						{
							num12 = num3 + obj3;
							if (!flag2 && num10 < textureSize && num12 < textureSize)
							{
								texture2D = (Texture2D)(object)fullyRevealed;
								if (fullyRevealed == null)
								{
									throw new NullReferenceException();
								}
								object obj4 = num12 * textureSize;
								nint num14 = (nint)(obj4 + num10);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v4 (UnityEngine.Texture2D)+18]");
								if (num14 >= 0)
								{
									throw new IndexOutOfRangeException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rdi_v18 (Il2CppClass<System.Math>)+20+v448 @ rcx_v4 (UnityEngine.Texture2D)]");
								bool flag3 = (nint)0 != 0;
								num11 = (nint)fullyRevealed;
								num12 = (int)num14;
								if (!flag3)
								{
									object obj5 = obj3 * obj3;
									num11 = (nint)(obj5 + num);
									bool flag4 = (double)num11 > num8;
									num12 = (int)num14;
									if (!flag4)
									{
										IntPtr intPtr;
										if (0 <= num11)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm1,xmm1\"");
											intPtr = num11;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180300EA0");
											intPtr = num11;
										}
										double num15 = (double)(nint)intPtr / num6;
										if (!(0.0 > num15))
										{
											if (num15 > 1.0)
											{
												num15 = 1.0;
											}
										}
										else
										{
											num15 = 0.0;
										}
										float num16 = Easing.InPower((float)num15, 5);
										if (0.01f > num16)
										{
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
										texture2D = (Texture2D)(object)pixels;
										if (pixels == null)
										{
											throw new NullReferenceException();
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v4 (UnityEngine.Texture2D)+18]");
										if (num14 >= 0)
										{
											throw new IndexOutOfRangeException();
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v4 (UnityEngine.Texture2D)+20+v326 @ rdi_v18 (Il2CppClass<System.Math>)*4]");
										bool flag5 = (nint)5 <= (nint)0;
										num11 = (nint)pixels;
										num12 = (int)num14;
										if (!flag5)
										{
											if (pixels == null)
											{
												throw new NullReferenceException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v4 (UnityEngine.Texture2D)+18]");
											if (num14 >= 0)
											{
												throw new IndexOutOfRangeException();
											}
											_ = 5;
											obj = 1;
											num11 = num14;
											num12 = 5;
										}
										num8 = num7;
										num10 = 5;
										num = num13;
									}
								}
								num9 = num5;
							}
						}
						obj3++;
					}
					obj2++;
				}
			}
			enumerator.Dispose();
			bool flag6 = revealedIndices == null;
			texture2D = (Texture2D)(object)revealedIndices;
			if (!flag6)
			{
				revealedIndices.Clear();
				if (obj == null)
				{
					return;
				}
				texture2D = fogTexture;
				if ((object)fogTexture != null)
				{
					fogTexture.SetPixels32(pixels);
					if ((object)fogTexture != null)
					{
						fogTexture.Apply();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public FullMap()
	{
		HashSet<int> hashSet = new HashSet<int>();
		revealedIndices = hashSet;
		base._002Ector();
	}
}
