using UnityEngine;

namespace Assets.Scripts.Vizzy.UI.Elements
{
	public class ConnectionPoint
	{
		public BlockElementScript Block { get; private set; }

		public bool CanReceive { get; set; }

		public bool CanSeek { get; set; }

		public ConnectionPointType ConnectionPointType { get; private set; }

		public Vector2 LocalPosition { get; set; }

		public Vector3 Position => Block.transform.TransformPoint(LocalPosition);

		public SpecialConnectionType SpecialConnection { get; set; }

		public ConnectionPoint(BlockElementScript block, ConnectionPointType connectionPointType, Vector2 localPosition)
		{
			Block = block;
			ConnectionPointType = connectionPointType;
			LocalPosition = localPosition;
		}

		public static bool IsCompatible(ConnectionPoint pointA, ConnectionPoint pointB)
		{
			ConnectionPointType connectionPointType = pointA.ConnectionPointType;
			ConnectionPointType connectionPointType2 = pointB.ConnectionPointType;
			bool flag = ((connectionPointType == ConnectionPointType.BoolExpression || connectionPointType == ConnectionPointType.TextExpression) && (connectionPointType2 == ConnectionPointType.BoolExpression || connectionPointType2 == ConnectionPointType.TextExpression)) || ((connectionPointType == ConnectionPointType.InstructionNext || connectionPointType == ConnectionPointType.InstructionChild) && connectionPointType2 == ConnectionPointType.InstructionPrevious) || ((connectionPointType2 == ConnectionPointType.InstructionNext || connectionPointType2 == ConnectionPointType.InstructionChild) && connectionPointType == ConnectionPointType.InstructionPrevious);
			if (flag)
			{
				if (pointA.SpecialConnection == SpecialConnectionType.Else)
				{
					flag = pointB.SpecialConnection == SpecialConnectionType.If;
				}
				else if (pointB.SpecialConnection == SpecialConnectionType.Else)
				{
					flag = pointB.SpecialConnection == SpecialConnectionType.If;
				}
			}
			return flag;
		}
	}
}
