using System;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Events
{
	public class CreatedBodyJointEventArgs : EventArgs
	{
		private static readonly CreatedBodyJointEventArgs _static = new CreatedBodyJointEventArgs();

		public AttachPoint AttachPoint { get; private set; }

		public BodyJoint BodyJoint { get; private set; }

		public Joint Joint { get; private set; }

		public PartConnection PartConnection { get; private set; }

		private CreatedBodyJointEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatedBodyJointEventArgs> eventHandler, PartConnection partConnection, AttachPoint attachPoint, BodyJoint bodyJoint, Joint joint)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.PartConnection = partConnection;
			_static.AttachPoint = attachPoint;
			_static.BodyJoint = bodyJoint;
			_static.Joint = joint;
			try
			{
				eventHandler(null, _static);
			}
			finally
			{
				_static.PartConnection = null;
				_static.AttachPoint = null;
				_static.BodyJoint = null;
				_static.Joint = null;
			}
		}
	}
}
