using System;
using System.Collections.Generic;
using ModApi.Flight.UI;
using UnityEngine;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class SetTargetHeadingInstruction : ProgramInstruction
	{
		private const string PidPitch = "pid-pitch";

		private const string PidRoll = "pid-roll";

		private const string TargetHeading = "heading";

		private const string TargetPitch = "pitch";

		[ProgramNodeProperty]
		private string _property = "pitch";

		public ProgramExpression Expression => GetExpression(0);

		public override ProgramInstruction Execute(IThreadContext context)
		{
			if (context.Craft.CraftScript.CraftNode.IsPlayer)
			{
				INavSphere navSphere = context.Craft.NavSphere;
				if (_property == "pitch")
				{
					float pitch = (float)Expression.Evaluate(context).NumberValue;
					navSphere.LockHeading(pitch, navSphere.Heading);
				}
				else if (_property == "heading")
				{
					float heading = (float)Expression.Evaluate(context).NumberValue;
					navSphere.LockHeading(navSphere.Pitch, heading);
				}
				else if (_property == "pid-roll")
				{
					Vector3d vectorValue = Expression.Evaluate(context).VectorValue;
					context.Craft.SetPidGainsRoll(vectorValue.ToVector3());
				}
				else if (_property == "pid-pitch")
				{
					Vector3d vectorValue2 = Expression.Evaluate(context).VectorValue;
					context.Craft.SetPidGainsPitch(vectorValue2.ToVector3());
				}
			}
			else
			{
				context.Log.LogError("Cannot lock nav sphere because this is not the player craft.");
			}
			return base.Execute(context);
		}

		public override List<ListItemInfo> GetListItems(string listId)
		{
			return new List<ListItemInfo>
			{
				new ListItemInfo("heading", "Heading", "Set the nav sphere's target heading in degrees.", ListItemInfoType.Degrees),
				new ListItemInfo("pitch", "Pitch", "Set the nav sphere's target pitch in degrees.", ListItemInfoType.Degrees),
				new ListItemInfo("pid-pitch", "Pitch PIDs", "Set the PID values for the pitch axis.", ListItemInfoType.Vector),
				new ListItemInfo("pid-roll", "Roll PIDs", "Set the PID values for the roll axis in plane mode.", ListItemInfoType.Vector)
			};
		}

		public override string GetListValue(string listId)
		{
			return _property;
		}

		public override void SetListValue(string listId, string value)
		{
			_property = value;
		}
	}
}
