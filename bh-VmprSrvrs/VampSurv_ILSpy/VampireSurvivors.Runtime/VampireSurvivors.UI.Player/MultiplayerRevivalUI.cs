using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Graphics;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI.Player;

public class MultiplayerRevivalUI : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public MultiplayerRevivalUI _003C_003E4__this;

		public float xMovement;

		public float strength;

		internal void _003CDoShake_003Eb__1()
		{
			//IL_0149: Expected I, but got O
			//IL_0114->IL00c3: Incompatible stack heights: 1 vs 0
			//IL_00aa->IL00c3: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				Transform transform = _003C_003E4__this.transform;
				if ((object)_003C_003E4__this != null)
				{
					Transform transform2 = _003C_003E4__this.transform;
					if ((object)transform2 != null)
					{
						bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
						if ((object)_003C_003E4__this != null)
						{
							Transform transform3 = _003C_003E4__this.transform;
							if ((object)transform3 != null)
							{
								bool flag2 = (object)((_003C_003Ec__DisplayClass12_0)(object)transform3)._003C_003E4__this == null;
								Transform.get_localPosition_Injected((IntPtr)((_003C_003Ec__DisplayClass12_0)(object)transform3)._003C_003E4__this, out Vector3 _);
								bool flag3 = (object)transform == null;
								bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CDoShake_003Eb__2()
		{
			//IL_0114->IL00c3: Incompatible stack heights: 1 vs 0
			//IL_00aa->IL00c3: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				Transform transform = _003C_003E4__this.transform;
				if ((object)_003C_003E4__this != null)
				{
					Transform transform2 = _003C_003E4__this.transform;
					if ((object)transform2 != null)
					{
						bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
						if ((object)_003C_003E4__this != null)
						{
							Transform transform3 = _003C_003E4__this.transform;
							if ((object)transform3 != null)
							{
								bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Transform.get_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
								bool flag3 = (object)transform == null;
								bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CDoShake_003Eb__0()
		{
			MultiplayerRevivalUI multiplayerRevivalUI = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController character = multiplayerRevivalUI._character;
			float motorLevel = strength / 3f;
			bool stopOtherMotors = default(bool);
			character._player.SetVibration(0, motorLevel, 0.1f, stopOtherMotors);
		}
	}

	private SpriteRenderer _revivalBarFill;

	private TextMeshProUGUI _revivalsLeftText;

	private SpriteRenderer _coffinRenderer;

	private SpriteRenderer _ghostRenderer;

	private Sprite[] _revivalBarSprites;

	private MeshRenderer _coffinOutline;

	private ExplodingCoffin _explodingCoffin;

	private VampireSurvivors.Objects.Characters.CharacterController _character;

	private MultiTargetTween _shakeTween;

	private void Awake()
	{
		VampireSurvivors.Objects.Characters.CharacterController componentInParent = GetComponentInParent<VampireSurvivors.Objects.Characters.CharacterController>();
		_character = componentInParent;
	}

	private void Update()
	{
		//IL_02af: Expected O, but got I4
		//IL_0068->IL0254: Incompatible stack heights: 1 vs 0
		//IL_0179->IL0254: Incompatible stack heights: 1 vs 0
		//IL_01a8->IL0254: Incompatible stack heights: 1 vs 0
		//IL_0211->IL0254: Incompatible stack heights: 1 vs 0
		//IL_00d6->IL0254: Incompatible stack heights: 1 vs 0
		//IL_01d1->IL0254: Incompatible stack heights: 1 vs 0
		//IL_023a->IL0254: Incompatible stack heights: 1 vs 0
		//IL_0105->IL0254: Incompatible stack heights: 1 vs 0
		//IL_012e->IL0254: Incompatible stack heights: 1 vs 0
		if (IsVisible())
		{
			UpdateCoffinVisuals();
		}
		SpriteRenderer ghostRenderer = _ghostRenderer;
		SpriteRenderer ghostRenderer2;
		bool flipX;
		if ((object)_ghostRenderer != null)
		{
			bool flag = ((UnityEngine.Object)ghostRenderer).m_CachedPtr == (IntPtr)0;
			object obj = Renderer.get_enabled_Injected(((UnityEngine.Object)ghostRenderer).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			VampireSurvivors.Objects.Characters.CharacterController character = _character;
			if ((object)_character != null)
			{
				if ((nint)character._currentDirection <= 0)
				{
					if (0 <= (nint)character._currentDirection)
					{
						goto IL_01f7;
					}
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						CoopConfig coopConfig = core.CoopConfig;
						if ((object)core.CoopConfig != null)
						{
							ghostRenderer2 = _ghostRenderer;
							if ((object)_ghostRenderer != null)
							{
								bool flag2 = !coopConfig._ghostUsesCharacterSprite;
								flipX = !flag2;
								goto IL_02cc;
							}
						}
					}
				}
				else
				{
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						CoopConfig coopConfig2 = core2.CoopConfig;
						if ((object)core2.CoopConfig != null)
						{
							ghostRenderer2 = _ghostRenderer;
							if ((object)_ghostRenderer != null)
							{
								bool flag3 = !coopConfig2._ghostUsesCharacterSprite;
								flipX = flag3;
								goto IL_02cc;
							}
						}
					}
				}
			}
		}
		goto IL_0254;
		IL_01f7:
		if ((object)_character != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
			if ((object)_ghostRenderer != null)
			{
				int sortingOrder = default(int);
				_ghostRenderer.sortingOrder = sortingOrder;
				return;
			}
		}
		goto IL_0254;
		IL_02cc:
		ghostRenderer2.flipX = flipX;
		goto IL_01f7;
		IL_0254:
		throw new NullReferenceException();
	}

	private void SetBarFill(float fillProportion)
	{
		//IL_001f: Expected O, but got I4
		Sprite[] revivalBarSprites = _revivalBarSprites;
		object obj = revivalBarSprites.Length - 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
		}
		_revivalBarFill.sprite = revivalBarSprites[obj];
	}

	public void DoShake(float strength)
	{
		//IL_00ce: Expected I, but got O
		//IL_014e: Expected O, but got I4
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass12_0();
		CS_0024_003C_003E8__locals18._003C_003E4__this = this;
		CS_0024_003C_003E8__locals18.strength = strength;
		float num = strength * 3f;
		float xMovement = num * 0.01f;
		CS_0024_003C_003E8__locals18.xMovement = xMovement;
		if (_shakeTween != null)
		{
			_shakeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 64f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 4;
		tweenConfig.localX = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0149: Expected I, but got O
			//IL_0114->IL00c3: Incompatible stack heights: 1 vs 0
			//IL_00aa->IL00c3: Incompatible stack heights: 1 vs 0
			if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null)
			{
				Transform transform2 = CS_0024_003C_003E8__locals18._003C_003E4__this.transform;
				if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null)
				{
					Transform transform3 = CS_0024_003C_003E8__locals18._003C_003E4__this.transform;
					if ((object)transform3 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.get_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 ret);
						if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null)
						{
							Transform transform4 = CS_0024_003C_003E8__locals18._003C_003E4__this.transform;
							if ((object)transform4 != null)
							{
								bool flag3 = (object)((_003C_003Ec__DisplayClass12_0)(object)transform4)._003C_003E4__this == null;
								Transform.get_localPosition_Injected((IntPtr)((_003C_003Ec__DisplayClass12_0)(object)transform4)._003C_003E4__this, out Vector3 _);
								bool flag4 = (object)transform2 == null;
								bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			//IL_0114->IL00c3: Incompatible stack heights: 1 vs 0
			//IL_00aa->IL00c3: Incompatible stack heights: 1 vs 0
			if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null)
			{
				Transform transform2 = CS_0024_003C_003E8__locals18._003C_003E4__this.transform;
				if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null)
				{
					Transform transform3 = CS_0024_003C_003E8__locals18._003C_003E4__this.transform;
					if ((object)transform3 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.get_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 ret);
						if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null)
						{
							Transform transform4 = CS_0024_003C_003E8__locals18._003C_003E4__this.transform;
							if ((object)transform4 != null)
							{
								bool flag3 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
								Transform.get_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out Vector3 _);
								bool flag4 = (object)transform2 == null;
								bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween shakeTween = Tweens.Add(tweenConfig);
		_shakeTween = shakeTween;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CControllerVibrationEnabled_003Ek__BackingField)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController character = _character;
		if (character._player != null && character._PlayerIndex >= 0)
		{
			float motorLevel = CS_0024_003C_003E8__locals18.strength / 3f;
			bool flag = default(bool);
			character._player.SetVibration(0, motorLevel, 0.1f, flag);
			Action onComplete2 = delegate
			{
				MultiplayerRevivalUI multiplayerRevivalUI = CS_0024_003C_003E8__locals18._003C_003E4__this;
				VampireSurvivors.Objects.Characters.CharacterController character2 = multiplayerRevivalUI._character;
				float motorLevel2 = CS_0024_003C_003E8__locals18.strength / 3f;
				bool stopOtherMotors = default(bool);
				character2._player.SetVibration(0, motorLevel2, 0.1f, stopOtherMotors);
			};
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.2f, onComplete2, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public unsafe void OpenLidAnimation()
	{
		//IL_02ed: Expected I, but got O
		//IL_01cd: Expected O, but got Ref
		//IL_01cd: Expected O, but got Ref
		//IL_0259: Expected O, but got Ref
		//IL_021b->IL025a: Incompatible stack heights: 1 vs 0
		//IL_0201->IL0201: Incompatible stack heights: 2 vs 1
		//IL_0247->IL025a: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				if (config._003CControllerVibrationEnabled_003Ek__BackingField)
				{
					VampireSurvivors.Objects.Characters.CharacterController character = _character;
					if ((object)_character == null)
					{
						goto IL_025a;
					}
					if (character._player != null && character._PlayerIndex >= 0)
					{
						bool stopOtherMotors = default(bool);
						character._player.SetVibration(0, 1f, 0.25f, stopOtherMotors);
					}
				}
				Debug.Log("OPEN LID ANIMATION");
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					nint num = (nint)typeof(Quaternion);
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ rdi_v6 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ rdi_v6 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
						}
					}
					object obj2 = default(object);
					Quaternion quaternion = default(Quaternion);
					UnityEngine.Object obj = UnityEngine.Object.Instantiate((UnityEngine.Object)_explodingCoffin, (Vector3)(&obj2), (Quaternion)(&quaternion));
					bool flag2 = (object)obj == null;
					ExplodingCoffin explodingCoffin = null;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						ExplodingCoffin explodingCoffin2 = default(ExplodingCoffin);
						bool flag3 = (object)explodingCoffin2 == null;
						explodingCoffin = explodingCoffin2;
					}
					if ((object)_character != null)
					{
						Color coopColour = _character.GetCoopColour();
						if ((object)explodingCoffin != null)
						{
							explodingCoffin.Explode((Color)(&quaternion));
							return;
						}
					}
				}
			}
		}
		goto IL_025a;
		IL_025a:
		throw new NullReferenceException();
	}

	private unsafe void UpdateCoffinVisuals()
	{
		//IL_0025: Expected O, but got I4
		//IL_00ad: Expected O, but got Ref
		Sprite[] revivalBarSprites = _revivalBarSprites;
		object obj = revivalBarSprites.Length - 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
		}
		_revivalBarFill.sprite = revivalBarSprites[obj];
		Color coopColour = _character.GetCoopColour();
		SpriteRenderer coffinRenderer = _coffinRenderer;
		bool flag = ((UnityEngine.Object)coffinRenderer).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)coffinRenderer).m_CachedPtr, ref *(Color*)(&value));
		Material material = ((Renderer)_coffinOutline).GetMaterial();
		float num = default(float);
		material.color = (Color)(&num);
	}

	public void ToggleVisible(bool visible)
	{
		//IL_010a: Expected I, but got O
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_037c: Expected O, but got I4
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected O, but got Unknown
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(visible);
		if (!visible)
		{
			return;
		}
		UpdateCoffinVisuals();
		int sortingOrder = _coffinRenderer.sortingOrder;
		int sortingOrder2 = sortingOrder + 4000;
		_coffinOutline.sortingOrder = sortingOrder2;
		GameManager core = GM.Core;
		CoopConfig coopConfig = core.CoopConfig;
		if (coopConfig._immediateRevivalUsage)
		{
			GameObject gameObject2 = _revivalsLeftText.gameObject;
			gameObject2.SetActive(value: false);
			return;
		}
		GameObject gameObject3 = _revivalsLeftText.gameObject;
		gameObject3.SetActive(value: true);
		VampireSurvivors.Objects.Characters.CharacterController character = _character;
		nint num = (nint)character;
		EggDouble eggDouble = character.PRevivals();
		double num2 = eggDouble._eggVal;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rax+10h]\"");
		object obj = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj != 9218868437227405312L)
		{
			object obj2 = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj2 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E02C28h\"");
				if ((long)obj2 == 9218868437227405312L)
				{
					num2 = -1.7976931348623157E+308;
				}
				goto IL_03ec;
			}
		}
		num2 = 1.7976931348623157E+308;
		goto IL_03ec;
		IL_03ec:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		if (num2 < 2147483648.0 && -2147483648.0 < num2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		}
		EggDouble eggDouble2 = _character.PRevivals();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,qword ptr [rax+10h]\"");
		object obj3 = eggDouble2._eggVal & 0x7FFFFFFFFFFFFFFFL;
		string text;
		if ((long)obj3 != 9218868437227405312L)
		{
			object obj4 = eggDouble2._eggVal & 0x7FFFFFFFFFFFFFFFL;
			object obj5 = obj4 - 9218868437227405312L;
			object obj6 = obj4 ^ 0x7FF0000000000000L;
			object obj7 = obj4 ^ obj5;
			object obj8 = obj6 & obj7;
			bool flag = (nint)obj8 < 0;
			bool flag2 = (nint)obj5 < 0;
			bool flag3 = (long)obj4 == 9218868437227405312L;
			if ((long)obj4 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E02CBAh\"");
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
					bool flag4 = flag2 == flag;
					object obj9 = !flag4;
					object obj10 = obj9 | flag3;
					if (obj10 != null)
					{
						goto IL_03a5;
					}
				}
				text = "No Revives Left!";
				goto IL_03c9;
			}
		}
		goto IL_03a5;
		IL_03a5:
		int num3 = default(int);
		string text2 = num3.ToString();
		text = "Revivals: " + text2;
		goto IL_03c9;
		IL_03c9:
		_revivalsLeftText.text = text;
	}

	public void SetGhost(bool isGhost)
	{
		bool flag = (byte)((isGhost ? 1u : 0u) ^ 1u) != 0;
		_coffinRenderer.enabled = flag;
		_ghostRenderer.enabled = isGhost;
		if (!isGhost)
		{
			return;
		}
		GameManager core = GM.Core;
		CoopConfig coopConfig = core.CoopConfig;
		if (coopConfig._ghostUsesCharacterSprite)
		{
			VampireSurvivors.Objects.Characters.CharacterController character = _character;
			if ((object)_character == null || ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0)
			{
				VampireSurvivors.Objects.Characters.CharacterController componentInParent = GetComponentInParent<VampireSurvivors.Objects.Characters.CharacterController>();
				_character = componentInParent;
			}
			VampireSurvivors.Objects.Characters.CharacterController character2 = _character;
			CharacterData currentSkinData = character2._currentSkinData;
			Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData._003CtextureName_003Ek__BackingField);
			_ghostRenderer.sprite = sprite;
		}
	}

	public bool IsGhost()
	{
		GameObject gameObject = base.gameObject;
		bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		bool flag2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
		if (!flag2)
		{
			return flag2;
		}
		return _ghostRenderer.enabled;
	}

	public bool IsVisible()
	{
		GameObject gameObject = base.gameObject;
		bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 45 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	public MultiplayerRevivalUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
