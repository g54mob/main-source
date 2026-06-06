using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuildableOverviewCategory : MonoBehaviour
{
	[SerializeField]
	private Image _icon;

	private UnityAction<BuildableOverviewCategory> _selectCallback;

	public BuildableCategory Category { get; private set; }

	public void Initialize(BuildableCategory category, UnityAction<BuildableOverviewCategory> selectCallback)
	{
		Category = category;
		_selectCallback = selectCallback;
		_icon.overrideSprite = category.IconSprite;
		base.gameObject.SetActive(value: true);
	}

	public void Select()
	{
		_selectCallback?.Invoke(this);
	}
}
