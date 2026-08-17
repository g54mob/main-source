using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace RetroArsenal;

public class RetroFireBeam : MonoBehaviour
{
	public GameObject[] beamLineRendererPrefab;

	public GameObject[] beamStartPrefab;

	public GameObject[] beamEndPrefab;

	private BeamType currentBeam;

	private GameObject beamStart;

	private GameObject beamEnd;

	private GameObject beam;

	private LineRenderer line;

	private Transform beamTransform;

	private float textureScrollOffset;

	public float beamEndOffset = 1f;

	public float textureScrollSpeed = 8f;

	public float textureLengthScale = 3f;

	public Slider endOffsetSlider;

	public Slider scrollSpeedSlider;

	public Text textBeamName;

	private bool isFiringBeam;

	private void Start()
	{
		GameObject gameObject = base.gameObject;
		Transform transform = gameObject.transform;
		beamTransform = transform;
		if ((bool)textBeamName)
		{
			GameObject[] array = beamLineRendererPrefab;
			BeamType beamType = currentBeam;
			string text = array[(int)beamType].name;
			textBeamName.text = text;
		}
		if ((bool)endOffsetSlider)
		{
			endOffsetSlider.value = beamEndOffset;
		}
		if ((bool)scrollSpeedSlider)
		{
			scrollSpeedSlider.value = textureScrollSpeed;
		}
		CreateBeamObjects();
	}

	private void CreateBeamObjects()
	{
		GameObject[] array = beamStartPrefab;
		BeamType beamType = currentBeam;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180758BC0");
		GameObject gameObject = default(GameObject);
		beamStart = gameObject;
		GameObject[] array2 = beamEndPrefab;
		BeamType beamType2 = currentBeam;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180758BC0");
		GameObject gameObject2 = default(GameObject);
		beamEnd = gameObject2;
		GameObject[] array3 = beamLineRendererPrefab;
		BeamType beamType3 = currentBeam;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180758BC0");
		GameObject gameObject3 = default(GameObject);
		beam = gameObject3;
		LineRenderer component = beam.GetComponent<LineRenderer>();
		line = component;
		beamStart.SetActive(value: false);
		beamEnd.SetActive(value: false);
		beam.SetActive(value: false);
	}

	private void Update()
	{
	}

	private void UpdateBeam()
	{
		if ((bool)textBeamName)
		{
			GameObject[] array = beamLineRendererPrefab;
			BeamType beamType = currentBeam;
			string text = array[(int)beamType].name;
			textBeamName.text = text;
		}
		UnityEngine.Object.Destroy(beamStart);
		UnityEngine.Object.Destroy(beamEnd);
		UnityEngine.Object.Destroy(beam);
		CreateBeamObjects();
	}

	private unsafe void ShootBeamInDir(Vector3 start, Vector3 dir)
	{
		//IL_0008: Expected O, but got Ref
		//IL_001b: Expected O, but got Ref
		//IL_006a: Expected O, but got Ref
		//IL_00ac: Expected O, but got Ref
		//IL_00c4: Expected O, but got Ref
		//IL_01a2: Expected O, but got Ref
		//IL_01ba: Expected O, but got Ref
		//IL_0275: Expected O, but got Ref
		//IL_02a4: Expected O, but got Ref
		//IL_030f: Expected O, but got Ref
		//IL_037d: Expected O, but got Ref
		//IL_04b2: Expected O, but got I4
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Expected O, but got Unknown
		//IL_054d: Invalid comparison between I4 and F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = start.x;
		_ = start.z;
		line.SetPosition(0, position);
		Transform transform = beamStart.transform;
		Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = start.z;
		_ = start.x;
		transform.position = position2;
		ref RaycastHit hitInfo = ref System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = dir.x;
		Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = dir.z;
		_ = start.x;
		_ = start.z;
		float num3;
		float num5;
		float num6;
		if (!Physics.Raycast(origin, direction, out hitInfo))
		{
			Vector3 position3 = beamTransform.position;
			float num = dir.x * 100f;
			float num2 = dir.y * 100f;
			num3 = num + position3.x;
			float num4 = dir.z * 100f;
			num5 = num2 + position3.y;
			num6 = num4 + position3.z;
		}
		else
		{
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			object obj5 = default(object);
			float num7 = beamEndOffset * (float)obj5;
			float num8 = beamEndOffset;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rax_v36+4]");
			float num9 = num8 * 0f;
			float num10 = beamEndOffset;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rax_v36+8]");
			float num11 = num10 * 0f;
			object obj6 = default(object);
			num3 = (float)obj6 - num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v35+4]");
			num5 = 0f - num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v35+8]");
			num6 = 0f - num11;
		}
		Transform transform2 = beamEnd.transform;
		Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		transform2.position = position4;
		Vector3 position5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		line.SetPosition(1, position5);
		Transform transform3 = beamStart.transform;
		Transform transform4 = beamEnd.transform;
		Vector3 position6 = transform4.position;
		Vector3 worldPosition = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = position6.x;
		_ = position6.z;
		transform3.LookAt(worldPosition);
		Transform transform5 = beamEnd.transform;
		Transform transform6 = beamStart.transform;
		Vector3 position7 = transform6.position;
		Vector3 worldPosition2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = position7.x;
		_ = position7.z;
		transform5.LookAt(worldPosition2);
		object obj7 = (object)line ^ (object)line;
		object obj8 = (object)line & obj7;
		bool flag = (nint)obj8 < 0;
		bool flag2 = (nint)line < 0;
		bool flag3 = (object)line == null;
		float num12 = start.x - num3;
		float num13 = start.y - num5;
		float num14 = start.z - num6;
		Material sharedMaterial = ((Renderer)line).GetSharedMaterial();
		float num15 = num13 * num13;
		float num16 = num12 * num12;
		float num17 = num14 * num14;
		float num18 = num15 + num16;
		float num19 = num18 + num17;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		bool flag4 = flag2 == flag;
		object obj9 = !flag3;
		object obj10 = flag4 & obj9;
		if (obj10 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
		}
		else
		{
			double num20 = Math.Sqrt(num19);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		Vector2 vector = default(Vector2);
		sharedMaterial.mainTextureScale = vector;
		float deltaTime = Time.deltaTime;
		float num21 = deltaTime * textureScrollSpeed;
		float num22 = (textureScrollOffset -= num21);
		if (0f > num22)
		{
			float num23 = num22 + 1f;
			textureScrollOffset = num23;
		}
		Material sharedMaterial2 = ((Renderer)line).GetSharedMaterial();
		sharedMaterial2.mainTextureOffset = vector;
	}
}
