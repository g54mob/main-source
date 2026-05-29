using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Subtype DisplayColorSO", menuName = "Scriptable Objects/Display Color")]
public class DisplayColorSO : ScriptableObject
{
	public DisplaySubType subType;

	public FurnitureSO mainDisplaySO;

	public List<FurnitureSO> variants;
}
