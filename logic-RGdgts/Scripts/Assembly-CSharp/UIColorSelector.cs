using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class UIColorSelector : MonoBehaviour
{
	[ColorEntity]
	public int color;

	public Color colorValue => default(Color);

	private IList<ValueDropdownItem<int>> ColorList()
	{
		return null;
	}
}
