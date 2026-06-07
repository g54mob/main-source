using System;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	[DoNotList]
	public sealed class MissingNode : Node, IMissingRecoverable
	{
		[SerializeField]
		private string _missingType;

		[SerializeField]
		private string _recoveryState;

		string IMissingRecoverable.missingType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		string IMissingRecoverable.recoveryState
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override string name => null;

		public override Type outConnectionType => null;

		public override int maxInConnections => 0;

		public override int maxOutConnections => 0;

		public override bool allowAsPrime => false;

		public override bool canSelfConnect => false;

		public override Alignment2x2 commentsAlignment => default(Alignment2x2);

		public override Alignment2x2 iconAlignment => default(Alignment2x2);
	}
}
