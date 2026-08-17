using System;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Cpp2ILInjected;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour
{
	public bool isItemSource;

	private Outline outline;

	protected DetectInteractables detectInteractables;

	public Vector3 textOffset;

	private Vector3 textOffsetCalculated;

	public static Action<string> A_DebugSpawn;

	public static Action<string> A_DebugDisable;

	public bool showOutline = true;

	protected void Start()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		Transform transform = base.transform;
		Vector3 right = transform.right;
		object obj = textOffset * right.y;
		object obj2 = textOffset * right.z;
		Transform transform2 = base.transform;
		Vector3 up = transform2.up;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseInteractable)+3C]");
		object obj3 = 0 * up.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseInteractable)+3C]");
		object obj4 = 0 * up.z;
		object obj5 = obj3 + obj;
		object obj6 = obj4 + obj2;
		Transform transform3 = base.transform;
		Vector3 forward = transform3.forward;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseInteractable)+40]");
		object obj7 = 0 * forward.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BaseInteractable)+40]");
		object obj8 = 0 * forward.z;
		object obj9 = obj7 + obj5;
		object obj10 = obj8 + obj6;
		Vector3 vector = default(Vector3);
		textOffsetCalculated = vector;
		bool flag = MapController.IsMainMenu();
		if (!flag && isItemSource != flag && ChallengesTracker.HasChallengeModifier("no_items"))
		{
			Transform transform4 = base.transform;
			Transform root = transform4.root;
			GameObject gameObject = root.gameObject;
			gameObject.SetActive(value: false);
		}
		if (ShowInDebug())
		{
			Action<string> a_DebugSpawn = A_DebugSpawn;
			if (A_DebugSpawn != null)
			{
				string debugName = GetDebugName();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v352 @ rdi_v2 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public unsafe void StartHover(DetectInteractables detectInteractables)
	{
		//IL_00a5: Expected O, but got Ref
		if (this.outline == null)
		{
			this.detectInteractables = detectInteractables;
			if (showOutline)
			{
				GameObject gameObject = base.gameObject;
				Outline outline = gameObject.AddComponent<Outline>();
				this.outline = outline;
				this.outline.OutlineMode = Outline.Mode.OutlineVisible;
				Color color = GetColor();
				object obj = default(object);
				this.outline.OutlineColor = (Color)(&obj);
				this.outline.OutlineWidth = 5f;
			}
		}
	}

	protected unsafe void RefreshInteractable()
	{
		//IL_007a: Expected O, but got Ref
		if (detectInteractables != null)
		{
			detectInteractables.RefreshCurrentInteractable();
			if (outline != null)
			{
				Color color = GetColor();
				object obj = default(object);
				outline.OutlineColor = (Color)(&obj);
			}
		}
	}

	public void StopHover()
	{
		detectInteractables = null;
		if (outline != null)
		{
			UnityEngine.Object.Destroy(outline);
			outline = null;
		}
	}

	protected void OnDestroy()
	{
		if (detectInteractables != null)
		{
			GameObject gameObject = base.gameObject;
			if (gameObject != null)
			{
				detectInteractables.InteractableDestroyed();
			}
		}
		detectInteractables = null;
		if (outline != null)
		{
			UnityEngine.Object.Destroy(outline);
			outline = null;
		}
	}

	public abstract bool Interact();

	public abstract string GetInteractString();

	public unsafe virtual Color GetColor()
	{
		//IL_0009: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		//IL_0025: Expected native int or pointer, but got O
		//IL_0033: Expected native int or pointer, but got O
		Color color = default(Color);
		((Color*)(nint)color)->r = 1f;
		((Color*)(nint)color)->g = 1f;
		((Color*)(nint)color)->b = 1f;
		((Color*)(nint)color)->a = 1f;
		return color;
	}

	public virtual bool CanInteract()
	{
		return true;
	}

	public unsafe Vector3 GetOffset()
	{
		//IL_000f: Expected F4, but got O
		//IL_000a: Expected native int or pointer, but got O
		//IL_0024: Expected F4, but got I
		//IL_001f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)textOffsetCalculated;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (BaseInteractable)+4C]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	public virtual bool ShowInDebug()
	{
		return false;
	}

	public virtual string GetDebugName()
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1+B8]");
		return (string)0;
	}
}
