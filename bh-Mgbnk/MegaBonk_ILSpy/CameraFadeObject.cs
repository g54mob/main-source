using System;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class CameraFadeObject : MonoBehaviour
{
	public Renderer renderer;

	private Material defaultMaterial;

	public Material fadeMaterial;

	private bool fading;

	private float stopFadeTime;

	private void Start()
	{
		//IL_00a3: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_00ba: Expected I, but got O
		Material sharedMaterial = renderer.GetSharedMaterial();
		defaultMaterial = sharedMaterial;
		Action<GameObject> b = OnFadeObject;
		Delegate obj = Delegate.Combine(PlayerCamera.A_CameraFadeObjectEnter, b);
		if ((object)obj == null)
		{
			PlayerCamera.A_CameraFadeObjectEnter = (Action<GameObject>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<GameObject> action = default(Action<GameObject>);
		bool flag = action == null;
		Delegate obj2 = obj;
		object obj3 = 0;
		object obj4 = 0;
		nint num = (nint)typeof(Action<GameObject>);
		if (!flag)
		{
			PlayerCamera.A_CameraFadeObjectEnter = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			if (obj5 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			Delegate obj6 = default(Delegate);
			obj2 = obj6;
			object obj7 = default(object);
			obj3 = obj7;
			object obj8 = default(object);
			obj4 = obj8;
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<GameObject> value = OnFadeObject;
		Delegate obj = Delegate.Remove(PlayerCamera.A_CameraFadeObjectEnter, value);
		if ((object)obj == null)
		{
			PlayerCamera.A_CameraFadeObjectEnter = (Action<GameObject>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<GameObject> action = default(Action<GameObject>);
		if (action != null)
		{
			PlayerCamera.A_CameraFadeObjectEnter = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<GameObject>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<GameObject>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnFadeObject(GameObject go)
	{
		GameObject gameObject = base.gameObject;
		bool flag = go != gameObject;
		if (!flag)
		{
			if (fading == flag)
			{
				renderer.SetMaterial(fadeMaterial);
			}
			fading = true;
			float num = MyTime.time + 0.08f;
			stopFadeTime = num;
		}
	}

	private void Update()
	{
		if (fading && !(MyTime.time < stopFadeTime))
		{
			fading = false;
			renderer.SetMaterial(defaultMaterial);
		}
	}

	private void StopFade()
	{
		fading = false;
		renderer.SetMaterial(defaultMaterial);
	}
}
