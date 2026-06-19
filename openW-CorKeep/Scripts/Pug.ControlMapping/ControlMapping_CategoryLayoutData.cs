using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "ControlMapping_LayoutData", menuName = "Pug/Control Mapping/Mapping Layout Data", order = 1)]
public class ControlMapping_CategoryLayoutData : ScriptableObject
{
	[SerializeField]
	private LocalizedString _categoryName;

	[SerializeField]
	private List<CategoryLayoutData> _categoryLayoutData;

	public List<CategoryLayoutData> CategoryLayoutData => _categoryLayoutData;

	public LocalizedString CategoryName => _categoryName;
}
