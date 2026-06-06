using I2.Loc;
using UnityEngine;

public abstract class TechTreeRequirementProvider : ScriptableObject
{
	[SerializeField]
	private string _label;

	[SerializeField]
	private LocalizedString _name;

	[SerializeField]
	private LocalizedString _description;

	[SerializeField]
	private Sprite _background;

	public string Label => _label;

	public LocalizedString Name => _name;

	public LocalizedString Description => _description;

	public Sprite Background => _background;

	public abstract TechTreeRequirement CreateRequirementInstance();

	public abstract bool IsProviderFor(TechTreeRequirement techTreeRequirement);

	public abstract Sprite GetIcon(TechTreeRequirement techTreeRequirement);
}
