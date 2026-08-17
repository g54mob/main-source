using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class StealWeaponWui : MonoBehaviour
{
	public RawImage icon;

	private Transform target;

	private Vector3 targetOffset;

	private float scale;

	private bool useScaleDown;

	private int phase;

	private float timer;

	private float moveUpTimer;

	private float moveUpTime;

	private float floatAbovePlayerHeadTime = 1f;

	private float moveTime = 1f;

	public unsafe void Set(UnlockableBase unlockable, Transform target, Vector3 targetOffset, float hoverTime, float moveTime, float scale, bool useScaleDown = false)
	{
		//IL_0044: Expected O, but got F4
		//IL_0090: Expected O, but got Ref
		//IL_00b1: Expected O, but got Ref
		Texture texture = unlockable.GetIcon();
		icon.texture = texture;
		this.target = target;
		this.targetOffset = (Vector3)targetOffset.x;
		_ = targetOffset.z;
		Transform transform = base.transform;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position = transform2.position;
		float num = default(float);
		transform.position = (Vector3)(&num);
		Transform transform3 = base.transform;
		transform3.localScale = (Vector3)(&num);
		bool flag = default(bool);
		this.useScaleDown = flag;
		timer = 0f;
		float num2 = default(float);
		this.scale = num2;
		float num3 = default(float);
		floatAbovePlayerHeadTime = num3;
		bool flag2 = !(0.75f > num3);
		float num4 = 0.75f;
		if (!flag2)
		{
			num4 = num3;
		}
		moveUpTime = num4;
	}

	private unsafe void Update()
	{
		//IL_0008: Expected O, but got Ref
		//IL_06e1: Expected I, but got O
		//IL_075d: Invalid comparison between I4 and F4
		//IL_02ac: Expected F4, but got I4
		//IL_0449: Invalid comparison between I4 and F4
		//IL_02c4: Expected O, but got Ref
		//IL_006b: Expected F4, but got I4
		//IL_0847: Invalid comparison between I4 and F4
		//IL_0317: Expected F4, but got I4
		//IL_0891: Invalid comparison between I4 and F4
		//IL_0353: Expected F4, but got I4
		//IL_0491: Expected I, but got O
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0107: Invalid comparison between I4 and F4
		//IL_015c: Expected F4, but got I4
		//IL_08d9: Expected I, but got O
		//IL_0174: Expected O, but got Ref
		//IL_039e: Expected O, but got Ref
		//IL_05c9: Expected I, but got O
		//IL_0631: Expected I, but got O
		//IL_09bd: Invalid comparison between I4 and F4
		//IL_01de: Expected F4, but got I4
		//IL_01f6: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (phase != 0)
		{
			if (phase != 1)
			{
				return;
			}
			float num = MyTime.deltaTime / moveTime;
			float num2 = num + timer;
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
			timer = num2;
			float num3 = Easing.InOutQuad(num2);
			Transform transform = base.transform;
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position = transform2.position;
			MyPlayer instance = MyPlayer.Instance;
			nint num4 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v35 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num5 = 0;
			float num6 = instance.height * (float)Vector3.upVector;
			float num7 = num6 + position.x;
			float num8 = instance.height;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rcx_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num9 = num8 * 0f;
			float num10 = instance.height;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rcx_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num11 = num10 * 0f;
			float num12 = num9 + position.y;
			float num13 = num11 + position.z;
			Vector3 position2 = target.position;
			float num14 = position2.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StealWeaponWui)+34]");
			float num15 = num14 + 0f;
			float num16 = position2.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (StealWeaponWui)+38]");
			float num17 = num16 + 0f;
			object obj3 = targetOffset + position2.x;
			float num18 = ((0f > num3) ? 0f : ((num3 > 1f) ? 1f : num3));
			float num19 = (float)obj3 - num7;
			float num20 = num15 - num12;
			float num21 = num17 - num13;
			float num22 = num19 * num18;
			float num23 = num20 * num18;
			float num24 = num21 * num18;
			float num25 = num22 + num7;
			float num26 = num23 + num12;
			float num27 = num24 + num13;
			Vector3 position3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			transform.position = position3;
			Transform transform3 = base.transform;
			nint num28 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ rax_v40 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num29 = 0;
			_ = Vector3.oneVector;
			float num30 = (float)Vector3.oneVector * scale;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
			float num31 = 0f * scale;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ rcx_v43 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num32 = 0f * scale;
			nint num33 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v822 @ rax_v41 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num34 = 0;
			float num35;
			if (!(0f > num3))
			{
				bool flag = !(num3 > 1f);
				num35 = num3;
				if (!flag)
				{
					num35 = 1f;
				}
			}
			else
			{
				num35 = 0f;
			}
			float num36 = (float)Vector3.zeroVector - num30;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v42 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
			float num37 = 0f - num31;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v42 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			float num38 = 0f - num32;
			float num39 = num36 * num35;
			float num40 = num37 * num35;
			float num41 = num38 * num35;
			float num42 = num39 + num30;
			float num43 = num40 + num31;
			float num44 = num41 + num32;
			Vector3 localScale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			transform3.localScale = localScale;
			if (!(timer < 1f))
			{
				GameObject obj4 = base.gameObject;
				Object.Destroy(obj4);
			}
			return;
		}
		Transform transform4 = base.transform;
		Transform transform5 = base.transform;
		Vector3 localScale2 = transform5.localScale;
		nint num45 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v8 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num46 = 0;
		_ = Vector3.oneVector;
		float num47 = (float)Vector3.oneVector * scale;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
		float num48 = 0f * scale;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num49 = 0f * scale;
		float deltaTime = Time.deltaTime;
		float num50 = deltaTime * 4f;
		if (!(0f > num50))
		{
			if (num50 > 1f)
			{
				num50 = 1f;
			}
		}
		else
		{
			num50 = 0f;
		}
		float num51 = num47 - localScale2.x;
		float num52 = num48 - localScale2.y;
		float num53 = num49 - localScale2.z;
		float num54 = num51 * num50;
		float num55 = num52 * num50;
		float num56 = num53 * num50;
		float num57 = num54 + localScale2.x;
		float num58 = num55 + localScale2.y;
		float num59 = num56 + localScale2.z;
		Vector3 localScale3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		transform4.localScale = localScale3;
		float num60 = MyTime.deltaTime / floatAbovePlayerHeadTime;
		float num61 = num60 + timer;
		if (!(0f > num61))
		{
			if (num61 > 1f)
			{
				num61 = 1f;
			}
		}
		else
		{
			num61 = 0f;
		}
		timer = num61;
		float num62 = MyTime.deltaTime / moveUpTime;
		float num63 = num62 + moveUpTimer;
		if (!(0f > num63))
		{
			if (num63 > 1f)
			{
				num63 = 1f;
			}
		}
		else
		{
			num63 = 0f;
		}
		moveUpTimer = num63;
		float num64 = Easing.InOutCirc(num63);
		Transform transform6 = base.transform;
		Transform transform7 = MyPlayer.Instance.transform;
		Vector3 position4 = transform7.position;
		MyPlayer instance2 = MyPlayer.Instance;
		nint num65 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rax_v19 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num66 = 0;
		float num67 = instance2.height * (float)Vector3.upVector;
		float num68 = instance2.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rcx_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
		float num69 = num68 * 0f;
		float num70 = instance2.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rcx_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num71 = num70 * 0f;
		float num72 = num67 * num64;
		float num73 = num69 * num64;
		float num74 = num71 * num64;
		float num75 = num72 + position4.x;
		float num76 = num73 + position4.y;
		float num77 = num74 + position4.z;
		Vector3 position5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		transform6.position = position5;
		if (!(timer < 1f))
		{
			int num78 = phase + 1;
			phase = num78;
			timer = 0f;
		}
	}
}
