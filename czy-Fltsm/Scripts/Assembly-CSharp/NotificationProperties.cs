using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/UI/Notification")]
public class NotificationProperties : PersistentProperties
{
	[Header("Properties")]
	[SerializeField]
	private LocalizedString _localizedDescription = "";

	[SerializeField]
	[Tooltip("This should be used for development only! If no localized description is provided, this will be used instead.")]
	private string _fallbackDescription;

	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private AudioClipProperties _audio;

	[SerializeField]
	private bool _audioOnly;

	[SerializeField]
	private float _expiration;

	[SerializeField]
	private bool _closeOnInteraction = true;

	public string LocalizedDescription => _localizedDescription.GetOrDefault(_fallbackDescription);

	public Sprite Icon => _icon;

	public AudioClipProperties Audio => _audio;

	public bool AudioOnly => _audioOnly;

	public float Expiration => _expiration;

	public bool CloseOnInteraction => _closeOnInteraction;

	public override Types Type => Types.NotificationProperties;
}
