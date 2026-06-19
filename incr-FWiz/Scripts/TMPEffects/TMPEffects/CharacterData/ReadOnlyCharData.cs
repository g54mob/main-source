using System.Collections.Generic;
using TMPEffects.Modifiers;
using UnityEngine;

namespace TMPEffects.CharacterData
{
	public class ReadOnlyCharData
	{
		private CharData cData;

		public Vector3 Position => default(Vector3);

		public Vector3 PositionDelta => default(Vector3);

		public Vector3 Scale => default(Vector3);

		public IReadOnlyList<Rotation> Rotation => null;

		public CharData.Info info => default(CharData.Info);

		public ReadOnlyVertexData InitialMesh => null;

		public Vector3 InitialPosition => default(Vector3);

		public Quaternion InitialRotation => default(Quaternion);

		public Vector3 InitialScale => default(Vector3);

		public ReadOnlyCharData(CharData cData)
		{
		}
	}
}
