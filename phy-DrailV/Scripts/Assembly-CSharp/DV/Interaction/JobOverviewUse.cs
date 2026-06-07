using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public class JobOverviewUse : MonoBehaviour, IItemUse
	{
		private JobOverview jobOverview;

		private void Awake()
		{
			jobOverview = GetComponent<JobOverview>();
		}

		public bool HandleHover(ItemUseTarget target)
		{
			if (VRManager.IsVREnabled())
			{
				return false;
			}
			if (target.GetComponent<JobValidator>() == null)
			{
				return false;
			}
			SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.JobOverviewValidatorUse);
			return true;
		}

		public bool HandleUse(ItemUseTarget target)
		{
			JobValidator component = target.GetComponent<JobValidator>();
			if (component == null)
			{
				return false;
			}
			component.ProcessJobOverview(jobOverview);
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
	}
}
