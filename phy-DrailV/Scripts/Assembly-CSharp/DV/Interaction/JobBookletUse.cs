using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public class JobBookletUse : MonoBehaviour, IItemUse
	{
		private JobBooklet jobBooklet;

		private void Awake()
		{
			jobBooklet = GetComponent<JobBooklet>();
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
			SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.JobBookletValidatorUse);
			return true;
		}

		public bool HandleUse(ItemUseTarget target)
		{
			JobValidator component = target.GetComponent<JobValidator>();
			if (component == null)
			{
				return false;
			}
			component.ValidateJob(jobBooklet);
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
