using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Minamolc/Game Styles Data")]
public class GameStylesData : ScriptableObject
{
	public bool applyAtEditor;

	[Space(10f)]
	public string gameVersion;

	[Space(10f)]
	[Header("Others Styles")]
	[Space(5f)]
	public RigidbodyStylesData rigidbodyStylesData;

	public ComponentStylesData componentStylesData;

	public MusicStylesData musicStylesData;

	public VolumeStylesData volumeStylesData;

	public VisualEffectStylesData visualEffectStylesData;

	public PrefabStylesData prefabStylesData;

	[Space(10f)]
	[Header("Colors")]
	[Space(5f)]
	public Color darkBackground;

	public Color lightBackground;

	public Color brightBackground;

	public Color green;

	public Color red;

	public Color blue;

	public Color yellow;

	public Color brightText;

	[Space(10f)]
	[Header("Audio Mixers")]
	[Space(5f)]
	public AudioMixer masterAudioMixer;

	public AudioMixer musicAudioMixer;

	public AudioMixer effectsAudioMixer;

	[Space(10f)]
	[Header("UI Audio Effects")]
	[Space(5f)]
	public AudioClip buttonMouseOverClip;

	public AudioClip buttonMouseClickClip;

	[Space(10f)]
	public AudioClip iconMouseClickClip;

	[Space(10f)]
	public AudioClip sliderValueChangingClip;

	[Space(10f)]
	public AudioClip levelSlotMouseOverClip;

	public AudioClip levelSlotMouseClickClip;

	[Space(10f)]
	public AudioClip toggleOverClip;

	public AudioClip toggleOnClip;

	public AudioClip toggleOffClip;

	public AudioClip keyChangedClip;

	[Space(10f)]
	public AudioClip slotDropInClip;

	public AudioClip slotDropOutClip;

	[Space(10f)]
	public AudioClip tooltipWarningClip;

	[Space(10f)]
	[Header("Construction Mode Audio Effects")]
	[Space(5f)]
	public AudioClip blockFreePlacedClip;

	public AudioClip blockFixPlacedClip;

	public AudioClip blockHingePlacedClip;

	public AudioClip blockRemovedClip;

	[Space(10f)]
	public AudioClip blockHeightChangedClip;

	[Space(10f)]
	public AudioClip toolKeyPressedClip;

	[Space(10f)]
	[Header("Transmission Mode Audio Effects")]
	[Space(5f)]
	public AudioClip hingeJointSelectedClip;

	public AudioClip motorBlockSelectedClip;

	public AudioClip connectionMadeClip;

	[Space(10f)]
	[Header("Properties Mode Audio Effects")]
	[Space(5f)]
	public AudioClip blockSelected;

	[Space(10f)]
	[Header("Level Completed Audio Effects")]
	[Space(5f)]
	public AudioClip levelSuccessfulClip;

	public AudioClip levelFailedClip;
}
