using System;
using System.Collections.Generic;
using ModApi.Craft.Program.Craft;
using ModApi.Flight.UI;
using UnityEngine;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class LockNavSphereInstruction : ProgramInstruction
	{
		public enum NavSphereIndicatorType
		{
			None = 0,
			Prograde = 1,
			Retrograde = 2,
			Target = 3,
			BurnNode = 4,
			Current = 5,
			Vector = 6
		}

		[ProgramNodeProperty]
		private NavSphereIndicatorType _indicatorType;

		public override ProgramInstruction Execute(IThreadContext context)
		{
			ICraftService craft = context.Craft;
			if (craft.CraftScript.CraftNode.IsPlayer)
			{
				switch (_indicatorType)
				{
				case NavSphereIndicatorType.None:
					craft.NavSphere.UnlockHeading();
					break;
				case NavSphereIndicatorType.Prograde:
					craft.NavSphere.LockedIndicator = ModApi.Flight.UI.NavSphereIndicatorType.VelocityPrograde;
					break;
				case NavSphereIndicatorType.Retrograde:
					craft.NavSphere.LockedIndicator = ModApi.Flight.UI.NavSphereIndicatorType.VelocityRetrograde;
					break;
				case NavSphereIndicatorType.Target:
					craft.NavSphere.LockedIndicator = ModApi.Flight.UI.NavSphereIndicatorType.Target;
					break;
				case NavSphereIndicatorType.BurnNode:
					craft.NavSphere.LockedIndicator = ModApi.Flight.UI.NavSphereIndicatorType.ManeuverNode;
					break;
				case NavSphereIndicatorType.Current:
					craft.NavSphere.LockCurrentHeading();
					break;
				case NavSphereIndicatorType.Vector:
					craft.NavSphere.LockHeading(GetExpression(0).Evaluate(context).VectorValue.normalized);
					break;
				}
			}
			else
			{
				Vector3d headingDirection = Vector3d.zero;
				switch (_indicatorType)
				{
				case NavSphereIndicatorType.None:
					craft.NavSphere.UnlockCraftHeading(context.Craft.CraftScript.CraftNode);
					break;
				case NavSphereIndicatorType.Prograde:
					headingDirection = craft.CraftScript.CraftNode.Velocity;
					break;
				case NavSphereIndicatorType.Retrograde:
					headingDirection = -craft.CraftScript.CraftNode.Velocity;
					break;
				case NavSphereIndicatorType.Target:
					headingDirection = craft.NavSphere.Target.Position - craft.CraftScript.CraftNode.Position;
					break;
				case NavSphereIndicatorType.Vector:
					headingDirection = GetExpression(0).Evaluate(context).VectorValue.normalized;
					break;
				default:
					context.Log.LogError("This heading locking method isn't supported for non-player crafts.");
					break;
				case NavSphereIndicatorType.Current:
					break;
				}
				if (headingDirection.magnitude > 0.0)
				{
					craft.NavSphere.LockCraftHeading(headingDirection, context.Craft.CraftScript.CraftNode);
				}
			}
			return base.Execute(context);
		}

		public override List<ListItemInfo> GetListItems(string listId)
		{
			return new List<ListItemInfo>
			{
				new ListItemInfo($"{NavSphereIndicatorType.None}", "None", "Unlock current heading.", ListItemInfoType.None),
				new ListItemInfo($"{NavSphereIndicatorType.Prograde}", "Prograde", "Lock heading on velocity prograde.", ListItemInfoType.None),
				new ListItemInfo($"{NavSphereIndicatorType.Retrograde}", "Retrograde", "Lock heading on velocity retrograde.", ListItemInfoType.None),
				new ListItemInfo($"{NavSphereIndicatorType.Target}", "Target", "Lock heading on direction to target.", ListItemInfoType.None),
				new ListItemInfo($"{NavSphereIndicatorType.BurnNode}", "BurnNode", "Lock heading on direction required for current burn node.", ListItemInfoType.None),
				new ListItemInfo($"{NavSphereIndicatorType.Current}", "Current", "Lock heading on the craft's current direction.", ListItemInfoType.None)
			};
		}

		public override string GetListValue(string listId)
		{
			return _indicatorType.ToString();
		}

		public override void SetListValue(string listId, string value)
		{
			if (!Enum.TryParse<NavSphereIndicatorType>(value, out var result))
			{
				result = NavSphereIndicatorType.None;
			}
			_indicatorType = result;
		}
	}
}
