using System.Collections.Generic;
using UnityEngine;

public class IItemImporter : MonoBehaviour
{
	public List<ItemProperties> ImportedItems { get; }

	public Target Target { get; }
}
