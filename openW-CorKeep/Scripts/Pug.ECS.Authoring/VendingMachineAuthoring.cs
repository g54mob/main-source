using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

[DisallowMultipleComponent]
public class VendingMachineAuthoring : MonoBehaviour
{
	public int sizeX;

	public int sizeY;

	[ArrayElementTitle("objectID")]
	public List<ObjectData> items;
}
