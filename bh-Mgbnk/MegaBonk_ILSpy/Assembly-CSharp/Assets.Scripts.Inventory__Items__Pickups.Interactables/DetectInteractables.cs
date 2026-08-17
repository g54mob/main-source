using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.UI.InGame.Levelup;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace Assets.Scripts.Inventory__Items__Pickups.Interactables;

public class DetectInteractables : MonoBehaviour
{
	private float interactableRange;

	public LayerMask whatIsInteractable;

	private BaseInteractable currentInteractable;

	public TextMeshProUGUI t_interact;

	public Transform uiParent;

	public MyGlyphDisplay glyphContainer;

	private string tagInteractable;

	public static Action<BaseInteractable, bool> A_Interacted;

	private float animationTime;

	private float animateOverTime;

	private Vector3 fromScale;

	private Vector3 toScale;

	private void Awake()
	{
		Transform transform = uiParent.transform;
		Transform parent = transform.parent;
		parent.parentInternal = null;
	}

	private unsafe void FixedUpdate()
	{
		//IL_003a: Expected O, but got Ref
		//IL_00b6: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_0164: Expected O, but got Ref
		//IL_045f: Expected O, but got Ref
		//IL_0494: Expected O, but got F4
		//IL_04db: Expected I, but got O
		Transform transform = base.transform;
		Vector3 position = transform.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float x = default(float);
		int layerMask = default(int);
		Collider[] array = Physics.OverlapSphere((Vector3)(&x), interactableRange, layerMask);
		if (currentInteractable != null && !currentInteractable.CompareTag(tagInteractable))
		{
			StopHovering();
		}
		UnityEngine.Object obj = null;
		x = position.x;
		object obj2 = 0;
		float num = 3.4028235E+38f;
		object obj3 = 0;
		float x2 = default(float);
		while ((nint)obj3 < array.Length)
		{
			GameObject gameObject = array[obj2].gameObject;
			if (gameObject.CompareTag(tagInteractable))
			{
				Transform transform2 = base.transform;
				Vector3 position2 = transform2.position;
				Transform transform3 = base.transform;
				Vector3 position3 = transform3.position;
				Vector3 vector = array[obj2].ClosestPoint((Vector3)(&x));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331420");
				bool flag = !(num > vector.x);
				x2 = position2.x;
				x = position3.x;
				if (!flag)
				{
					GameObject gameObject2 = array[obj2].gameObject;
					BaseInteractable component = gameObject2.GetComponent<BaseInteractable>();
					bool flag2 = component != null;
					float x3 = vector.x;
					x2 = position2.x;
					x = position3.x;
					if (flag2)
					{
						bool flag3 = component.CanInteract();
						bool flag4 = !flag3;
						x3 = vector.x;
						x2 = position2.x;
						x = position3.x;
						if (!flag4)
						{
							GameObject gameObject3 = array[obj2].gameObject;
							x3 = vector.x;
							x2 = position2.x;
							obj = gameObject3;
							x = position3.x;
							num = vector.x;
						}
					}
				}
			}
			obj2++;
			obj3 = obj2;
		}
		if (currentInteractable != null)
		{
			GameObject gameObject4 = currentInteractable.gameObject;
			if (obj != gameObject4)
			{
				StopHovering();
			}
		}
		if (!(obj != null))
		{
			currentInteractable = null;
			return;
		}
		if (currentInteractable != null)
		{
			GameObject gameObject5 = currentInteractable.gameObject;
			if (!(gameObject5 != obj))
			{
				return;
			}
		}
		BaseInteractable component2 = ((GameObject)obj).GetComponent<BaseInteractable>();
		currentInteractable = component2;
		currentInteractable.StartHover(this);
		animationTime = 0f;
		RefreshGlyphContainer();
		GameObject gameObject6 = uiParent.gameObject;
		gameObject6.SetActive(value: true);
		Transform transform4 = uiParent.transform;
		transform4.localScale = (Vector3)(&x2);
		Transform transform5 = uiParent.transform;
		Vector3 localScale = transform5.localScale;
		fromScale = (Vector3)localScale.x;
		_ = localScale.z;
		nint num2 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v921 @ rax_v37 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num3 = 0;
		toScale = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rcx_v34 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
	}

