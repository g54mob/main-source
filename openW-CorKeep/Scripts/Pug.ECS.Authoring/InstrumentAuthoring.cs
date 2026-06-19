using NaughtyAttributes;
using UnityEngine;

[DisallowMultipleComponent]
public class InstrumentAuthoring : MonoBehaviour
{
	public InstrumentType instrumentType;

	[HideIf("instrumentType", InstrumentType.Drumkit)]
	public SFXTableIDField noteSound;

	[HideIf("instrumentType", InstrumentType.Drumkit)]
	public SFXTableIDField noteSoundOctave;

	[HideIf("instrumentType", InstrumentType.Drumkit)]
	public int keyOffsetFromC5;

	public readonly SfxUnityInspectorFriendlyID equipSound = SfxUnityInspectorFriendlyID.inventoryClose;

	public readonly SfxUnityInspectorFriendlyID unequipSound = SfxUnityInspectorFriendlyID.inventoryOpen;
}
