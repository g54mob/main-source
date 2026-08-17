using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace RetroArsenalLib;

public class RetroLibCanvas : MonoBehaviour
{
	public static RetroLibCanvas GlobalAccess;

	public bool MouseOverButton;

	public Text PENameText;

	public Text ToolTipText;

	private RaycastHit rayHit;

	private void Awake()
	{
		GlobalAccess = this;
	}

	private void Start()
	{
		if (PENameText != null)
		{
			RetroVFXLibrary globalAccess = RetroVFXLibrary.GlobalAccess;
			string text = globalAccess.effectNameBuilder.ToString();
			PENameText.text = text;
		}
	}

	private unsafe void Update()
	{
		//IL_005c: Expected O, but got Ref
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Ref, but got Unknown
		//IL_007e: Expected O, but got Ref
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00c3: Expected O, but got Ref
		if (!MouseOverButton && Input.GetMouseButtonUp(0))
		{
			Camera main = Camera.main;
			Vector3 mousePosition = Input.mousePosition;
			float num = default(float);
			Ray ray = main.ScreenPointToRay((Vector3)(&num));
			Vector3 vector = default(Vector3);
			if (Physics.Raycast((Ray)(&vector), out *(RaycastHit*)(this + 56)))
			{
				object obj = this + 56;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
				RetroVFXLibrary.GlobalAccess.SpawnParticleEffect((Vector3)(&num));
			}
		}
	}

	public void UpdateToolTip(string toolTipText)
	{
		if (ToolTipText != null)
		{
			ToolTipText.text = toolTipText;
		}
	}

	public void ClearToolTip()
	{
		if (ToolTipText != null)
		{
			ToolTipText.text = "";
		}
	}

	private void SelectPreviousPE()
	{
		//IL_0022: Expected O, but got I4
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected I4, but got Unknown
		RetroVFXLibrary globalAccess = RetroVFXLibrary.GlobalAccess;
		RetroVFXLibrary.GlobalAccess.DestroyLoopingParticleEffects();
		object obj = globalAccess.CurrentParticleEffectIndex - 1;
		object obj2 = globalAccess.TotalEffects + obj;
		int currentParticleEffectIndex = obj2 % globalAccess.TotalEffects;
		globalAccess.CurrentParticleEffectIndex = currentParticleEffectIndex;
		RetroVFXLibrary.GlobalAccess.UpdateEffectNameString();
		if (PENameText != null)
		{
			RetroVFXLibrary globalAccess2 = RetroVFXLibrary.GlobalAccess;
			string text = globalAccess2.effectNameBuilder.ToString();
			PENameText.text = text;
		}
	}

	private void SelectNextPE()
	{
		//IL_0022: Expected O, but got I4
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected I4, but got Unknown
		RetroVFXLibrary globalAccess = RetroVFXLibrary.GlobalAccess;
		RetroVFXLibrary.GlobalAccess.DestroyLoopingParticleEffects();
		object obj = globalAccess.CurrentParticleEffectIndex + 1;
		int currentParticleEffectIndex = obj % globalAccess.TotalEffects;
		globalAccess.CurrentParticleEffectIndex = currentParticleEffectIndex;
		RetroVFXLibrary.GlobalAccess.UpdateEffectNameString();
		if (PENameText != null)
		{
			RetroVFXLibrary globalAccess2 = RetroVFXLibrary.GlobalAccess;
			string text = globalAccess2.effectNameBuilder.ToString();
			PENameText.text = text;
		}
	}

	private unsafe void SpawnCurrentParticleEffect()
	{
		//IL_0013: Expected O, but got Ref
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Ref, but got Unknown
		//IL_0035: Expected O, but got Ref
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_007a: Expected O, but got Ref
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		float num = default(float);
		Ray ray = main.ScreenPointToRay((Vector3)(&num));
		Vector3 vector = default(Vector3);
		if (Physics.Raycast((Ray)(&vector), out *(RaycastHit*)(this + 56)))
		{
			object obj = this + 56;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			RetroVFXLibrary.GlobalAccess.SpawnParticleEffect((Vector3)(&num));
		}
	}

	public void UIButtonClick(string buttonTypeClicked)
	{
		//IL_0055: Expected O, but got I4
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I4
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected I4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172BAA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		RetroVFXLibrary globalAccess;
		object obj;
		if (!(buttonTypeClicked == "Previous"))
		{
			if (!(buttonTypeClicked == "Next"))
			{
				return;
			}
			globalAccess = RetroVFXLibrary.GlobalAccess;
			RetroVFXLibrary.GlobalAccess.DestroyLoopingParticleEffects();
			obj = globalAccess.CurrentParticleEffectIndex + 1;
		}
		else
		{
			globalAccess = RetroVFXLibrary.GlobalAccess;
			RetroVFXLibrary.GlobalAccess.DestroyLoopingParticleEffects();
			object obj2 = globalAccess.CurrentParticleEffectIndex - 1;
			obj = globalAccess.TotalEffects + obj2;
		}
		int currentParticleEffectIndex = obj % globalAccess.TotalEffects;
		globalAccess.CurrentParticleEffectIndex = currentParticleEffectIndex;
		globalAccess.UpdateEffectNameString();
		if (PENameText != null)
		{
			RetroVFXLibrary globalAccess2 = RetroVFXLibrary.GlobalAccess;
			string text = globalAccess2.effectNameBuilder.ToString();
			PENameText.text = text;
		}
	}
}
