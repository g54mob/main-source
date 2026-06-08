using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

namespace Kitchen
{
	public class ViewBoundsMaintainer
	{
		private CinemachineTargetGroup TargetGroup;

		private List<CinemachineTargetGroup.Target> Targets;

		private List<CinemachineTargetGroup.Target> DefaultTargets;

		public ViewBoundsMaintainer(CinemachineTargetGroup target_group)
		{
			TargetGroup = target_group;
			Targets = new List<CinemachineTargetGroup.Target>();
			DefaultTargets = target_group.m_Targets.ToList();
		}

		public void Update(IObjectView view, MaintainInViewData mvd)
		{
			Transform transform = view.GameObject.transform;
			if (mvd.ShouldMaintain)
			{
				foreach (CinemachineTargetGroup.Target target in Targets)
				{
					if (target.target == transform)
					{
						return;
					}
				}
				Targets.Add(new CinemachineTargetGroup.Target
				{
					radius = mvd.Radius,
					target = transform,
					weight = 1f
				});
			}
			else
			{
				foreach (CinemachineTargetGroup.Target target2 in Targets)
				{
					if (target2.target == transform)
					{
						Targets.Remove(target2);
						break;
					}
				}
			}
			if (Targets.Count == 0)
			{
				TargetGroup.m_Targets = DefaultTargets.ToArray();
			}
			else
			{
				TargetGroup.m_Targets = Targets.ToArray();
			}
		}
	}
}
