using System.Collections.Generic;
using TMPEffects.Modifiers;
using UnityEngine;

namespace TMPEffects.CharacterData
{
	public class ReadOnlyCharData
	{
		private CharData cData;

		public Vector3 Position => cData.Position;

		public Vector3 PositionDelta => cData.PositionDelta;

		public Vector3 Scale => cData.Scale;

		public IReadOnlyList<Rotation> Rotation => cData.Rotations;

		public CharData.Info info => cData.info;

		public ReadOnlyVertexData InitialMesh => cData.InitialMesh;

		public Vector3 InitialPosition => cData.InitialPosition;

		public Quaternion InitialRotation => cData.InitialRotation;

		public Vector3 InitialScale => cData.InitialScale;

		public ReadOnlyCharData(CharData cData)
		{
			this.cData = cData;
		}
	}
}
