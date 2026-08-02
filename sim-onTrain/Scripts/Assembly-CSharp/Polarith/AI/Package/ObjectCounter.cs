using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Object Counter")]
	public sealed class ObjectCounter : MonoBehaviour
	{
		[Tooltip("A <see Text object that if assigned displays the number of objects.")]
		public Text DisplayText;

		[Tooltip("For every object in this list the child objects are counted. The sum is number of objects.")]
		public List<GameObject> ObjectCluster;

		private void Update()
		{
			int num = 0;
			foreach (GameObject item in ObjectCluster)
			{
				num += item.transform.childCount;
			}
			if (DisplayText != null)
			{
				DisplayText.text = "Pedestrians: " + num;
			}
		}
	}
}
