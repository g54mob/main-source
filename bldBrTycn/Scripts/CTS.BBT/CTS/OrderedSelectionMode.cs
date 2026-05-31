using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Selection/Ordered Selection Mode")]
	public class OrderedSelectionMode : SelectionMode
	{
		[field: SerializeField]
		public int Order { get; set; }
	}
}
