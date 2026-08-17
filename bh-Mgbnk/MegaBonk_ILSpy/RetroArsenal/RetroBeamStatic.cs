using System;
using Cpp2ILInjected;
using UnityEngine;

namespace RetroArsenal;

public class RetroBeamStatic : MonoBehaviour
{
	public GameObject beamLineRendererPrefab;

	public GameObject beamStartPrefab;

	public GameObject beamEndPrefab;

	private GameObject beamStart;

	private GameObject beamEnd;

	private GameObject beam;

	private LineRenderer line;

	public bool beamCollides = true;

	public float beamLength = 100f;

	public float beamEndOffset;

	public float textureScrollSpeed;

	public float textureLengthScale = 1f;

	public float widthMultiplier = 1.5f;

	private float customWidth;

	private float originalWidth;

	private float lerpValue;

	public float pulseSpeed = 1f;

	private bool pulseExpanding = true;

	private void Start()
	{
		SpawnBeam();
		float num = (originalWidth = line.startWidth) * widthMultiplier;
		customWidth = num;
	}

	private unsafe void FixedUpdate()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0045: Expected O, but got I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_09a0: Invalid comparison between I4 and F4
		//IL_082b: Invalid comparison between I4 and F4
		//IL_08ac: Expected F4, but got I4
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected Ref, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Expected O, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Expected O, but got Unknown
		//IL_090b: Expected I, but got O
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Expected O, but got Unknown
		//IL_031f: Expected F8, but got I4
		//IL_058f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Expected O, but got Unknown
		//IL_06e5: Expected O, but got I4
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		_ = 0;
		_ = 0;
		_ = 0;
		bool flag = beam;
		bool flag2 = !flag;
		Vector2 vector = (Vector2)0;
		float num4;
		float num5;
		float num6;
		float num17;
		float num3 = default(float);
		if (!flag2)
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Vector3 position2 = (Vector3)(obj - 121);
			_ = position.x;
			_ = position.z;
			line.SetPosition(0, position2);
			Transform transform2 = base.transform;
			Vector3 position3 = transform2.position;
			Transform transform3 = base.transform;
			Vector3 forward = transform3.forward;
			if (beamCollides)
			{
				Transform transform4 = base.transform;
				Vector3 position4 = transform4.position;
				Transform transform5 = base.transform;
				Vector3 forward2 = transform5.forward;
				_ = forward2.x;
				ref RaycastHit hitInfo = ref *(RaycastHit*)(obj - 89);
				_ = forward2.z;
				Vector3 direction = (Vector3)(obj - 121);
				_ = position4.x;
				Vector3 origin = (Vector3)(obj - 105);
				_ = position4.z;
				if (Physics.Raycast(origin, direction, out hitInfo))
				{
					object obj3 = obj - 89;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
					Transform transform6 = base.transform;
					Vector3 forward3 = transform6.forward;
					float num = beamEndOffset * forward3.x;
					float num2 = beamEndOffset * forward3.y;
					num3 = beamEndOffset * forward3.z;
					object obj4 = default(object);
					num4 = (float)obj4 - num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rax_v58+4]");
					num5 = 0f - num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rax_v58+8]");
					num6 = 0f - num3;
					Transform transform7 = base.transform;
					Vector3 position5 = transform7.position;
					nint num7 = (nint)typeof(Math);
					float num8 = position5.x - num4;
					float num9 = position5.y - num5;
					float num10 = position5.z - num6;
					float num11 = num9 * num9;
					float num12 = num8 * num8;
					float num13 = num10 * num10;
					float num14 = num11 + num12;
					float num15 = num14 + num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rcx_v58 (Il2CppClass<System.Math>)+E4]");
					double num16;
					if ((nint)0 <= (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
						num16 = 0.0;
					}
					else
					{
						num16 = Math.Sqrt(num15);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
					bool flag3 = !(num16 > (double)beamLength);
					num17 = num3;
					if (flag3)
					{
						goto IL_042c;
					}
				}
			}
			Transform transform8 = base.transform;
			Vector3 position6 = transform8.position;
			Transform transform9 = base.transform;
			Vector3 forward4 = transform9.forward;
			float num18 = beamLength * forward4.x;
			num4 = num18 + position6.x;
			float num19 = beamLength * forward4.y;
			float num20 = beamLength * forward4.z;
			num5 = num19 + position6.y;
			num6 = num20 + position6.z;
			num17 = num3;
			goto IL_042c;
		}
		goto IL_0798;
		IL_0798:
		float num22;
		if (!pulseExpanding)
		{
			float deltaTime = Time.deltaTime;
			float num21 = deltaTime * pulseSpeed;
			num22 = lerpValue - num21;
		}
		else
		{
			float deltaTime2 = Time.deltaTime;
			float num23 = deltaTime2 * pulseSpeed;
			float num24 = num23 + lerpValue;
			num22 = num24;
		}
		lerpValue = num22;
		if (num22 < 1f)
		{
			if (!(0f < num22))
			{
				pulseExpanding = true;
				lerpValue = 0f;
			}
		}
		else
		{
			pulseExpanding = false;
			lerpValue = 1f;
		}
		float num25 = lerpValue * (float)Math.PI;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
		if (!(0f > num25))
		{
			if (num25 > 1f)
			{
				num25 = 1f;
			}
		}
		else
		{
			num25 = 0f;
		}
		float num26 = customWidth - originalWidth;
		float num27 = num26 * num25;
		float num28 = num27 + originalWidth;
		line.startWidth = num28;
		line.endWidth = num28;
		return;
		IL_042c:
		Vector3 position7 = (Vector3)(obj - 121);
		line.SetPosition(1, position7);
		Transform transform10 = beamStart.transform;
		Transform transform11 = base.transform;
		Vector3 position8 = transform11.position;
		Vector3 position9 = (Vector3)(obj - 105);
		_ = position8.x;
		_ = position8.z;
		transform10.position = position9;
		Transform transform12 = beamStart.transform;
		Vector3 worldPosition = (Vector3)(obj - 121);
		transform12.LookAt(worldPosition);
		Transform transform13 = beamEnd.transform;
		Vector3 position10 = (Vector3)(obj - 121);
		transform13.position = position10;
		Transform transform14 = beamEnd.transform;
		Transform transform15 = beamStart.transform;
		Vector3 position11 = transform15.position;
		Vector3 worldPosition2 = (Vector3)(obj - 105);
		_ = position11.x;
		_ = position11.z;
		transform14.LookAt(worldPosition2);
		Transform transform16 = base.transform;
		Vector3 position12 = transform16.position;
		object obj5 = (object)line ^ (object)line;
		object obj6 = (object)line & obj5;
		bool flag4 = (nint)obj6 < 0;
		bool flag5 = (nint)line < 0;
		bool flag6 = (object)line == null;
		float num29 = position12.x - num4;
		float num30 = position12.y - num5;
		float num31 = position12.z - num6;
		Material material = ((Renderer)line).GetMaterial();
		float num32 = num30 * num30;
		float num33 = num29 * num29;
		float num34 = num31 * num31;
		float num35 = num32 + num33;
		float num36 = num35 + num34;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		bool flag7 = flag5 == flag4;
		object obj7 = !flag6;
		object obj8 = flag7 & obj7;
		if (obj8 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
		}
		else
		{
			double num37 = Math.Sqrt(num36);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		Vector2 vector2 = default(Vector2);
		material.mainTextureScale = vector2;
		Material material2 = ((Renderer)line).GetMaterial();
		Vector2 mainTextureOffset = material2.mainTextureOffset;
		float deltaTime3 = Time.deltaTime;
		material2.mainTextureOffset = vector2;
		num3 = num17;
		vector = vector2;
		goto IL_0798;
	}

	public unsafe void SpawnBeam()
	{
		//IL_00c0: Expected O, but got Ref
		//IL_0132: Expected O, but got Ref
		if (!beamLineRendererPrefab)
		{
			GameObject gameObject = base.gameObject;
			string text = gameObject.name;
			string text2 = "A prefab with a line renderer must be assigned to the `beamLineRendererPrefab` field in the RetroArsenalBeamStatic script on " + text;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return;
		}
		GameObject gameObject2 = UnityEngine.Object.Instantiate(beamLineRendererPrefab);
		beam = gameObject2;
		Transform transform = beam.transform;
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		object obj = default(object);
		transform.position = (Vector3)(&obj);
		Transform transform3 = beam.transform;
		Transform parent = base.transform;
		transform3.parent = parent;
		Transform transform4 = beam.transform;
		Transform transform5 = base.transform;
		Quaternion rotation = transform5.rotation;
		object obj2 = default(object);
		transform4.rotation = (Quaternion)(&obj2);
		LineRenderer component = beam.GetComponent<LineRenderer>();
		line = component;
		line.useWorldSpace = true;
		line.positionCount = 2;
		GameObject gameObject3;
		if ((bool)beamStartPrefab)
		{
			Transform parent2 = beam.transform;
			gameObject3 = UnityEngine.Object.Instantiate(beamStartPrefab, parent2);
		}
		else
		{
			gameObject3 = null;
		}
		beamStart = gameObject3;
		GameObject gameObject4;
		if ((bool)beamEndPrefab)
		{
			Transform parent3 = beam.transform;
			gameObject4 = UnityEngine.Object.Instantiate(beamEndPrefab, parent3);
		}
		else
		{
			gameObject4 = null;
		}
		beamEnd = gameObject4;
	}
}
