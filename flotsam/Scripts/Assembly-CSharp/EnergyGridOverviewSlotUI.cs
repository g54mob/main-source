using UnityEngine;

public abstract class EnergyGridOverviewSlotUI : MonoBehaviour
{
	public enum EnergyOverviewType
	{
		Producer = 0,
		Consumer = 1,
		Storage = 2
	}

	[SerializeField]
	private EnergyOverviewType _overviewType;

	[SerializeField]
	private Color _activeColor = new Color(1f, 1f, 1f, 1f);

	[SerializeField]
	private Color _inactiveColor = new Color(1f, 1f, 1f, 1f);

	public EnergyOverviewType OverviewType => _overviewType;

	public float EnergyAddition { get; set; }

	public float EnergyStorage { get; set; }

	public float EnergyCapacity { get; set; }

	public Color Activecolor => _activeColor;

	public Color InactiveColor => _inactiveColor;

	protected abstract GameObject SelectionGameObject { get; }

	protected abstract void UpdateOverview();

	public void Select()
	{
		Selector.Select(SelectionGameObject, ObjectType.Buildable);
	}
}
