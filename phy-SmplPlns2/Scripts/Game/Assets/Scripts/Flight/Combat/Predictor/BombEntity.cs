using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat.Predictor
{
	public class BombEntity : PredictorEntity
	{
		public override void ResetSim(PartModifierScript weapon)
		{
			base.ResetSim(weapon);
			_unityDrag = 0.05f;
			List<PartConnection> partConnections = weapon.PartScript.Part.PartConnections;
			if (partConnections.Count == 1)
			{
				PartConnection partConnection = partConnections[0];
				DetacherScript modifier = partConnections[0].GetOtherPart(weapon.PartScript.Part).PartScript.GetModifier<DetacherScript>();
				if (modifier != null)
				{
					Vector3 vector = ((partConnection.PartA != weapon.PartScript.Part) ? partConnection.AttachPointsB[0].Normal : partConnection.AttachPointsB[0].Normal);
					vector *= modifier.Detacher.DetacherForce * 0.01f;
					vector = modifier.transform.TransformVector(vector);
					AddForce(vector, 0f, ForceMode.Impulse);
				}
			}
		}
	}
}
