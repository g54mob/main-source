using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "Tooltip Builder Properties", menuName = "Flotsam/Tooltips/Tooltip Builder Properties")]
public class TooltipBuilderProperties : ScriptableObject
{
	public int DefaultCapacity;

	public LocalizedString EffectHeader;
}
