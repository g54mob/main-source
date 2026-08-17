using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class TentacleUI : MonoBehaviour
{
	public float maxAngle = 30f;

	public float speed = 1f;

	public GameObject TentaclePrefab;

	public RectTransform Anchor;

	public int Tentaclindex;

	public RectTransform Ring;

	public List<GameObject> Decorations;

	private float _currentTime;

	private GameObject _tentaclette;

	private Vector3 _startRotation;

	private bool isRoot;

	private int depth;

	private List<Tween> _tweens;

	private void Awake()
	{
		ArcanaMainSelectionPage.OnArcanaModeChange value = Toggle;
		ArcanaMainSelectionPage.ArcanaModeChanged += value;
	}

	private void OnDestroy()
	{
		ArcanaMainSelectionPage.OnArcanaModeChange value = Toggle;
		ArcanaMainSelectionPage.ArcanaModeChanged -= value;
		List<Tween>.Enumerator enumerator = default(List<Tween>.Enumerator);
		while (enumerator.MoveNext())
		{
			TweenExtensions.Kill(null);
		}
	}

	private void Start()
	{
		//IL_012a: Expected O, but got I4
		//IL_0034->IL00e3: Incompatible stack heights: 1 vs 0
		//IL_0097->IL00e3: Incompatible stack heights: 2 vs 0
		//IL_00d4->IL00e3: Incompatible stack heights: 2 vs 0
		List<GameObject> decorations = Decorations;
		if (Decorations != null)
		{
			object obj = UnityEngine.Random.RandomRangeInt(0, decorations._size);
			bool flag = (nint)obj >= decorations._size;
			GameObject[] items = decorations._items;
			if (decorations._items != null)
			{
				bool flag2 = (nint)obj >= items.Length;
				GameObject gameObject = UnityEngine.Object.Instantiate(parent: base.transform, original: items[obj]);
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: true);
					Transform transform = gameObject.transform;
					if ((object)transform != null)
					{
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 110 ConditionalJump @-1, v237 @ TEMP_v10 (System.Boolean) --- -1 Nop");
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 86 ConditionalJump @-1, v82 @ TEMP_v9 (System.Boolean) --- -1 Nop");
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 193 ConditionalJump @-1, v362 @ ZF_v18 (System.Boolean) --- -1 Nop");
						/*Error: End of method reached without returning.*/;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Toggle(ArcanaMainSelectionPage.ArcanaMode mode)
	{
		//IL_00d6: Expected O, but got I
		//IL_0056: Expected O, but got I
		//IL_0172: Expected F4, but got I4
		//IL_0137: Expected O, but got I8
		//IL_00b7: Expected O, but got I8
		if (!isRoot)
		{
			return;
		}
		float duration;
		float endValue;
		Transform target;
		if (mode != ArcanaMainSelectionPage.ArcanaMode.DARK)
		{
			Transform transform = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				TentacleUI tentacleUI = (TentacleUI)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v120 @ rax_v13 (should have been resolved before IL gen)");
			duration = 0.25f;
			endValue = 0f;
			target = transform;
		}
		else
		{
			Transform transform2 = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj2 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
				TentacleUI tentacleUI = (TentacleUI)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v148 @ rax_v8 (should have been resolved before IL gen)");
			duration = 0.25f;
			endValue = 4f;
			target = transform2;
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, endValue, duration);
	}

	private void Hide()
	{
		//IL_001a: Expected O, but got I
		Transform target = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v47 @ rax_v3 (should have been resolved before IL gen)");
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 0f, 0.25f);
	}

	public void InstantHide()
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void Show()
	{
		//IL_001a: Expected O, but got I
		Transform target = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v47 @ rax_v3 (should have been resolved before IL gen)");
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 4f, 0.25f);
	}

	public void Initialize()
	{
		//IL_0039: Expected O, but got I
		//IL_0048: Expected O, but got F4
		//IL_011b: Expected O, but got I
		//IL_00be: Expected F4, but got I8
		//IL_00fc: Expected F4, but got I8
		Transform transform = base.transform;
		Vector3 localEulerAngles = transform.localEulerAngles;
		float z = localEulerAngles.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		_startRotation = (Vector3)localEulerAngles.x;
		_ = localEulerAngles.z;
		isRoot = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			z = 6.573111E+09f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v65 @ rax_v11 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		maxAngle = 5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			z = 6.573111E+09f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v123 @ rax_v14 (should have been resolved before IL gen)");
		speed = 0.3f;
		depth = 1;
	}

	private unsafe void Update()
	{
		//IL_0056: Expected O, but got F4
		//IL_00c2: Expected O, but got F4
		//IL_0099: Expected O, but got F4
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00ef: Expected O, but got Ref
		object obj = Time.deltaTime;
		object obj2 = default(object);
		float num = (_currentTime = (float)obj2 + _currentTime);
		object obj5;
		object obj6 = default(object);
		Transform transform2;
		if (isRoot)
		{
			Transform transform = base.transform;
			object obj3 = Time.timeSinceLevelLoad;
			object obj4 = _startRotation * speed;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			obj5 = obj6;
			transform2 = transform;
		}
		else
		{
			Transform transform3 = base.transform;
			object obj7 = Time.timeSinceLevelLoad;
			float num2 = num * speed;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			obj5 = obj6;
			transform2 = transform3;
		}
		transform2.localEulerAngles = (Vector3)(&obj5);
	}

	public unsafe TentacleUI AddSegment()
	{
		//IL_0087: Expected O, but got Ref
		//IL_016c: Expected O, but got I
		//IL_0239->IL01b1: Incompatible stack heights: 3 vs 0
		//IL_00a1->IL01b1: Incompatible stack heights: 3 vs 0
		GameObject tentaclette = UnityEngine.Object.Instantiate(TentaclePrefab, Anchor);
		_tentaclette = tentaclette;
		if ((object)_tentaclette != null)
		{
			Transform transform = _tentaclette.transform;
			bool flag = (object)transform == null;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			bool flag3 = (object)_tentaclette == null;
			Transform transform2 = _tentaclette.transform;
			if ((object)transform2 != null)
			{
				Vector3 value2 = default(Vector3);
				transform2.localEulerAngles = (Vector3)(&value2);
				if ((object)_tentaclette != null)
				{
					Transform transform3 = _tentaclette.transform;
					bool flag4 = (object)transform3 == null;
					bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
					bool flag6 = (object)_tentaclette == null;
					TentacleUI component = _tentaclette.GetComponent<TentacleUI>();
					bool flag7 = (object)component == null;
					float num = (float)(component.depth = depth + 1) * 0.05f;
					float maxInclusive = num + 1f;
					float minInclusive = num + 0.3f;
					float num2 = UnityEngine.Random.Range(minInclusive, maxInclusive);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v45 (VampireSurvivors.TentacleUI)+70]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v45 (VampireSurvivors.TentacleUI)+70]");
					object obj = num3 + 0;
					float num4 = (float)obj + maxAngle;
					Transform anchor = Anchor;
					bool flag8 = (object)Anchor == null;
					bool flag9 = ((UnityEngine.Object)anchor).m_CachedPtr == (IntPtr)0;
					Transform.SetAsLastSibling_Injected(((UnityEngine.Object)anchor).m_CachedPtr);
					return component;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetStats(float _speed, float _maxAngle, int _depth)
	{
		//IL_001a: Expected I4, but got F4
		//IL_0076: Expected O, but got I4
		float num = (float)_depth + 1f;
		depth = (int)num;
		float num2 = num * 0.05f;
		float maxInclusive = num2 + 1f;
		float minInclusive = num2 + 0.3f;
		float num3 = UnityEngine.Random.Range(minInclusive, maxInclusive);
		speed = num3;
		object obj = depth + depth;
		float num4 = (float)obj + _maxAngle;
		maxAngle = num4;
	}

	public TentacleUI()
	{
		List<GameObject> decorations = new List<GameObject>();
		Decorations = decorations;
		List<Tween> tweens = new List<Tween>();
		_tweens = tweens;
	}
}
