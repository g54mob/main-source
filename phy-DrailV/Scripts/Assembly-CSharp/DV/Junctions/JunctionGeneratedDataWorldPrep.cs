using System;
using UnityEngine;

namespace DV.Junctions
{
	[CreateAssetMenu(menuName = "DV/Junctions/JunctionGeneratedDataWorldPrep")]
	public class JunctionGeneratedDataWorldPrep : ScriptableObject
	{
		public Junction.JunctionData[] junctionData;

		public Junction.JunctionData[] oldJunctionData;

		public JunctionGeneratedDataRuntime junctionGeneratedDataRuntime;

		public void UpdateData(Junction.JunctionData[] data, bool oldData)
		{
			if (Application.isPlaying)
			{
				throw new OperationCanceledException("JunctionGeneratedDataWorldPrep: Cannot update junction data in play mode.");
			}
			if (!Application.isEditor)
			{
				throw new OperationCanceledException("JunctionGeneratedDataWorldPrep: Cannot update junction data outside of the editor.");
			}
		}
	}
}
