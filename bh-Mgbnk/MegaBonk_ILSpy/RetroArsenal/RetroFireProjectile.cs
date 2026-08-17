using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RetroArsenal;

public class RetroFireProjectile : MonoBehaviour
{
	private sealed class _003CShoot_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RetroFireProjectile _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CShoot_003Ed__17(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00b6: Expected I4, but got I8
			//IL_00f7: Expected I4, but got O
			RetroFireProjectile retroFireProjectile = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					retroFireProjectile.canShoot = (byte)_003C_003E1__state != 0;
					_003C_003E4__this.ShootProjectile();
					WaitForSeconds waitForSeconds = new WaitForSeconds(retroFireProjectile.fireRate);
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_00e9;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_00e9;
				}
				retroFireProjectile.canShoot = (byte)_003C_003E1__state != 0;
			}
			return false;
			IL_00e9:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
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

	public GameObject[] projectiles;

	public Text missileNameText;

	public Toggle fullAutoButton;

	public Slider speedSlider;

	public bool cleanUpMissileName;

	public Transform spawnPosition;

	public int currentProjectile;

	public float speed = 1000f;

	public float spawnOffset = 0.3f;

	public float fireRate = 0.13f;

	public bool isFullAuto = true;

	public GameObject gunPrefab;

	public float gunOffset = 0.5f;

	private bool canShoot = true;

	private GameObject instantiatedGun;

	private unsafe void Start()
	{
		//IL_0046: Expected O, but got Ref
		//IL_0046: Expected O, but got Ref
		//IL_0133: Expected F4, but got O
		//IL_00aa: Expected O, but got Ref
		if (gunPrefab != null)
		{
			Vector3 vector = default(Vector3);
			object obj = default(object);
			GameObject gameObject = UnityEngine.Object.Instantiate(gunPrefab, (Vector3)(&vector), (Quaternion)(&obj));
			instantiatedGun = gameObject;
			Transform transform = instantiatedGun.transform;
			Transform parentInternal = base.transform;
			transform.parentInternal = parentInternal;
			Transform transform2 = instantiatedGun.transform;
			transform2.localPosition = (Vector3)(&vector);
		}
		if (speedSlider != null)
		{
			Slider slider = speedSlider;
			UnityAction<float> call = OnSpeedSliderChanged;
			slider.m_OnValueChanged.AddListener(call);
			float value = speedSlider.value;
			speed = (float)Vector3.zeroVector;
		}
		GameObject gameObject2 = GameObject.Find("ToggleAuto");
		if (gameObject2 != null)
		{
			Toggle component = gameObject2.GetComponent<Toggle>();
			fullAutoButton = component;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 355 Invalid \"Jump target not found in method: 0x1804B9570\"");
		throw new NullReferenceException();
	}

	private void Update()
	{
		if (fullAutoButton != null)
		{
			Toggle toggle = fullAutoButton;
			isFullAuto = toggle.m_IsOn;
		}
		if (instantiatedGun != null)
		{
			UpdateGunPositionAndRotation();
		}
		if (speedSlider != null)
		{
			Slider slider = speedSlider;
			UnityAction<float> call = OnSpeedSliderChanged;
			slider.m_OnValueChanged.AddListener(call);
			float value = speedSlider.value;
			float num = default(float);
			speed = num;
		}
	}

	private IEnumerator Shoot()
	{
		_003CShoot_003Ed__17 obj = new _003CShoot_003Ed__17(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void ShootProjectile()
	{
		//IL_0012: Expected O, but got Ref
		//IL_003a: Expected O, but got Ref
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00b3: Expected O, but got I4
		//IL_00bb: Expected O, but got Ref
		//IL_0065: Expected O, but got I4
		//IL_006d: Expected O, but got Ref
		//IL_010e: Expected O, but got Ref
		//IL_010e: Expected O, but got Ref
		//IL_0138: Expected O, but got Ref
		//IL_015d: Expected O, but got Ref
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 vector = default(Vector3);
		Vector3 origin = main.ScreenPointToRay((Vector3)(&vector)).m_Origin;
		Vector3 vector3 = default(Vector3);
		if (!Physics.Raycast((Ray)(&vector), out var _, 100f))
		{
			Vector3 vector2 = default(Vector3);
			vector = vector2;
			origin = vector2;
			object obj = 0;
			object obj2 = (object)(&vector3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			object obj3 = default(object);
			Vector3 vector4 = (Vector3)(obj3 - spawnPosition.position.x);
			vector = vector4;
			object obj = 0;
			object obj2 = (object)(&vector3);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Vector3 position = spawnPosition.position;
		GameObject[] array = projectiles;
		int num = currentProjectile;
		GameObject gameObject = UnityEngine.Object.Instantiate(array[num], (Vector3)(&vector), (Quaternion)(&vector3));
		Transform transform = gameObject.transform;
		float num2 = default(float);
		transform.LookAt((Vector3)(&num2));
		Rigidbody component = gameObject.GetComponent<Rigidbody>();
		float num3 = default(float);
		component.AddForce((Vector3)(&num3));
	}

	private unsafe void UpdateGunPositionAndRotation()
	{
		//IL_0008: Expected O, but got Ref
		//IL_001b: Expected O, but got Ref
		//IL_0085: Expected O, but got Ref
		//IL_013a: Expected O, but got Ref
		//IL_014c: Expected F4, but got O
		//IL_015c: Expected F4, but got I
		//IL_0169: Expected F4, but got O
		//IL_01d5: Expected O, but got Ref
		//IL_01e3: Expected O, but got Ref
		//IL_05b3: Expected I, but got O
		//IL_024a: Expected O, but got I
		//IL_0267: Expected O, but got I
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_032a: Expected O, but got Ref
		//IL_02c5: Expected F8, but got I4
		//IL_041f: Expected O, but got Ref
		//IL_042d: Expected O, but got Ref
		//IL_0455: Expected O, but got Ref
		//IL_0550: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = mousePosition.z;
		_ = mousePosition.x;
		Ray ray = main.ScreenPointToRay(pos);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v6 (UnityEngine.Ray)+10]");
		_ = 0;
		_ = ray.m_Origin;
		ref RaycastHit hitInfo = ref System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v6 (UnityEngine.Ray)+10]");
		_ = 0;
		Ray ray2 = (Ray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		float num2 = default(float);
		float num5;
		float num6;
		float num7;
		if (!Physics.Raycast(ray2, out hitInfo))
		{
			float num = num2 * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v6 (UnityEngine.Ray)+10]");
			float num3 = 0f * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-45]");
			float num4 = 0f * 100f;
			num5 = num + (float)ray.m_Origin;
			num6 = num3 + num2;
			num7 = num4 + num2;
			float num8 = num2;
			float num9 = 100f;
		}
		else
		{
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			object obj4 = default(object);
			float num8 = (float)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rax_v34+8]");
			num7 = 0f;
			num5 = (float)obj4;
			num6 = num2;
			float num9 = num2;
		}
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num10 = num5 - position.x;
		float num11 = num6 - position.y;
		float num12 = num7 - position.z;
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180301660");
		object obj7 = default(object);
		float num13 = (float)obj7 * 57.29578f;
		nint num14 = (nint)typeof(Math);
		object obj8 = obj7 * obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v12+4]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v12+4]");
		object obj9 = num15 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v12+8]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v12+8]");
		object obj10 = num16 * 0;
		object obj11 = obj9 + obj8;
		double d = (double)obj11 + (double)obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v14 (Il2CppClass<System.Math>)+E4]");
		double num17;
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			num17 = 0.0;
		}
		else
		{
			num17 = Math.Sqrt(d);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v12+4]");
		double num18 = 0.0 / num17;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180301440");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
		object obj12 = num18 ^ 0;
		Vector3 euler = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		float num19 = (float)obj12 * 57.29578f;
		_ = 0;
		float num20 = num13 * ((float)Math.PI / 180f);
		float num21 = num19 * ((float)Math.PI / 180f);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
		if (instantiatedGun != null)
		{
			Transform transform2 = instantiatedGun.transform;
			Transform transform3 = instantiatedGun.transform;
			Quaternion rotation = transform3.rotation;
			_ = quaternion.x;
			_ = rotation.x;
			float deltaTime = Time.deltaTime;
			float t = deltaTime * 10f;
			Quaternion b = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Quaternion a = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			Quaternion quaternion2 = Quaternion.Slerp(a, b, t);
			Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			_ = quaternion2.x;
			transform2.rotation = rotation2;
			Transform transform4 = instantiatedGun.transform;
			Vector3 position2 = spawnPosition.position;
			Transform transform5 = instantiatedGun.transform;
			Vector3 forward = transform5.forward;
			float num22 = gunOffset * forward.x;
			float num23 = gunOffset * forward.y;
			float num24 = gunOffset * forward.z;
			float num25 = position2.x - num22;
			float num26 = position2.y - num23;
			float num27 = position2.z - num24;
			Vector3 position3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			transform4.position = position3;
		}
	}

	public void nextEffect()
	{
		//IL_001f: Expected O, but got I4
		GameObject[] array = projectiles;
		object obj = array.Length - 1;
		if (currentProjectile >= (nint)obj)
		{
			currentProjectile = 0;
			UpdateDisplayName();
		}
		else
		{
			int num = currentProjectile + 1;
			currentProjectile = num;
			UpdateDisplayName();
		}
	}

	public void previousEffect()
	{
		if (currentProjectile <= 0)
		{
			GameObject[] array = projectiles;
			int num = array.Length - 1;
			currentProjectile = num;
			UpdateDisplayName();
		}
		else
		{
			int num2 = currentProjectile - 1;
			currentProjectile = num2;
			UpdateDisplayName();
		}
	}

	private void UpdateDisplayName()
	{
		//IL_00e8: Expected O, but got I4
		//IL_0115: Expected O, but got I4
		Text text;
		if (missileNameText != null)
		{
			text = missileNameText;
		}
		else
		{
			Text componentInChildren = GetComponentInChildren<Text>();
			text = componentInChildren;
		}
		if (text != null)
		{
			GameObject[] array = projectiles;
			int num = currentProjectile;
			RetroProjectileScript component = array[num].GetComponent<RetroProjectileScript>();
			string text2 = component.projectileParticle.name;
			bool flag = !cleanUpMissileName;
			string arg = text2;
			object obj = 0;
			if (!flag)
			{
				string text3 = CleanUpMissileName(text2);
				arg = text3;
				obj = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			object arg3 = default(object);
			string text4 = $"{arg} ({arg2}/{arg3})";
			text.text = text4;
		}
	}

	private string CleanUpMissileName(string name)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172BC1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (name != null)
		{
			string text = name.Replace("Missile", "");
			if (text != null)
			{
				string text2 = text.Replace("Blue", " Blue");
				if (text2 != null)
				{
					string text3 = text2.Replace("Red", " Red");
					if (text3 != null)
					{
						string text4 = text3.Replace("Yellow", " Yellow");
						if (text4 != null)
						{
							string text5 = text4.Replace("Green", " Green");
							if (text5 != null)
							{
								string text6 = text5.Replace("Purple", " Purple");
								if (text6 != null)
								{
									string text7 = text6.Replace("White", " White");
									if (text7 != null)
									{
										return text7.Replace("Black", " Black");
									}
								}
							}
						}
					}
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	private void OnSpeedSliderChanged(float value)
	{
		speed = value;
	}
}
