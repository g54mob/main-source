using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Bindings;

namespace VampireSurvivors;

public class TreasureRibbonTrailGenerator : MonoBehaviour
{
	private float _Scale = 1f;

	private List<Vector2> _Points;

	private GameObject _TrailPrefab;

	private List<Vector2> _Ribbon3Points;

	private GameObject _RibbonTrailPrefab;

	private RectTransform _Reels3StartPosition;

	private RectTransform ReelsIconsContainer;

	private List<SplineComputer> _spawnedCurves;

	private List<GameObject> _trails;

	private List<SplineComputer> _spawnedReelCurves;

	private List<GameObject> _reelTrails;

	private List<GameObject> _reelTrails3;

	private void Awake()
	{
		GenerateReelCurves();
	}

	private float GetCameraRTScale()
	{
		Camera main = Camera.main;
		if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
		{
			return 0.666875f;
		}
		return 1f;
	}

	public unsafe void MakeRibbons()
	{
		//IL_0430: Expected O, but got I4
		//IL_04e0: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		//IL_021a: Expected O, but got Ref
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_041a->IL04cd: Incompatible stack heights: 1 vs 0
		Vector2 vector = (Vector2)0;
		Vector2 item = default(Vector2);
		Vector2 vec = default(Vector2);
		float x = default(float);
		bool flipX = default(bool);
		bool flipY = default(bool);
		float value = default(float);
		bool flag4;
		do
		{
			List<Vector2> list = new List<Vector2>();
			Vector2 vector2 = (Vector2)0;
			Vector3 position;
			GameObject gameObject2;
			Transform transform3;
			while (true)
			{
				List<Vector2> points = _Points;
				if (_Points != null)
				{
					Vector2 vector3 = vector2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v7 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if ((nint)vector3 < 0)
					{
						_Points.Add(vector2);
						float num = UnityEngine.Random.Range(0f, 1f);
						if (_Points != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
							if (list != null)
							{
								list.Add(item);
								vector2++;
								continue;
							}
						}
					}
					else
					{
						float num2 = UnityEngine.Random.Range(0f, 1f);
						bool flag = !(num2 > 0.25f);
						float num3 = 1f;
						if (!flag)
						{
							bool flag2 = list == null;
							num3 = 1f;
							Vector2 vector4 = (Vector2)0;
							Vector2 vector5 = (Vector2)0;
							if (flag2)
							{
								goto IL_0420;
							}
							while (true)
							{
								Vector2 vector6 = vector5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
								if ((nint)vector6 >= 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
								num2 = UnityEngine.Random.Range(-10f, 10f);
								Vector2 vector7 = RotateVectorByDegrees(vec, num2);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180612C40");
								vector5++;
								num3 = 10f;
								vector4 = vector7;
							}
						}
						Transform transform = base.transform;
						if ((object)transform != null)
						{
							position = transform.position;
							Transform parent = base.transform;
							SplineComputer splineComputer = SplineManager.Create((Vector3)(&x), list, parent, _Scale, flipX, flipY);
							if ((object)splineComputer != null)
							{
								GameObject gameObject = splineComputer.gameObject;
								if ((object)gameObject != null)
								{
									((UnityEngine.Object)gameObject).SetName("Heat Curve");
									Transform parent2 = splineComputer.transform;
									gameObject2 = UnityEngine.Object.Instantiate(_TrailPrefab, parent2);
									if ((object)gameObject2 != null)
									{
										UISplineFollower component = gameObject2.GetComponent<UISplineFollower>();
										if ((object)component != null)
										{
											component.SetSpline(splineComputer);
											Transform transform2 = gameObject2.transform;
											transform3 = base.transform;
											if ((object)transform3 != null)
											{
												break;
											}
										}
									}
								}
							}
						}
					}
				}
				goto IL_0420;
				IL_0420:
				throw new NullReferenceException();
			}
			Vector3 position2 = transform3.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v29 (UnityEngine.Transform)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rax_v29 (UnityEngine.Transform)+10]");
			Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
			TrailRenderer component2 = gameObject2.GetComponent<TrailRenderer>();
			float widthMultiplier = component2.widthMultiplier;
			float cameraRTScale = GetCameraRTScale();
			float widthMultiplier2 = cameraRTScale * widthMultiplier;
			component2.widthMultiplier = widthMultiplier2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F730");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			TrailRenderer component3 = gameObject2.GetComponent<TrailRenderer>();
			int sortingOrder = UnityEngine.Random.Range(100, 103);
			component3.sortingOrder = sortingOrder;
			((UnityEngine.Object)gameObject2).SetName("Heat Trail");
			vector++;
			flag4 = (nint)vector < 8;
			x = position.x;
		}
		while (flag4);
	}

