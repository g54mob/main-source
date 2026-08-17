using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Level;

public class BackgroundOffsetManager : GameMonoBehaviour
{
	private float _edgeOffset;

	private Camera _mainCamera;

	private Bounds _backgroundBounds;

	private Bounds _camBounds;

	private void Awake()
	{
		Camera main = Camera.main;
		_mainCamera = main;
	}

	private void Start()
	{
		CalculateBounds();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		CalculateBounds();
	}

	protected override void OnUpdate()
	{
		OffsetBackgroundTiles();
	}

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_001d: Expected O, but got I4
		object obj = Application.isPlaying;
		if (obj != null)
		{
			Color value = default(Color);
			Gizmos.set_color_Injected(ref value);
			Bounds center = default(Bounds);
			Bounds size = default(Bounds);
			Gizmos.DrawWireCube_Injected(ref *(Vector3*)(&center), ref *(Vector3*)(&size));
			Gizmos.set_color_Injected(ref value);
			Color value2 = default(Color);
			Gizmos.set_color_Injected(ref value2);
			Gizmos.DrawWireCube_Injected(ref *(Vector3*)(&size), ref *(Vector3*)(&center));
			Gizmos.set_color_Injected(ref value2);
		}
	}

	private unsafe void CalculateBounds()
	{
		//IL_0108: Expected O, but got I4
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0019: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_00c5: Expected O, but got Ref
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_008a: Expected O, but got F4
		//IL_0085: Expected native int or pointer, but got O
		//IL_009d: Expected O, but got I4
		SpriteRenderer[] componentsInChildren = GetComponentsInChildren<SpriteRenderer>();
		_backgroundBounds = (Bounds)0;
		_ = 0;
		Bounds bounds = (Bounds)(this + 56);
		object obj = 0;
		object obj2 = 0;
		object obj3 = 0;
		Vector3 center = default(Vector3);
		while ((nint)obj3 < componentsInChildren.Length)
		{
			if (obj2 == null)
			{
				Transform transform = componentsInChildren[obj].transform;
				Vector3 position = transform.position;
				((Bounds*)(nint)bounds)->m_Center = (Vector3)position.x;
				_ = position.z;
				obj2 = 1;
			}
			Bounds bounds2 = componentsInChildren[obj].bounds;
			((Bounds*)bounds)->Encapsulate((Bounds)(&center));
			obj++;
			center = bounds2.m_Center;
			obj3 = obj;
		}
	}

	private void OffsetBackgroundTiles()
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Expected O, but got Unknown
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_054c: Expected O, but got Unknown
		_camBounds = (Bounds)CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v3 (UnityEngine.Bounds)+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+58]");
		_ = 0;
		_ = _camBounds;
		Bounds bounds = default(Bounds);
		_camBounds = bounds;
		_ = 0;
		float num = _edgeOffset * 0.5f;
		_ = _camBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+64]");
		float num2 = 0f + num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+5C]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+4C]");
		_ = 0;
		_ = _backgroundBounds;
		Bounds backgroundBounds = _backgroundBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+44]");
		object obj = backgroundBounds - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+44]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+64]");
		_ = 0;
		_ = _camBounds;
		Bounds camBounds = _camBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+5C]");
		object obj2 = camBounds - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+5C]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = obj & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = obj2 & 0;
		object obj5 = obj3 - obj4;
		object obj6 = default(object);
		if (0 > (nint)obj5)
		{
			Transform transform = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+44]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+4C]");
			_ = 0;
			_ = 0;
			Vector3 translation = (Vector3)(obj6 - 96);
			transform.Translate(translation, Space.Self);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+4C]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+44]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+44]");
		object obj7 = 0 + _backgroundBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+40]");
		_ = 0;
		_ = _backgroundBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+64]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+5C]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+5C]");
		object obj8 = 0 + _camBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+58]");
		_ = 0;
		_ = _camBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj9 = obj7 & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj10 = obj8 & 0;
		object obj11 = obj9 - obj10;
		if (0 > (nint)obj11)
		{
			Transform transform2 = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+44]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+4C]");
			_ = 0;
			Vector3 translation2 = (Vector3)(obj6 - 96);
			_ = 0;
			transform2.Translate(translation2, Space.Self);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+44]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+4C]");
		_ = 0;
		object obj12 = (object)bounds + (object)bounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+40]");
		_ = 0;
		_ = _backgroundBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+5C]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+64]");
		_ = 0;
		object obj13 = (object)bounds + (object)bounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+58]");
		_ = 0;
		_ = _camBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj14 = obj12 & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj15 = obj13 & 0;
		object obj16 = obj14 - obj15;
		if (0 > (nint)obj16)
		{
			Transform transform3 = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+4C]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+44]");
			_ = 0;
			Vector3 translation3 = (Vector3)(obj6 - 96);
			_ = 0;
			transform3.Translate(translation3, Space.Self);
		}
		_ = _backgroundBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+4C]");
		_ = 0;
		object obj17 = (object)bounds - (object)bounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+44]");
		_ = 0;
		_ = _camBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+64]");
		_ = 0;
		object obj18 = (object)bounds - (object)bounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+5C]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj19 = obj17 & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj20 = obj18 & 0;
		object obj21 = obj19 - obj20;
		if (0 > (nint)obj21)
		{
			Transform transform4 = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+4C]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Level.BackgroundOffsetManager)+44]");
			_ = 0;
			_ = 0;
			Vector3 translation4 = (Vector3)(obj6 - 96);
			transform4.Translate(translation4, Space.Self);
		}
	}

	public BackgroundOffsetManager()
	{
		//IL_002b: Expected I, but got O
		_edgeOffset = 1f;
		base._onResumeSent = true;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
