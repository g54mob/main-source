using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class ChestOpening : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ItemData, int> _003C_003E9__33_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003COpenChest_003Eb__33_0(ItemData x)
		{
			//IL_0026: Expected I4, but got O
			if (MyRandom.random != null)
			{
				return MyRandom.random.Next();
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private sealed class _003CAnimateEffects_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChestOpening _003C_003E4__this;

		public ItemData itemData;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CAnimateEffects_003Ed__54(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0012: Expected O, but got I8
			//IL_002c: Expected O, but got I8
			while (true)
			{
				int num = _003C_003E1__state;
				if (_003C_003E1__state > 5)
				{
					break;
				}
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v1+3622A0+v29 @ rax_v2 (System.Int32)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v52 @ rcx_v3 (should have been resolved before IL gen)");
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	private sealed class _003CAnimateOpening_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChestOpening _003C_003E4__this;

		public ItemData itemData;

		private float _003Ctimer_003E5__2;

		private float _003CwaitTime_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CAnimateOpening_003Ed__48(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_076f: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0207: Expected I4, but got I8
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_01ee: Expected I4, but got I8
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_00b0: Expected I4, but got I8
			//IL_084d: Expected I4, but got O
			//IL_07e3: Expected I, but got O
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Expected O, but got Unknown
			//IL_00d9: Expected O, but got Ref
			//IL_0093: Expected I4, but got I8
			//IL_0647: Expected O, but got Ref
			//IL_04e9: Expected O, but got I4
			//IL_0389: Expected O, but got I4
			//IL_02ef: Expected O, but got Ref
			//IL_0325: Expected I, but got O
			//IL_0500: Unknown result type (might be due to invalid IL or missing references)
			//IL_0505: Expected O, but got Unknown
			//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a5: Expected O, but got Unknown
			//IL_034f: Expected I, but got O
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c1: Expected O, but got Unknown
			//IL_0728: Unknown result type (might be due to invalid IL or missing references)
			//IL_072d: Expected O, but got Unknown
			ChestOpening chestOpening = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			nint num = default(nint);
			bool result;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					chestOpening.particlesCoinsParent.SetActive(value: true);
					ParticleSystem[] psChestEmission = chestOpening.psChestEmission;
					object obj2 = null;
					object obj3 = null;
					while ((nint)obj3 < psChestEmission.Length)
					{
						if ((nint)obj2 < psChestEmission.Length)
						{
							psChestEmission[obj2].enableEmission = true;
							obj2++;
							obj3 = obj2;
							continue;
						}
						goto IL_083f;
					}
					SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
					if ((object)SaveManager._003CInstance_003Ek__BackingField != null && saveManager.progression != null)
					{
						string statName = ((Enum)(&num)).ToString();
						float stat = MyStats.GetStat(statName);
						bool flag2 = !(stat > 10f);
						num = (nint)typeof(EMyStat);
						if (!flag2)
						{
							chestOpening.canSkip = true;
							num = (nint)typeof(EMyStat);
						}
					}
					ItemData itemData = this.itemData;
					_003Ctimer_003E5__2 = 0f;
					_003CwaitTime_003E5__3 = 1.5f;
					bool flag3 = itemData.rarity == EItemRarity.Common;
					if (!flag3)
					{
						object obj4 = itemData.rarity - 1;
						if (!flag3)
						{
							object obj5 = obj4 - 1;
							if (!flag3)
							{
								object obj6 = obj5 - 1;
								if (!flag3 && (nint)obj6 != 1)
								{
									goto IL_0898;
								}
							}
							_003CwaitTime_003E5__3 = 3.005f;
						}
						else
						{
							_003CwaitTime_003E5__3 = 2.26f;
						}
					}
					goto IL_0898;
				}
				object obj7 = obj - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					goto IL_040f;
				}
				object obj8 = obj7 - 1;
				if (!flag)
				{
					bool flag4 = (nint)obj8 != 1;
					result = false;
					if (!flag4)
					{
						_003C_003E1__state = -1;
						result = false;
					}
					goto IL_07d0;
				}
				_003C_003E1__state = -1;
				Transform transform = chestOpening.itemIcon.transform;
				nint num2 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v68 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num3 = 0;
				float num4 = (float)Vector3.oneVector * 1.75f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdx_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
				float num5 = 0f * 1.75f;
				float num6 = default(float);
				transform.localScale = (Vector3)(&num6);
				chestOpening.fxCommon.SetActive(value: false);
				chestOpening.fxRare.SetActive(value: false);
				chestOpening.fxEpic.SetActive(value: false);
				chestOpening.fxLegendary.SetActive(value: false);
				chestOpening.fxCorrupted.SetActive(value: false);
				chestOpening.chestAnimator.Play("OpenedBounce", 0, 0f);
				chestOpening.backgroundGlow.enableEmission = false;
				chestOpening.desiredFov = 10f;
				Action<ItemData> a_ChestFinished = A_ChestFinished;
				if (A_ChestFinished != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1160 @ rax_v71 (System.Action`1<ItemData>)+18] (should have been resolved before IL gen)");
				}
				WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 4;
			}
			else
			{
				_003C_003E1__state = -1;
				_003CAnimateEffects_003Ed__54 obj9 = new _003CAnimateEffects_003Ed__54(0);
				obj9._003C_003E4__this = _003C_003E4__this;
				obj9._003C_003E1__state = 0;
				obj9.itemData = this.itemData;
				_003C_003E2__current = obj9;
				_003C_003E1__state = 1;
			}
			goto IL_08b2;
			IL_040f:
			if (!(_003CwaitTime_003E5__3 > _003Ctimer_003E5__2))
			{
				goto IL_05d6;
			}
			if (!chestOpening.skipped)
			{
				float deltaTime = Time.deltaTime;
				float num7 = deltaTime + _003Ctimer_003E5__2;
				_003C_003E2__current = null;
				_003Ctimer_003E5__2 = num7;
				_003C_003E1__state = 2;
				goto IL_08b2;
			}
			chestOpening.sfxBuildup.Stop();
			ItemData itemData2 = this.itemData;
			bool flag5 = itemData2.rarity == EItemRarity.Common;
			AudioSource sfxBuildup;
			AudioClip clip;
			if (!flag5)
			{
				object obj10 = itemData2.rarity - 1;
				if (!flag5)
				{
					object obj11 = obj10 - 1;
					if (!flag5)
					{
						if ((nint)obj11 != 1)
						{
							goto IL_05c3;
						}
						sfxBuildup = chestOpening.sfxBuildup;
						clip = chestOpening.skipLegendary;
					}
					else
					{
						sfxBuildup = chestOpening.sfxBuildup;
						clip = chestOpening.skipEpic;
					}
				}
				else
				{
					sfxBuildup = chestOpening.sfxBuildup;
					clip = chestOpening.skipRare;
				}
			}
			else
			{
				sfxBuildup = chestOpening.sfxBuildup;
				clip = chestOpening.skipCommon;
			}
			sfxBuildup.clip = clip;
			goto IL_05c3;
			IL_07d0:
			return result;
			IL_083f:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (byte)(int)ex != 0;
			IL_0898:
			ControllerShaker.Shake(1, 0.15f, _003CwaitTime_003E5__3);
			goto IL_040f;
			IL_05c3:
			chestOpening.sfxBuildup.Play();
			goto IL_05d6;
			IL_08b2:
			result = true;
			goto IL_07d0;
			IL_05d6:
			chestOpening.canSkip = false;
			chestOpening.fxFinal.SetActive(value: true);
			chestOpening.spinning = false;
			ItemData itemData3 = this.itemData;
			Color itemRarityColor = MyColorUtility.GetItemRarityColor(itemData3.rarity);
			chestOpening.itemShine.startColor = (Color)(&num);
			GameObject gameObject = chestOpening.itemShine.gameObject;
			gameObject.SetActive(value: true);
			chestOpening.fxCommon.SetActive(value: false);
			ItemData itemData4 = this.itemData;
			chestOpening.itemIcon.texture = itemData4.icon;
			ParticleSystem[] psChestEmission2 = chestOpening.psChestEmission;
			object obj12 = null;
			while ((nint)obj12 < psChestEmission2.Length)
			{
				if ((nint)obj12 < psChestEmission2.Length)
				{
					psChestEmission2[obj12].enableEmission = false;
					obj12++;
					continue;
				}
				goto IL_083f;
			}
			WaitForSeconds waitForSeconds2 = new WaitForSeconds(0.1f);
			_003C_003E2__current = waitForSeconds2;
			_003C_003E1__state = 3;
			goto IL_08b2;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public SkinnedMeshRenderer chestRenderer;

	public Animator chestAnimator;

	public AudioSource sfxOpen;

	public AudioSource sfxBuildup;

	public AudioSource sfxBuildupIntro;

	private bool spinning;

	private bool opened;

	public AudioClip buildupCommon;

	public AudioClip buildupRare;

	public AudioClip buildupEpic;

	public AudioClip buildupLegendary;

	public AudioClip skipCommon;

	public AudioClip skipRare;

	public AudioClip skipEpic;

	public AudioClip skipLegendary;

	public GameObject backgroundParticles;

	public ParticleSystem itemShine;

	public ParticleSystem backgroundGlow;

	public ParticleSystem[] psChestEmission;

	public GameObject particlesCoinsParent;

	public Mesh meshNormal;

	public Mesh meshFree;

	public Mesh meshEvil;

	public Material matNormal;

	public Material matFree;

	public Material matEvil;

	public Material matFreeCrypt;

	public Material matGhost;

	public Camera cam;

	public static Action<ItemData> A_ChestFinished;

	private ItemData itemData;

	private List<ItemData> rollingItems;

	public RawImage itemIcon;

	private int index;

	private const float updateRate = 0.06f;

	private float nextIconUpdate;

	private Vector3 desiredPosition;

	public GameObject fxCommon;

	public GameObject fxRare;

	public GameObject fxEpic;

	public GameObject fxLegendary;

	public GameObject fxCorrupted;

	public GameObject fxFinal;

	public Texture[] testSpinTextures;

	private bool canSkip;

	private bool skipped;

	private float desiredFov;

	private float defaultFov;

	private float timeBetweenTiers;

	public unsafe void SetChest(EChest chestType)
	{
		//IL_01f2: Expected O, but got Ref
		//IL_0218: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183171FF8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		Renderer renderer;
		Material material;
		if (chestType != EChest.Normal)
		{
			if (chestType != EChest.Free)
			{
				if (chestType != EChest.FreeCrypt)
				{
					if (chestType != EChest.Corrupt)
					{
						if (chestType != EChest.Ghost)
						{
							goto IL_01c0;
						}
						chestRenderer.sharedMesh = meshNormal;
						renderer = chestRenderer;
						material = matGhost;
					}
					else
					{
						chestRenderer.sharedMesh = meshEvil;
						renderer = chestRenderer;
						material = matEvil;
					}
				}
				else
				{
					chestRenderer.sharedMesh = meshFree;
					renderer = chestRenderer;
					material = matFreeCrypt;
				}
			}
			else
			{
				chestRenderer.sharedMesh = meshFree;
				renderer = chestRenderer;
				material = matFree;
			}
		}
		else
		{
			chestRenderer.sharedMesh = meshNormal;
			renderer = chestRenderer;
			material = matNormal;
		}
		renderer.SetMaterial(material);
		goto IL_01c0;
		IL_01c0:
		spinning = false;
		Transform transform = itemIcon.transform;
		Vector3 vector = default(Vector3);
		transform.localPosition = (Vector3)(&vector);
		Transform transform2 = itemIcon.transform;
		transform2.localScale = (Vector3)(&vector);
		fxFinal.SetActive(value: false);
		backgroundParticles.SetActive(value: false);
		GameObject gameObject2 = itemShine.gameObject;
		gameObject2.SetActive(value: false);
		chestAnimator.Play("Intro", 0, 0f);
	}

	private void SetRender(EChest chest)
	{
		switch (chest)
		{
		case EChest.Ghost:
			chestRenderer.sharedMesh = meshNormal;
			((Renderer)chestRenderer).SetMaterial(matGhost);
			break;
		case EChest.Corrupt:
			chestRenderer.sharedMesh = meshEvil;
			((Renderer)chestRenderer).SetMaterial(matEvil);
			break;
		case EChest.FreeCrypt:
			chestRenderer.sharedMesh = meshFree;
			((Renderer)chestRenderer).SetMaterial(matFreeCrypt);
			break;
		case EChest.Free:
			chestRenderer.sharedMesh = meshFree;
			((Renderer)chestRenderer).SetMaterial(matFree);
			break;
		case EChest.Normal:
			chestRenderer.sharedMesh = meshNormal;
			((Renderer)chestRenderer).SetMaterial(matNormal);
			break;
		}
	}

	public void OpenChest(ItemData itemData)
	{
		canSkip = false;
		this.itemData = itemData;
		chestAnimator.Play("Open");
		_003CAnimateOpening_003Ed__48 obj = new _003CAnimateOpening_003Ed__48(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.itemData = itemData;
		Coroutine coroutine = StartCoroutine(obj);
		object source = ((Dictionary<System.Int32Enum, object>)(object)RunUnlockables.availableItems).get_Item((System.Int32Enum)itemData.rarity);
		List<object> list = Enumerable.ToList((IEnumerable<object>)source);
		rollingItems = (List<ItemData>)(object)list;
		List<object> list2 = (List<object>)(object)rollingItems;
		if (list2._size > 2)
		{
			bool flag = list2.Remove(itemData);
		}
		Func<ItemData, int> keySelector = _003C_003Ec._003C_003E9__33_0;
		if (_003C_003Ec._003C_003E9__33_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__33_0 = delegate
			{
				//IL_0026: Expected I4, but got O
				if (MyRandom.random == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
				return MyRandom.random.Next();
			});
		}
		IOrderedEnumerable<ItemData> source2 = Enumerable.OrderBy(rollingItems, keySelector);
		List<object> list3 = Enumerable.ToList((IEnumerable<object>)source2);
		rollingItems = (List<ItemData>)(object)list3;
	}

	private unsafe void Update()
	{
		//IL_039e: Invalid comparison between I4 and F4
		//IL_03e9: Expected F4, but got I4
		//IL_0424: Invalid comparison between I4 and F4
		//IL_046f: Expected F4, but got I4
		//IL_0177: Invalid comparison between I4 and F4
		//IL_01c2: Expected F4, but got I4
		//IL_01d4: Expected O, but got Ref
		//IL_04fc: Invalid comparison between I4 and F4
		//IL_024a: Expected F4, but got I4
		//IL_025c: Expected O, but got Ref
		if (canSkip)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			if ((object)SaveManager._003CInstance_003Ek__BackingField != null && saveManager.config != null && (MyInputManager.GetButtonDown(MyInputManager.Interact) || Input.GetMouseButtonDown(0)))
			{
				skipped = true;
			}
		}
		if (opened)
		{
			ItemData itemData = this.itemData;
			float num;
			if (itemData.rarity == EItemRarity.Common)
			{
				num = 2f;
			}
			else
			{
				bool flag = itemData.rarity != EItemRarity.Rare;
				num = 1f;
				if (!flag)
				{
					num = 1.4f;
				}
			}
			Transform transform = itemIcon.transform;
			Transform transform2 = itemIcon.transform;
			Vector3 localPosition = transform2.localPosition;
			float deltaTime = Time.deltaTime;
			float num2 = deltaTime * num;
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			else
			{
				num2 = 0f;
			}
			float num3 = default(float);
			transform.localPosition = (Vector3)(&num3);
			Transform transform3 = itemIcon.transform;
			Transform transform4 = itemIcon.transform;
			Vector3 localScale = transform4.localScale;
			float deltaTime2 = Time.deltaTime;
			float num4 = deltaTime2 * num;
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			transform3.localScale = (Vector3)(&num3);
		}
		if (spinning)
		{
			float time = Time.time;
			if (time > nextIconUpdate)
			{
				List<ItemData> list = rollingItems;
				List<ItemData> list2;
				int num7;
				if (list._size != 1)
				{
					float time2 = Time.time;
					float num5 = time2 + 0.06f;
					int num6 = index + 1;
					index = num6;
					list2 = rollingItems;
					nextIconUpdate = num5;
					num7 = index % list2._size;
				}
				else
				{
					num7 = 0;
					list2 = list;
				}
				ItemData itemData2 = list2.get_Item(num7);
				Texture icon = itemData2.GetIcon();
				itemIcon.texture = icon;
			}
		}
		float deltaTime3 = Time.deltaTime;
		float num8 = deltaTime3 * 14f;
		if (!(0f > num8))
		{
			if (num8 > 1f)
			{
				num8 = 1f;
			}
		}
		else
		{
			num8 = 0f;
		}
		float num9 = defaultFov - desiredFov;
		float num10 = num9 * num8;
		float num11 = num10 + desiredFov;
		desiredFov = num11;
		float fieldOfView = cam.fieldOfView;
		float deltaTime4 = Time.deltaTime;
		float num12 = deltaTime4 * 15f;
		if (!(0f > num12))
		{
			if (num12 > 1f)
			{
				num12 = 1f;
			}
		}
		else
		{
			num12 = 0f;
		}
		float num13 = desiredFov - fieldOfView;
		float num14 = num13 * num12;
		float fieldOfView2 = num14 + fieldOfView;
		cam.fieldOfView = fieldOfView2;
	}

	private IEnumerator AnimateOpening(ItemData itemData)
	{
		_003CAnimateOpening_003Ed__48 obj = new _003CAnimateOpening_003Ed__48(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.itemData = itemData;
		return obj;
	}

	private IEnumerator AnimateEffects(ItemData itemData)
	{
		_003CAnimateEffects_003Ed__54 obj = new _003CAnimateEffects_003Ed__54(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.itemData = itemData;
		return obj;
	}

	public ChestOpening()
	{
		//IL_0011: Expected O, but got I4
		_ = 1075838976;
		desiredPosition = (Vector3)0;
		desiredFov = 40f;
		defaultFov = 40f;
		timeBetweenTiers = 0.32f;
		base._002Ector();
	}
}