	public void TryInteract()
	{
		UiManager instance = UiManager.Instance;
		EncounterWindows encounterWindows = instance.encounterWindows;
		if (encounterWindows._003CencounterInProgress_003Ek__BackingField)
		{
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		if (!instance2.isTeleporting && currentInteractable != null)
		{
			bool flag = currentInteractable.Interact();
			if (currentInteractable == null)
			{
				StopHovering();
			}
			Action<BaseInteractable, bool> a_Interacted = A_Interacted;
			if (A_Interacted != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v282 @ rax_v20 (System.Action`2<BaseInteractable, System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private bool CanInteract()
	{
		//IL_009d: Expected I4, but got O
		UiManager instance = UiManager.Instance;
		if ((object)UiManager.Instance != null)
		{
			EncounterWindows encounterWindows = instance.encounterWindows;
			if ((object)instance.encounterWindows != null)
			{
				if (!encounterWindows._003CencounterInProgress_003Ek__BackingField)
				{
					MyPlayer instance2 = MyPlayer.Instance;
					if ((object)MyPlayer.Instance == null)
					{
						goto IL_008f;
					}
					if (!instance2.isTeleporting)
					{
						return true;
					}
				}
				return false;
			}
		}
		goto IL_008f;
		IL_008f:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void Update()
	{
		//IL_01ed: Invalid comparison between I4 and F4
		//IL_015c: Invalid comparison between I4 and F4
		//IL_0043: Expected F4, but got I4
		//IL_01aa: Expected O, but got Ref
		//IL_011a: Expected O, but got Ref
		if (animateOverTime > animationTime)
		{
			float num = animationTime + MyTime.deltaTime;
			if (!(0f > num))
			{
				if (num > animateOverTime)
				{
					num = animateOverTime;
				}
			}
			else
			{
				num = 0f;
			}
			animationTime = num;
			if (!(num < animateOverTime) && currentInteractable == null)
			{
				GameObject gameObject = uiParent.gameObject;
				gameObject.SetActive(value: false);
				return;
			}
		}
		float num2 = default(float);
		if (currentInteractable != null)
		{
			Transform transform = uiParent.transform;
			Transform transform2 = currentInteractable.transform;
			Vector3 position = transform2.position;
			transform.position = (Vector3)(&num2);
		}
		float t = animationTime / animateOverTime;
		float num3 = Easing.InOutCirc(t);
		Transform transform3 = uiParent.transform;
		if (0f > num3 || num3 > 1f)
		{
		}
		transform3.localScale = (Vector3)(&num2);
	}

	private unsafe void StartHovering(GameObject newObject)
	{
		//IL_008b: Expected O, but got Ref
		//IL_00c0: Expected O, but got F4
		//IL_00dd: Expected I, but got O
		BaseInteractable component = newObject.GetComponent<BaseInteractable>();
		currentInteractable = component;
		currentInteractable.StartHover(this);
		animationTime = 0f;
		RefreshGlyphContainer();
		GameObject gameObject = uiParent.gameObject;
		gameObject.SetActive(value: true);
		Transform transform = uiParent.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
		Transform transform2 = uiParent.transform;
		Vector3 localScale = transform2.localScale;
		fromScale = (Vector3)localScale.x;
		_ = localScale.z;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v18 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		toScale = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
	}

	public void RefreshCurrentInteractable()
	{
		if (currentInteractable != null)
		{
			RefreshGlyphContainer();
		}
	}

	private void StopHovering()
	{
		//IL_0083: Expected O, but got F4
		//IL_00ef: Expected I, but got O
		if (!(uiParent != null))
		{
			return;
		}
		GameObject gameObject = uiParent.gameObject;
		if (gameObject != null)
		{
			Transform transform = uiParent.transform;
			Vector3 localScale = transform.localScale;
			fromScale = (Vector3)localScale.x;
			_ = localScale.z;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v13 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			toScale = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			if (currentInteractable != null)
			{
				currentInteractable.StopHover();
			}
			animationTime = 0f;
		}
	}

	public void InteractableDestroyed()
	{
		StopHovering();
	}

	private void RefreshGlyphContainer()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172982]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		glyphContainer.SetAction("Interact");
		string interactString = currentInteractable.GetInteractString();
		t_interact.text = interactString;
	}

	public DetectInteractables()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172983]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		interactableRange = 5f;
		tagInteractable = "Interactable";
		animateOverTime = 0.3f;
		base._002Ector();
	}
}