	public unsafe void MakeRibbons3()
	{
		//IL_03d2: Expected O, but got F4
		//IL_0239: Expected O, but got Ref
		//IL_004f->IL028e: Incompatible stack heights: 1 vs 0
		//IL_0086->IL028e: Incompatible stack heights: 1 vs 0
		//IL_00c0->IL028e: Incompatible stack heights: 2 vs 0
		//IL_00ea->IL028e: Incompatible stack heights: 2 vs 0
		//IL_012f->IL028e: Incompatible stack heights: 2 vs 0
		//IL_0342->IL028e: Incompatible stack heights: 3 vs 0
		//IL_039d->IL028e: Incompatible stack heights: 4 vs 0
		//IL_0469->IL028e: Incompatible stack heights: 7 vs 0
		//IL_0288->IL0511: Incompatible stack heights: 12 vs 0
		GenerateReelCurves();
		int num = 0;
		Vector3 ret = default(Vector3);
		Vector3 value = default(Vector3);
		object obj2 = default(object);
		while (true)
		{
			List<SplineComputer> spawnedReelCurves = _spawnedReelCurves;
			if (_spawnedReelCurves == null)
			{
				break;
			}
			bool flag = num >= spawnedReelCurves._size;
			SplineComputer[] items = spawnedReelCurves._items;
			if (spawnedReelCurves._items == null)
			{
				break;
			}
			SplineComputer splineComputer = items[num];
			if ((object)items[num] == null)
			{
				break;
			}
			bool flag2 = ((UnityEngine.Object)splineComputer).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)splineComputer).m_CachedPtr);
			GameObject gameObject = UnityEngine.Object.Instantiate(parent: UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr), original: _RibbonTrailPrefab);
			if ((object)gameObject == null)
			{
				break;
			}
			UISplineFollower component = gameObject.GetComponent<UISplineFollower>();
			if ((object)component == null)
			{
				break;
			}
			component.SetSpline(items[num]);
			TrailRenderer component2 = gameObject.GetComponent<TrailRenderer>();
			if ((object)component2 == null)
			{
				break;
			}
			bool flag3 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
			Renderer.set_enabled_Injected(((UnityEngine.Object)component2).m_CachedPtr, false);
			TrailRenderer component3 = gameObject.GetComponent<TrailRenderer>();
			if ((object)component3 == null)
			{
				break;
			}
			bool flag4 = ((UnityEngine.Object)component3).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)component3).m_CachedPtr, 103);
			TrailRenderer component4 = gameObject.GetComponent<TrailRenderer>();
			if ((object)component4 == null)
			{
				break;
			}
			bool flag5 = ((UnityEngine.Object)component4).m_CachedPtr == (IntPtr)0;
			object obj = TrailRenderer.get_widthMultiplier_Injected(((UnityEngine.Object)component4).m_CachedPtr);
			float cameraRTScale = GetCameraRTScale();
			float num2 = cameraRTScale * (float)ret;
			bool flag6 = ((UnityEngine.Object)component4).m_CachedPtr == (IntPtr)0;
			TrailRenderer.set_widthMultiplier_Injected(((UnityEngine.Object)component4).m_CachedPtr, 0f);
			bool flag7 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			Transform reels3StartPosition = _Reels3StartPosition;
			if ((object)_Reels3StartPosition == null)
			{
				break;
			}
			bool flag8 = ((UnityEngine.Object)reels3StartPosition).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)reels3StartPosition).m_CachedPtr, out ret);
			bool flag9 = (object)transform == null;
			bool flag10 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			List<object> reelTrails = (List<object>)(object)_reelTrails3;
			bool flag11 = _reelTrails3 == null;
			int version = reelTrails._version + 1;
			reelTrails._version = version;
			object[] items2 = reelTrails._items;
			bool flag12 = reelTrails._items == null;
			if (reelTrails._size >= items2.Length)
			{
				((List<object>)(object)_reelTrails3).AddWithResize((object)gameObject);
			}
			else
			{
				int size = reelTrails._size + 1;
				reelTrails._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			string text = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj2), null);
			string text2 = "Level 3 Reel Follower " + text;
			((UnityEngine.Object)gameObject).SetName(text2);
			num++;
			if (num >= 2)
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GenerateReelCurves()
	{
		//IL_0076: Expected O, but got I4
		//IL_01eb: Expected O, but got Ref
		List<SplineComputer> spawnedReelCurves = _spawnedReelCurves;
		if (spawnedReelCurves._size > 0)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
		List<Vector2>.Enumerator enumerator2 = default(List<Vector2>.Enumerator);
		object obj2 = default(object);
		SplineComputer splineComputer = default(SplineComputer);
		List<Vector2>.Enumerator enumerator3 = default(List<Vector2>.Enumerator);
		bool flipX = default(bool);
		bool flipY = default(bool);
		while (num2 < 2)
		{
			List<Vector2> list = new List<Vector2>();
			object obj = 0;
			List<Vector2>.Enumerator ribbon3Points = (List<Vector2>.Enumerator)_Ribbon3Points;
			while (enumerator.MoveNext())
			{
				if (list != null)
				{
					list.Add((Vector2)enumerator2);
					obj = obj2;
					ribbon3Points = enumerator2;
					continue;
				}
				throw new NullReferenceException();
			}
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Transform parent = base.transform;
			if ((nint)transform >= 0)
			{
				splineComputer = SplineManager.Create((Vector3)(&enumerator3), list, parent, _Scale, flipX, flipY);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F730");
			GameObject gameObject = splineComputer.gameObject;
			string text = num.ToString();
			string text2 = "Level 3 Ribbon Curve " + text;
			((UnityEngine.Object)gameObject).SetName(text2);
			num2++;
			num = num2;
		}
	}

	public void ClearExisting()
	{
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		if (enumerator.MoveNext())
		{
			throw new NullReferenceException();
		}
		List<GameObject> reelTrails = _reelTrails3;
		int version = reelTrails._version + 1;
		reelTrails._version = version;
		reelTrails._size = 0;
		if (reelTrails._size > 0)
		{
			Array.Clear(reelTrails._items, 0, reelTrails._size);
		}
		List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
		if (enumerator2.MoveNext())
		{
			GameObject gameObject = null;
			throw new NullReferenceException();
		}
	}

	public void Play(float duration, float delay, int playCount, int howMany)
	{
		//IL_000e: Expected O, but got I4
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_0065->IL0179: Incompatible stack heights: 1 vs 0
		//IL_008b->IL0179: Incompatible stack heights: 1 vs 0
		//IL_00be->IL0179: Incompatible stack heights: 1 vs 0
		//IL_01f5->IL0179: Incompatible stack heights: 2 vs 0
		//IL_0174->IL0385: Incompatible stack heights: 11 vs 0
		//IL_0179->IL03ae: Incompatible stack heights: 11 vs 0
		object obj = default(object);
		if ((nint)obj <= 0)
		{
			return;
		}
		object obj2 = 0;
		float num = delay;
		Vector3 value = default(Vector3);
		Vector3 value2 = default(Vector3);
		float duration2 = default(float);
		int loopCount = default(int);
		Ease ease = default(Ease);
		while (true)
		{
			List<GameObject> trails = _trails;
			if (_trails == null)
			{
				break;
			}
			bool flag = (nint)obj2 >= trails._size;
			GameObject[] items = trails._items;
			if (trails._items == null || (object)items[obj2] == null)
			{
				break;
			}
			UISplineFollower component = items[obj2].GetComponent<UISplineFollower>();
			if ((object)component == null)
			{
				break;
			}
			bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)component).m_CachedPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			if ((object)transform == null)
			{
				break;
			}
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			IntPtr parent_Injected = Transform.GetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr);
			Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
			bool flag4 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ rax_v56 (UnityEngine.Transform)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ rax_v56 (UnityEngine.Transform)+10]");
			Transform.set_localPosition_Injected((IntPtr)0, ref value);
			bool flag6 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)component).m_CachedPtr);
			Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			bool flag7 = (object)transform3 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rax_v68 (UnityEngine.Transform)+10]");
			bool flag8 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rax_v68 (UnityEngine.Transform)+10]");
			IntPtr parent_Injected2 = Transform.GetParent_Injected((IntPtr)0);
			Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected2);
			bool flag9 = (object)transform4 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1178 @ rax_v73 (UnityEngine.Transform)+10]");
			bool flag10 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1178 @ rax_v73 (UnityEngine.Transform)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref value2);
			GameObject gameObject = component.gameObject;
			bool flag11 = (object)gameObject == null;
			gameObject.SetActive(value: true);
			num = (float)obj2 * delay;
			IEnumerator routine = component.BeginPlaying(duration2, num, true, loopCount, ease);
			Coroutine coroutine = component.StartCoroutine(routine);
			obj2++;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void PlayReelTrails(float duration, float delay, int playCount)
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_061d: Expected O, but got F4
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_0099->IL02bf: Incompatible stack heights: 1 vs 0
		//IL_00bf->IL02bf: Incompatible stack heights: 1 vs 0
		//IL_00f2->IL02bf: Incompatible stack heights: 1 vs 0
		//IL_0344->IL02bf: Incompatible stack heights: 2 vs 0
		//IL_02ac->IL02bf: Incompatible stack heights: 22 vs 0
		//IL_02be->IL065b: Incompatible stack heights: 22 vs 0
		List<GameObject> reelTrails = _reelTrails3;
		if (_reelTrails3 != null)
		{
			object obj = 0;
			object obj2 = 0;
			Vector3 value = default(Vector3);
			Vector3 value2 = default(Vector3);
			float value3 = default(float);
			float num = default(float);
			float num2 = default(float);
			int loopCount = default(int);
			Ease ease = default(Ease);
			while (true)
			{
				if ((nint)obj2 < reelTrails._size)
				{
					List<GameObject> reelTrails2 = _reelTrails3;
					if (_reelTrails3 == null)
					{
						break;
					}
					bool flag = (nint)obj >= reelTrails2._size;
					GameObject[] items = reelTrails2._items;
					if (reelTrails2._items == null || (object)items[obj] == null)
					{
						break;
					}
					UISplineFollower component = items[obj].GetComponent<UISplineFollower>();
					if ((object)component == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)component).m_CachedPtr);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform == null)
					{
						break;
					}
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					IntPtr parent_Injected = Transform.GetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr);
					Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
					bool flag4 = (object)transform2 == null;
					bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					bool flag6 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)component).m_CachedPtr);
					Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
					bool flag7 = (object)transform3 == null;
					bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					IntPtr parent_Injected2 = Transform.GetParent_Injected(((UnityEngine.Object)transform3).m_CachedPtr);
					Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected2);
					bool flag9 = (object)transform4 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1598 @ rax_v101 (UnityEngine.Transform)+10]");
					bool flag10 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1598 @ rax_v101 (UnityEngine.Transform)+10]");
					Transform.set_localScale_Injected((IntPtr)0, ref value2);
					bool flag11 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)component).m_CachedPtr);
					Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
					object reels3StartPosition = _Reels3StartPosition;
					bool flag12 = (object)_Reels3StartPosition == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1263 @ rbx_v38 (System.Object)+10]");
					bool flag13 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1263 @ rbx_v38 (System.Object)+10]");
					float ret;
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
					bool flag14 = (object)transform5 == null;
					bool flag15 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)(&value3));
					GameObject gameObject = component.gameObject;
					bool flag16 = (object)gameObject == null;
					gameObject.SetActive(value: true);
					IEnumerator routine = component.BeginPlaying(num, num2, false, loopCount, ease);
					Coroutine coroutine = component.StartCoroutine(routine);
					TrailRenderer component2 = component.GetComponent<TrailRenderer>();
					bool flag17 = (object)component2 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2189 @ rax_v128 (UnityEngine.TrailRenderer)+10]");
					bool flag18 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2189 @ rax_v128 (UnityEngine.TrailRenderer)+10]");
					Renderer.set_enabled_Injected((IntPtr)0, true);
					UISplineSpawner component3 = component.GetComponent<UISplineSpawner>();
					bool flag19 = (object)component3 == null;
					component3._container = ReelsIconsContainer;
					UISplineSpawner component4 = component.GetComponent<UISplineSpawner>();
					TrailRenderer component5 = component.GetComponent<TrailRenderer>();
					bool flag20 = (object)component5 == null;
					bool flag21 = ((UnityEngine.Object)component5).m_CachedPtr == (IntPtr)0;
					object obj3 = TrailRenderer.get_time_Injected(((UnityEngine.Object)component5).m_CachedPtr);
					bool flag22 = (object)component4 == null;
					component4._spline = component.Spline;
					component4._duration = ret;
					component4._speed = num;
					component4._delay = num2;
					component4._interval = 0.03f;
					UISplineSpawner._003CDoSpawning_003Ed__12 obj4 = null;
					obj4._003C_003E1__state = 0;
					obj4._003C_003E4__this = component4;
					Coroutine coroutine2 = component4.StartCoroutine(obj4);
					reelTrails = _reelTrails3;
					obj++;
					if (_reelTrails3 == null)
					{
						break;
					}
					obj2 = obj;
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void SetTexture()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		List<GameObject> reelTrails = _reelTrails;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < reelTrails._size)
		{
			obj2++;
			obj = obj2;
		}
	}

	private void OnDisable()
	{
		ClearExisting();
	}

	public unsafe Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
	{
		//IL_0188: Expected native int or pointer, but got O
		//IL_0195: Expected native int or pointer, but got O
		float euler = default(float);
		Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out Quaternion ret);
		float num = point.x - pivot.x;
		float num2 = point.z - pivot.z;
		float num4 = default(float);
		float num3 = point.y - num4;
		float num5 = (float)ret * 2f;
		object obj = default(object);
		float num6 = (float)obj * 2f;
		object obj2 = default(object);
		float num7 = (float)obj2 * 2f;
		float num8 = (float)ret * num6;
		float num9 = (float)obj2 * num7;
		object obj3 = default(object);
		float num10 = (float)obj3 * num5;
		float num11 = (float)obj2 * num6;
		float num12 = (float)ret * num5;
		float num13 = (float)obj3 * num7;
		float num14 = num9 + num12;
		float num15 = 1f - num14;
		float num16 = num15 * num2;
		float num17 = num8 - num13;
		float num18 = num10 + num11;
		float num19 = num17 * num;
		float num20 = num18 * num3;
		float num21 = num19 + num20;
		float num22 = num21 + num16;
		float z = num22 + pivot.z;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = num4;
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	public Vector2 RotateVectorByDegrees(Vector2 vec2, float degrees)
	{
		float num = degrees * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm10\"");
		double num2 = Math.Cos(0.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm9,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Vector2 result = default(Vector2);
		return result;
	}

	public TreasureRibbonTrailGenerator()
	{
		List<Vector2> points = new List<Vector2>();
		_Points = points;
		List<Vector2> ribbon3Points = new List<Vector2>();
		_Ribbon3Points = ribbon3Points;
		List<SplineComputer> spawnedCurves = new List<SplineComputer>();
		_spawnedCurves = spawnedCurves;
		List<GameObject> trails = new List<GameObject>();
		_trails = trails;
		List<SplineComputer> spawnedReelCurves = new List<SplineComputer>();
		_spawnedReelCurves = spawnedReelCurves;
		List<GameObject> reelTrails = new List<GameObject>();
		_reelTrails = reelTrails;
		List<GameObject> reelTrails2 = new List<GameObject>();
		_reelTrails3 = reelTrails2;
	}
}
