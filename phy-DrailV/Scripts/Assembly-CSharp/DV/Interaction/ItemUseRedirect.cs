using UnityEngine;

namespace DV.Interaction
{
	public class ItemUseRedirect : MonoBehaviour
	{
		[SerializeField]
		private ItemUseTarget target;

		public ItemUseTarget Target => target;

		private void Awake()
		{
			if (!(Target != null))
			{
				Debug.LogError("ItemUseRedirect must have a ItemUseTarget assigned. Destroying self.", this);
				Object.Destroy(this);
			}
		}
	}
}
