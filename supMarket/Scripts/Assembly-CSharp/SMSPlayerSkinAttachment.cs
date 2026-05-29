using UnityEngine;

public class SMSPlayerSkinAttachment : MonoBehaviour, IAttachment
{
	public enum AttachmentId
	{
		None = 0,
		Mop_Cleaning = 1,
		Mop_Carrying = 2,
		Sponge = 3,
		Bat = 4,
		Scanner = 5,
		Tablet = 6,
		PaperBag = 7,
		Notebook = 8,
		Trashbag = 9,
		LeftHand = 10,
		RightHand = 11,
		Spoon = 12,
		IceCreamConeSocket = 13
	}

	[SerializeField]
	private AttachmentId m_Id;

	public uint Id => 0u;

	GameObject IAttachment.gameObject => null;

	Transform IAttachment.transform => null;
}
