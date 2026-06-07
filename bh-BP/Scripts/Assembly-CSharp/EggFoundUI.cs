using I2.Loc;
using UnityEngine.UI;

public class EggFoundUI : OverlayUI
{
	public static EggFoundUI I;

	public CoolButton BtnClose;

	public Image ImgPreview;

	public Localize LocDesc;

	public PetType TgtEgg;

	protected override void Start()
	{
	}

	public override void Activate()
	{
	}

	protected override void OnEntryComplete()
	{
	}
}
