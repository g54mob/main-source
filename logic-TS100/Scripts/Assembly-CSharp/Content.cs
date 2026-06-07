using UnityEngine;
using UnityStandardAssets.ImageEffects;

public sealed class Content : MonoBehaviour
{
	public Camera MainUICamera;

	public CrtEffect CrtEffect;

	public SharpenEffect SharpenEffect;

	public Bloom BloomEffect;

	public ImageBleed ImageBleed;

	public QuantumChat QuantumChat;

	public AudioSource AudioSource;

	public GameObject StateParentObject;

	public GameObject DialogParentObject;

	public TitleWidget PrefabTitleWidget;

	public LevelSelectWidget PrefabLevelSelectWidget;

	public LevelEditorWidget PrefabLevelEditorWidget;

	public BonusCampaignWidget PrefabBonusCampaignWidget;

	public SimulationWidget PrefabSimulationWidget;

	public LevelCompleteDialogWidget PrefabLevelCompleteDialogWidget;

	public JournalDialogWidget PrefabJournalDialogWidget;

	public EscapeMenuDialogWidget PrefabEscapeMenuDialogWidget;

	public ConfirmationDialogWidget PrefabConfirmationDialogWidget;

	public MainMenuDialogWidget PrefabMainMenuDialogWidget;

	public TutorialMenuDialogWidget PrefabTutorialMenuDialogWidget;

	public AntiTamperDialogWidget PrefabAntiTamperDialogWidget;

	public QuickReferenceDialogWidget PrefabQuickReferenceDialogWidget;

	public FilePathDialogWidget PrefabFilePathDialogWidget;

	public SynchronizationDialogWidget PrefabSynchronizationDialogWidget;

	public AudioClip SoundClick;

	public AudioClip SoundBoot;

	public AudioClip SoundDrive;

	public AudioClip SoundError;

	public AudioClip SoundImageBleed;

	public AudioClip SoundPowerDown;

	public AudioClip SoundHappy;

	public AudioClip SoundModem;

	public TextAsset[] BonusPuzzles;

	public Content()
	{
		int num = 1;
		if (false)
		{
		}
		base._002Ector();
	}

	private void Awake()
	{
		if (8u != 0)
		{
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D = this;
		}
	}

	private void Start()
	{
		if (_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqIdkwNwG6hDuD_00247ZBnU6PSg_003D_003D)
		{
			int num = 8;
			if (-1 == 0)
			{
			}
			Verify();
		}
	}

	public void Verify()
	{
	}
}
