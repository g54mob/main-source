using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class StatusIconStaffQualifications : StatusIcon
	{
		[Serializable]
		[UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.Members)]
		private struct QualificationGui
		{
			public GameObject Root;

			public Image Icon;
		}

		private Staff _staff;

		[SerializeField]
		private List<QualificationGui> _qualifications = new List<QualificationGui>();

		public override void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			base.Initialise(emitter, level, priority);
			_staff = (Staff)emitter;
			RefreshIcons();
		}

		private void RefreshIcons()
		{
			int maxQualifications = _staff.MaxQualifications;
			for (int i = 0; i < _qualifications.Count; i++)
			{
				bool flag = i < maxQualifications;
				_qualifications[i].Root.SetActive(flag);
				if (flag)
				{
					if (i < _staff.Qualifications.Count && _staff.Qualifications[i] != null)
					{
						_qualifications[i].Icon.enabled = true;
						_qualifications[i].Icon.sprite = _staff.Qualifications[i].Definition.Icon;
					}
					else
					{
						_qualifications[i].Icon.enabled = false;
						_qualifications[i].Icon.sprite = null;
					}
				}
			}
		}

		private void Update()
		{
			RefreshIcons();
		}

		public override bool HasTimedOut()
		{
			return _level.DataViewManager.CurrentMode != DataViewManager.Mode.StaffQualifications;
		}
	}
}
