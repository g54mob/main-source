using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "ResourceActivatedGEData_default", menuName = "Tower Factory/Resource Activated GE Data")]
public class ResourceActivatedGEData : ScriptableObject
{
	[SerializeField]
	private string id;

	[SerializeField]
	private LocalizedString displayName;

	[SerializeField]
	private LocalizedString description;

	[SerializeField]
	private Sprite icon;

	[SerializeField]
	private Cost[] input;

	[SerializeField]
	private GameplayEffectData[] geToApply;

	[SerializeField]
	[Tooltip("Duration <= 0 -> infinito")]
	private float duration;

	public string Id => id;

	public virtual string DisplayName
	{
		get
		{
			if (displayName != null && !displayName.IsEmpty)
			{
				return displayName.GetLocalizedString();
			}
			return "-";
		}
	}

	public virtual string Description
	{
		get
		{
			if (description != null && !description.IsEmpty)
			{
				return description.GetLocalizedString();
			}
			return "-";
		}
	}

	public Sprite Icon => icon;

	public Cost[] Input => input;

	public GameplayEffectData[] GeToApply => geToApply;

	public float Duration => duration;

	private void SetNameAsID()
	{
		id = base.name;
	}

	public bool HasAllInputElements(Storage_ResourceData storage)
	{
		for (int i = 0; i < Input.Length; i++)
		{
			if (storage.GetStoredObjectAmount(Input[i].Resource.Id) < Input[i].Amount)
			{
				return false;
			}
		}
		return true;
	}
}
