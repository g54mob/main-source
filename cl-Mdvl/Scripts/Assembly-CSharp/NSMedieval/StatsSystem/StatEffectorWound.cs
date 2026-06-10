using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class StatEffectorWound : StatEffector
	{
		[SerializeField]
		private float severity;

		[SerializeField]
		private bool needTend;

		[SerializeField]
		private bool needRest;

		[SerializeField]
		private float severityFall;

		[SerializeField]
		private float severityMin;

		private List<EffectorBase> instancesOnRepeat;

		public float Severity => severity;

		public bool NeedTend => needTend;

		public bool NeedRest => needRest;

		public float SeverityFall => severityFall;

		public float SeverityMin => severityMin;

		public List<EffectorBase> InstancesOnRepeat
		{
			get
			{
				if (instancesOnRepeat == null)
				{
					instancesOnRepeat = new List<EffectorBase>();
					foreach (EffectorBase instance in base.Instances)
					{
						if (!(instance is AttributeModifyEffect) && !(instance is AttributeAdderModifyEffect))
						{
							instancesOnRepeat.Add(instance);
						}
					}
				}
				return instancesOnRepeat;
			}
		}

		public override void OnAfterDeserialize()
		{
			base.Duration = (severity - severityMin) / severityFall;
			base.OnAfterDeserialize();
		}
	}
}
