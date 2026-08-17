using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.App.UI.Bestiary;

public class UISketamari : MonoBehaviour
{
	private float _Speed = 100f;

	private GameObject _BonesParent;

	private DataManager _dataManager;

	private readonly EnemyType[] _enemiesArray = new EnemyType[10]
	{
		EnemyType.SKELETON,
		EnemyType.SKELETON2,
		EnemyType.SKELETON3,
		EnemyType.SKELETON4,
		EnemyType.SKULLINO,
		EnemyType.SKELEPANTHER,
		EnemyType.SKELETONE,
		EnemyType.SKELEWING_ZONE,
		EnemyType.SKULLNOAURA,
		EnemyType.SKULLNOAURA
	};

	private void Awake()
	{
		Transform transform = _BonesParent.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private unsafe void Update()
	{
		//IL_004a: Expected O, but got F4
		//IL_003b: Expected O, but got Ref
		Transform transform = _BonesParent.transform;
		object obj = Time.deltaTime;
		object obj2 = default(object);
		float angle = (float)obj2 * _Speed;
		object obj3 = default(object);
		transform.Rotate((Vector3)(&obj3), angle, Space.Self);
	}

	private void OnDestroy()
	{
		Transform transform = _BonesParent.transform;
		if ((object)transform != null)
		{
			float optionalFloat = default(float);
			object optionalObj = default(object);
			object[] optionalArray = default(object[]);
			int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)transform, false, optionalFloat, optionalObj, optionalArray);
		}
	}

	public void Generate(DataManager dataManager)
	{
		_dataManager = dataManager;
		float radiusMax = default(float);
		float scaleMax = default(float);
		bool flipY = default(bool);
		AddBones(_BonesParent, 60, 0.75f, radiusMax, scaleMax, flipY);
		AddBones(_BonesParent, 35, 0.5f, radiusMax, scaleMax, flipY);
		AddBones(_BonesParent, 25, 0f, radiusMax, scaleMax, flipY);
		Transform target = _BonesParent.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 400f, 60.000004f);
	}

	private unsafe void AddBones(GameObject container, int amount, float radiusMin, float radiusMax, float scaleMax, bool flipY)
	{
		//IL_003e: Expected O, but got I4
		//IL_05b2: Expected O, but got I4
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Expected O, but got Unknown
		//IL_01cc: Expected O, but got I
		//IL_01f5: Expected O, but got I
		//IL_0256: Expected O, but got Ref
		//IL_02de: Expected O, but got I
		//IL_0317: Expected O, but got I
		//IL_0347: Expected I4, but got O
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Expected I4, but got Unknown
		//IL_0421: Expected O, but got I
		//IL_044c: Expected I4, but got O
		//IL_048e->IL0578: Incompatible stack heights: 1 vs 0
		//IL_03a2->IL0578: Incompatible stack heights: 1 vs 0
		//IL_04b8->IL0578: Incompatible stack heights: 1 vs 0
		//IL_03c7->IL0578: Incompatible stack heights: 1 vs 0
		//IL_03fd->IL0578: Incompatible stack heights: 1 vs 0
		//IL_0577->IL05b7: Incompatible stack heights: 1 vs 0
		if (_dataManager != null)
		{
			Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = _dataManager.GetConvertedEnemyData();
			if (amount <= 0)
			{
				return;
			}
			object obj = 0;
			Dictionary<EnemyType, List<EnemyData>> dictionary = convertedEnemyData;
			int num = amount;
			string text = default(string);
			Vector3 value3 = default(Vector3);
			object obj4 = default(object);
			object obj5 = default(object);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			object obj6 = default(object);
			object obj7 = default(object);
			List<string> frameNames2 = default(List<string>);
			object obj8 = default(object);
			while (true)
			{
				EnemyType[] enemiesArray = _enemiesArray;
				if (_enemiesArray == null)
				{
					break;
				}
				object obj2 = UnityEngine.Random.RandomRangeInt(0, enemiesArray.Length);
				if (dictionary == null)
				{
					break;
				}
				object obj3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref enemiesArray[obj2]));
				if (obj3 != null)
				{
					List<EnemyData> list = ((Dictionary<EnemyType, List<EnemyData>>)obj3).get_Item(EnemyType.BAT1);
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm8,r15d\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebp\"");
						float value = UnityEngine.Random.value;
						List<EnemyData> list2 = ((Dictionary<EnemyType, List<EnemyData>>)null).get_Item(EnemyType.BAT1);
						float value2 = UnityEngine.Random.value;
						List<EnemyData> list3 = ((Dictionary<EnemyType, List<EnemyData>>)null).get_Item(EnemyType.BAT1);
						List<EnemyData> list4 = ((Dictionary<EnemyType, List<EnemyData>>)obj3).get_Item(EnemyType.BAT1);
						if (list4 == null)
						{
							break;
						}
						List<EnemyData> list5 = ((Dictionary<EnemyType, List<EnemyData>>)obj3).get_Item(EnemyType.BAT1);
						if (list5 == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rax_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.Enemies.EnemyData>)+D8]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rax_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.Enemies.EnemyData>)+D8]");
						List<EnemyData> list6 = ((Dictionary<EnemyType, List<EnemyData>>)0).get_Item(EnemyType.BAT1);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.Enemies.EnemyData>)+C8]");
						SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(this, 0f, 0f, (string)0, text);
						if ((object)spriteRenderer == null)
						{
							break;
						}
						Transform transform = spriteRenderer.transform;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value3);
						float value4 = UnityEngine.Random.value;
						bool flag2 = value4 < 0.5f;
						bool flipX = !flag2;
						spriteRenderer.flipX = flipX;
						float value5 = UnityEngine.Random.value;
						Transform transform2 = spriteRenderer.transform;
						transform2.localEulerAngles = (Vector3)(&obj4);
						float value6 = UnityEngine.Random.value;
						float num2 = value6 * (float)obj5;
						float scale = num2 + 1f;
						SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(spriteRenderer, scale);
						GameObject gameObject = spriteRenderer.gameObject;
						SpriteAnimation spriteAnimation = gameObject.AddComponent<SpriteAnimation>();
						SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale((SpriteRenderer)obj3, scale);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v44 (UnityEngine.SpriteRenderer)+170]");
						SpriteRenderer frameNames = RenderingExtensions.SetScale((SpriteRenderer)0, scale);
						SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale((SpriteRenderer)obj3, scale);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ rax_v46 (UnityEngine.SpriteRenderer)+C8]");
						List<Sprite> animationFramesFast = SpriteManager.GetAnimationFramesFast((List<string>)(object)frameNames, (string)0);
						spriteAnimation.AddAnimation("die", animationFramesFast, 24, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ rax_v50+BC]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							if (obj6 == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rax_v62+168]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							if (obj7 == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v64+C8]");
							List<Sprite> animationFramesFast2 = SpriteManager.GetAnimationFramesFast(frameNames2, (string)0);
							spriteAnimation.AddAnimation("idle", animationFramesFast2, 8, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
							spriteAnimation.SetAnimation("idle");
						}
						Transform transform3 = spriteRenderer.transform;
						if ((object)container == null)
						{
							break;
						}
						Transform parent = container.transform;
						if ((object)transform3 == null)
						{
							break;
						}
						transform3.SetParent(parent, worldPositionStays: false);
						int maxExclusive = obj + 1;
						int num3 = UnityEngine.Random.Range(0, maxExclusive);
						int sortingOrder = num3 + 100;
						spriteRenderer.sortingOrder = sortingOrder;
						int sortingLayerID = SortingLayer.NameToID("UI");
						spriteRenderer.sortingLayerID = sortingLayerID;
						spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
						obj4 = obj8;
						value3 = (Vector3)obj8;
						dictionary = convertedEnemyData;
						text = text;
						num = amount;
					}
				}
				obj++;
				if ((nint)obj >= num)
				{
					return;
				}
			}
		}
		throw new NullReferenceException();
	}
}
