using TMPro;

public class PetNameUI : OverlayUI
{
	public static PetNameUI I;

	public PetDisplayItem DispItem;

	public TMP_InputField InputName;

	public CoolButton BtnConfirm;

	private PetInst _tgtPet;

	private void Awake()
	{
	}

	public void Activate(PetInst tgt)
	{
	}

	private void OnInputChanged(string n)
	{
	}

	private void OnSubmitted(string n)
	{
	}

	private void OnConfirmClicked()
	{
	}
}
