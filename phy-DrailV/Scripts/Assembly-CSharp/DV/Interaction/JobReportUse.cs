using UnityEngine;

namespace DV.Interaction
{
	public class JobReportUse : MonoBehaviour, IItemUse
	{
		public bool HandleUse(ItemUseTarget target)
		{
			JobValidator component = target.GetComponent<JobValidator>();
			if (component == null)
			{
				return false;
			}
			component.PlayErrorSound();
			return true;
		}

		public bool IsHoverCompatible(ItemUseTarget target)
		{
			return IsUseCompatible(target);
		}

		public bool IsUseCompatible(ItemUseTarget target)
		{
			return target.GetComponent<JobValidator>();
		}

		public bool HandleHover(ItemUseTarget target)
		{
			return false;
		}
	}
}
